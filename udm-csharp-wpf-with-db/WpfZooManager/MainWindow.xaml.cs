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

namespace WpfZooManager
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["WpfZooManager.Properties.Settings.SQLEXPRESSConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            ShowZoos();
        }   

        public void ShowZoos()
        { 
            string query = "SELECT * FROM Zoo";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            using (sqlDataAdapter)
            {
                DataTable zooTable = new DataTable();
                sqlDataAdapter.Fill(zooTable);
                // Which Information from the table should be displayed in the ListBox
                listZoos.DisplayMemberPath = "Location";
                // Which Value should be used behind the scenes
                listZoos.SelectedValuePath = "Id";
                listZoos.ItemsSource = zooTable.DefaultView;
            }
        }
    }
}
