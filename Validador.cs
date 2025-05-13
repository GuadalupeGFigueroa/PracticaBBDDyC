namespace practicaBBDDyC;

public static class Validador
{
    public static int LeerEntero(string mensaje)
    {
        int valor;
        Console.Write(mensaje);
        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("❌ Valor no válido." + mensaje);
        }
        return valor;
    }
    public static string LeerTexto(string mensaje)
    {
        string? texto;
        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(texto));
        return texto;
    }
}