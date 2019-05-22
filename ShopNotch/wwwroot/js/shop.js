$(".product-add-button").on("click", function() {

    var productId = $(this).data("productid");

    var amount = $("#product-amount").val();

    console.log(productId);
    console.log(amount);

    $.ajax({
        type: "POST",
        url: "/Shop/AddToCart",
        data: {
            productId: productId,
            amount: amount
        },
        success: function (data) {
            console.log(data);
        }
    });

});