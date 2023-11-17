using System;
using System.Collections.Generic;

class Program
{
    static List<string> usuarios = new List<string>();

    static void Main()
    {
        MostrarEncabezado();

        while (true)
        {
            MostrarMenu();
            int eleccion = int.Parse(Console.ReadLine());

            switch (eleccion)
            {
                case 1:
                    CrearUsuario();
                    break;

                case 2:
                    EliminarUsuario();
                    break;

                case 3:
                    return;

                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }

            Console.Clear();
        }
    }

    static void MostrarEncabezado()
    {
        Console.WriteLine("\t-------------------------------------------------------------------------------------");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("\t---                                  <*(BankConsole)*>                            ---");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("\t-------------------------------------------------------------------------------------");
    }

    static void MostrarMenu()
    {
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("        ---                                1.Crear nuevo usuario                          ---");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("        -------------------------------------------------------------------------------------");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("        ---                           2.Eliminar un usuario existente                     ---");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("        -------------------------------------------------------------------------------------");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("        ---                                       3.Salir:                                ---");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("        -------------------------------------------------------------------------------------");
    }

    static void CrearUsuario()
    {
        Console.WriteLine("\t-------------------------------------------------------------------------------------");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("        ---                           Ingrese el nombre de usuario:                       ---");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("\t-------------------------------------------------------------------------------------");
        string nuevoUsuario = Console.ReadLine();

        if (!usuarios.Contains(nuevoUsuario))
        {
            usuarios.Add(nuevoUsuario);
            Console.WriteLine("\t-------------------------------------------------------------------------------------");
            Console.WriteLine("        -----                                                                           -----");
            Console.WriteLine($"\t----                 Usuario: '{nuevoUsuario}' creado exitosamente.             ----");
            Console.WriteLine("        -----                                                                           -----");
            Console.WriteLine("\t-------------------------------------------------------------------------------------");
        }
        else
        {
            Console.WriteLine("        -----                                                                           -----");
            Console.WriteLine($"\t----                 El usuario: '{nuevoUsuario}' ya existe. Inténtalo con otro nombre.             ----");
            Console.WriteLine("        -----                                                                           -----");
            Console.WriteLine("\t-------------------------------------------------------------------------------------");
        }

        Console.ReadLine(); 
        Console.WriteLine("       -----                                                                         -----\n");
        Console.WriteLine("       ---                      Presiona cualquier tecla para continuar              -----");
        Console.WriteLine("       -----                                                                         -----\n");
        Console.WriteLine("       -----------------------------------------------------------------------------------");
    }

    static void EliminarUsuario()
    {
        Console.WriteLine("        -----                                                                           -----");
        Console.Write("\t----                 Ingrese el nombre de usuario a eliminar:              ----");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("\t-------------------------------------------------------------------------------------");

        string usuarioEliminar = Console.ReadLine();

        if (usuarios.Contains(usuarioEliminar))
        {
            Console.WriteLine("        -----                                                                           -----");
            Console.WriteLine($"\t----                 Usuario '{usuarioEliminar}' eliminado exitosamente.              ----");
            Console.WriteLine("        -----                                                                           -----");
            Console.WriteLine("\t-------------------------------------------------------------------------------------");
            usuarios.Remove(usuarioEliminar);
            
        }
        else
        {
            Console.WriteLine("        -----                                                                           -----");
            Console.WriteLine($"\t----                 El usuario '{usuarioEliminar}' no existe. Verifica el nombre e intenta nuevamente.              ----");
            Console.WriteLine("        -----                                                                           -----");
            Console.WriteLine("\t-------------------------------------------------------------------------------------");
        }

                Console.WriteLine("       -----                                                                         -----\n");
                Console.WriteLine("       ---                      Presiona cualquier tecla para continuar              -----");
                Console.WriteLine("       -----                                                                         -----\n");
                Console.WriteLine("       -----------------------------------------------------------------------------------");
                Console.ReadLine(); 
        
    }
}
