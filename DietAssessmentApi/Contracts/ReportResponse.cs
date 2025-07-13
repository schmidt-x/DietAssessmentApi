using System.Collections.Generic;
using DietAssessmentApi.Contracts.Dto;

namespace DietAssessmentApi.Contracts;

public record ReportResponse(IReadOnlyList<ReportDto> Reports, IReadOnlyList<SupplementDto> Supplements);