using IndustrialUnit.WpfUI.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace IndustrialUnit.WpfUI.Views
{
  /// <summary>
  /// Interaction logic for ProgressDialog.xaml
  /// </summary>
  public partial class ProgressDialogView : Window
  {
    readonly BackgroundWorker _worker = new();

    string Path { get; set; }

    bool _isBusy;
    readonly Stopwatch stopWatch = new();
    readonly DispatcherTimer timer = new();

    public ProgressDialogView(string path)
    {
      InitializeComponent();

      Path = path;
      _isBusy = true;
      _worker.DoWork += BgWorker_DoWork;
      _worker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
      _worker.RunWorkerAsync();

      timer.Interval = TimeSpan.FromSeconds(1);
      timer.Tick += Timer_Tick;
      timer.Start();

      ShowDialog();
    }

    private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      _isBusy = false;
      TextLabel.Visibility = Visibility.Hidden;
      ProgressBar.Visibility = Visibility.Hidden;
      SubTextLabel.Text = "Process done.";
      OK.Visibility = Visibility.Visible;
      timer.Stop();
    }

    void OnClosing(object sender, CancelEventArgs e)
    {
      MessageBoxResult dialogResult = MessageBox.Show("Transaction cannot be stopped properly. \nForce to kill the program?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);

      if(dialogResult == MessageBoxResult.Yes)
      {
        throw new InvalidProgramException();
      }

      e.Cancel = _isBusy;
    }

    private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      FileRepository.LoadIntoDB(Path);
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
      Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate {
        _isBusy = false;
        Close();
      }, null);
    }

    void Timer_Tick(object sender, EventArgs e)
    {
      stopWatch.Start();
      TimeSpan ts = stopWatch.Elapsed;
      EllpasedTime.Content = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
    }
  }
}
