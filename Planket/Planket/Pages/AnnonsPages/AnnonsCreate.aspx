<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="AnnonsCreate.aspx.cs" Inherits="Planket.Pages.AnnonsPages.AnnonsCreate" %>

<%-- Meny för denna sida som genereras ut --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">        
    <h3>Lägg in en annons.</h3>
</asp:Content>

<%-- Content genereras ut på master page när den är aktiv  --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
     
    <%-- Presenterar meddelande --%>
     <asp:ValidationSummary runat="server" />   

    
    <asp:FormView ID="CreateAnnonsFormView" runat="server"
        Itemtype="Planket.Model.Annons"
        InsertMethod="CreateAnnonsFormView_InsertItem"        
        DefaultMode="Insert"
        RenderOuterTables="false">        

        <InsertItemTemplate>

             <%-- Kontak uppgifter --%>
         <div class="contact">
            <div>
                <label for="Rubrik">Rubrik</label>
            </div>
            <div>
                <asp:TextBox ID="Rubrik" runat="server" Text='<%# BindItem.Rubrik %>' MaxLength="50" />
                <asp:RequiredFieldValidator ID="RubrikRequiredFieldValidator" runat="server" 
                        ControlToValidate="Rubrik"
                        Text="*"
                        ErrorMessage="Du måste ange en rubrik." 
                        ForeColor="#CC0000" 
                        Display="None" 
                        SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
            </div>

             <div>
                <label for="Pris">Pris</label>
            </div>
            <div>
                <asp:TextBox ID="Pris" runat="server" Text='<%# BindItem.Pris %>' MaxLength="10" />
                <p>Kr</p>               
                 <asp:RequiredFieldValidator ID="PrisRequiredFieldValidator" runat="server" 
                    ControlToValidate="Pris"
                     Text="*"
                    ErrorMessage="Du måste ange ett pris." 
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="PrisRegularExpressionValidator" runat="server" 
                    ControlToValidate="Pris"
                    Text="*"
                    ErrorMessage="Du har inte anget en giltigt pris."
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True"
                    ValidationExpression="^[0-9]*$">                                
                </asp:RegularExpressionValidator>
            </div>

            <div>
                <label for="Beskrivning">Beskrivning</label>
            </div>
            <div>
                <asp:TextBox ID="Beskrivning" runat="server" Text='<%# BindItem.Beskrivning %>' TextMode="MultiLine" MaxLength="500" />
                <asp:RequiredFieldValidator ID="BeskrivningRequiredFieldValidator" runat="server" 
                    ControlToValidate="Beskrivning"
                    Text="*"
                    ErrorMessage="Du måste ange ett beskrivning." 
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
            </div>
              
            <li>
                <div><%-- Dropdownlist kategorityp --%>
                <label for="AddTypeDropDownList">Kategori typ</label>
                </div>
                <asp:DropDownList ID="AddTypeDropDownList" runat="server"                    
                    SelectMethod="KategoriTypeDropDownList_GetData"
                    DataTextField="Kategorityp"
                    DataValueField="KategoriID"
                    SelectedValue='<%# BindItem.KategoriID %>'/>

                <asp:HyperLink ID="NewKategoriHyperLink" runat="server" Text="Lägg till ny Kategori" NavigateUrl='<%$ RouteUrl:routename = KategoriPage %>' />
            </li>
            
             <li>
                <div><%-- Dropdownlist läntyp --%>
                <label for="LanDropDownList">Välj Län</label>
                </div>
                <asp:DropDownList ID="LanDropDownList" runat="server"                    
                    SelectMethod="LanTypeDropDownList_GetData"
                    DataTextField="Lantyp"
                    DataValueField="LanID"
                    SelectedValue='<%# BindItem.LanID %>'/>
            </li>

            <div class="link">
                <%-- JAVASCRIPT för att betraktas som en POSTNING --%>
                <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
            </div>

        </InsertItemTemplate>        
    </asp:FormView>
</asp:Content>