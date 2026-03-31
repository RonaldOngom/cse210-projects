using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create Video objects
        Video video1 = new Video("C# Programming Basics", "Code Academy", 600);
        Video video2 = new Video("Understanding Abstraction", "Dev Simplified", 720);
        Video video3 = new Video("Object-Oriented Programming", "Tech World", 840);

        // Add comments to video 1
        video1.AddComment(new Comment("Alice", "This video was very helpful."));
        video1.AddComment(new Comment("Brian", "Clear explanation of concepts."));
        video1.AddComment(new Comment("Clara", "Perfect for beginners."));

        // Add comments to video 2
        video2.AddComment(new Comment("Daniel", "Abstraction finally makes sense."));
        video2.AddComment(new Comment("Esther", "Well explained and simple."));
        video2.AddComment(new Comment("Frank", "Great examples used."));

        // Add comments to video 3
        video3.AddComment(new Comment("Grace", "OOP concepts are now clear."));
        video3.AddComment(new Comment("Henry", "Very informative."));
        video3.AddComment(new Comment("Irene", "Helped me with my assignment."));

        // Store videos in a list
        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3
        };

        // Display video information
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}