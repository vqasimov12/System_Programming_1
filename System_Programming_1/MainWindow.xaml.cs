using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace System_Programming_1;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private string order = "";
    private List<Process> programs = [];
    public List<Process> Programs { get => programs; set { programs = value; OnPropertyChanged(); } }
    System.Timers.Timer Timer { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        order = "Process name";
        Timer = new System.Timers.Timer(1000);
        Timer.Elapsed += GetPrograms;
        Timer.AutoReset = true;
        Timer.Start();
    }
    void GetPrograms(object sender, ElapsedEventArgs e)
    {
        var p = Process.GetProcesses().ToList();
        if (order == "Id")
            Programs = p.OrderBy(z => z.Id).ToList();
        else if (order == "Process name")
            Programs = p.OrderBy(p => p.ProcessName).ToList();
        else if (order == "Handles")
            Programs = p.OrderBy(p => p.HandleCount).ToList();
        else if (order == "Threads")
            Programs = p.OrderBy(p => p.Threads.Count).ToList();
        else if (order == "Memory")
            Programs = p.OrderBy(p => p.PagedMemorySize).ToList();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void BlackList_Button(object sender, RoutedEventArgs e)
    {

    }
    private void Kill_Button(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var process = button?.DataContext as Process;
        process?.Kill();
        GetPrograms(sender, null);
    }

    private void OrderButton_Click(object sender, RoutedEventArgs e)
    {
        var b = sender as Button;
        if (b is null) return;
        order = b.Content.ToString()!;
        GetPrograms(sender, null!);
    }
}