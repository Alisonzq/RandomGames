using System;

class Converter
{
    static string ConvertirUnités(int entierDe0A9)
    {
        switch (entierDe0A9)
        {
            case 0:
                return "";
            case 1:
                return "un";
            case 2:
                return "deux";
            case 3:
                return "trois";
            case 4:
                return "quatre";
            case 5:
                return "cinq";
            case 6:
                return "six";
            case 7:
                return "sept";
            case 8:
                return "huit";
            case 9:
                return "neuf";
            default:
                return "";
        }
    }

    static string ConvertirDizaines(int entierDe1A9)
    {
        switch (entierDe1A9)
        {
            case 1:
                return "dix";
            case 2:
                return "vingt";
            case 3:
                return "trente";
            case 4:
                return "quarante";
            case 5:
                return "cinquante";
            case 6:
                return "soixante";
            case 7:
                return "soixante-dix";
            case 8:
                return "quatre-vingt";
            case 9:
                return "quatre-vingt-dix";
            default:
                return "";
        }
    }

    static string ConvertirDizainesSpéciales(int entierDe1A6)
    {
        switch (entierDe1A6)
        {
            case 1:
                return "onze";
            case 2:
                return "douze";
            case 3:
                return "treize";
            case 4:
                return "quatorze";
            case 5:
                return "quinze";
            case 6:
                return "seize";
            default:
                return "";
        }
    }

    static string ConvertirEntierSousCent(int entierDe1A99, bool contexteInfA1000)
    {
        int entierUnités = entierDe1A99 % 10;
        int entierDizaines = entierDe1A99 / 10;
        string strUnités = ConvertirUnités(entierUnités);
        string réponse = "";
        if (entierDizaines == 0)
            réponse = strUnités;
        else
        {
            bool entierDizaine1 = entierDizaines == 1;
            bool entierDizaine79 = entierDizaines == 7 || entierDizaines == 9;
            bool entierUnite16 = entierUnités == 1 || entierUnités == 2 || entierUnités == 3 || entierUnités == 4 || entierUnités == 5 || entierUnités == 6;

            if (entierDizaine1 && entierUnite16) //entre 11 et 16
                réponse = ConvertirDizainesSpéciales(entierUnités);
            else
            {
                bool entier0 = entierUnités == 0;
                string trait = entier0 ? "" : (entierUnités == 1 && entierDizaines < 8 ? "-et-" : "-");
                string quatrevingt = contexteInfA1000 && entier0 && entierDizaines == 8 ? "s" : "";
                string dizSpecial = ConvertirDizaines(entierDizaines - 1) + trait + ConvertirDizainesSpéciales(entierUnités);
                réponse = entierDizaine79 && entierUnite16 ? dizSpecial : ConvertirDizaines(entierDizaines) + trait + strUnités + quatrevingt;
            }
        }
        return réponse;
    }


    static string ConvertirEntierSousMille(int entierDe1A999, bool contexteInférieurAMille)
    {
        int entierSous100 = entierDe1A999 % 100;
        int entierCentaines = entierDe1A999 / 100;
        string portionCent_s;
        bool entierSous100Nul = entierSous100 == 0;
        bool entierCentaines0 = entierCentaines == 0;

        if (entierCentaines0)
            portionCent_s = "";
        else
        {
            bool entierCentaines1 = entierCentaines == 1;
            portionCent_s = (entierCentaines1 ? "" : (ConvertirUnités(entierCentaines) + " ")) + "cent" + (contexteInférieurAMille && !entierCentaines1 && entierSous100Nul ? "s" : "");
        }
        string portionSousCent = entierSous100Nul ? "" : ((entierCentaines0 ? "" : " ") + ConvertirEntierSousCent(entierSous100, contexteInférieurAMille));
        return portionCent_s + portionSousCent;
    }

    static string ConvertirEntierSousUnMillion(int entierDe1A1000000)
    {
        int sousMillier = entierDe1A1000000 % 1000;
        int millier = entierDe1A1000000 / 1000;

        string portionMille = millier == 0 ? "" : millier == 1000 ? "un million" : millier < 2 ? "mille" : (ConvertirEntierSousMille(millier, false) + " mille");
        string portionSousMille = sousMillier == 0 ? "" : (millier == 0 ? "" : " ") + ConvertirEntierSousMille(sousMillier, true);
        return portionMille + portionSousMille;
    }

    static void Main()
    {
        Console.WriteLine("BIENVENUE AU CONVERTISSEUR \"NOMBRES-LETTRES\"!");
        int nombreAConvertir = InputNumber.InputNumBetween(1, 1000000);
        Console.WriteLine(ConvertirEntierSousUnMillion(nombreAConvertir));
        Console.WriteLine();
    }
}