using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace default_browser_watcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Settings should be externalized
        static int interval = 3000;
        static string defaultBrowserKey = "";

        private BackgroundWorker backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = true
            };

        public MainWindow()
        {
            Console.WriteLine("In MainWindow");
            startBackgroundChecker();

            InitializeComponent();
        }

        private void OnInit(object senter, EventArgs e) {
        }

        private void ButtonClickMe_Click(object sender, EventArgs e) {
            //BrowserLog.Items.Insert(0, "klikk klikk!");
            InsertLog("klikk klikk klikk etc.");
        }

        private void InsertLog(string s) {
            this.Dispatcher.Invoke(() =>
            {
                BrowserLog.Items.Insert(0, s);
            });
        }

        void startBackgroundChecker() {
            backgroundWorker.DoWork += backgroundWorker_DoWork;

            backgroundWorker.RunWorkerAsync();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            while (BrowserLog is null) {
                Console.WriteLine("BrowserLog not yet initialized, blocking");
                Thread.Sleep(interval);
            }
            InsertLog("In DoWork");
            int i = 0;
            while (true) {
                Thread.Sleep(interval);
                InsertLog("Iteration number " + i++);
            }
        }

    }
}
