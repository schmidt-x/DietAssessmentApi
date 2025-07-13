using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using DietAssessmentApi.Data;
using DietAssessmentApi.Domain.Enums;
using DietAssessmentApi.Infra;
using DietAssessmentApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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

		builder.Services.AddSwaggerGen(options =>
		{
			var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
		});

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();

			using var scope = app.Services.CreateScope();
			using var db = scope.ServiceProvider.GetRequiredService<NutrientContext>();
			db.Database.Migrate();
		}

		app.MapControllers();
		
		app.Run();
	}
}
