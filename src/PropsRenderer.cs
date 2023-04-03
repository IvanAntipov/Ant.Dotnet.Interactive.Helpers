using System.Text;
using Microsoft.DotNet.Interactive;
namespace Ant.Dotnet.Interactive.Helpers
{
    public class PropsRenderer
    {
        private readonly bool _quiet;
        public readonly DisplayedValue _d;
        public readonly StringBuilder _sb = new();
        
        public PropsRenderer(bool quiet = false)
        {
            _quiet = quiet;
            if(!quiet)
                _d = Kernel.display("");
        }
    
        public void DisplayProp(string name, object value, int level = 0)
        {
            var tab = "  ";
            var spaces = String.Join("", Enumerable.Range(0, level).Select(_ => tab));
            _sb.AppendLine($"{spaces}{name}: {value}");
            if(!_quiet)
                _d.Update(_sb.ToString());
        }
    }
}