
$(document).ready(function () {
    GetAll();
    GetAllEstados();
});

function GetAll() {
    $.ajax({        
        type: 'GET',
        url: 'http://localhost:5236/api/Empleado/GetAll',
        dataType: 'json',
        success: function (result) {
            $('#tblEmpleados tbody').empty();
            $.each(result.objects, function (i, empleado) {
                var filas =
                    "<tr>" + "<td class='text-center'>" +
                    "<a class='btn btn-warning' href='#' onclick='GetById(" + empleado.idEmpleado + ")'>" +
                    "<i class='fa-regular fa-pen-to-square'></i></a></td>" +
                    "<td id='IdEmpleado' class='visually-hidden'>" + empleado.idEmpleado + "</td>" + 
                    "<td id='NumeroNomina' class='text-center'>" + empleado.numeroNomina + "</td>" + 
                    "<td id='Nombre' class='text-center'>" + empleado.nombre + "</td>" +
                    "<td id='ApPaterno' class='text-center'>" + empleado.apellidoPaterno + "</td>" +
                    "<td id='ApMaterno' class='text-center'>" + empleado.apellidoMaterno + "</td>" +
                    "<td id='IdEstado' class='visually-hidden'>" + empleado.estado.idEstado + "</td>" +
                    "<td id='EstadoNombre' class='text-center'>" + empleado.estado.nombre + "</td>" +
                    "<td class='text-center'><a class='btn btn-danger' href='#' onclick='Delete(" + empleado.idEmpleado + ")'>" +
                    "<i class='fa-solid fa-trash'></i></td>"
                    + '</tr>';
                $("#tblEmpleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta:' + result.errorMessage);
        }
    });
};

function Add(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5236/api/Empleado/Add',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify({
            NumeroNomina: empleado.NumeroNomina,
            Nombre: empleado.Nombre,
            ApellidoPaterno: empleado.ApellidoPaterno,
            ApellidoMaterno: empleado.ApellidoMaterno,
            Estado: {
                IdEstado: empleado.Estado.IdEstado
            }          
        }),
        success: function (result) {
            $('#myModal').modal('show');
            $('#ModalForm').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error al agregar el registro.');
        }
    });
};

function Update(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5236/api/Empleado/Update',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify({
            IdEmpleado: empleado.IdEmpleado,
            Nombre: empleado.Nombre,
            ApellidoPaterno: empleado.ApellidoPaterno,
            ApellidoMaterno: empleado.ApellidoMaterno,
            Estado: {
                IdEstado: empleado.Estado.IdEstado
            }
        }),
        success: function (result) {
            GetAll();
            $('#myModal').modal('show');
            $('#ModalForm').modal('hide');
            
        },
        error: function (result) {
            alert('Error al agregar el registro.');
        }
    });
};

function Enviar() {
    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApPaterno').val(),
        ApellidoMaterno: $('#txtApMaterno').val(),
        Estado: {
            IdEstado: $('#ddlEstado').val()
        }
    }

    if (empleado.IdEmpleado == '') {
        Add(empleado);
    }
    else {
        Update(empleado);
    }
}

function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5236/api/Empleado/GetById?idEmpleado=' + IdEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.object.idEmpleado);
            $('#txtNumeroNomina').val(result.object.numeroNomina);
            $('#txtNombre').val(result.object.nombre);
            $('#txtApPaterno').val(result.object.apellidoPaterno);
            $('#txtApMaterno').val(result.object.apellidoMaterno);
            $('#ddlEstado').val(result.object.estado.idEstado);

            $('#ModalForm').modal('show');
        },
        error: function () {
            alert('Error al mostrar la información');
        }
    });
}

function GetAllEstados() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5236/api/Estado/GetAll',
        success: function (result) {
            $('#ddlEstado').append('<option value="0">' + 'Seleccione un estado' + '</option>');
            $.each(result.objects, function (i, estado) {
                $("#ddlEstado").append('<option value="' +
                    estado.idEstado + '">' +
                    estado.nombre + '</option>');
            });
        }
    });
}

function Delete(IdEmpleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5236/api/Empleado/Delete?idEmpleado=' + IdEmpleado,
        success: function () {
            alert('El registro se eliminó exitosamente');
            GetAll();
        },
        error: function () {
            alert('Error al eliminar el registro.');
        }
    })
}

function MostrarModal() {
    $('#ModalForm').modal('show');
    LimpiarModal();
}

function LimpiarModal() {
    $('#txtIdEmpleado').val('');
    $('#txtNumeroNomina').val('');
    $('#txtNombre').val('');
    $('#txtApPaterno').val('');
    $('#txtApMaterno').val('');
    $('#ddlEstado').val(0);
}