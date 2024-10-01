using Microsoft.AspNetCore.Mvc;

namespace Lab3_PRN231.API.RequestModel;

public class PaginationRequest
{
    [FromQuery(Name = "page-index")]
    public int? PageIndex { get; set; } = 0;

    [FromQuery(Name = "page-size")]
    public int? PageSize { get; set; } = 10;

    [FromQuery(Name = "search")]
    public string? Search { get; set; } = "";

    [FromQuery(Name = "order-by")]
    public string? OrderBy { get; set; } = "";

    [FromQuery(Name = "order-desc")]
    public bool? OrderDesc { get; set; } = false;
}
