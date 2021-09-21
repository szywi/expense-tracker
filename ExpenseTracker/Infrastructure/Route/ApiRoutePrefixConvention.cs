using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ExpenseTracker.Infrastructure.Route
{
    internal sealed class ApiRoutePrefixConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel routePrefix;

        public ApiRoutePrefixConvention()
        {
            this.routePrefix = new AttributeRouteModel(new RouteAttribute("api"));
        }

        public void Apply(ApplicationModel application)
        {
            foreach (var selector in application.Controllers.SelectMany(c => c.Selectors))
            {
                selector.AttributeRouteModel = selector.AttributeRouteModel != null
                    ? AttributeRouteModel.CombineAttributeRouteModel(this.routePrefix, selector.AttributeRouteModel)
                    : this.routePrefix;
            }
        }
    }
}