


$(document).ready(function () {

    $("#btnRentar").on("click", function () {

        //swal({
        //    title: "Campo vacio",
        //    text: "Favor de completar todos los campos",
        //    icon: "warning",
        //    button: "aceptar",
        //});


    });

    $("#dias").on("keyup", function () {

        var numero = $(this).val();
        var monto = $("#montodia").val();

        $("#total").val(numero * monto);

    });
})

function btnRentarClick(id) {

    var item = modelo.filter(x => x.Id == id)[0];

    $("#anovehiculo").val(item.Año);
    $("#marcavehiculo").val(item.MarcaDescripcion);
    $("#modelovehiculo").val(item.ModeloDescripcion);
    $("#montodia").val(item.Monto);
    $("#img-vehiculo").prop("src","data:image/jpg;base64," + item.ImagenPrincipal);


    $('#modal-renta').modal('show'); 
    


    
    
    


}