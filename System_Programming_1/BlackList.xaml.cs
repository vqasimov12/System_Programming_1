using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace System_Programming_1;

public partial class BlackList : Page, INotifyPropertyChanged
{
    private List<Process> programs = [];

    public List<Process> Programs { get => programs; set{ programs = value; OnPropertyChanged(); }}
    public BlackList()
    {

        InitializeComponent();
        DataContext = this;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void Remove_Button(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var process = button?.DataContext as Process;
        if (process is null) return;
        var p = Programs;
        Programs.Remove(process);
        Programs = new(p);
    }

    private void ProcessesPage_button(object sender, RoutedEventArgs e)
    {
        var page = new Page1();
        page.BlackList = Programs;
        page.GetPrograms(null, null);
        NavigationService.Navigate(page);
    }
}
