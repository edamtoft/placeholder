using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Placeholder.Drawing;
using Placeholder.Options;
using SkiaSharp;

namespace Placeholder.Controllers
{
  [ResponseCache(Duration = 31536000, Location = ResponseCacheLocation.Any)]
  public class PlaceholderController : ControllerBase
  {
    private readonly ImageOptions _options;

    public PlaceholderController(IOptions<ImageOptions> options)
    {
      _options = options.Value;
    }

    [HttpGet("/{width:int}x{height:int}/{bgColor?}/{fgColor?}")]
    public IActionResult Rectangle(int width, int height, string bgColor, string fgColor, string text = null, int? textSize = null)
    {
      if (width * height > _options.MaxSize)
      {
        return UnprocessableEntity();
      }

      if (width <= 0 || height <= 0 ||
        !SKColor.TryParse(bgColor ?? _options.BackgroundColor, out var skBgColor) || 
        !SKColor.TryParse(fgColor ?? _options.ForegroundColor, out var skFgColor))
      {
        return BadRequest();
      }

      var image = Draw.Steps(
        Draw.BackgroundColor(skBgColor),
        Draw.CenteredText(text ?? $"{width}×{height}", textSize ?? _options.TextSize, skFgColor));

      return new ImageResult(width, height, image);
    }

    [HttpGet("/{width:int}×{height:int}/{bgColor?}/{fgColor?}")]
    public IActionResult RectangleTimesSymbolRedirect(int width, int height, string bgColor, string fgColor, string text = null, int? textSize = null)
    {
      return RedirectToActionPermanent(nameof(Rectangle), new { width, height, bgColor, fgColor, text, textSize });
    }

    [HttpGet("/{size:int}/{bgColor?}/{fgColor?}")]
    public IActionResult Square(int size, string bgColor, string fgColor, string text = null, int? textSize = null)
    {
      
      return Rectangle(size, size, bgColor, fgColor, text, textSize);
    }

    [HttpGet("/{preset}/{bgColor?}/{fgColor?}")]
    public IActionResult Preset(string preset, string bgColor, string fgColor, string text = null, int? textSize = null)
    {
      if (!Sizes.Presets.TryGetValue(preset, out var size))
      {
        return NotFound();
      }

      return Rectangle(size.Width, size.Height, bgColor, fgColor, text, textSize);
    }
  }
}
