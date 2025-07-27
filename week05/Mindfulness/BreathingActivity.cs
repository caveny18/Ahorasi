using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("Breathe in...");
            ShowCountdown(4);
            Console.Write("Breathe out...");
            ShowCountdown(6);
        }
        DisplayEndingMessage();
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}