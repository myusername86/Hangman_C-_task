﻿using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        int attempts = 10;
        int[] repeat = new int[26];

        while (attempts > 0)
        {
            string[] words = { "cat", "dog", "kittens", "puppies", "bunny" };
            string selectedWord = words[random.Next(words.Length)];
            char[] guessedWord = new char[selectedWord.Length];
            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }
            

            while (true)
            {
                Console.WriteLine("clue for the word connect is: domestic pet animals and their younger one");

                Console.WriteLine("_________________________________________________________________________");
                Console.WriteLine("Guess the word: " + string.Join(" ", guessedWord));
                Console.WriteLine("Attempts left: " + attempts);
                Console.Write("Enter a letter: ");
                char letter = Console.ReadKey().KeyChar;
                int letterIndex = letter - 'a';
                Console.WriteLine();

                bool found = false;
                for (int i = 0; i < selectedWord.Length; i++)
                {
                    if (selectedWord[i] == letter)
                    {
                        guessedWord[i] = letter;
                        found = true;
                    }
                }

                if(!char.IsLetter(letter))
                {
                    Console.WriteLine("don't repeat the same letter");
                    continue;
                }

                if (repeat[letterIndex] > 0)
                {
                    Console.WriteLine("You already guessed the letter '" + letter + "'. Try a different letter.");
                    continue;
                }
                else
                {
                   repeat[letterIndex]++;
                }


                if (!found)
                {
                    attempts--;
                    Console.WriteLine("Incorrect guess!");
                }
                else
                {
                    Console.WriteLine("Correct guess!");
                }

                if (string.Join("", guessedWord) == selectedWord)
                {
                    Console.WriteLine("Congratulations! You guessed the word: " + selectedWord);
                    return; 
                }

                if (attempts == 0)
                {
                    Console.WriteLine("Out of attempts! The word was: " + selectedWord);
                    return; 

                }
            }
        }
    }
}
