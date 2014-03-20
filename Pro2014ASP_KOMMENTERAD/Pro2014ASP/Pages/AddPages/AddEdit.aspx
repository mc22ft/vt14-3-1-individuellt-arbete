<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="AddEdit.aspx.cs" Inherits="Pro2014ASP.AddEdit" %>

                                    <%-- Meny för denna sida som genereras ut --%>
<asp:Content ContentPlaceHolderID="MessageContentPlaceHolder" runat="server">        
    <h2>Redigera en annons!</h2>         
    </asp:Content>  

                                    <%-- Content genereras ut på master page när den är aktiv  --%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">    
                                    
                                    <%-- Valedeings kontroll saknas!! ValidationSummary... 
                                        Som också fel meddelande från ModelStat vissas i --%>                

                                    
                                    <%-- Vissar meddelande när annons lyckts - Session --%>
    <asp:PlaceHolder ID="MessagePlaceHolder" runat="server" Visible="false">
               <p>Annonsen har uppdaterats.</p>
            </asp:PlaceHolder>

                                    <%-- Formulär med olika egenskaper --%>
    <asp:FormView ID="AddFormView" runat="server"
        ItemType="Pro2014ASP.Model.Add"
        DataKeyNames="AddID"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="AddAddsFormView_GetItem"
        UpdateMethod="CustomerFormView_UpdateItem">
        
                                    <%-- Genererar ut textboxar med aktuellt värde i för updatering --%>
        <EditItemTemplate>

            <div class="editor-label">
                <label for="HeadLine">Rubrik</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="HeadLine" runat="server" Text='<%# BindItem.HeadLine %>' MaxLength="50" />
            </div>
            
            <div class="editor-label">
                <label for="Insert">Datum</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Insert" runat="server" Text='<%# BindItem.Insert %>' ReadOnly="True" />
            </div>
            <div class="editor-label">
                <label for="Description">Beskrivning</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Description" runat="server" Text='<%# BindItem.Description %>' MaxLength="500" />
            </div>


            <div class="editor-label">
                <label for="Price">Pris</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Price" runat="server" Text='<%# BindItem.Price %>' />
            </div>
            <div class="editor-label">
                <label for="Town">Stad</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Town" runat="server" Text='<%# BindItem.Town %>' MaxLength="25" />
            </div>

            <div>
                <label for="Postalcode">Postnummer</label>
            </div>
            <div>
                <asp:TextBox ID="Postalcode" runat="server" Text='<%# BindItem.Postalcode %>' MaxLength="5" />
            </div>

            <div class="editor-label">
                <label for="Name">Namn</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' MaxLength="25" />
            </div>
            <div class="editor-label">
                <label for="Contact">Kontakt</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Contact" runat="server" Text='<%# BindItem.Contact %>' MaxLength="25" />
            </div>         


                                            <%-- Knappar för att att utföra updatering eller avbryta updatering --%>
            <div class="link">
                <asp:LinkButton runat="server" Text="Spara" CommandName="Update" />
                <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("AddDetails", new { id = Item.AddID }) %>' />
            </div>


                                              <%-- VALEDERING --%>

         <%-- Rubrik --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="HeadLine"
                ErrorMessage="Du måste ange en rubrik." 
                ForeColor="#CC0000" 
                Display="None" 
                SetFocusOnError="True">
        </asp:RequiredFieldValidator>
         <%-- Datum - Låst fält --%>
         <%-- Beskrivning - Kan vara tomt --%>
         <%-- Pris --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
            ControlToValidate="Price"
            ErrorMessage="Du måste ange ett pris." 
            ForeColor="#CC0000" 
            Display="None" 
            SetFocusOnError="True">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="Price"
            ErrorMessage="Du har inte anget en giltigt pris."
            ForeColor="#CC0000" 
            Display="None" 
            SetFocusOnError="True"
            ValidationExpression="^[0-9]*$">                                
        </asp:RegularExpressionValidator>
         <%-- Stad --%>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="Town"
            ErrorMessage="Du måste ange en stad." 
            ForeColor="#CC0000" 
            Display="None" 
            SetFocusOnError="True">
         </asp:RequiredFieldValidator>
         <%-- Namn --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="Name"
            ErrorMessage="Du måste ange ett namn." 
            ForeColor="#CC0000" 
            Display="None" 
            SetFocusOnError="True">
        </asp:RequiredFieldValidator>
         <%-- Kontakt --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="Contact"
            ErrorMessage="Du måste ange en kontakt." 
            ForeColor="#CC0000" 
            Display="None" 
            SetFocusOnError="True">
        </asp:RequiredFieldValidator>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
