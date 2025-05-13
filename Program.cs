using System.ComponentModel;
using System.Diagnostics;

namespace practicaBBDDyC;

class Program
{
    static void Main(string[] args)
    {
        ConexionSQL conexion = new ConexionSQL();
        bool salir = false;

        Console.WriteLine("\n--- MENÚ DE OPCIONES ---");
        Console.WriteLine("1. Consultar todos los cursos");
        Console.WriteLine("2. Insertar un nuevo curso");
        Console.WriteLine("3. Modificar un curso existente");
        Console.WriteLine("4. Eliminar un curso");
        Console.WriteLine("5. Salir");
        int opcion = Validador.LeerEntero("Opcion: ");

        switch (opcion)
        {
            case 1:
                List<Cursos> lista = conexion.Consultar();
                int i = 0;
                while (i < lista.Count)
                {
                    Cursos c = lista[i];
                    Console.WriteLine($"{c.Id} {c.NombreCurso} {c.FamiliaProfesional} {c.Horas}");
                    i++;
                }
                break;

            case 2:
                int IdIn=Validador.LeerEntero("Id: ");
                if (conexion.Existe(IdIn))
                {
                    Console.WriteLine("❌ Ya existe ese Id");
                    break;
                }
                Cursos nuevo = new Cursos
                {
                    Id=IdIn,
                    NombreCurso=Validador.LeerTexto("Nombre: "),
                    FamiliaProfesional=Validador.LeerTexto("Familia profesional: "),
                    Horas=Validador.LeerEntero("Horas: ")
                };
                if (conexion.Insertar(nuevo))
                Console.WriteLine("✅ Registro insertado correctamente.");
                break; 

            case 3:
                int idMod = Validador.LeerEntero("ID a modificar: ");
                if (!conexion.Existe(idMod))
                {
                    Console.WriteLine("❌ No existe ese Id");
                    break;
                }

                Cursos mod = new Cursos 
                {
                    Id=idMod,
                    NombreCurso=Validador.LeerTexto("Nuevo Nombre: "),
                    FamiliaProfesional=Validador.LeerTexto("Nueva Familia profesional: "),
                    Horas=Validador.LeerEntero("Nuevas Horas: ")
                };

                if (conexion.Modificar(mod))
                Console.WriteLine("✅ Registro modificado correctamente.");
                break;

            case 4:
                
                int idDel= Validador.LeerEntero("ID a eliminar: ");
                if (!conexion.Existe(idDel))
                {
                    Console.WriteLine("❌ No existe ese Id");
                    break;
                }
                if (conexion.Eliminar(idDel))
                Console.WriteLine("Registro eliminado correctamente.");
                break;
                

            case 5:
                salir = true;
                Console.WriteLine("Saliendo del programa.");
                break;

            default:
            Console.WriteLine("Opcion no valida.");
            break;
        }
    }
}
