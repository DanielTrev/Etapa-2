Console.WriteLine("\t-------------------------------------------------------------------------------------");
Console.WriteLine("\t---                                  <*(BankConsole)*>                            ---");
Console.WriteLine("\t-------------------------------------------------------------------------------------");


int M1;

while (true)
{
    Console.WriteLine("        -----                                                                           -----\n");
    Console.WriteLine("        ---                                1.Crear nuevo usuario                          ---\n");
    Console.WriteLine("        -----                                                                           -----\n");
    Console.WriteLine("        -------------------------------------------------------------------------------------");
    Console.WriteLine("        -----                                                                           -----\n");
    Console.WriteLine("        ---                           2.Eliminar un usuario existente                     ---\n");
    Console.WriteLine("        -----                                                                           -----\n");
    Console.WriteLine("        -------------------------------------------------------------------------------------");
    Console.WriteLine("        -----                                                                           -----\n");
    Console.WriteLine("        ---                                       3.Salir:                                ---\n");
    Console.WriteLine("        -----                                                                           -----\n");
    Console.WriteLine("        -------------------------------------------------------------------------------------\n");
    M1 = int.Parse(Console.ReadLine());
    

    switch (M1)
    {
        case 1:
           
        

            break;

        case 2:
           
            break;

        case 3:
        
            return 0;

    }
    Console.Clear();
}