using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Clases;

namespace Datos
{
    public class Consultas
    {
        private Conexion conexion = new Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        /*public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Select * from Productos";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }*/
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select Productos.id as Id, Productos.Nombre,Sectores.nombre as Sector,Productos.precio as Precio,Productos.stock as Stock from Productos " +
            "inner join Sectores on "+
            "Sectores.id = Productos.idSector;";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(Producto unProducto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insert into Productos (Nombre,idSector,precio,stock) values ('"+unProducto.Nombre+"',"+unProducto.IdSector+","+unProducto.Precio+","+unProducto.Stock+");";
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        
        public void Editar(Producto unProducto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "update Productos " +
                "set Nombre = '" + unProducto.Nombre + "'," +
                "idSector = " + unProducto.IdSector + "," + 
                "precio = " + unProducto.Precio + "," + 
                "stock = " + unProducto.Stock +
                " where id = " + unProducto.Id;

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(Producto unProducto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "delete from Productos where id="+unProducto.Id;
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
