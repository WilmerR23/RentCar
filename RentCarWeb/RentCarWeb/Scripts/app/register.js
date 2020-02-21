

$(document).ready(function () {

    $("#form-registro").submit(function (e) {
        var clave = $("#txtClave").val();
        var claveConfirmacion = $("#txtConfirmarContraseña").val();
        var correo = $("#txtCorreo").val();
        if (clave.length > 0 && claveConfirmacion.length > 0 && correo.length > 0) {
            if (emailIsValid(correo)) {

                if (clave == claveConfirmacion)
                    return true;

                $("#txtError").html("Las contraseñas no coinciden");
                $("#txtError").show();
            } else {
                $("#txtError").html("El correo no es valido");
                $("#txtError").show();
            }
        } else {
            $("#txtError").html("Debe completar todos los campos");
            $("#txtError").show();
        }
            
        e.preventDefault();
    });

    $("#btnRegistro").on("click", function () {

        //swal({
        //    title: "Campo vacio",
        //    text: "Favor de completar todos los campos",
        //    icon: "warning",
        //    button: "aceptar",
        //});


    });

    function emailIsValid(email) {
        return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)
    }

})