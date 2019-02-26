using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Repositories
{
    /// <summary>
    /// 此类写成静态的类并创建一个从DataTable转换到泛型对象的静态扩展方法
    /// </summary>
    public static class DataConverter
    {
        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            var obj = new T();
            var tType = obj.GetType();
            var list = new List<T>();
            //Define what attributes to be read from the class
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

            //Read Attribute Names and Types
            var objFieldNames = typeof(T).GetProperties(flags)
                .Select(item => new
                {
                    item.Name,
                    Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
                }).ToList();

            //Read Datatable column names and types
            var dtlFieldNames = table.Columns.Cast<DataColumn>()
                .Select(item => new
                {
                    Name = item.ColumnName,
                    Type = item.DataType
                }).ToList();

            foreach (var row in table.Rows.Cast<DataRow>())
            {
                foreach (var prop in objFieldNames)
                {
                    if (!dtlFieldNames.Any(x => x.Name.Equals(prop.Name, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        continue;
                    }
                    var propertyInfo = tType.GetProperty(prop.Name);
                    var rowValue = row[prop.Name];
                    if (propertyInfo == null) continue;
                    var t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;

                    var safeValue = (rowValue == null || DBNull.Value.Equals(rowValue)) ? null : Convert.ChangeType(rowValue, t);
                    propertyInfo.SetValue(obj, safeValue, null);
                }
                list.Add(obj);
            }
            return list;
        }
    }
}
