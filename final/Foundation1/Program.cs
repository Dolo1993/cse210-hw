 using System;
using System.Collections.Generic;

public class Comment
{
    private string commenterName;
    private string commentText;

    public Comment(string commenterName, string commentText)
    {
        this.commenterName = commenterName;
        this.commentText = commentText;
    }

    public string GetCommenterName()
    {
        return commenterName;
    }

    public string GetCommentText()
    {
        return commentText;
    }
}

public class Video
{
    private string title;
    private string author;
    private int lengthInSeconds;
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        this.title = title;
        this.author = author;
        this.lengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Length (seconds): " + lengthInSeconds);
        Console.WriteLine("Number of Comments: " + GetNumberOfComments());

        Console.WriteLine("Comments:");
        foreach (Comment comment in comments)
        {
            Console.WriteLine("Commenter: " + comment.GetCommenterName());
            Console.WriteLine("Comment Text: " + comment.GetCommentText());
            Console.WriteLine(); 
            Console.WriteLine();
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Create videos
        Video video1 = new Video("Video 1", "Author 1", 120);
        Comment comment11 = new Comment("Commenter 1", "Comment 1 for Video 1");
        Comment comment12 = new Comment("Commenter 2", "Comment 2 for Video 1");
        Comment comment13 = new Comment("Commenter 3", "Comment 3 for Video 1");
        video1.AddComment(comment11);
        video1.AddComment(comment12);
        video1.AddComment(comment13);

        Video video2 = new Video("Video 2", "Author 2", 180);
        Comment comment21 = new Comment("Commenter 1", "Comment 1 for Video 2");
        Comment comment22 = new Comment("Commenter 2", "Comment 2 for Video 2");
        video2.AddComment(comment21);
        video2.AddComment(comment22);

        Video video3 = new Video("Video 3", "Author 3", 150);
        Comment comment31 = new Comment("Commenter 1", "Comment 1 for Video 3");
        Comment comment32 = new Comment("Commenter 2", "Comment 2 for Video 3");
        Comment comment33 = new Comment("Commenter 3", "Comment 3 for Video 3");
        Comment comment34 = new Comment("Commenter 4", "Comment 4 for Video 3");
        video3.AddComment(comment31);
        video3.AddComment(comment32);
        video3.AddComment(comment33);
        video3.AddComment(comment34);

        // Create list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details
        foreach (Video video in videos)
        {
            video.PrintVideoDetails();
            Console.WriteLine();
        }
    }
}
