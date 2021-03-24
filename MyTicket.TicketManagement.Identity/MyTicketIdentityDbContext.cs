using MyTicket.TicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyTicket.TicketManagement.Identity
{
    public class MyTicketIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyTicketIdentityDbContext(DbContextOptions<MyTicketIdentityDbContext> options) : base(options)
        {
        }
    }
}
