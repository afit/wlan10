// MainWindow.xaml.cs in Wlan10/Wlan10
// Created 2016/07/27
// ©Bertware, visit http://bertware.net
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Net.Bertware.Wlan10.Controller;
using Net.Bertware.Wlan10.Model;

namespace Net.Bertware.Wlan10
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<WlanNetwork> networks = Netshell.GetNetworks();

        public MainWindow()
        {
            InitializeComponent();
            // bind
            lvNetworks.ItemsSource = networks;
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            // Drag and drop will reorder the list (binding with observablelist). So just loop through the list and set the current position.
            for (int i = 0; i < networks.Count; i++)
            {
                networks[i].SetPriority(i + 1);
            }
            // confirm this to the user, to make sure there is no doubt
            MessageBox.Show("The new network order was applied succesfully!");
        }

        private void btnForget_click(object sender, RoutedEventArgs e)
        {
            WlanNetwork net = (WlanNetwork) ((Button) sender).DataContext;
            // Ask politely
            if (
                MessageBox.Show("Are you sure you want to forget " + net.Name + "? This cannot be undone.",
                    "Forget network",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // make windows forget
                net.ForgetNetwork();
                // also remove from the list
                networks.Remove(net); 
            }
        }

        private void btnLearnMore_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start https://github.com/afit/wlan10") { CreateNoWindow = true });
        }
    }
}