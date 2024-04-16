using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca2
{
    public partial class Form1 : Form
    {
        private List<Libro> libros;
        public Form1()
        {
            InitializeComponent();
            libros = new List<Libro>();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;
            int anioPublicacion = Convert.ToInt32(txtPublicacion.Text);

            Libro libro = new Libro(titulo, autor, anioPublicacion);
            libros.Add(libro);

            ActualizarListaLibros();
            LimpiarCampos();
        }

        private void btnPrestar_Click(object sender, EventArgs e)
        {
            if (lstLibros.SelectedIndex != -1)
            {
                Libro libro = libros[lstLibros.SelectedIndex];
                if (!libro.Prestado)
                {
                    libro.Prestar();
                    ActualizarListaLibros();
                }
                else
                {
                    MessageBox.Show("El libro ya ha sido prestado.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un libro de la lista.");
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (lstLibros.SelectedIndex != -1)
            {
                Libro libro = libros[lstLibros.SelectedIndex];
                if (libro.Prestado)
                {
                    libro.Devolver();
                    ActualizarListaLibros();
                }
                else
                {
                    MessageBox.Show("El libro no está prestado.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un libro de la lista.");
            }
        }

        private void ActualizarListaLibros()
        {
            lstLibros.Items.Clear();
            foreach (Libro libro in libros)
            {
                string estado = libro.Prestado ? "Prestado" : "Disponible";
                lstLibros.Items.Add($"{libro.Titulo} - {libro.Autor} ({libro.AnioPublicacion}) [{estado}]");
            }
        }

        private void LimpiarCampos()
        {
            txtTitulo.Text = string.Empty;
            txtAutor.Text = string.Empty;
            txtPublicacion.Text = string.Empty;
        }
    }
}
