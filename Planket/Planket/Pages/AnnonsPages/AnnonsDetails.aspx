<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="AnnonsDetails.aspx.cs" Inherits="Planket.Pages.AnnonsPages.AnnonsDetails" %>
<%-- Meny för denna sida som genereras ut --%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h3>En annons</h3>
</asp:Content>

<%-- Content genereras ut på master page när den är aktiv  --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

      <%-- Presenterar meddelande --%>
      <asp:ValidationSummary runat="server" class="alert alert-dismissable alert-info" />   
     
    
    <asp:FormView ID="AnnonsFormViewDitails" runat="server"
        ItemType="Planket.Model.Annons"
        SelectMethod="AnnonsFormViewDitails_GetItem"        
        RenderOuterTable="false">

         <ItemTemplate>
                    <%-- Mall för nya rader. --%>  

          <div class="add well well-lg">
          
             <div class="Rubrik">
                  <h2><%#: Item.Rubrik %></h2>
            </div>
            <div class="Pris">
                  <p>Pris: <%#: Item.Pris %> Kr</p>
            </div>
            <div class="Description well ">                         
                  <p><%#: Item.Beskrivning %></p>
            </div>             
            <div>
                  <p>Annonsen finns i: <%#: Item.LanNamn %></p>
            </div>
            <div>
                  <p>Denna annons ligger under kategori :<%#: Item.KategoriNamn %> </p>
            </div>
        </div>
            <div class="link">
                <%-- Bottoms, "ta bort" ligger det javascript på --%>
                <asp:HyperLink runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("AnnonsEdit", new { id = Item.AnnonsID }) %>' class="btn btn-primary btn-xs" />
                <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ta bort" class="btn btn-danger btn-xs"
                                 CausesValidation="false" 
                                 OnClientClick='<%# String.Format("return AlertDelete(\"{0}\");", Eval("Rubrik")) %>' 
                                  OnCommand="DeleteLinkButton_Command"            
                                  CommandArgument='<%$ RouteValue:id %>'/>
                <asp:HyperLink ID="BackHyperLink" runat="server" Text="Tillbaka"  NavigateUrl='<%# GetRouteUrl("AnnonsList", null) %>' class="btn btn-primary btn-xs" />
            </div>
       </ItemTemplate>

        <EmptyDataTemplate>
                        <%-- Detta visas då annonser saknas i databasen. --%>
                        <table>
                            <tr>
                                <td>  Det finns inga annonser!  </td>
                            </tr>
                        </table>
      </EmptyDataTemplate>

    </asp:FormView>

    <%-- JavaScript (ska in i extern fil) --%>
    <script type="text/javascript">
        function AlertDelete(Rubrik) {
            if (confirm("Ta bort annonsen " + Rubrik + " permanent!") == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script> 

</asp:Content>
