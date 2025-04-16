using PriceExtractor.Services;
using System;
using System.Linq;
using System.Windows;

namespace PriceExtractor.Interface
{
    /// <summary>
    /// Interaction logic for DividendScreen.xaml
    /// </summary>
    public partial class DividendScreen : Window
    {
        public DividendScreen()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var filePath = txtFilePath.Text;
                var dividends = DividendsService.GetGroupedDividends(filePath);
                dgDividends.ItemsSource = dividends;

                var totalDividends = dividends.Sum(x => x.TotalValue);

                MessageBox.Show("Sucesso. Total: R$ " + totalDividends);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }
    }
}
