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
                data: "Id", //0
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
        
        //drawCallback:
        //    //function (row, data, start, end, display) {
        //    function drawCallback() {
        //        var api = that.api();
        //        var pageTotal = api
        //                .columns(5/*, { page: 'current' }*/) 
        //                .data()
        //                .reduce(function (a, b) {
        //                    return Number(a) + Number(b);
        //                }, 0);
        //            // Update footer
        //        $(api.column(5).footer()).html(pageTotal);

        //    } 
    
         /*function (row, data, start, end, display) {
            var api = this.api();

            api.columns('.sum', {
                page: 'current'
            }).every(function () {
                var sum = this
                    .data()
                    .reduce(function (a, b) {
                        var x = parseFloat(a) || 0;
                        var y = parseFloat(b) || 0;
                        return x + y;
                    }, 0);
                console.log(sum); //alert(sum);
                $(this.footer()).html(sum);
            });
        } */
    });


    $("#BuyBtn").click(function () {
        $.post("/Buyer/Buy", function () { });
        $.post("/Home/Index", function () { });
    });
});
