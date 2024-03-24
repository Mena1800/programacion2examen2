<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Iniciarencuesta.aspx.cs" Inherits="programacion2examen2.Iniciarencuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h1>Iniciar Encuesta</h1>
        </div>
    
    <div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        </div>

    <div class="mb-3">
        <label for="formGroupExampleInput" class="form-label text-center">Nombre</label>
        <asp:TextBox ID="Tnom" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label for="formGroupExampleInput2" class="form-label text-center">Apellido</label>
        <asp:TextBox ID="Tapellido" class="form-control"  runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label for="formGroupExampleInput2" class="form-label text-center">Fecha de nacimiento</label>
        <asp:TextBox ID="Tfecha" class="form-control"  runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label for="formGroupExampleInput2" class="form-label text-center">Correo electronico</label>
        <asp:TextBox ID="Tcorreo" class="form-control"  runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label for="formGroupExampleInput2" class="form-label">Tiene carro propio?</label>
        <br />
        <br />
        <asp:RadioButton ID="Sitiene" runat="server" GroupName="carro" Text="Si tengo carro propio" />
        &nbsp;&nbsp;
        <asp:RadioButton ID="Notiene" runat="server" GroupName="carro" Text="No tengo carro propio" />
       
        <br />
        <br />
        <asp:Button ID="Bingresar" runat="server" OnClick="Bingresar_Click" Text="Ingresar encuesta" Width="170px" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
       
        <br />
       
    </div>

    

</asp:Content>
