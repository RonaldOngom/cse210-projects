using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who have you helped recently?",
        "Who are your personal heroes?"
    };

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity helps you list positive things in your life."
        )
    { }

    protected override void PerformActivity()
    {
        Random rand = new();
        Console.WriteLine($"\n{_prompts[rand.Next(_prompts.Count)]}");
        Console.WriteLine("Start listing items...");
        ShowSpinner(3);

        List<string> items = new();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
    }
}