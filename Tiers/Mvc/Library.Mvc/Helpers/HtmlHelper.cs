using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace Library.Mvc.Helpers
{
    public static class HtmlHelper
    {
        public static MvcHtmlString SpanFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var valueGetter = expression.Compile();
            var span = new TagBuilder("span");
            span.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            if (helper.ViewData.Model != null)
            {
                var value = valueGetter(helper.ViewData.Model);

                if (value != null)
                {
                    span.SetInnerText(value.ToString());
                }

            }


            return MvcHtmlString.Create(span.ToString());
        }
    }
}