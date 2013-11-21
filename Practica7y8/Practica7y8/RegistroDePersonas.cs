using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace Practica7y8
{
	public class RegistroDePersonas : ConexionMySql
	{
		private	string nombre,email;
		private int id,telefono,codigo;
		
		public RegistroDePersonas (){}
		
		public void nuevoRegistro()
		{
			this.comenzarConexion();
			
			Console.WriteLine ("Ingrese los siguientes datos para el nuevo registro.");
			Console.WriteLine("Nombre: "); nombre = Console.ReadLine ();
			Console.WriteLine("Codigo: "); codigo = int.Parse(Console.ReadLine());
			Console.WriteLine("Telefono: "); telefono =int.Parse (Console.ReadLine ());
			Console.WriteLine("Email: "); email = Console.ReadLine ();
			
			string sql = "INSERT INTO `Persona` (`nombre`,`codigo`,`telefono`,`email`) " +
						 "VALUES ('"+ nombre +"','"+ codigo+"'," +"'"+ telefono +"','"+ email +"')";
			
			this.ejecutarComando(sql);		
			Console.WriteLine("Registro agregado con exito\n");
			this.cerrarConexion();			
		}
		
		public void editarRegistros()
		{
			this.comenzarConexion();
			
			Console.Write("Ingrese el ID del registro a modificar: ");
			id=int.Parse(Console.ReadLine());
			
			MySqlCommand micomando = new MySqlCommand(this.queryBuscar(),this.EscuelaConexion);
			MySqlDataReader myReader = micomando.ExecuteReader();
			
			if(myReader.Read())
			{
				Console.WriteLine("Nombre"); nombre = Console.ReadLine();	
				Console.WriteLine("Codigo"); codigo = int.Parse(Console.ReadLine());
				Console.WriteLine("Telefono"); telefono = int.Parse(Console.ReadLine());			
				Console.WriteLine("Email"); email = Console.ReadLine ();
				
				string sql = "UPDATE `Persona` SET `nombre`='" + nombre + "',`codigo`='" + codigo + "',`telefono`='"+ telefono +"'" +
							 ",`email`='"+ email +"' WHERE (`id`='" + id + "')";
				myReader.Close();
				myReader =null;
				micomando.Dispose();
				micomando=null;
				
				this.ejecutarComando(sql);
				Console.WriteLine("Registro con ID "+id+" modificado con EXITO");
				
			}	
			else 
			Console.WriteLine("ID "+ id +" NO EXISTE");
		}
		
		public void eliminarRegistro()
		{
		this.comenzarConexion();
	
			Console.Write("ID del registro a eliminar: ");
			id=int.Parse(Console.ReadLine ());
			
			MySqlCommand micomando = new MySqlCommand(this.queryBuscar(),this.EscuelaConexion);
			MySqlDataReader myReader = micomando.ExecuteReader();
		
			if(myReader.Read ())
			{			
				string sql = "DELETE  FROM `Persona` WHERE id="+id;
				
				myReader.Close();
				myReader =null;
				micomando.Dispose();
				micomando=null;	
				
				this.ejecutarComando(sql);
				Console.WriteLine("SE ELIMINO EL ID "+id+" CON EXITO");
			
			}
			else
			Console.WriteLine ("ID "+id+" NO EXISTE");	
		
		this.cerrarConexion();	
		}
		
		public void mostrarRegistros()
		{
		   this.comenzarConexion();
			
			MySqlCommand micomando = new MySqlCommand(this.querySelect(),EscuelaConexion);
			MySqlDataReader myReader = micomando.ExecuteReader();
			
			while(myReader.Read())
			{
				id = int.Parse(myReader["id"].ToString());
				nombre = myReader["nombre"].ToString();
				codigo = int.Parse(myReader["codigo"].ToString());
				telefono = int.Parse(myReader["telefono"].ToString());
				email = myReader["email"].ToString();
			
				Console.WriteLine (" ID:" + id +"\n Nombre:" + nombre + "\n Codigo:" + codigo +
				                   "\n Telefono:" + telefono + "\n Email:" + email);
				Console.WriteLine ("--------------------------");
			}
			myReader.Close();
			myReader =null;
			micomando.Dispose();
			micomando=null;
		    this.cerrarConexion();		
		}
		
		private int ejecutarComando(string sql)
		{
			MySqlCommand micomando = new MySqlCommand(sql,this.EscuelaConexion);
			int afectadas = micomando.ExecuteNonQuery();	
			micomando.Dispose();
			micomando = null;
			return afectadas;
		}
	
		private string querySelect() 
		{
			return "SELECT *" + "FROM Persona";
		}

		private string queryBuscar()
		{
			return "SELECT id FROM Persona WHERE id="+id;
		}
		
	}
}

