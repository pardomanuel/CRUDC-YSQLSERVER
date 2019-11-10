using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class Sector
    {
        /*
            VARIABLES
        */
        int id;
        string nombre;

        /*
            CONSTRUNCTORES
        */
        public Sector()
        {

        }
        public Sector(string nombre)
        {
            this.nombre = nombre;
        }


        /*
            PROPIEDADES
        */
        public string Nombre 
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
    }
}
