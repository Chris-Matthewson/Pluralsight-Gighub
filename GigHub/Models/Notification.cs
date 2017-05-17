using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; }
        public NotificationType Type { get; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenu { get; set; }

        [Required]
        public Gig Gig { get; set; }

        protected Notification()
        {
            
        }

        public Notification(Gig gig, NotificationType type)
        {
            if (gig == null)
            {
                throw new ArgumentNullException(nameof(gig));
            }

            Gig = gig;
            Type = type;
            DateTime = DateTime.Now;
        }
    }
}