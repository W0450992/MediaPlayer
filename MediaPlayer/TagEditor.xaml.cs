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

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for UCNowPlaying.xaml
    /// </summary>
    public partial class TagEditor : UserControl

    {

        public event EventHandler Save_Clicked;

        public TagEditor()
        {
            InitializeComponent();
        }



        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(Save_Clicked != null)
            {
                this.Save_Clicked(this, e );
            }
        }

        
    }
}
