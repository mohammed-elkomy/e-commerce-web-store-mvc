$(document).ready(function () {
    $("#forget_form").submit(function (event) {
        if ($("#forget_email").val() === ""||!isEmail($("#login_email").val())) {
            $("#error_message").html("<strong>Oh snap!</strong> Check Your Input Email.");
            $("#error_message").show();
        }else
        $("#error_message").hide();
        event.preventDefault();
    });
});

