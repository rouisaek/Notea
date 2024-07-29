namespace Notea.Api.Routes;

public static class BaseRoutes
{
    public const string USER = "api/v{version:apiVersion}/users";
    public const string NOTEBOOK = $"{USER}/{{userId}}/notebooks";
    public const string NOTE = $"{NOTEBOOK}/{{notebookId}}/notes/";
}