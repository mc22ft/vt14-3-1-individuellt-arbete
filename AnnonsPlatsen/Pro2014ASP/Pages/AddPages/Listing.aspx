<%@ Page Title="Planket.se" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="Pro2014ASP.Pages.AddPages.Listing" %>


<%--Contentplaceholder kan sättas här från titlen--%>

<asp:Content ContentPlaceHolderID="MessageContentPlaceHolder" runat="server">
        
         <div><h2>Annonser</h2></div>
          <div><h4>Säljes</h4></div>
    </asp:Content>       


<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">   
    <asp:ValidationSummary ID="ListiningValidationSummary" runat="server" />
    
    <div>        
        <asp:HyperLink runat="server" Text="Lägg till annons" NavigateUrl="~/Pages/AddPages/CreateAdd.aspx"/>
    </div>                                                 <%-- '<%# GetRouteUrl("AddCreate", null) %>' Fick det inte att funka --%>   

    <%--Hämtar ut alla annonser. PageWise?... --%>
    <asp:ListView ID="AddListView" runat="server"
        itemtype="Pro2014ASP.Model.Add"
        SelectMethod="AddListView_GetData"
        DataKeyName="AddID">
         
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
        
        <ItemTemplate>
                    <%-- Mall för nya rader. --%>
            
            <tr>
                <td>
                        <%-- Länk till enskild annons sida --%>
                       <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("AddDetails", new { id = Item.AddID })  %>'> <%#: Item.HeadLine %> </asp:HyperLink>
                </td>
                <td>  <%#: Item.Price %>     </td>
                <td>  <%#: Item.Area %>      </td>                        
                <td>  <%#: Item.Insert %>    </td>
            </tr>

       </ItemTemplate>
        <EmptyDataTemplate>
                        <%-- Detta visas då kunduppgifter saknas i databasen. --%>
                        <table>
                            <tr>
                                <td>  Kontaktuppgifter saknas!  </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
    </asp:ListView>




</asp:Content>
