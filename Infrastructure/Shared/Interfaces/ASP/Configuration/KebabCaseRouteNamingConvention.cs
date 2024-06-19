using Infrastructure.Shared.Interfaces.ASP.Configuration.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Infrastructure.Shared.Interfaces.ASP.Configuration;

public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null 
            ? new AttributeRouteModel { Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase()) } 
            : null;
    }
    /// <summary>
    ///  Apply the kebab case route naming convention.
    /// </summary>
    /// <param name="controller"></param>
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors) 
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);

        foreach (var selector in controller.Actions.SelectMany(a => a.Selectors)) 
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        
    }
}