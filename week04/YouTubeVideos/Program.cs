using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; }
    public string Text { get; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

public class Video
{
    public string Title { get; }
    public string Author { get; }
    public int LengthInSeconds { get; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public List<Comment> GetComments()
    {
        return comments;
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Create 3-4 videos with Zimbabwean themes
        Video video1 = new Video("Understanding Ubuntu Philosophy", "Tendai Moyo", 300);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "I learned a lot."));
        video1.AddComment(new Comment("Charlie", "Thanks for this!"));

        Video video2 = new Video("Introduction to Shona Culture", "Chipo Ndlovu", 450);
        video2.AddComment(new Comment("David", "Very helpful!"));
        video2.AddComment(new Comment("Eve", "Nice overview."));
        
        Video video3 = new Video("Basics of Zimbabwean Cuisine", "Mike Johnson", 600);
        video3.AddComment(new Comment("Frank", "Good content!"));
        video3.AddComment(new Comment("Grace", "Looking forward to more!"));
        video3.AddComment(new Comment("Heidi", "Well explained."));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display the information for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(); // Add a blank line for better readability
        }
    }
}
