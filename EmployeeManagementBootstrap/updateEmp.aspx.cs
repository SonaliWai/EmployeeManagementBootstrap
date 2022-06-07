using Emp.Services;
using Emp.Services.Models;
using Emp.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementBootstrap
{
    public partial class updateEmp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ShowDataToUpdate();
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            var empService = new EmployeeServices();

            try
            {
                var idText = Request.QueryString["id"];

                var emp = new Employee();
                emp.Id = int.Parse(idText);
                emp.Emp_no = int.Parse(TextBoxEmployeeNumber.Text);
                emp.Emp_Name = TextBoxEmployeeName.Text;
                emp.Emp_Gender = RadioButtonGender.SelectedValue;
                emp.Emp_Address = TextBoxAddress.Text;
                emp.Emp_Department = TextBoxDepartment.Text;
                emp.Emp_Position = TextBoxPosition.Text;
                emp.DateOfJoining = (DateTime)(string.IsNullOrEmpty(TextBoxDoj.Text) ? (DateTime?)null : DateTime.Parse(TextBoxDoj.Text));
                emp.Emp_Email = TextBoxEmail.Text;



                empService.Update(emp);

                LabelStatus.ShowStatusMessage("User record successfully updated!");
            }
            catch (Exception exception)
            {
                Debug.Print(exception.StackTrace);
                LabelStatus.ShowStatusMessage("Failed to update User record!");
            }
        }

        private void ShowDataToUpdate()
        {
            var idText = Request.QueryString["id"];
            try
            {
                var id = int.Parse(idText);

                var empService = new EmployeeServices();

                var emp = empService.GetById(id);

                if (emp == null)
                {
                    LabelStatus.ShowStatusMessage("Specified Id not found in database!");
                    return;
                }

                TextBoxEmployeeNumber.Text = emp.Emp_no.ToString();
                TextBoxEmployeeName.Text = emp.Emp_Name;
                RadioButtonGender.SelectedValue = emp.Emp_Gender;
                TextBoxAddress.Text = emp.Emp_Address;
                TextBoxDepartment.Text = emp.Emp_Department;
                TextBoxPosition.Text = emp.Emp_Position;
                TextBoxDoj.Text = emp.DateOfJoining.ToString();
                TextBoxEmail.Text = emp.Emp_Email;



            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                LabelStatus.ShowStatusMessage("Id parameter not found!: " + exception.Message);
            }
        }
    }
}