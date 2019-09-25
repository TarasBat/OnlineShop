$(document).ready(function () {
    var that = this;


    var CartsTable = $("#ShoppingHistoryTable").DataTable({
        ajax: {
            url: "/Buyer/GetShoppingHistory",
            type: "GET",
            dataType: "json"
        },
        columns: [
            {
                data: null,
                render: function (data, type, row) {
                    //Log that has details
                        return '<i class="fa fa-plus cursor-pointer"></i>';
                    },
                //that.renderMoreIcon //,
                className: "details-control"
            },
            {
                data: "ID", //0
            },
            {
                data: "Date"
            },
            {
                data: "TotalPrice"
            }
        ],

    });

    $("#ShoppingHistoryTable" + ' tbody').on('click', 'td.details-control .fa-plus, td.details-control .fa-minus', function () {
        var icon = $(this);
        var tr = icon.closest('tr');
        var row = CartsTable.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            icon.addClass("fa-plus");
            icon.removeClass("fa-minus");
        }
        else {
            var data = row.data();
            var PurchaseID = data["ID"];

            $.post($("#GetPurchaseOrdersM").data("request-url"), { PurchaseID }, function (partial) {
                // Open this row
                row.child(partial).show();
                icon.removeClass("fa-plus");
                icon.addClass("fa-minus");
            });
        }
    });



});
