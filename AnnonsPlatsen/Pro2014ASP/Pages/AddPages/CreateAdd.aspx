<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="CreateAdd.aspx.cs" Inherits="Pro2014ASP.CreateAdd" %>




<asp:Content ContentPlaceHolderID="MessageContentPlaceHolder" runat="server">
        
    <h2>Lägg till ny Annons!</h2>
         
    </asp:Content>  



<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server" >
    

    <asp:PlaceHolder ID="MessagePlaceHolder" runat="server" Visible="false">
        
    </asp:PlaceHolder>

    

    <asp:ValidationSummary ID="CreateValidationSummary" runat="server" />   
    
    <asp:FormView ID="CreateAddFormView" runat="server"
        Itemtype="Pro2014ASP.Model.Add"
        InsertMethod="CreateAddListView_InsertItem"
        DefaultMode="Insert"
        RenderOuterTables="false">
        

        <InsertItemTemplate>

<%--    Fixa om tid ges, hinner inte med att göra caschningen. 22h kvar!

            <asp:DropDownList ID="DropDownList" runat="server">    
                <asp:ListItem>Län</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:DropDownList>

--%>


             <%-- Kontak uppgifter --%>
         <div class="contact">
            <div>
                <label for="Name">Namn</label>
            </div>
            <div>
                <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' MaxLength="25" />
            </div>
            <div>
                <label for="Postalcode">Postnummer</label>
            </div>
            <div>
                <asp:TextBox ID="Postalcode" runat="server" Text='<%# BindItem.Postalcode %>' MaxLength="5" />
            </div>
            <div>
                <label for="Town">Stad</label>
            </div>
            <div>
                <asp:TextBox ID="Town" runat="server" Text='<%# BindItem.Town %>' MaxLength="25" />
            </div>
            <div>
                <label for="Contact">Kontakt</label>
            </div>
            <div>
                <asp:TextBox ID="Contact" runat="server" Text='<%# BindItem.Contact %>' MaxLength="25"/>
            </div>
             <div>
                <label for="Area">Län --- DropDownLista Men funkar nu att skicka in 1-7</label>
            </div>
            <div>
                <asp:TextBox ID="Area" runat="server" Text='<%# BindItem.Area %>' MaxLength="1"/>
            </div>
        </div>
            <%-- Annons uppgifer --%>
            <div class="">
             <div>
                <label for="HeadLine">Rubrik</label>
            </div>
            <div>
                <asp:TextBox ID="HeadLine" runat="server" Text='<%# BindItem.HeadLine %>' MaxLength="50"/>
            </div>
                <div>
                <label for="Description">Beskrivning</label>
            </div>
            <div>
                <asp:TextBox ID="Description" runat="server" TextMode="multiline" Text='<%# BindItem.Description %>' MaxLength="500" />
            </div><div>
                <label for="Price">Pris</label>
            </div>
            <div>
                <asp:TextBox ID="Price" runat="server" Text='<%# BindItem.Price %>' />
            </div>
                <div class="link">
                <%-- JAVASCRIPT för att betraktas som en POSTNING --%>
                                <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                                <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
              </div>

                                                         <%-- Valedering --%>
                 <%-- Namn --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="Name"
                    ErrorMessage="Du måste ange ett namn." 
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                 <%-- Postnummer --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Postalcode"
                    ErrorMessage="Du måste ange ett postnummer." 
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Postalcode"
                        ErrorMessage="Du har inte anget en giltigt postnummer."
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
                 <%-- Kontakt --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="Contact"
                    ErrorMessage="Du måste ange en kontakt." 
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                 <%-- Län --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="Area"
                    ErrorMessage="Du måste ange ett län." 
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="Area"
                    ErrorMessage="Du har inte anget en giltigt län."
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True"
                    ValidationExpression="^[0-9]*$">                                
                </asp:RegularExpressionValidator>
                 <%-- Rubrik --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="HeadLine"
                    ErrorMessage="Du måste ange en rubrik." 
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                 <%-- Beskrinvning - Kan vara tomt--%>
               
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


                <%-- 
                <li>
                <asp:DropDownList ID="AddTypeDropDownList" runat="server"
                    ItemType="Pro2014ASP.Model.Add"
                    SelectMethod="AddTypeDropDownList_GetData"
                    DataTextField="Name"
                    DataValueField="AreaTypeID"
                    SelectedValue='<%# BindItem.AreaTypeID %>' />
                <asp:TextBox ID="ValueTextBox" runat="server" Text='<%# BindItem.Area %>' MaxLength="50" ValidationGroup="vgContactInsert" />
               
                     <asp:RequiredFieldValidator runat="server" 
                         ErrorMessage="Fel i dropdown"
                    ControlToValidate="ValueTextBox" 
                         CssClass="field-validation-error" 
                         ValidationGroup="vgContactInsert"
                    Display="Dynamic">*</asp:RequiredFieldValidator>
                <%-- "Kommandknappar" för att uppdatera en kontaktuppgift och avbryta. Kommandonamnen är VIKTIGA! 
                <asp:LinkButton runat="server" CommandName="Insert" Text="Spara" ValidationGroup="vgContactInsert" />
            </li>
                --%>
            </div>


<%-- 
    <asp:LinkButton runat="server" Text="Spara" CommandName="Insert" />
                <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Customers", null) %>' />
--%>

            
        </InsertItemTemplate>


    </asp:FormView>




</asp:Content>
