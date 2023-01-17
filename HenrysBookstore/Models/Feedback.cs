using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HenrysBookstore.Models
{
    public class Feedback
    {
        [Required(ErrorMessage = "You must provide your first name")]
        public string fname { get; set; }

        [Required(ErrorMessage = "You must provide your last name")]
        public string lname { get; set; }

        [Required(ErrorMessage = "You must provide an email address")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "You must confirm your email address")]
        [EmailAddress]
        [System.ComponentModel.DataAnnotations.Compare(nameof(email), ErrorMessage = "The provided emails don't match")] 
        public string confirmemail { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "The phone number you provided is not valid")]
        public string phonenumber { get; set; }

        [Required(ErrorMessage = "You must choose a bookstore branch")]
        public string branchname { get; set; }

        [Required(ErrorMessage = "You must choose a bookstore branch")]
        public IEnumerable<SelectListItem> AllBranchOptions { get; set; }

        [Required(ErrorMessage = "You must provide feedback/comments")]
        public string comments { get; set; }
    }
}