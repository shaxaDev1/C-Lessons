
using Microsoft.EntityFrameworkCore;
using Xarajat.Api.Entities;

namespace Xarajat.Api.Data;

public class XarajatDbContext : DbContext
{
    public XarajatDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
}
