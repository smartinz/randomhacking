<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NorthwindWeb.Business.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            OrderID:
            <%= Html.Encode(Model.OrderID) %>
        </p>
        <p>
            Customer:
            <%= Html.ActionLink(Model.Customer.ToString(), "Details", "Customer") %>
        </p>
        <p>
            OrderDate:
            <%= Html.Encode(String.Format("{0:g}", Model.OrderDate)) %>
        </p>
        <p>
            RequiredDate:
            <%= Html.Encode(String.Format("{0:g}", Model.RequiredDate)) %>
        </p>
        <p>
            ShippedDate:
            <%= Html.Encode(String.Format("{0:g}", Model.ShippedDate)) %>
        </p>
        <p>
            Freight:
            <%= Html.Encode(String.Format("{0:F}", Model.Freight)) %>
        </p>
        <p>
            ShipName:
            <%= Html.Encode(Model.ShipName) %>
        </p>
        <p>
            ShipAddress:
            <%= Html.Encode(Model.ShipAddress) %>
        </p>
        <p>
            ShipCity:
            <%= Html.Encode(Model.ShipCity) %>
        </p>
        <p>
            ShipRegion:
            <%= Html.Encode(Model.ShipRegion) %>
        </p>
        <p>
            ShipPostalCode:
            <%= Html.Encode(Model.ShipPostalCode) %>
        </p>
        <p>
            ShipCountry:
            <%= Html.Encode(Model.ShipCountry) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { id=Model.OrderID }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

