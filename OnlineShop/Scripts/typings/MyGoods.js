$(document).ready(function () {
    $("#sellersGoodsTable").DataTable({
        ajax: {
            url: "/Seller/GetGoodsList",
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
            }
        ]
    });
    var that = this;
    var GoodsTable = $("#GoodsTable").DataTable({
        ajax: {
            url: "/Buyer/GetGoodsList",
            type: "GET",
            dataType: "json"
        },
        columns: [
            {
                data: "Id",
                visible: false
            },
            {
                data: "SellerId",
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
                data: null,
                orderable: false,
                render: function (row) {
                    return "<input type='number' class='form-control text-right' name='Amount' min='1' onkeydown='javascript: return (event.keyCode == 69 ||  event.keyCode == 189 || event.keyCode == 109) ? false : true' style='width:90px' step='1' value = '1' ></input>";
                }
            },
            {
                data: null,
                orderable: false,
                render: function (data, type, row) {
                    return '<a class="btn AddToCarts" title="Add to carts"><i class="fas fa-cart-plus"></i></a>';
                }
            }
        ],
        drawCallback: function drawCallback() {
            $(".AddToCarts").unbind().click(function (index) {
                swal("Goods was successfully added to Carts!", "", "success");
                var row = $(this).closest("tr");
                var rowIndex = this.parentNode._DT_CellIndex.row;
                var rowData = GoodsTable.row(rowIndex).data();
                var amount = row.find("input[name='Amount']").val();
                var model = {
                    Id: rowData.Id,
                    Amount: amount
                };
                $.post("/Buyer/AddToCarts", model);
            });
        }
    });
});
//# sourceMappingURL=MyGoods.js.map