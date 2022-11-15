using Microsoft.AspNetCore.Mvc.Rendering;

namespace Downstream.Models
{
    public class TicketIssueTypeViewModel
    {

        public List<Ticket>? Tickets { get; set; }
        public SelectList? IssueTypes { get; set; }
        public string? TicketIssueType { get; set; }

        public string? SearchString { get; set; }


    }
}
