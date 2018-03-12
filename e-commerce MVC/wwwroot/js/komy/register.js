$(document).ready(function(){
    $("#register_form").submit(function(event){
        if($("#reg_first").val()==="" || $("#reg_last").val()==="" || $("#reg_mobile").val()==="" || !isPhone($("#reg_mobile").val())) {

            if ($("#reg_first").val()==="" )
                $("#error_message_up").html("<strong>Oh snap!</strong> Check Your Input First Name.");
            else if ($("#reg_last").val()==="")
                $("#error_message_up").html("<strong>Oh snap!</strong> Check Your Input Last Name.");
            else if ( $("#reg_mobile").val()==="" || !isPhone($("#reg_mobile").val()))
                $("#error_message_up").html("<strong>Oh snap!</strong> Check Your Input Mobile Number.");

            $("#error_message_up").show();
        }
        else {
            $("#error_message_up").hide();

            if ($("#reg_email").val() === "" || $("#reg_password").val() === "" || $("#conf_reg_password").val() === "" || !isEmail($("#reg_email").val()) || $("#reg_password").val() !== $("#conf_reg_password").val()||!$('#terms_chk').prop('checked') )
            {
                if ($("#reg_email").val() === "" || !isEmail($("#reg_email").val())  )
                    $("#error_message_down").html("<strong>Oh snap!</strong> Check Your Input Email.");
                else if ($("#reg_password").val() === "")
                    $("#error_message_down").html("<strong>Oh snap!</strong> Check Your Input Password.");
                else if( $("#reg_password").val() !== $("#conf_reg_password").val())
                    $("#error_message_down").html("<strong>Oh snap!</strong> Password Doesn't match.");
                else if(!$('#terms_chk').prop('checked'))
                    $("#error_message_down").html("<strong>Oh snap!</strong> Please, Accept the terms.");

                $("#error_message_down").show();
            }else
                $("#error_message_down").hide();
        }


        event.preventDefault();
    });
});


