using System;

class Ref
{
    static double Taxes(ref double payedPrice)
    {
        const double TPS = 0.05;
        const double TVQ = 0.09975;
        double taxBeforeRounding = (TPS + TVQ) * payedPrice;
        double roundedTax = Math.Round(taxBeforeRounding, 2);
        payedPrice += roundedTax;
        return roundedTax;
    }

    static void RacinesQuadratiques(double a, double b, double c, out double r1, out double r2)
    {
        double racineCarrée = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
        r1 = (-b + racineCarrée) / (2 * a);
        r2 = (-b - racineCarrée) / (2 * a);
    }

    static void Main()
    {
        Console.WriteLine("TAXES : Establish cost to buy something");
        Console.WriteLine("Enter price of article: ");
        double articlePrice = Double.Parse(Console.ReadLine());
        double amountPayed = articlePrice;
        double taxAmount = Taxes(ref amountPayed);
        Console.WriteLine("Tax total is {0}, and total amount payed is {1}", taxAmount, amountPayed);


        Console.WriteLine("Racines quadratiques");
        Console.WriteLine("What's A:");
        double numA = Double.Parse(Console.ReadLine());
        Console.WriteLine("B:");
        double numB = Double.Parse(Console.ReadLine());
        Console.WriteLine("C:");
        double numC = Double.Parse(Console.ReadLine());
        double racine1, racine2;
        RacinesQuadratiques(numA, numB, numC, out racine1, out racine2);

        Console.WriteLine("Les deux racines sont{0} et {1}", racine1, racine2);
    }
}