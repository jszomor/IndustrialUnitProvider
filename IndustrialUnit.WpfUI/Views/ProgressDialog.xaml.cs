using IndustrialUnit.WpfUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace IndustrialUnit.WpfUI.Views
{
  /// <summary>
  /// Interaction logic for ProgressDialog.xaml
  /// </summary>
  public partial class ProgressDialog : Window
  {
    BackgroundWorker _worker = new BackgroundWorker();

    string Path { get; set; }
    bool _isBusy;

    public ProgressDialog(string path)
    {
      InitializeComponent();
      Path = path;
      _isBusy = true;
      _worker.DoWork += BgWorker_DoWork;
      _worker.ProgressChanged += BgWorker_ProgressChanged;
      _worker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;

      _worker.WorkerSupportsCancellation = true;
      _worker.WorkerReportsProgress = true;
      _worker.RunWorkerAsync();
      ShowDialog();
    }

    private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      //if (e.Cancelled)
      //  this.lblStatus.Content = "Stopped!";
      //else
      //  this.lblStatus.Content = "Completed!";

      //this.btnStart.Content = "Start";
      Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate {
        _isBusy = false;
        Close();
      }, null);
    }

    void OnClosing(object sender, CancelEventArgs e)
    {
      e.Cancel = _isBusy;
    }

    private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {

      //this.lblCounter.Content = e.ProgressPercentage;
      //this.progressbar.Value = e.ProgressPercentage;
    }

    private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
    {



      //for (int i = 1; i <= this.counterMax; i++)
      //{
      //  Console.WriteLine(i);

      //  bgWorker.ReportProgress(i);

      //  System.Threading.Thread.Sleep(100);
        FileRepository.LoadIntoDB(Path);

      if (_worker.CancellationPending)
      {
        Console.WriteLine("Thread is exiting....");
        e.Cancel = true;
        return;
      }
      //}
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
      if (_worker != null && _worker.WorkerSupportsCancellation)
      {
        SubTextLabel.Visibility = Visibility.Visible;
        SubTextLabel.Text = "Please wait while process will be cancelled...";
        CancelButton.IsEnabled = false;
        _worker.CancelAsync();
        Close();
      }
    }
  }
}
