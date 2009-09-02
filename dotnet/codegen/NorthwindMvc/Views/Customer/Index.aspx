<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<NorthwindWeb.Business.Customer>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Index</h2>
	<% Html.RenderPartial("Search"); %>
	<p>
		<%= Html.ActionLink("Create New", "Create") %>
	</p>
</asp:Content>
