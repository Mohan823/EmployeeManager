﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="EmployeeManager.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Delete Employee ?</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
     <h1 class="text-center my-5 fs-2">Are you sure to delete?</h1>
    <div class="container">
        <div>
            <div class="fw-bold">Id</div>
            <asp:Label ID="Label_Id" runat="server" CssClass="ms-3"></asp:Label>
        </div>
        <div>
            <div class="fw-bold">Name</div>
            <asp:Label ID="Label_Name" runat="server" CssClass="ms-3"></asp:Label>
        </div>
        <div class="fw-bold">Gender</div>
        <asp:Label ID="Label_Gender" runat="server" CssClass="ms-3"></asp:Label>

        <div class="fw-bold">Age</div>
        <asp:Label ID="Label_Age" runat="server" CssClass="ms-3"></asp:Label>

        <div class="fw-bold">Salary</div>
        <asp:Label ID="Label_Salary" runat="server" CssClass="ms-3"></asp:Label>

        <div class="fw-bold">Address</div>
        <asp:Label ID="Label_Address" runat="server" CssClass="ms-3"></asp:Label>
       <div class="my-3"> 
           <asp:Button ID="Button_Delete" runat="server" CssClass="btn btn-danger me-2" Text="Delete" OnClick="Button_Delete_Click" />
            <a href="Index.aspx">Back to Home</a>
       </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScripts" runat="server">
</asp:Content>
