using System.Threading;
using System.Threading.Tasks;
using DietAssessmentApi.Contracts;
using DietAssessmentApi.Extensions;
using DietAssessmentApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DietAssessmentApi.Controllers;

[Controller, Route("reports")]
public class ReportController : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetReport([FromServices] INutrientService service, CancellationToken ct)
	{
		var reports = await service.GetReportsAsync(ct);
		var supplements = await service.GetRecommendedSupplementsAsync(reports, ct);
		
		var response = new ReportResponse(reports.ToDto(), supplements.ToDto());
		return Ok(response);
	}
}