using MusicCatalogue.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MusicCatalogue.DAL
{

    public class CatalogueContext : DbContext
    {

        public CatalogueContext() : base("CatalogueContext")
        {
        }

        public DbSet<Catalogue> Catalogue { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}