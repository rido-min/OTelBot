using Microsoft.Teams.Apps;
using Microsoft.Teams.Apps.Diagnostics;
using Microsoft.Teams.Apps.Handlers;
using Microsoft.Teams.Core.Diagnostics;

string[] activitySources = [CoreTelemetryNames.ActivitySourceName, TeamsBotApplicationTelemetry.ActivitySourceName];
string[] meterNames = [CoreTelemetryNames.MeterName, TeamsBotApplicationTelemetry.MeterName];

WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);
builder.AddServiceDefaults(activitySources, meterNames);
builder.Services.AddTeamsBotApplication();

WebApplication app = builder.Build();

TeamsBotApplication teams = app.UseTeamsBotApplication();

teams.OnMessage(async (context, cancellationToken) =>
{
    await context.SendActivityAsync($"You said: {context.Activity.Text}", cancellationToken);
    await context.SendActivityAsync($"You said2: {context.Activity.Text}", cancellationToken);
});

app.MapDefaultEndpoints();
app.Run();