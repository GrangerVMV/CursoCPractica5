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
            Console.WriteLine(numeroAleatorio);
            do
            {
                numIntentos++;
                try
                {
                    numeroElegido = int.Parse(Console.ReadLine());
                }
                /*catch (FormatException ex) // Primer ejemplo: Excepción de formato
                //El objetivo de Try catch es capturar las excepciones y que el programa no caiga
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

                catch (Exception e) when (e.GetType() != typeof(FormatException))
                {
                    Console.WriteLine("Se ha producido un error indeterminado en el valor introducido. Se tomará como valor introducido el 0");
                    numeroElegido = 0;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Has introducido un valor de texto. Se tomará como valor introducido el 0");
                    numeroElegido = 0;
                }

                if (numeroAleatorio > numeroElegido) Console.WriteLine("Vuelve a intentarlo, el número es mayor que el que has elegido");
                else if (numeroAleatorio < numeroElegido) Console.WriteLine("Vuelve a intentarlo, el número es menor que el que has elegido");
            } while (numeroElegido != numeroAleatorio);
            Console.WriteLine($"Enhorabuena, el número secreto era el {numeroAleatorio} y has acertado en {numIntentos} intentos");

            /*//Sexto ejemplo: Uso checked para control de desbordamiento y subdesbordamiento
            //Normalmente (a menos que se configure en Opciones Avanzadas) C# no chequea los errores de desbordamiento y subdesbordamiento -> No lanza excepción
            //Usando checked si lanza dichas excepciones

            checked
            {
                int numero = int.MaxValue;
                int resultado = numero + 50;
                Console.WriteLine(resultado);
            }
            

            //Septimo ejemplo: Otra sintaxis de checked para control de desbordamiento y subdesbordamiento
            // Si tenemos configurado el chequeo en opciones avanzadas pero no lo queremos aplicar podemos usar unchecked con la misma estructura
            // checked y unchecked funcionan solo para tipos int y long
            int numero = int.MaxValue;
            int resultado = checked(numero + 50); 
            Console.WriteLine(resultado);*/

            //Octavo ejemplo: Lanzamiento de excepciones con throw
            //Creamos una excepción para un valor fuera de rango
            //Explorar en internet las bibliotecas de clases dentro de los distintos workspace de .Net Framework
            //Consultamos las clases existentes dentro del workspace System
            //Utilizamos la clase ArgumentOutOfRangeException para lanzar una excepción en nuestro programa
            //Después usamos un Try-Catch para capturar la excepción

            Console.WriteLine("Por favor introduce un número de mes");
            int numeroDeMes = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(NombreDeMes(numeroDeMes));
            }catch (Exception e) 
            {
                Console.WriteLine("Mensaje de la excepción: " + e.Message);
            }
            Console.WriteLine("Aquí continuaría la ejecución del resto del programa");

            //Noveno ejemplo: Uso de bloque finally para el código que debe ejecutarse siempre
            // En este ejemplo vamos a acceder al archivo "ejemplofinally.txt" que está dentro de la carpeta de la práctica 5
            // Para ejecutar en otro PC cambiar los parámetros de la ruta
            //La idea del bloque finally es que haya excepción o no la haya el programa cierre siempre la connexión al archivo

            System.IO.StreamReader archivo = null;
            try 
            {
                string linea;
                int contador = 0;
                string path = @"C:\Users\vmarchena.AYESA.000\source\repos\CursoCSharp\CursoCPractica5\ejemplofinally.txt";
                // string path = @"C:\Users\vmarchena.AYESA.000\source\repos\CursoCSharp\CursoCPractica5\ejemplofinallytttt.txt"; // Si ponemos la ruta mal entra en el bloque try-catch
                archivo = new System.IO.StreamReader(path);
                while ((linea = archivo.ReadLine())!= null)
                {
                    Console.WriteLine(linea);
                    contador++;
                }
            }catch (Exception e) 
            {
                Console.WriteLine("Error con la lectura del archivo");
            }
            finally 
            {
                if (archivo != null) archivo.Close();
                Console.WriteLine("Conexión con el archivo cerrada");
            }


        }
        public static string NombreDeMes (int mes) 
        {
            switch (mes) 
            {
                case 1: 
                    return "Enero";
                case 2:
                    return "Febrero";
                case 3:
                    return "Marzo";
                case 4:
                    return "Abril";
                case 5:
                    return "Mayo";
                case 6:
                    return "Junio";
                case 7:
                    return "Julio";
                case 8:
                    return "Agosto";
                case 9:
                    return "Septiembre";
                case 10:
                    return "Octubre";
                case 11:
                    return "Noviembre";
                case 12:
                    return "Diciembre";
                default:
                    //return "Mes introducido no válido";
                    throw new ArgumentOutOfRangeException(); // En lugar de devolver un mensaje lanzamos una excepción

                    
            }
        }
    }
}
