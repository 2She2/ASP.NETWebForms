<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="_02_TodoList.TodoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ToDos Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:EntityDataSource ID="EntityDataSourceTodos" runat="server"
                ConnectionString="name=ToDosDbEntities"
                DefaultContainerName="ToDosDbEntities"
                EnableDelete="True" EnableFlattening="False"
                EnableInsert="True" EnableUpdate="True" EntitySetName="ToDos"
                Include="Category">
            </asp:EntityDataSource>
            <asp:Label ID="LabelErrorMessages" runat="server"></asp:Label>
            <asp:Label ID="LabelSuccessMessages" runat="server"></asp:Label>
            <asp:ListView ID="ListViewTodos" runat="server" DataKeyNames="Id"
                DataSourceID="EntityDataSourceTodos"
                InsertItemPosition="LastItem"
                OnItemInserting="ListViewTodos_ItemInserting"
                OnItemUpdating="ListViewTodos_ItemUpdating">
                <EditItemTemplate>
                    <li style="background-color: #999999;">
                        Title:
                    <asp:TextBox ID="TitleEditTextBox" runat="server" MaxLength="50" Text='<%#: Bind("Title") %>' />
                        <br />
                        Body:
                    <asp:TextBox ID="BodyEditTextBox" runat="server" Text='<%#: Bind("Body") %>' />
                        <br />
                        Category:
                    <asp:TextBox ID="CategoryEditTextBox" runat="server" MaxLength="50" Text='<%#: Eval("Category.Name") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </li>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    No data was returned.
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <li style="">
                        Title:
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%#: Bind("Title") %>' />
                        <br />
                        Body:
                    <asp:TextBox ID="BodyTextBox" runat="server" Text='<%#: Bind("Body") %>' />
                        <br />
                        Category:
                    <asp:TextBox ID="CategoryTextBox" runat="server" Text='<%#: Eval("Category.Name") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </li>
                </InsertItemTemplate>
                <ItemSeparatorTemplate>
                    <br />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <li style="background-color: #E0FFFF; color: #333333;">
                        Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%#: Eval("Title") %>' />
                        <br />
                        Body:
                    <asp:Label ID="BodyLabel" runat="server" Text='<%#: Eval("Body") %>' />
                        <br />
                        LastUpdated:
                    <asp:Label ID="LastUpdatedLabel" runat="server" Text='<%#: Eval("LastUpdated") %>' />
                        <br />
                        Category:
                    <asp:Label ID="CategoryLabel" runat="server" Text='<%#: Eval("Category.Name") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </li>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                    <div style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF;">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="4">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <li style="background-color: #E2DED6; font-weight: bold; color: #333333;">
                        Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%#: Eval("Title") %>' />
                        <br />
                        Body:
                    <asp:Label ID="BodyLabel" runat="server" Text='<%#: Eval("Body") %>' />
                        <br />
                        LastUpdated:
                    <asp:Label ID="LastUpdatedLabel" runat="server" Text='<%#: Eval("LastUpdated") %>' />
                        <br />
                        Category:
                    <asp:Label ID="CategoryLabel" runat="server" Text='<%#: Eval("Category.Name") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </li>
                </SelectedItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
