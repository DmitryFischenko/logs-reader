namespace Soti.LogReader.Viewer.Views
{
    partial class EntryTextView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryTextView));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.filterBySelectedBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.formatBtn = new System.Windows.Forms.ToolStripButton();
            this.removeFormatBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(676, 405);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            this.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.filterBySelectedBtn,
            this.toolStripSeparator1,
            this.formatBtn,
            this.removeFormatBtn,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(676, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // filterBySelectedBtn
            // 
            this.filterBySelectedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.filterBySelectedBtn.Image = global::Soti.LogReader.Viewer.Properties.Resources.icons8_conversion_26;
            this.filterBySelectedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filterBySelectedBtn.Name = "filterBySelectedBtn";
            this.filterBySelectedBtn.Size = new System.Drawing.Size(23, 22);
            this.filterBySelectedBtn.Text = "toolStripButton2";
            this.filterBySelectedBtn.Click += new System.EventHandler(this.filterBySelectedBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // formatBtn
            // 
            this.formatBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.formatBtn.Image = global::Soti.LogReader.Viewer.Properties.Resources.icons8_align_left_26;
            this.formatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.formatBtn.Name = "formatBtn";
            this.formatBtn.Size = new System.Drawing.Size(23, 22);
            this.formatBtn.Text = "toolStripButton2";
            this.formatBtn.ToolTipText = "Try to format";
            this.formatBtn.Click += new System.EventHandler(this.formatBtn_Click);
            // 
            // removeFormatBtn
            // 
            this.removeFormatBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeFormatBtn.Image = global::Soti.LogReader.Viewer.Properties.Resources.icons8_delete_26;
            this.removeFormatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeFormatBtn.Name = "removeFormatBtn";
            this.removeFormatBtn.Size = new System.Drawing.Size(23, 22);
            this.removeFormatBtn.Text = "toolStripButton2";
            this.removeFormatBtn.ToolTipText = "Remove formatting";
            this.removeFormatBtn.Click += new System.EventHandler(this.removeFormatBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // EntryTextView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 430);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "EntryTextView";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntryTextView_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton filterBySelectedBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton formatBtn;
        private System.Windows.Forms.ToolStripButton removeFormatBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
