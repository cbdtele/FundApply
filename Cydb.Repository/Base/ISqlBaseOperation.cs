using System.Collections.Generic;

namespace Cydb.Repository.Base {
    public interface ISqlBaseOperation {
        /// <summary>
        /// ��ѯһ����¼
        /// </summary>
        /// <returns></returns>
        T Get<T>(string str, object param = null);
        dynamic Get(string str, object param = null);


        /// <summary>
        /// ִ�в�ѯ����
        /// </summary>
        /// <returns></returns>
        List<T> Query<T>(string str, object param = null);
        List<dynamic> Query(string str, object param = null);

        /// <summary>
        /// ִ��Oracle�洢����
        /// </summary>
        /// <param name="procedureName">�洢������</param>
        /// <param name="oracleDynamicParameters">����</param>
        /// <returns></returns>
        List<T> ExecuteProcedure<T>(string procedureName, OracleDynamicParameters oracleDynamicParameters);
        List<dynamic> ExecuteProcedure(string procedureName, OracleDynamicParameters oracleDynamicParameters);
    }
}