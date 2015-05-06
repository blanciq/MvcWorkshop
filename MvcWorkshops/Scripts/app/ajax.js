var Focus = Focus || {};
Focus.Common = Focus.Common || {};
Focus.Common.Ajax = Focus.Common.Ajax || function(options) {
    options = $.extend(options, {
        error: function(data) {
            alert("An error occured");
        }
    });
    return $.ajax(options);
}