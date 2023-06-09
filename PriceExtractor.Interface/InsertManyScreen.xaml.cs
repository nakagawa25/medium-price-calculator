﻿using PriceExtractor.Enums;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PriceExtractor.Interface
{
    /// <summary>
    /// Interaction logic for InsertManyScreen.xaml
    /// </summary>
    public partial class InsertManyScreen : Window
    {
        public InsertManyScreen()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var negotiation = Tools.ManualInsert.GetNegotiationObject(
                    ((KeyValuePair<string, AssetType>)cbAsset.SelectedItem).Key,
                    ((KeyValuePair<string, AssetType>)cbAsset.SelectedItem).Value,
                    Convert.ToInt32(txtAmount.Text),
                    dpDate.DisplayDate,
                    Convert.ToDouble(txtTotalValue.Text));

                Tools.ManualInsert.Insert(negotiation);
                MessageBox.Show("Sucesso");
                CleanFields();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        private void CleanFields()
        {
            cbAsset.SelectedIndex = -1;
            txtAmount.Clear();
            txtTotalValue.Clear();
        }

        private void FillComboBox()
        {
            var assetsNames = Services.NegotiationAssetService.GetAssetsName();
            cbAsset.ItemsSource = assetsNames;
            cbAsset.DisplayMemberPath = "Key";
        }
    }
}
