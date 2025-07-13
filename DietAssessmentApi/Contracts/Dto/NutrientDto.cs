using DietAssessmentApi.Domain.Enums;

namespace DietAssessmentApi.Contracts.Dto;

public class NutrientDto(int id, string name, double? recommendedIntakeFrom, double recommendedIntakeTo, Unit unit)
{
	public int Id { get; } = id;
	public string Name { get; } = name;
	public double? RecommendedIntakeFrom { get; } = recommendedIntakeFrom;
	public double? RecommendedIntakeTo { get; } = recommendedIntakeTo;
	public Unit Unit { get; } = unit;
}