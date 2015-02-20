using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Secondary_Clock
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    public MainWindow()
    {
      InitializeComponent();

      SetupTimers();
    }

    private void SetupTimers()
    {
      SetupTimeTimer();
      SetupLocationTimer();
    }

    private void SetupLocationTimer()
    {
      SetupTimer(MoveForm, 10000);
    }

    private void SetupTimeTimer()
    {
      SetupTimer(UpdateTime, 1000);
    }

    private void SetupTimer(EventHandler method, int milliseconds)
    {
      var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(milliseconds) };
      timer.Tick += method;
      timer.Start();
    }

    private void UpdateTime(object sender, EventArgs e)
    {
      TimeBlock.Text = DateTime.Now.ToLongTimeString();
      TimeBlock.Text += Environment.NewLine;
      TimeBlock.Text += DateTime.Today.ToShortDateString();
    }

    private void MoveForm(object sender, EventArgs e)
    {
      Screen secondScreen = null;
      foreach (var screen in Screen.AllScreens)
      {
        if (screen != Screen.PrimaryScreen) secondScreen = screen;
      }

      if (secondScreen == null) return;

      Topmost = true;

      var area = secondScreen.WorkingArea;
      Left = area.Right * 1f - Width;
      Top = area.Bottom * 1f - Height + 40;
    }

    private void MoveForm(object sender, RoutedEventArgs e)
    {
      MoveForm(sender, new EventArgs());
    }
  }
}
