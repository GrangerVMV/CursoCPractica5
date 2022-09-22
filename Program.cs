using System;

namespace CursoCPractica5_Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Random referenciaARandom = new Random();
            int numeroAleatorio = referenciaARandom.Next(0, 100);
            Console.WriteLine("Por favor, elige un número del 0-100");
            int numeroElegido;
            int numIntentos = 0;
            do
            {
                numIntentos++;
                try
                {
                    numeroElegido = int.Parse(Console.ReadLine());
                }
                /*catch (FormatException ex) // Primer ejemplo: Excepción de formato
                {
                    Console.WriteLine("El valor introducido no es válido. El programa tomará como valor el 0");
                    numeroElegido = 0;
                }
                catch (OverflowException ex2) //Segundo ejemplo: Excepción de desbordamiento. Añadimos otro catch para tratar el error del desbordamiento
                {
                    Console.WriteLine("El valor introducido es demasiado alto. El programa tomará como valor el 0");
                    numeroElegido = 0;
                }*/
                //Tercer ejemplo: Excepción genérica y mensaje descriptivo.
                //No es aconsejable usar este tipo de excepción (demasiado genérica). La expresión entre paréntesis puede omitirse pero no se aconseja
                //La herencia sería Exception -> SystemException -> FormatException, OverflowException, etc
                catch(Exception ex3)
                {
                    Console.WriteLine("El valor introducido no es válido. El programa tomará como valor el 0");
                    Console.WriteLine(ex3.Message);
                    numeroElegido = 0;
                }
                if (numeroAleatorio > numeroElegido) Console.WriteLine("Vuelve a intentarlo, el número es mayor que el que has elegido");
                else if (numeroAleatorio < numeroElegido) Console.WriteLine("Vuelve a intentarlo, el número es menor que el que has elegido");
            } while (numeroElegido != numeroAleatorio);
            Console.WriteLine($"Enhorabuena, el número secreto era el {numeroAleatorio} y has acertado en {numIntentos} intentos");
        }
    }
}
