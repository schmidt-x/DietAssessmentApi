using System.Reflection;
using DietAssessmentApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietAssessmentApi.Data;

public class NutrientContext : DbContext
{
	public DbSet<Nutrient> Nutrients { get; set; }
	public DbSet<NutrientReport> Reports { get; set; }
	public DbSet<Supplement> Supplements { get; set; }

	public NutrientContext(DbContextOptions<NutrientContext> options) : base(options)
	{ }
	
	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}