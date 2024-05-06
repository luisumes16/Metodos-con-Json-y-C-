using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MetodosconJSONC_
{
    internal class BaseDatos<Personas>
    {
        public List<Personas> lista = new List<Personas>();

        public string ruta;
        public BaseDatos(string ruta)
        {
            if (!File.Exists(ruta))
            {
                File.Create(ruta).Close();
            }
            this.ruta = ruta;
        }
        public void Guardar()
        {
            
            string json = JsonConvert.SerializeObject(lista);
            File.WriteAllText(ruta, json);
        }
        public void Leer()
        {
            try
            {
                string json = System.IO.File.ReadAllText(ruta);
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Personas>>(json);

            }catch (Exception ex) { }
        }
        public void Insertar(Personas nuevo)
        {
            lista.Add(nuevo);
            Guardar();
        }

    }
}
