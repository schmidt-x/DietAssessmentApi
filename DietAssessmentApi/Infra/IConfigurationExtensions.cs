using System;
using Microsoft.Extensions.Configuration;

namespace DietAssessmentApi.Infra;

// ReSharper disable once InconsistentNaming
public static class IConfigurationExtensions
{
	public static string GetPostgresConnectionString(this IConfiguration configuration)
	{
		const string postgres = "Postgres";
		
		var cnn = configuration.GetConnectionString(postgres);
		if (string.IsNullOrWhiteSpace(cnn))
		{
			throw new Exception($"Connection string '{postgres}' is required");
		}
		
		return cnn;
	}
}