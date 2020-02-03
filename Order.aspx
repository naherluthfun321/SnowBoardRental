<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Rent Order</h1>
        <asp:Label runat="server" ID="txtErrorMsg" ForeColor="Red" Text=""></asp:Label>
        <table>
            <tr>
                <td>
                    Person Name:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPersonName"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    Driver License / ID:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLicenseId"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>
                    Snowboards

                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSnowboards" OnTextChanged="txtSnowboards_TextChanged" AutoPostBack="True"></asp:TextBox>
                    <asp:Label runat="server" ID="lblSnowAmt" ForeColor="Green" Text="$0.00"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                    Snowboards with Boots

                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSnowboardsBoots" AutoPostBack="True" OnTextChanged="txtSnowboardsBoots_TextChanged"></asp:TextBox>               
                    <asp:Label runat="server" ID="lblSnowBootAmt" ForeColor="Green" Text="$0.00"></asp:Label>
                </td>
            </tr>

                <tr>
                <td>
                   <span style="font-weight:bold">Rental Total:</span> 

                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRentalTotal" Font-Bold="True" ForeColor="Green" ReadOnly="True"></asp:TextBox>               
                </td>
            </tr>

            <tr>
                <td> 
                    <asp:Button runat="server" ID="btnBack" Text="<<Back" OnClick="btnBack_Click"></asp:Button>
                    <asp:Button runat="server" ID="btnSave" Text="Submit" OnClick="btnSave_Click"></asp:Button>
                </td>
            </tr>
            
        </table>
    </div>
    </form>
</body>
</html>
