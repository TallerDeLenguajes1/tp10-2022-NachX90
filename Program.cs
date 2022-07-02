using System.Net;
using System.Text.Json;

//Saludo
Funcion.GenerarTitulo("BIENVENIDO");
Console.WriteLine("Consumo de una web API de \"Age Of Empires\".");

//Datos para la conexión a la API
var Url = @"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
var Conexion = (HttpWebRequest)WebRequest.Create(Url);
Conexion.Method = "GET";
Conexion.ContentType = "application/json";
Conexion.Accept = "application/json";

//Conexión a la API
try
{
    using (WebResponse Respuesta = Conexion.GetResponse())
    {
        using (Stream SR = Respuesta.GetResponseStream())
        {
            if (SR == null) return;
            using (StreamReader SRObjeto = new StreamReader(SR))
            {
                string RespuestaObjeto = SRObjeto.ReadToEnd();
                CivilizationsList ListaDeCivilizaciones = JsonSerializer.Deserialize<CivilizationsList>(RespuestaObjeto); //Instanciación de la clase! Este es un objeto, no la lista en si.
                //Mostrando listado de civilizaciones
                Console.WriteLine("\nListado de civilizaciones:");
                Console.WriteLine("\tID\tNombre");
                foreach (Civilization Civilizacion in ListaDeCivilizaciones.Civilizations)
                {
                    Console.WriteLine($"\t{Civilizacion.Id}\t{Civilizacion.Name}");
                }
                //Mostrar 1 civilizacion completa
                Console.Write("\nIngrese el ID de la civilización a mostrar: ");
                int index = Convert.ToInt32(Console.ReadLine())-1;
                ListaDeCivilizaciones.Civilizations.ElementAt(index).PrintCivilization();


                //Uso de la otra api
                var Url2 = ListaDeCivilizaciones.Civilizations.ElementAt(index).UniqueTech.ElementAt(0);
                var Conexion2 = (HttpWebRequest)WebRequest.Create(Url2);
                Conexion2.Method = "GET";
                Conexion2.ContentType = "application/json";
                Conexion2.Accept = "application/json";
                try
                {
                    using (WebResponse Respuesta2 = Conexion2.GetResponse())
                    {
                        using (Stream SR2 = Respuesta2.GetResponseStream())
                        {
                            if (SR2 == null) return;
                            using (StreamReader SRObjeto2 = new StreamReader(SR2))
                            {
                                string RespuestaObjeto2 = SRObjeto2.ReadToEnd();
                                var TecnologiasUnicas = JsonSerializer.Deserialize<Technology>(RespuestaObjeto2);
                                //Mostrar
                                Console.WriteLine("\nInformación de la primera tecnología única:");
                                TecnologiasUnicas.PrintTechnology();
                            }
                        }
                    }
                }
                catch (WebException Excepcion)
                {
                    Console.WriteLine("No se pudo acceder a la API.");
                }
            }
        }
    }
}
catch (WebException Excepcion)
{
    Console.WriteLine("No se pudo acceder a la API.");
}