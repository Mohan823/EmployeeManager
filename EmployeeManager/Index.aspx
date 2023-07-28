<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EmployeeManager.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <h1 class="text-center my-5">Manage Employees</h1>
    <asp:Label ID="Label_Error" runat="server" CssClass="d-none"></asp:Label>
    <asp:Label ID="Label_Success" runat="server" CssClass="d-none"></asp:Label>
    <div class="container mt-5">
        <div class="text-end">
            <a href="Create.aspx" class="btn btn-primary px-5 mb-3" runat="server">Create</a>
        </div>
        <asp:GridView ID="GridView" runat="server" CssClass="table table-responsive table-bordered table-striped" AutoGenerateColumns="False" OnRowEditing="GridView_RowEditing" PageSize="2" OnSelectedIndexChanging="GridView_SelectedIndexChanging" OnRowDeleting="GridView_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id"></asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                <asp:BoundField DataField="Gender" HeaderText="Gender"></asp:BoundField>
                <asp:BoundField DataField="Age" HeaderText="Age"></asp:BoundField>
                <asp:BoundField DataField="Address" HeaderText="Address"></asp:BoundField>
                <asp:BoundField DataField="Salary" HeaderText="Salary(Rs)"></asp:BoundField>
                <asp:CommandField SelectText="View" HeaderText="Actions" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" ButtonType="Button"></asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScripts" runat="server">
    <script>
        $("document").ready(function () {
            $("input[value='Edit']").addClass("btn btn-warning");
            $("input[value='Delete']").addClass("btn btn-danger");
            $("input[value='View']").addClass("btn btn-success");
        })
    </script>
    <script>
        $("document").ready(function () {
            let status = $("#ContentPlaceHolderBody_Label_Success").text()
            if (status) {
                toastr.success(status)
            } else {
                status = $("#ContentPlaceHolderBody_Label_Error").text()
                if (status) {
                    toastr.error(status)
                }
            }
        })
    </script>
</asp:Content>
