<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SummaryInfo.aspx.cs" Inherits="SummaryInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Summary</title>
    <style type="text/css">  
            #GridView1 {  
                font-family: Verdana;  
                font-size: 10pt;  
                font-weight: normal;  
                color: black;  
            }  
        </style>  
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Today Order Summary</h1>
            <asp:Button runat="server" Text="Add Order" ID="btnAddOrder" OnClick="btnAddOrder_Click" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="id"
                OnRowDataBound="GridView1_RowDataBound"
                
                OnRowEditing="GridView1_RowEditing" 
                OnRowUpdating="GridView1_RowUpdating" 
                OnRowCancelingEdit="GridView1_RowCancelingEdit" EnableViewState="False" >
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>  
                    <asp:CommandField ShowEditButton="true" />
                    </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
