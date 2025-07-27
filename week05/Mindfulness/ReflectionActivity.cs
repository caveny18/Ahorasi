using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself through this experience?",
        "How did you feel when it was complete?",
        "What could you learn from this experience that applies to other situations?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("\n" + GetRandomPrompt());
        ShowSpinner(5);
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.WriteLine("\n" + GetRandomQuestion());
            ShowSpinner(5);
        }
        DisplayEndingMessage();
    }

    private string GetRandomPrompt() => _prompts[new Random().Next(_prompts.Count)];
    private string GetRandomQuestion() => _questions[new Random().Next(_questions.Count)];
}