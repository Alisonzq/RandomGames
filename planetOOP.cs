using System;

//classification, lecteur, accesseur, mutateur, constructeur
class SphèreCéleste
{
    private int pourcentageDEau;
    protected int diamètre;
    private double gravité;
    private bool atmosphèreRespirable;

    protected static void VerifExceptionsPossiblesNonPositives(double valeurDuParametre, string descriptionDuParametre)
    {
        if (valeurDuParametre == 0)
        {
            throw new ArgumentException("Argument invalide car nul!" + descriptionDuParametre);
        }
        else if (valeurDuParametre < 0)
            throw new ArgumentException("Argument invalide car negatif!" + descriptionDuParametre);
    }

    public int GetPourcentageDEau()
    {
        return pourcentageDEau;
    }
    public int GetDiamètre()
    {
        return diamètre;
    }
    public double GetGravité()
    {
        return gravité;
    }
    public string GetAtmosphèreRespirable()
    {
        return atmosphèreRespirable ? "Oui" : "Non";
    }

    public void SetPourcentageDEau(int unPourcentage)
    {
        pourcentageDEau = unPourcentage;
    }
    public void SetDiamètre(int unDiamètre)
    {
        VerifExceptionsPossiblesNonPositives(unDiamètre, "Mesure de diamètre.");
        diamètre = unDiamètre;
    }
    public void SetGravité(double uneGravité)
    {
        VerifExceptionsPossiblesNonPositives(uneGravité, "Mesure de gravité.");
        gravité = uneGravité;
    }
    public void SetAtmosphèreRespirable(string uneAtmosphère)
    {
        atmosphèreRespirable = uneAtmosphère == "Oui";
    }
    public SphèreCéleste(int lePourcentage, int leDiamètre, double laGravité, string lAtmosphère)
    {
        SetPourcentageDEau(lePourcentage);
        SetDiamètre(leDiamètre);
        SetGravité(laGravité);
        SetAtmosphèreRespirable(lAtmosphère);
    }
}

class Planète : SphèreCéleste
{
    private int nbrDeLunes;

    public int GetNbrDeLunes()
    {
        return nbrDeLunes;
    }
    public void SetNbrDeLunes(int unNbrDeLunes)
    {
        nbrDeLunes = unNbrDeLunes;
    }

    public Planète(int leNbrDeLunes, int prc, int dia, double grav, string atm) : base(prc, dia, grav, atm)
    {
        SetNbrDeLunes(leNbrDeLunes);
    }
    //planète sans eau
    public Planète(int leNbrDeLunes, int dia, double grav, string atm) : this(leNbrDeLunes, 0, dia, grav, atm) { }
    //planète sans eau ni atmosphère
    public Planète(int leNbrDeLunes, int dia, double grav) : this(leNbrDeLunes, dia, grav, "Non") { } 

    public double Aire()
    {
        return Math.PI * Math.Pow(diamètre / 2, 2);
    }

    public double Circonférence()
    {
        return Math.PI * (diamètre / 2) * 2;
    }
}
class PlanetOOP
{
    static void Main()
    {
        Console.WriteLine("La Terre");
        Planète terre = new Planète(1, 72, 12742, 9.81, "Oui");
        Console.WriteLine(terre.GetGravité());
        Console.WriteLine(terre.GetAtmosphèreRespirable());

        Console.WriteLine("Un céleste");
        SphèreCéleste unCéleste = new SphèreCéleste(56, 1435435, 15, "Non");
        Console.WriteLine(unCéleste.GetGravité());
        Console.WriteLine(unCéleste.GetAtmosphèreRespirable());

        unCéleste.SetGravité(7);
        Console.WriteLine(unCéleste.GetGravité());

        Console.WriteLine("Jupiter");
        Planète jupiter = new Planète(79, 139820, 24.79);
        Console.WriteLine(jupiter.GetGravité());
        Console.WriteLine(jupiter.GetDiamètre());
        Console.WriteLine(jupiter.GetNbrDeLunes());

        Console.WriteLine("L'aire de la Terre est {0} km²", terre.Aire());
        Console.WriteLine("La circonférence de Jupiter est {0} km²", jupiter.Circonférence());

        Console.ReadKey();
    }
}