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
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}