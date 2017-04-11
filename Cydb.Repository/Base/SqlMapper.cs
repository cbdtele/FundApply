/*
 .NET 3.5+ 
 适配 SqlServer，SqlServerCE， Oracle， MySQL，SQLite
 李科笠 2015年10月12日 10:08:41
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Dapper;

namespace Cydb.Repository.Base {
    /// <summary>
    /// 数据库初始化基类
    /// 来一个口味清淡的。。。
    /// PS：我为服务Ajax而生！
    /// </summary>
    public class DbBase : IDisposable {
        public string connectionName = "sqlConn";
        private string paramPrefix = "@";
        private string _providerName = @"System.Data.OracleClient"; //驱动
        private IDbConnection dbConnecttion;
        private DbProviderFactory dbFactory;
        private DBType _dbType = DBType.Oracle;
        public IDbConnection DbConnecttion { get { return dbConnecttion; } }
        public string ParamPrefix { get { return paramPrefix; } }
        /// <summary>
        /// 数据库事物
        /// </summary>
        public IDbTransaction DbTransaction { get { return dbConnecttion.BeginTransaction(); } }

        public DbBase() {
            var connStr = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            if (!string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[connectionName].ProviderName))
                _providerName = ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
            else
                throw new Exception("错误，ConnectionStrings中没有配置提供程序ProviderName");
            dbFactory = DbProviderFactories.GetFactory(_providerName);
            dbConnecttion = dbFactory.CreateConnection();
            dbConnecttion.ConnectionString = connStr;
            dbConnecttion.Open();
        }

        private void SetParamPrefix() {
            string dbtype = (dbFactory == null ? dbConnecttion.GetType() : dbFactory.GetType()).Name;
            // 使用类型名判断
            if (dbtype.StartsWith("MySql")) _dbType = DBType.MySql;
            else if (dbtype.StartsWith("SqlCe")) _dbType = DBType.SqlServerCE;
            else if (dbtype.StartsWith("Oracle")) _dbType = DBType.Oracle;
            else if (dbtype.StartsWith("SQLite")) _dbType = DBType.SQLite;
            else if (dbtype.StartsWith("System.Data.SqlClient.")) _dbType = DBType.SqlServer;
            else if (_providerName.IndexOf("MySql", StringComparison.InvariantCultureIgnoreCase) >= 0) _dbType = DBType.MySql;
            else if (_providerName.IndexOf("SqlServerCe", StringComparison.InvariantCultureIgnoreCase) >= 0) _dbType = DBType.SqlServerCE;
            else if (_providerName.IndexOf("Oracle", StringComparison.InvariantCultureIgnoreCase) >= 0) _dbType = DBType.Oracle;
            else if (_providerName.IndexOf("SQLite", StringComparison.InvariantCultureIgnoreCase) >= 0) _dbType = DBType.SQLite;

            if (_dbType == DBType.MySql && dbConnecttion != null && dbConnecttion.ConnectionString != null && dbConnecttion.ConnectionString.IndexOf("Allow User Variables=true") >= 0)
                paramPrefix = "?";
            if (_dbType == DBType.Oracle)
                paramPrefix = ":";
        }

        /// <summary>
        /// 数据库类型枚举
        /// </summary>
        public enum DBType {
            SqlServer,
            SqlServerCE,
            MySql,
            Oracle,
            SQLite
        }

        public void Dispose() {
            if (dbConnecttion != null) {
                try {
                    dbConnecttion.Dispose();
                }
                catch {
                    // none
                }
            }
        }
    }

    public class OracleDynamicParameters : SqlMapper.IDynamicParameters {
        private readonly DynamicParameters _dynamicParameters = new DynamicParameters();

        private readonly List<OracleParameter> _oracleParameters = new List<OracleParameter>();

        public void Add(string name, object value = null, DbType dbType = DbType.AnsiString, ParameterDirection? direction = null, int? size = null) {
            _dynamicParameters.Add(name, value, dbType, direction, size);
        }

        public void Add(string name, OracleType oracleDbType, ParameterDirection direction) {
            var oracleParameter = new OracleParameter(name, oracleDbType) { Direction = direction };
            _oracleParameters.Add(oracleParameter);
        }

        public void Add(string name, OracleType oracleDbType, int size, ParameterDirection direction) {
            var oracleParameter = new OracleParameter(name, oracleDbType, size) { Direction = direction };
            _oracleParameters.Add(oracleParameter);
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity) {
            ((SqlMapper.IDynamicParameters)_dynamicParameters).AddParameters(command, identity);

            var oracleCommand = command as OracleCommand;

            if (oracleCommand != null) {
                oracleCommand.Parameters.AddRange(_oracleParameters.ToArray());
            }
        }

        public T Get<T>(string parameterName) {
            var parameter = _oracleParameters.SingleOrDefault(t => t.ParameterName == parameterName);
            if (parameter != null)
                return (T)Convert.ChangeType(parameter.Value, typeof(T));
            return default(T);
        }

        public T Get<T>(int index) {
            var parameter = _oracleParameters[index];
            if (parameter != null)
                return (T)Convert.ChangeType(parameter.Value, typeof(T));
            return default(T);
        }
    }

    public sealed class DbString {
        public DbString() { Length = -1; }
        public bool IsAnsi { get; set; }
        public bool IsFixedLength { get; set; }
        public int Length { get; set; }
        public string Value { get; set; }
        public void AddParameter(IDbCommand command, string name) {
            if (IsFixedLength && Length == -1) {
                throw new InvalidOperationException("If specifying IsFixedLength,  a Length must also be specified");
            }
            var param = command.CreateParameter();
            param.ParameterName = name;
            param.Value = (object)Value ?? DBNull.Value;
            if (Length == -1 && Value != null && Value.Length <= 4000) {
                param.Size = 4000;
            }
            else {
                param.Size = Length;
            }
            param.DbType = IsAnsi ? (IsFixedLength ? DbType.AnsiStringFixedLength : DbType.AnsiString) : (IsFixedLength ? DbType.StringFixedLength : DbType.String);
            command.Parameters.Add(param);
        }
    }
}
