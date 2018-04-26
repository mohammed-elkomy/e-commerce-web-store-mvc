$(document).ready(function(){
    $("#register_form").submit(function(event){
        if($("#reg_first").val()==="" || $("#reg_last").val()==="" || $("#reg_mobile").val()==="" || !isPhone($("#reg_mobile").val())) {

            if ($("#reg_first").val()==="" )
                $("#error_message_up").html("Check Your Input First Name.");
            else if ($("#reg_last").val()==="")
                $("#error_message_up").html("Check Your Input Last Name.");
            else if ( $("#reg_mobile").val()==="" || !isPhone($("#reg_mobile").val()))
                $("#error_message_up").html("Check Your Input Mobile Number.");

            $("#error_message_up").show();

            event.preventDefault();
        }
        else {
            $("#error_message_up").hide();

            if ($("#reg_email").val() === "" || $("#reg_username").val() === "" || $("#reg_password").val() === "" || $("#conf_reg_password").val() === "" || !isEmail($("#reg_email").val()) || $("#reg_password").val() !== $("#conf_reg_password").val()||!$('#terms_chk').prop('checked') )
            {  
                if ($("#reg_email").val() === "" || !isEmail($("#reg_email").val())  )
                    $("#error_message_down").html("Check Your Input Email.");
                else if ($("#reg_username").val() === "")
                    $("#error_message_down").html("Check Your Input User Name.");
                else if ($("#reg_password").val() === "")
                    $("#error_message_down").html("Check Your Input Password.");
                else if( $("#reg_password").val() !== $("#conf_reg_password").val())
                    $("#error_message_down").html("Password Doesn't match.");
                else if(!$('#terms_chk').prop('checked'))
                    $("#error_message_down").html("Must Agree To Terms and Conditions");

                $("#error_message_down").show();

                event.preventDefault();
            }else
                $("#error_message_down").hide();
        }


       
    });
});


