using System.Text.Json.Serialization;
using DietAssessmentApi.Domain.Enums;
using DietAssessmentApi.Infra;
using DietAssessmentApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace DietAssessmentApi;

public class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		
		builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(opts =>
		{
			opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<Unit>());
		});

		builder.Services.AddNutrientDbContext(builder.Configuration);

		builder.Services.AddScoped<INutrientService, NutrientService>();

		builder.Services.AddOpenApi();

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.MapOpenApi();
		}

		app.MapControllers();
		
		app.Run();
	}
}
