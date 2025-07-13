using System;
using System.Linq;
using DietAssessmentApi.Data;
using DietAssessmentApi.Domain.Entities;
using DietAssessmentApi.Domain.Enums;

namespace DietAssessmentApi;

internal static class TestSeeder
{
	public static void Seed(NutrientContext db)
	{
		if (db.Nutrients.Any()) return;
		
		Nutrient[] nutrients = [
			new() { Name = "Алкоголь (спирт)",                  RecommendedIntakeFrom = 0,    RecommendedIntakeTo = 23.6,  Unit = Unit.G },
			new() { Name = "Белки",                             RecommendedIntakeFrom = null, RecommendedIntakeTo = 89,    Unit = Unit.G },
			new() { Name = "Бета-каротин",                      RecommendedIntakeFrom = 0,    RecommendedIntakeTo = 5000,  Unit = Unit.Mcg },
			new() { Name = "Витамин B1 (тиамин)",               RecommendedIntakeFrom = null, RecommendedIntakeTo = 1.5,   Unit = Unit.Mg },
			new() { Name = "Витамин B2 (рибофлавин)",           RecommendedIntakeFrom = null, RecommendedIntakeTo = 1.8,   Unit = Unit.Mg },
			new() { Name = "Витамин B3 (ниацин)",               RecommendedIntakeFrom = null, RecommendedIntakeTo = 20,    Unit = Unit.Mg },
			new() { Name = "Витамин B5 (пантотеновая кислота)", RecommendedIntakeFrom = null, RecommendedIntakeTo = 5,     Unit = Unit.Mg },
			new() { Name = "Витамин B6 (пиродоксин)",           RecommendedIntakeFrom = null, RecommendedIntakeTo = 2,     Unit = Unit.Mg },
			new() { Name = "Витамин B9 (фолиевая кислота)",     RecommendedIntakeFrom = null, RecommendedIntakeTo = 400,   Unit = Unit.Mcg },
			new() { Name = "Витамин B12 (кобаламин)",           RecommendedIntakeFrom = null, RecommendedIntakeTo = 3,     Unit = Unit.Mcg },
			new() { Name = "Витамин C (аскорбиновая кислота)",  RecommendedIntakeFrom = null, RecommendedIntakeTo = 100,   Unit = Unit.Mg },
			new() { Name = "Витамин D (кальциферол)",           RecommendedIntakeFrom = null, RecommendedIntakeTo = 15,    Unit = Unit.Mcg },
			new() { Name = "Витамин E (альфа-токоферол)",       RecommendedIntakeFrom = null, RecommendedIntakeTo = 15,    Unit = Unit.Mg },
			new() { Name = "Вода",                              RecommendedIntakeFrom = 1500, RecommendedIntakeTo = 1600,  Unit = Unit.G },
			new() { Name = "Железо",                            RecommendedIntakeFrom = 10,   RecommendedIntakeTo = 45,    Unit = Unit.Mg },
			new() { Name = "Жиры",                              RecommendedIntakeFrom = 45,   RecommendedIntakeTo = 92,    Unit = Unit.G },
			new() { Name = "Йод",                               RecommendedIntakeFrom = 150,  RecommendedIntakeTo = 1000,  Unit = Unit.Mcg },
			new() { Name = "Калий",                             RecommendedIntakeFrom = null, RecommendedIntakeTo = 2500,  Unit = Unit.Mg },
			new() { Name = "Кальций",                           RecommendedIntakeFrom = null, RecommendedIntakeTo = 1000,  Unit = Unit.Mg },
			new() { Name = "Крахмал",                           RecommendedIntakeFrom = 0,    RecommendedIntakeTo = 551,   Unit = Unit.G },
			new() { Name = "Магний",                            RecommendedIntakeFrom = 420,  RecommendedIntakeTo = 4000,  Unit = Unit.Mg },
			new() { Name = "Натрий",                            RecommendedIntakeFrom = 1300, RecommendedIntakeTo = 4900,  Unit = Unit.Mg },
			new() { Name = "Пищевые волокна",                   RecommendedIntakeFrom = 0,    RecommendedIntakeTo = 250,   Unit = Unit.G },
			new() { Name = "Ретинол (Витамин A)",               RecommendedIntakeFrom = null, RecommendedIntakeTo = 900,   Unit = Unit.Mcg },
			new() { Name = "Сахара",                            RecommendedIntakeFrom = 0,    RecommendedIntakeTo = 68.75, Unit = Unit.G },
			new() { Name = "Селен",                             RecommendedIntakeFrom = 70,   RecommendedIntakeTo = 400,   Unit = Unit.Mcg },
			new() { Name = "Углеводы",                          RecommendedIntakeFrom = 0,    RecommendedIntakeTo = 392,   Unit = Unit.G },
			new() { Name = "Фосфор",                            RecommendedIntakeFrom = 700,  RecommendedIntakeTo = 4000,  Unit = Unit.Mg },
			new() { Name = "Хлор",                              RecommendedIntakeFrom = null, RecommendedIntakeTo = 2300,  Unit = Unit.Mg },
			new() { Name = "Цинк",                              RecommendedIntakeFrom = 12,   RecommendedIntakeTo = 50,    Unit = Unit.Mg },
			new() { Name = "Энергия",                           RecommendedIntakeFrom = null, RecommendedIntakeTo = 2750,  Unit = Unit.Kcal }
		];
		
		var rnd = new Random();
		
		var reports = nutrients.Select(n => new NutrientReport
		{
			Intake = rnd.Next(0, (int)n.RecommendedIntakeTo + 1),
			RecFromFood = rnd.Next(1, (int)Math.Ceiling(n.RecommendedIntakeTo / 2)),
			RecFromSupplement = rnd.Next(1, (int)Math.Ceiling(n.RecommendedIntakeTo / 2)),
			Nutrient = n
		}).ToList();
		
		var supplements = new[] { "Supplement 1", "Supplement 2", "Supplement 3" }
			.Select(name =>
			{
				var relatedNutrientCount = rnd.Next(5, nutrients.Length / 2);
				
				var randomNutrients = Enumerable.Range(0, relatedNutrientCount)
					.Select(_ => nutrients[rnd.Next(0, nutrients.Length)])
					.Distinct()
					.ToList();
				
				return new Supplement { Name = name, ThumbnailUrl = "link/to/thumbnail", Nutrients = randomNutrients };
			})
			.ToList();
		
		db.Reports.AddRange(reports);
		db.Supplements.AddRange(supplements);
		db.SaveChanges();
	}
}
