<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard_page.aspx.cs" Inherits="TodoList.GUI.Dashboard_Page.dashboard_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
      <meta name="description" content="" />
      <meta name="author" content="" />

      <title>Simple Sidebar - Start Bootstrap Template</title>

      <!-- Bootstrap core CSS -->
      <link href="../CSS/bootstrap.min.css" rel="stylesheet" />

      <!-- Custom styles for this template -->
      <link href="../CSS/simple-sidebar.css?Version=1" rel="stylesheet" />
      <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" />
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.css" />
      <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
      <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/jquery-ui.min.js"></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
      
    </head>

    <body>
          
          <!-- -->

          <div class="modal fade" id="modal_insert_employee" tabindex="-1" role="dialog">
                 <div class="modal-dialog" role="document">
                    <div class="modal-content" style="width: 550px">
                      <div class="modal-header">
                        <h4 class="modal-title">Thông tin</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                      <div class="modal-body" id="insert_employee_container" style="overflow:scroll">
                        <form id="insert_employee_form" method="post">
                            <fieldset>
                                <input name='employee_name' id='employee_name' type='text' placeholder='Tên nhân viên' tabindex='1'/>
                            </fieldset> 
                            <fieldset> 
                                <input name='employee_email' placeholder='Email:'  type="email"  id='employee_email' tabindex='2'/>
                            </fieldset>
                            <fieldset>
                                <input name='employee_password' placeholder='Mật khẩu:' type="password"  id='employee_password'   tabindex='3'/> 
                            </fieldset>
                            <fieldset>
                                <select tabindex='4' id="employee_role">
                                    <option value='1'>Employee</option>
                                    <option value='2'>Manager</option>
                                </select>
                            </fieldset>
                        </form>
                      </div>
                      <div class="modal-footer">
                          <button type="button" class="btn btn-danger" data-dismiss="modal" id="insert_employee">Thêm</button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                      </div>
                    </div>
                </div>
              </div>

              <div class="modal fade" id="modal_info" tabindex="-1" role="dialog">
                 <div class="modal-dialog" role="document">
                    <div class="modal-content" style="width: 550px">
                      <div class="modal-header">
                        <h4 class="modal-title">Thông tin</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                      <div class="modal-body" id="info_container" style="overflow:scroll">
                        
                      </div>
                      <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                      </div>
                    </div>
                </div>
              </div>
              
              
              <div id="myModal" class="modal fade" role="dialog">
                  <div class="modal-dialog">
                    <div style="width: 550px" class="modal-content">
                        <div class="modal-header">
                            <h4>Thêm công việc</h4>
                            <button type='button' class='close' data-dismiss='modal'>&times;</button>
                        </div>  
                        <div class="modal-body" id="modal_body">
                            <div class="container">
                                <form id='add_job_form' method='post'>
                                    <fieldset>
                                        <input name='job_title' id='job_title' type='text' placeholder='Nhập tên công việc' tabindex='1'/>
                                    </fieldset> 
                                    <fieldset> 
                                        <input name='startDate' placeholder='Ngày bắt đầu: '  type="datetime-local"  id='startDate' tabindex='2'/>
                                    </fieldset>
                                    <fieldset>
                                        <input name='endDate' placeholder='Ngày kết thúc: ' type='datetime-local'  id='endDate'   tabindex='3'/> 
                                    </fieldset>
                                    <fieldset>
                                        <select id='job_range' tabindex='4'>
                                            <option value='Public'>Public</option>
                                            <option value='Private'>Private</option>
                                        </select>
                                    </fieldset>
                                    <fieldset>
                                        <div id="load_table" runat="server" onload="table_employee_Load" class='table_employee'>" 
                                            
                                        </div>
                                    </fieldset>
                                </form>                        
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type='button' class='btn btn-success' data-dismiss='modal' id='create_btn'>Tạo</button>
                            <button type='button' class='btn btn-danger cancle' data-dismiss='modal'>Huỷ</button>
                        </div>
                    </div>
                  </div>
              </div>
              
              <div class="modal fade bs-example-modal-lg in" id="modal_edit" tabindex="-1" role="dialog" aria-labelledby="modal_editLabel">
                 <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content" style="width: 850px; height:550px">
                      <div class="modal-header">
                        <h4 class="modal-title" id="myModalLabel">Chỉnh sửa công việc</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                      <div class="modal-body" style="overflow:scroll">
                        <div class="container" >
                            <div class="row" >
                                <div class="col">
                                    <form id="edit_job_form">
                                        <fieldset>
                                            <input type="text" id="edit_job_id" readonly="true"/>
                                        </fieldset>
                                        <fieldset>
                                            <input name='edit_job_title' id='edit_job_title' type='text' placeholder='Nhập tên công việc' tabindex='1'/>
                                        </fieldset> 
                                        <fieldset> 
                                            <input name='edit_startDate' placeholder='Ngày bắt đầu: '  type="datetime-local"  id='edit_startDate' tabindex='2'/>
                                        </fieldset>
                                        <fieldset>
                                            <input name='edit_endDate' placeholder='Ngày kết thúc: ' type='datetime-local'  id='edit_endDate' tabindex='3'/> 
                                        </fieldset>
                                        <fieldset>
                                            <select id='edit_job_Range' tabindex='4'>
                                                <option value='Public'>Public</option>
                                                <option value='Private'>Private</option>
                                            </select>
                                        </fieldset>
                                    </form>
                                </div>
                                <div class="col" style="overflow:scroll">
                                    <h4>Danh sách các nhân viên không có trong công việc này</h4>
                                    <div id="edit_table_employee">
                                            
                                    </div>
                                </div>
                            </div>
                        </div>
                      </div>
                      <div class="modal-footer">
                        <button id="edit_btn" type="button" class="btn btn-success" data-dismiss="modal">Lưu</button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                      </div>
                </div>
              </div>
</div>
          <!-- --> 
            
          <div class="d-flex" id="wrapper">

            <!-- Sidebar -->
            <div class="bg-light border-right" id="sidebar-wrapper">
              <div class="sidebar-heading" runat="server" id="name"></div>
              <div class="list-group list-group-flush">
                  <form runat="server" style="border: 0">
                      <asp:LinkButton runat="server" ID="job_observe" CssClass="list-group-item list-group-item-action bg-light job_observe">Xem công việc</asp:LinkButton>
                      <asp:LinkButton href="#" class="list-group-item list-group-item-action bg-light admin_management" runat="server" id="manage">Quản lý nhân viên (admin)</asp:LinkButton>
                      <asp:LinkButton runat="server" CssClass="list-group-item list-group-item-action bg-light" ID="log_out" OnClick="log_out_Click">
                        Đăng xuất
                    </asp:LinkButton>
                  </form>
              </div>
            </div>
            <!-- /#sidebar-wrapper -->

            <!-- Page Content -->
            <div id="page-content-wrapper">

              <nav class="navbar navbar-expand-lg navbar-light bg-light border-bottom">
                <button class="btn btn-primary" id="menu-toggle">Menu</button>

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                  <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                  <!--
                  <ul class="navbar-nav ml-auto mt-2 mt-lg-0">
                    <li class="nav-item active">
                      <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" href="#">Link</a>
                    </li>
                    <li class="nav-item dropdown">
                      <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Dropdown
                      </a>
                      <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="#">Action</a>
                        <a class="dropdown-item" href="#">Another action</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#">Something else here</a>
                      </div>
                    </li>
                  </ul>
                    -->
                </div>
              </nav>

              <div class="container-fluid">
                    <div class="content" runat="server" id="content" onload="Loader">
                        
                    </div>
              </div>
            </div>
            <!-- /#page-content-wrapper -->

          </div>
          <!-- /#wrapper -->

          <!-- Bootstrap core JavaScript -->
          <script src="../Script/bootstrap.bundle.min.js"></script>

          <!-- Menu Toggle Script -->
          <script>
              $(".table").on()
            
            $("#menu-toggle").click(function(e) {
              e.preventDefault();
              $("#wrapper").toggleClass("toggled");
            });
          </script> 
        <script src="../Script/main_page.js" type="text/javascript"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                Table();
            });
        </script>
    </body>
</html>
