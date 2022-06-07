using Emp.Services.Models;
using Emp.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Services
{
    public class EmployeeServices
    {
        public List<Employee> GetAll()
        {
            var emp = new List<Employee>();

            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "employee_GetAll";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee
                            {
                                Emp_no = (int)reader["Emp_no"],
                                //empNumber = reader["empNumber"].GetDataFromDb<int>(),
                                Emp_Name = reader["Emp_Name"].GetDataFromDb<string>(),
                                Emp_Gender = reader["Emp_Gender"].GetDataFromDb<string>(),
                                Emp_Address = reader["Emp_Address"].GetDataFromDb<string>(),
                                Emp_Department = reader["Emp_Department"].GetDataFromDb<string>(),
                                Emp_Position = reader["Emp_Position"].GetDataFromDb<string>(),
                                DateOfJoining = reader["DateOfJoining"].GetDataFromDb<DateTime>(),
                                Emp_Email = reader["Emp_Email"].GetDataFromDb<string>()


                            };
                            emp.Add(employee);
                        }
                    }
                }
            }
            return emp;
        }

        public void Delete(int Emp_no)
        {
            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "employee_Delete";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Emp_no", Emp_no);

                    connection.Open();

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");
                }
            }
        }

        public Employee GetById(int Emp_no)
        {
            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "Employee_GetById";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Emp_no", Emp_no);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var employees = new Employee();
                            employees.Emp_no = (int)reader["Emp_no"];
                            
                            employees.Emp_Name = reader["Emp_Name"].GetDataFromDb<string>();
                            employees.Emp_Gender = reader["Emp_Gender"].GetDataFromDb<string>();
                            employees.Emp_Address = reader["Emp_Address"].GetDataFromDb<string>();
                            employees.Emp_Department = reader["Emp_Department"].GetDataFromDb<string>();
                            employees.Emp_Position = reader["Emp_Position"].GetDataFromDb<string>();
                            employees.DateOfJoining = reader["DateOfJoining"].GetDataFromDb<DateTime>();
                            employees.Emp_Email = reader["DateOfJoining"].GetDataFromDb<string>();
                            return employees;
                        }
                    }
                    return null;
                }
            }
        }

        public void Update(Employee employees)
        {
            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "employee_Update";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", employees.Id);

                    command.Parameters.AddWithValue("@Emp_no", employees.Emp_no);
                   
                    command.Parameters.AddWithValue("@Emp_Name", employees.Emp_Name.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@Emp_Gender", employees.Emp_Gender.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@Emp_Address", employees.Emp_Address.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@Emp_Department", employees.Emp_Department.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@Emp_Position", employees.Emp_Position.GetDataFromUi<string>());
                    command.Parameters.AddWithValue("@DateOfJoining", employees.DateOfJoining.GetDataFromUi<DateTime>());
                    command.Parameters.AddWithValue("@Emp_Email", employees.Emp_Email.GetDataFromUi<string>());

                    connection.Open();

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");
                }
            }
        }

        public void Add(Employee employees)
        {

            using (var connection = new SqlConnection(WebConfigHelper.ConnectionString))
            {
                const string cmdText = "employee_Add";

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", employees.Id);

                    command.Parameters.AddWithValue("@Emp_no", employees.Emp_no);
                    command.Parameters.AddWithValue("@Emp_Name", employees.Emp_Name);
                    command.Parameters.AddWithValue("@Emp_Gender", employees.Emp_Gender);
                    command.Parameters.AddWithValue("@Emp_Address", employees.Emp_Address);
                    command.Parameters.AddWithValue("@Emp_Department", employees.Emp_Department);
                    command.Parameters.AddWithValue("@Emp_Position", employees.Emp_Position);
                    command.Parameters.AddWithValue("@DateOfJoining", employees.DateOfJoining);
                    command.Parameters.AddWithValue("@Emp_Email", employees.Emp_Email);



                    connection.Open();

                    var rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                        throw new Exception("Add returned 0 rows affected. Expecting 1 rows affected");
                }
            }
        }

    }
}
