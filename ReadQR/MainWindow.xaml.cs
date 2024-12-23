using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReadQR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 入力された文字列を取得
            TextBox textBox = sender as TextBox;
            string inputText = textBox.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                try
                {
                    // 入力文字列をエクスプローラーで開く
                    if (Directory.Exists(inputText) || File.Exists(inputText))
                    {
                        Process.Start("explorer.exe", inputText);
                    }
                    else
                    {
                        MessageBox.Show("指定されたパスは存在しません。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"エクスプローラーを開けませんでした: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}