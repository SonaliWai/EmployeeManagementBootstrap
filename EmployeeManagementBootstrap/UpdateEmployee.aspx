<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateEmployee.aspx.cs" Inherits="EmployeeManagementBootstrap.UpdateEmployee" %>

<%@ Import Namespace="Emp.Services" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!--CDN-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>

    <link href="css/style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <div class="container-fluid">
                    <div class="row ">
                        <!-- navbar content start -->
                        <div class="col-md-12 p-0">
                            <nav class="navbar navbar-expand-lg navbar-light " style="background-color: #808080;">
                                <div class="container-fluid">
                                    <span class="text-danger fw-bold" style="font-size:20px;">Wai Technologies</span>
                                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                                        <span class="navbar-toggler-icon"></span>
                                    </button>
                                    <div class="collapse navbar-collapse " id="navbarSupportedContent">
                                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                                            <li class="nav-item active">
                                                <a class="nav-link text-white font-weight-light">Home</a>
                                            </li>
                                            <li class="nav-item ">
                                                <a href="AddEmployee.aspx" class="nav-link text-white font-weight-light">Add Employee</a>
                                            </li>
                                            <li class="nav-item ">
                                                <a href="DefaultEmployee.aspx" class="nav-link text-white font-weight-light">All Employee</a>
                                            </li>
                                            <li class="nav-item ">
                                                <a href="DeleteEmployee.aspx" class="nav-link text-white font-weight-light">Delete Employee</a>
                                            </li>
                                            <li class="nav-item ">
                                                <a  href="UpdateEmployee.aspx" class="nav-link text-white font-weight-light">Update Employee</a>
                                            </li>

                                        </ul>
                                        
                                    </div>
                                </div>
                            </nav>
                        </div>

                        <div class="col-md-12">

                            <!--main section-->



                            <h4 class="p-3 text-info  bg-dark mt-4 ">Update Employee</h4>
                            <table class="table table-bordered table-striped scroll mt-3">
                                <thead class="bg-info text-center">
                                    <tr>
                                        <th>Emp_no</th>
                                        <%--<th>Emp number</th>--%>
                                        <th>Emp_Name</th>

                                        <th>Emp_Gender</th>

                                        <th>Emp_Address</th>
                                        <th>Emp_Position</th>
                                        <th>Emp_Department</th>
                                        <th>DateOfJoining</th>
                                        <th>Emp_Email</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%
                                        var employeeService = new EmployeeServices();
                                        var empployees = employeeService.GetAll();

                                        foreach (var emp in empployees)
                                        {
                                    %>
                                    <tr>

                                        <td><%= emp.Emp_no %></td>
                                        <%--<td><%= emp.empNumber %></td>--%>
                                        <td><%= emp.Emp_Name %></td>
                                        <td><%= emp.Emp_Gender %></td>
                                        <td><%= emp.Emp_Address %></td>
                                        <td><%= emp.Emp_Department %></td>
                                        <td><%= emp.Emp_Position %></td>
                                        <td><%= emp.DateOfJoining %></td>
                                        <td><%= emp.Emp_Email %></td>
                                        <%--  <td><a href="empEdit.aspx?id=<%= emp.Id %>">Edit</a></td>
                                            <td><a href="empDelete.aspx?id=<%= emp.Id %>">Delete</a></td>--%>
                                    </tr>
                                    <%
                                        }
                                    %>
                                </tbody>
                            </table>
                        </div>
                        <!--main section-->

                        <div class="col-md-12">
                            <hr />
                            <p class=" mt-3">© 2022 WAi Technologies. All rights Reserved <span> <i class="pt-3 social-icon pb-3  text-dark   fab fa-facebook"></i>
                                            <i class="pt-3 social-icon pb-3  text-dark   fab fa-twitter"></i>
                                            <i class="pt-3 social-icon pb-3  text-dark  fab fa-instagram"></i>
                                            <i class="pt-3 social-icon pb-3  text-dark   fab fa-linkedin"></i></span></p>
                            
                            <hr />
                        </div>
                    </div>
                    </div>
                </div>
                </div>
            
    </form>
</body>
</html>

