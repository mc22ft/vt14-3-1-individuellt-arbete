<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="KategoriPage.aspx.cs" Inherits="Planket.Pages.KategoriPages.KategoriPage" %>

<%-- Meny för denna sida som genereras ut --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h3>Lista, skapa ny, redigera och ta bort kategori</h3>
</asp:Content>

<%-- Content genereras ut på master page när den är aktiv  --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <%-- Presenterar meddelande --%>
    <asp:ValidationSummary runat="server" class="alert alert-dismissable alert-info" />

    <asp:ListView ID="KategoriListView" runat="server"
        ItemType="Planket.Model.KategoriTyp"
        SelectMethod="KategoriListView_GetData"
        InsertMethod="KategoriListView_InsertItem"
        UpdateMethod="KategoriListView_UpdateItem"
        DeleteMethod="KategoriListView_DeleteItem"        
        InsertItemPosition="FirstItem"
        DataKeyNames="KategoriID">

        <LayoutTemplate>
            <table>
                <tr class="TableKategori"><%-- Meny --%>
                    <th>Kategorier</th>
                    <th>
                        <asp:LinkButton ID="BackToAddAnnonsLinkButton" runat="server" Text="Tillbaka" OnClick="BackToAddAnnonsLinkButton_Click" />                     
                    </th>                   
                </tr>
                            <%-- Platshållare för nya rader --%>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        
        <ItemTemplate>            
            <tr class="TableKategori">
                <td> <%#: Item.Kategorityp %> </td>
                <td>
                     <%-- ta bort och redigera kategorityp. Kommandonamnen är VIKTIGA! LÄNKA IN JAVASCRIPT --%>                                       
                    <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" class="btn btn-danger btn-xs"                      
                        OnClientClick='<%# String.Format("return AlertDelete(\"{0}\");", Eval("kategoriTyp")) %>' 
                        />                     
                    
                    <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" class="btn btn-primary btn-xs"/>
                </td>
            </tr>            
        </ItemTemplate>

        <EmptyDataTemplate>
            <%-- Detta visas då kategorier saknas i databasen. --%>
            <table>
                <tr class="TableKategori">
                    <td>  Kategori uppgifter saknas!  </td>
                </tr>
            </table>
        </EmptyDataTemplate>

         <InsertItemTemplate>
            <%-- Mall nya kunduppgifter. Visas bara om InsertItemPosition har värdet FirstItemPosition eller LasItemPosition.--%>
            <tr class="TableKategori">
                <td>
                    <asp:TextBox ID="KategoriTyp" runat="server" Text='<%# BindItem.Kategorityp %>' MaxLength="20" />                 
                </td>  
                <td>
                    <%-- "Kommandknappar" för att lägga till en ny kunduppgift och rensa texfälten. Kommandonamnen är VIKTIGA! --%>
                        <%-- JAVASCRIPT för att betraktas som en POSTNING --%>
                    <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" class="btn btn-success btn-xs" />
                    <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" class="btn btn-primary btn-xs"/>
                </td>
            </tr>
        </InsertItemTemplate>

        <EditItemTemplate>
            <%-- Mall för rad i tabellen för att redigera Kategorier. --%>
            <tr class="TableKategori">
                <td>
                    <asp:TextBox ID="KategoriTyp" runat="server" Text='<%# BindItem.Kategorityp %>' MaxLength="20" />                    
                </td>              
                       
                <td>
                    <%-- "Kommandknappar" för att uppdatera en kunduppgift och avbryta. Kommandonamnen är VIKTIGA! --%>
                        <%-- JAVASCRIPT för att betraktas som en POSTNING --%>
                    <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                    <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />

                        <%-- Valedering för TextBoxen, för lägga till och redigera textboxarna --%>
                        <%--                    KategoriTyp                       --%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="KategoriTyp"
                        Text="*"
                        ErrorMessage="Du måste ange en KategoriTyp." 
                        ForeColor="#CC0000" 
                        Display="None" 
                        SetFocusOnError="True">
                    </asp:RequiredFieldValidator>  
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
    
     <%-- JavaScript (ska in i extern fil) --%>
    <script type="text/javascript">
        function AlertDelete(Kategorityp) {
            if (confirm("Ta bort kategoritypen " + Kategorityp + " permanent!") == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script> 
</asp:Content>