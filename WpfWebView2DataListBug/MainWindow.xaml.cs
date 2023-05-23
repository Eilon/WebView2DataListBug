using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWebView2DataListBug
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Load HTML content from index.html file
            using var indexHtmlStream = typeof(MainWindow).Assembly.GetManifestResourceStream("WpfWebView2DataListBug.index.html");
            using var indexHtmlReader = new StreamReader(indexHtmlStream);
            var indexHtmlContent = indexHtmlReader.ReadToEnd();

            // Load the HTML into the WebView2 control
            wv2.CoreWebView2InitializationCompleted += (_, __) =>
            {
                wv2.NavigateToString(indexHtmlContent);
            };
            _ = wv2.EnsureCoreWebView2Async();
        }
    }
}
