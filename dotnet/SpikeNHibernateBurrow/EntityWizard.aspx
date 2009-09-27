<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntityWizard.aspx.cs" Inherits="SpikeNHibernateBurrow.EntityWizard" %>

<%@ Register Src="ChildEntityEditControl.ascx" TagName="ChildEntityEditControl" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form" runat="server">
    <asp:MultiView ID="MultiView" runat="server" ActiveViewIndex="0">
        <asp:View runat="server" ID="Step1View">
            <asp:Label ID="lblStep1" runat="server" Text="Step 1"></asp:Label><br />
            <asp:TextBox ID="txtValue1" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnToStep2" runat="server" Text="Next" OnClick="btnToStep2_Click"
                Style="height: 26px" />
        </asp:View>
        <asp:View runat="server" ID="Step2View">
            <asp:Label ID="lblStep2" runat="server" Text="Step 2"></asp:Label><br />
            <asp:TextBox ID="txtValue2" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnToStep3" runat="server" Text="Next" OnClick="btnToStep3_Click" />
        </asp:View>
        <asp:View runat="server" ID="Step3View">
            <asp:Label ID="lblStep3" runat="server" Text="Step 3"></asp:Label><br />
            <asp:TextBox ID="txtValue3" runat="server"></asp:TextBox><br />
            <uc1:ChildEntityEditControl ID="ChildEntityEditControl1" runat="server" Visible="false" />
            <asp:Button ID="btnAddChildEntity" runat="server" Text="Add" 
                onclick="btnAddChildEntity_Click" /><br />
            <asp:Button ID="btnFinish" runat="server" Text="Finish" OnClick="btnFinish_Click" />
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
        </asp:View>
    </asp:MultiView>
    </form>
</body>
</html>
