using System;

class Fraction
{
    //Classification:
    private int numérateur;
    private int dénominateur;
    private int numFR;
    private int dénoFR;

    //Accesseurs-lecteurs
    public int GetNumérateur()
    {
        return numérateur;
    }
    public int GetDénominateur()
    {
        return dénominateur;
    }
    public int GetNumFR()
    {
        return numFR;
    }
    public int GetDénoFR()
    {
        return dénoFR;
    }

    //Accesseurs-mutateurs
    public void SetNumérateur(int unNum)
    {
        numérateur = unNum;
        Réduire();
    }

    public void SetDénominateur(int unDéno)
    {
        if (unDéno == 0)
            throw new ArgumentException("Le dénominateur ne peut être nul.");
        else
        {
            dénominateur = unDéno;
            Réduire();
        }
    }

    public bool EstNégative()
    {
        return numérateur < 0 ^ dénominateur < 0;
    }

    private void Réduire()
    {
        int numValAbs = Math.Abs(numérateur);
        int dénoValAbs = Math.Abs(dénominateur);

        if (numValAbs == dénoValAbs)
        {
            numFR = EstNégative() ? -1 : 1;
            dénoFR = 1;
        }
        else if (numValAbs == 0)
        {
            numFR = 0;
            dénoFR = 1;
        }
        else if (numValAbs == 1)
        {
            numFR = EstNégative() ? -1 : 1;
            dénoFR = dénoValAbs;
        }
        else
        {
            //Euclide
            int facteur1 = numValAbs;
            int facteur2 = dénoValAbs;
            int reste, pgcd;

            do
            { 
                reste = facteur1 % facteur2;
                facteur1 = facteur2;
                facteur2 = reste;
            } while (facteur2 != 0);
            pgcd = facteur1;
            numFR = numValAbs / pgcd * (EstNégative() ? -1 : 1);
            dénoFR = dénoValAbs / pgcd;
        }
    }

    //Le constructeur
    public Fraction(int unNumérateur, int unDénominateur)
    {
        numérateur = unNumérateur;
        SetDénominateur(unDénominateur);
    }

    public static Fraction operator +(Fraction fractionDeGauche, Fraction fractionDeDroite)
    {
        int numérateurRésultant = fractionDeGauche.numérateur * fractionDeDroite.dénominateur;
        numérateurRésultant += fractionDeGauche.dénominateur * fractionDeDroite.numérateur;
        int dénominateurRésultat = fractionDeGauche.dénominateur * fractionDeDroite.dénominateur;

        return new Fraction(numérateurRésultant, dénominateurRésultat);
    }

    public static Fraction operator -(Fraction fractionDeGauche, Fraction fractionDeDroite)
    {
        Fraction opposéFractionDeDroite = new Fraction(-1 * fractionDeDroite.numérateur, fractionDeDroite.dénominateur);
        return fractionDeGauche + opposéFractionDeDroite;
    }

    public static Fraction operator *(Fraction fractionDeGauche, Fraction fractionDeDroite)
    {
        int numérateurRésultat = fractionDeGauche.numérateur * fractionDeDroite.numérateur;
        int dénominateurRésultat = fractionDeGauche.dénominateur * fractionDeDroite.dénominateur;

        return new Fraction(numérateurRésultat, dénominateurRésultat);
    }
}

class Ch12Fractions
{

    static void Afficher2VersionsDUneFraction(Fraction uneFraction, string désignation)
    {
        Console.WriteLine("{0} est {1}/{2}, et sa version réduite est {3}/{4}", désignation, uneFraction.GetNumérateur(), uneFraction.GetDénominateur(), uneFraction.GetNumFR(), uneFraction.GetDénoFR());
    }

    static void Main()
    {
        Fraction fraction1 = new Fraction(1, 2);
        Fraction fraction2 = new Fraction(2, 4);
        Fraction fraction3 = new Fraction(3, 6);
        Fraction fraction4 = new Fraction(-3, -6);
        Fraction fraction5 = new Fraction(4, 8);
        Fraction fraction6 = new Fraction(6, 8);
        Fraction fraction7 = new Fraction(97, 92);
        Fraction fraction8 = new Fraction(44, 38);
        Fraction fraction9 = new Fraction(12, -2);
        Fraction fraction10 = new Fraction(4, 7);
        Fraction fractionRéponse1 = fraction4 * fraction6;
        Fraction fractionRéponse2 = fraction7 + fraction8;
        Fraction fractionRéponse3 = fraction7 - fraction8;
        Fraction fractionRéponse4 = fraction7 * fraction8;
        Fraction fractionRéponse5 = fraction1 + fraction2 + fraction3;
        Fraction fractionRéponse6 = fraction1 - fraction2 - fraction3;
        Fraction fractionRéponse7 = fraction9 + fraction10;
        Fraction fractionRéponse8 = fraction5 * fraction10;

        Afficher2VersionsDUneFraction(fraction1, "La première fraction");
        Afficher2VersionsDUneFraction(fraction2, "La deuxième fraction");
        Afficher2VersionsDUneFraction(fraction3, "La troisième fraction");
        Afficher2VersionsDUneFraction(fraction4, "La quatrième fraction");
        Afficher2VersionsDUneFraction(fraction5, "La cinquième fraction");
        Afficher2VersionsDUneFraction(fraction6, "La sixième fraction");
        Afficher2VersionsDUneFraction(fraction7, "La septième fraction");
        Afficher2VersionsDUneFraction(fraction8, "La huitième fraction");
        Afficher2VersionsDUneFraction(fraction9, "La neuvième fraction");
        Afficher2VersionsDUneFraction(fraction10, "La dixième fraction");

        Afficher2VersionsDUneFraction(fractionRéponse1, "Le PRODUIT des fractions 4 et 6");
        Afficher2VersionsDUneFraction(fractionRéponse2, "La SOMME des fractions 7 et 8");
        Afficher2VersionsDUneFraction(fractionRéponse3, "La DIFFÉRENCE des fractions 7 et 8");
        Afficher2VersionsDUneFraction(fractionRéponse4, "Le PRODUIT des fractions 7 et 8");
        Afficher2VersionsDUneFraction(fractionRéponse5, "La SOMME des fractions 1, 2 et 3");
        Afficher2VersionsDUneFraction(fractionRéponse6, "La DIFFÉRENCE des fractions 1, 2 et 3");
        Afficher2VersionsDUneFraction(fractionRéponse7, "La SOMME des fractions 9 et 10");
        Afficher2VersionsDUneFraction(fractionRéponse8, "Le PRODUIT des fractions 5 et 10");
    }
}