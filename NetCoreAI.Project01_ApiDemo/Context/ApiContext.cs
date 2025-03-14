using Microsoft.EntityFrameworkCore;
using NetCoreAI.Project01_ApiDemo.Entities;
namespace NetCoreAI.Project01_ApiDemo.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HELEN\\SQLEXPRESS04;initial catalog=ApiAIDb ;integrated security=true;trustservercertificate=true");
                 //Baglanti configurasyon islemlerimizi yaptik
        }
        public DbSet<Customer> Customers { get; set; } //Veritabanina yansitacagamiz tablo

    }
}
