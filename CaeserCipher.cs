using System;
using System.IO;
using System.Linq;

class cryptographie
{
    static void Main()
    {
        string encrypt(string encryptText, int keyE)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string newAlphabet = alphabet.Substring(keyE) + alphabet.Substring(0, keyE);
            string newText = "";

            foreach (char letter in encryptText)
            {
                if (Char.IsLower(letter))
                {
                    int letterIndex = alphabet.IndexOf(letter);
                    newText += newAlphabet[letterIndex];
                }
                else
                    newText += letter;
            }
            return newText;
        }

        void decrypt(string decryptText)
        {
            foreach (int keyD in Enumerable.Range(1, 26))
            {
                //random 1 to 3
                string cipher = encrypt(decryptText, keyD);
                bool found = false;
                foreach (string line in File.ReadLines(@"words.txt"))
                {
                    if (cipher == line)
                    {
                        found = true;
                        Console.WriteLine(cipher);
                        break;
                    }

                }
                if (found)
                    Console.WriteLine(cipher);
            }
        }

        do
        {
            Console.Write("press 1 to encrypt, 2 to decrypt or 3 to exit: ");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Write("enter a word to encrypt: ");
                    string text = Console.ReadLine();
                    Console.Write("enter a number (between 1 & 26): ");
                    int key = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("encrypted word : " + encrypt(text, key) + Environment.NewLine);
                    break;

                case 2:
                    string[] encryptedWords = { "tcrgneixdc", "tfwsbrg", "lwsuzwj", "fgnrs", "ywopha", "egdvgpbbxcv", "flzzrgevpny", "yanwewqgmjhskkogjv:)" };
                    Console.WriteLine("Choose an ecrypted word to decrypt or decrypt your own word : ");
                    foreach (string word in encryptedWords)
                        Console.WriteLine(word);
                    Console.WriteLine();
                    Console.Write("enter a message to decrypt : ");
                    string decryptWord = Console.ReadLine();
                    decrypt(decryptWord);
                    Console.WriteLine();
                    break;

                case 3:
                    Environment.Exit(0);
                    break;
            }
        } while (true);
    }
}