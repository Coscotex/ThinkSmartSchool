using LumenWorks.Framework.IO.Csv;
using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;
using Excel;
using Microsoft.AspNetCore.Http;

namespace ThinkSmartSchools.Models.Common
{
    public class ReadExcelFileHelper
    {
        public List<FailedDBEntriesVM> failedDataRows = new List<FailedDBEntriesVM>();

        public DataTable Read(IFormFile upload)
        {
            DataTable excelTable = new DataTable();
            IExcelDataReader reader = null;
            DataSet result = null;
            var stream = new FileStream(Path.GetTempFileName(), FileMode.Create, FileAccess.ReadWrite, FileShare.None, 4096, FileOptions.DeleteOnClose);
            if (upload.FileName.EndsWith(".csv"))
            {
                using (CsvReader csvReader = new CsvReader(new StreamReader(stream), true))
                {
                    excelTable.Load(csvReader);
                    stream.Dispose();
                }
                return excelTable;
            }
            else if (upload.FileName.EndsWith(".xls"))
            {
                reader = ExcelReaderFactory.CreateBinaryReader(stream);
                reader.IsFirstRowAsColumnNames = true;

                result = reader.AsDataSet();
                reader.Close();
                stream.Dispose();
                return (result.Tables[0]);
            }
            else if (upload.FileName.EndsWith(".xlsx"))
            {
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                reader.IsFirstRowAsColumnNames = true;

                result = reader.AsDataSet();
                reader.Close();
                stream.Dispose();
                return (result.Tables[0]);
            }
            else
            {
                excelTable = null;
                stream.Dispose();
                return excelTable;
            }
        }

        public List<T> readAndCreateMultipleInstances<T>(DataTable excelTable)
        {
            List<T> people = new List<T>();
            bool headerCheck = true;
            // Check if the headers match the class type properties         
            foreach (DataColumn col in excelTable.Columns)
            {
                if (!typeof(T).GetProperties().Any(d => d.Name == col.ColumnName))
                {
                    headerCheck = false;
                }
            }
            //Create an instance of T for every row and add it to the List being returned in this method
            if (headerCheck)
            {
                foreach (DataRow row in excelTable.Rows)
                {
                    object instance = Activator.CreateInstance(typeof(T));
                    foreach (DataColumn col in excelTable.Columns)
                    {
                        PropertyInfo f = instance.GetType().GetProperty(col.ColumnName);
                        try
                        {
                            if (f.PropertyType.Equals(typeof(DateTime?))) { f.SetValue(instance, (DBNull.Value.Equals(row[col.ColumnName])) ? null : row[col.ColumnName]); }
                            else { f.SetValue(instance, Convert.ChangeType(row[col.ColumnName], f.PropertyType)); }
                        }
                        catch (Exception ex)
                        {
                            instance = null;
                            FailedDBEntriesVM fdm = new FailedDBEntriesVM { failedDataRows = row, errorMessage = ex.ToString() };
                            failedDataRows.Add(fdm); break;
                        }
                    }
                    if (instance != null) { people.Add((T)instance); }
                }
            }
            return people;
        }
    }
}
