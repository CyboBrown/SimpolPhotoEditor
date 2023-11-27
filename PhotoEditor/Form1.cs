﻿using System;
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

namespace PhotoEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
            MaximumSize = Size;
            MinimumSize = Size;
        }
        
        byte current_mode = 0;
        Bitmap img_loaded;
        Bitmap img_loaded_image;
        Bitmap img_loaded_background;
        Image img_temp_0 = null;
        Image img_temp_1 = null;
        Bitmap img_prev;
        Stack<Bitmap> img_stack = new Stack<Bitmap>();
        Color subtract_color = Color.FromArgb(0, 0, 255);

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

        private void tsb_grayscale_Click(object sender, EventArgs e)
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

        private void tsb_sepia_Click(object sender, EventArgs e)
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

        private void tsb_invert_colors_Click(object sender, EventArgs e)
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

        private void tsb_flip_vertically_Click(object sender, EventArgs e)
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

        private void tsb_flip_horizontally_Click(object sender, EventArgs e)
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
                toolStrip1.Visible = true;
                toolStrip2.Visible = false;
                pictureBox1.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                if(current_mode == 1)
                {
                    img_temp_1 = pictureBox2.Image;
                }
                pictureBox2.Image = img_temp_0;
            }
            current_mode = 0;
        }

        private void tsb_background_mode_Click(object sender, EventArgs e)
        {
            if (current_mode != 1)
            {
                toolStrip1.Visible = false;
                toolStrip2.Visible = true;
                pictureBox1.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                if (current_mode == 0)
                {
                    img_temp_0 = pictureBox2.Image;
                }
                pictureBox2.Image = img_temp_1;
            }
            current_mode = 1;
        }

        private void tsb_camera_mode_Click(object sender, EventArgs e)
        {
            if (current_mode != 2)
            {

            }
            current_mode = 2;
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
    }
}