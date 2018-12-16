using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Accord.Video.FFMPEG;
using AForge.Video;
using AForge.Video.DirectShow;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;

namespace WebCam1Lib
{
    class MainWindow1 : ObservableObject, IDisposable
    {
        #region Private fields

        private FilterInfo _currentDevice;
        private BitmapImage _image;
        private IVideoSource _videoSource;
        private VideoFileWriter _writer;
        private bool _recording;
        private DateTime? _firstFrameTime;

        #endregion

        #region Constructor

        public MainWindow1()
        {
            VideoDevices = new ObservableCollection<FilterInfo>();
            GetVideoDevices();
            StartSourceCommand = new RelayCommand(StartCamera);
            StopSourceCommand = new RelayCommand(StopCamera);
            StartRecordingCommand = new RelayCommand(StartRecording);
            StopRecordingCommand = new RelayCommand(StopRecording);
        }

        #endregion

        #region Properties

        public ObservableCollection<FilterInfo> VideoDevices { get; set; }

        public BitmapImage Image
        {
            get { return _image; }
            set { Set(ref _image, value); }
        }
        public FilterInfo CurrentDevice
        {
            get { return _currentDevice; }
            set { Set(ref _currentDevice, value); }
        }

        public ICommand StartRecordingCommand { get; private set; }

        public ICommand StopRecordingCommand { get; private set; }

        public ICommand StartSourceCommand { get; private set; }

        public ICommand StopSourceCommand { get; private set; }

        #endregion

        private void GetVideoDevices()
        {
            var devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in devices)
            {
                VideoDevices.Add(device);
            }
            if (VideoDevices.Any())
            {
                CurrentDevice = VideoDevices[0];
            }
            else
            {
                MessageBox.Show("No webcam found");
            }
        }

        private void StartCamera()
        {
            if (CurrentDevice != null)
            {
                _videoSource = new VideoCaptureDevice(CurrentDevice.MonikerString);
                _videoSource.NewFrame += video_NewFrame;
                _videoSource.Start();
            }
            else
            {
                MessageBox.Show("Current device can't be null");
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                if (_recording)
                {
                    using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                    {
                        if (_firstFrameTime != null)
                        {
                            _writer.WriteVideoFrame(bitmap, DateTime.Now - _firstFrameTime.Value);
                        }
                        else
                        {
                            _writer.WriteVideoFrame(bitmap);
                            _firstFrameTime = DateTime.Now;
                        }
                    }
                }
                using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                {
                    var memory = new MemoryStream();
                    bitmap.Save(memory, ImageFormat.Png);
                    memory.Position = 0;

                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                    Dispatcher.CurrentDispatcher.Invoke(() => Image = bitmapImage);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error on _videoSource_NewFrame:\n" + exc.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                StopCamera();
            }
        }

        private void StopCamera()
        {
            if (_videoSource != null && _videoSource.IsRunning)
            {
                _videoSource.SignalToStop();
                _videoSource.NewFrame -= video_NewFrame;
            }
            Image = null;
        }

        private void StopRecording()
        {
            _recording = false;
            _writer.Close();
            _writer.Dispose();
        }

        private void StartRecording()
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = "Video1";
            dialog.DefaultExt = ".mp4";
            dialog.AddExtension = true;

            // default setting

            dialog.InitialDirectory = null;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.RestoreDirectory = true;

            //end of default

            var dialogresult = dialog.ShowDialog();
            if (dialogresult != true)
            {
                return;
            }
            _firstFrameTime = null;

            _writer = new VideoFileWriter();
            _writer.Open(dialog.FileName, (int)Math.Round(Image.Width, 0), (int)Math.Round(Image.Height, 0));
            _recording = true;
        }
        public void Dispose()
        {
            if (_videoSource != null && _videoSource.IsRunning)
            {
                _videoSource.SignalToStop();
            }
            _writer?.Dispose();
        }
    }
}
