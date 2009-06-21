<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<NorthwindWeb.Business.Employee>>" %>
<div id="employee-search">
	<%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
	<% using (Ajax.BeginForm(new AjaxOptions { UpdateTargetId = "employee-search" }))
	 { %>
	<fieldset>
		<legend>Filters</legend>
		<p>
			<label for="lastName">
				lastName:</label>
			<%= Html.TextBox("lastName", ViewData["lastName"])%>
			<%= Html.ValidationMessage("lastName", "*")%>
		</p>
		<p>
			<label for="firstName">
				firstName:</label>
			<%= Html.TextBox("firstName", ViewData["firstName"])%>
			<%= Html.ValidationMessage("firstName", "*")%>
		</p>
		<p>
			<label for="title">
				title:</label>
			<%= Html.TextBox("title", ViewData["title"])%>
			<%= Html.ValidationMessage("title", "*")%>
		</p>
		<p>
			<input type="submit" value="Search" />
		</p>
	</fieldset>
	<% }%>
	<table>
		<tr>
			<th>
			</th>
			<th>
				EmployeeID
			</th>
			<th>
				LastName
			</th>
			<th>
				FirstName
			</th>
			<th>
				Title
			</th>
			<th>
				TitleOfCourtesy
			</th>
			<th>
				BirthDate
			</th>
			<th>
				HireDate
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
				HomePhone
			</th>
			<th>
				Extension
			</th>
			<th>
				Notes
			</th>
			<th>
				PhotoPath
			</th>
		</tr>
		<% foreach (var item in Model)
	  { %>
		<tr>
			<td>
				<div class="data-id"><%= Html.Encode(item.EmployeeID) %></div>
				<div class="data-description"><%= Html.Encode(item) %></div>
				<a href="<%= Url.Action("Details", new { id = item.EmployeeID }) %>" class="item-selector">Select</a>
			</td>
			<td>
				<%= Html.Encode(item.EmployeeID) %>
			</td>
			<td>
				<%= Html.Encode(item.LastName) %>
			</td>
			<td>
				<%= Html.Encode(item.FirstName) %>
			</td>
			<td>
				<%= Html.Encode(item.Title) %>
			</td>
			<td>
				<%= Html.Encode(item.TitleOfCourtesy) %>
			</td>
			<td>
				<%= Html.Encode(String.Format("{0:g}", item.BirthDate)) %>
			</td>
			<td>
				<%= Html.Encode(String.Format("{0:g}", item.HireDate)) %>
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
				<%= Html.Encode(item.HomePhone) %>
			</td>
			<td>
				<%= Html.Encode(item.Extension) %>
			</td>
			<td>
				<%= Html.Encode(item.Notes) %>
			</td>
			<td>
				<%= Html.Encode(item.PhotoPath) %>
			</td>
		</tr>
		<% } %>
	</table>
</div>
