
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; }
        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; }

        public ApplicationUser User { get; set; }

        public Notification Notification { get; }

        public bool IsRead { get; set; }

        protected UserNotification()
        {
            
        }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (User == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (Notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }
            User = user;
            Notification = notification;
        }
    }
}