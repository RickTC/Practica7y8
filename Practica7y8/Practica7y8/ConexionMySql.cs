using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace Practica7y8
{
	public class ConexionMySql
	{
		protected MySqlConnection EscuelaConexion;
		public ConexionMySql (){}
		
		protected void comenzarConexion()
		{
			string conectar = 
			"Server=localhost;"+
			"Database=BasedePrueba;"+
			"User ID=root;"+		
			"Password=maromero2594;"+
			"Pooling=false;";
			
		this.EscuelaConexion= new MySqlConnection (conectar);
		this.EscuelaConexion.Open();		
		
		}
		
		protected void cerrarConexion()
		{
			this.EscuelaConexion.Close();
			this.EscuelaConexion = null;
		}
	}
}

