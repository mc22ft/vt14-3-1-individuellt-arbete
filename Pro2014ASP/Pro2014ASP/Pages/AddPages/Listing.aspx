<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shered/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="Pro2014ASP.Pages.AddPages.Listing" %>


<%--Contentplaceholder kan sättas här från titlen--%>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">


    <h1>Testar om detta kommer upp! Listan på annonserna ska upp här!</h1>




    <%--Hämtar ut alla annonser. PageWise... --%>
    <asp:ListView ID="AddListView" runat="server"
        itemtype="Pro2014ASP.Model.Add"
        SelectMethod="AddListView_GetData"
        InsertItemPosition="FirstItem">
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
            <div class="skip20page">
                    <asp:DataPager runat="server" PageSize="20">
                        <Fields>
                            <asp:NextPreviousPagerField 
                                ShowFirstPageButton="True" 
                                FirstPageText=" << "
                                ShowNextPageButton="False"
                                ShowPreviousPageButton="False"/>
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField 
                                ShowLastPageButton="True" 
                                LastPageText=" >> " 
                                ShowNextPageButton="False" 
                                ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
                    <%-- Mall för nya rader. --%>

            <tr>
                <td>  <%#: Item.HeadLine %>  </td>
                <td>  <%#: Item.Price %>     </td>
                <td>  <%#: Item.Area %>      </td>                        
                <td> <%#: Item.Insert %>     </td>
            </tr>

       </ItemTemplate>
    </asp:ListView>




</asp:Content>
