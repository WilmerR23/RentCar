//$('#anovehiculo').mask('0000');
var table;
var obj = {};
var callback = null;

$(document).ready(function() {
   table = $('#tbvehiculos').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "columns": [
            {
                "data": "TipoVehiculoDescripcion", "title": "Tipo de vehiculo"
            },
            {
                "data": "MarcaDescripcion", "title": "Marca"
            },
            {
                "data": "ModeloDescripcion", "title": "Modelo"
            },
            {
                "data": "Año", "title": "Año"
            },
            {
                "data": "Placa", "title": "Placa"
            },
            {
                "data": "Monto", "title": "Monto por dia"
            },
            {
                "data": "FechaCreacion", "title": "Fecha de creación", "render": function (data) {
                    moment.locale('es');
                    return moment(data).format('LL');
                    //return data;
                }
            },
            {
                "mRender": function (data, type, row) {
                    return `<a href="#" onclick="verImagenes(${row.Id})">Ver imagenes</a>`;
                }, 'sortable': false, "title": 'Imagenes'
            },
            {
                "mRender": function (data, type, row) {
                    return `<button onclick="editVehiculo(${row.Id})" class="btn btn-warning">Editar</a> <button style="margin-left: 5px;" onclick="deleteVehiculo(${row.Id})" class="btn btn-danger">Borrar</a>`;
                }, 'sortable': false, "title": 'Acciones'
            }
        ],
        "columnDefs": [
            { "className": "dt-center", "targets": "_all" }
        ],
        ajax: {
            "url": `${origen}api/Vehiculo/ObtenerVehiculos`,
            "type": "GET",
            "dataType": "json",
            "contentType": "application/json",
            "dataSrc": '',
            "error": function (jqXHR, statusCode, error) {
                console.error(error);
                $('#tbvehiculos').DataTable().clear().draw();
            }
        }
    });
    
    $("#btnguardar").on("click", function() {
        var tipoVehiculoId = $("#tipovehiculo").val();
        var marcaId = $("#marca").val();
        var modeloId = $("#modelo").val();
        var año = $("#anovehiculo").val();
        var placa = $("#placa").val();
        var monto = $("#monto").val();
        var files = $('#imagenes')[0].files;

        if (tipoVehiculoId != 0 && marcaId != 0 && modeloId != 0 && año != "" && placa != "" && monto > 0) {

            obj.Placa = placa;
            obj.TipoVehiculoId = tipoVehiculoId;
            obj.MarcaId = marcaId;
            obj.ModeloId = modeloId;
            obj.Año = año;
            obj.Monto = monto;

            var url = `${origen}api/Vehiculo/GuardarVehiculo`;

            var ajaxRequest = $.ajax({
                type: "POST",
                url: url,
                contentType: "application/json",
                data: JSON.stringify(obj)
            });

            ajaxRequest.done(function (resultado) {
                if (resultado) {

                    var fileData = new FormData();

                    for (var i = 0; i < files.length; i++) {
                        fileData.append("fileInput", files[i]);
                    }

                    var ajaxImgRequest = $.ajax({
                        type: "POST",
                        url: `${origen}Vehiculo/UploadFiles?vehiculoId=${resultado}`,
                        contentType: false,
                        processData: false,
                        data: fileData
                    });

                    ajaxImgRequest.done(function (data) {
                        clearValues();
                        table.ajax.reload();
                        swal({
                            //title: 'Enhorabuena',
                            text: "Su información ha sido registrada",
                            type: 'success',
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

                    
                }
                else {

                }
                //swal('Atención', resultado.Mensaje, 'warning')
            });

            ajaxRequest.fail(function (error) {
                //Loading.finalizar();
                //if (error.status === statusCode.unAuthorized) {
                //    mostrarMensajeSesionExpirada();
                //} else {
                //    $('#btnEnviar').prop('disabled', false)
                //    processResponse(error)
                //}
            })
        } else {
            swal({
                //title: 'Enhorabuena',
                text: "Debe llenar todos los campos",
                type: 'error',
                allowOutsideClick: false,
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Ok'
            }).then(function (result) {
                //if (result.value) {
                //    window.location.href = origen + 'Home';
                //}
            })
        }
    });


    $("#marca").on("change", function () {
        changeMarca(callback);
    });

    
});

function changeMarca(callback) {
        var idMarca = $("#marca").val();
        var url = `Vehiculo/ObtenerModelos?idMarca=${idMarca}`;
        $.get(origen + url, function (data) {
            //objVM.servicios(data);
            var modelos = $("#modelo");
            modelos.empty();
            modelos.append($("<option selected disabled/>").val('-99').text('Seleccione modelo'));
            $.each(data, function () {
                modelos.append($("<option />").val(this.Id).text(this.Nombre));
            });
            modelos.prop('disabled', false);

        }, 'json')
            .fail(function () {
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

            })
            .always(function () {
                // $("#modalLoading").modal("hide");

                if (callback != null)
                    callback();
            });
}

function clearValues() {
    $("#tipovehiculo").val(0);
    $("#marca").val(0);
    $("#modelo").val(0);
    $("#anovehiculo").val("");
    $("#monto").val("");
    $("#placa").val("");
    $("#imagenes").val('');
    $("#btnguardar").html("Guardar");
    $("#btnguardar").addClass("btn-success");
    $("#btnguardar").removeClass("btn-primary");
    obj = {};
}

function verImagenes(id) {

    $('.gallery-item').remove();
    $(".gallery-controls").html("");

    $('#myModal').modal('show'); 
    var data = table.rows().data();

    $.get(`${origen}api/Vehiculo/ObtenerImagenes/${id}`, function (data) {

        for (v = 0; v < data.length; v++) {
            var item = data[v];
            var img = $('<img class="gallery-item">');
            img.attr('src', `data:image/jpg;base64,${item.ContenidoBase64}`);
            img.appendTo('.gallery-container');
        }

        if (data.length < 5) {

            var count = 5 - data.length;

            for (v = 0; v < count; v++) {
                var img = $('<img class="gallery-item">');
                img.attr('src', `https://fakeimg.pl/300/`);
                img.appendTo('.gallery-container');
            }

        }

        const galleryItems = document.querySelectorAll('.gallery-item');
        const exampleCarousel = new Carousel(galleryContainer, galleryItems, galleryControls);

        exampleCarousel.setControls();
        exampleCarousel.setNav();
        exampleCarousel.setInitialState();
        exampleCarousel.useControls();

    }, 'json')
        .fail(function () {
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
        })
        .always(function () {
            // $("#modalLoading").modal("hide");

            if (callback != null)
                callback();
        });

}

function editVehiculo(id) {
    var data = table.rows().data();
    var item = data.filter(x => x.Id == id)[0];

    obj.Id = id;
    $("#tipovehiculo").val(item.TipoVehiculoId);
    callback = () => { $("#modelo").val(item.ModeloId); };
    $("#marca").val(item.MarcaId).change();
    $("#anovehiculo").val(item.Año);
    $("#placa").val(item.Placa);
    $("#monto").val(item.Monto);
    $("#btnguardar").html("Actualizar");
    $("#btnguardar").removeClass("btn-success");
    $("#btnguardar").addClass("btn-primary");
}

function deleteVehiculo(id) {
    $.get(`${origen}api/Vehiculo/BorrarVehiculo/${id}`, function (data) {
        
        swal({
            //title: 'Enhorabuena',
            text: "Vehiculo borrado satisfactoriamente.",
            type: 'success',
            allowOutsideClick: false,
            showCancelButton: false,
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'Ok'
        }).then(function (result) {
            //if (result.value) {
            //    window.location.href = origen + 'Home';
            //}
        });

    }, 'json')
        .fail(function () {
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
        })
        .always(function () {
            // $("#modalLoading").modal("hide");

            if (callback != null)
                callback();
        });
}


//swal({
//    title: "Campo vacio",
//    text: "Favor de completar todos los campos",
//    icon: "warning",
//    button: "aceptar",
//});
//		} else {
//    swal({
//        title: "¡Exito!",
//        text: "Datos guardados correctamente",
//        icon: "success",
//        button: false,
//        timer: 1800,
//    });