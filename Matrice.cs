using System;
using System.Linq;

class Matrice
{
    static char SaisitCharValideALaConsole(char[] possibilitésDeCaractère)
    {
        char caractèreCaptéALaConsole;
        string chaîneDesPossibilités = "";
        bool caractèreValideTrouvéDansTableau;

        foreach (char unCharPossible in possibilitésDeCaractère)
        {
            chaîneDesPossibilités += unCharPossible + "," + Char.ToLower(unCharPossible) + ',';
        }
        chaîneDesPossibilités = chaîneDesPossibilités.Substring(0, chaîneDesPossibilités.Length - 1);
        //Pour enlever la dernière virgule

        do
        {
            caractèreCaptéALaConsole = Console.ReadLine().ToUpper()[0];
            caractèreValideTrouvéDansTableau = possibilitésDeCaractère.Contains(caractèreCaptéALaConsole);
            if (!caractèreValideTrouvéDansTableau) Console.Write("Vous devez inscrire un caractère parmi les suivants: {0}. Recommençons:", chaîneDesPossibilités);
        } while (!caractèreValideTrouvéDansTableau);
        return caractèreCaptéALaConsole;
    }

    static int DimensionDUneMatrice(string ligneOuColonne, string quantième)
    {
        Console.WriteLine("Combien de {0} voulez-vous dans votre {1} matrice?:", ligneOuColonne, quantième);
        return InputNumber.InputPositiveNum();
    }

    static int[,] Matrix(string quantième, int nombreRangées, int nombreColonnes)
    {
        int[,] matrice = new int[nombreRangées, nombreColonnes];
        for (int i = 0; i < nombreRangées; i++)
        {
            for (int j = 0; j < nombreColonnes; j++)
            {
                Console.Write("Pour votre {0} matrice, quel est le nombre à ligne {1}, colonne {2}? ", quantième, i + 1, j + 1);
                matrice[i, j] = Int32.Parse(Console.ReadLine());
            }
        }
        return matrice;
    }

    static void AfficherMatrice(int[,] uneMatrice)
    {
        int nombreLignes = uneMatrice.GetLength(0);
        int nombreColonnes = uneMatrice.GetLength(1);
        Console.WriteLine();
        for (int i = 0; i < nombreLignes; i++)
        {
            for (int j = 0; j < nombreColonnes; j++)
            {
                Console.Write(uneMatrice[i, j] + "   ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static int[,] Addition(int[,] premièreMatrice, int[,] deuxièmeMatrice, bool addition)
    {
        int lignes = premièreMatrice.GetLength(0);
        int colonnes = premièreMatrice.GetLength(1);
        int[,] newMatrice = new int[lignes, colonnes];
        int resultAdd;
        for (int i = 0; i < lignes; i++)
        {
            for (int j = 0; j < colonnes; j++)
            {
                if (addition)
                {
                    resultAdd = premièreMatrice[i, j] + deuxièmeMatrice[i, j];
                    newMatrice[i, j] = resultAdd;
                }
                else
                {
                    resultAdd = premièreMatrice[i, j] - deuxièmeMatrice[i, j];
                    newMatrice[i, j] = resultAdd;
                }
            }
        }
        return newMatrice;
    }

    static int[,] Multiplication(int[,] premièreMatrice, int[,] secondeMatrice)
    {
        int ligne1 = premièreMatrice.GetLength(0);
        int colonne1ligne2 = premièreMatrice.GetLength(1);
        int colonne2 = secondeMatrice.GetLength(1);
        int[,] newMatrice = new int[ligne1, colonne2];
        for (int i = 0; i < ligne1; i++) //loop through 1st matrix lines
        {
            for (int j = 0; j < colonne2; j++) //loop through 2nd matrix colonnes
            {
                int resultMultiply = 0;
                for (int k = 0; k < colonne1ligne2; k++) //loop through 1st matrix colonnes
                {
                    resultMultiply += premièreMatrice[i, k] * secondeMatrice[k, j];
                }
                newMatrice[i, j] = resultMultiply;
            }
        }
        return newMatrice;
    }

    static void Main()
    {
        bool usagerVeutUtiliserLes2MêmesMatrices, usagerVeutPoursuivreLeJeu, addSoustrPossible, multPossible, reponseEstA, reponseEstS;
        int nombreDeRangéesMatrice1, nombreDeColonnesMatrice1, nombreDeRangéesMatrice2, nombreDeColonnesMatrice2, nombreDePossibilités, indiceChoixM;
        int[,] matrice1, matrice2, matriceRésultante;
        char[] tableauDesCaractèresPossibles;
        char choixDeLUsager;

        do
        {
            nombreDeRangéesMatrice1 = DimensionDUneMatrice("ligne(s)", "première");
            nombreDeColonnesMatrice1 = DimensionDUneMatrice("colonne(s)", "première");
            nombreDeRangéesMatrice2 = DimensionDUneMatrice("ligne(s)", "deuxième");
            nombreDeColonnesMatrice2 = DimensionDUneMatrice("colonne(s)", "deuxième");

            addSoustrPossible = nombreDeRangéesMatrice1 == nombreDeRangéesMatrice2 && nombreDeColonnesMatrice1 == nombreDeColonnesMatrice2;
            multPossible = nombreDeColonnesMatrice1 == nombreDeRangéesMatrice2;

            if (!addSoustrPossible && !multPossible)
                Console.WriteLine("Vous spécifiez des dimensions de matrices qui ne permettent ni les opérations additives, ni la multiplication!");
            else
            {
                matrice1 = Matrix("première", nombreDeRangéesMatrice1, nombreDeColonnesMatrice1);
                matrice2 = Matrix("seconde", nombreDeRangéesMatrice2, nombreDeColonnesMatrice2);
                nombreDePossibilités = 0;
                if (addSoustrPossible)
                {
                    nombreDePossibilités++;
                    nombreDePossibilités++;
                }

                if (multPossible) nombreDePossibilités++;
                tableauDesCaractèresPossibles = new char[nombreDePossibilités];

                if (addSoustrPossible)
                {
                    tableauDesCaractèresPossibles[0] = 'A';
                    tableauDesCaractèresPossibles[1] = 'S';
                    indiceChoixM = 2;
                }
                else
                    indiceChoixM = 0;

                if (multPossible)
                    tableauDesCaractèresPossibles[indiceChoixM] = 'M';

                do
                {
                    Console.WriteLine("Spécifiez quelle opération vous voulez faire avec vos deux matrices:");
                    if (addSoustrPossible)
                    {
                        Console.WriteLine("A (ou a...) - les additionner");
                        Console.WriteLine("S (ou s...) - les soustraire");
                    }
                    if (multPossible)
                        Console.WriteLine("M (ou m...) - les multiplier");

                    choixDeLUsager = SaisitCharValideALaConsole(tableauDesCaractèresPossibles);
                    reponseEstA = choixDeLUsager == 'A';
                    reponseEstS = choixDeLUsager == 'S';

                    Console.WriteLine("Vos deux matrices sont donc:");
                    AfficherMatrice(matrice1);
                    AfficherMatrice(matrice2);

                    if (reponseEstA || reponseEstS)
                    {
                        Console.WriteLine("{0} de ces deux matrices donne:", reponseEstA ? "L'addition" : "La soustraction");
                        matriceRésultante = Addition(matrice1, matrice2, reponseEstA);
                        AfficherMatrice(matriceRésultante);
                    }
                    else
                    {
                        Console.WriteLine("La multiplication de ces deux matrices donne:");
                        matriceRésultante = Multiplication(matrice1, matrice2);
                        AfficherMatrice(matriceRésultante);
                    }

                    usagerVeutUtiliserLes2MêmesMatrices = InputNumber.InputOuiouNon("Voulez-vous faire une autre opération avec les deux mêmes matrices?:");
                } while (usagerVeutUtiliserLes2MêmesMatrices);
            }
            usagerVeutPoursuivreLeJeu = InputNumber.InputOuiouNon("Voulez-vous inscrire deux nouvelles matrices pour faire d'autres opérations? "); 
        } while (usagerVeutPoursuivreLeJeu);
    }
}