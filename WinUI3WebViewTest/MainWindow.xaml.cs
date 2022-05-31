using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3WebViewTest
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.WebView.CoreWebView2Initialized += WebView_CoreWebView2InitializationCompleted;

            _ = this.WebView.EnsureCoreWebView2Async();
        }

        private void WebView_CoreWebView2InitializationCompleted(WebView2 sender, CoreWebView2InitializedEventArgs args)
        {
            var myObject = new MyObject();

            var interop = this.WebView.CoreWebView2.As<ICoreWebView2Interop>();
            interop.AddHostObjectToScript("myObject", myObject);

            this.WebView.Source = new Uri(@"file:///" + Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"Web/TestPage.html"));
        }
    }
}
