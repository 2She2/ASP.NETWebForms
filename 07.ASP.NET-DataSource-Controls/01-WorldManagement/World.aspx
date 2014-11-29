<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="World.aspx.cs" Inherits="_01_WorldManagement.World" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>World Management</title>
    <script type="text/javascript">
        function Confirm() {
            var confirmValue = document.createElement("input");
            confirmValue.type = "hidden";
            confirmValue.name = "confirm-value";
            if (confirm("Do you want to continue with the operation?")) {
                confirmValue.value = "Yes";
            } else {
                confirmValue.value = "No";
            }

            document.forms[0].appendChild(confirmValue);
        }
    </script>
</head>
<body>
    <form id="formWorld" runat="server">
        <div>
            <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server"
                ConnectionString="name=WorldEntities" DefaultContainerName="WorldEntities"
                EnableDelete="True" EnableFlattening="False" EnableInsert="True"
                EnableUpdate="True" EntitySetName="Continents">
            </asp:EntityDataSource>
            <fieldset>
                <legend>Continents</legend>
                <asp:ListBox ID="ListBoxContinents" runat="server" DataSourceID="EntityDataSourceContinents"
                    DataTextField="ContinentName" DataValueField="ContinentId" Rows="5" AutoPostBack="true"
                    OnSelectedIndexChanged="ListBoxContinents_SelectedIndexChanged"></asp:ListBox>
                <br />
                <asp:TextBox ID="TextBoxUpdateContinent" MaxLength="20" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonUpdateContinent" runat="server" OnClick="ButtonUpdateContinent_Click" Text="Update" />
                <asp:Button ID="ButtonDeleteContinent" runat="server" OnClick="ButtonDeleteContinent_Click" Text="Delete" />
                <asp:Button ID="ButtonAddContinent" runat="server" OnClick="ButtonAddContinent_Click" Text="Add" />
            </fieldset>
            <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server"
                ConnectionString="name=WorldEntities" DefaultContainerName="WorldEntities"
                EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True"
                EntitySetName="Countries" Where="it.ContinentId=@ContId" Include="Continent, Languages">
                <WhereParameters>
                    <asp:ControlParameter Name="ContId" Type="Int32"
                        ControlID="ListBoxContinents" />
                </WhereParameters>
            </asp:EntityDataSource>
            <asp:EntityDataSource ID="EntityDataSourceLanguages" runat="server" ConnectionString="name=WorldEntities" DefaultContainerName="WorldEntities" EnableFlattening="False" EntitySetName="Languages">
            </asp:EntityDataSource>
            <br />
            <br />
            <fieldset>
                <legend>Countries</legend>
                <asp:GridView ID="GridViewCountries" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CountryId" DataSourceID="EntityDataSourceCountries"
                    ForeColor="#333333" GridLines="None" ItemType="World.Country" ShowFooter="True"
                    OnRowDataBound="GridViewCountries_RowDataBound"
                    OnRowUpdating="GridViewCountries_RowUpdating"
                    OnRowUpdated="GridViewCountries_RowUpdated"
                    OnRowDeleting="GridViewCountries_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />

                        <asp:TemplateField HeaderText="Country Id" SortExpression="CountryId">
                            <ItemTemplate>
                                <%#: Item.CountryId %>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxAddCountryId" MaxLength="3" runat="server"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddCountryId"
                                    CssClass="text-danger" ErrorMessage="The Country Id field is required." />--%>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Country Name" SortExpression="CountryName">
                            <ItemTemplate>
                                <%#: Item.CountryName %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxCountryNameEdit" Text="<%#: BindItem.CountryName %>" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxAddCountry" runat="server"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddCountry"
                                    CssClass="text-danger" ErrorMessage="The Country Name field is required." />--%>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Latitude" SortExpression="Latitude">
                            <ItemTemplate>
                                <%#: Item.Latitude %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxLatitudeEdit" Text="<%#: BindItem.Latitude %>" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxAddLatitude" runat="server"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddLatitude"
                                    CssClass="text-danger" ErrorMessage="The Latitude field is required." />--%>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Longitude" SortExpression="Longitude">
                            <ItemTemplate>
                                <%#: Item.Longitude %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxLongitudeEdit" Text="<%#: BindItem.Longitude %>" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxAddLongitude" runat="server"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddLongitude"
                                    CssClass="text-danger" ErrorMessage="The Longitude field is required." />--%>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Surface Area" SortExpression="SurfaceArea">
                            <ItemTemplate>
                                <%#: Item.SurfaceArea %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxSurfaceAreaEdit" Text="<%#: BindItem.SurfaceArea %>" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxAddSurfaceArea" runat="server"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddSurfaceArea"
                                    CssClass="text-danger" ErrorMessage="The Surface Area field is required." />--%>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Population" SortExpression="Population">
                            <ItemTemplate>
                                <%#: Item.Population %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxPopulationEdit" Text="<%#: BindItem.Population %>" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TextBoxAddPopulation" runat="server"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddPopulation"
                                    CssClass="text-danger" ErrorMessage="The Population field is required." />--%>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Continent" SortExpression="Continent.ContinentName">
                            <ItemTemplate>
                                <%#: Item.Continent.ContinentName %>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%#: this.ListBoxContinents.SelectedItem.Text %>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Languages">
                            <ItemTemplate>
                                <%#: string.Join(", ", Item.Languages.Select(lang => lang.LanguageName)) %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxLanguages" runat="server"
                                    Text='<%# string.Join(", ", Item.Languages.Select(lang => lang.LanguageName))%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ListBox ID="ListBoxAddLanguages" runat="server" Rows="5"
                                    SelectionMode="Multiple"
                                    DataTextField="LanguageName"
                                    DataValueField="LanguageId"
                                    AppendDataBoundItems="True"
                                    DataSourceID="EntityDataSourceLanguages"></asp:ListBox>
                                <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="ListBoxAddLanguages"
                                    CssClass="text-danger" ErrorMessage="The Language field is required." />--%>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Flag">
                            <ItemTemplate>
                                <img src='data:image/png;base64,<%#: Item.FlagImage != null ? Convert.ToBase64String((byte[])Eval("FlagImage")) : string.Empty%>' alt="flag" height="50" width="100" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:FileUpload ID="FileUploadFlagChange" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:FileUpload ID="FileUploadFlagChange" runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label runat="server" Text="Footer"></asp:Label>
                                <asp:Button ID="ButtonAddCountry" OnClick="ButtonAddCountry_Click" Text="Add country" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <asp:Label ID="LabelCountryErrors" runat="server" ForeColor="Red"></asp:Label>
            </fieldset>
            <asp:EntityDataSource ID="EntityDataSourceTowns" runat="server" ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True"
                EnableUpdate="True" EntitySetName="Cities" Where="it.CountryId=@CountId">
                <WhereParameters>
                    <asp:ControlParameter Name="CountId" Type="String"
                        ControlID="GridViewCountries" />
                </WhereParameters>
            </asp:EntityDataSource>
            <br />
            <br />
            <fieldset>
                <legend>Cities</legend>
                <asp:ListView ID="ListViewCities" runat="server" DataKeyNames="CityId"
                    DataSourceID="EntityDataSourceTowns" 
                    InsertItemPosition="LastItem"
                    OnItemInserting="ListViewCities_ItemInserting" 
                    OnItemDeleting="ListViewCities_ItemDeleting" 
                    OnItemUpdating="ListViewCities_ItemUpdating">
                    <EditItemTemplate>
                        <tr style="background-color: #008A8C; color: #FFFFFF;">
                            <td>
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                            </td>
                            <td>
                                <asp:TextBox ID="CityNameTextBox" MaxLength="50" runat="server" Text='<%#: Bind("CityName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="LatitudeTextBox" runat="server" Text='<%#: Bind("Latitude") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="LongitudeTextBox" runat="server" Text='<%#: Bind("Longitude") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%#: Bind("Population") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.CountryName") %>' />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                            <tr>
                                <td>No data was returned.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                            </td>
                            <td>
                                <asp:TextBox ID="CityNameTextBox" runat="server" MaxLength="50" Text='<%#: Bind("CityName") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="LatitudeTextBox" runat="server" Text='<%#: Bind("Latitude") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="LongitudeTextBox" runat="server" Text='<%#: Bind("Longitude") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%#: Bind("Population") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.CountryName") %>' />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #DCDCDC; color: #000000;">
                            <td>
                                <asp:Button ID="DeleteButton" OnClientClick="Confirm()" runat="server" CommandName="Delete" Text="Delete" />
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            </td>
                            <td>
                                <asp:Label ID="CityNameLabel" runat="server" Text='<%#: Eval("CityName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LatitudeLabel" runat="server" Text='<%#: Eval("Latitude") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LongitudeLabel" runat="server" Text='<%#: Eval("Longitude") %>' />
                            </td>
                            <td>
                                <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.CountryName") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                            <th runat="server"></th>
                                            <th runat="server">City Name</th>
                                            <th runat="server">Latitude</th>
                                            <th runat="server">Longitude</th>
                                            <th runat="server">Population</th>
                                            <th runat="server">Country</th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                                    <asp:DataPager ID="DataPager1" runat="server">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            </td>
                            <td>
                                <asp:Label ID="CityNameLabel" runat="server" Text='<%#: Eval("CityName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LatitudeLabel" runat="server" Text='<%#: Eval("Latitude") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LongitudeLabel" runat="server" Text='<%#: Eval("Longitude") %>' />
                            </td>
                            <td>
                                <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.CountryName") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:Label ID="LabelCityErrors" runat="server" ForeColor="Red"></asp:Label>
            </fieldset>
        </div>
    </form>
</body>
</html>
