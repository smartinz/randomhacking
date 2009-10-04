<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DatePicker.aspx.cs" Inherits="SpikeJQueryCss.DatePicker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function() {
            $('#<%= datePickerTextBox.ClientID %>').datepicker({
                inline: true
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="datePickerTextBox" runat="server"></asp:TextBox>
</asp:Content>
