using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using static ODataBookStore.Model.EntityDataModel;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.EntityFrameworkCore;
using ODataBookStore.Model;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookLists"));
builder.Services.AddControllers();

builder.Services.AddControllers().AddOData(opt => opt.Select().Filter()
    .Count().OrderBy().Expand().SetMaxTop(100)
    .AddRouteComponents("odata", GetEdmModel()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseODataBatching();

app.UseRouting();

app.Use(next => context =>
{
    var endpoint = context.GetEndpoint();
    if(endpoint == null)
        return next(context);

    IEnumerable<string> templates;
    IODataRoutingMetadata metadata = endpoint.Metadata.GetMetadata<IODataRoutingMetadata>();
    if(metadata != null)
        templates = metadata.Template.GetTemplates();

    return next(context);
});

//app.UseMiddleware<ODataQueryValidationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Book>("Books");
    builder.EntitySet<Press>("Presses");
    return builder.GetEdmModel();
}

//public class ODataQueryValidationMiddleware
//{
//    private readonly RequestDelegate _next;

//    public ODataQueryValidationMiddleware(RequestDelegate next)
//    {
//        _next = next;
//    }

//    public async Task Invoke(HttpContext context)
//    {
//        if (context.Request.Path.StartsWithSegments("/odata"))
//        {
//            var query = context.Request.QueryString.ToString();

//            if (query.Contains("$orderby") && query.Contains("1 tu ngu ban cho rang do la du lieu nhay cam neu dung vao no"))
//            {
//                context.Response.StatusCode = 400;
//                await context.Response.WriteAsync("Invalid query");
//                return;
//            }
//        }

//        await _next(context);
//    }
//}
