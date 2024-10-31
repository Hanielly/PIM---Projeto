using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public interface IRazorViewRendererService
{
    Task<string> RenderViewToStringAsync(ActionContext actionContext, string viewName, object model);
}