using System;

//classification, lecteur, accesseur, mutateur, constructeur
class SphèreCéleste
{
    private int pourcentageDEau;
    private int diamètre;
    private double gravité;
    private bool atmosphèreRespirable;

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
        diamètre = unDiamètre;
    }
    public void SetGravité(double uneGravité)
    {
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
}
class PlanetOOP
{
    static void Main()
    {
        Planète unePlanète = new Planète(5, 75, 23215494, 9.85, "Oui");
        Console.WriteLine(unePlanète.GetGravité());
        Console.WriteLine(unePlanète.GetAtmosphèreRespirable());

        unePlanète.SetNbrDeLunes(7);
        Console.WriteLine(unePlanète.GetNbrDeLunes());

        SphèreCéleste unCéleste = new SphèreCéleste(56, 1435435, 15, "Non");
        Console.WriteLine(unCéleste.GetGravité());
        Console.WriteLine(unCéleste.GetAtmosphèreRespirable());
        Console.ReadKey();
    }
}