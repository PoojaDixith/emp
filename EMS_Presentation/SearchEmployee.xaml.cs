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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EMS_BLL;
using EMS_Entity;
using EMS_Exception;

namespace EMS_Presentation
{
    /// <summary>
    /// Interaction logic for SearchEmployee.xaml
    /// </summary>
    public partial class SearchEmployee : Window
    {
        public SearchEmployee()
        {
            InitializeComponent();
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Employee_BLL emp = new Employee_BLL();
                Employee employee = emp.SearchEmployee_Bal(int.Parse(txt_Search.Text));
               

                if (employee != null)
                {
                    txt_EName.Text = employee.Employee_Name;
                    txt_DOJ.Text = employee.DOJ.ToString();
                    txt_Location.Text = employee.Location;
                    txt_PhoneNumber.Text = employee.Phone_Number.ToString();
                    txt_Designation.Text = employee.Designation;


                }
                else
                { 
                    MessageBox.Show
                        (string.Format("Employee with id {0} does not exists.", txt_Search.Text),
                        "Employee Management System");
                }
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

    }
    }

