namespace PhotoEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_open_file = new System.Windows.Forms.ToolStripButton();
            this.tsb_save_file = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_reset_image = new System.Windows.Forms.ToolStripButton();
            this.tsb_undo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_basic_copy = new System.Windows.Forms.ToolStripButton();
            this.tsb_grayscale = new System.Windows.Forms.ToolStripButton();
            this.tsb_sepia = new System.Windows.Forms.ToolStripButton();
            this.tsb_invert_colors = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_flip_vertically = new System.Windows.Forms.ToolStripButton();
            this.tsb_flip_horizontally = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_histogram = new System.Windows.Forms.ToolStripButton();
            this.tsb_mode = new System.Windows.Forms.ToolStripSplitButton();
            this.tsb_photo_mode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_background_mode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_camera_mode = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsb_open_image = new System.Windows.Forms.ToolStripButton();
            this.tsb_open_background = new System.Windows.Forms.ToolStripButton();
            this.tsb_save_subtracted = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_subtract = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_histogram_2 = new System.Windows.Forms.ToolStripButton();
            this.tsb_mode_2 = new System.Windows.Forms.ToolStripSplitButton();
            this.tsb_photo_mode_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_background_mode_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_camera_mode_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_open_file,
            this.tsb_save_file,
            this.toolStripSeparator4,
            this.tsb_reset_image,
            this.tsb_undo,
            this.toolStripSeparator5,
            this.tsb_basic_copy,
            this.tsb_grayscale,
            this.tsb_sepia,
            this.tsb_invert_colors,
            this.toolStripSeparator1,
            this.tsb_flip_vertically,
            this.tsb_flip_horizontally,
            this.toolStripSeparator3,
            this.tsb_histogram,
            this.tsb_mode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1229, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_open_file
            // 
            this.tsb_open_file.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_open_file.Image = global::PhotoEditor.Properties.Resources.ic_open;
            this.tsb_open_file.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_open_file.Name = "tsb_open_file";
            this.tsb_open_file.Size = new System.Drawing.Size(29, 24);
            this.tsb_open_file.Text = "Open File";
            this.tsb_open_file.Click += new System.EventHandler(this.tsb_open_file_Click);
            // 
            // tsb_save_file
            // 
            this.tsb_save_file.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_save_file.Enabled = false;
            this.tsb_save_file.Image = global::PhotoEditor.Properties.Resources.ic_save;
            this.tsb_save_file.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_save_file.Name = "tsb_save_file";
            this.tsb_save_file.Size = new System.Drawing.Size(29, 24);
            this.tsb_save_file.Text = "Save File";
            this.tsb_save_file.Click += new System.EventHandler(this.tsb_save_file_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_reset_image
            // 
            this.tsb_reset_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_reset_image.Enabled = false;
            this.tsb_reset_image.Image = global::PhotoEditor.Properties.Resources.ic_reset_image;
            this.tsb_reset_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_reset_image.Name = "tsb_reset_image";
            this.tsb_reset_image.Size = new System.Drawing.Size(29, 24);
            this.tsb_reset_image.Text = "Reset Image";
            this.tsb_reset_image.Click += new System.EventHandler(this.tsb_reset_image_Click);
            // 
            // tsb_undo
            // 
            this.tsb_undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_undo.Enabled = false;
            this.tsb_undo.Image = global::PhotoEditor.Properties.Resources.ic_undo;
            this.tsb_undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_undo.Name = "tsb_undo";
            this.tsb_undo.Size = new System.Drawing.Size(29, 24);
            this.tsb_undo.Text = "Undo";
            this.tsb_undo.Click += new System.EventHandler(this.tsb_undo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_basic_copy
            // 
            this.tsb_basic_copy.AccessibleName = "";
            this.tsb_basic_copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_basic_copy.Enabled = false;
            this.tsb_basic_copy.Image = global::PhotoEditor.Properties.Resources.ic_basic_copy;
            this.tsb_basic_copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_basic_copy.Name = "tsb_basic_copy";
            this.tsb_basic_copy.Size = new System.Drawing.Size(29, 24);
            this.tsb_basic_copy.Text = "Basic Copy";
            this.tsb_basic_copy.Click += new System.EventHandler(this.tsb_basic_copy_Click);
            // 
            // tsb_grayscale
            // 
            this.tsb_grayscale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_grayscale.Enabled = false;
            this.tsb_grayscale.Image = global::PhotoEditor.Properties.Resources.ic_grayscale;
            this.tsb_grayscale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_grayscale.Name = "tsb_grayscale";
            this.tsb_grayscale.Size = new System.Drawing.Size(29, 24);
            this.tsb_grayscale.Text = "Grayscale";
            this.tsb_grayscale.Click += new System.EventHandler(this.tsb_grayscale_Click);
            // 
            // tsb_sepia
            // 
            this.tsb_sepia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_sepia.Enabled = false;
            this.tsb_sepia.Image = global::PhotoEditor.Properties.Resources.ic_sepia;
            this.tsb_sepia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_sepia.Name = "tsb_sepia";
            this.tsb_sepia.Size = new System.Drawing.Size(29, 24);
            this.tsb_sepia.Text = "Sepia";
            this.tsb_sepia.Click += new System.EventHandler(this.tsb_sepia_Click);
            // 
            // tsb_invert_colors
            // 
            this.tsb_invert_colors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_invert_colors.Enabled = false;
            this.tsb_invert_colors.Image = global::PhotoEditor.Properties.Resources.ic_invert_colors;
            this.tsb_invert_colors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_invert_colors.Name = "tsb_invert_colors";
            this.tsb_invert_colors.Size = new System.Drawing.Size(29, 24);
            this.tsb_invert_colors.Text = "Invert Colors";
            this.tsb_invert_colors.Click += new System.EventHandler(this.tsb_invert_colors_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_flip_vertically
            // 
            this.tsb_flip_vertically.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_flip_vertically.Enabled = false;
            this.tsb_flip_vertically.Image = global::PhotoEditor.Properties.Resources.ic_flip_vertically;
            this.tsb_flip_vertically.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_flip_vertically.Name = "tsb_flip_vertically";
            this.tsb_flip_vertically.Size = new System.Drawing.Size(29, 24);
            this.tsb_flip_vertically.Text = "Flip Vertically";
            this.tsb_flip_vertically.Click += new System.EventHandler(this.tsb_flip_vertically_Click);
            // 
            // tsb_flip_horizontally
            // 
            this.tsb_flip_horizontally.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_flip_horizontally.Enabled = false;
            this.tsb_flip_horizontally.Image = global::PhotoEditor.Properties.Resources.ic_flip_horizontally;
            this.tsb_flip_horizontally.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_flip_horizontally.Name = "tsb_flip_horizontally";
            this.tsb_flip_horizontally.Size = new System.Drawing.Size(29, 24);
            this.tsb_flip_horizontally.Text = "Flip Horizontally";
            this.tsb_flip_horizontally.Click += new System.EventHandler(this.tsb_flip_horizontally_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_histogram
            // 
            this.tsb_histogram.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_histogram.Enabled = false;
            this.tsb_histogram.Image = global::PhotoEditor.Properties.Resources.ic_histogram;
            this.tsb_histogram.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_histogram.Name = "tsb_histogram";
            this.tsb_histogram.Size = new System.Drawing.Size(29, 24);
            this.tsb_histogram.Text = "Display Histogram";
            this.tsb_histogram.Click += new System.EventHandler(this.tsb_histogram_Click);
            // 
            // tsb_mode
            // 
            this.tsb_mode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_mode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_photo_mode,
            this.tsb_background_mode,
            this.tsb_camera_mode});
            this.tsb_mode.Image = global::PhotoEditor.Properties.Resources.ic_mode;
            this.tsb_mode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_mode.Name = "tsb_mode";
            this.tsb_mode.Size = new System.Drawing.Size(39, 24);
            this.tsb_mode.Text = "Switch Editor Mode";
            // 
            // tsb_photo_mode
            // 
            this.tsb_photo_mode.Image = global::PhotoEditor.Properties.Resources.ic_photo_mode;
            this.tsb_photo_mode.Name = "tsb_photo_mode";
            this.tsb_photo_mode.Size = new System.Drawing.Size(271, 26);
            this.tsb_photo_mode.Text = "Photo Filter Mode";
            this.tsb_photo_mode.Click += new System.EventHandler(this.tsb_photo_mode_Click);
            // 
            // tsb_background_mode
            // 
            this.tsb_background_mode.Image = global::PhotoEditor.Properties.Resources.ic_background_mode;
            this.tsb_background_mode.Name = "tsb_background_mode";
            this.tsb_background_mode.Size = new System.Drawing.Size(271, 26);
            this.tsb_background_mode.Text = "Background Replace Mode";
            this.tsb_background_mode.Click += new System.EventHandler(this.tsb_background_mode_Click);
            // 
            // tsb_camera_mode
            // 
            this.tsb_camera_mode.Image = global::PhotoEditor.Properties.Resources.ic_camera_mode;
            this.tsb_camera_mode.Name = "tsb_camera_mode";
            this.tsb_camera_mode.Size = new System.Drawing.Size(271, 26);
            this.tsb_camera_mode.Text = "Live Camera Mode";
            this.tsb_camera_mode.Click += new System.EventHandler(this.tsb_camera_mode_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(726, 30);
            this.pictureBox2.MaximumSize = new System.Drawing.Size(720, 720);
            this.pictureBox2.MinimumSize = new System.Drawing.Size(480, 720);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(720, 720);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 30);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(720, 720);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(480, 720);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(720, 720);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(0, 30);
            this.pictureBox3.MaximumSize = new System.Drawing.Size(720, 360);
            this.pictureBox3.MinimumSize = new System.Drawing.Size(480, 360);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(720, 360);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(0, 390);
            this.pictureBox4.MaximumSize = new System.Drawing.Size(720, 360);
            this.pictureBox4.MinimumSize = new System.Drawing.Size(480, 360);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(720, 360);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_open_image,
            this.tsb_open_background,
            this.tsb_save_subtracted,
            this.toolStripSeparator2,
            this.tsb_subtract,
            this.toolStripSeparator6,
            this.tsb_histogram_2,
            this.tsb_mode_2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 27);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1229, 27);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.Visible = false;
            // 
            // tsb_open_image
            // 
            this.tsb_open_image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_open_image.Image = global::PhotoEditor.Properties.Resources.ic_open;
            this.tsb_open_image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_open_image.Name = "tsb_open_image";
            this.tsb_open_image.Size = new System.Drawing.Size(29, 24);
            this.tsb_open_image.Text = "Open Image";
            this.tsb_open_image.Click += new System.EventHandler(this.tsb_open_image_Click);
            // 
            // tsb_open_background
            // 
            this.tsb_open_background.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_open_background.Image = global::PhotoEditor.Properties.Resources.ic_open;
            this.tsb_open_background.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_open_background.Name = "tsb_open_background";
            this.tsb_open_background.Size = new System.Drawing.Size(29, 24);
            this.tsb_open_background.Text = "Open Background";
            this.tsb_open_background.Click += new System.EventHandler(this.tsb_open_background_Click);
            // 
            // tsb_save_subtracted
            // 
            this.tsb_save_subtracted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_save_subtracted.Enabled = false;
            this.tsb_save_subtracted.Image = global::PhotoEditor.Properties.Resources.ic_save;
            this.tsb_save_subtracted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_save_subtracted.Name = "tsb_save_subtracted";
            this.tsb_save_subtracted.Size = new System.Drawing.Size(29, 24);
            this.tsb_save_subtracted.Text = "Save File";
            this.tsb_save_subtracted.Click += new System.EventHandler(this.tsb_save_file_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_subtract
            // 
            this.tsb_subtract.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_subtract.Enabled = false;
            this.tsb_subtract.Image = global::PhotoEditor.Properties.Resources.ic_subtract;
            this.tsb_subtract.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_subtract.Name = "tsb_subtract";
            this.tsb_subtract.Size = new System.Drawing.Size(29, 24);
            this.tsb_subtract.Text = "Subtract / Auto Merge";
            this.tsb_subtract.Click += new System.EventHandler(this.tsb_subtract_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_histogram_2
            // 
            this.tsb_histogram_2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_histogram_2.Enabled = false;
            this.tsb_histogram_2.Image = global::PhotoEditor.Properties.Resources.ic_histogram;
            this.tsb_histogram_2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_histogram_2.Name = "tsb_histogram_2";
            this.tsb_histogram_2.Size = new System.Drawing.Size(29, 24);
            this.tsb_histogram_2.Text = "Display Histogram";
            this.tsb_histogram_2.Click += new System.EventHandler(this.tsb_histogram_Click);
            // 
            // tsb_mode_2
            // 
            this.tsb_mode_2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_mode_2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_photo_mode_2,
            this.tsb_background_mode_2,
            this.tsb_camera_mode_2});
            this.tsb_mode_2.Image = global::PhotoEditor.Properties.Resources.ic_mode;
            this.tsb_mode_2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_mode_2.Name = "tsb_mode_2";
            this.tsb_mode_2.Size = new System.Drawing.Size(39, 24);
            this.tsb_mode_2.Text = "Switch Editor Mode";
            // 
            // tsb_photo_mode_2
            // 
            this.tsb_photo_mode_2.Image = global::PhotoEditor.Properties.Resources.ic_photo_mode;
            this.tsb_photo_mode_2.Name = "tsb_photo_mode_2";
            this.tsb_photo_mode_2.Size = new System.Drawing.Size(271, 26);
            this.tsb_photo_mode_2.Text = "Photo Filter Mode";
            this.tsb_photo_mode_2.Click += new System.EventHandler(this.tsb_photo_mode_Click);
            // 
            // tsb_background_mode_2
            // 
            this.tsb_background_mode_2.Image = global::PhotoEditor.Properties.Resources.ic_background_mode;
            this.tsb_background_mode_2.Name = "tsb_background_mode_2";
            this.tsb_background_mode_2.Size = new System.Drawing.Size(271, 26);
            this.tsb_background_mode_2.Text = "Background Replace Mode";
            this.tsb_background_mode_2.Click += new System.EventHandler(this.tsb_background_mode_Click);
            // 
            // tsb_camera_mode_2
            // 
            this.tsb_camera_mode_2.Image = global::PhotoEditor.Properties.Resources.ic_camera_mode;
            this.tsb_camera_mode_2.Name = "tsb_camera_mode_2";
            this.tsb_camera_mode_2.Size = new System.Drawing.Size(271, 26);
            this.tsb_camera_mode_2.Text = "Live Camera Mode";
            this.tsb_camera_mode_2.Click += new System.EventHandler(this.tsb_camera_mode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1229, 547);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Simpol Photo Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_basic_copy;
        private System.Windows.Forms.ToolStripButton tsb_grayscale;
        private System.Windows.Forms.ToolStripButton tsb_sepia;
        private System.Windows.Forms.ToolStripButton tsb_invert_colors;
        private System.Windows.Forms.ToolStripButton tsb_flip_vertically;
        private System.Windows.Forms.ToolStripButton tsb_flip_horizontally;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsb_open_file;
        private System.Windows.Forms.ToolStripButton tsb_save_file;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsb_histogram;
        private System.Windows.Forms.ToolStripButton tsb_reset_image;
        private System.Windows.Forms.ToolStripButton tsb_undo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton tsb_mode;
        private System.Windows.Forms.ToolStripMenuItem tsb_photo_mode;
        private System.Windows.Forms.ToolStripMenuItem tsb_background_mode;
        private System.Windows.Forms.ToolStripMenuItem tsb_camera_mode;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsb_open_image;
        private System.Windows.Forms.ToolStripButton tsb_save_subtracted;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsb_histogram_2;
        private System.Windows.Forms.ToolStripSplitButton tsb_mode_2;
        private System.Windows.Forms.ToolStripMenuItem tsb_photo_mode_2;
        private System.Windows.Forms.ToolStripMenuItem tsb_background_mode_2;
        private System.Windows.Forms.ToolStripMenuItem tsb_camera_mode_2;
        private System.Windows.Forms.ToolStripButton tsb_open_background;
        private System.Windows.Forms.ToolStripButton tsb_subtract;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}

