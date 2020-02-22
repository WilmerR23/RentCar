

$(document).ready(function () {

$("#txtCedula").mask('000-0000000-0');
$("#txtTarjetaCredito").mask('0000 0000 0000 0000');
$("#txtTelefono").mask('(000) 000-0000');
$("#txtCelular").mask('(000) 000-0000');

$("#btnguardar").on("click", function () {
    var txtNombre = $("#txtNombre").val();
    var txtCedula = $("#txtCedula").val();
    var txtTarjetaCredito = $("#txtTarjetaCredito").val();
    var txtDireccion = $("#txtDireccion").val();
    var txtTelefono = $("#txtTelefono").val();
    var txtCelular = $('#txtCelular').val();

    var obj = {};
    obj.Id = idUsuario;
    obj.Nombre = txtNombre;
    obj.Cedula = txtCedula;
    obj.TarjetaCredito = txtTarjetaCredito;
    obj.Direccion = txtDireccion;
    obj.Telefono = txtTelefono;
    obj.Celular = txtCelular;

        var url = `${origen}api/Account/EditarVehiculo`;

        var ajaxRequest = $.ajax({
            type: "POST",
            url: url,
            contentType: "application/json",
            data: JSON.stringify(obj)
        });

        ajaxRequest.done(function (resultado) {
            if (resultado) {
                swal({
                    //title: 'Enhorabuena',
                    text: "Su información ha sido registrada",
                    type: 'success',
                    allowOutsideClick: false,
                    showCancelButton: false,
                    confirmButtonColor: '#3085d6',
                    confirmButtonText: 'Ok'
                }).then(function (result) {

                });
            }
        });

        ajaxRequest.fail(function (error) {
            swal({
                //title: 'Enhorabuena',
                text: "Ha ocurrido un error.",
                type: 'error',
                allowOutsideClick: false,
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Ok'
            }).then(function (result) {
                //if (result.value) {
                //    window.location.href = origen + 'Home';
                //}
            });
        });
    });
});