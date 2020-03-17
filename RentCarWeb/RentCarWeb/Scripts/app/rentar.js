
var item = null;

$(document).ready(function () {

    $("#btnRentarVehiculo").on("click", function () {

        var dias = $("#dias").val();
        var servicio = $("#servicio-domicilio").is(':checked');
        var fechaRenta = $("#fechaRenta").val();
        var fechaDevolucion = $("#fechaDevolucion").val();

        var obj = {
            VehiculoId: item.Id,
            ServicioDomicilio: servicio,
            Dias: dias,
            FechaRenta: fechaRenta,
            FechaDevolucion: fechaDevolucion
        }

        var url = `${origen}api/Vehiculo/RentaVehiculo`;
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
                    text: "El vehiculo ha sido rentado satisfactoriamente",
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

    $("#fechaRenta,#fechaDevolucion").on("change", function () {
        fechaOnChangeLogic();
    });
})

function fechaOnChangeLogic() {
    var fechaRenta = $("#fechaRenta").val();
    var fechaDevolucion = $("#fechaDevolucion").val();

    if (fechaDevolucion != "" && fechaRenta != "") {
        const fecha1 = new Date(fechaRenta);
        const fecha2 = new Date(fechaDevolucion);
        const diffTime = Math.abs(fecha2 - fecha1) + 2;
        const num = Math.ceil(diffTime / (1000 * 60 * 60 * 24)); 
        var monto = $("#montodia").val();
        $("#dias").val(num);
        $("#total").val(num * monto);
    }


}

function btnRentarClick(id) {
    item = modelo.filter(x => x.Id == id)[0];
    $("#anovehiculo").val(item.Año);
    $("#marcavehiculo").val(item.MarcaDescripcion);
    $("#modelovehiculo").val(item.ModeloDescripcion);
    $("#montodia").val(item.Monto);
    $("#img-vehiculo").prop("src","data:image/jpg;base64," + item.ImagenPrincipal);
    $('#modal-renta').modal('show'); 
}