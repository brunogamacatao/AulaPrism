using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prism1.Extensions
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null) return null;

            ImageSource image = ImageSource.FromResource(Source);

            return image;
        }  
    }
}
