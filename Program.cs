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
                }

                //Tercer ejemplo: Excepción genérica y mensaje descriptivo.
                //No es aconsejable usar este tipo de excepción (demasiado genérica). La expresión entre paréntesis puede omitirse pero no se aconseja
                //La herencia sería Exception -> SystemException -> FormatException, OverflowException, etc
                catch(Exception ex3)
                {
                    Console.WriteLine("El valor introducido no es válido. El programa tomará como valor el 0");
                    Console.WriteLine(ex3.Message);
                    numeroElegido = 0;
                }

                //Cuarto ejemplo: Incluir excepción específica y excepción genérica.
                //Aquí para que no de error siempre debemos colocar la excepción específica antes que la genérica
                catch(FormatException e)
                {
                    Console.WriteLine("Has introducido un valor de texto. Se tomará como valor introducido el 0");
                    numeroElegido = 0;
                }catch (Exception e)
                {
                    Console.WriteLine("Ha habido un error indeterminado en el valor que has introducido. Se tomará como valor introducido el 0");
                    numeroElegido = 0;
                }*/

                //Quinto ejemplo: Excepción con filtro
                //Se usa para tratar de forma diferente una excepción en concreto

                catch(Exception e) when (e.GetType()!= typeof(FormatException))
                {
                    Console.WriteLine("Se ha producido un error indeterminado en el valor introducido. Se tomará como valor introducido el 0");
                    numeroElegido = 0;
                }catch(FormatException)
                {
                    Console.WriteLine("Has introducido un valor de texto. Se tomará como valor introducido el 0");
                    numeroElegido = 0;
                }



                if (numeroAleatorio > numeroElegido) Console.WriteLine("Vuelve a intentarlo, el número es mayor que el que has elegido");
                else if (numeroAleatorio < numeroElegido) Console.WriteLine("Vuelve a intentarlo, el número es menor que el que has elegido");
            } while (numeroElegido != numeroAleatorio);
            Console.WriteLine($"Enhorabuena, el número secreto era el {numeroAleatorio} y has acertado en {numIntentos} intentos");
        }
    }
}
