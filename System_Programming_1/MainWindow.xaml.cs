using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace System_Programming_1;

public partial class MainWindow : NavigationWindow
{

    public MainWindow()
    {
        InitializeComponent();
        var page = new Page1();
        NavigationService.Navigate(page);
    }

}