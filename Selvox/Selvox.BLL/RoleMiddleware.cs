public class RoleMiddleware
{
    private readonly RequestDelegate _next;

    public RoleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var path = context.Request.Path;
        var userRole = context.Session.GetString("UserRole");

        if (path.StartsWithSegments("/admin") && userRole != "admin" ||
            path.StartsWithSegments("/employer") && userRole != "employer" ||
            path.StartsWithSegments("/jobseeker") && userRole != "jobseeker")
        {
            context.Response.StatusCode = 403; // Forbidden
            await context.Response.WriteAsync("You do not have access to this resource.");
            return;
        }

        await _next(context);
    }
}

public static class RoleMiddlewareExtensions
{
    public static IApplicationBuilder UseRoleMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RoleMiddleware>();
    }
}