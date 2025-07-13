using System.Linq;
using System.Collections.Generic;
using DietAssessmentApi.Contracts.Dto;
using DietAssessmentApi.Domain.Entities;

namespace DietAssessmentApi.Extensions;

public static class EntityToDtoExtensions
{
	public static IReadOnlyList<ReportDto> ToDto(this IReadOnlyList<NutrientReport> reports)
	{
		return reports.Select(r =>
		{
			var n = r.Nutrient;
		
			return new ReportDto(
				r.Id,
				r.Intake,
				r.RecFromFood,
				r.RecFromSupplement,
				new NutrientDto(n.Id, n.Name, n.RecommendedIntakeFrom, n.RecommendedIntakeTo, n.Unit));
		}).ToList();
	}
	
	public static IReadOnlyList<SupplementDto> ToDto(this IReadOnlyList<Supplement> supplements)
		=> supplements.Select(s => new SupplementDto(s.Id, s.Name, s.ThumbnailUrl)).ToList();
}