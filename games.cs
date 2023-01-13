using System;

class Jeu
{
    static bool EstUnTypeDEspace(char unCaractere)
    {
        return unCaractere == 32 || unCaractere == 9;
        /*32 est le code ASCII de l'espace, 9 est le code ASCII de la tabulation*/
    }

    static void AfficheMotSiNonVide(string leMot)
    {
        if (leMot.Length != 0) Console.WriteLine(leMot);
    }

    static void SautDeLigne_s(int nombreDeLignesQuIlFautSauter)
    {
        Console.ResetColor();
        for (int i = 0; i < nombreDeLignesQuIlFautSauter; i++)
        {
            Console.WriteLine();
        }
    }

    static void JeuDuChangeRendu()
    {
        //À COMPLÉTER
        Console.WriteLine("Quel est le nombre de 'cents' de l'item acheté?");
        int nombreDeCentsDuProduit = InputNumber.InputNumBetween(1, 99);

        if (nombreDeCentsDuProduit == 1 || nombreDeCentsDuProduit == 2)
            Console.WriteLine("Avec ce nombre de 'cents' dans le prix du produit, le commerçant vous remettrait un dollar complet, alors vous n'avez même pas à les débourser...");
        else
        {
            int nombreDeCentsEnMonnaie_Theorique = 100 - nombreDeCentsDuProduit;
            int reste = nombreDeCentsEnMonnaie_Theorique % 10;
            int ajustement;
            int nombreDeCentsEnMonnaie_Effectif;
            switch (reste)
            {
                case 0:
                case 5:
                    Console.WriteLine("Avec un prix contenant {0} ‘cents’, la monnaie \"théorique\" serait de {1}... et c'est donc exactement ce que le client recevra!", nombreDeCentsDuProduit, nombreDeCentsEnMonnaie_Theorique);
                    break;
                case 1:
                case 6:
                    ajustement = -1;
                    nombreDeCentsEnMonnaie_Effectif = nombreDeCentsEnMonnaie_Theorique + ajustement;
                    Console.WriteLine("Avec un prix contenant {0} ‘cents’, la monnaie \"théorique\" serait de {1}¢, mais depuis le retrait des pièces d'un sou, le change rendu sera de {2}¢.", nombreDeCentsDuProduit, nombreDeCentsEnMonnaie_Theorique, nombreDeCentsEnMonnaie_Effectif);
                    break;
                case 2:
                case 7:
                    ajustement = -2;
                    nombreDeCentsEnMonnaie_Effectif = nombreDeCentsEnMonnaie_Theorique + ajustement;
                    Console.WriteLine("Avec un prix contenant {0} ‘cents’, la monnaie \"théorique\" serait de {1}¢, mais depuis le retrait des pièces d'un sou, le change rendu sera de {2}¢.", nombreDeCentsDuProduit, nombreDeCentsEnMonnaie_Theorique, nombreDeCentsEnMonnaie_Effectif);
                    break;
                case 3:
                case 8:
                    ajustement = 2;
                    nombreDeCentsEnMonnaie_Effectif = nombreDeCentsEnMonnaie_Theorique + ajustement;
                    Console.WriteLine("Avec un prix contenant {0} ‘cents’, la monnaie \"théorique\" serait de {1}¢, mais depuis le retrait des pièces d'un sou, le change rendu sera de {2}¢.", nombreDeCentsDuProduit, nombreDeCentsEnMonnaie_Theorique, nombreDeCentsEnMonnaie_Effectif);
                    break;
                case 4:
                case 9:
                    ajustement = 1;
                    nombreDeCentsEnMonnaie_Effectif = nombreDeCentsEnMonnaie_Theorique + ajustement;
                    Console.WriteLine("Avec un prix contenant {0} ‘cents’, la monnaie \"théorique\" serait de {1}¢, mais depuis le retrait des pièces d'un sou, le change rendu sera de {2}¢.", nombreDeCentsDuProduit, nombreDeCentsEnMonnaie_Theorique, nombreDeCentsEnMonnaie_Effectif);
                    break;
            }
        }
    }


    static int DemandeLongueurCoteTriangleRect(string quantieme)
    {
        Console.WriteLine("Quelle est la {0} longueur de côté que vous voulez inscrire pour votre triangle rectangle?", quantieme);
        Console.WriteLine("(cette valeur DOIT ÊTRE POSITIVE!):");
        int longueur = InputNumber.InputPositiveNum();
        return longueur;
    }

    static void JeuDeLHypotenuse()
    {
        //COMPLÈTEMENT CODÉ POUR VOUS!
        int premiereDonnee = DemandeLongueurCoteTriangleRect("première");
        int deuxiemeDonnee = DemandeLongueurCoteTriangleRect("deuxième");
        bool unCôtéHypo = false; //Initialisation par défaut
        int hypotenuse, cote;
        hypotenuse = cote = 0; //Initialisation par défaut

        if (premiereDonnee != deuxiemeDonnee)
        {
            Console.WriteLine("côtés de longueurs différents, côté plus long est l'hypothénuse? o/n");
            string input = Console.ReadLine();
            switch(input)
            {
                case "o":
                    unCôtéHypo = true;
                    break;
                case "n":
                    unCôtéHypo = false;
                    break;
            }
            if (unCôtéHypo)
            {
                if (premiereDonnee > deuxiemeDonnee)
                {
                    hypotenuse = premiereDonnee;
                    cote = deuxiemeDonnee;
                }
                else
                {
                    hypotenuse = deuxiemeDonnee;
                    cote = premiereDonnee;
                }
            }
        }

        if (unCôtéHypo)
            Console.WriteLine("Le côté manquant de ce triangle rectangle est {0}", Math.Sqrt(Math.Pow(hypotenuse, 2) - Math.Pow(cote, 2)));
        else
            Console.WriteLine("L'hypoténuse de ce triangle rectangle est {0}", Math.Sqrt(Math.Pow(premiereDonnee, 2) + Math.Pow(deuxiemeDonnee, 2)));
    }

    //===***   SECTION #4 POUR LE JEU #3   ***===

    static void JeuDeLEquationLin()
    {
        Console.WriteLine("Ce jeu vous permet de résoudre une équation du type AX + B = 0.");
        Console.WriteLine("Il faut commencer par inscrire une valeur ENTIÈRE pour A:");
        int entierPourA = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Il faut maintenant inscrire une valeur ENTIÈRE pour B:");
        int entierPourB = Int32.Parse(Console.ReadLine());

        //CE QUI EST CI-BAS DOIT ÊTRE COMPLÉTÉ
        if (entierPourA != 0 && entierPourB != 0)
            Console.WriteLine("L'équation {0}X + {1} = 0 a une solution en X = {2}.", entierPourA, entierPourB, (double)-entierPourB / entierPourA);
        else
        {
            if (entierPourA == 0 && entierPourB == 0)
                Console.WriteLine("L'équation {0}X + {1} = 0 a une infinité de solutions.", entierPourA, entierPourB);
            else if (entierPourA == 0 && entierPourB != 0)
                Console.WriteLine("L'équation {0}X + {1} = 0 n'a aucune solution.", entierPourA, entierPourB);
            else if (entierPourA != 0 && entierPourB == 0)
                Console.WriteLine("L'équation {0}X + {1} = 0 a une solution en X = 0.", entierPourA, entierPourB);
        }
    }

    static void JeuDeLEquationQuadr()
    {
        Console.WriteLine("Ce jeu vous permet de trouver les racines d'une équation quadratiques du type AX² + BX + C = 0.");
        Console.WriteLine("Il faut commencer par inscrire une valeur ENTIÈRE pour A (CE NE PEUT ÊTRE NUL!):");
        int entierPourA = InputNumber.InputAtLeast(1); 
        Console.WriteLine("Il faut maintenant inscrire une valeur ENTIÈRE pour B:");
        int entierPourB = Int32.Parse(Console.ReadLine()); 
        Console.WriteLine("Il faut finalement inscrire une valeur ENTIÈRE pour C:");
        int entierPourC = Int32.Parse(Console.ReadLine()); ; 
        SautDeLigne_s(1);
        double radicandePotentiel = Math.Pow(entierPourB, 2) - 4 * entierPourA * entierPourC; //REMPLACEZ CE 0.0. PAR LA BONNE FORMULE POUR LE RADICANDE
        double quad = (-entierPourB + Math.Sqrt(radicandePotentiel)) / (2 * entierPourA);
        double quad2 = (-entierPourB - Math.Sqrt(radicandePotentiel)) / (2 * entierPourA);
        double reponse(double wakandaquad) { return (entierPourA * Math.Pow(wakandaquad, 2)) + (entierPourB * wakandaquad) + entierPourC; }
        if (radicandePotentiel < 0)
            Console.WriteLine("Ceci est insoluble: votre combinaison de A, B et C donne une valeur négative pour l'expression b^2 - 4ac, rendant impossible l'extraction de la racine carée.");
        else if (radicandePotentiel == 0)
        {
            Console.WriteLine("La racine de cette équation quadratique est {0}.", radicandePotentiel);
            Console.WriteLine("Effectivement, {0}({1})² + {2}({1}) + {3} = {4}", entierPourA, quad, entierPourB, entierPourC, reponse(quad));
        }
        else
        {
            Console.WriteLine("Les racines de cette équation quadratique sont {0} et {1}.", quad, quad2);
            Console.WriteLine("Effectivement, d'une part, {0}({1})² + {2}({1}) + {3} = {4}", entierPourA, quad, entierPourB, entierPourC, reponse(quad));
            Console.WriteLine("D'autre part, {0}({1})² + {2}({1}) + {3} = {4}", entierPourA, quad2, entierPourB, entierPourC, reponse(quad2));
        }
    }

    //===***---&&&   LES JEUX DE CHAÎNES DE CARACTÈRES   &&&---***===

    //===***   SECTION #6 POUR LE JEU #5   ***===

    static void JeuDeLEliminationDEspaces()
    {
        Console.WriteLine("Veuillez inscrire une chaîne de caractères svp. : ");
        string input = Console.ReadLine();

        string chaineEpuree = "";
        foreach (char i in input)
        {
            if (!EstUnTypeDEspace(i))
                chaineEpuree += i;
        }
        Console.WriteLine(chaineEpuree);
    }

    //===***   SECTION #7 POUR LE JEU #6   ***===

    static void JeuDuMotParLigne()
    {
        Console.WriteLine("Veuillez inscrire une phrase svp : ");
        string input = Console.ReadLine();
        string mot = "";
        foreach (char i in input)
        {
            if (!EstUnTypeDEspace(i))
                mot += i;
            else if (mot != "")
            {
                Console.WriteLine(mot);
                mot = "";
            }
        }
        AfficheMotSiNonVide(mot);
    }

    //===***   SECTION #8 POUR LE JEU #7   ***===    

    static void JeuDesOccurrencesDUnCaractere()
    {
        Console.Write("register a sentence: ");
        string input = Console.ReadLine();
        int sentenceLength = input.Length;
        Console.Write("register a character: ");
        string characterInput;
        do
        {
            characterInput = Console.ReadLine();
            if (characterInput.Length > 1)
                Console.Write("Un caractère! Recommençons...");
        } while (characterInput.Length > 1);

        char charInInput = characterInput[0];
        Console.WriteLine();
        int numOfTime = 0;
        for (int i = 0; i < sentenceLength; i++)
        {
            if (input[i] == charInInput)
                numOfTime++;
        }

        Console.WriteLine("the character '{0}' appears {1} times in the sentence \"{2}\"", charInInput, numOfTime, input);
    }



    //===***   SECTION #9: LE "MAIN"   ***===    
    static void Main()
    {
        string chaineCapteeALaConsole;
        bool onArreteTout = false;
        bool continueGame = true;
        do
        {
            SautDeLigne_s(3);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("LE BUFFET!");
            SautDeLigne_s(3);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("Choisissez parmi les 7 options suivantes:");
            SautDeLigne_s(2);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("(options numériques et mathématiques):");
            SautDeLigne_s(2);
            Console.WriteLine("Touche 1 ==> Veuillez passer à la caisse...");
            Console.WriteLine("Touche 2 ==> Pythagore!");
            Console.WriteLine("Touche 3 ==> L'équation linéaire");
            Console.WriteLine("Touche 4 ==> L'équation quadratique");
            SautDeLigne_s(1);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("(options de chaînes de caractères):");
            SautDeLigne_s(2);
            Console.WriteLine("Touche 5 ==> Les espaces... pouf!");
            Console.WriteLine("Touche 6 ==> La phrase qui prend de la place...");
            Console.WriteLine("Touche 7 ==> Combien de fois apparaît-il, lui?");
            Console.WriteLine("N'importe quelle(s) autre(s) touche(s) ==> Fin du programme");
            SautDeLigne_s(1);
            Console.Write("Votre choix, svp:");
            chaineCapteeALaConsole = Console.ReadLine();
            SautDeLigne_s(2);
            do
            {
                switch (chaineCapteeALaConsole)
                {
                    case "1":
                        JeuDuChangeRendu();
                        break;
                    case "2":
                        JeuDeLHypotenuse();
                        break;
                    case "3":
                        JeuDeLEquationLin();
                        break;
                    case "4":
                        JeuDeLEquationQuadr();
                        break;
                    case "5":
                        JeuDeLEliminationDEspaces();
                        break;
                    case "6":
                        JeuDuMotParLigne();
                        break;
                    case "7":
                        JeuDesOccurrencesDUnCaractere();
                        break;
                    default:
                        onArreteTout = true;
                        break;
                }//FIN DU SWITCH
                if (!onArreteTout)
                {
                    SautDeLigne_s(1);
                    Console.WriteLine("Voulez-vous reprendre le même jeu? o/n");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "o":
                            continueGame = true;
                            break;
                        case "n":
                            continueGame = false;
                            break;
                    }
                }
            } while (!onArreteTout && continueGame);
        } while (!onArreteTout);
    }//FIN DU MAIN
}//FIN DE LA CLASSE