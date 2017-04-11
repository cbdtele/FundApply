using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Cydb.Common.Linq {

    /// <summary>
    /// 泛型集合 操作
    /// </summary>
    public class ListHelper {

        /// <summary>
        /// 获取实体描述
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>Dictionary[成员名，描述名]</returns>
        public static Dictionary<string, string> GetAuthors<TEntity>() where TEntity : class {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            PropertyInfo[] props = typeof(TEntity).GetProperties();
            foreach (PropertyInfo prop in props) {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs) {
                    string propName = prop.Name;
                    var a = attr as System.ComponentModel.DataAnnotations.DisplayAttribute;
                    var displayAttributeName = string.Empty;
                    if (a != null) {
                        displayAttributeName = a.Name;
                    }
                    dict.Add(propName, displayAttributeName);
                }
            }
            return dict;
        }

        #region 泛型集合转换DataTable

        /// <summary>
        /// 将集合类转换成DataTable
        /// </summary>
        /// <param name="list">集合</param>
        /// <returns></returns>
        //public static DataTable ToDataTable(IList list) {
        //    DataTable result = new DataTable();
        //    if (list.Count > 0) {
        //        PropertyInfo[] propertys = list[0].GetType().GetProperties();
        //        foreach (PropertyInfo pi in propertys) {
        //            result.Columns.Add(pi.Name, pi.PropertyType);
        //        }
        //        for (int i = 0; i < list.Count; i++) {
        //            ArrayList tempList = new ArrayList();
        //            foreach (PropertyInfo pi in propertys) {
        //                object obj = pi.GetValue(list, null);
        //                tempList.Add(obj);
        //            }
        //            object[] array = tempList.ToArray();
        //            result.LoadDataRow(array, true);
        //        }
        //    }
        //    return result;
        //}

        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(IList<T> list) {
            return ToDataTable<T>(list, null);
        }

        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="propertyName">需要返回的列的列名</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName) {
            List<string> propertyNameList = new List<string>();
            if (propertyName != null)
                propertyNameList.AddRange(propertyName);
            DataTable result = new DataTable();
            if (list.Count > 0) {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys) {
                    if (propertyNameList.Count == 0) {
                        result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else {
                        if (propertyNameList.Contains(pi.Name))
                            result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }
                for (int i = 0; i < list.Count; i++) {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys) {
                        if (propertyNameList.Count == 0) {
                            object obj = pi.GetValue(list, null);
                            tempList.Add(obj);
                        }
                        else {
                            if (propertyNameList.Contains(pi.Name)) {
                                object obj = pi.GetValue(list, null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
        #endregion

    }
}
