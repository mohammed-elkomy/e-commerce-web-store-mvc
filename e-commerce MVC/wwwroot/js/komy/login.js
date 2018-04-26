$(document).ready(function () {
    $("#login_form").submit(function (event) {
        if ($("#login_email").val() === "" || $("#login_password").val() === "" )) {

            if ($("#login_email").val() === "")
                $("#error_message").html("Check Your Input Username.");
            else if ($("#login_password").val() === "")
                $("#error_message").html("Check Your Input Password.");

            $("#error_message").show();

            event.preventDefault();
        } else
            $("#error_message").hide();
    });

}); 