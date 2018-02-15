namespace Soti.LogReader.Viewer.Views.FileTableView
{
    partial class FileTableView
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.fastObjectListView = new BrightIdeasSoftware.FastObjectListView();
            this.colTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.filterTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterTextBox});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(766, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 465);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(766, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // fastObjectListView
            // 
            this.fastObjectListView.AllColumns.Add(this.colTime);
            this.fastObjectListView.AllColumns.Add(this.colMessage);
            this.fastObjectListView.CellEditUseWholeCell = false;
            this.fastObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTime,
            this.colMessage});
            this.fastObjectListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView.Location = new System.Drawing.Point(0, 25);
            this.fastObjectListView.Name = "fastObjectListView";
            this.fastObjectListView.ShowGroups = false;
            this.fastObjectListView.Size = new System.Drawing.Size(766, 440);
            this.fastObjectListView.TabIndex = 2;
            this.fastObjectListView.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView.UseFiltering = true;
            this.fastObjectListView.View = System.Windows.Forms.View.Details;
            this.fastObjectListView.VirtualMode = true;
            // 
            // colTime
            // 
            this.colTime.AspectName = "TimeCreated";
            this.colTime.AspectToStringFormat = "{0: dd-MM HH:mm:ss.fff }";
            // 
            // colMessage
            // 
            this.colMessage.AspectName = "Message";
            // 
            // filterTextBox
            // 
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(100, 25);
            this.filterTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filterTextBox_KeyUp);
            // 
            // FileTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 487);
            this.Controls.Add(this.fastObjectListView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.KeyPreview = true;
            this.Name = "FileTableView";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileTableView_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView;
        private BrightIdeasSoftware.OLVColumn colTime;
        private BrightIdeasSoftware.OLVColumn colMessage;
        private System.Windows.Forms.ToolStripTextBox filterTextBox;
    }
}
