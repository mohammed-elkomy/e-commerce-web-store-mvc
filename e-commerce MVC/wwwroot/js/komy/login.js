$(document).ready(function () {
    $("#login_form").submit(function (event) {
        if ($("#login_email").val() === "" || $("#login_password").val() === "" || !isEmail($("#login_email").val())) {

            if ($("#login_email").val() === ""||!isEmail($("#login_email").val()))
                $("#error_message").html("<strong>Oh snap!</strong> Check Your Input Email.");
            else if ($("#login_password").val() === "")
                $("#error_message").html("<strong>Oh snap!</strong> Check Your Input Password.");

            $("#error_message").show();
        } else
            $("#error_message").hide();

        event.preventDefault();
    });
});

