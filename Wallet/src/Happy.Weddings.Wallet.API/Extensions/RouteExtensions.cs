using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Linq;

namespace Happy.Weddings.Wallet.API.Extensions
{
    /// <summary>
    /// Adds the route url prefixes
    /// </summary>
    public static class RouteExtensions
    {
        /// <summary>
        /// Uses the general route prefix.
        /// </summary>
        /// <param name="opts">The opts.</param>
        /// <param name="routeAttribute">The route attribute.</param>
        public static void UseGeneralRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
        {
            opts.Conventions.Add(new RoutePrefixConvention(routeAttribute));
        }

        /// <summary>
        /// Uses the general route prefix.
        /// </summary>
        /// <param name="opts">The opts.</param>
        /// <param name="prefix">The prefix.</param>
        public static void UseGeneralRoutePrefix(this MvcOptions opts, string prefix)
        {
            opts.UseGeneralRoutePrefix(new RouteAttribute(prefix));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention" />
    public class RoutePrefixConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel _routePrefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoutePrefixConvention"/> class.
        /// </summary>
        /// <param name="route">The route.</param>
        public RoutePrefixConvention(IRouteTemplateProvider route)
        {
            _routePrefix = new AttributeRouteModel(route);
        }

        /// <summary>
        /// Called to apply the convention to the <see cref="T:Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel" />.
        /// </summary>
        /// <param name="application">The <see cref="T:Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel" />.</param>
        public void Apply(ApplicationModel application)
        {
            foreach (var selector in application.Controllers.SelectMany(c => c.Selectors))
            {
                if (selector.AttributeRouteModel != null)
                {
                    selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_routePrefix, selector.AttributeRouteModel);
                }
                else
                {
                    selector.AttributeRouteModel = _routePrefix;
                }
            }
        }
    }
}
