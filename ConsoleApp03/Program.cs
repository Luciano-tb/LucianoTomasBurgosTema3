using Entidades;

namespace Entidades
{
    public struct PrismaRectangular
    {
        private double longitud;
        private double ancho;
        private double altura;

        public double Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }

        public double Ancho
        {
            get { return ancho; }
            set { ancho = value; }
        }

        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }

        public double Volumen()
        {
            return longitud * ancho * altura;
        }

        public double Area()
        {
            return 2 * (longitud * ancho + longitud * altura + ancho * altura);
        }

        public double Diagonal()
        {
            return Math.Sqrt(longitud * longitud + ancho * ancho + altura * altura);
        }

        public bool ValidarDimensiones()
        {
            return longitud > 0 && ancho > 0 && altura > 0;
        }
    }
}

namespace ProgramaPrisma
{
    class Program
    {
        static void Main(string[] args)
        {
            PrismaRectangular prisma = new PrismaRectangular();

            Console.WriteLine("Ingrese la longitud del prisma:");
            prisma.Longitud = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese el ancho del prisma:");
            prisma.Ancho = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese la altura del prisma:");
            prisma.Altura = Convert.ToDouble(Console.ReadLine());

            if (prisma.ValidarDimensiones())
            {
                Console.WriteLine($"Volumen del prisma: {prisma.Volumen()}");
                Console.WriteLine($"Área del prisma: {prisma.Area()}");
                Console.WriteLine($"Diagonal del prisma: {prisma.Diagonal()}");
            }
            else
            {
                Console.WriteLine("Las dimensiones ingresadas no son válidas. Todas deben ser mayores a cero.");
            }

            Console.ReadKey();
        }
    }
}
