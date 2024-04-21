﻿using System;
using System.Collections.Generic;
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
using TestMODBUS.Models.Services;
using TestMODBUS.Models.Services.Excel;
using TestMODBUS.Services.Settings.Channels;
using TestMODBUS.ViewModels;

namespace TestMODBUS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ChannelsSettingFileManager.UploadDefaultSettings();
            ExportExcel.SetUp();
            ListAvailablePorts.UpdateAvailablePortList();
            InitializeComponent();
            MainViewModel viewModel = new MainViewModel();
            this.DataContext = viewModel;
            this.Closing += viewModel.OnWindowClosing;
        }

        private void PortComboBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListAvailablePorts.UpdateAvailablePortList();
        }
    }
}
