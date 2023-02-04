﻿using Microsoft.Win32;
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
            //fileDlg.Filter = "MP3 files (*.mp3)|*.mp3 | All files (*.*)|*.*";

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
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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

        }
    }
}
