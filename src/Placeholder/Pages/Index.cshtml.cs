using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
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

    public void OnGet()
    {
    }
  }
}