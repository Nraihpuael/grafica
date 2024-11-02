using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Animacion;
using WindowsFormsApp1.Estructura;

namespace WindowsFormsApp1.Utils
{
    class Serializable
    {
        
        public static void Serialize(Escenario escenario, string path)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(escenario, Formatting.Indented, settings);
            File.WriteAllText(path, json);
        }

        public static Escenario Deserialize(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };

                Escenario escenario = JsonConvert.DeserializeObject<Escenario>(json, settings);

                return escenario;
            }
            else
            {
                throw new FileNotFoundException($"El archivo en la ruta '{path}' no existe.");
            }
        }

        
        public static Libreto DeserializeA(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };

                Libreto libreto = JsonConvert.DeserializeObject<Libreto>(json, settings);

                return libreto;
            }
            else
            {
                throw new FileNotFoundException($"El archivo en la ruta '{path}' no existe.");
            }
        }

        public static void SerializeA(Libreto libreto, string path)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(libreto, Formatting.Indented, settings);
            File.WriteAllText(path, json);
        }
    }
}
