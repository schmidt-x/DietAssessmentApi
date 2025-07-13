using DietAssessmentApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietAssessmentApi.Data.Configurations;

public class SupplementConfiguration : IEntityTypeConfiguration<Supplement>
{
	public void Configure(EntityTypeBuilder<Supplement> builder)
	{
		builder
			.HasMany(s => s.Nutrients)
			.WithMany(); // Unidirectional many-to-many (https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many#unidirectional-many-to-many)
	}
}