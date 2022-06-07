using Emp.Services;
using Emp.Services.Models;
using Emp.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementBootstrap
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonCreate_OnClick(object sender, EventArgs e)
        {
            CreateData();
        }
        private void CreateData()
        {
            var employeeService = new EmployeeServices();

            try
            {



                var emp = new Employee()
                {
                    

                    Emp_no = int.Parse(TextBoxEmployeeNumber.Text),
                    Emp_Name = TextBoxEmployeeName.Text,
                    Emp_Gender = RadioButtonGender.SelectedValue,
                    Emp_Address = TextBoxAddress.Text,
                    Emp_Department = TextBoxDepartment.Text,
                    Emp_Position = TextBoxPosition.Text,
                    DateOfJoining = DateTime.Parse(TextBoxDoj.Text),
                    Emp_Email = TextBoxEmail.Text,
                };
                employeeService.Add(emp);

                LabelStatus.ShowStatusMessage("Users record successfully added!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                LabelStatus.ShowStatusMessage("Failed to add Users record! > " + exception.Message);
            }
        }
    }
}