using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("\n" + GetRandomPrompt());
        Console.WriteLine("You have a few seconds to prepare...");
        ShowSpinner(5);

        Console.WriteLine("Start listing now!");
        int count = 0;
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items.");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt() => _prompts[new Random().Next(_prompts.Count)];
}