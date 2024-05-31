

using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;


Persona persona = new Persona();
PersonaNegocio personaNegocio = new PersonaNegocio();
List<Persona> lista = new List<Persona>();

         lista=personaNegocio.listarPersona();

Console.WriteLine(lista[0].Nombre);




