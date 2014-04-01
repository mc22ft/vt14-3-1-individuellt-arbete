<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="AnnonsList.aspx.cs" Inherits="Planket.Pages.AnnonsPages.AnnonsList" %>

<%-- Meny för denna sida som genereras ut --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h3>Annonser</h3>
</asp:Content>

<%-- Content genereras ut på master page när den är aktiv  --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <%-- Presenterar meddelande --%>
    <asp:ValidationSummary runat="server" />
    
    <div>        
        <asp:HyperLink runat="server" Text="Lägg till annons" NavigateUrl='<%$ RouteUrl:routename = AnnonsCreate %>'/> 
    </div>                                                   

    <%--Hämtar ut alla annonser. --%>
    <asp:ListView ID="AddListView" runat="server"
        itemtype="Planket.Model.Annons"
        SelectMethod="AddListView_GetData"
        DataKeyName="AnnonsID">
         
        <LayoutTemplate>          
            <table class="table table-bordered table-striped table-hover">
                    <%-- Meny --%>
                    <tr>
                        <th>Rubrik</th>
                        <th>Pris</th>                                                                                            
                    </tr>
                
                    <%-- Platshållare för nya rader --%>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
             </table>            
        </LayoutTemplate>
        
        <ItemTemplate>
                    <%-- Mall för nya rader. --%>            
            <tr>
                <td>                         
                        <%-- Länk till enskild annons sida --%>
                       <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("AnnonsDetails", new { id = Item.AnnonsID })  %>'> <%#: Item.Rubrik %> </asp:HyperLink>

                </td>
                <td> 
                    <p><%#: Item.Pris %> Kr</p>
                </td>                
            </tr>
       </ItemTemplate>

        <EmptyDataTemplate>
                        <%-- Detta visas då kunduppgifter saknas i databasen. --%>
                        <table>
                            <tr>
                                <td>  Det finns inga annonser.  </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
    </asp:ListView>

</asp:Content>
