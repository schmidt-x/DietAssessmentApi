using DietAssessmentApi.Domain.Enums;

namespace DietAssessmentApi.Domain.Entities;

/// <summary>
/// Питательное вещество.
/// </summary>
public class Nutrient
{
	/// <summary>
	/// Уникальный идентификатор.
	/// </summary>
	public int Id { get; set; }
	
	/// <summary>
	/// Наименование нутриента (например, Белки, Железо, Витамин C, и т.д.).
	/// </summary>
	public required string Name { get; set; }
	
	/// <summary>
	/// Рекомендуемая норма потребления, нижняя граница.
	/// </summary>
	public double? RecommendedIntakeFrom { get; set; }
	
	/// <summary>
	/// Рекомендуемая норма потребления, верхняя граница.
	/// </summary>
	public double RecommendedIntakeTo { get; set; }
	
	/// <summary>
	/// Единица измерения.
	/// </summary>
	public Unit Unit { get; set; }
}