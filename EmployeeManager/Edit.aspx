<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="EmployeeManager.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Update Employee</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
     <h1 class="text-center my-5 fs-2">Update Details</h1>
    <div class="container">
        <div class="row">
            <div class="mb-3 col-md-6">
                <asp:Label ID="Label_Name" class="form-label" runat="server" AssociatedControlID="TextBox_Name" Text="Name"></asp:Label>
                <asp:TextBox ID="TextBox_Name" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" ControlToValidate="TextBox_Name" runat="server" ErrorMessage="Name is Required" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3 col-md-6">
                <asp:Label ID="Label_Gender" class="form-label" runat="server" AssociatedControlID="DropDownList_Gender" Text="Gender"></asp:Label>
                <asp:DropDownList ID="DropDownList_Gender" CssClass="form-select" runat="server">
                    <asp:ListItem Selected="True">Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="mb-3 col-md-6">
                <asp:Label ID="Label_Age" class="form-label" runat="server" AssociatedControlID="TextBox_Age" Text="Age"></asp:Label>
                <asp:TextBox ID="TextBox_Age" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" ControlToValidate="TextBox_Age" runat="server" ErrorMessage="Age is Required" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" CssClass="text-danger" ControlToValidate="TextBox_Age" runat="server" ErrorMessage="Age must be between 0 and 99" MinimumValue="0" MaximumValue="99" Display="Dynamic"></asp:RangeValidator>

            </div>
            <div class="mb-3 col-md-6">
                <asp:Label ID="Label_Salary" class="form-label" runat="server" AssociatedControlID="TextBox_Salary" Text="Salary"></asp:Label>
                <asp:TextBox ID="TextBox_Salary" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" ControlToValidate="TextBox_Salary" runat="server" ErrorMessage="Salary is Required" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label_Address" class="form-label" runat="server" AssociatedControlID="TextBox_Address" Text="Address"></asp:Label>
                <asp:TextBox ID="TextBox_Address" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" ControlToValidate="TextBox_Address" runat="server" ErrorMessage="Address is Required" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <asp:Button ID="Button_Submit" runat="server" class="btn btn-primary col-auto px-4 me-3" Text="Update" OnClick="Button_Submit_Click" />
        <a href="Index.aspx" class="col-auto">Back to Home</a>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScripts" runat="server">
</asp:Content>
