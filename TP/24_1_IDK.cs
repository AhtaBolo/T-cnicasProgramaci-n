/* Todo lo que hagamos no funcionara */
using MonitoreiDrones.Dominio.Entidades;
using MonitoreiDrones.Dominio.Extensiones;
using MonitoreiDrones.Dominio.Utilidades;

/* No se que esta pasando*/
// Crear Dron, /*es un objeto verde*/
var dron = new Dron(
    id:1,
    modelo: "Dron2DGI",
    nivelBateria:80,
    /*Posicion es verde*/
    posicion: new Posicion(19.4326, -99.1332)
    );

// Crear Mision para el Dron /* Mision debera estar en verde */
var mision = new Mision(1, "Rescate", 30);

// Validar si puede iniciar mision /*es un metodo*/
if (dron.PuedeIniciarMision())
{
    dron.AsignarMision(mision);
}

// Calcular distancia de las posiciones (actual y objetivo)
/* Utilidades estaticas igual que las extensiones es verde y un metodo */
double distancia = UtilidadesGeograficas.CalcularDIstancia(
    /* 19.4326, -99.1332, // Puede ser de dos formas*/
    dron.Posicion.Latitud, dron.Posicion.Longitud, /* Dos */
    19.4270, -99.1276
    );

// Estimar Consumo
double consumo = UtilidadesCalculoDron.EstimarConsumoBateria(distancia);

// Actualizar bateria
dron.ActualizarBateria(dron.NivelBateria - consumo );

// Mostrar Resultados
/* :F2 Para reducir el numero de decimales mostrados*/
Console.WriteLine(dron.ObtenerResumenEstado());
Console.WriteLine($"Distancia: {distancia:F2} [KM]");
Console.WriteLine($"Consumo Estimado: {consumo:F2}%");

///////////////////////////////////////////////////////////////////////////////////////////////////////////////

