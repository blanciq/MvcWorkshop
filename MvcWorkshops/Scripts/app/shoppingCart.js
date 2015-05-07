var shoppingCart = (function() {
    var self = {};
    var update = function() {
        Focus.Common.Ajax({
            url: "/shoppingcart/header",
            success: function(data) {
                $("#shopping-cart-container").html(data);
            }
        });
    }

    var showConfirmationDialog = function (data) {
        update();
        var $dialog = $("<div></div>").html(data);
        var $h1 = $dialog.find("h1");
        var title = $h1.text();
        $h1.remove();
        $dialog.dialog({
            width: "450px",
            title: title,
            buttons: [
                {
                    text: "Continue shopping",
                    click: function() {
                        $dialog.dialog("close");
                    }
                }, {
                    text: "Go to shopping cart",
                    click: function() {
                        document.location.href = consts.url.shoppingCart;
                    }
                }
            ],
            close: function() {
                $dialog.dialog("destroy").remove();
            }
        });
    }
    $(function() {
        $(".product a").click(function (event) {
            event.preventDefault();
            var url = $(this).attr("href");
            var title = $(this).attr("data-title");
            Focus.Common.Ajax({
                method: "POST",
                url: url,
                success: function(data) {
                    showConfirmationDialog(data);
                }
            });
        });
    });
    return self;
})();