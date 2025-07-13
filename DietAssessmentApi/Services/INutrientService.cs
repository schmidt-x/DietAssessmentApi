using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DietAssessmentApi.Domain.Entities;

namespace DietAssessmentApi.Services;

public interface INutrientService
{
	Task<IReadOnlyList<NutrientReport>> GetReportsAsync(CancellationToken ct);
	Task<IReadOnlyList<Supplement>> GetRecommendedSupplementsAsync(IEnumerable<NutrientReport> reports, CancellationToken ct);
}