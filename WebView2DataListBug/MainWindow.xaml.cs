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
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WebView2DataListBug
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            // Load HTML content from index.html file
            using var indexHtmlStream = typeof(MainWindow).Assembly.GetManifestResourceStream("WebView2DataListBug.index.html");
            using var indexHtmlReader = new StreamReader(indexHtmlStream);
            var indexHtmlContent = indexHtmlReader.ReadToEnd();

            // Load the HTML into the WebView2 control
            wv2.CoreWebView2Initialized += (_, __) =>
            {
                wv2.NavigateToString(indexHtmlContent);
            };
            _ = wv2.EnsureCoreWebView2Async();
        }
    }
}
