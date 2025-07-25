using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Rafting in Peru", "Carlos Ruiz", 180);
        video1.AddComment(new Comment("Alice", "Wow, this looks exciting!"));
        video1.AddComment(new Comment("Bob", "Great adventure!"));
        video1.AddComment(new Comment("Charlie", "I want to go there!"));

        Video video2 = new Video("Cooking Lomo Saltado", "Chef Pedro", 300);
        video2.AddComment(new Comment("Maria", "My favorite dish!"));
        video2.AddComment(new Comment("Luis", "Delicious!"));
        video2.AddComment(new Comment("Sofia", "Now I'm hungry."));

        Video video3 = new Video("Hiking Machu Picchu", "AdventuresPeru", 420);
        video3.AddComment(new Comment("Nina", "Amazing views!"));
        video3.AddComment(new Comment("Daniel", "Bucket list destination."));
        video3.AddComment(new Comment("Elena", "This was so helpful!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}
