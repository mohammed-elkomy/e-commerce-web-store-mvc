$(document).ready(function () {
    $("#contact_form").submit(function (event) {
        if ($("#name").val() === "" || $("#subject").val() === "" || $("#message").val() === "" || $("#email").val() === "" || !isEmail($("#email").val())) {

            if ($("#name").val() === "")
                $("#error_message").html("<strong>Oh snap!</strong> Check Your Input Name.");
            else if ($("#email").val() === "" || !isEmail($(email).val()))
                $("#error_message").html("<strong>Oh snap!</strong> Check Your Input Email.");
            else if ($("#subject").val() === "")
                $("#error_message").html("<strong>Oh snap!</strong> Check Your Input Subject.");

            else if ($("#message").val() === "")
                $("#error_message").html("<strong>Oh snap!</strong> Check Your Input Message.");

            $("#error_message").show();
        }
        else $("#error_message").hide();

        event.preventDefault();
    });
});


