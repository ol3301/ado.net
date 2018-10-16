using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Configuration;
using System.Windows;

namespace GraficsInAdo
{
    class ViewModel:BindableBase 
    {
        #region Sql
        private SqlConnection conn;
        private SqlDataAdapter adapter ;
        private DataSet dataset = new DataSet();
        #endregion  

        #region ViewMovel
        public ObservableCollection<TabItem> TabItems { get; set; }
        public DelegateCommand<string> Execute { get; set; }
        #endregion

        public ViewModel()
        {
            TabItems = new ObservableCollection<TabItem>();
            Task.Run(()=>
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Lib"].ConnectionString);
                Execute = new DelegateCommand<string>(_Execute);
                adapter = new SqlDataAdapter("", conn);
            });
        }

        private void _Execute(string com)
        {
            //lol
            dataset.Tables.Clear();
            TabItems.Clear();

            adapter.SelectCommand.CommandText = com;
            adapter.Fill(dataset);

            for(int i = 0; i < dataset.Tables.Count; ++i)
            {
                TabItem item = new TabItem();
                item.Header = i.ToString();

                DataGrid view = new DataGrid();
                view.ItemsSource = dataset.Tables[i].DefaultView;

                item.Content = view;

                TabItems.Add(item);
            }
        }
    }
}
