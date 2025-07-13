namespace DietAssessmentApi.Domain.Entities;

/// <summary>
/// Отчет о потреблении нутриентов.
/// </summary>
public class NutrientReport
{
	/// <summary>
	/// Уникальный идентификатор.
	/// </summary>
	public int Id { get; set; }
	
	/// <summary>
	/// Фактическое потребление.
	/// </summary>
	public double Intake { get; set; }
	
	/// <summary>
	/// Рекомендованное дополнительное потребление из обычного питания для компенсации дефицита.
	/// </summary>
	public double RecFromFood { get; set; }
	
	/// <summary>
	/// Рекомендованное дополнительное потребление из БАДов для компенсации дефицита.
	/// </summary>
	public double RecFromSupplement { get; set; }
	
	/// <summary>
	/// Внешний ключ на Nutrient(<see cref="Nutrient.Id"/>).
	/// </summary>
	public int NutrientId { get; set; }
	
	/// <summary>
	/// Навигационное свойство на таблицу <see cref="DietAssessmentApi.Domain.Entities.Nutrient"/>.
	/// </summary>
	public Nutrient Nutrient { get; set; } = null!;
}