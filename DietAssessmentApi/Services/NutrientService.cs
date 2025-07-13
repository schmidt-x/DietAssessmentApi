using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DietAssessmentApi.Data;
using DietAssessmentApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietAssessmentApi.Services;

public class NutrientService : INutrientService
{
	private readonly NutrientContext _db;
	
	public NutrientService(NutrientContext db) => _db = db;
	
	public async Task<IReadOnlyList<NutrientReport>> GetReportsAsync(CancellationToken ct)
	{
		var reports = await _db.Reports
			.AsNoTracking()
			.Include(r => r.Nutrient)
			.ToListAsync(ct);
		
		return reports.AsReadOnly();
	}

	public async Task<IReadOnlyList<Supplement>> GetRecommendedSupplementsAsync(IEnumerable<NutrientReport> reports, CancellationToken ct)
	{
		var deficitNutrientIds = reports
			.Where(r => r.Intake < (r.Nutrient.RecommendedIntakeFrom ?? r.Nutrient.RecommendedIntakeTo))
			.Select(r => r.NutrientId)
			.ToList();
		
		var supplements = await _db.Supplements
			.AsNoTracking()
			.Where(s => s.Nutrients.Any(n => deficitNutrientIds.Contains(n.Id)))
			.ToListAsync(ct);
		
		return supplements.AsReadOnly();
	}
}