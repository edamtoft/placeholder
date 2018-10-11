using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Placeholder.Controllers;
using Placeholder.Drawing;
using Placeholder.Options;

namespace Placeholder.Pages
{
  public class IndexModel : PageModel
  {
    public IndexModel(IOptions<ImageOptions> imageOptions, IOptions<PageOptions> pageOptions)
    {
      ImageOptions = imageOptions.Value;
      PageOptions = pageOptions.Value;
    }

    public ImageOptions ImageOptions { get; }
    public PageOptions PageOptions { get; }

    public string BannerUrl(int width, int height) => Url.Action(nameof(PlaceholderController.Rectangle), "Placeholder", new { text = PageOptions.Banner, width, height });

    public IEnumerable<(string Title, string Url)> Examples()
    {
      yield return ("Basic Usage", Url.Action(nameof(PlaceholderController.Rectangle), "Placeholder", new { width = 480, height = 240 }));
      yield return ("Colors", Url.Action(nameof(PlaceholderController.Rectangle), "Placeholder", new { width = 480, height = 240, bgColor = ImageOptions.ForegroundColor, fgColor = ImageOptions.BackgroundColor }));
      yield return ("Custom Text", Url.Action(nameof(PlaceholderController.Rectangle), "Placeholder", new { width = 480, height = 240, text = "Sample" }));
    }

    public IEnumerable<(string Preset, string Url, int Width, int Height)> Presets()
    {
      return from preset in Sizes.Presets
             orderby preset.Key.StartsWith("ad"), preset.Value.Width
             let url = Url.Action(nameof(PlaceholderController.Preset), "Placeholder", new { preset = preset.Key })
             select (preset.Key, url, preset.Value.Width, preset.Value.Height);
    }

    public void OnGet()
    {
    }
  }
}