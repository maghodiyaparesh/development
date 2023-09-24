using CrystalFlights.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using System.Text;

namespace CrystalFlights.Setup
{
    public static class SqlHelper
    {
        private static SqlConnection _connection;

        static SqlHelper()
        {
            _connection = GetConnection();
        }

        public static SqlConnection GetConnection()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);

            var config = configuration.Build();
            var connectionString = config.GetConnectionString("MyConnection");

            return new SqlConnection(connectionString);
        }

        public static void CreateTable(string commandText)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            using (var command = new SqlCommand(commandText, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public static int ExecuteNonQuery(string commandText, params SqlParameter[] commandParameters)
        {
            int affectedRows = 0;
            
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            using (var command = new SqlCommand(commandText, _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(commandParameters);
                affectedRows = command.ExecuteNonQuery();
            }

            return affectedRows;
        }

        public static DataSet ExecuteQuery(string commandText, params SqlParameter[] parameters)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            using (var command = new SqlCommand(commandText, _connection))
            {
                DataSet ds = new DataSet();
                command.CommandType = CommandType.Text;
                command.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return ds;
            }
        }

        public static void CreateTable<T>(T r)
        {
            StringBuilder query = new StringBuilder("");

            List<SqlParameter> param = new List<SqlParameter>();
            string qryApp_1 = "", qryApp_2 = "";
            foreach (PropertyInfo p in typeof(T).GetProperties())
            {
                if (!p.Name.Equals("Id") && !p.Name.Equals("Item"))
                {
                    object[] attribute = p.GetCustomAttributes(typeof(CustomProperty), true);
                    CustomProperty myAttribute = (CustomProperty)attribute[0];

                    if (myAttribute.IgnoreField)
                        continue;

                    //[Name] [varchar](50) NULL,
                    qryApp_1 += "[" + myAttribute.FieldName + "] [" + myAttribute.FieldType + "](50) NULL,";
                    qryApp_2 += "@" + myAttribute.FieldName + ",";

                    var val = typeof(T).GetProperty(p.Name).GetValue(r);

                    if (myAttribute.FieldLength != 0)
                        param.Add(new SqlParameter("@" + myAttribute.FieldName, myAttribute.FieldType, myAttribute.FieldLength) { Value = (myAttribute.JsonConvert) ? JsonConvert.SerializeObject(val) : val });
                    else
                        param.Add(new SqlParameter("@" + myAttribute.FieldName, myAttribute.FieldType) { Value = (myAttribute.JsonConvert) ? JsonConvert.SerializeObject(val) : val });
                }
            }
            var tableInfo = typeof(T).GetCustomAttribute(typeof(TableAttribute), false) as TableAttribute;
            
            query.Append("IF OBJECT_ID('dbo.dr_" + tableInfo.Name + "', 'U') IS NOT NULL ");
            query.Append("DROP TABLE [dbo].[dr_" + tableInfo.Name + "] ");

            query.Append("CREATE TABLE [dbo].[dr_" + tableInfo.Name + "]( ");
            query.Append("[Id] [bigint] IDENTITY(1,1) NOT NULL, ");
            query.Append(qryApp_1.Trim(','));
            query.Append("CONSTRAINT [PK_" + tableInfo.Name + "] PRIMARY KEY CLUSTERED([Id] ASC) )");

            CreateTable(query.ToString());
        }

        public static long Save<T>(T r)
        {
            StringBuilder query = new StringBuilder("");

            List<SqlParameter> param = new List<SqlParameter>();
            string qryApp_1 = "", qryApp_2 = "";
            foreach (PropertyInfo p in typeof(T).GetProperties())
            {
                if (!p.Name.Equals("Id") && !p.Name.Equals("Item"))
                {
                    object[] attribute = p.GetCustomAttributes(typeof(CustomProperty), true);
                    CustomProperty myAttribute = (CustomProperty)attribute[0];

                    if (myAttribute.IgnoreField)
                        continue;

                    qryApp_1 += myAttribute.FieldName + ",";
                    qryApp_2 += "@" + myAttribute.FieldName + ",";

                    var val = typeof(T).GetProperty(p.Name).GetValue(r);

                    if (myAttribute.FieldLength != 0)
                        param.Add(new SqlParameter("@" + myAttribute.FieldName, myAttribute.FieldType, myAttribute.FieldLength) { Value = (myAttribute.JsonConvert) ? JsonConvert.SerializeObject(val) : val });
                    else
                        param.Add(new SqlParameter("@" + myAttribute.FieldName, myAttribute.FieldType) { Value = (myAttribute.JsonConvert) ? JsonConvert.SerializeObject(val) : val });
                }
            }
            var tableInfo = typeof(T).GetCustomAttribute(typeof(TableAttribute), false) as TableAttribute;
            query.Append("INSERT INTO " + tableInfo.Name + "(" + qryApp_1.Trim(',') + ") VALUES ( ");
            query.Append(qryApp_2.Trim(',') + ") SELECT SCOPE_IDENTITY()");

            DataSet ds = ExecuteQuery(query.ToString(), param.ToArray());

            if (ds != null)
                return long.Parse(ds.Tables[0].Rows[0][0].ToString());
            else
                return 0;
        }

        public static T Update<T>(T r)
        {
            return r;
        }

        public static long Delete<T>(T r)
        {
            return 0;
        }

        public static T GetDataById<T>(int id) where T : class, new()
        {
            T r = new T();

            if (id != 0)
            {
                StringBuilder query = new StringBuilder("");

                query.Append("SELECT * FROM " + typeof(T).Name + " WHERE Id=" + id);
                DataSet ds = ExecuteQuery(query.ToString());

                List<T> lst = ConvertDataSetToObject<T>(ds);

                if (lst != null && lst.Count != 0)
                    r = lst[0];
            }

            return r;
        }

        public static List<T> GetDataByIds<T>(int[] ids) where T : class, new()
        {
            List<T> r = new List<T>();

            if (ids != null)
            {
                string idsAdd = string.Join("','", ids);

                StringBuilder query = new StringBuilder("");

                query.Append("SELECT * FROM " + typeof(T).Name + " WHERE Id IN(" + idsAdd + ")");
                DataSet ds = ExecuteQuery(query.ToString());

                r = ConvertDataSetToObject<T>(ds);
            }

            return r;
        }

        public static List<T> GetAllData<T>() where T : class, new()
        {
            List<T> r = new List<T>();

            StringBuilder query = new StringBuilder("");

            query.Append("SELECT * FROM " + typeof(T).Name);
            DataSet ds = ExecuteQuery(query.ToString());

            r = ConvertDataSetToObject<T>(ds);

            return r;
        }

        public static List<T> ConvertDataSetToObject<T>(DataSet ds) where T : new()
        {
            List<T> lst = new List<T>();
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst.Add(ConvertDataRowToObject<T>(dr));
                }
            }

            return lst;
        }

        public static T ConvertDataRowToObject<T>(DataRow dr) where T : new()
        {
            Type entityType = typeof(T);
            //var pt = Array.Find(entityType.DeclaringMethod, element => element.Name.Equals("MapToObject"));
            MethodInfo mi = typeof(T).GetMethod("MapToObject");


            T r = new T();
            foreach (DataColumn column in dr.Table.Columns)
            {
                object value = dr[column.ColumnName];
                if (value == DBNull.Value) value = null;
                PropertyInfo property = entityType.GetProperty(column.ColumnName, BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
                try
                {
                    if (property != null && property.CanWrite)
                    {
                        Type propertyType = property.PropertyType;
                        if (property.PropertyType.IsEnum)
                            value = Enum.ToObject(property.PropertyType, int.Parse(value.ToString()));
                        else if (property.PropertyType.IsGenericType && !property.PropertyType.Name.Equals("Nullable`1"))
                            value = value.ToString().Replace("\"", "").Replace("[", "").Replace("]", "").Split(',').ToList();

                        property.SetValue(r, value, null);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return r;
        }
    }
}
