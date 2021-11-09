using System;
using System.IO;

namespace Capitalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter the address of the chosen file:");
                string fileAddress = Console.ReadLine();
                string text = LoadTextFile(fileAddress);
                Console.WriteLine(text);
                Console.WriteLine();
                string choice = MenuGenerator("Enter 'Point' to capitalize the first character of each sentence. \nEnter 'All' to capitalize the entire text file.");
                string newText = Capitalize(choice, text);
                Console.WriteLine();
                string choice2 = MenuGenerator("Enter 'N' to save in a new text file. \nEnter 'R' to rewrite the original file. \nEnter 'B' to restart the application without saving.");

                if (choice2 == "N")
                {
                    SaveTextFile(choice2, newText, fileAddress);
                }
                else if (choice2 == "R")
                {
                    SaveTextFile(choice2, newText, fileAddress);
                }
            }
        }
        static string Capitalize(string choice, string text)
        {
            if (choice.Equals("Point"))
            {
                string[] textWords = text.Split(" ");
                for (int i = 0; i < textWords.Length; i++)
                {
                    string pointWord = textWords[i];
                    if (pointWord.EndsWith(".") && pointWord != textWords[textWords.Length - 1])
                    {
                        string nextWord = textWords[i + 1];

                        nextWord = nextWord[0].ToString().ToUpper() + nextWord.Substring(1);

                        textWords[i + 1] = nextWord;
                    }
                    textWords[i] = pointWord;
                }
                string result = string.Join(" ", textWords);
                Console.WriteLine(result);
                return result;
            }
            else
            {
                string result = text.ToUpper();
                Console.WriteLine(result);
                return result;
            }
        }

        static string MenuGenerator(string menuText)
        {
            Console.WriteLine(menuText);
            string choice = Console.ReadLine();
            return choice;
        }

        static string LoadTextFile(string fileAddress)
        {
            if (File.Exists(fileAddress))
            {
                try
                {
                    string text = File.ReadAllText(fileAddress);
                    return text;
                }
                catch (Exception)
                {
                    Console.WriteLine("Can't read this file.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("This file doesn't exists.");
                return null;
            }
        }

        static void SaveTextFile(string choice, string text, string address)
        {
            switch (choice)
            {
                case "N":
                    string[] addressBody = address.Split("\\");
                    Console.WriteLine("Save as:");
                    string fileName = Console.ReadLine();
                    addressBody[addressBody.Length - 1] = fileName + ".txt";
                    string newAddress = string.Join("\\", addressBody);
                    try
                    {
                        File.WriteAllText(newAddress, text);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Save file: Failure!");
                    }
                    break;
                case "R":
                    try
                    {
                        File.WriteAllText(address, text);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Save File: Failure!");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
