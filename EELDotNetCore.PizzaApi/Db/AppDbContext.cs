using EELDotNetCore.PizzaApi;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EELDotNetCore.PizzaApi.Db
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<PizzaModel> Pizzas { get; set; }
        public DbSet<PizzaExtraModel> PizzaExtras { get; set; }
    }

    [Table("Tbl_Pizza")]
    public class PizzaModel
    {
        [Key]
        [Column("PizzaId")]
        public int Id { get; set; }
        [Column("Pizza")]
        public string Name { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        [NotMapped]
        public string PriceStr { get { return "$" + Price; } }
    }
    [Table("Tbl_PizzaExtra")]
    public class PizzaExtraModel
    {
        [Key]
        [Column("PizzaExtraId")]
        public int Id { get; set; }
        [Column("PizzaExtraName")]
        public string Name { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        [NotMapped]
        public string PriceStr { get { return "$" + Price; } }
    }
}
