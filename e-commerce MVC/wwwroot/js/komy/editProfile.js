$(document).ready(function () {
    $('#imageUploadTrigger').click(function () {
        $('#imageUpload').trigger('click');
    });

    $('#imageUpload').change(function (event) {

        if (event.target.files && event.target.files[0]) {
            console.log("here2");
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imageView')
                    .attr('src', e.target.result)
                    .width(150)
                    .height(150);
            };
            reader.readAsDataURL(event.target.files[0]);
        }
    });

    $("#editForm").submit(function (event) {

        if ($("#reg_first").val() === "" || $("#reg_last").val() === "" || $("#reg_email").val() === "" || !isEmail($("#reg_email").val())|| $("#reg_mobile").val() === "" || !isPhone($("#reg_mobile").val())) {

            if ($("#reg_first").val() === "")
                $("#error_message").html("<strong>Oh snap!</strong> Check Your Input First Name.");
            else if ($("#reg_last").val() === "")
                $("#error_message").html("<strong>Oh snap!</strong> Check Your Input Last Name.");
            else if ($("#reg_email").val() === "" || !isEmail($("#reg_email").val()))
                $("#error_message").html("<strong>Oh snap!</strong> Check Your Input Email.");
            else if ( $("#reg_mobile").val()==="" || !isPhone($("#reg_mobile").val()))
                $("#error_message").html("<strong>Oh snap!</strong> Check Your Input Mobile Number.");

            $("#error_message").show();
        }
        else
            $("#error_message").hide();

        event.preventDefault();
    });

    $("#usertags").css({
        'width': ($("#reg_mobile").width() )
    });
});


