/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 17/04/2026
 * Hora: 10:56
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace TallerIujo01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("===Taller 01===");
			
			// 1. El dato del usuario
			
			string registroUsuario = "     ID_777;     JuanPerez;     EVALUACIÓN;     95     ";

			Console.WriteLine(registroUsuario);
			
			string registroLimpio = registroUsuario.Trim();
			Console.WriteLine(registroLimpio);
			
			string[] partes = registroLimpio.Split(';');
			string id = partes[0].Trim();
			string nombre = partes[1].Trim();
			string tarea = partes[2].Trim();
			string nota = partes[3].Trim();
			
			Console.WriteLine(string.Format("El ID es : {0} del usuario: {1} con la nota: {2}", id, nombre,nota));
			
			//Flujo de Archivos
			
			string rutaraiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");
			

			if(Directory.Exists(rutaraiz)){
				Directory.CreateDirectory("Reportes");
				Console.WriteLine("Creando Directorio Correctamente");
			
			}
			string archivoTexto = Path.Combine(rutaraiz, "notas.txt");
			
			Console.WriteLine(archivoTexto);
			
			using(StreamWriter sw = new StreamWriter(archivoTexto,true)){
			
				sw.WriteLine(string.Format("ID: {0} - NOTA: {1} - {yyyy-MM-dd HH:mm)}", id, nota, DataTime.Now() ));
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}