using System;
using System.Collections.Generic;

namespace A133590.Ejercicio46
{
    class Program
    {
        static int validarEntero(string ingreso)
        {
            int resultado;

            bool exito = Int32.TryParse(ingreso, out resultado);

            while (!exito || resultado < 0)
            {
                Console.Write("Ingreso incorrecto, por favor intente de nuevo: ");
                exito = Int32.TryParse(Console.ReadLine(), out resultado);
            }

            return resultado;
        }
        static double validarDouble(string ingreso)
        {
            double resultado;

            bool exito = Double.TryParse(ingreso, out resultado);

            while (!exito || resultado < 0)
            {
                Console.Write("Ingreso incorrecto, por favor intente de nuevo: ");
                exito = Double.TryParse(Console.ReadLine(), out resultado);
            }

            return resultado;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 46");
            Dictionary<int, double> productos = new Dictionary<int, double>();
            while (true)
            {
                Console.Write("Por favor, ingrese un código de producto (ingrese 0 para terminar): ");
                int registro = validarEntero(Console.ReadLine());
                if (registro == 0) break;
                if (productos.ContainsKey(registro))
                {
                    Console.WriteLine("Producto ya existente, ingrese otro.");
                    continue;
                }

                Console.Write("Ahora ingrese el precio: ");
                double precio = validarDouble(Console.ReadLine());


                productos.Add(registro, precio);
                Console.WriteLine($"Código de producto: '{registro}' asociado a precio '{precio}' exitosamente.");
            }


            Console.Clear();
            double suma = 0;
            while (true)
            {
                Console.Write("Ingrese un código de producto: ");
                int registro = validarEntero(Console.ReadLine());
                if (registro == 0) break;
                if (productos.ContainsKey(registro))
                {
                    double precio = productos.GetValueOrDefault(registro);
                    Console.WriteLine($"Producto encontrado, precio: {precio}");
                    suma += precio;
                }
                else
                {
                    Console.WriteLine($"Producto no existente.");
                }

            }
            Console.WriteLine($"Precio total de productos ingresados: {suma}");
            Console.WriteLine("Presione cualquier tecla para continuar..");
            Console.ReadKey();

        }
    }
}
