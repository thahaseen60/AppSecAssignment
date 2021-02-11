<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="AppSecAssignment.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Registration</title>
     
    <script type="text/javascript">
        function validate() {
            var str = document.getElementById('<%=tb_password.ClientID %>').value;
            // password check for less than 8 characters
            if (str.length < 8) {
                document.getElementById("lbl_pwdchecker").innerHTML = "Password Length Must be at Least 8 Characters";
                document.getElementById("lbl_pwdchecker").style.color = "Red";
                return ("too_short");
            }

            // password check for at least 1 number
            else if (str.search(/[0-9]/) == -1) {
                document.getElementById("lbl_pwdchecker").innerHTML = "Password require at least 1 number";
                document.getElementById("lbl_pwdchecker").style.color = "Red";
                return ("No_number");
            }

            // password check for lower case
            else if (str.search(/[a-z]/) < 0) {
                document.getElementById("lbl_pwdchecker").innerHTML = "Password require at least 1 lower case letter";
                document.getElementById("lbl_pwdchecker").style.color = "Red";
                return ("No_lowercase");
            }

            // password check for upper case
            else if (str.search(/[A-Z]/) < 0) {
                document.getElementById("lbl_pwdchecker").innerHTML = "Password require at least 1 upper case letter";
                document.getElementById("lbl_pwdchecker").style.color = "Red";
                return ("No_uppercase");
            }

            // password check for special characters
            else if (str.search(/[!@#$%^&*./]/) == -1) {
                document.getElementById("lbl_pwdchecker").innerHTML = "Password require at least 1 special character. You can choose any special character from here: ( ! @ # $ % ^ & * . / ) ";
                document.getElementById("lbl_pwdchecker").style.color = "Red";
                return ("No_specialcharacter");
            }

            document.getElementById("lbl_pwdchecker").innerHTML = "Excellent!";
            document.getElementById("lbl_pwdchecker").style.color = "Blue";
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            Registration<br />
            <br />
            First Name
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Last Name
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Credit Card Info
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            Email Address
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            Password&nbsp;&nbsp;
            <asp:TextBox ID="tb_password" runat="server" Width="206px" onkeyup="javascript:validate()" TextMode="Password"></asp:TextBox>
&nbsp;
            <asp:Label ID="lbl_pwdchecker" runat="server" Text="pwdchecker"></asp:Label>
            <br />
            <br />
            Date of Birth
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_checkPassword" runat="server" Text="Check Password" Width="365px" />
            <br />
            <br />
            <asp:Button ID="btn_Submit" runat="server" Text="Submit" Width="364px" />
        </div>
    </form>
</body>
</html>
