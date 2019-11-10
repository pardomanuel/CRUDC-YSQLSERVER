using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Producto
    {
        /*
          VARIABLES
        */
        int id;
        string nombre;
        int idSector;
        decimal precio;
        int stock;
        
        /*
          CONSTRUCTORES
        */
        public Producto()
        {

        }
        public Producto(string nombre, int idSector, decimal precio, int stock)
        {
            this.nombre = nombre;
            this.idSector = idSector;
            this.precio = precio;
            this.stock = stock;
        }
        public Producto(int id, string nombre, int idSector, decimal precio, int stock)
        {
            this.id = id;
            this.nombre = nombre;
            this.idSector = idSector;
            this.precio = precio;
            this.stock = stock;
        }

        /*
          PROPIEDADES
        */
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Nombre 
        {
            get { return this.nombre; }
            set { this.nombre = value; } 
        }
        public int IdSector
        {
            get { return this.idSector; }
            set { this.idSector = value; }
        }
        public decimal Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        public int Stock
        {
            get { return this.stock; }
            set { this.stock = value; }
        }
    }
}
  