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
			
			string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");
			string rutaReportes = Path.Combine(rutaRaiz, "Reportes");

			if(!Directory.Exists(rutaReportes)){
				Directory.CreateDirectory(rutaReportes);
				Console.WriteLine("Creando Directorio de Reportes Correctamente");
			}
			
			string archivoTexto = Path.Combine(rutaReportes, "notas.txt");
			Console.WriteLine(archivoTexto);
			using(StreamWriter sw = new StreamWriter(archivoTexto,true))
			{
				sw.WriteLine(string.Format("ESTUDIANTE: {0} | NOTA: {1} | FECHA: {2: yyyy-MM-dd HH:mm}", nombre, nota,DateTime.Now));
			}
			
			// DESAFIO 1
			
			string datos = "usuario;clave123";
			
			string[] partesClave = datos.Split(';');
			string clave = partesClave[1];
			
			if (clave.Contains("123"))
			{
				using (StreamWriter sw = new StreamWriter("Seguridad.txt", true))
				{
					sw.WriteLine("Aviso: Clave Débil");
				}
				Console.WriteLine("Aviso: Guardado en Seguridad.txt");
			}
			
			else
			{
				Console.WriteLine("La Clave es Segura");
			}
			
			// DESAFIO 2
			
			string origen = "avatar.jpg";
			string destino = "respaldo.jpg";
			
			try
			{
				using (FileStream fsOrigen = new FileStream(origen, FileMode.Open, FileAccess.Read))
					using (FileStream fsDestino = new FileStream(destino, FileMode.Create, FileAccess.Write))
				{
					byte[] buffer = new byte[1024];
					int bytesLeidos;
					
					Console.WriteLine("Iniciado Copiado de Imágenes...");
					
					while ((bytesLeidos = fsOrigen.Read(buffer, 0, buffer.Length)) > 0)
					{
						fsDestino.Write(buffer, 0, bytesLeidos);
					}
				}
				Console.WriteLine("Imagen Clonada Exitosamente como respaldo.jpg");
			}
			
			catch (FileNotFoundException)
			{
				Console.WriteLine("ERROR: No se encontró el archivo avatar.jpg");
			}
			
			catch (Exception ex)
			{
				Console.WriteLine("Ocurrió un Error Inesperado" + ex.Message);
				
				
				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
			}
		}
	}
}