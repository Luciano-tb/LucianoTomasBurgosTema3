using System;

namespace PrismaRectangular
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la longitud del prisma: ");
            double longitud = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el ancho del prisma: ");
            double ancho = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese la altura del prisma: ");
            double altura = Convert.ToDouble(Console.ReadLine());

            double volumen = longitud * ancho * altura;

            double area = 2 * (longitud * ancho + longitud * altura + ancho * altura);

            double diagonal = Math.Sqrt(Math.Pow(longitud, 2) + Math.Pow(ancho, 2) + Math.Pow(altura, 2));

            Console.WriteLine("\nResultados:");
            Console.WriteLine($"Volumen del prisma: {volumen}");
            Console.WriteLine($"Área del prisma: {area}");
            Console.WriteLine($"Diagonal del prisma: {diagonal}");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
