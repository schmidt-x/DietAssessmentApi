using DietAssessmentApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DietAssessmentApi.Infra;

// ReSharper disable once InconsistentNaming
public static class IServiceCollectionExtensions
{
	public static IServiceCollection AddNutrientDbContext(this IServiceCollection services, ConfigurationManager configuration)
	{
		var cnnString = configuration.GetPostgresConnectionString();
		return services.AddDbContext<NutrientContext>(optsBuilder => optsBuilder.UseNpgsql(cnnString));
	}
}