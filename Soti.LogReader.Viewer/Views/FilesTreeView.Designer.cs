namespace Soti.LogReader.Viewer.Views
{
    partial class FilesTreeView
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.treeListFiles = new BrightIdeasSoftware.TreeListView();
            this.colTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.viewModeButton = new System.Windows.Forms.ToolStripButton();
            this.btnAddFile = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewModeButton,
            this.btnAddFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(477, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // treeListFiles
            // 
            this.treeListFiles.AllColumns.Add(this.colTitle);
            this.treeListFiles.CellEditUseWholeCell = false;
            this.treeListFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle});
            this.treeListFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.treeListFiles.Location = new System.Drawing.Point(0, 25);
            this.treeListFiles.Name = "treeListFiles";
            this.treeListFiles.ShowGroups = false;
            this.treeListFiles.Size = new System.Drawing.Size(477, 420);
            this.treeListFiles.TabIndex = 1;
            this.treeListFiles.UseCompatibleStateImageBehavior = false;
            this.treeListFiles.View = System.Windows.Forms.View.Details;
            this.treeListFiles.VirtualMode = true;
            // 
            // colTitle
            // 
            this.colTitle.AspectName = "Title";
            // 
            // viewModeButton
            // 
            this.viewModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.viewModeButton.Image = global::Soti.LogReader.Viewer.Properties.Resources.hierarchy;
            this.viewModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewModeButton.Name = "viewModeButton";
            this.viewModeButton.Size = new System.Drawing.Size(23, 22);
            this.viewModeButton.Click += new System.EventHandler(this.viewModeButton_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddFile.Image = global::Soti.LogReader.Viewer.Properties.Resources.add_file;
            this.btnAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(23, 22);
            this.btnAddFile.Text = "Add files...";
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // FilesTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListFiles);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FilesTreeView";
            this.Size = new System.Drawing.Size(477, 445);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private BrightIdeasSoftware.TreeListView treeListFiles;
        private BrightIdeasSoftware.OLVColumn colTitle;
        private System.Windows.Forms.ToolStripButton viewModeButton;
        private System.Windows.Forms.ToolStripButton btnAddFile;
    }
}
