using System;
namespace pcsHackathon2019.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int ThreadID { get; set; }
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public virtual Thread Thread { get; set; }
    }
}
