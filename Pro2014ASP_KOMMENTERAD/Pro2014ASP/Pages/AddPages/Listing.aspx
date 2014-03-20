<%@ Page Title="Planket.se" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="Pro2014ASP.Pages.AddPages.Listing" %>

                                        <%-- Meny för denna sida som genereras ut --%>
<asp:Content ContentPlaceHolderID="MessageContentPlaceHolder" runat="server">        
         <div>
             <h2>Annonser</h2>
         </div>
         <div>
             <h4>Säljes</h4>
         </div>
    </asp:Content>       

                                        <%-- Content genereras ut på master page när den är aktiv  --%>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">   
                                        <%-- Presenterar meddelande från vaideringen kontrollerna och ModelState --%>
    <asp:ValidationSummary ID="ListiningValidationSummary" runat="server" />
    
                                        <%-- Knapp för att lägga till ny annons --%>
    <div>        
        <asp:HyperLink runat="server" Text="Lägg till annons" NavigateUrl="~/Pages/AddPages/CreateAdd.aspx"/>
    </div>                                                 <%-- '<%# GetRouteUrl("AddCreate", null) %>' Fick det inte att funka --%>   

                                        <%-- Formulär med olika egenskaper --%>
    <asp:ListView ID="AddListView" runat="server"
        itemtype="Pro2014ASP.Model.Add"
        SelectMethod="AddListView_GetData"
        DataKeyName="AddID">
                                       <%--Hämtar ut alla annonser --%>
        <LayoutTemplate>             
            <table class="table table-bordered table-striped table-hover">
                    <tr>
                        <th>Rubrik</th>
                        <th>Pris</th>
                        <th>Stad</th>    
                        <th>Inlagd</th>                                                                     
                    </tr>
                
                                        <%-- Platshållare för nya rader --%>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
             </table>            
        </LayoutTemplate>
                                        <%-- Mall för nya rader. --%>
        <ItemTemplate>
            <tr>
                                        <%-- HyperLänk till enskild annons --%>
                <td> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("AddDetails", new { id = Item.AddID })  %>'> <%#: Item.HeadLine %> </asp:HyperLink> </td>
                <td>  <%#: Item.Price %>     </td>
                <td>  <%#: Item.Town %>      </td>                        
                <td>  <%#: Item.Insert %>    </td>
            </tr>
       </ItemTemplate>
                                        <%-- Detta visas då kunduppgifter saknas i databasen. --%>
       <EmptyDataTemplate>                        
                <table>
                    <tr>
                        <td>  Kontaktuppgifter saknas!  </td>
                    </tr>
                </table>
       </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
