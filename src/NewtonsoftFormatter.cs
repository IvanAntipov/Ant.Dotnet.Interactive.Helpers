using System.Text.Json;
using Microsoft.DotNet.Interactive.Formatting;
using Newtonsoft.Json.Linq;
namespace Ant.Dotnet.Interactive.Helpers
{
    public static class NewtonsoftFormatter
    {
        public static void Register()
        {
            var systemTextFormatter = Formatter.GetPreferredFormatterFor(
                    typeof(JsonDocument), "text/html");

            Formatter.Register<JObject>(
                t =>
                {
                    var systemTextObject = JsonDocument.Parse(t.ToString());
                    var sw = new StringWriter();
                    systemTextFormatter.Format(systemTextObject, sw);
                    return sw.ToString();
                },
                "text/html");
            
            Formatter.SetPreferredMimeTypesFor(
                typeof(JObject), "text/html");
        }
    }
}