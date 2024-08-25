using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;

namespace System_Programming_1;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private List<ProcessModel> programs = [];
    public List<ProcessModel> Programs { get => programs; set { programs = value; OnPropertyChanged(); } }
    System.Timers.Timer Timer { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        Timer = new System.Timers.Timer(1000);
        Timer.Elapsed += GetPrograms;
        Timer.AutoReset = true;
        Timer.Start();
    }
    void GetPrograms(object sender, ElapsedEventArgs e)
    {
        var programs = Process.GetProcesses().ToList();
        foreach (var process in programs)
        {
            try
            {
                Programs.Add(new ProcessModel
                {
                    BasePriority = process.BasePriority,
                    Id = process.Id,
                    ProcessName = process.ProcessName,
                    StartTime = process.StartTime,
                    ThreadCount = process.Threads.Count,
                    Image = process.MainModule?.FileName // No need for null-forgiving operator here
                });
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                // For instance, log the exception or ignore this process
                Console.WriteLine($"Error processing {process.ProcessName}: {ex.Message}");
            }
        }



        //MessageBox.Show(Programs[0]?.MainModule?.FileName);

        //foreach (var process in allProcesses) 
        //     Programs.Add(process);

        //foreach (var process in allProcesses)
        //{
        //    try
        //    {
        //        var cpuCounter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName, true);
        //        cpuCounter.NextValue();
        //        //Thread.Sleep(1000);
        //        double cpuUsage = cpuCounter.NextValue() / Environment.ProcessorCount;
        //        Programs.Add(new ProcessModel
        //        {
        //            Id = process.Id,
        //            ProcessName = process.ProcessName,
        //            Memory = process.WorkingSet64 / (1024 * 1024),
        //            CpuUsage = cpuUsage,
        //            ThreadCount = process.Threads.Count,
        //            StartTime = process.StartTime,
        //            BasePriority = process.BasePriority
        //        });
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Something went wrong please restart program", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}