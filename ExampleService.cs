using System.ServiceProcess;
using System.Timers;

namespace WindowsServiceExample
{
    partial class ExampleService : ServiceBase
    {
        private static Timer aTimer;

        public ExampleService() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
            aTimer = new Timer(10000); // 10 Seconds
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e) {
            DataProcessor dataProcessor = new DataProcessor();
            dataProcessor.Execute();
        }

        protected override void OnStop() {
            aTimer.Stop();
        }
    }
}