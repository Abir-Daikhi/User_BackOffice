using UserBackOffice.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UserBackOffice.Data
{
    public class DataContext : DbContext
    {
        

        public DataContext(): base("DataContext")
        {
        }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Taxe> Taxes { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Devise> Devises { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<Privilege> Privilege { get;}
        public DbSet<AccessView> AccessView { get; }
        public DbSet<Site> Site { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<ImgProduit> ImgProduits { get; set; }
        public DbSet<Pays> Pays { get; set; }
        public DbSet<Ville> Villes { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
