﻿using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace H1_Hangman_Project
{
    internal class Program
    {
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }
        }

        private static int printWord(List<char> guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters += 1;
                }
                else
                {
                    Console.Write("  ");
                }
                counter += 1;
            }
            //Console.Write("\r\n");
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til Hangman!");
            Console.WriteLine("----------------------------------------------------");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { "ost", "ko", "telefon", "oplader", "computer", "mus", "flaske", "tv", "kebab" };
            int index = random.Next(wordDictionary.Count);
            String randomWord = wordDictionary[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nBogstaver gættet: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                // Prompt brugeren for input
                Console.Write("\nGæt et bogstav: ");
                char letterGuessed = Console.ReadLine()[0];
                // Tjek om bogstavet er blevet gættet før
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\n Du har allerede gættet dette bogstav.");
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    // Tjek om bogstavet er i det tilfældige ord
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++) { if (letterGuessed == randomWord[i]) { right = true; } }

                    // Brugeren har ret
                    if (right)
                    {
                        printHangman(amountOfTimesWrong);
                        // Udskriv ordet
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    // Brugeren havde ikke ret
                    else
                    {
                        amountOfTimesWrong += 1;
                        currentLettersGuessed.Add(letterGuessed);
                        // Opdater tegningen og udskriv ordet
                        printHangman(amountOfTimesWrong);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nSpillet er slut!");
        }
    }
}