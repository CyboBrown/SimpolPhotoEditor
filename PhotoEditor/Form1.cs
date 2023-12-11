using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WebCamLib;
using System.Security.AccessControl;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Threading;
using System.Diagnostics.Tracing;

namespace PhotoEditor
{
    public partial class Form1 : Form
    {
        byte current_mode = 0;
        int current_filter = 0;
        Bitmap img_loaded;
        Bitmap img_loaded_image;
        Bitmap img_loaded_background;
        Image img_temp_0 = null;
        Image img_temp_1 = null;
        Image img_temp_2 = null;
        Image img_temp_3 = null;
        Bitmap img_prev;
        Bitmap img_cam;
        Bitmap img_cam_processed;
        Stack<Bitmap> img_stack = new Stack<Bitmap>();
        Color subtract_color = Color.FromArgb(0, 0, 255);
        private VideoCaptureDevice videoSource;
        private readonly object frameLock = new object();
        private Thread processingThread;

        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
            MaximumSize = Size;
            MinimumSize = Size;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void tsb_basic_copy_Click(object sender, EventArgs e)
        {
            current_filter = 0;
            if(current_mode == 0)
            {
                img_prev = (Bitmap)pictureBox2.Image;
                img_stack.Push(img_prev);
                Bitmap temp = new Bitmap(img_prev.Width, img_prev.Height);
                Color pixel;
                for (int x = 0; x < img_prev.Width; x++)
                {
                    for (int y = 0; y < img_prev.Height; y++)
                    {
                        pixel = img_loaded.GetPixel(x, y);
                        temp.SetPixel(x, y, pixel);
                    }
                }
                pictureBox2.Image = temp;
                pictureBox2.Invalidate();
            }
        }

        private void tsb_grayscale_Click(object sender, EventArgs e)
        {
            current_filter = 1;
            if (current_mode == 0)
            {
                img_prev = (Bitmap)pictureBox2.Image;
                img_stack.Push(img_prev);
                Bitmap temp = new Bitmap(img_prev.Width, img_prev.Height);
                Color pixel;
                for (int x = 0; x < img_prev.Width; x++)
                {
                    for (int y = 0; y < img_prev.Height; y++)
                    {
                        pixel = img_prev.GetPixel(x, y);
                        int grey = (int)(pixel.R + pixel.G + pixel.B) / 3;
                        temp.SetPixel(x, y, Color.FromArgb(grey, grey, grey));
                    }
                }
                pictureBox2.Image = temp;
                pictureBox2.Invalidate();
            }  
        }

        private void tsb_sepia_Click(object sender, EventArgs e)
        {
            current_filter = 2;
            if (current_mode == 0)
            {
                img_prev = (Bitmap)pictureBox2.Image;
                img_stack.Push(img_prev);
                Bitmap temp = new Bitmap(img_prev.Width, img_prev.Height);
                Color pixel;
                for (int x = 0; x < img_prev.Width; x++)
                {
                    for (int y = 0; y < img_prev.Height; y++)
                    {
                        pixel = img_prev.GetPixel(x, y);
                        int r = pixel.R;
                        int g = pixel.G;
                        int b = pixel.B;
                        int new_r = Math.Min(255, (int)(0.393 * r + 0.769 * g + 0.189 * b));
                        int new_g = Math.Min(255, (int)(0.349 * r + 0.686 * g + 0.168 * b));
                        int new_b = Math.Min(255, (int)(0.272 * r + 0.534 * g + 0.131 * b));
                        temp.SetPixel(x, y, Color.FromArgb(new_r, new_g, new_b));
                    }
                }
                pictureBox2.Image = temp;
                pictureBox2.Invalidate();
            }
        }

        private void tsb_invert_colors_Click(object sender, EventArgs e)
        {
            current_filter = 3;
            if (current_mode == 0)
            {
                img_prev = (Bitmap)pictureBox2.Image;
                img_stack.Push(img_prev);
                Bitmap temp = new Bitmap(img_prev.Width, img_prev.Height);
                Color pixel;
                for (int x = 0; x < img_prev.Width; x++)
                {
                    for (int y = 0; y < img_prev.Height; y++)
                    {
                        pixel = img_prev.GetPixel(x, y);
                        int r = 255 - pixel.R;
                        int g = 255 - pixel.G;
                        int b = 255 - pixel.B;
                        temp.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }
                pictureBox2.Image = temp;
                pictureBox2.Invalidate();
            }
        }

        private void tsb_flip_vertically_Click(object sender, EventArgs e)
        {
            current_filter = 4;
            if (current_mode == 0)
            {
                img_prev = (Bitmap)pictureBox2.Image;
                img_stack.Push(img_prev);
                Bitmap temp = new Bitmap(img_prev.Width, img_prev.Height);
                Color pixel;
                for (int x = 0; x < img_prev.Width; x++)
                {
                    for (int y = 0; y < img_prev.Height; y++)
                    {
                        pixel = img_prev.GetPixel(img_prev.Width - x - 1, y);
                        temp.SetPixel(x, y, pixel);
                    }
                }
                pictureBox2.Image = temp;
                pictureBox2.Invalidate();
            }
        }

        private void tsb_flip_horizontally_Click(object sender, EventArgs e)
        {
            current_filter = 5;
            if (current_mode == 0)
            {
                img_prev = (Bitmap)pictureBox2.Image;
                img_stack.Push(img_prev);
                Bitmap temp = new Bitmap(img_prev.Width, img_prev.Height);
                Color pixel;
                for (int x = 0; x < img_prev.Width; x++)
                {
                    for (int y = 0; y < img_prev.Height; y++)
                    {
                        pixel = img_prev.GetPixel(x, img_prev.Height - y - 1);
                        temp.SetPixel(x, y, pixel);
                    }
                }
                pictureBox2.Image = temp;
                pictureBox2.Invalidate();
            }
        }

        private void tsb_open_file_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                img_loaded = (Bitmap)Image.FromFile(open.FileName);
                pictureBox1.Image = img_loaded;
                pictureBox2.Image = img_loaded;
                // enable buttons
                tsb_save_file.Enabled = true;
                tsb_reset_image.Enabled = true;
                tsb_basic_copy.Enabled = true;
                tsb_grayscale.Enabled = true;
                tsb_sepia.Enabled = true;
                tsb_invert_colors.Enabled = true;
                tsb_flip_vertically.Enabled = true;
                tsb_flip_horizontally.Enabled = true;
                tsb_histogram.Enabled = true;
            }
        }

        private void tsb_save_file_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            ImageFormat format;
            if (save.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(save.FileName).ToLower();
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    case ".gif":
                        format = ImageFormat.Gif;
                        break;
                    default:
                        format = ImageFormat.Png;
                        break;
                }
                pictureBox2.Image.Save(save.FileName, format);
            }
        }

        private void tsb_reset_image_Click(object sender, EventArgs e)
        {
            img_prev = img_loaded;
            pictureBox2.Image = img_loaded;
            img_stack.Clear();
        }

        private void tsb_undo_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = img_prev;
            if(img_stack.Count > 0)
            {
                img_stack.Pop();
                if(img_stack.Count == 0)
                {
                    img_prev = img_loaded;
                } else
                {
                    img_prev = img_stack.Peek();
                }
            }
            pictureBox2.Invalidate();
        }

        private void tsb_histogram_Click(object sender, EventArgs e)
        {
            int[] histogram = new int[256];
            Bitmap temp = new Bitmap(pictureBox2.Image);
            Color pixel;
            for (int x = 0; x < temp.Width; x++)
            {
                for (int y = 0; y < temp.Height; y++)
                {
                    pixel = temp.GetPixel(x, y);
                    int grey = (int)(pixel.R + pixel.G + pixel.B) / 3;
                    histogram[grey]++;
                }
            }
            var histogramHeight = 256;
            var bitmap = new Bitmap(1024, histogramHeight);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                for (int i = 0; i < histogram.Length; i++)
                {
                    float unit = (float)histogram[i] / histogram.Max();

                    graphics.DrawLine(Pens.Black,
                        new Point(i * 4 + 1, histogramHeight - 5),
                        new Point(i * 4 + 1, histogramHeight - 5 - (int)(unit * histogramHeight)));
                }
            }
            //bitmap.Save(filename: @"C:\Users\my pc\Desktop\histogram.jpg");
            using (Form form = new Form())
            {
                form.Icon = Icon;
                form.Text = "Sampol Photo Editor - Histogram";
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ClientSize = bitmap.Size;
                form.MaximumSize = form.Size;
                form.MinimumSize = form.Size;
                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                pb.Image = bitmap;
                form.Controls.Add(pb);
                form.ShowDialog();
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (img_stack.Count > 0)
            {
                tsb_undo.Enabled = true;
            } else
            {
                tsb_undo.Enabled = false;
            }
        }

        private void tsb_photo_mode_Click(object sender, EventArgs e)
        {
            if(current_mode != 0)
            {
                if(current_mode == 2) DisableWebcam();
                toolStrip1.Visible = true;
                toolStrip2.Visible = false;
                toolStrip2.Visible = false;
                pictureBox1.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                if (current_mode == 1)
                {
                    img_temp_1 = pictureBox2.Image;
                    img_temp_2 = pictureBox3.Image;
                    img_temp_3 = pictureBox4.Image;
                }
                pictureBox2.Image = img_temp_0;
            }
            current_mode = 0;
        }

        private void tsb_background_mode_Click(object sender, EventArgs e)
        {
            if (current_mode != 1)
            {
                if (current_mode == 2) DisableWebcam();
                toolStrip1.Visible = false;
                toolStrip2.Visible = true;
                toolStrip3.Visible = false;
                pictureBox1.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                tsb_save_shot.Enabled = false;
                tsb_histogram_3.Enabled = false;
                if (current_mode == 0)
                {
                    img_temp_0 = pictureBox2.Image;
                }
                Thread.Sleep(100);
                pictureBox2.Image = img_temp_1;
                pictureBox3.Image = img_temp_2;
                pictureBox4.Image = img_temp_3;
            }
            current_mode = 1;
        }

        private void tsb_camera_mode_Click(object sender, EventArgs e)
        {
            if (current_mode == 1)
            {
                img_temp_1 = pictureBox2.Image;
                img_temp_2 = pictureBox3.Image;
                img_temp_3 = pictureBox4.Image;
            }
            if (current_mode != 2)
            {
                tsb_save_shot.Enabled = false;
                tsb_histogram_3.Enabled = false;
                toolStrip1.Visible = false;
                toolStrip2.Visible = false;
                toolStrip3.Visible = true;
                pictureBox1.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                if (current_mode == 0)
                {
                    img_temp_0 = pictureBox2.Image;
                }
                InitializeWebcam();
                processingThread = new Thread(ProcessFrames);
                processingThread.Start();
                pictureBox2.Image = null;
            }
            current_mode = 2;
        }

        private void InitializeWebcam()
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("No video devices found.");
            }
        }

        private void DisableWebcam()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

            // Stop the processing thread
            processingThread.Abort();
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            lock (frameLock)
            {
                // Clone the new frame to avoid synchronization issues
                img_cam = (Bitmap)eventArgs.Frame.Clone();
            }
            //pictureBox3.Image = (Bitmap) eventArgs.Frame.Clone();
        }

        private void ProcessFrames()
        {
            while (true)
            {
                Bitmap frameToProcess;
                Bitmap frameFromProcess;

                lock (frameLock)
                {
                    // Check if a new frame is available
                    if (img_cam == null)
                        continue;

                    // Clone the frame to avoid synchronization issues
                    frameToProcess = (Bitmap)img_cam.Clone();
                    img_cam = null;
                }

                // Clone the original frame to avoid modifying it directly
                frameFromProcess = (Bitmap) frameToProcess.Clone();

                // Apply the filter
                switch(current_filter)
                {
                    case 1:
                        PhotoFilter.grayscale(frameFromProcess);
                        break;
                    case 2:
                        PhotoFilter.sepia(frameFromProcess);
                        break;
                    case 3:
                        PhotoFilter.invert(frameFromProcess);
                        break;
                    case 4:
                        PhotoFilter.flip_vertically(frameFromProcess);
                        break;
                    case 5:
                        PhotoFilter.flip_horizontally(frameFromProcess);
                        break;
                }
                

                // Update the PictureBox with the filtered frame on the UI thread
                BeginInvoke((MethodInvoker)delegate
                {
                    pictureBox3.Image = frameToProcess;
                    pictureBox4.Image = frameFromProcess;
                    img_cam_processed = frameFromProcess;
                });
            }
        }

        private void tsb_open_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                img_loaded_image = (Bitmap)Image.FromFile(open.FileName);
                pictureBox3.Image = img_loaded_image;
            }
            if(img_loaded_background != null && img_loaded_image != null) tsb_subtract.Enabled = true;
        }

        private void tsb_open_background_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                img_loaded_background = (Bitmap)Image.FromFile(open.FileName);
                pictureBox4.Image = img_loaded_background;
            }
            if (img_loaded_background != null && img_loaded_image != null) tsb_subtract.Enabled = true;
        }

        private void tsb_subtract_Click(object sender, EventArgs e)
        {
            Bitmap temp = new Bitmap(pictureBox3.Image);
            int greygreen = (subtract_color.R + subtract_color.G + subtract_color.B) / 3;
            int threshold = 25;
            for(int x = 0; x < temp.Width; x++)
            {
                for(int y = 0; y < temp.Height; y++)
                {
                    Color pixel = temp.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtract_value = Math.Abs(grey - greygreen);
                    if (subtract_value > threshold) temp.SetPixel(x, y, pixel);
                    else temp.SetPixel(x, y, ((Bitmap)pictureBox4.Image).GetPixel(x, y));
                }
            }
            pictureBox2.Image = temp;
            tsb_save_subtracted.Enabled = true;
            tsb_histogram_2.Enabled = true;
            pictureBox2.Invalidate();
        }

        private void tsb_capture_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = img_cam_processed;
            tsb_save_shot.Enabled = true;
            tsb_histogram_3.Enabled = true;
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            if (current_mode != 2) DisableWebcam();
        }
    }
}
