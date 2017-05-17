using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using GigHub.Controllers;
using System.Linq.Expressions;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime() => DateTime.Parse(string.Format($"{Date} {Time}"));

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<GigsController, ActionResult>> update = 
                    (c => c.Update(null));
                Expression<Func<GigsController, ActionResult>> create = 
                    (c => c.Create(null));
                return (Id != 0) ? update.Name : create.Name;
            }
        }
    }
}