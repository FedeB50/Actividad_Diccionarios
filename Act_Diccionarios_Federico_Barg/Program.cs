namespace Act_Diccionarios_Federico_Barg;

class Program
{
    
    static void Main(string[] args)
    {
        Dictionary<string, int> materiales = new Dictionary<string, int>()
    {{ "Madera", 10 },{ "Hierro", 10 },{ "Soga", 10 }};
        Menu(materiales);
    }
    static void Menu(Dictionary <string, int> materiales)
    {
        int opcion=-1;
        do {
            Console.WriteLine("1. Ver inventario\n2. Actualizar stock\n3. Consumir recurso\n4. Consultar recurso\n5. Salir");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    VerInventario(materiales);
                    break;
                case 2:
                    ActualizarStock(materiales);
                    
                    break;
                case 3:
                    ConsumirRecurso(materiales);
                    break;
                case 4:
                    ConsultarRecurso(materiales);
                    break;
                case 5:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        } while (opcion != 5);
        
    }
    static void VerInventario(Dictionary <string, int> materiales)
    {
        Console.WriteLine("Inventario:");
        foreach (var item in materiales)
        {
            Console.WriteLine($"Recurso: {item.Key}. \nStock: {item.Value}");
        }
    }
    static void ActualizarStock(Dictionary <string, int> materiales)
    {
        Console.WriteLine("Ingrese el recurso a actualizar:");
        string recurso = Console.ReadLine();
        if (materiales.ContainsKey(recurso))
        {
            Console.WriteLine("Ingrese la cantidad a agregar:");
            int cantidad = int.Parse(Console.ReadLine());
            materiales[recurso] += cantidad;
            Console.WriteLine($"Stock actualizado. Stock de {recurso}: {materiales[recurso]}");
        }
        else
        {
            materiales.Add(recurso, 0);
            Console.WriteLine("Recurso no encontrado. Se ha agregó al inventario con stock 0.");
        }
    }
    static void ConsumirRecurso(Dictionary <string, int> materiales)
    {
        Console.WriteLine("Ingrese el recurso que desee consumir:");
        string recurso = Console.ReadLine();
        if (materiales.ContainsKey(recurso))
        {
            Console.WriteLine("Ingrese la cantidad a consumir:");
            int cantidad = int.Parse(Console.ReadLine());
            if (materiales[recurso] >= cantidad)
            {
                materiales[recurso] -= cantidad;
                Console.WriteLine($"Recurso consumido. Stock de {recurso}: {materiales[recurso]}");
                if (materiales[recurso] < 5)
                {
                    Console.WriteLine($"ALERTA: REABASTECER {recurso}");
                }
            }
            else
            {
                Console.WriteLine("No hay suficiente stock para consumir esa cantidad.");
            }
        }
        else
        {
            Console.WriteLine("Recurso no encontrado.");
        }
    }
    static void ConsultarRecurso(Dictionary <string, int> materiales)
    {
        Console.WriteLine("Ingrese el recurso a consultar.");
        string recurso = Console.ReadLine();
        if (materiales.ContainsKey(recurso))
        {
            Console.WriteLine($"Stock de {recurso}: {materiales[recurso]}");
        }
        else
        {
            Console.WriteLine("Recurso no encontrado.");
        }
    }
}
