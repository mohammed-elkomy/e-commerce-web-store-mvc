$(document).ready(function () {
    $("#contact_form").submit(function (event) {
        $("#success_message").hide();
        $("#success_message_br").hide();
        

        if ($("#name").val() === "" || $("#subject").val() === "" || $("#message").val() === "" || $("#email").val() === "" || !isEmail($("#email").val())) {

            if ($("#name").val() === "")
                $("#error_message").html("Check Your Input Name.");
            else if ($("#email").val() === "" || !isEmail($(email).val()))
                $("#error_message").html("Check Your Input Email.");
            else if ($("#subject").val() === "")
                $("#error_message").html("Check Your Input Subject.");

            else if ($("#message").val() === "")
                $("#error_message").html("Check Your Input Message.");

            $("#error_message").show();
            
            event.preventDefault();
        }
        else $("#error_message").hide();
    });
    $("#message").val("")
});


