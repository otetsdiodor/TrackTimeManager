using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrackTimeManager.Models;
using TrackTimeManager.Services;

namespace TrackTimeManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DBConnectionService dbService;
        public Tracker tracker;
        List<TrackAreaModel> Areas;

        public MainWindow()
        {
            InitializeComponent();
            dbService = new DBConnectionService();
            Areas = new List<TrackAreaModel>();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Areas = dbService.ReadData();
            if (Areas.Count != 0)
            {
                foreach (var item in Areas)
                {
                    AreasName.Items.Add(item.AreaName);
                }
            }
        }

        private void BtnTrack_Click(object sender, RoutedEventArgs e)
        {
            if (AreasName.SelectedIndex != -1)
            {
                tracker = new Tracker(Areas[AreasName.SelectedIndex]);
                tracker.Track();
            }
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            tracker.Track();
            dbService.ChangeData(Areas[AreasName.SelectedIndex]);
            InformTextBlock.Text = "Общее натреканное время - " + tracker.GetTotalTimeInDouble;
        }
    }
}
