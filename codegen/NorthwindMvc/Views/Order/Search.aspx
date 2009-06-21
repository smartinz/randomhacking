<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<NorthwindWeb.Business.Order>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Search</h2>
	<%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
	<% Html.BeginForm(); %>
	<fieldset>
		<legend>Filters</legend>
		<p>
			<label for="employee">
				employee:</label>
			<% Html.RenderPartial("ChooseEmployeePartial", ViewData["employee"], new ViewDataDictionary { { "property", "employee" } }); %>
			<%= Html.ValidationMessage("employee", "*")%>
		</p>
		<p>
			<label for="dateFrom">
				dateFrom:</label>
			<%= Html.TextBox("dateFrom", ViewData["dateFrom"])%>
			<%= Html.ValidationMessage("dateFrom", "*")%>
		</p>
		<p>
			<label for="dateTo">
				dateTo:</label>
			<%= Html.TextBox("dateTo", ViewData["dateTo"])%>
			<%= Html.ValidationMessage("dateTo", "*")%>
		</p>
		<p>
			<input type="submit" value="Search" />
		</p>
	</fieldset>
	<% Html.EndForm();%>
	<table>
		<tr>
			<th>
			</th>
			<th>
				OrderID
			</th>
			<th>
				OrderDate
			</th>
			<th>
				RequiredDate
			</th>
			<th>
				ShippedDate
			</th>
			<th>
				Freight
			</th>
			<th>
				ShipName
			</th>
			<th>
				ShipAddress
			</th>
			<th>
				ShipCity
			</th>
			<th>
				ShipRegion
			</th>
			<th>
				ShipPostalCode
			</th>
			<th>
				ShipCountry
			</th>
		</tr>
		<% foreach (var item in Model)
	  { %>
		<tr>
			<td>
				<%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %>
				|
				<%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%>
			</td>
			<td>
				<%= Html.Encode(item.OrderID) %>
			</td>
			<td>
				<%= Html.Encode(String.Format("{0:g}", item.OrderDate)) %>
			</td>
			<td>
				<%= Html.Encode(String.Format("{0:g}", item.RequiredDate)) %>
			</td>
			<td>
				<%= Html.Encode(String.Format("{0:g}", item.ShippedDate)) %>
			</td>
			<td>
				<%= Html.Encode(String.Format("{0:F}", item.Freight)) %>
			</td>
			<td>
				<%= Html.Encode(item.ShipName) %>
			</td>
			<td>
				<%= Html.Encode(item.ShipAddress) %>
			</td>
			<td>
				<%= Html.Encode(item.ShipCity) %>
			</td>
			<td>
				<%= Html.Encode(item.ShipRegion) %>
			</td>
			<td>
				<%= Html.Encode(item.ShipPostalCode) %>
			</td>
			<td>
				<%= Html.Encode(item.ShipCountry) %>
			</td>
		</tr>
		<% } %>
	</table>
	<p>
		<%= Html.ActionLink("Create New", "Create") %>
	</p>
</asp:Content>
