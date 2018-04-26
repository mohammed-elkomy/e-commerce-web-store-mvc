$(document).ready(function () {
    $("#forget_form").submit(function (event) {
        if ($("#forget_email").val() === "" || !isEmail($("#forget_email").val())) {
            $("#error_message").html("Check Your Input Email.");
            $("#error_message").show();
            event.preventDefault();
        }else
        $("#error_message").hide();
       
    });
});

