$(document).ready(function () {
    var that = this;
    var CartsTableY = $("#CartsTable").DataTable({
        ajax: {
            url: "/Buyer/GetOrdersList",
            type: "GET",
            dataType: "json"
        },
        columns: [
            {
                data: "Id",
                visible: false
            },
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
    $("#BuyBtn").click(function () {
        $.post("/Buyer/Buy", function () { });
        $.post("/Home/Index", function () { });
    });
});
//# sourceMappingURL=Carts.js.map