<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EditableGridview._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Diferentes Controls ASP.NET - Gridview</title>
</head>
<body>
    <form id="frmeditableGridview" runat="server">
    <div style="text-align: center">
        <h4>
            Informaci&oacute;n del empleado</h4>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" 
            OnRowDataBound="GridView1_RowDataBound" ShowFooter="true" OnRowDeleted="GridView1_Deleted">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="Label" runat="server" Text='<%# Eval("emp_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("emp_name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("emp_name")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="XC1" runat="server"></asp:TextBox>
                    </FooterTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Direcci&oacute;n">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("emp_address") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("emp_address") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="XC2" runat="server"></asp:TextBox>
                    </FooterTemplate>                                        
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Departamento">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("department") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" />
                    </FooterTemplate>                                        
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Salario">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("salary") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("salary") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="XC4" runat="server"></asp:TextBox>
                    </FooterTemplate>                                        
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado civil">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Maritalstatus") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem>Soltero</asp:ListItem>
                            <asp:ListItem>Casado</asp:ListItem>
                        </asp:RadioButtonList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:RadioButtonList ID="XC5" runat="server">
                            <asp:ListItem>Soltero</asp:ListItem>
                            <asp:ListItem>Casado</asp:ListItem>
                        </asp:RadioButtonList>                       
                    </FooterTemplate>                                        
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estatus">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Active_Status") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                            <asp:ListItem>Activo</asp:ListItem>
                            <asp:ListItem>Inactivo</asp:ListItem>
                        </asp:CheckBoxList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Editar" ShowHeader="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Editar"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar" ShowHeader="false">
                    <ItemTemplate>                    
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:button  ID="sNew" Text="Enviar" runat="server" OnClick="addItem"></asp:button>
                    </FooterTemplate>                    
               </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#CCCCCC" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
