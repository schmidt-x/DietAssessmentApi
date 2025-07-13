using DietAssessmentApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietAssessmentApi.Data.Configurations;

public class NutrientConfiguration : IEntityTypeConfiguration<Nutrient>
{
	public void Configure(EntityTypeBuilder<Nutrient> builder)
	{
		builder
			.Property(n => n.Unit)
			.HasConversion<string>();
	}
}