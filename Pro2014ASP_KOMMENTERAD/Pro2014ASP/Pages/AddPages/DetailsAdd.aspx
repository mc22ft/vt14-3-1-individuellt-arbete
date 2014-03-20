<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="DetailsAdd.aspx.cs" Inherits="Pro2014ASP.DetailsAdd" %>

                                <%-- Meny för denna sida som genereras ut --%>
<asp:Content ContentPlaceHolderID="MessageContentPlaceHolder" runat="server">        
    <h1>Annons</h1>         
    </asp:Content>

                                <%-- Content genereras ut på master page när den är aktiv  --%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
                                <%-- Presenterar meddelande från vaideringen kontrollerna och ModelState --%>
    <asp:ValidationSummary ID="DetailsValidationSummary" runat="server" />   
     
                                <%-- Formulär med olika egenskaper --%>
    <asp:FormView ID="FormViewDitailsAdd" runat="server"
        ItemType="Pro2014ASP.Model.Add"
        SelectMethod="FormViewDitailsAdd_GetItem"
        RenderOuterTable="false">

                                <%-- Vissar innehållet på en annons --%>
         <ItemTemplate>                     

            <div class="add">
                <div>
                      <h2><%#: Item.HeadLine %></h2>
                </div>

                <div>
                      <p>Inlagd: <%#: Item.Insert %></p>
                </div> 

                <div class="Description">                         
                      <p><%#: Item.Description %></p>
                </div> 
             
                <div>
                    <p>Pris: <%#: Item.Price %> </p><p>Finns i: <%#: Item.Town %></p>
                </div>
                <div>
                    <p>Annonsör: <%#: Item.Name %></p> <p>Kontakta mig:<%#: Item.Contact %></p> 
                </div>
            </div>
                                <%-- Knappar för val att redigera, radera en annons eller tillbaka till annonslista--%>
            <div class="link">
                <asp:HyperLink runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("AddEdit", new { id = Item.AddID }) %>' />
                                        
                 <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ta bort" 
                                 CausesValidation="false" 
                                 OnClientClick='<%# String.Format("return AlertDelete(\"{0}\", \"{1}\");", Eval("Name"), Eval("HeadLine")) %>' 
                                  OnCommand="DeleteLinkButton_Command1"            
                                  CommandArgument='<%$ RouteValue:id %>'/> 
                         
                <asp:HyperLink ID="BackHyperLink" runat="server" Text="Tillbaka"  NavigateUrl='<%# GetRouteUrl("Default", null) %>' />
            </div>
       </ItemTemplate>
                                <%-- Detta visas då kunduppgifter saknas i databasen. --%>
        <EmptyDataTemplate>                        
            <table>
                <tr>
                    <td>  Kontaktuppgifter saknas!  </td>
                </tr>
            </table>
      </EmptyDataTemplate>
    </asp:FormView>
                                <%-- JavaScript till delete knappen --%>
    <script type="text/javascript">
        function AlertDelete(FirstName, LastName) {
            if (confirm("Ta bort kontakten " + FirstName + " " + LastName + " permanent!") == true) {
                return true;
            }
            else
            {
                return false;
            }
        }
    </script>

</asp:Content>
