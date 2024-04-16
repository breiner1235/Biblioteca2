using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca2
{
    internal class Libro
    {
        public string Titulo { get; }
        public string Autor { get; }
        public int AnioPublicacion { get; }
        public bool Prestado { get; private set; }

        public Libro(string titulo, string autor, int anioPublicacion)
        {
            Titulo = titulo;
            Autor = autor;
            AnioPublicacion = anioPublicacion;
            Prestado = false;
        }

        public void Prestar()
        {
            Prestado = true;
        }

        public void Devolver()
        {
            Prestado = false;
        }
    }
}
