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
        TagEditor TagEditor = new TagEditor();

        public MainWindow()
        {
            InitializeComponent();
            TagEditor1.Save_Clicked += TagEditor_Save_Clicked;
        }

        private void TagEditor_Save_Clicked(object? sender, EventArgs e)
        {
            // had to stop the media player to save and was getting an error
            myMediaPlayer.Stop();
            // was getting an error file was in use elsewhere and it was the media player so i set it = to null
            myMediaPlayer.Source = null;
            var title = currentFile.Tag.Title;
            var artist = currentFile.Tag.Artists;
            var album = currentFile.Tag.Album;
            var year = currentFile.Tag.Year;
            var newTitle = TagEditor1.TagTitle.Text;
            var newArtist = TagEditor1.TagArtist.Text;
            var newAlbum = TagEditor1.TagAlbum.Text;
            var newYear = TagEditor1.TagYear.Text;
            int temp;


            //if tag exists then and text box is filled then change the tags

            if (title != null && newTitle != null)
            {
                currentFile.Tag.Title = null;
                currentFile.Tag.Title = newTitle;


            }
            if (artist != null && newArtist != null)
            {

                currentFile.Tag.Artists = new string[] { newArtist };
            }
            if (album != null && newAlbum != null)
            {
                currentFile.Tag.Album = newAlbum;
            }
            if (year != null && newYear != null && int.TryParse(newYear, out temp))
            {
                // had to converty to unsigned int for year
                int.TryParse(newYear, out temp);
                currentFile.Tag.Year = (uint)temp;
            }

            currentFile.Save();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            
            string filePath;
            //Example of instantiating an OpenFileDialog
            OpenFileDialog fileDlg = new OpenFileDialog();

            //Create a file filter. only opens mp3
            fileDlg.Filter = "MP3 files (*.mp3)|*.mp3";


            //ShowDialog shows onscreen for the user
            //By default it return true if the user selects a file and hits "Open"
            if (fileDlg.ShowDialog() == true)
            {
                //The filename property stores the full path that was selected
                filePath = fileDlg.FileName;



                //Example of creating a TagLib file object, for accessing mp3 metadata
                currentFile = TagLib.File.Create(fileDlg.FileName);
                //TagLib.File.AccessMode accessMode = TagLib.File.AccessMode.Closed;



                //Set the source of the media player element.
                myMediaPlayer.Source = new Uri(fileDlg.FileName);
                var title = currentFile.Tag.Title;
                var artist = currentFile.Tag.Artists;
                var album = currentFile.Tag.Album;
                var year = currentFile.Tag.Year;

                // if tag exists then write to textbox

                if (title != null)
                {
                    TagEditor1.TagTitle.Text = title.ToString();
                    NPTitle.Text = title.ToString();
                }
                if (artist != null)
                {
                    TagEditor1.TagArtist.Text = currentFile.Tag.Artists[0];
                    NPArtist.Text = currentFile.Tag.Artists[0];
                }
                if (album != null)
                {
                    TagEditor1.TagAlbum.Text = album.ToString();
                }
                if (year != null)

                {
                    TagEditor1.TagYear.Text = year.ToString();
                }
                if (album != null && year != null)
                {
                    var strAlbum = album.ToString();
                    var strYear = year.ToString();
                    NPAlbumYear.Text = strAlbum + " (" + strYear + ")";
                }

            }
        }

    private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //exit application
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
            // trigger collapsing of rows in grid
            showTagEditor();

        }


    // changes the row size to 0 and sets the other grid size to 1* each row to imitate a new page
        private void NowPlayingButton_Click(object sender, RoutedEventArgs e)
            {
                RightGrid.RowDefinitions[0].Height = new GridLength(0);

                NowPlayingGrid.RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                NowPlayingGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
                NowPlayingGrid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
            }

        private void TagEditorButton_Click(object sender, RoutedEventArgs e)
        {
            showTagEditor();
        }


         // sets specific rows to 0 and other rows to 1* to imitate a new page 
        private void showTagEditor()
        {
            NowPlayingGrid.RowDefinitions[0].Height = new GridLength(0);
            NowPlayingGrid.RowDefinitions[1].Height = new GridLength(0);
            NowPlayingGrid.RowDefinitions[2].Height = new GridLength(0);

            RightGrid.RowDefinitions[0].Height = new GridLength(3, GridUnitType.Star);
           
        }
    }
}
