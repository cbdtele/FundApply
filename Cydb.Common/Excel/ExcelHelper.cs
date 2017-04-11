using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Cydb.Common.Excel {
    public class ExcelHelper {

        /// <summary>
        /// 利用模板，导出到Excel（单个类别）
        /// </summary>
        /// <param name="dataList">源</param>
        /// <param name="strFileName">生成的文件路径、名称</param>
        /// <param name="strTemplateFileName">模板的文件路径、名称</param>
        /// <param name="titleName">表头名称</param>
        public static void ExportExcelForDtByNpoi<T>(List<T> dataList, string strFileName, string strTemplateFileName, string titleName) where T : class {
            HttpResponse response = HttpContext.Current.Response;
            try {
                using (MemoryStream ms = ExportExcelForDtByNpoi<T>(dataList, strTemplateFileName, titleName)) {
                    byte[] data = ms.ToArray();
                    response.Clear();
                    response.Charset = "UTF-8";
                    response.ContentType = "application/vnd-excel"; //"application/vnd.ms-excel";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + strFileName));
                    HttpContext.Current.Response.BinaryWrite(data);
                }
            }
            catch (Exception e) {
                response.Write($@"<h1>导出出现错误！</h1>
错误详情：
{e.Message}");
            }

        }

        /// <summary>
        /// 利用模板，导出到Excel（单个类别）
        /// </summary>
        /// <param name="dataList">DataTable</param>
        /// <param name="strTemplateFileName">模板的文件路径、名称</param>
        /// <param name="titleName">表头名称</param>
        /// <returns></returns>
        private static MemoryStream ExportExcelForDtByNpoi<T>(
            List<T> dataList,
            string strTemplateFileName,
            string titleName) where T : class {
            FileStream file = new FileStream(strTemplateFileName, FileMode.Open, FileAccess.Read);//读入excel模板
            HSSFWorkbook workbook = new HSSFWorkbook(file);
            string sheetName = "Sheet1";
            ISheet sheet = workbook.GetSheet(sheetName);

            #region 表头
            //IRow headerRow = sheet.GetRow(0);
            //ICell headerCell = headerRow.GetCell(0);
            //headerCell.SetCellValue(titleName);
            #endregion

            Type type = typeof(T);
            PropertyInfo[] pis = type.GetProperties();
            var piIndex = 0;
            int rowIndex = 3;           //起始行
            IRow tag = sheet.GetRow(2); //标签
            foreach (T data in dataList) {
                IRow dataRow = sheet.CreateRow(rowIndex);
                while (piIndex < pis.Length) {
                    try {
                        var tagValue = tag.GetCell(piIndex).StringCellValue;
                        var propertyInfo = data.GetType().GetProperty(tagValue).GetValue(data, null).ToString();
                        dataRow.CreateCell(piIndex).SetCellValue(propertyInfo);
                    }
                    catch (Exception e) {
                        dataRow.CreateCell(piIndex).SetCellValue("");
                    }
                    piIndex++;
                }
                piIndex = 0;
                rowIndex++;
            }

            // 格式化当前sheet，用于数据total计算
            sheet.ForceFormulaRecalculation = true;
            using (MemoryStream ms = new MemoryStream()) {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                sheet = null;
                workbook = null;
                //sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }

    }
}
