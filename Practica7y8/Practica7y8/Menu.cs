using System;

namespace Practica7y8
{
	public class Menu
	{
		public Menu (){}
		
		RegistroDePersonas persona = new RegistroDePersonas();
		int opciondemenu,opcionseguir, salir=0;
		
	   public void menuPrograma()
	   {

		  do
		  {	
			 Console.WriteLine("**Menu**");
			 Console.WriteLine("1-Insertar nuevo registro.");
			 Console.WriteLine("2-Editar registro.");
			 Console.WriteLine("3-Eliminar registro.");
			 Console.WriteLine("4-Mostrar todos.");
			 Console.WriteLine("5-Salir\n");
			 Console.Write("Accion a realizar: "); 
				
		     opciondemenu =int.Parse(Console.ReadLine());
			 switch(opciondemenu)
			 {
				case 1: persona.nuevoRegistro(); break;
				case 2:	persona.editarRegistros(); break;
				case 3: persona.eliminarRegistro(); break;
				case 4:	persona.mostrarRegistros(); break;	
				case 5:	Console.WriteLine("\n**Ejecucion Finalizada**");
						Environment.Exit(salir); break;				
			 }
			
			 Console.Write("1-Regresar al menu\n"+"2-SALIR\n"+"opcion: ");
			 opcionseguir = int.Parse(Console.ReadLine());
			 Console.Clear();
			
		  }while(opcionseguir==1);
			
		  {
			Console.WriteLine ("\n**Ejecucion Finalizada**");
			Console.Out.Close();
		  }	
	   }	
		
	}
}

