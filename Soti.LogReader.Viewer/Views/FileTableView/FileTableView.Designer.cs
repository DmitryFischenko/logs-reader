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
            this.filterTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.clearFilterBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.prevErrorBtn = new System.Windows.Forms.ToolStripButton();
            this.nextErrorBtn = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.entriesNumberTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.fastObjectListView = new BrightIdeasSoftware.FastObjectListView();
            this.colTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colLevel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colComponent = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colCorId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colThread = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.locatorsCb = new System.Windows.Forms.ToolStripComboBox();
            this.prevLocBtn = new System.Windows.Forms.ToolStripButton();
            this.nextLocBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterTextBox,
            this.clearFilterBtn,
            this.toolStripSeparator1,
            this.refreshBtn,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.prevErrorBtn,
            this.nextErrorBtn,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.locatorsCb,
            this.prevLocBtn,
            this.nextLocBtn});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(871, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // filterTextBox
            // 
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(100, 25);
            this.filterTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filterTextBox_KeyUp);
            // 
            // clearFilterBtn
            // 
            this.clearFilterBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearFilterBtn.Image = global::Soti.LogReader.Viewer.Properties.Resources.icons8_clear_filters_26;
            this.clearFilterBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearFilterBtn.Name = "clearFilterBtn";
            this.clearFilterBtn.Size = new System.Drawing.Size(23, 22);
            this.clearFilterBtn.Text = "toolStripButton1";
            this.clearFilterBtn.Click += new System.EventHandler(this.clearFilterBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // refreshBtn
            // 
            this.refreshBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshBtn.Image = global::Soti.LogReader.Viewer.Properties.Resources.icons8_reset_26;
            this.refreshBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(23, 22);
            this.refreshBtn.Text = "toolStripButton1";
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // prevErrorBtn
            // 
            this.prevErrorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevErrorBtn.Image = global::Soti.LogReader.Viewer.Properties.Resources.icons8_long_arrow_up_26;
            this.prevErrorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevErrorBtn.Name = "prevErrorBtn";
            this.prevErrorBtn.Size = new System.Drawing.Size(23, 22);
            this.prevErrorBtn.Text = "Previous Error";
            this.prevErrorBtn.Click += new System.EventHandler(this.prevErrorBtn_Click);
            // 
            // nextErrorBtn
            // 
            this.nextErrorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextErrorBtn.Image = global::Soti.LogReader.Viewer.Properties.Resources.icons8_arrow_pointing_down_26;
            this.nextErrorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextErrorBtn.Name = "nextErrorBtn";
            this.nextErrorBtn.Size = new System.Drawing.Size(23, 22);
            this.nextErrorBtn.Text = "Next Error";
            this.nextErrorBtn.Click += new System.EventHandler(this.nextErrorBtn_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entriesNumberTxt});
            this.statusStrip.Location = new System.Drawing.Point(0, 542);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(871, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // entriesNumberTxt
            // 
            this.entriesNumberTxt.Name = "entriesNumberTxt";
            this.entriesNumberTxt.Size = new System.Drawing.Size(0, 17);
            // 
            // fastObjectListView
            // 
            this.fastObjectListView.AllColumns.Add(this.colTime);
            this.fastObjectListView.AllColumns.Add(this.colLevel);
            this.fastObjectListView.AllColumns.Add(this.colComponent);
            this.fastObjectListView.AllColumns.Add(this.colCorId);
            this.fastObjectListView.AllColumns.Add(this.colThread);
            this.fastObjectListView.AllColumns.Add(this.colMessage);
            this.fastObjectListView.CellEditUseWholeCell = false;
            this.fastObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTime,
            this.colLevel,
            this.colComponent,
            this.colCorId,
            this.colThread,
            this.colMessage});
            this.fastObjectListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView.FullRowSelect = true;
            this.fastObjectListView.Location = new System.Drawing.Point(0, 25);
            this.fastObjectListView.Name = "fastObjectListView";
            this.fastObjectListView.OverlayImage.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.fastObjectListView.OverlayText.Text = "Loading...";
            this.fastObjectListView.ShowGroups = false;
            this.fastObjectListView.Size = new System.Drawing.Size(871, 517);
            this.fastObjectListView.TabIndex = 2;
            this.fastObjectListView.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView.UseFiltering = true;
            this.fastObjectListView.View = System.Windows.Forms.View.Details;
            this.fastObjectListView.VirtualMode = true;
            this.fastObjectListView.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.fastObjectListView_CellClick);
            this.fastObjectListView.SelectionChanged += new System.EventHandler(this.fastObjectListView_SelectionChanged);
            // 
            // colTime
            // 
            this.colTime.AspectName = "TimeCreated";
            this.colTime.AspectToStringFormat = "{0: dd-MM HH:mm:ss.fff }";
            this.colTime.Text = "Time";
            // 
            // colLevel
            // 
            this.colLevel.AspectName = "Level";
            this.colLevel.Searchable = false;
            this.colLevel.Sortable = false;
            this.colLevel.Text = "Level";
            // 
            // colComponent
            // 
            this.colComponent.AspectName = "Component";
            this.colComponent.Sortable = false;
            this.colComponent.Text = "Component";
            // 
            // colCorId
            // 
            this.colCorId.AspectName = "CorrelationId";
            this.colCorId.Sortable = false;
            this.colCorId.Text = "CorrelationId";
            // 
            // colThread
            // 
            this.colThread.AspectName = "Thread";
            this.colThread.Searchable = false;
            this.colThread.Sortable = false;
            this.colThread.Text = "Thread";
            this.colThread.UseFiltering = false;
            // 
            // colMessage
            // 
            this.colMessage.AspectName = "Message";
            this.colMessage.IsEditable = false;
            this.colMessage.Sortable = false;
            this.colMessage.Text = "Message";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "Locators:";
            // 
            // locatorsCb
            // 
            this.locatorsCb.Name = "locatorsCb";
            this.locatorsCb.Size = new System.Drawing.Size(121, 25);
            // 
            // prevLocBtn
            // 
            this.prevLocBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevLocBtn.Image = global::Soti.LogReader.Viewer.Properties.Resources.icons8_long_arrow_up_26;
            this.prevLocBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevLocBtn.Name = "prevLocBtn";
            this.prevLocBtn.Size = new System.Drawing.Size(23, 22);
            this.prevLocBtn.Text = "toolStripButton1";
            // 
            // nextLocBtn
            // 
            this.nextLocBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextLocBtn.Image = global::Soti.LogReader.Viewer.Properties.Resources.icons8_arrow_pointing_down_26;
            this.nextLocBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextLocBtn.Name = "nextLocBtn";
            this.nextLocBtn.Size = new System.Drawing.Size(23, 22);
            this.nextLocBtn.Text = "toolStripButton2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel2.Text = "Errors:";
            // 
            // FileTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 564);
            this.Controls.Add(this.fastObjectListView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.KeyPreview = true;
            this.Name = "FileTableView";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileTableView_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton clearFilterBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton refreshBtn;
        private System.Windows.Forms.ToolStripStatusLabel entriesNumberTxt;
        private BrightIdeasSoftware.OLVColumn colLevel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton prevErrorBtn;
        private System.Windows.Forms.ToolStripButton nextErrorBtn;
        private BrightIdeasSoftware.OLVColumn colComponent;
        private BrightIdeasSoftware.OLVColumn colCorId;
        private BrightIdeasSoftware.OLVColumn colThread;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox locatorsCb;
        private System.Windows.Forms.ToolStripButton prevLocBtn;
        private System.Windows.Forms.ToolStripButton nextLocBtn;
    }
}
