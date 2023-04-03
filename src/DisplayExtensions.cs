using Microsoft.DotNet.Interactive.Formatting;
using Microsoft.AspNetCore.Html;
namespace Ant.Dotnet.Interactive.Helpers
{
    public static class DisplayExtensions
    {
        public static void DisplayCollapsed(this object d, params string[] mimeTypes)
        {
            var sw = new StringWriter();
            var fc = new FormatContext(sw);
            Formatter.GetPreferredFormatterFor(d.GetType(), "text/html").Format(d, fc);
            var html = new HtmlString(sw.ToString());
            fc.RequireDefaultStyles();

            var attributes = new HtmlAttributes();
            attributes.AddCssClass("dni-treeview");

            HtmlTag code = new HtmlTag("code", c =>
            {
                var formatter = PlainTextSummaryFormatter.GetPreferredFormatterFor(d?.GetType());

                formatter.Format(d, c);
            });
            var v = PocketViewTags.details[attributes](
                PocketViewTags.summary(
                    PocketViewTags.span[@class: "dni-code-hint"](
                        code)),
                PocketViewTags.div(html));
            System.DisplayExtensions.Display(v, mimeTypes);
        }
    }
}