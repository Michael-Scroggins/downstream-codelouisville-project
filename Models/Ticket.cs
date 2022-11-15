﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Downstream.Models
{
    public class Ticket
    {

        public int Id { get; set; }
        public string? Title { get; set; }

        [DisplayName("Issue Type")]
        public string? IssueType { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Ticket Entered")]
        public DateTime TimeEntered { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Required Resolution Time")]
        public DateTime RequiredResolutionTime { get; set; }


    }
}
 