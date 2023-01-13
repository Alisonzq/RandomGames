using System;

class Polygone
{
    //classification
    static protected int anglePlatDeg = 180;

    protected int côté1;
    private int nombreDeCôtés;

    //lecteurs
    public int GetCôté1()
    {
        return côté1;
    }
    public int GetNombreDeCôté()
    {
        return nombreDeCôtés;
    }

    //traitements utiles permanents

    protected static void VerifExceptionsPossiblesNonPositives(int valeurDuParametre, string descriptionDuParametre)
    {
        if (valeurDuParametre == 0)
        {
            throw new ArgumentException("Argument invalide car nul!" + descriptionDuParametre);
        }
        else if (valeurDuParametre < 0)
            throw new ArgumentException("Argument invalide car negatif!" + descriptionDuParametre);
    }

    protected static void VerifExceptionsPossiblesMesureDeCôté(int valeurDeCôté)
    {
        VerifExceptionsPossiblesNonPositives(valeurDeCôté, "Mesure de côté.");
    }

    public void SetCôté1(int unC1)
    {
        VerifExceptionsPossiblesMesureDeCôté(unC1);
        côté1 = unC1;
    }

    public void SetNombreDeCôtés(int unNombreDeCôtés)
    {
        VerifExceptionsPossiblesNonPositives(unNombreDeCôtés, "Nombre de côtés.");

        if (nombreDeCôtés < 3)
            throw new ArgumentException("Un polygone doit avoir au moins 3 côtés.");

        nombreDeCôtés = unNombreDeCôtés;
    }

    //Une autre méthode utile
    public int SommeDesAnglesIntérieurs()
    {
        return (nombreDeCôtés - 2) * anglePlatDeg;
    }

    //constructeur
    public Polygone(int c1, int unNombreCôtés)
    {
        SetCôté1(c1);
        SetNombreDeCôtés(unNombreCôtés);
    }
}

class Rectangle : Polygone
{
    //Classification
    private int côté2;

    //Lecteur
    public int getCôté2()
    {
        return côté2;
    }

    //Mutateur
    public void SetCôté2(int unC2)
    {
        VerifExceptionsPossiblesMesureDeCôté(unC2);
        côté2 = unC2;
    }

    //constructeur
    public Rectangle(int c1, int c2) : base(c1, 4)
    {
        SetCôté2(c2);
    }

    //un AUTRE constructeur
    public Rectangle(int valeurUniqueDeCôté) : this(valeurUniqueDeCôté, valeurUniqueDeCôté)
    { }
    public bool EstCarré()
    {
        return côté1 == côté2;
    }

    public int Aire()
    {
        return côté1 * côté2;
    }

    public int Périmètre()
    {
        return 2 * (côté1 + côté2);
    }
}

class Triangle : Polygone
{

    //Classification
    private int côté2;
    private int angleEntreLes2;

    //Lecteur
    public int getCôté2()
    {
        return côté2;
    }

    public int getAngleEntreLes2()
    {
        return angleEntreLes2;
    }

    //Mutateur
    public void SetCôté2(int unC2)
    {
        VerifExceptionsPossiblesMesureDeCôté(unC2);
        côté2 = unC2;
    }

    public void SetAngleEntreLes2(int unAngle)
    {
        VerifExceptionsPossiblesNonPositives(unAngle, "Mesure de l'angle.");

        //SECOND cas de vérification: un angle de 180 degrés.
        if (unAngle == anglePlatDeg)
            throw new ArgumentException("Un seul angle dans un triangle ne peut être de 180 degrés.");

        //Troisième cas de vérification: un angle >= 360
        if (unAngle >= 2 * anglePlatDeg)
            throw new ArgumentException("La classe triangle n'accepte pas d'angle supérieur ou égal à 360 degrés.");

        /*Finalement, tout angle supérieur à 180 degrés sera automatiquement ramené à son angle "supplémentaire à 360 degrés"*/
        int diff = anglePlatDeg - unAngle;
        angleEntreLes2 = diff < 0 ? anglePlatDeg + diff : unAngle;
    }

    //constructeur
    public Triangle(int c1, int c2, int angle) : base(c1, 3) //utilise de la superclasse
    {
        SetCôté2(c2);
        SetAngleEntreLes2(angle);
    }

    //traitements utiles

    //Méthode utiliitaire pour les angles dans un triangle
    private static double ConvertirDegrésEnRadians(int unAngleEnDegrés)
    {
        return Math.PI * unAngleEnDegrés / anglePlatDeg;
    }

    public double Longueur3ièmeCôté()
    {
        return Math.Sqrt(Math.Pow(côté1, 2) + Math.Pow(côté2, 2) - 2 * côté1 * côté2 * Math.Cos(ConvertirDegrésEnRadians(angleEntreLes2)));
    }

    public double Aire()
    {
        double hauteur = Math.Sin(ConvertirDegrésEnRadians(angleEntreLes2)) * côté2;
        return côté1 * hauteur / 2;
    }

    //Autre exemple de polymorphisme
    public double Périmètre()
    {
        return côté1 + côté2 + Longueur3ièmeCôté();
    }

    //Des méthodes vraiment propres à un triangle
    public bool EstÉquilatéral()
    {
        return côté1 == côté2 && côté1 == Longueur3ièmeCôté();
    }

    public bool EstIsocèle()
    {
        return (côté1 == côté2) || (côté1 == Longueur3ièmeCôté() || (côté2 == Longueur3ièmeCôté()));
    }

    public bool EstScalène()
    {
        return !EstIsocèle();
    }
}
class Chapitre12PratiqueGéométrie
{
    static void AfficherSiRectangleEEstCarré(Rectangle unRectangle, string nomRectangle)
    {
        Console.WriteLine("{0} {1} un carré.", nomRectangle, unRectangle.EstCarré() ? "est" : "n'est PAS");
    }
    static void Main()
    {
        //créons ici trois rectangles
        Rectangle unRectangle1 = new Rectangle(4, 5);
        Rectangle unRectangle2 = new Rectangle(2, 7);
        Rectangle unRectangle3 = new Rectangle(6);
        AfficherSiRectangleEEstCarré(unRectangle1, "Le premier rectangle");
        AfficherSiRectangleEEstCarré(unRectangle2, "Le deuxième rectangle");
        AfficherSiRectangleEEstCarré(unRectangle3, "Le troisième rectangle");

        Console.WriteLine("L'aire du premier rectangle est {0}", unRectangle1.Aire());
        Console.WriteLine("Le périmètre du premier rectangle est {0}", unRectangle1.Périmètre());

        Console.WriteLine("L'aire du deuxième rectangle est {0}", unRectangle2.Aire());
        Console.WriteLine("Le périmètre du deuxième rectangle est {0}", unRectangle2.Périmètre());

        Console.WriteLine("L'aire du troisième rectangle est {0}", unRectangle3.Aire());
        Console.WriteLine("Le périmètre du troisième rectangle est {0}", unRectangle3.Périmètre());


        Triangle unTriangleRect = new Triangle(3, 4, 90);
        Console.WriteLine("Le 3e côté (dans ce cas l'hypothénuse) de ce triangle rectangle est de {0}", unTriangleRect.Longueur3ièmeCôté());

        Console.WriteLine("L'aire de ce triangle rectangle est de {0}", unTriangleRect.Aire());

        Console.WriteLine("Le périmiètre de ce triangle rectangle est de {0}", unTriangleRect.Périmètre());

    }
}