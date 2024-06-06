using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public int ID { get; set; }
        public int IDPersona { get; set; }
        public byte[] Archivo { get; set; } // Representación de los datos binarios de la imagen
    }
}