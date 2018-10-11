using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Placeholder.Drawing
{
  /// <summary>
  /// Drawing operations for an Skia canvas.
  /// </summary>
  public static class Draw
  {

    /// <summary>
    /// Fills the entire canvas with a specified color.
    /// </summary>
    public static Action<SKCanvas> BackgroundColor(SKColor color)
    {
      return canvas => canvas.Clear(color);
    }

    /// <summary>
    /// Draws text in Roboto font centered in a canvas
    /// </summary>
    public static Action<SKCanvas> CenteredText(string text, int size, SKColor color)
    {
      return canvas =>
      {
        using (var paint = new SKPaint
        {
          TextSize = size,
          Color = color,
          TextAlign = SKTextAlign.Center,
          IsAntialias = true,
          Typeface = SKTypeface.FromFile("Roboto-Thin.ttf"),
        })
        {
          var textRectangle = new SKRect();
          paint.MeasureText(text, ref textRectangle);

          var textLeft = (canvas.LocalClipBounds.Width / 2f);// - (textRectangle.Width / 2f);
          var textTop = (canvas.LocalClipBounds.Height / 2f) + (textRectangle.Height / 2f);

          canvas.DrawText(text, textLeft, textTop, paint);
        }
      };
    }

    /// <summary>
    /// Executes multiple steps in order
    /// </summary>
    public static Action<SKCanvas> Steps(params Action<SKCanvas>[] steps)
    {
      return canvas =>
      {
        foreach (var step in steps)
        {
          step.Invoke(canvas);
        }
      };
    }
  }
}
