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

namespace HydroAcousticApp_1.Views.Signals
{
    /// <summary>
    /// Логика взаимодействия для SineWaveSignalView.xaml
    /// </summary>
    public partial class SineWaveSignalView : UserControl
    {
        public SineWaveSignalView()
        {
            InitializeComponent();
        }

        private void GroupBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var gb = (GroupBox)e.OriginalSource;
            var grid = (Grid)gb.Header;
            grid.Width = gb.ActualWidth;
        }
    }
}
