namespace Selvox.BLL;

public class RoleBasedAuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public RoleBasedAuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var routeValues = context.GetRouteData().Values;
        var controller = routeValues["controller"]?.ToString()?.ToLowerInvariant();
        var action = routeValues["action"]?.ToString()?.ToLowerInvariant();

        // Determine if role-based authorization is needed for this route
        if (RequiresAuthorization(controller))
        {
            // Determine the required role based on controller and action
            var requiredRole = DetermineRequiredRole(controller);

            // Get user's roles (assuming you have implemented role management)
            var userRoles = context.User.Claims
                .Where(c => c.Type == System.Security.Claims.ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            // Check if the user has the required role
            if (!userRoles.Contains(requiredRole))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("You are not authorized to access this resource.");
                return;
            }
        }

        // Proceed to the next middleware if authorized or if no authorization is required
        await _next(context);
    }

    private bool RequiresAuthorization(string controller)
    {
        // Define controllers that require role-based authorization
        // Adjust as per your application's routing and authorization needs
        return controller == "jobseeker" || controller == "admin" || controller == "employer";
    }

    private string DetermineRequiredRole(string controller)
    {
        // Example logic to determine required role based on controller
        return char.ToUpperInvariant(controller[0]) + controller.Substring(1); // Capitalize first letter
    }
}