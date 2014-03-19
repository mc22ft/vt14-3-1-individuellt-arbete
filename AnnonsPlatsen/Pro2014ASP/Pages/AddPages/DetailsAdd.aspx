<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="DetailsAdd.aspx.cs" Inherits="Pro2014ASP.DetailsAdd" %>

<asp:Content ContentPlaceHolderID="MessageContentPlaceHolder" runat="server">
        
    <h1>Annons</h1>
         
    </asp:Content>   


<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
       <asp:ValidationSummary ID="DetailsValidationSummary" runat="server" />   
     
    
    <asp:FormView ID="FormViewDitailsAdd" runat="server"
        ItemType="Pro2014ASP.Model.Add"
        SelectMethod="FormViewDitailsAdd_GetItem"
        RenderOuterTable="false">

         <ItemTemplate>
                    <%-- Mall för nya rader. --%>  

            <div class="add">         
            
                        <%-- <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("AddDetails", new { id = Item.AddID })  %>'> <%#: Item.HeadLine %> </asp:HyperLink> --%>
                       
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
            <div class="link">
                <asp:HyperLink runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("AddEdit", new { id = Item.AddID }) %>' />
               <%-- <asp:HyperLink runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("CustomerDelete", new { id = Item.AddID }) %>' />  
                     
                <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ja, ta bort kunden"
                    OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id %>' /> --%> 
                
                 <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ta bort" 
                                 CausesValidation="false" 
                                 OnClientClick='<%# String.Format("return AlertDelete(\"{0}\", \"{1}\");", Eval("Name"), Eval("HeadLine")) %>' 
                      OnCommand="DeleteLinkButton_Command1"            
                      CommandArgument='<%$ RouteValue:id %>'/> 
                         
                <asp:HyperLink ID="BackHyperLink" runat="server" Text="Tillbaka"  NavigateUrl='<%# GetRouteUrl("Default", null) %>' />
            </div>
             
    

       </ItemTemplate>

        <EmptyDataTemplate>
                        <%-- Detta visas då kunduppgifter saknas i databasen. --%>
                        <table>
                            <tr>
                                <td>  Kontaktuppgifter saknas!  </td>
                            </tr>
                        </table>
      </EmptyDataTemplate>


    </asp:FormView>

    <script type="text/javascript">
        function AlertDelete(FirstName, LastName) {
            if (confirm("Ta bort kontakten " + FirstName + " " + LastName + " permanent!") == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>       
   

</asp:Content>
