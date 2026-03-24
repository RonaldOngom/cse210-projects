using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Class to represent a single word in a scripture
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public string GetDisplay()
        {
            if (_isHidden)
                return new string('_', _text.Length);
            return _text;
        }

        public bool IsHidden => _isHidden;

        public void Hide()
        {
            _isHidden = true;
        }
    }

    // Class to represent a scripture reference (single verse or range)
    public class Reference
    {
        public string Book { get; private set; }
        public int StartChapter { get; private set; }
        public int StartVerse { get; private set; }
        public int? EndVerse { get; private set; }

        // Constructor for single verse
        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            StartChapter = chapter;
            StartVerse = verse;
            EndVerse = null;
        }

        // Constructor for verse range
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            Book = book;
            StartChapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            if (EndVerse.HasValue)
                return $"{Book} {StartChapter}:{StartVerse}-{EndVerse}";
            return $"{Book} {StartChapter}:{StartVerse}";
        }
    }

    // Class to represent the full scripture
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private static Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            foreach (var w in text.Split(' '))
            {
                _words.Add(new Word(w));
            }
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(_reference.ToString());
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplay())));
        }

        public bool HideRandomWords(int count)
        {
            var visibleWords = _words.Where(w => !w.IsHidden).ToList();
            if (!visibleWords.Any())
                return false;

            for (int i = 0; i < count && visibleWords.Count > 0; i++)
            {
                var wordToHide = visibleWords[_random.Next(visibleWords.Count)];
                wordToHide.Hide();
                visibleWords.Remove(wordToHide);
            }
            return true;
        }

        public bool AllHidden()
        {
            return _words.All(w => w.IsHidden);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // EXCEED REQUIREMENTS: Added a small library of scriptures for random selection
            List<Scripture> scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
                new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength.")
            };

            Random random = new Random();
            Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

            while (true)
            {
                selectedScripture.Display();
                Console.WriteLine();
                Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;

                // Hide 3 words per iteration, only visible words
                if (!selectedScripture.HideRandomWords(3))
                    break;

                if (selectedScripture.AllHidden())
                {
                    selectedScripture.Display();
                    Console.WriteLine();
                    Console.WriteLine("All words are hidden! Well done!");
                    break;
                }
            }

            Console.WriteLine("Thank you for using Scripture Memorizer!");
        }
    }
}