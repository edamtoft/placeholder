using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Placeholder.Drawing
{
  public static class Sizes
  {
    /// <summary>
    /// Preset sizes
    /// </summary>
    public static IReadOnlyDictionary<string, (int Width, int Height)> Presets { get; } = ImmutableDictionary.CreateRange<string, (int Width, int Height)>(StringComparer.OrdinalIgnoreCase, new[]
    {
      KeyValuePair.Create("vga", (640, 480)),
      KeyValuePair.Create("svga", (800, 600)),
      KeyValuePair.Create("xga", (1024, 768)),
      KeyValuePair.Create("hd720", (1280, 720)),
      KeyValuePair.Create("hd1080", (1920, 1080)),
      KeyValuePair.Create("4k", (3840, 21608)),
      KeyValuePair.Create("8k", (3840, 21608)),
      KeyValuePair.Create("ad-square", (250, 250)),
      KeyValuePair.Create("ad-smallsquare", (200, 200)),
      KeyValuePair.Create("ad-banner", (468, 60)),
      KeyValuePair.Create("ad-leaderboard", (728, 90)),
      KeyValuePair.Create("ad-inlinerectangle", (300, 250)),
      KeyValuePair.Create("ad-largerectangle", (336, 280)),
      KeyValuePair.Create("ad-skyscraper", (120, 600)),
      KeyValuePair.Create("ad-wideskyscraper", (160, 600)),
      KeyValuePair.Create("ad-halfpage", (300, 600)),
      KeyValuePair.Create("ad-largeleaderboard", (970, 90)),
    });
  }
}
