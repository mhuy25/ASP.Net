<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TodoList.GUI.Login"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en" dir="ltr">
<head runat="server">
    <meta charset="utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../CSS/Login.css" />
    <script src="../Script/jquery.min.js" charset="utf-8"></script>

</head>
<body>

    <!-- FORM ĐĂNG NHẬP -->
    <form class="login-form" runat="server" method="post">
        <h2>Đăng Nhập</h2>
        <div class="txtb">
            <asp:TextBox ID="username" runat="server" CssClass="Input"></asp:TextBox>
            <span data-placeholder="Mã Nhân Viên"></span>
        </div>

        <div class="txtb">
            <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="Input"></asp:TextBox>
            <span data-placeholder="Mật Khẩu"></span>
        </div>

        <asp:Button ID="login" runat="server" Text="Đăng Nhập" CssClass="log_btn" OnClick="Button_Login_Click"/>

        <div class="bottom-text">
            <asp:Label CssClass="Error_Label" ID="Error" runat="server" Text="Mã nhân viên hoặc mật khẩu không hợp lệ" Visible="false"></asp:Label>
        </div>
        
        <script type="text/javascript">
            $(".txtb Input").on("focus", function () {
                $(this).addClass("focus");
            });

            $(".txtb Input").on("blur", function () {
                if($(this).val() == "")
                    $(this).removeClass("focus");
            }); 
        </script>    
    </form>
</body>
</html>
