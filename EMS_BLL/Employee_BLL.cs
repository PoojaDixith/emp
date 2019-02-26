using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EMS_Entity;
using EMS_Exception;
using EMS_DAL;
using System.Text.RegularExpressions;
namespace EMS_BLL

{
    public class Employee_BLL
    {
        public bool ValidateEmployee(Employee emp)
        {
            bool isValidEmployee = true;
            StringBuilder sb = new StringBuilder();

            if (emp.Employee_Id.ToString().Equals(string.Empty))
            {
                isValidEmployee = false;
                sb.Append("Employee ID cannot be blank " + Environment.NewLine);

            }
            if (!(Regex.IsMatch(emp.Employee_Name, "[A-Z][a-z]{3,}")))
            {
                isValidEmployee = false;
                sb.Append("Employee Name must have only characters starting with Uppercase " + Environment.NewLine);
            }
            if (emp.DOJ == DateTime.Today)
            {
                isValidEmployee = false;
                sb.Append("Employee " + Environment.NewLine);

                //}
                //if (!(Regex.IsMatch(emp.Location, "[A-Z][a-z]{3,}")))
                //{
                //    isValidEmployee = false;
                //    sb.Append("Employee Location must have only characters starting with Uppercase " + Environment.NewLine);
            }
                if (!((emp.Phone_Number > 6000000000) && (emp.Phone_Number < 7000000000)))
            {
                isValidEmployee = false;
                sb.Append(Environment.NewLine + "Phone No must be of 10 digits and must begin with 6");
            }

            if (!isValidEmployee)
            {
                throw new Employee_Exception(sb.ToString());
            }

            return isValidEmployee;

        }
        public int AddEmployee_Bal(Employee emp)
        {
            int EmpId = 0;
            try
            {
                Emploee_DAL ed = new Emploee_DAL();
                if (ValidateEmployee(emp))
                {
                    EmpId = ed.AddEmployee(emp);

                }
                else throw new Employee_Exception("Failed to Add Employee");
                return EmpId;

            }
            catch (Employee_Exception se)
            {
                throw se;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DisplayEmployee_Bal()
        {
            try
            {
                Emploee_DAL ed = new Emploee_DAL();
                DataTable dtEmployee = ed.DisplayEmployee();
                if (dtEmployee.Rows.Count <= 0)
                {
                    throw new Employee_Exception("No Employees are available");
                }
                return dtEmployee;
            }
            catch (Employee_Exception se)
            {
                throw se;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Employee SearchEmployee_Bal(int Id)
        {
            try
            {
                Emploee_DAL ed = new Emploee_DAL();
                return ed.SearchEmployee(Id);
            }
            catch (Employee_Exception)
            {
                throw;
            }
        }
    }
}
