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

namespace WebCam1Lib
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public Button start, stop;

        private void startRecord_Click(object sender, RoutedEventArgs e)
        {

        }

        public UserControl1()
        {
            InitializeComponent();
            start = startRecord;
            stop = stopRecord;
        }
        public void startRecClick()
        {
            //start.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            start.Command.Execute(null);
        }
        public void stopRecClick()
        {
            stop.Command.Execute(null);
        }
    }
}
