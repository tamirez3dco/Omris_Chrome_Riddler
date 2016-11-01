using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuspenderLib
{
    public partial class UploaderForm : HebrewWordForm
    {
        String tempRecordingSoundPath;
        String newSoundFilePath;
        public UploaderForm()
        {
            InitializeComponent();
        }

        public override void init_form_by_riddle_word(HebrewWord riddleWord)
        {
            base.init_form_by_riddle_word(riddleWord);
            this.imageFilePath = Processer.mainResourcesPath + "words_sounds" + Path.DirectorySeparatorChar + riddleWord.filename + ".jpg";
            this.soundFilePath = Processer.mainResourcesPath + "words_sounds" + Path.DirectorySeparatorChar + riddleWord.filename + ".wav";
            tempRecordingSoundPath = Processer.mainResourcesPath + "temp_recorded_sound.wav";
            waveViewer1.WaveStream = new NAudio.Wave.WaveFileReader(soundFilePath);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // copy sound and image files...
            try
            {
                String path = Processer.mainResourcesPath + "words_sounds" + Path.DirectorySeparatorChar + riddleWord.filename + ".jpg";
                if (File.Exists(imageFilePath))
                {
                    if (path != imageFilePath) File.Copy(imageFilePath, path, true);
                }
                path = Processer.mainResourcesPath + "words_sounds" + Path.DirectorySeparatorChar + riddleWord.filename + ".wav";
                if (File.Exists(soundFilePath))
                {
                    if (path != soundFilePath) File.Copy(soundFilePath, path, true);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }

            this.Close();
        }

        String soundFilePath;
        String imageFilePath;
        private Point StartLineLocation;
        private void updateImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.jpg)|*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //pictureBox1.Image.
                        pictureBox1.Image = new Bitmap(dlg.FileName);
                        imageFilePath = dlg.FileName;
                    }
                    catch (Exception e2)
                    {
                        Logger.Log(e2.Message);
                        Logger.Log(e2.StackTrace);

                    }
                }
            }
        }

        private void updateSoundButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "wav files (*.wav)|*.wav";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //pictureBox1.Image = new Bitmap(dlg.FileName);
                    try
                    {
                        word_player = new SoundPlayer(dlg.FileName);
                        word_player.Load();
                        word_player.Play();
                        soundFilePath = dlg.FileName;
                    }
                    catch (Exception e2)
                    {
                        MessageBox.Show("Could not load sound file");
                        Logger.Log(e2.Message);
                        Logger.Log(e2.StackTrace);

                    }
                }
                newSoundFilePath = dlg.FileName;
                updateWaveViewerByFile(newSoundFilePath);
                return;
/*
                wave = new NAudio.Wave.WaveFileReader(newSoundFilePath);
                Debug.WriteLine("wave.Length=" + wave.Length);
                Debug.WriteLine("wave.TotalTime=" + wave.TotalTime);
                int smaples = (int)wave.TotalTime.TotalSeconds * wave.WaveFormat.SampleRate;
                Debug.WriteLine("samples=" + smaples.ToString());
                int desiredSamplesPerPixel = smaples / waveViewer1.Width;
                waveViewer1.SamplesPerPixel = desiredSamplesPerPixel;
                //waveViewer1.
*/
            }

        }

        private void updateWaveViewerByFile(String wav_file_path)
        {
            waveViewer1.WaveStream = wave = new NAudio.Wave.WaveFileReader(wav_file_path);

            Debug.WriteLine("wave.Length=" + wave.Length);
            Debug.WriteLine("wave.TotalTime=" + wave.TotalTime);
            int smaples = (int)wave.TotalTime.TotalSeconds * wave.WaveFormat.SampleRate;
            Debug.WriteLine("samples=" + smaples.ToString());
            int desiredSamplesPerPixel = smaples / waveViewer1.Width;
            waveViewer1.SamplesPerPixel = desiredSamplesPerPixel;

        }
        public override void display_richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            return;
        }
        public override void display_richTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void UploaderForm_Load(object sender, EventArgs e)
        {

        }

        private void startLine_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("startLine_MouseDown, e.Location=" + e.Location.ToString());
            if (e.Button == MouseButtons.Left) StartLineLocation = e.Location;
        }

        private void startLine_MouseMove(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("startLine_MouseMove, StartLineLocation=" + StartLineLocation.ToString() + ", e.X="+e.X.ToString() +", StartLine.Left="+startLine.Left.ToString());
            if (e.Button == MouseButtons.Left)
            {
                int newLocationLeft = startLine.Left + e.X;
                int newLocationRight = startLine.Right + e.X;
                if (newLocationLeft < waveViewer1.Left)
                {
                    startLine.Left = waveViewer1.Left;
                    return;
                }
                if (newLocationRight > EndLine.Left)
                {
                    startLine.Left = EndLine.Left - startLine.Width;
                    return;
                }
                startLine.Left = newLocationLeft;
            }
        }

        private void EndLine_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("EndLine_MouseDown");
            if (e.Button == MouseButtons.Left) EndLineLocation = e.Location;
        }

        private void EndLine_MouseMove(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("EndLine_MouseMove, EndLineLocation=" + EndLineLocation.ToString() + ", e.X=" + e.X.ToString() + ", EndLine.Left=" + EndLine.Left.ToString());
            if (e.Button == MouseButtons.Left)
            {
                int newLocationLeft = EndLine.Left + e.X;
                int newLocationRight = EndLine.Right + e.X;
                if (newLocationRight > waveViewer1.Right)
                {
                    EndLine.Left = waveViewer1.Right - EndLine.Width;
                    return;
                }
                if (newLocationLeft < startLine.Right)
                {
                    EndLine.Left = startLine.Right;
                    return;
                }
                EndLine.Left = newLocationLeft;
            }
        }

        public Point EndLineLocation { get; set; }

        private NAudio.Wave.WaveFileReader wave = null;
        private NAudio.Wave.DirectSoundOut output = null;

        private void playCroptedButton_Click(object sender, EventArgs e)
        {
            //String inpath = newSoundFilePath;
            //String outpath = Processer.mainResourcesPath +Path.DirectorySeparatorChar + "temp.wav";
            wave = new NAudio.Wave.WaveFileReader(newSoundFilePath);


            double totaltime = wave.TotalTime.TotalSeconds;
            double fullengthpixels = waveViewer1.Width;
            double startLinePosition = startLine.Left - waveViewer1.Left;
            double to_skip = totaltime * startLinePosition / fullengthpixels;
            double endLinePosition = (double)(waveViewer1.Right - EndLine.Right);
            double end_skip = totaltime * endLinePosition / fullengthpixels;

            int skip_start_seconds = (int)to_skip;
            int skip_start_miliseconds = (int)((to_skip-(double)skip_start_seconds) * 1000);

            wave.CurrentTime = new TimeSpan(0, 0, 0, skip_start_seconds, skip_start_miliseconds);

            init_wave_liner();
            //WavFileUtils.TrimWavFile(inpath, outpath, new TimeSpan(0, 0, 0, 0, (int)(1000 * to_skip)), new TimeSpan(0, 0, 0, 0, (int)(1000 * end_skip)));


            //wave.Skip(to_skip);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(wave));
            //output.
            output.Play();
        }

        public WaveIn waveSource = null;
        public WaveFileWriter waveFile = null;
        public NAudio.Wave.WaveBuffer waveBuffer = null;
        public bool start = true;
        public NAudio.Wave.WaveStream recordWaveStream;
        private void recordSoundButton_Click(object sender, EventArgs e)
        {
            if (start)
            {
                recordSoundButton.Text = "Stop Record";
                waveSource = new WaveIn();
                waveSource.WaveFormat = new WaveFormat(44100, 1);

                waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
                waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

                waveFile = new WaveFileWriter(tempRecordingSoundPath, waveSource.WaveFormat);
                
                waveSource.StartRecording();
                start = false;
            }
            else
            {
                start = true;
                recordSoundButton.Text = "Start Record";
                waveSource.StopRecording();
            }
        }

        void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            Debug.WriteLine("waveSource_DataAvailable");
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }

            //WaveFileReader wfr = new WaveFileReader(

            //StartBtn.Enabled = true;
        }

        private void init_wave_liner()
        {
            int playable_pixels_interval = EndLine.Right - startLine.Left;
            double playable_portion = (double)playable_pixels_interval / waveViewer1.Width;
            double playable_time = wave.TotalTime.TotalSeconds * playable_portion;

            wavePanel.Left = startLine.Left;
            wavePanel.Visible = true;
            waveTimer.Interval = (int)(playable_time * 1000 / playable_pixels_interval);
            waveTimer.Start();

        }


        private void waveTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine(wave.CurrentTime.ToString());
            TimeSpan ts = wave.CurrentTime;
            double portion = ts.TotalMilliseconds / wave.TotalTime.TotalMilliseconds;
            int yellow_line_location = (int)(waveViewer1.Left + waveViewer1.Width * portion);
            wavePanel.Left = yellow_line_location;

            if (wavePanel.Left > EndLine.Right - wavePanel.Width)
            {
                waveTimer.Stop();
                wavePanel.Visible = false;
            }
        }
    }
}
