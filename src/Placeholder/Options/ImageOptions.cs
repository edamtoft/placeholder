using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placeholder.Options
{
  public class ImageOptions
  {
    public string BackgroundColor { get; set; }
    public string ForegroundColor { get; set; }
    public Dictionary<string, string> Presets { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    public int TextSize { get; set; }
  }
}
