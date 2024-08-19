using System;

class Prisma
{
    public double Largo { get; set; }
    public double Ancho { get; set; }
    public double Alto { get; set; }

    public Prisma(double largo, double ancho, double alto)
    {
        if (largo <= 0 || ancho <= 0 || alto <= 0)
        {
            throw new ArgumentException("Las dimensiones del prisma deben ser mayores a 0.");
        }

        Largo = largo;
        Ancho = ancho;
        Alto = alto;
    }

    public double CalcularVolumen()
    {
        return Largo * Ancho * Alto;
    }
}

class Program
{
    static void Main()
    {
        const int cantidadPrismas = 5;
        Prisma[] prismas = new Prisma[cantidadPrismas];
        double mayorVolumen = 0;
        int iteracionMayorVolumen = -1;
        double sumaVolumenes = 0;

        for (int i = 0; i < cantidadPrismas; i++)
        {
            Console.WriteLine($"Ingrese las dimensiones del prisma {i + 1}:");

            double largo, ancho, alto;

            while (true)
            {
                try
                {
                    Console.Write("Largo: ");
                    largo = double.Parse(Console.ReadLine());

                    Console.Write("Ancho: ");
                    ancho = double.Parse(Console.ReadLine());

                    Console.Write("Alto: ");
                    alto = double.Parse(Console.ReadLine());

                    prismas[i] = new Prisma(largo, ancho, alto);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}. Por favor, ingrese valores válidos.");
                }
            }

            double volumen = prismas[i].CalcularVolumen();
            sumaVolumenes += volumen;

            if (volumen > mayorVolumen)
            {
                mayorVolumen = volumen;
                iteracionMayorVolumen = i + 1;
            }
        }

        double promedioVolumenes = sumaVolumenes / cantidadPrismas;

        Console.WriteLine($"\nEl prisma con mayor volumen fue ingresado en la iteración {iteracionMayorVolumen} con un volumen de {mayorVolumen}.");
        Console.WriteLine($"El promedio de los volúmenes de los prismas ingresados es {promedioVolumenes}.");
    }
}
s