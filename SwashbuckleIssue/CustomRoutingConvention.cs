using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace SwashbuckleIssue
{
    public class CustomRoutingConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                string template = null;
                if (controller.ControllerType == typeof(ArticlesController))
                {
                    controller.Selectors[0].AttributeRouteModel = new AttributeRouteModel {Template = "api/v1/articles"};
                }
            }
        }
    }
}