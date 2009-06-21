<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<NorthwindWeb.Business.Employee>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Search</h2>
	<% Html.RenderPartial("SearchPartial"); %>
	<p>
		<%= Html.ActionLink("Create New", "Create") %>
	</p>
</asp:Content>
