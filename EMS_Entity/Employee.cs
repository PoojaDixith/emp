using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_Entity
{
    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public DateTime DOJ { get; set; }
        public string Location { get; set; }
        public long Phone_Number { get; set; }
        public string Designation { get; set; }
    }
}
