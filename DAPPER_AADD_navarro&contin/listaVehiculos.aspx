<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listaVehiculos.aspx.cs" Inherits="DAPPER_AADD_navarro_contin.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gdVehiculos" runat="server" AutoGenerateColumns="False" DataSourceID="tVehiculos" AllowPaging="True" DataKeyNames="id_vehiculo">
                <Columns>
                    <asp:BoundField DataField="id_vehiculo" HeaderText="id_vehiculo" ReadOnly="True" SortExpression="id_vehiculo" />
                    <asp:BoundField DataField="id_modelo" HeaderText="id_modelo" SortExpression="id_modelo" />
                    <asp:BoundField DataField="color" HeaderText="color" SortExpression="color" />
                    <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                    <asp:BoundField DataField="anio" HeaderText="anio" SortExpression="anio" />
                    <asp:CheckBoxField DataField="disponible" HeaderText="disponible" SortExpression="disponible" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:EntityDataSource ID="tVehiculos" runat="server" ConnectionString="name=ConcesionariosEntities" DefaultContainerName="ConcesionariosEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Vehiculos">
        </asp:EntityDataSource>
    </form>
</body>
</html>