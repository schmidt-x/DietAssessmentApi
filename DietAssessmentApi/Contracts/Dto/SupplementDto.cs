namespace DietAssessmentApi.Contracts.Dto;

public class SupplementDto(int id, string name, string thumbnailUrl)
{
	public int Id { get; } = id;
	public string Name { get; } = name;
	public string ThumbnailUrl { get; } = thumbnailUrl;
}