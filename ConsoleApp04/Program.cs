using Entidades;
using System;

namespace Entidades
{
    public struct Prisma
    {
        public double Longitud { get; private set; }
        public double Ancho { get; private set; }
        public double Altura { get; private set; }

        public Prisma(double longitud, double ancho, double altura)
        {
            Longitud = longitud;
            Ancho = ancho;
            Altura = altura;
        }

        public void AsignarValores(double longitud, double ancho, double altura)
        {
            Longitud = longitud;
            Ancho = ancho;
            Altura = altura;
        }

        public double ObtenerVolumen()
        {
            return Longitud * Ancho * Altura;
        }

        public double ObtenerArea()
        {
            return 2 * (Longitud * Ancho + Longitud * Altura + Ancho * Altura);
        }

        public double ObtenerDiagonal()
        {
            return Math.Sqrt(Longitud * Longitud + Ancho * Ancho + Altura * Altura);
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Longitud: {Longitud}, Ancho: {Ancho}, Altura: {Altura}");
            Console.WriteLine($"Volumen: {ObtenerVolumen()}, Área: {ObtenerArea()}, Diagonal: {ObtenerDiagonal()}");
        }
    }
}

namespace AdministradorDePrismas
{
    class Program
    {
        static void Main(string[] args)
        {
            const int tamañoArray = 5; 
            Prisma[] prismas = new Prisma[tamañoArray];
            int cantidadPrismas = 0;

            while (true)
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Ingresar un prisma al array");
                Console.WriteLine("2. Verificar si el array está lleno o vacío");
                Console.WriteLine("3. Mostrar datos de los prismas");
                Console.WriteLine("4. Modificar un prisma en el array");
                Console.WriteLine("5. Mostrar estadísticas de los prismas");
                Console.WriteLine("6. Mostrar prismas con volumen inferior al promedio");
                Console.WriteLine("7. Salir");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        if (cantidadPrismas < tamañoArray)
                        {
                            Console.Write("Ingrese la longitud del prisma: ");
                            double longitud = double.Parse(Console.ReadLine());

                            Console.Write("Ingrese el ancho del prisma: ");
                            double ancho = double.Parse(Console.ReadLine());

                            Console.Write("Ingrese la altura del prisma: ");
                            double altura = double.Parse(Console.ReadLine());

                            prismas[cantidadPrismas] = new Prisma(longitud, ancho, altura);
                            cantidadPrismas++;
                        }
                        else
                        {
                            Console.WriteLine("El array está lleno.");
                        }
                        break;

                    case 2:
                        if (cantidadPrismas == 0)
                            Console.WriteLine("El array está vacío.");
                        else if (cantidadPrismas == tamañoArray)
                            Console.WriteLine("El array está lleno.");
                        else
                            Console.WriteLine($"El array tiene {cantidadPrismas} prismas.");
                        break;

                    case 3:
                        for (int i = 0; i < cantidadPrismas; i++)
                        {
                            Console.WriteLine($"Prisma {i + 1}:");
                            prismas[i].MostrarDatos();
                        }
                        break;

                    case 4:
                        Console.Write("Ingrese el índice del prisma a modificar (1 a {0}): ", cantidadPrismas);
                        int indice = int.Parse(Console.ReadLine()) - 1;

                        if (indice >= 0 && indice < cantidadPrismas)
                        {
                            Console.Write("Ingrese la nueva longitud del prisma: ");
                            double nuevaLongitud = double.Parse(Console.ReadLine());

                            Console.Write("Ingrese el nuevo ancho del prisma: ");
                            double nuevoAncho = double.Parse(Console.ReadLine());

                            Console.Write("Ingrese la nueva altura del prisma: ");
                            double nuevaAltura = double.Parse(Console.ReadLine());

                            prismas[indice].AsignarValores(nuevaLongitud, nuevoAncho, nuevaAltura);
                            Console.WriteLine("Prisma modificado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Índice inválido.");
                        }
                        break;

                    case 5:
                        if (cantidadPrismas > 0)
                        {
                            var prismaMayorVolumen = prismas.Max(p => p.ObtenerVolumen());
                            var prismaMenorVolumen = prismas.Min(p => p.ObtenerVolumen());
                            var promedioVolumenes = prismas.Average(p => p.ObtenerVolumen());

                            Console.WriteLine($"Prisma de mayor volumen: {prismaMayorVolumen}");
                            Console.WriteLine($"Prisma de menor volumen: {prismaMenorVolumen}");
                            Console.WriteLine($"Promedio de volúmenes: {promedioVolumenes}");
                        }
                        else
                        {
                            Console.WriteLine("No hay prismas en el array.");
                        }
                        break;

                    case 6:
                        if (cantidadPrismas > 0)
                        {
                            var promedioVolumen = prismas.Average(p => p.ObtenerVolumen());

                            Console.WriteLine("Prismas con volumen inferior al promedio:");
                            foreach (var prisma in prismas.Where(p => p.ObtenerVolumen() < promedioVolumen))
                            {
                                prisma.MostrarDatos();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay prismas en el array.");
                        }
                        break;

                    case 7:
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
