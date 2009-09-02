<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NorthwindWeb.Business.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Edit</h2>
	<%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
	<% using (Html.BeginForm())
	 {%>
	<fieldset>
		<legend>Fields</legend>
		<p>
			<label for="OrderID">
				OrderID:</label>
			<%= Html.TextBox("OrderID", Model.OrderID) %>
			<%= Html.ValidationMessage("OrderID", "*") %>
		</p>
		<p>
			<label for="Employee">
				Employee:</label>
			<% Html.RenderPartial("ChooseEmployeePartial", null, new ViewDataDictionary { { "object", Model.Employee }, { "property", "Employee" } }); %>
			<%= Html.ValidationMessage("Employee", "*")%>
		</p>
		<p>
			<label for="OrderDate">
				OrderDate:</label>
			<%= Html.TextBox("OrderDate", String.Format("{0:g}", Model.OrderDate)) %>
			<%= Html.ValidationMessage("OrderDate", "*") %>
		</p>
		<p>
			<label for="RequiredDate">
				RequiredDate:</label>
			<%= Html.TextBox("RequiredDate", String.Format("{0:g}", Model.RequiredDate)) %>
			<%= Html.ValidationMessage("RequiredDate", "*") %>
		</p>
		<p>
			<label for="ShippedDate">
				ShippedDate:</label>
			<%= Html.TextBox("ShippedDate", String.Format("{0:g}", Model.ShippedDate)) %>
			<%= Html.ValidationMessage("ShippedDate", "*") %>
		</p>
		<p>
			<label for="Freight">
				Freight:</label>
			<%= Html.TextBox("Freight", String.Format("{0:F}", Model.Freight)) %>
			<%= Html.ValidationMessage("Freight", "*") %>
		</p>
		<p>
			<label for="ShipName">
				ShipName:</label>
			<%= Html.TextBox("ShipName", Model.ShipName) %>
			<%= Html.ValidationMessage("ShipName", "*") %>
		</p>
		<p>
			<label for="ShipAddress">
				ShipAddress:</label>
			<%= Html.TextBox("ShipAddress", Model.ShipAddress) %>
			<%= Html.ValidationMessage("ShipAddress", "*") %>
		</p>
		<p>
			<label for="ShipCity">
				ShipCity:</label>
			<%= Html.TextBox("ShipCity", Model.ShipCity) %>
			<%= Html.ValidationMessage("ShipCity", "*") %>
		</p>
		<p>
			<label for="ShipRegion">
				ShipRegion:</label>
			<%= Html.TextBox("ShipRegion", Model.ShipRegion) %>
			<%= Html.ValidationMessage("ShipRegion", "*") %>
		</p>
		<p>
			<label for="ShipPostalCode">
				ShipPostalCode:</label>
			<%= Html.TextBox("ShipPostalCode", Model.ShipPostalCode) %>
			<%= Html.ValidationMessage("ShipPostalCode", "*") %>
		</p>
		<p>
			<label for="ShipCountry">
				ShipCountry:</label>
			<%= Html.TextBox("ShipCountry", Model.ShipCountry) %>
			<%= Html.ValidationMessage("ShipCountry", "*") %>
		</p>
		<p>
			<input type="submit" value="Save" />
		</p>
	</fieldset>
	<% } %>
	<div>
		<%=Html.ActionLink("Back to List", "Index") %>
	</div>
</asp:Content>
