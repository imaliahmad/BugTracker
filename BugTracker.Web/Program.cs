using BugTracker.BLL;
using BugTracker.DAL;
using BugTracker.DAL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


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
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
    );
app.Run();
