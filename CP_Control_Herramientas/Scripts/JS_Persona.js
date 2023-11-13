//window.onload = function () {

//    alert("Inicio JS");

//    //Establecer la fecha del registro del colaborador
//    var date = new Date();
//    var mes = date.getUTCMonth() + 1;
//    $(".dtFechaRegPersona").val(date.getFullYear() + "-" + mes + "-" + date.getDate());
//}
//function CancelarRegPersona() {
//    alert("Cancelar registro");
//    $(".txtCedulaPersona").val("");
//    $(".txtNombrePersona").val("");
//    $(".txtApellido1Persona").val("");
//    $(".txtApellido2Persona").val("");
//    $(".slt_EstadoPersona").val("");
//}

//function LimpiarRegPersona() {
//    alert("Limpiar registro");
//    $(".txtCedulaPersona").val("");
//    $(".txtNombrePersona").val("");
//    $(".txtApellido1Persona").val("");
//    $(".txtApellido2Persona").val("");
//    $(".slt_EstadoPersona").val("");
//}

//function GuardarRegPersona() {

//    alert("Inicio el registro");

//    //Datos del formulario persona
//    var idPersona = $(".txtCedulaPersona").val();
//    var nombrePersona = $(".txtNombrePersona").val();
//    var apellido1 = $(".txtApellido1Persona").val();
//    var apellido2 = $(".txtApellido2Persona").val();
//    var fechaRegistro = $(".dtFechaRegPersona").val();
//    var estadoPersona = $(".slt_EstadoPersona").val();

//    var Persona = {
//        idPersona,
//        nombrePersona,
//        apellido1,
//        apellido2,
//        fechaRegistro,
//        estadoPersona
//    }

//    alert("Continuar registro" + estadoPersona);

//    //Enviar datos al controlador
//    jQuery.ajax({
//        url: '@Url.Action("GuardarUsuario", "Home")',
//        type: "POST",
//        data: JSON.stringify({ person: Persona }),
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {

//            alert("Continuar registro success");

//            if (data.resultado == 1) {
//                alert("Persona registrada");
//            } else {
//                alert("Error en el registro");
//            }
//        },
//        error: function (error) {

//            alert("Continuar registro error");
//            alert(error.Mensage);
//        },
//        beforedSend: function () {

//        }
//    });
//}