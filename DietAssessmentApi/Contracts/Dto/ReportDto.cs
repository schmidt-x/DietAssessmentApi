namespace DietAssessmentApi.Contracts.Dto;

public class ReportDto(int id, double intake, double recFromFood, double recFromSupplement, NutrientDto nutrient)
{
	public int Id { get; } = id;
	public double Intake { get; } = intake;
	public double RecFromFood { get; } = recFromFood;
	public double RecFromSupplement { get; } = recFromSupplement;
	public bool IsDeficient => Intake < (Nutrient.RecommendedIntakeFrom ?? Nutrient.RecommendedIntakeTo);
	public NutrientDto Nutrient { get; } = nutrient;
}