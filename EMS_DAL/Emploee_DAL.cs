using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_Entity;
using EMS_Exception;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EMS_DAL
{
    /// <summary>
    /// Author: Manisha Chennu
    /// Doc: 02 feb 2019
    /// Description to implement CRUD operation
    /// </summary>
    public class Emploee_DAL
    {
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;
        static Emploee_DAL()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }
        public Emploee_DAL()
        {
            con = new SqlConnection(conStr);
        }
        public int AddEmployee(Employee eobj)
        {
            int Id = 0;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "ManishaChennu_168247.uspAddEmployee";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@EId", SqlDbType.Int);
                cmd.Parameters["@EId"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@EName", eobj.Employee_Name);
                cmd.Parameters.AddWithValue("@EDOJ", eobj.DOJ);
                cmd.Parameters.AddWithValue("@ELocation", eobj.Location);
                cmd.Parameters.AddWithValue("@EPhone_Number", eobj.Phone_Number);
                cmd.Parameters.AddWithValue("@EDesignation", eobj.Designation);
                con.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                Id = int.Parse(cmd.Parameters["@EId"].Value.ToString());
            }
            catch (Employee_Exception) { throw; }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Id;
        }

        public Employee SearchEmployee(int Id)
        {
            Employee emp = null;

            try
            {
                //  con = new SqlConnection();
                //con.ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                cmd = new SqlCommand();
                cmd.CommandText = "ManishaChennu_168247.usp_SearchEmployee";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EId", Id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    emp = new Employee
                    {
                        Employee_Id = int.Parse(dr["Employee_Id"].ToString()),
                        Employee_Name = dr["Employee_Name"].ToString(),
                        DOJ = DateTime.Parse(dr["DOj"].ToString()),
                        Location = dr["Location"].ToString(),
                        Phone_Number = long.Parse(dr["Phone_Number"].ToString()),
                        Designation = dr["Designation"].ToString()
                    };
                    dr.Close();
                }
            }
            catch (Employee_Exception)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return emp;
        }

        public DataTable DisplayEmployee()
        {
            DataTable dt = null;

            try
            {
                cmd = new SqlCommand("ManishaChennu_168247.usp_DisplayEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }

    }
}
