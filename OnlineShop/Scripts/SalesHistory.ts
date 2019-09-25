$(document).ready(function () {
    var that = this;


    var CartsTable = $("#SalesHistoryTable").DataTable({
        ajax: {
            url: "/Seller/GetSalesHistory",
            type: "GET",
            dataType: "json"
        },
        columns: [
            {
                data: "Name"
            },
            {
                data: "Category"
            },
            {
                data: "Price"
            },
            {
                data: "Amount"
            },
            {
                data: "TotalPrice"
            }
        ],
    });
});