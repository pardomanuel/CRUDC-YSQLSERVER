using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Datos;
using Clases;

namespace Negocio
{
    public class CN_Productos
    {
        private Consultas objConexion = new Consultas();

        public DataTable MostrarProductos()
        {
            DataTable tabla = new DataTable();
            tabla = objConexion.Mostrar();
            return tabla;
        }
        public void InsertarProductos(string nombre, string idSector, string precio, string stock)
        {
            Producto unProducto = new Producto(nombre, Convert.ToInt32(idSector), Convert.ToDecimal(precio), Convert.ToInt32(stock));
            objConexion.Insertar(unProducto);
        }
        
        public void EditarProducto(string nombre, string idSector, string precio, string stock, string id)
        {
            Producto unProducto = new Producto(Convert.ToInt32(id),nombre, Convert.ToInt32(idSector), Convert.ToDecimal(precio), Convert.ToInt32(stock));
            objConexion.Editar(unProducto);
        }

        public void EliminarProducto(string id)
        {
            Producto unProducto = new Producto();
            unProducto.Id = Convert.ToInt32(id);
            objConexion.Eliminar(unProducto);
        }
    }
}
