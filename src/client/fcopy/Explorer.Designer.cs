namespace uBizSoft.FileCopy.fCopy
{
    partial class Explorer
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miClose = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lvLFiles = new System.Windows.Forms.ListView();
            this.spLeft = new System.Windows.Forms.Splitter();
            this.tvLFolders = new System.Windows.Forms.TreeView();
            this.m_imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.spCenter = new System.Windows.Forms.Splitter();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lvRFiles = new System.Windows.Forms.ListView();
            this.spRight = new System.Windows.Forms.Splitter();
            this.tvRFolders = new System.Windows.Forms.TreeView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.sbStatus = new System.Windows.Forms.StatusBar();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnMoveToRight = new System.Windows.Forms.Button();
            this.btnMoveToLeft = new System.Windows.Forms.Button();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miClose});
            this.menuItem1.Text = "&File";
            // 
            // miClose
            // 
            this.miClose.Index = 0;
            this.miClose.Text = "Close(&X)";
            this.miClose.Click += new System.EventHandler(this.miClose_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "&Edit";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "&View";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "&Window";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6});
            this.menuItem5.Text = "&Help";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "&About";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lvLFiles);
            this.pnlLeft.Controls.Add(this.spLeft);
            this.pnlLeft.Controls.Add(this.tvLFolders);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 34);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(377, 415);
            this.pnlLeft.TabIndex = 0;
            // 
            // lvLFiles
            // 
            this.lvLFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLFiles.Location = new System.Drawing.Point(122, 0);
            this.lvLFiles.Name = "lvLFiles";
            this.lvLFiles.Size = new System.Drawing.Size(255, 415);
            this.lvLFiles.TabIndex = 7;
            this.lvLFiles.UseCompatibleStateImageBehavior = false;
            this.lvLFiles.View = System.Windows.Forms.View.Details;
            // 
            // spLeft
            // 
            this.spLeft.Location = new System.Drawing.Point(119, 0);
            this.spLeft.Name = "spLeft";
            this.spLeft.Size = new System.Drawing.Size(3, 415);
            this.spLeft.TabIndex = 6;
            this.spLeft.TabStop = false;
            // 
            // tvLFolders
            // 
            this.tvLFolders.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvLFolders.ImageIndex = 0;
            this.tvLFolders.ImageList = this.m_imageListTreeView;
            this.tvLFolders.Location = new System.Drawing.Point(0, 0);
            this.tvLFolders.Name = "tvLFolders";
            this.tvLFolders.SelectedImageIndex = 0;
            this.tvLFolders.Size = new System.Drawing.Size(119, 415);
            this.tvLFolders.TabIndex = 5;
            this.tvLFolders.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvLFolders_AfterExpand);
            this.tvLFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLFolders_AfterSelect);
            // 
            // m_imageListTreeView
            // 
            this.m_imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageListTreeView.ImageStream")));
            this.m_imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageListTreeView.Images.SetKeyName(0, "");
            this.m_imageListTreeView.Images.SetKeyName(1, "");
            this.m_imageListTreeView.Images.SetKeyName(2, "");
            this.m_imageListTreeView.Images.SetKeyName(3, "");
            this.m_imageListTreeView.Images.SetKeyName(4, "");
            this.m_imageListTreeView.Images.SetKeyName(5, "");
            this.m_imageListTreeView.Images.SetKeyName(6, "");
            this.m_imageListTreeView.Images.SetKeyName(7, "");
            this.m_imageListTreeView.Images.SetKeyName(8, "");
            // 
            // spCenter
            // 
            this.spCenter.Location = new System.Drawing.Point(377, 34);
            this.spCenter.Name = "spCenter";
            this.spCenter.Size = new System.Drawing.Size(3, 415);
            this.spCenter.TabIndex = 1;
            this.spCenter.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.lvRFiles);
            this.pnlRight.Controls.Add(this.spRight);
            this.pnlRight.Controls.Add(this.tvRFolders);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(445, 34);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(369, 415);
            this.pnlRight.TabIndex = 2;
            // 
            // lvRFiles
            // 
            this.lvRFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRFiles.Location = new System.Drawing.Point(149, 0);
            this.lvRFiles.Name = "lvRFiles";
            this.lvRFiles.Size = new System.Drawing.Size(220, 415);
            this.lvRFiles.TabIndex = 8;
            this.lvRFiles.UseCompatibleStateImageBehavior = false;
            this.lvRFiles.View = System.Windows.Forms.View.Details;
            // 
            // spRight
            // 
            this.spRight.Location = new System.Drawing.Point(146, 0);
            this.spRight.Name = "spRight";
            this.spRight.Size = new System.Drawing.Size(3, 415);
            this.spRight.TabIndex = 7;
            this.spRight.TabStop = false;
            // 
            // tvRFolders
            // 
            this.tvRFolders.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvRFolders.ImageIndex = 0;
            this.tvRFolders.ImageList = this.m_imageListTreeView;
            this.tvRFolders.Location = new System.Drawing.Point(0, 0);
            this.tvRFolders.Name = "tvRFolders";
            this.tvRFolders.SelectedImageIndex = 0;
            this.tvRFolders.Size = new System.Drawing.Size(146, 415);
            this.tvRFolders.TabIndex = 6;
            this.tvRFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRFolders_AfterSelect);
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(814, 34);
            this.pnlTop.TabIndex = 0;
            // 
            // sbStatus
            // 
            this.sbStatus.Location = new System.Drawing.Point(0, 449);
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.Size = new System.Drawing.Size(814, 22);
            this.sbStatus.TabIndex = 8;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.btnCompare);
            this.pnlMiddle.Controls.Add(this.btnMoveToRight);
            this.pnlMiddle.Controls.Add(this.btnMoveToLeft);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMiddle.Location = new System.Drawing.Point(380, 34);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(65, 415);
            this.pnlMiddle.TabIndex = 10;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(6, 196);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(52, 23);
            this.btnCompare.TabIndex = 2;
            this.btnCompare.Text = "<->";
            this.btnCompare.UseVisualStyleBackColor = true;
            // 
            // btnMoveToRight
            // 
            this.btnMoveToRight.Location = new System.Drawing.Point(7, 140);
            this.btnMoveToRight.Name = "btnMoveToRight";
            this.btnMoveToRight.Size = new System.Drawing.Size(52, 23);
            this.btnMoveToRight.TabIndex = 1;
            this.btnMoveToRight.Text = "->";
            this.btnMoveToRight.UseVisualStyleBackColor = true;
            this.btnMoveToRight.Click += new System.EventHandler(this.btnMoveToRight_Click);
            // 
            // btnMoveToLeft
            // 
            this.btnMoveToLeft.Location = new System.Drawing.Point(7, 92);
            this.btnMoveToLeft.Name = "btnMoveToLeft";
            this.btnMoveToLeft.Size = new System.Drawing.Size(52, 23);
            this.btnMoveToLeft.TabIndex = 0;
            this.btnMoveToLeft.Text = "<-";
            this.btnMoveToLeft.UseVisualStyleBackColor = true;
            this.btnMoveToLeft.Click += new System.EventHandler(this.btnMoveToLeft_Click);
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 471);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.spCenter);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.sbStatus);
            this.Controls.Add(this.pnlTop);
            this.Menu = this.mainMenu1;
            this.Name = "Explorer";
            this.Text = "Form1";
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem miClose;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Splitter spCenter;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.ListView lvLFiles;
        private System.Windows.Forms.Splitter spLeft;
        private System.Windows.Forms.TreeView tvLFolders;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.StatusBar sbStatus;
        private System.Windows.Forms.ListView lvRFiles;
        private System.Windows.Forms.Splitter spRight;
        private System.Windows.Forms.TreeView tvRFolders;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.ImageList m_imageListTreeView;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Button btnMoveToRight;
        private System.Windows.Forms.Button btnMoveToLeft;
        private System.Windows.Forms.Button btnCompare;

    }
}

