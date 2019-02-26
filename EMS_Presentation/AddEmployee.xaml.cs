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
using System.Data;
using System.Data.SqlClient;
using EMS_Entity;
using EMS_Exception;
using EMS_BLL;

namespace EMS_Presentation
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        SqlConnection conObj = new SqlConnection(@"Data Source = ndamssql\sqlilearn; Initial Catalog = Training_12Dec18_Bangalore; User ID = sqluser; Password=sqluser");
        SqlCommand cmdObj = new SqlCommand();
        SqlDataReader rdrStudent = null;
        DataTable dtStudent = new DataTable();

        public AddEmployee()
        {
            InitializeComponent();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Employee emp = new Employee
                {
                    //Employee_Id = int.Parse(tb_EId.text),

                    Employee_Name = txt_EName.Text,
                    DOJ = Convert.ToDateTime(dp_DOJ.Text),
                    Location = cb_Location.Text,
                    Phone_Number = long.Parse(txt_PhoneNumber.Text),
                    Designation= cb_Designation.Text
                };
                Employee_BLL eb = new Employee_BLL();
                int eid = eb.AddEmployee_Bal(emp);

                MessageBox.Show(string.Format("New Employee Added.\nEmployee Id: {0}", eid),
                    "Employee Management System");
            }
            catch (Employee_Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee Management System");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message, "Employee Management System");
            }

        }

        private void Btn_Display_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
    }

