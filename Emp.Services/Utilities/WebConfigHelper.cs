using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Services.Utilities
{
    public static class WebConfigHelper
    {
        public static string ConnectionString =>
        ConfigurationManager.ConnectionStrings["EmployeeManagement"].ConnectionString;
    }
}
