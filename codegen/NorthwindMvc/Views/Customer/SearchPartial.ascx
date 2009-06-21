<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<NorthwindWeb.Business.Customer>>" %>
<div id="customer-search">
	<%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
	<% using (Ajax.BeginForm(new AjaxOptions { UpdateTargetId = "customer-search" }))
	 { %>
	<% //Html.BeginForm(); %>
	<fieldset>
		<legend>Filters</legend>
		<p>
			<label for="companyName">
				companyName:</label>
			<%= Html.TextBox("companyName", ViewData["companyName"])%>
			<%= Html.ValidationMessage("companyName", "*")%>
		</p>
		<p>
			<label for="contactName">
				contactName:</label>
			<%= Html.TextBox("contactName", ViewData["contactName"])%>
			<%= Html.ValidationMessage("contactName", "*")%>
		</p>
		<p>
			<label for="contactTitle">
				contactTitle:</label>
			<%= Html.TextBox("contactTitle", ViewData["contactTitle"])%>
			<%= Html.ValidationMessage("contactTitle", "*")%>
		</p>
		<p>
			<input type="submit" value="Search" />
		</p>
	</fieldset>
	<% //Html.EndForm();%>
	<% }%>
	<table>
		<tr>
			<th>
			</th>
			<th>
				CustomerID
			</th>
			<th>
				CompanyName
			</th>
			<th>
				ContactName
			</th>
			<th>
				ContactTitle
			</th>
			<th>
				Address
			</th>
			<th>
				City
			</th>
			<th>
				Region
			</th>
			<th>
				PostalCode
			</th>
			<th>
				Country
			</th>
			<th>
				Phone
			</th>
			<th>
				Fax
			</th>
		</tr>
		<% foreach (var item in Model)
	  { %>
		<tr>
			<td>
				<%= Html.ActionLink("Edit", "Edit", new { id = item.CustomerID }) %>
				|
				<%= Html.ActionLink("Details", "Details", new { id = item.CustomerID })%>
			</td>
			<td>
				<%= Html.Encode(item.CustomerID) %>
			</td>
			<td>
				<%= Html.Encode(item.CompanyName) %>
			</td>
			<td>
				<%= Html.Encode(item.ContactName) %>
			</td>
			<td>
				<%= Html.Encode(item.ContactTitle) %>
			</td>
			<td>
				<%= Html.Encode(item.Address) %>
			</td>
			<td>
				<%= Html.Encode(item.City) %>
			</td>
			<td>
				<%= Html.Encode(item.Region) %>
			</td>
			<td>
				<%= Html.Encode(item.PostalCode) %>
			</td>
			<td>
				<%= Html.Encode(item.Country) %>
			</td>
			<td>
				<%= Html.Encode(item.Phone) %>
			</td>
			<td>
				<%= Html.Encode(item.Fax) %>
			</td>
		</tr>
		<% } %>
	</table>
</div>
