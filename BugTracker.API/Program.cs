
using BugTracker.BLL;
using BugTracker.DAL;
using BugTracker.DAL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//Service cors
builder.Services.AddCors(p => p.AddPolicy("corspolicy", builder =>
{
    builder.WithOrigins("").
            AllowAnyMethod()
           .AllowAnyHeader();
           
}));
#region DAL
builder.Services.AddTransient<IOrganizationsDb, OrganizationsDb>();
builder.Services.AddTransient<IAppUsersDb, AppUsersDb>();
builder.Services.AddTransient<IProjectsDb, ProjectsDb>();
builder.Services.AddTransient<IProjectUserDb, ProjectUserDb>();
builder.Services.AddTransient<ITasksDb, TasksDb>();
builder.Services.AddTransient<ITaskHistoryDb, TaskHistoryDb>();
builder.Services.AddTransient<ITaskCommentsDb, TaskCommentsDb>();
builder.Services.AddTransient<IAttachmentMasterDb, AttachmentMasterDb>();
builder.Services.AddTransient<ITaskAttachmentsDb, TaskAttachmentsDb>();

#endregion

#region BLL
builder.Services.AddTransient<IOrganizationsBs, OrganizationsBs>();
builder.Services.AddTransient<IAppUsersBs, AppUsersBs>();
builder.Services.AddTransient<IProjectsBs, ProjectsBs>();
builder.Services.AddTransient<IProjectUserBs, ProjectUserBs>();
builder.Services.AddTransient<ITasksBs, TasksBs>();
builder.Services.AddTransient<ITaskHistoryBs, TaskHistoryBs>();
builder.Services.AddTransient<ITaskCommentsBs, TaskCommentsBs>();
builder.Services.AddTransient<IAttachmentMasterBs, AttachmentMasterBs>();
builder.Services.AddTransient<ITaskAttachmentsBs, TaskAttachmentsBs>();

#endregion


builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(@"Server=MEHROZQAZI-PC\SQLEXPRESS;Database=BugTrackerA;Trusted_Connection=True"));


//enable cors

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});
app.UseCors("corspolicy");
app.UseRouting();
app.MapControllers();
app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}