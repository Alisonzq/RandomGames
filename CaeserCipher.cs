using System;
using System.IO;

class Cryptographie
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
                if (Char.IsLetter(letter))
                {
                    if (Char.IsUpper(letter))
                    {
                        char lowerLett = Char.ToLower(letter);
                        int letterIndex = alphabet.IndexOf(lowerLett);
                        newText += Char.ToUpper(newAlphabet[letterIndex]);
                    }
                    else
                    {
                        int letterIndex = alphabet.IndexOf(letter);
                        newText += newAlphabet[letterIndex];
                    }
                }
                else
                {
                    newText += letter;
                }

            }
            return newText;
        }

        void decrypt(string decryptText)
        {
            string[] cipherWords = new string[26];
            bool found = false;
            for (int keyD = 0; keyD < 26; keyD++)
            {
                string cipher = encrypt(decryptText, keyD);
                cipherWords[keyD] = cipher;
            }

            foreach (string line in File.ReadLines(@"words.txt"))
            {
                foreach (string word in cipherWords)
                {
                    string lower = word.ToLower();
                    if (word == line)
                    {
                        found = true;
                        Console.WriteLine(word);
                        break;
                    } else if (lower == line)
                    {
                        found = true;
                        Console.WriteLine(word);
                        break;
                    }
                }
            }
            if (found == false)
            {
                foreach (var word in cipherWords)
                {
                    Console.WriteLine(word);
                }
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