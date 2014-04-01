<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="AnnonsEdit.aspx.cs" Inherits="Planket.Pages.AnnonsPages.AnnonsEdit" %>

<%-- Meny för denna sida som genereras ut --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h3>Redigera din annons</h3>
</asp:Content>

<%-- Content genereras ut på master page när den är aktiv  --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <%-- Presenterar meddelande --%>
    <asp:ValidationSummary runat="server" />

    <asp:FormView ID="AnnonsEditFormView" runat="server"
        ItemType="Planket.Model.Annons"
        DataKeyNames="AnnonsID"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="AnnonsEditFormView_GetItem"
        UpdateMethod="AnnonsEditFormView_UpdateItem">
        
        <%-- Genererar ut textboxar med aktuellt värde i för updatering --%>
        <EditItemTemplate>
            <%-- Rubrik  --%>
            <div class="editor-label">
                <label for="Rubrik">Rubrik</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Rubrik" runat="server" Text='<%# BindItem.Rubrik %>' MaxLength="25" />
                <asp:RequiredFieldValidator ID="EditRubrikRequiredFieldValidator" runat="server" 
                        ControlToValidate="Rubrik"
                        Text="*"
                        ErrorMessage="Du måste ange en rubrik." 
                        ForeColor="#CC0000" 
                        Display="None" 
                        SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
            </div>      
            
            <%-- Pris --%>
            <div class="editor-label">
                <label for="EditPris">Pris</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="EditPris" runat="server" Text='<%# BindItem.Pris %>' />
                <p>Kr</p>
                <asp:RequiredFieldValidator ID="EditPrisRequiredFieldValidator" runat="server" 
                    ControlToValidate="EditPris"
                    Text="*"
                    ErrorMessage="Du måste ange ett pris." 
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EditPrisRegularExpressionValidator" runat="server" 
                    ControlToValidate="EditPris"
                    Text="*"
                    ErrorMessage="Du har inte anget en giltigt pris."
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True"
                    ValidationExpression="^[0-9]*$">                                
                </asp:RegularExpressionValidator>
            </div> 
            <%-- Beskrivning --%>
            <div class="editor-label">
                <label for="EditBeskrivning">Beskrivning</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="EditBeskrivning" runat="server" Text='<%# BindItem.Beskrivning %>' TextMode="MultiLine" MaxLength="500" />
                <asp:RequiredFieldValidator ID="EditBeskrivningRequiredFieldValidator" runat="server" 
                    ControlToValidate="EditBeskrivning"
                    Text="*"
                    ErrorMessage="Du måste ange ett beskrivning." 
                    ForeColor="#CC0000" 
                    Display="None" 
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
            </div>

            <%-- Dropp Kategori typ --%>
            <li>
                <div>
                    <label for="AddTypeDropDownList">Kategori typ</label>
                </div>
                <asp:DropDownList ID="AddTypeDropDownList" runat="server"                    
                    SelectMethod="KategoriTypeDropDownList_GetData"
                    DataTextField="Kategorityp"
                    DataValueField="KategoriID"
                    SelectedValue='<%# BindItem.KategoriID %>'/>

                <asp:HyperLink ID="NewKategoriHyperLink" runat="server" Text="Lägg till ny Kategori" NavigateUrl='<%$ RouteUrl:routename = KategoriPage %>' />
           </li>

            <%-- Dropp Välj Län --%>
            <li>
                <div>
                <label for="LanDropDownList">Välj Län</label>
                </div>
                <asp:DropDownList ID="LanDropDownList" runat="server"                    
                    SelectMethod="LanTypeDropDownList_GetData"
                    DataTextField="Lantyp"
                    DataValueField="LanID"
                    SelectedValue='<%# BindItem.LanID %>'/>
            </li>

                          <%-- Knappar för att att utföra updatering eller avbryta updatering --%>
            <div class="link">
                <asp:LinkButton runat="server" Text="Spara" CommandName="Update" />
                <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("AnnonsDetails", new { id = Item.AnnonsID }) %>' />
            </div> 
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>