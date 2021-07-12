<%@ 
    Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="MainPage.aspx.cs" 
    Inherits="TodoList.GUI.MainPage" 
%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en" dir="ltr">
<head runat="server">
    <meta charset="utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../CSS/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/all.min.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/MainPage.css"/>
    

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.css" />

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../Script/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="../Script/shieldui-all.min.js"></script>
    
</head>
<body>
    <div class="bg-modal">
            <div class="modal-content">
                <div class="close">+</div>
                <h3>THÊM CÔNG VIỆC</h3>
                <form id="job_form" runat="server">
                    <div>
                        <span>Tên công việc</span> <br />
                        <asp:TextBox ID="job_title" CssClass="job_title" runat="server"/>
                    </div>
                    <div>
                        <span>Trạng thái công việc</span> <br />
                        <asp:DropDownList ID="job_status" CssClass="job_status" runat="server">
                            <asp:ListItem Text="[Default]" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Public" Value="1">Public</asp:ListItem>
                            <asp:ListItem Text="Private" Value="0">Private</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    
                    <div>
                        <span>Ngày bắt đầu: </span> <br />
                        <input class="textbox-n job_date" type="date" id="job_startDate" runat="server"/>
                    </div>
                    
                    <div>
                        <span>Ngày kết thúc</span> <br />
                        <input class="textbox-n job_date" type="date" id="job_finishDate" runat="server"/>
                    </div>
                    
                    <input type="button" id="submit" class="submit_btn" value="Tạo mới" runat="server" />
                    <input type="button" id="cancle" class="cancle_btn" value="Huỷ bỏ" runat="server" /></form>
                    <asp:Label Visible="false" ID="error_label" CssClass="sui-upload-file-error error_label" Text="Ngày bắt đầu hoặc ngày kết thúc không hợp lệ" runat="server"></asp:Label>
            </div>
    </div>
    <div class="container-sm">
        <div class="content_left">
            <asp:Label runat="server" ID="abc" Text="Xin chào, Huỳnh Tuấn Đạt" CssClass="content_left" ></asp:Label>
        </div>

        <div class="container-right">
            <asp:Label runat="server" ID="change_Pass" Text="Đổi Mật Khẩu" CssClass="change_Pass"></asp:Label>
            <span>|</span>
            <asp:Label runat="server" ID="log_Out" Text="Đăng Xuất" CssClass="log_Out"></asp:Label>
        </div>
    </div>

    <div class="content">
        <div>
            <div class="open_modal_button">
                <a id="open">+</a>
            </div>
        </div>
        <!--<input type="text" class="txtb" placeholder="Thêm Công Việc"/> -->
        <div class="notcomp"> 
            <h3>Chưa hoàn thành</h3>
        </div>
                
        <div class="comp">
            <h3>Đã hoàn thành</h3>
        </div>
     </div>

    <script type="text/javascript">
        
        var temp;
        
        $('.cancle_btn').on('click', function (e) {
            $(".bg-modal").css('display', 'none');
        });

        $(".submit_btn").on("click", function (e) {
            var task = $("<div class='task'></div>").text($(".job_title").val());
            var temp;
            var del = $("<i class='fas fa-trash-alt'></i>").click(function () {
                var p = $(this).parent();
                p.fadeOut(function () {
                    $(this).empty();
                });
            });
            var add = $("<i class='fas fa-plus-circle'></i>").click(function(){
                    
            });
            var edit = $("<i class='fas fa-edit'></i>").click(function () {

            });

            var check = $("<i class='fas fa-check'></i>").click(function (e) {
                var q = $(this).parent();
                q.fadeOut(function () {
                    $(".comp").append(q);
                    $('.comp div i.fas.fa-check').css('display', 'none');
                    $('.comp div i.fas.fa-plus-circle').remove();
                    $('.comp div i.fas.fa-edit').remove();
                    q.fadeIn();
                });
                $(this).remove();
            });

            task.append(del, check, edit, add);
            $(".notcomp").append(task);
            $(".job_title").val(""); //Để xoá (làm mới) dữ liệu trong input
            $(".bg-modal").css('display', 'none'); //Sau khi thêm công việc mới sẽ hide cái form đó
        });

        window.onclick = function (e) {
            if (e.target.className == 'bg-modal') {
                e.target.style.display = 'none'; //
            }
        }
        
    </script>
    <script type="text/javascript" src="../Script/main_page.js"></script>  
</body>
</html>
