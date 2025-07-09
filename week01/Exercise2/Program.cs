using System;

class Program
{
    static void Main(string[] args)
    {
        // Pedir al usuario el porcentaje
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";
        string sign = "";

        // Determinar la letra base
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determinar el signo solo si no es F
        if (letter != "F")
        {
            int lastDigit = percent % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }

            // Ajuste especial: no existe A+
            if (letter == "A" && sign == "+")
            {
                sign = "";
            }
        }
        else
        {
            // F nunca lleva + ni -
            sign = "";
        }

        // Mostrar la calificación final con signo
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determinar si aprobó
        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}
