using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using verklegt.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace verklegt.DAL
{
	public class AppContext : DbContext
	{
		// Látum default constructorinn vera tengingu við NewsContext reference-ið í web.config
		public AppContext()
			: base("AppContext")
		{

		}

		// Búum News töfluna fyrir gagnagrunninn sem á að mappa við NewsItem klasann.
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<Point> Points { get; set; }
		public DbSet<SubPart> SubParts { get; set; }
		public DbSet<SubPartText> SubPartTexts { get; set; }
		public DbSet<Subtitle> Subtitles { get; set; }
		public DbSet<Title> Titles { get; set; }


		// Kemur í veg fyrir að EntityFramework-ið breyti nafni töflunnar í fleirtölu þegar hún býr hana til.
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}