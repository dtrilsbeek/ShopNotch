$(".product-add-button").on("click", function() {

    var productId = $(this).data("productid");

    var amount = $("#product-amount").val();

    $.ajax({
        type: "POST",
        url: "/Shop/AddToCart",
        data: {
            productId: productId,
            amount: amount
        },
        success: function (data) {
            $("#main-notification").addClass("alert alert-success").html(amount + " item(s) added").delay(3000).queue(function() {
                $(this).html("").removeClass().dequeue();
            });
        }
    });

});