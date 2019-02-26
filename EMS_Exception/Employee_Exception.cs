using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_Exception
{
    public class Employee_Exception : ApplicationException
    {
        public Employee_Exception() : base()
        { }
        public Employee_Exception(string exMessage) : base(exMessage)
        { }
        public Employee_Exception(string exMessage, Exception innerException) : base(exMessage, innerException)
        { }
    }
}
