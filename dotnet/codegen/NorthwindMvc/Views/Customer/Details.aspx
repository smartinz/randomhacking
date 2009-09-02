<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NorthwindWeb.Business.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            CustomerID:
            <%= Html.Encode(Model.CustomerID) %>
        </p>
        <p>
            CompanyName:
            <%= Html.Encode(Model.CompanyName) %>
        </p>
        <p>
            ContactName:
            <%= Html.Encode(Model.ContactName) %>
        </p>
        <p>
            ContactTitle:
            <%= Html.Encode(Model.ContactTitle) %>
        </p>
        <p>
            Address:
            <%= Html.Encode(Model.Address) %>
        </p>
        <p>
            City:
            <%= Html.Encode(Model.City) %>
        </p>
        <p>
            Region:
            <%= Html.Encode(Model.Region) %>
        </p>
        <p>
            PostalCode:
            <%= Html.Encode(Model.PostalCode) %>
        </p>
        <p>
            Country:
            <%= Html.Encode(Model.Country) %>
        </p>
        <p>
            Phone:
            <%= Html.Encode(Model.Phone) %>
        </p>
        <p>
            Fax:
            <%= Html.Encode(Model.Fax) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { id=Model.CustomerID }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

