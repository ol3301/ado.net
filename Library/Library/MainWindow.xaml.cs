using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter;
        DataSet dataset = new DataSet();
        SqlCommandBuilder cmdbuilder = null;
        DataTable curtable = null;

        public MainWindow()
        {
            InitializeComponent();

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Library books"].ConnectionString);
            adapter = new SqlDataAdapter("", conn);
            cmdbuilder = new SqlCommandBuilder(adapter);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExecuterSql("SELECT * FROM DEBTORS");
        }

        private void ExecuterSql(string comm)
        {
            dataset.Tables.Clear();
            adapter.SelectCommand.CommandText = comm;
            adapter.Fill(dataset);
            datagrid.ItemsSource = dataset.Tables[0].DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ExecuterSql(@"
SELECT * FROM AUTHORS_BOOKS
WHERE IdBook = 3
");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ExecuterSql(@"SELECT * FROM BOOKS");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ExecuterSql(@"SELECT * FROM DEBTORS
WHERE IdGuest=2");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            adapter.DeleteCommand = new SqlCommand(@"
DELETE FROM DEBTORS",conn);
            adapter.Update(dataset);
        }
    }
}
