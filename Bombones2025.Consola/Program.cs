using Bombones2025.Entidades;
using Bombones2025.Servicios;
public class Program
{
    private static void Main(string[] args)
    {
        string rutaPaises = "Paises.txt";
        string rutaFrutosSecos = "FrutosSecos.txt";
        var paisServicio = new PaisServicio(rutaPaises);
        var servicioFrutoSeco = new FrutoSecoServicio(rutaFrutosSecos);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\nMenú de opciones:");
            Console.WriteLine("1. Países");
            Console.WriteLine("2. Frutos Secos");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    MostrarListaPaises(paisServicio);
                    break;
                case "2":
                    MostrarListaFrutosSecos(servicioFrutoSeco);
                    break;
                case "3":
                    Console.WriteLine("Fin del programa");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }
    }
    private static void MostrarListaPaises(PaisServicio paisServicio)
    {
        Console.Clear();
        Console.WriteLine("\nLista de países:");
        List<Pais> paises = paisServicio.GetPaises();
        if (paises.Count == 0)
        {
            Console.WriteLine("No hay países disponibles.");
        }
        else
        {
            foreach (var pais in paises)
            {
                Console.WriteLine(pais);
            }
        }
        EsperaTecla("Presione Enter para continuar");
    }
    private static void EsperaTecla(string mensaje)
    {
        Console.WriteLine(mensaje);
        Console.ReadLine();
    }
    private static void MostrarListaFrutosSecos(FrutoSecoServicio servicioFrutoSeco)
    {
        Console.Clear();
        Console.WriteLine("\nLista de frutos secos:");

        List<FrutoSeco> frutosSecos = servicioFrutoSeco.GetLista();
        if (frutosSecos.Count == 0)
        {
            Console.WriteLine("No hay frutos secos disponibles.");
        }
        else
        {
            foreach (var frutoSeco in frutosSecos)
            {
                Console.WriteLine(frutoSeco);
            }
        }
        EsperaTecla("Presione Enter para continuar");
    }
}
