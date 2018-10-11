using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placeholder.Drawing
{
  /// <summary>
  /// Renders an image to the body of the HTTP response
  /// </summary>
  public class ImageResult : ActionResult
  {
    public ImageResult(int width, int height, Action<SKCanvas> drawAction)
    {
      Width = width;
      Height = height;
      _drawAction = drawAction;
    }

    public int Width { get; }
    public int Height { get; }

    private readonly Action<SKCanvas> _drawAction;

    public override void ExecuteResult(ActionContext context)
    {
      using (var bmp = new SKBitmap(Width, Height))
      using (var canvas = new SKCanvas(bmp))
      {
        _drawAction.Invoke(canvas);
        canvas.Flush();

        using (var image = SKImage.FromBitmap(bmp))
        using (var data = image.Encode())
        {
          context.HttpContext.Response.StatusCode = 200;
          context.HttpContext.Response.ContentLength = data.Size;
          context.HttpContext.Response.ContentType = "image/png";
          data.SaveTo(context.HttpContext.Response.Body);
        }
      }
    }
  }
}
