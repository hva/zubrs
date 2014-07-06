using System;
using System.Web.Mvc;
using MarkdownDeep;

namespace Zubrs.Mvc.Helpers
{
    public static class MarkdownHelper
    {
        private static Lazy<Markdown> processorLazy = new Lazy<Markdown>(() => new Markdown());

        public static MvcHtmlString Markdown(this HtmlHelper helper, string text)
        {
            var html = processorLazy.Value.Transform(text);
            return new MvcHtmlString(html);
        }
    }
}