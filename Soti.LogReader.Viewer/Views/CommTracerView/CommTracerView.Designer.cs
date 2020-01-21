namespace Soti.LogReader.Viewer.Views.CommTracerView
{
    partial class CommTracerView
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
            this.fastObjectListView1 = new BrightIdeasSoftware.FastObjectListView();
            this.Message = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Type = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Time = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fastObjectListView1
            // 
            this.fastObjectListView1.AllColumns.Add(this.Type);
            this.fastObjectListView1.AllColumns.Add(this.Message);
            this.fastObjectListView1.AllColumns.Add(this.Time);
            this.fastObjectListView1.CellEditUseWholeCell = false;
            this.fastObjectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Type,
            this.Message,
            this.Time});
            this.fastObjectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView1.FullRowSelect = true;
            this.fastObjectListView1.Location = new System.Drawing.Point(0, 0);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(800, 450);
            this.fastObjectListView1.TabIndex = 0;
            this.fastObjectListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView1.View = System.Windows.Forms.View.Details;
            this.fastObjectListView1.VirtualMode = true;
            this.fastObjectListView1.SelectionChanged += new System.EventHandler(this.fastObjectListView1_SelectionChanged);
            // 
            // Message
            // 
            this.Message.AspectName = "Message";
            this.Message.IsEditable = false;
            this.Message.Sortable = false;
            this.Message.Text = "Message";
            // 
            // Type
            // 
            this.Type.AspectName = "MessageType";
            this.Type.IsEditable = false;
            this.Type.Sortable = false;
            this.Type.Text = "Type";
            // 
            // Time
            // 
            this.Time.AspectName = "TimeStamp";
            this.Time.IsEditable = false;
            this.Time.Text = "Time";
            // 
            // CommTracerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fastObjectListView1);
            this.Name = "CommTracerView";
            this.Text = "CommTracerView";
            this.Load += new System.EventHandler(this.CommTracerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView fastObjectListView1;
        private BrightIdeasSoftware.OLVColumn Message;
        private BrightIdeasSoftware.OLVColumn Type;
        private BrightIdeasSoftware.OLVColumn Time;
    }
}