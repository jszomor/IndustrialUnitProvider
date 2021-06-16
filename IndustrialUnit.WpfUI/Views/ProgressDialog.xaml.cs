using IndustrialUnit.WpfUI.Models;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace IndustrialUnit.WpfUI.Views
{
  /// <summary>
  /// Interaction logic for ProgressDialog.xaml
  /// </summary>
  public partial class ProgressDialog : Window
  {
    readonly BackgroundWorker _worker = new();

    string Path { get; set; }
    bool _isBusy;

    public ProgressDialog(string path)
    {
      InitializeComponent();
      Path = path;
      _isBusy = true;
      _worker.DoWork += BgWorker_DoWork;
      _worker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;

      _worker.WorkerSupportsCancellation = true;
      _worker.WorkerReportsProgress = true;
      _worker.RunWorkerAsync();
      ShowDialog();
    }

    private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      _isBusy = false;
      TextLabel.Visibility = Visibility.Hidden;
      ProgressBar.Visibility = Visibility.Hidden;
      SubTextLabel.Text = "Process done.";
      OK.Visibility = Visibility.Visible;
    }

    void OnClosing(object sender, CancelEventArgs e)
    {
      //e.Cancel = _isBusy;
    }

    private void BgWorker_DoWork(object sender, DoWorkEventArgs e) => FileRepository.LoadIntoDB(Path);

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
      Dispatcher.BeginInvoke(DispatcherPriority.Send, (SendOrPostCallback)delegate {
        _isBusy = false;
        Close();
      }, null);
    }
  }
}
