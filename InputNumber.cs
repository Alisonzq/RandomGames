using System;

class InputNumber
{

    private static int Input(string consigne, bool isThereMax, bool isThereMin, int min, int max)
    {
        bool toutEstCorrect;
        int inputNum = 0;
        string messageDErreur;

        Console.WriteLine(consigne);
        do
        {
            messageDErreur = "";
            string input = Console.ReadLine();
            try
            {
                inputNum = Int32.Parse(input);

                if(isThereMax | isThereMin)
                {
                    if (inputNum < min)
                        messageDErreur = "trop petit, doit être" + min + "ou plus grand";
                }
                if(isThereMax)
                {
                    if (inputNum > max)
                        messageDErreur = "trop grand, doit être" + max + "ou plus petit";
                }
            }
            catch
            {
                messageDErreur = "votre entier n'est pas valide.";
            }

            toutEstCorrect = messageDErreur.Length == 0;

            if (!toutEstCorrect)
            {
                messageDErreur += "Veuillez recommencez svp: ";
                Console.Write(messageDErreur);
            }
        } while (!toutEstCorrect);
        return inputNum;
    }
    public static int InputNumBetween(int min, int max)
    {
        return Input("Inscrire un entier entre" +min + " et " +max, true, true, min,max);
    }

    public static int InputPositiveNum()
    {
        return Input("Inscrire un entier positif", false, true, 0, 0);
    }

    public static int InputAtLeast(int min)
    {
        return Input("Inscrire un entier d'au moins" + min, false, true, min, 0);
    }
}