using System.Diagnostics;
using System.Windows;

namespace System_Programming_1;
public partial class RunNewTask : Window
{
    public RunNewTask()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(txtbox.Text))
        {
            MessageBox.Show("Enter File Name or Path", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            return;
        }
        try
        {
            Process.Start(txtbox.Text);
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}","Error",MessageBoxButton.OK,MessageBoxImage.Error);
        }
    }
}
