/****************************************************************************
While the underlying libraries are covered by LGPL, this sample is released 
as public domain.  It is distributed in the hope that it will be useful, but 
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
or FITNESS FOR A PARTICULAR PURPOSE.  
*****************************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Kodiak_Kapture
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.TextBox tbFileName;
        private OpenFileDialog openFileDialog1;
        private Button button2;
        private TrackBar trackBar1;
        private Label label2;
        private Label label3;
        private Timer timer1;
        private Label label4;
        private TextBox textBox1;
        private ToolTip toolTip1;
        private ImageList imageList1;
        private Button button1;
        private IContainer components;


                private bool btnPauseEnabled = false;
                private bool tbFileNameEnabled = true;
        private int btnStartImageIndex = 0;
                private string btnPauseText = "Pause";
        private PictureBox pb_color;

        private int counter = 1;
                

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
            // Make sure to release the Kodiak_Kapture object to avoid hanging
            if (m_play != null)
            {
                m_play.Dispose();
            }
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnSnap = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pb_color = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFileName
            // 
            this.tbFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFileName.Location = new System.Drawing.Point(45, 12);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(256, 13);
            this.tbFileName.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.ImageIndex = 0;
            this.btnStart.ImageList = this.imageList1;
            this.btnStart.Location = new System.Drawing.Point(8, 36);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(38, 30);
            this.btnStart.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnStart, "Play/Stop Movie");
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "PlayButton.gif");
            this.imageList1.Images.SetKeyName(1, "StopButton.gif");
            this.imageList1.Images.SetKeyName(2, "CameraButton.gif");
            this.imageList1.Images.SetKeyName(3, "QuestionButton.gif");
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(8, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 240);
            this.panel1.TabIndex = 10;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(298, -8);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(38, 22);
            this.btnPause.TabIndex = 11;
            this.btnPause.Text = "Pause";
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnSnap
            // 
            this.btnSnap.Enabled = false;
            this.btnSnap.ImageIndex = 2;
            this.btnSnap.ImageList = this.imageList1;
            this.btnSnap.Location = new System.Drawing.Point(52, 36);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(38, 30);
            this.btnSnap.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnSnap, "Take Snapshot");
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "avi";
            this.openFileDialog1.Filter = "AVI files|*.avi|All files|*.*";
            this.openFileDialog1.Title = "Select Video file to play";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(303, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "...";
            this.toolTip1.SetToolTip(this.button2, "Select Video File");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(0, 320);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(301, 45);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.trackBar1, "Scroll Forwards/Backwards Through Video");
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(277, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "00:00:00";
            this.toolTip1.SetToolTip(this.label2, "Video Duration");
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(199, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "00:00:00";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label3, "Current Position");
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(267, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "/";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(8, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(289, 20);
            this.textBox1.TabIndex = 19;
            this.toolTip1.SetToolTip(this.textBox1, "Current Video");
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // button1
            // 
            this.button1.ImageIndex = 3;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(298, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 20;
            this.toolTip1.SetToolTip(this.button1, "Help");
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pb_color
            // 
            this.pb_color.Location = new System.Drawing.Point(292, 31);
            this.pb_color.Name = "pb_color";
            this.pb_color.Size = new System.Drawing.Size(36, 24);
            this.pb_color.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_color.TabIndex = 21;
            this.pb_color.TabStop = false;
            this.toolTip1.SetToolTip(this.pb_color, "Image preview");
            this.pb_color.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(336, 355);
            this.Controls.Add(this.pb_color);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSnap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.btnPause);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(344, 389);
            this.MinimumSize = new System.Drawing.Size(344, 389);
            this.Name = "Form1";
            this.Text = "Kodiak Kapture 20070711.03";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}


        enum State
        {
            Uninit,
            Stopped,
            Paused,
            Playing
        }
        State m_State = State.Uninit;
        Kodiak_Kapture m_play = null;

        private void StartButtonAction()
        {
            while (tbFileName.Text.Length < 1)
            {
                if (ChangeSelectedFile() == false)
                {
                    return;
                }
            }

            // If necessary, close the old file
            if (m_State == State.Stopped)
            {
                // Did the filename change?
                if (tbFileName.Text != m_play.FileName)
                {
                    // File name changed, close the old file
                    m_play.Dispose();
                    m_play = null;
                    m_State = State.Uninit;
                    btnSnap.Enabled = false;
                }
            }

            // If we have no file open
            if (m_play == null)
            {
                try
                {
                    // Open the file, provide a handle to play it in
                    m_play = new Kodiak_Kapture(panel1, tbFileName.Text);

                    // Let us know when the file is finished playing
                    m_play.StopPlay += new Kodiak_Kapture.Kodiak_KaptureEvent(m_play_StopPlay);
                    m_State = State.Stopped;
                    double durat = m_play.GetDuration();
                    label2.Text = SecondsConvertor(durat);
                    trackBar1.Maximum = (int)durat;
                    trackBar1.Value = 0;
                    trackBar1.Enabled = false;
                    label3.Text = SecondsConvertor(m_play.GetCurrentPosition());
                    timer1.Enabled = true;
                    timer1.Start();
                }
                catch (COMException ce)
                {
                    MessageBox.Show("Failed to open file: " + ce.Message, "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // If we were stopped, start
            if (m_State == State.Stopped)
            {
                //btnStart.Text = "Stop";
                btnStart.ImageIndex = 1;
                m_play.Start();
                btnSnap.Enabled = true;
                btnPause.Enabled = true;
                tbFileName.Enabled = false;
                m_State = State.Playing;
                trackBar1.Enabled = true;
            }
            // If we are playing or paused, stop
            else if (m_State == State.Playing || m_State == State.Paused)
            {
                m_play.Stop();
                btnPause.Enabled = false;
                tbFileName.Enabled = true;
                //btnStart.Text = "Start";
                btnStart.ImageIndex = 0;
                btnPause.Text = "Pause";
                m_State = State.Stopped;
                trackBar1.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            StartButtonAction();
        }

        private void btnPause_Click(object sender, System.EventArgs e)
        {
            // If we are playing, pause
            if (m_State == State.Playing)
            {
                m_play.Pause();
                btnPause.Text = "Resume";
                m_State = State.Paused;
            }
            // If we are paused, start
            else
            {
                m_play.Start();
                btnPause.Text = "Pause";
                m_State = State.Playing;
            }
        }

        private void TakeSnapshot()
        {
            // Grab a copy of the current bitmap.  Graph can be paused, playing, or stopped
            IntPtr ip = m_play.SnapShot();
            string savename = "";
            try
            {
                // Turn the raw pixels into a Bitmap
                Bitmap bmp = m_play.IPToBmp(ip);

                // Save the bitmap to a file
                FileInfo finfo = new FileInfo(tbFileName.Text);

                savename = finfo.FullName.Remove(finfo.FullName.Length - finfo.Extension.Length) + "(" + counter + ").bmp";
                bool continu = false;
               
                while (continu == false)
                {
                    counter = counter + 1;
                    FileInfo tinfo = new FileInfo(savename);
                    if (tinfo.Exists == true)
                    {
                        continu = false;
                        savename = tinfo.FullName.Remove(tinfo.FullName.Length - tinfo.Extension.Length) + "(" + counter + ").bmp";
                    }
                    else
                    {
                        continu = true;
                    }
                    tinfo = null;
                }

                bmp.Save(savename);
                ConvertToJPG(savename);
                //bmp.Save(((finfo.DirectoryName + "\\").Replace("\\\\", "\\")) + finfo.Name.Substring(0, finfo.Name.Length - finfo.Extension.Length) + " " + m_play.GetCurrentPosition().ToString() + ".bmp");
                bmp.Dispose();
                bmp = null;
                finfo = null;              
            }
            finally
            {
                // Free the raw pixels
                Marshal.FreeCoTaskMem(ip);
            }
            FileInfo testExist = new FileInfo(savename);
            if (testExist.Exists == true)
            {
                testExist.Delete();
            }
            testExist = null;
        }



        private void btnSnap_Click(object sender, System.EventArgs e)
        {
           
                TakeSnapshot();
           
        }

        // Called when the video is finished playing
        private void m_play_StopPlay(Object sender)
        {
            
            try
            {
                btnPauseEnabled = false;
                tbFileNameEnabled = true;
                btnStartImageIndex = 0;
                btnPauseText = "Pause";
                m_State = State.Stopped;

               /* btnPause.Enabled = false;
                tbFileName.Enabled = true;
                //btnStart.Text = "Start";
                btnStart.ImageIndex = 0;
                btnPause.Text = "Pause";
                m_State = State.Stopped;
                label3.Text = SecondsConvertor(m_play.GetCurrentPosition());*/
            }
            catch
            {
                m_State = State.Stopped;
            }
          
            // Rewind clip to beginning to allow Kodiak_Kapture.Start to work again.
            m_play.Rewind();
        }


        private bool ChangeSelectedFile()
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = openFileDialog1.FileName;
                FileInfo finfo = new FileInfo(openFileDialog1.FileName);
                textBox1.Text = finfo.Name;
                toolTip1.SetToolTip(textBox1, finfo.FullName);
                finfo = null;
                counter = 1;
                return true;
            }
            else
            {
                return false;
            }

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (ChangeSelectedFile() == true)
            {
                StartButtonAction();
                if (m_State == State.Stopped)
                    StartButtonAction();
            }
        }

        private string SecondsConvertor(double inseconds)
        {
            string output = "00:00:00";
            output = TimeSpan.FromSeconds(inseconds).ToString().Substring(0,8);
            return output;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //MessageBox.Show(trackBar1.Value.ToString());
            m_play.SkipForward(trackBar1.Value);
            label3.Text = SecondsConvertor(m_play.GetCurrentPosition());           
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_State == State.Playing)
            {
                if (trackBar1.Enabled == false)
                {
                    trackBar1.Enabled = true;
                }
                label3.Text = SecondsConvertor(m_play.GetCurrentPosition());
                trackBar1.Value = (int)m_play.GetCurrentPosition();
            }
            else
            {
                if (trackBar1.Enabled == true)
                {
                    trackBar1.Enabled = false;
                }
              
            }
            
            
            if (m_State == State.Stopped)
            {
                btnPause.Enabled = btnPauseEnabled;
                tbFileName.Enabled = tbFileNameEnabled;
                btnStart.ImageIndex = btnStartImageIndex;
                btnPause.Text = btnPauseText;
            }

           
                if (m_play.GetCurrentPosition() == m_play.GetDuration())
                {
                   
                    m_play.Rewind();
                    btnStart.ImageIndex = 0;
                    StartButtonAction();
                }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help helpfrm = new Help();
            helpfrm.Show();
        }

    



        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                // allow them to continue
                // (without this, the cursor stays a "NO" symbol
                e.Effect = DragDropEffects.All;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            // transfer the filenames to a string array
            // (yes, everything to the left of the "=" can be put in the 
            // foreach loop in place of "files", but this is easier to understand.)
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // loop through the string array, adding each filename to the ListBox
            if (files.Length > 0)
            {
                FileInfo finfo;
                finfo = new FileInfo(files[0]);
                if (finfo.Exists == true)
                {
                    openFileDialog1.FileName = finfo.FullName;
                    tbFileName.Text = openFileDialog1.FileName;
                    textBox1.Text = finfo.Name;
                    toolTip1.SetToolTip(textBox1, finfo.FullName);
                    counter = 1;
                    StartButtonAction();
                    if (m_State == State.Stopped)
                    {
                        StartButtonAction();
                    }
                }
                finfo = null;
            }
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                // allow them to continue
                // (without this, the cursor stays a "NO" symbol
                e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            // transfer the filenames to a string array
            // (yes, everything to the left of the "=" can be put in the 
            // foreach loop in place of "files", but this is easier to understand.)
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // loop through the string array, adding each filename to the ListBox
            if (files.Length > 0)
            {
                FileInfo finfo;
                finfo = new FileInfo(files[0]);
                if (finfo.Exists == true)
                {
                    openFileDialog1.FileName = finfo.FullName;
                    tbFileName.Text = openFileDialog1.FileName;
                    textBox1.Text = finfo.Name;
                    toolTip1.SetToolTip(textBox1, finfo.FullName);
                    counter = 1;
                    StartButtonAction();
                    if (m_State == State.Stopped)
                    {
                        StartButtonAction();
                    }
                }
                finfo = null;
            }
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            } return null;
        }

        private void ConvertToJPG(string file)
        {
            try
            {
                FileInfo finfo = new FileInfo(file);

                pb_color.Image = new Bitmap(finfo.FullName);
                Bitmap b = (Bitmap)pb_color.Image;

                System.Drawing.Imaging.Encoder qualityEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameter enc = new EncoderParameter(qualityEncoder, 100L);
                EncoderParameters encs = new EncoderParameters(1);
                encs.Param[0] = enc;
                ImageCodecInfo coder;
                coder = GetEncoderInfo("image/jpeg");
                //MessageBox.Show(finfo.FullName.Remove(finfo.FullName.Length - finfo.Extension.Length) + ".jpg");
                string savename = finfo.FullName.Remove(finfo.FullName.Length - finfo.Extension.Length) + ".jpg";
                bool continu = false;
                int counter = 0;
                while (continu == false)
                {
                    counter = counter + 1;
                    FileInfo tinfo = new FileInfo(savename);
                    if (tinfo.Exists == true)
                    {
                        continu = false;
                        savename = tinfo.FullName.Remove(tinfo.FullName.Length - tinfo.Extension.Length) + "(" + counter + ").jpg";
                    }
                    else
                    {
                        continu = true;
                    }
                    tinfo = null;
                }


                b.Save(savename, coder, encs);
                b.Dispose();
                b = null;
                pb_color.Image.Dispose();
                pb_color.Image = null;
                finfo = null;
            }
            catch
            {
                FileInfo finfo = new FileInfo(file);
                MessageBox.Show("There was an error in processing " + finfo.Name, "Error Trapped", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                finfo = null;
            }
        }

    }
}
