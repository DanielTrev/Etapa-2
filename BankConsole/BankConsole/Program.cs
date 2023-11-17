using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

class Program
{
    static List<Usuario> usuarios = new List<Usuario>();

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
                    Console.WriteLine("\t-------------------------------------------------------------------------------------");
                    Console.WriteLine("        -----                                                                           -----");
                    Console.WriteLine("\t---                                  Opción no válida. Inténtalo de nuevo.                            ---");
                    Console.WriteLine("        -----                                                                           -----");
                    Console.WriteLine("\t-------------------------------------------------------------------------------------");
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

        // Validar el ID
        int id;
        do
        {
            Console.WriteLine("\t-------------------------------------------------------------------------------------");
            Console.WriteLine("        -----                                                                           -----");
            Console.Write("        ---                           Ingrese el ID (entero positivo):                    ---");
        } while (!int.TryParse(Console.ReadLine(), out id) || id <= 0);

        // Validar si el ID ya existe
        if (usuarios.Exists(u => u.Id == id))
        {
            Console.WriteLine("\t-------------------------------------------------------------------------------------");
            Console.WriteLine("        -----                                                                           -----");
            Console.WriteLine("        ---                           El ID ya existe. Inténtalo de nuevo.                       ---");
            Console.WriteLine("        -----                                                                           -----");
            Console.WriteLine("\t-------------------------------------------------------------------------------------");
            Console.ReadLine();
            return;
        }

        // Validar el email con expresión regular
        string email;
        do
        {
            Console.WriteLine("\t-------------------------------------------------------------------------------------");
            Console.WriteLine("        -----                                                                           -----");
            Console.Write("        ---                          Ingrese el correo electrónico:                       ---");
            email = Console.ReadLine();
        } while (!EsEmailValido(email));

        // Validar el saldo (balance)
        decimal saldo;
        do
        {
            Console.Write("        ---                          Ingrese el saldo (decimal positivo):                 ---");
        } while (!decimal.TryParse(Console.ReadLine(), out saldo) || saldo < 0);

        // Validar si es cliente o empleado
        string tipoUsuario;
        do
        {
            Console.WriteLine("\t-------------------------------------------------------------------------------------");
            Console.WriteLine("        -----                                                                           -----");
            Console.Write("        ---                           ¿Es Cliente (c) o Empleado (e)?                       ---");
            tipoUsuario = Console.ReadLine().ToLower();
        } while (tipoUsuario != "c" && tipoUsuario != "e");

        // Agregar el nuevo usuario a la lista
        usuarios.Add(new Usuario { Nombre = nuevoUsuario, Id = id, Email = email, Saldo = saldo, TipoUsuario = tipoUsuario });

        Console.WriteLine("\t-------------------------------------------------------------------------------------");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine($"\t---                        Usuario: '{nuevoUsuario}' creado exitosamente.                 ---");
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("\t-------------------------------------------------------------------------------------");

        
        Console.ReadLine();
        Console.WriteLine("\t-------------------------------------------------------------------------------------");
        Console.WriteLine("       -----                                                                         -----\n");
        Console.WriteLine("       ---                      Presiona cualquier tecla para continuar                ---");
        Console.WriteLine("       -----                                                                         -----\n");
        Console.WriteLine("       -----------------------------------------------------------------------------------");
    }

    static void EliminarUsuario()
    {
        Console.WriteLine("\t-------------------------------------------------------------------------------------");
        Console.WriteLine("        -----                                                                           -----");
        Console.Write("\t---                   Ingrese el ID de usuario a eliminar:                                  ---");

        // Validar el ID
        int idEliminar;
        do
        {
            
            Console.Write("---                   Ingrese el ID (entero positivo):                                    ---");

        } while (!int.TryParse(Console.ReadLine(), out idEliminar) || idEliminar <= 0);

        // Validar si el ID existe
        var usuarioEliminar = usuarios.Find(u => u.Id == idEliminar);
        if (usuarioEliminar == null)
        {
            Console.WriteLine("\t---                  El ID no existe. Inténtalo de nuevo.               ---");
            Console.WriteLine("-----                                                                           -----");
            Console.WriteLine("\t-------------------------------------------------------------------------------------");
            Console.ReadLine();
            return;
        }

        usuarios.Remove(usuarioEliminar);

        
        Console.WriteLine($"\t----                 Usuario '{usuarioEliminar.Nombre}' eliminado exitosamente.              ----");
        Console.WriteLine("\t-------------------------------------------------------------------------------------");
        Console.WriteLine("       -----                                                                         -----\n");
        Console.WriteLine("       ---                      Presiona cualquier tecla para continuar                ---");
        Console.WriteLine("       -----                                                                         -----\n");
        Console.WriteLine("       -----------------------------------------------------------------------------------");
        Console.ReadLine();
        Thread.Sleep(3500);
        Console.WriteLine("        -----                                                                           -----\n");
        Console.WriteLine("        ---                          Espere en lo que se procesa la accion...             ---");
        Console.WriteLine("        ---        Se retornara al inicio de las opciones que tenga un buen dia           ---");
        Console.WriteLine("        -----                                          :)                               -----\n");
        Console.WriteLine("        -------------------------------------------------------------------------------------");
    }

    static bool EsEmailValido(string email)
    {
        // Utilizar una expresión regular para validar el formato del correo electrónico
        Console.WriteLine("        -----                                                                           -----");
        string patronEmail = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        Console.WriteLine("        -----                                                                           -----");
        Console.WriteLine("        -------------------------------------------------------------------------------------");
        Regex regex = new Regex(patronEmail);
        return regex.IsMatch(email);
    }
}

class Usuario
{
    public string Nombre { get; set; }
    public int Id { get; set; }
    public string Email { get; set; }
    public decimal Saldo { get; set; }
    public string TipoUsuario { get; set; }
}
