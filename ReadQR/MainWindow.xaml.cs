using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private void QRCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // 入力された文字列を取得
            // Enterキーが押された場合のみ処理
            if (e.Key == Key.Enter && sender is TextBox textBox)
            {
                string inputText = textBox.Text;
                // スラッシュ (/) をバックスラッシュ (\) に置き換え
                inputText = inputText.Replace('/', '\\');

                if (!string.IsNullOrWhiteSpace(inputText))
                {
                    try
                    {
                        // 入力文字列をエクスプローラーで開く
                        if (Directory.Exists(inputText) || File.Exists(inputText))
                        {
                            Process.Start("explorer.exe", inputText);

                            // エクスプローラーが開いた後、テキストボックスをクリア
                            textBox.Clear();
                            textBox.Focus(); // フォーカスをテキストボックスに戻す
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
}