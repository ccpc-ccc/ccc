using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ESC.Utility {
    /// <summary>
    /// 
    /// </summary>
    public class RouteConvention : IApplicationModelConvention {
        private readonly AttributeRouteModel _centralPrefix;
        public RouteConvention(IRouteTemplateProvider routeTemplateProvider) {
            _centralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }
        public void Apply(ApplicationModel application) {
            foreach(var controller in application.Controllers) {
                var matchedSelectors=controller.Selectors.Where(x=>x.AttributeRouteModel!=null).ToList();
                if(matchedSelectors.Any()) {
                    foreach(var selectorModel in matchedSelectors) {
                        selectorModel.AttributeRouteModel=AttributeRouteModel.CombineAttributeRouteModel(_centralPrefix,selectorModel.AttributeRouteModel);
                    }
                }
                matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();
                if (matchedSelectors.Any()) {
                    foreach (var selectorModel in matchedSelectors) {
                        selectorModel.AttributeRouteModel =_centralPrefix;
                    }
                }
            }
        }
    }
}
