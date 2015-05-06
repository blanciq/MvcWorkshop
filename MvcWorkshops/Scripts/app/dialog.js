if ($) {
    $.fn.prepareDialogs = function() {
        var dialogOpened = false;
        $(this).click(function() {
            if (dialogOpened) {
                return;
            }
            var href = $(this).attr("href") || $(this).attr("data-href");
            dialogOpened = true;
            Focus.Common.Ajax({
                url: href,
                data: { id: $(this).attr("data-id") },
                type: "GET",
                success: function(data) {
                    var $div = $("<div></div>");
                    if (data.Success) {
                        $div.html(data.PartialView);
                        $div.dialog({
                            buttons: [
                                {
                                    text: 'OK',
                                    click: function() {
                                        $(this).dialog("close");
                                    }
                                }
                            ],
                            close: function() {
                                dialogOpened = false;
                                $(this).dialog("destroy").remove();
                            }
                        });
                    } else {
                        alert("sth wrong");
                    }
                }
            });
        });
    };
    $(function() {
        $(".dialog-link").prepareDialogs();
    });
}
