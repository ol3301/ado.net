using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Photo_album
{
    /// <summary>
    /// Общий класс для использования sql
    /// </summary>
    public static class SqlWorker
    {
        static SqlConnection conn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["Albums"].ConnectionString);
        static SqlCommand comm = null;
        static SqlCommandBuilder cmd = null;
        
        static SqlDataAdapter adapter { get; set; }
        static DataSet set { get; set; }

        public static async Task CreateNewAlbumAsync(string name)
        {
            try
            {
                await conn.OpenAsync();

                comm = conn.CreateCommand();
                comm.CommandText = @"
    CREATE TABLE "+name+@" (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Image]       VARBINARY (MAX) ,
    [Description] NVARCHAR (MAX)  NULL,
    [Category]  NVARCHAR(100)     NOT NULL,
    [Date]        DATE            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
";
                await comm.ExecuteNonQueryAsync();
            }   
            finally
            {
                conn.Close();
            }
        }

        public static List<DataTable> GetTables()
        {
            adapter = new SqlDataAdapter(@"
SELECT name FROM sysobjects WHERE status>=0 AND type='U' ", conn);
            set = new DataSet();

            adapter.Fill(set);

            List<string> list = new List<string>();

            foreach (DataRow i in set.Tables[0].Rows)
               list.Add(i.ItemArray[0].ToString());

            set.Tables.Clear();

            adapter.SelectCommand.CommandText = "";

            foreach (string i in list)
                adapter.SelectCommand.CommandText += $"SELECT * FROM {i}; ";


            if (adapter.SelectCommand.CommandText.Length > 0)
                adapter.SelectCommand.CommandText =
                    adapter.SelectCommand.CommandText.Remove(adapter.SelectCommand.CommandText.Length - 1, 1);

            if (adapter.SelectCommand.CommandText.Length == 0)
                return null;

            adapter.Fill(set);

            List<DataTable> res = new List<DataTable>();

            for(int i=0;i<set.Tables.Count;++i)
            {
                set.Tables[i].TableName = list[i];
                    res.Add(set.Tables[i]);
            }

            return res;
        }

        public static void Update(string tablename)
        {
            //            adapter.InsertCommand = conn.CreateCommand();
            //            adapter.InsertCommand.CommandText = @"INSERT INTO @tablename VALUES
            //()";

            cmd = new SqlCommandBuilder(adapter);
            
            adapter.Update(set.Tables[tablename]);
        }

        public static DataRowCollection SortTable(string tablename,string category)
        {
            //DataViewManager manager = new DataViewManager(set);
            //manager.DataViewSettings[tablename].RowFilter = $"Category = '{category}'";
            //return manager.CreateDataView(set.Tables[tablename]);
            return null;
        }
    }
}
