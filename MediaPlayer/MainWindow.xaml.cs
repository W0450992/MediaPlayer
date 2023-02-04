using Microsoft.Win32;
using System;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TagLib.File currentFile;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            string filePath;
            //Example of instantiating an OpenFileDialog
            OpenFileDialog fileDlg = new OpenFileDialog();

            //Create a file filter
            fileDlg.Filter = "MP3 files (*.mp3)|*.mp3";
            

            //ShowDialog shows onscreen for the user
            //By default it return true if the user selects a file and hits "Open"
            if (fileDlg.ShowDialog() == true)
            {
                //The filename property stores the full path that was selected
                filePath = fileDlg.FileName;

                

                //Example of creating a TagLib file object, for accessing mp3 metadata
                currentFile = TagLib.File.Create(fileDlg.FileName);

                //Set the source of the media player element.
                myMediaPlayer.Source = new Uri(fileDlg.FileName);
                var title = currentFile.Tag.Title;
                var artist = currentFile.Tag.FirstArtist;
                var album = currentFile.Tag.Album;
                var year = currentFile.Tag.Year;

                if (title != null)
                {
                    TagTitle.Text = title.ToString();
                }
                if (artist != null)
                {
                    TagArtist.Text = artist.ToString();
                }
                if(album != null)
                {
                    TagAlbum.Text = album.ToString();
                }
                if(year != null)
                {
                    TagYear.Text = year.ToString();
                }

            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Play_Click(object sender, RoutedEventArgs e)
        {
            myMediaPlayer.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            myMediaPlayer.Pause();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            myMediaPlayer.Stop();
        }

        private void TagMP3_Click(object sender, RoutedEventArgs e)
        {
            showTagEditor();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var title = currentFile.Tag.Title;
            var artist = currentFile.Tag.FirstArtist;
            var album = currentFile.Tag.Album;
            var year = currentFile.Tag.Year;
            var newTitle = TagTitle.Text;
            var newArtist = TagArtist.Text;
            var newAlbum = TagAlbum.Text;
            var newYear = TagYear.Text;
            int temp;

            if (title != null && newTitle != null)
            {
                title = newTitle;
                
            }
            if (artist != null && newArtist != null)
            {
                artist = newArtist;
            }
            if (album != null && newAlbum != null)
            {
                album = newAlbum;
            }
            if (year != null && newYear != null && int.TryParse(newYear, out temp))
            {

                int.TryParse(newYear, out temp);
                year = (uint)temp;
            }
            currentFile.Save();
        }

        private void NowPlayingButton_Click(object sender, RoutedEventArgs e)
        {
            RightGrid.RowDefinitions[1].Height = new GridLength(0);
            RightGrid.RowDefinitions[2].Height = new GridLength(0);
            RightGrid.RowDefinitions[3].Height = new GridLength(0);
            RightGrid.RowDefinitions[4].Height = new GridLength(0);
            RightGrid.RowDefinitions[5].Height = new GridLength(0);
            RightGrid.RowDefinitions[6].Height = new GridLength(0);

            NowPlayingGrid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
            NowPlayingGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
            NowPlayingGrid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
        }

        private void TagEditorButton_Click(object sender, RoutedEventArgs e)
        {
            showTagEditor();
        }

        private void showTagEditor()
        {
            NowPlayingGrid.RowDefinitions[0].Height = new GridLength(0);
            NowPlayingGrid.RowDefinitions[1].Height = new GridLength(0);
            NowPlayingGrid.RowDefinitions[2].Height = new GridLength(0);

            RightGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
            RightGrid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
            RightGrid.RowDefinitions[3].Height = new GridLength(1, GridUnitType.Star);
            RightGrid.RowDefinitions[4].Height = new GridLength(1, GridUnitType.Star);
            RightGrid.RowDefinitions[5].Height = new GridLength(1, GridUnitType.Star);
            RightGrid.RowDefinitions[6].Height = new GridLength(1, GridUnitType.Star);
        }
    }
}
