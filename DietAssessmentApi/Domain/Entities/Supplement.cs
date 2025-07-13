using System.Collections.Generic;

namespace DietAssessmentApi.Domain.Entities;

/// <summary>
/// Пищевая добавка.
/// </summary>
public class Supplement
{
	/// <summary>
	/// Уникальный идентификатор.
	/// </summary>
	public int Id { get; set; }
	
	/// <summary>
	/// Наименование добавки.
	/// </summary>
	public required string Name { get; set; }
	
	/// <summary>
	/// Ссылка на изображение-превью.
	/// </summary>
	public required string ThumbnailUrl { get; set; }
	
	/// <summary>
	/// Навигационное свойство на таблицу <see cref="Nutrient"/>.
	/// </summary>
	public IReadOnlyList<Nutrient> Nutrients { get; init; } = [];
}