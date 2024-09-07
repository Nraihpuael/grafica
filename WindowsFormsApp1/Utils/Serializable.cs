using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Estructura;

namespace WindowsFormsApp1.Utils
{
    class Serializable
    {
        public Dictionary<string, Dictionary<string, object>> Objetos { get; set; }

        public Serializable()
        {
            Objetos = new Dictionary<string, Dictionary<string, object>>();
        }

        public void SerializarEscenario(string filePath)
        {
            string serializedEscenario = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, serializedEscenario);
        }

        public void ConvertirDesdeEscenario(Escenario escenario)
        {
            foreach (var objeto in escenario.objetos)
            {
                var serializableObjeto = new Dictionary<string, object>
                {
                    { "Centro", new List<float> { objeto.Value.Centro.X, objeto.Value.Centro.Y, objeto.Value.Centro.Z } },
                    { "Partes", new Dictionary<string, List<object>>() }
                };

                foreach (var parte in objeto.Value.partes)
                {
                    var serializableParte = new Dictionary<string, object>
                    {
                        { "Centro", new List<float> { parte.Value.Centro.X, parte.Value.Centro.Y, parte.Value.Centro.Z } },
                        { "Poligonos", new List<object>() }
                    };

                    foreach (var poligono in parte.Value.poligonos)
                    {
                        var serializablePoligono = new Dictionary<string, object>
                        {
                            { "Nombre", poligono.Key },
                            { "Vertices", poligono.Value.Vertices }
                        };

                        ((List<object>)serializableParte["Poligonos"]).Add(serializablePoligono);
                    }

                    ((Dictionary<string, List<object>>)serializableObjeto["Partes"]).Add(parte.Key, new List<object> { serializableParte });
                }

                Objetos.Add(objeto.Key, serializableObjeto);
            }
        }

        public static Serializable DeserializeEscenario(string filePath)
        {
            string serializedEscenario = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Serializable>(serializedEscenario);
        }

        public Escenario ConvertirAEscenario()
        {
            var escenario = new Escenario();

            foreach (var kvpObjeto in Objetos)
            {
                var nombreObjeto = kvpObjeto.Key;

                var datosObjeto = kvpObjeto.Value;
                var centroObjetoJArray = (Newtonsoft.Json.Linq.JArray)datosObjeto["Centro"];
                var centroObjeto = centroObjetoJArray.Select(x => (float)x).ToArray();

                var objeto = new Objeto(new Vector3(centroObjeto[0], centroObjeto[1], centroObjeto[2]));
                var partesJObject = (Newtonsoft.Json.Linq.JObject)datosObjeto["Partes"];
                var partes = partesJObject.ToObject<Dictionary<string, Newtonsoft.Json.Linq.JArray>>();
                foreach (var kvpParte in partes)
                {
                    var nombreParte = kvpParte.Key;
                    var datosParteJArray = kvpParte.Value;

                    if (datosParteJArray.Count > 0)
                    {
                        var datosParteJObject = (Newtonsoft.Json.Linq.JObject)datosParteJArray[0];

                        // Convertir el JArray a un arreglo de float
                        var centroParteJArray = (Newtonsoft.Json.Linq.JArray)datosParteJObject["Centro"];
                        var centroParte = centroParteJArray.Select(x => (float)x).ToArray();
                        var parte = new Parte(new Vector3(centroParte[0], centroParte[1], centroParte[2]));


                        // Convertir el JArray de poligonos a una lista de JObject
                        var poligonosJArray = (Newtonsoft.Json.Linq.JArray)datosParteJObject["Poligonos"];
                        var poligonos = poligonosJArray.ToObject<List<Newtonsoft.Json.Linq.JObject>>();

                        foreach (var datosPoligono in poligonos)
                        {
                            var nombrePoligono = (string)datosPoligono["Nombre"];
                            var verticesJArray = (Newtonsoft.Json.Linq.JArray)datosPoligono["Vertices"];
                            var verticesArray = verticesJArray.Select(x => (float)x).ToArray();

                            var Poligono = new Poligono(verticesArray);
                            parte.AgregarPoligono(nombrePoligono, Poligono);
                        }
                        objeto.AgregarParte(nombreParte, parte);
                    }
                }

                escenario.AgregarObjeto(nombreObjeto, objeto);
            }

            return escenario;
        }

    }
}
