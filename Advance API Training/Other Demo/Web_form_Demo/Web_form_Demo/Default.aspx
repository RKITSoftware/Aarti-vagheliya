<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_form_Demo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Web Form</title>
    <!-- Include Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <!-- Name Input -->
            <div class="form-group row">
                <label for="txtName" class="col-sm-2 col-form-label">Name:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                </div>
            </div>
            <!-- Email Input -->
            <div class="form-group row">
                <label for="txtEmail" class="col-sm-2 col-form-label">Email:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                </div>
            </div>
            <!-- Date of Birth Input -->
            <div class="form-group row">
                <label for="txtDOB" class="col-sm-2 col-form-label">Date of Birth:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="Enter Date of Birth" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <!-- Country Dropdown -->
            <div class="form-group row">
                <label for="ddlCountry" class="col-sm-2 col-form-label">Country:</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Select Country" Value="" />
                        <asp:ListItem Text="USA" Value="USA" />
                        <asp:ListItem Text="Canada" Value="Canada" />
                        <asp:ListItem Text="UK" Value="UK" />
                        <asp:ListItem Text="India" Value="India" />
                        <asp:ListItem Text="China" Value="China" />
                        <asp:ListItem Text="Pakistan" Value="Pakistan" />
                       
                    </asp:DropDownList>
                </div>
            </div>
            <!-- Button to add a new record -->
            <div class="form-group row">
                <div class="col-sm-12">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="btn btn-primary mx-auto d-flex justify-content-center align-items-center" />
                </div>
            </div>
            <!-- GridView to display records -->
            <div class="row">
                <div class="col-sm-12">
                   <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="Id" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                            <asp:TemplateField HeaderText="Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditName" runat="server" Text='<%# Bind("Name") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date of Birth">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditDOB" runat="server" CssClass="form-control" Text='<%# Bind("DOB", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDOB" runat="server" Text='<%# Bind("DOB", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Country">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlEditCountry" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="USA" Value="USA" />
                                        <asp:ListItem Text="Canada" Value="Canada" />
                                        <asp:ListItem Text="UK" Value="UK" />
                                        <asp:ListItem Text="India" Value="India" />
                                        <asp:ListItem Text="China" Value="China" />
                                        <asp:ListItem Text="Pakistan" Value="Pakistan" />
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="Action" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
    <!-- Include Bootstrap JS (optional) -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
