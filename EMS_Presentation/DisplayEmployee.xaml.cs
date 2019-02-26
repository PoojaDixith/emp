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
using System.Windows.Shapes;
using EMS_BLL;
using EMS_Entity;
using EMS_Exception;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EMS_Presentation
{
    /// <summary>
    /// Interaction logic for DisplayEmployee.xaml
    /// </summary>
    public partial class DisplayEmployee : Window
    {
        SqlConnection conObj = new SqlConnection(@"Data Source = ndamssql\sqlilearn; Initial Catalog = Training_12Dec18_Bangalore; User ID = sqluser; Password=sqluser");
        SqlCommand cmdObj = new SqlCommand();
        //SqlDataReader rdrStudent = null;
        DataTable dtStudent = new DataTable();
        public DisplayEmployee()
        {
            InitializeComponent();
        }
        private void Btn_Display_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee_BLL emp = new Employee_BLL();
                DataTable dtEmployee = emp.DisplayEmployee_Bal();
                dg_Employee.ItemsSource = dtEmployee.DefaultView;
            }
            catch (Employee_Exception ex)
            {
                MessageBox.Show(ex.Message, "Student Management System");
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message, "Student Management System");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Student Management System");
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
