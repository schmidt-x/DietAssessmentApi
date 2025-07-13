using System.Threading;
using System.Threading.Tasks;
using DietAssessmentApi.Contracts;
using DietAssessmentApi.Extensions;
using DietAssessmentApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DietAssessmentApi.Controllers;

[ApiController]
[Route("api/reports")]
[Produces("application/json")]
public class ReportController : ControllerBase
{
	/// <summary>
	/// Returns nutrient reports.
	/// </summary>
	[HttpGet]
	[ProducesResponseType<ReportResponse>(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetReport([FromServices] INutrientService service, CancellationToken ct)
	{
		var reports = await service.GetReportsAsync(ct);
		var supplements = await service.GetRecommendedSupplementsAsync(reports, ct);
		
		var response = new ReportResponse(reports.ToDto(), supplements.ToDto());
		return Ok(response);
	}
}