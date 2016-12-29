using FontManager.UI.Control;

namespace FontManager.UI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.tblPnlTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pnlColumn1 = new System.Windows.Forms.Panel();
            this.btnViewFontInfo = new System.Windows.Forms.Button();
            this.btnViewSentencesSample = new System.Windows.Forms.Button();
            this.btnViewGridSample = new System.Windows.Forms.Button();
            this.btnViewAz09Sample = new System.Windows.Forms.Button();
            this.pnlColumn2 = new System.Windows.Forms.Panel();
            this.btnDisOrEnableFont = new System.Windows.Forms.Button();
            this.btnAddFonts = new System.Windows.Forms.Button();
            this.pnlColumn3 = new System.Windows.Forms.Panel();
            this.pnlColumn3Child = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlSearchBox = new System.Windows.Forms.Panel();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.picbxSearchOption = new System.Windows.Forms.PictureBox();
            this.tblPnlBody = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnFontsUser = new System.Windows.Forms.Button();
            this.btnFontsSystem = new System.Windows.Forms.Button();
            this.btnAllFonts = new System.Windows.Forms.Button();
            this.pnlListFont = new System.Windows.Forms.Panel();
            this.pnlShowContent = new System.Windows.Forms.Panel();
            this.pnlViewGridSample = new System.Windows.Forms.Panel();
            this.pnlViewGridSampleChild = new System.Windows.Forms.Panel();
            this.cbSubsetFont = new System.Windows.Forms.ComboBox();
            this.pnlViewFontInfo = new System.Windows.Forms.Panel();
            this.pnlFontInfoBottomView = new System.Windows.Forms.Panel();
            this.pnlFontInforTopView = new System.Windows.Forms.Panel();
            this.lblFontInfoFontStyle = new System.Windows.Forms.Label();
            this.lblFontInfoTitleFont = new System.Windows.Forms.Label();
            this.pnlViewSentencesSample = new System.Windows.Forms.Panel();
            this.trbrEditSizeFontSentencesView = new System.Windows.Forms.TrackBar();
            this.pnlViewSentencesSampleChild = new System.Windows.Forms.Panel();
            this.rtxtViewSentencesSample = new System.Windows.Forms.RichTextBox();
            this.pnlViewAz09Sample = new System.Windows.Forms.Panel();
            this.trbrEditSizeFontAz09View = new System.Windows.Forms.TrackBar();
            this.pnlViewAz09SampleChild = new System.Windows.Forms.Panel();
            this.rtxtViewAz09Sample = new System.Windows.Forms.RichTextBox();
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblPlaceholder = new System.Windows.Forms.Label();
            this.lbFonts = new FontManager.UI.Control.FontListBox();
            this.pnlDrawCharacter = new FontManager.UI.Control.DoubleBufferPanel();
            this.pnlTitle.SuspendLayout();
            this.tblPnlTitle.SuspendLayout();
            this.pnlColumn1.SuspendLayout();
            this.pnlColumn2.SuspendLayout();
            this.pnlColumn3.SuspendLayout();
            this.pnlColumn3Child.SuspendLayout();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbxSearchOption)).BeginInit();
            this.tblPnlBody.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlListFont.SuspendLayout();
            this.pnlShowContent.SuspendLayout();
            this.pnlViewGridSample.SuspendLayout();
            this.pnlViewGridSampleChild.SuspendLayout();
            this.pnlViewFontInfo.SuspendLayout();
            this.pnlFontInforTopView.SuspendLayout();
            this.pnlViewSentencesSample.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbrEditSizeFontSentencesView)).BeginInit();
            this.pnlViewSentencesSampleChild.SuspendLayout();
            this.pnlViewAz09Sample.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbrEditSizeFontAz09View)).BeginInit();
            this.pnlViewAz09SampleChild.SuspendLayout();
            this.pnlBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlTitle.Controls.Add(this.tblPnlTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(4, 4);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1182, 40);
            this.pnlTitle.TabIndex = 0;
            // 
            // tblPnlTitle
            // 
            this.tblPnlTitle.ColumnCount = 3;
            this.tblPnlTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tblPnlTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tblPnlTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblPnlTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblPnlTitle.Controls.Add(this.pnlColumn1, 0, 0);
            this.tblPnlTitle.Controls.Add(this.pnlColumn2, 1, 0);
            this.tblPnlTitle.Controls.Add(this.pnlColumn3, 2, 0);
            this.tblPnlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPnlTitle.Location = new System.Drawing.Point(0, 0);
            this.tblPnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tblPnlTitle.Name = "tblPnlTitle";
            this.tblPnlTitle.RowCount = 1;
            this.tblPnlTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPnlTitle.Size = new System.Drawing.Size(1182, 40);
            this.tblPnlTitle.TabIndex = 0;
            // 
            // pnlColumn1
            // 
            this.pnlColumn1.Controls.Add(this.btnViewFontInfo);
            this.pnlColumn1.Controls.Add(this.btnViewSentencesSample);
            this.pnlColumn1.Controls.Add(this.btnViewGridSample);
            this.pnlColumn1.Controls.Add(this.btnViewAz09Sample);
            this.pnlColumn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColumn1.Location = new System.Drawing.Point(0, 0);
            this.pnlColumn1.Margin = new System.Windows.Forms.Padding(0);
            this.pnlColumn1.Name = "pnlColumn1";
            this.pnlColumn1.Size = new System.Drawing.Size(220, 40);
            this.pnlColumn1.TabIndex = 0;
            // 
            // btnViewFontInfo
            // 
            this.btnViewFontInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnViewFontInfo.FlatAppearance.BorderSize = 0;
            this.btnViewFontInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewFontInfo.Image = global::FontManager.Properties.Resources.icon_info_16x16;
            this.btnViewFontInfo.Location = new System.Drawing.Point(150, 0);
            this.btnViewFontInfo.Name = "btnViewFontInfo";
            this.btnViewFontInfo.Size = new System.Drawing.Size(50, 40);
            this.btnViewFontInfo.TabIndex = 5;
            this.mainToolTip.SetToolTip(this.btnViewFontInfo, "View font\'s info");
            this.btnViewFontInfo.UseVisualStyleBackColor = true;
            // 
            // btnViewSentencesSample
            // 
            this.btnViewSentencesSample.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnViewSentencesSample.FlatAppearance.BorderSize = 0;
            this.btnViewSentencesSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSentencesSample.Image = global::FontManager.Properties.Resources.icon_font_24x24;
            this.btnViewSentencesSample.Location = new System.Drawing.Point(100, 0);
            this.btnViewSentencesSample.Name = "btnViewSentencesSample";
            this.btnViewSentencesSample.Size = new System.Drawing.Size(50, 40);
            this.btnViewSentencesSample.TabIndex = 4;
            this.mainToolTip.SetToolTip(this.btnViewSentencesSample, "View a sample of sentences");
            this.btnViewSentencesSample.UseVisualStyleBackColor = true;
            // 
            // btnViewGridSample
            // 
            this.btnViewGridSample.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnViewGridSample.FlatAppearance.BorderSize = 0;
            this.btnViewGridSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewGridSample.Image = global::FontManager.Properties.Resources.icon_grid_layout_24x24;
            this.btnViewGridSample.Location = new System.Drawing.Point(50, 0);
            this.btnViewGridSample.Name = "btnViewGridSample";
            this.btnViewGridSample.Size = new System.Drawing.Size(50, 40);
            this.btnViewGridSample.TabIndex = 3;
            this.mainToolTip.SetToolTip(this.btnViewGridSample, "View a sample of full symbols");
            this.btnViewGridSample.UseVisualStyleBackColor = true;
            // 
            // btnViewAz09Sample
            // 
            this.btnViewAz09Sample.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnViewAz09Sample.FlatAppearance.BorderSize = 0;
            this.btnViewAz09Sample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAz09Sample.Image = global::FontManager.Properties.Resources.icon_center_alignment_2_24x24;
            this.btnViewAz09Sample.Location = new System.Drawing.Point(0, 0);
            this.btnViewAz09Sample.Name = "btnViewAz09Sample";
            this.btnViewAz09Sample.Size = new System.Drawing.Size(50, 40);
            this.btnViewAz09Sample.TabIndex = 2;
            this.mainToolTip.SetToolTip(this.btnViewAz09Sample, "View a sample of symbols");
            this.btnViewAz09Sample.UseVisualStyleBackColor = true;
            // 
            // pnlColumn2
            // 
            this.pnlColumn2.Controls.Add(this.btnDisOrEnableFont);
            this.pnlColumn2.Controls.Add(this.btnAddFonts);
            this.pnlColumn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColumn2.Location = new System.Drawing.Point(220, 0);
            this.pnlColumn2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlColumn2.Name = "pnlColumn2";
            this.pnlColumn2.Size = new System.Drawing.Size(250, 40);
            this.pnlColumn2.TabIndex = 1;
            // 
            // btnDisOrEnableFont
            // 
            this.btnDisOrEnableFont.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDisOrEnableFont.FlatAppearance.BorderSize = 0;
            this.btnDisOrEnableFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisOrEnableFont.Image = global::FontManager.Properties.Resources.icon_checkbox_16x16;
            this.btnDisOrEnableFont.Location = new System.Drawing.Point(50, 0);
            this.btnDisOrEnableFont.Name = "btnDisOrEnableFont";
            this.btnDisOrEnableFont.Size = new System.Drawing.Size(50, 40);
            this.btnDisOrEnableFont.TabIndex = 1;
            this.mainToolTip.SetToolTip(this.btnDisOrEnableFont, "Enable/disable font");
            this.btnDisOrEnableFont.UseVisualStyleBackColor = true;
            // 
            // btnAddFonts
            // 
            this.btnAddFonts.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddFonts.FlatAppearance.BorderSize = 0;
            this.btnAddFonts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFonts.Image = global::FontManager.Properties.Resources.icon_plus_16x16;
            this.btnAddFonts.Location = new System.Drawing.Point(0, 0);
            this.btnAddFonts.Name = "btnAddFonts";
            this.btnAddFonts.Size = new System.Drawing.Size(50, 40);
            this.btnAddFonts.TabIndex = 0;
            this.mainToolTip.SetToolTip(this.btnAddFonts, "Insert/install fonts");
            this.btnAddFonts.UseVisualStyleBackColor = true;
            // 
            // pnlColumn3
            // 
            this.pnlColumn3.Controls.Add(this.pnlColumn3Child);
            this.pnlColumn3.Controls.Add(this.pnlSearchBox);
            this.pnlColumn3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColumn3.Location = new System.Drawing.Point(470, 0);
            this.pnlColumn3.Margin = new System.Windows.Forms.Padding(0);
            this.pnlColumn3.Name = "pnlColumn3";
            this.pnlColumn3.Size = new System.Drawing.Size(712, 40);
            this.pnlColumn3.TabIndex = 2;
            // 
            // pnlColumn3Child
            // 
            this.pnlColumn3Child.Controls.Add(this.btnMinimize);
            this.pnlColumn3Child.Controls.Add(this.btnMaximize);
            this.pnlColumn3Child.Controls.Add(this.btnClose);
            this.pnlColumn3Child.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlColumn3Child.Location = new System.Drawing.Point(531, 0);
            this.pnlColumn3Child.Margin = new System.Windows.Forms.Padding(0);
            this.pnlColumn3Child.Name = "pnlColumn3Child";
            this.pnlColumn3Child.Size = new System.Drawing.Size(181, 40);
            this.pnlColumn3Child.TabIndex = 3;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::FontManager.Properties.Resources.icon_minimize_2_16x16;
            this.btnMinimize.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimize.Location = new System.Drawing.Point(31, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(50, 40);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.UseVisualStyleBackColor = true;
            // 
            // btnMaximize
            // 
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximize.Image")));
            this.btnMaximize.Location = new System.Drawing.Point(81, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(50, 40);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::FontManager.Properties.Resources.icon_close_16x16;
            this.btnClose.Location = new System.Drawing.Point(131, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.Controls.Add(this.lblPlaceholder);
            this.pnlSearchBox.Controls.Add(this.txtSearchBox);
            this.pnlSearchBox.Controls.Add(this.picbxSearchOption);
            this.pnlSearchBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSearchBox.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(400, 40);
            this.pnlSearchBox.TabIndex = 1;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBox.Location = new System.Drawing.Point(39, 11);
            this.txtSearchBox.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(357, 19);
            this.txtSearchBox.TabIndex = 1;
            this.mainToolTip.SetToolTip(this.txtSearchBox, "Search for a font");
            this.txtSearchBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchBox_KeyUp);
            // 
            // picbxSearchOption
            // 
            this.picbxSearchOption.BackgroundImage = global::FontManager.Properties.Resources.icon_down_arrow_16x16;
            this.picbxSearchOption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picbxSearchOption.Dock = System.Windows.Forms.DockStyle.Left;
            this.picbxSearchOption.Location = new System.Drawing.Point(0, 0);
            this.picbxSearchOption.Name = "picbxSearchOption";
            this.picbxSearchOption.Size = new System.Drawing.Size(40, 40);
            this.picbxSearchOption.TabIndex = 0;
            this.picbxSearchOption.TabStop = false;
            this.mainToolTip.SetToolTip(this.picbxSearchOption, "Search option");
            // 
            // tblPnlBody
            // 
            this.tblPnlBody.ColumnCount = 3;
            this.tblPnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tblPnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tblPnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblPnlBody.Controls.Add(this.pnlMenu, 0, 0);
            this.tblPnlBody.Controls.Add(this.pnlListFont, 1, 0);
            this.tblPnlBody.Controls.Add(this.pnlShowContent, 2, 0);
            this.tblPnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPnlBody.Location = new System.Drawing.Point(4, 44);
            this.tblPnlBody.Name = "tblPnlBody";
            this.tblPnlBody.RowCount = 1;
            this.tblPnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPnlBody.Size = new System.Drawing.Size(1182, 642);
            this.tblPnlBody.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnFontsUser);
            this.pnlMenu.Controls.Add(this.btnFontsSystem);
            this.pnlMenu.Controls.Add(this.btnAllFonts);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(220, 642);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnFontsUser
            // 
            this.btnFontsUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFontsUser.FlatAppearance.BorderSize = 0;
            this.btnFontsUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFontsUser.Image = global::FontManager.Properties.Resources.icon_user_2_16x16;
            this.btnFontsUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFontsUser.Location = new System.Drawing.Point(0, 80);
            this.btnFontsUser.Name = "btnFontsUser";
            this.btnFontsUser.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnFontsUser.Size = new System.Drawing.Size(220, 40);
            this.btnFontsUser.TabIndex = 5;
            this.btnFontsUser.Text = "  User";
            this.btnFontsUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFontsUser.UseVisualStyleBackColor = true;
            // 
            // btnFontsSystem
            // 
            this.btnFontsSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFontsSystem.FlatAppearance.BorderSize = 0;
            this.btnFontsSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFontsSystem.Image = global::FontManager.Properties.Resources.icon_computer_16x16;
            this.btnFontsSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFontsSystem.Location = new System.Drawing.Point(0, 40);
            this.btnFontsSystem.Name = "btnFontsSystem";
            this.btnFontsSystem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnFontsSystem.Size = new System.Drawing.Size(220, 40);
            this.btnFontsSystem.TabIndex = 4;
            this.btnFontsSystem.Text = "  Computer";
            this.btnFontsSystem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFontsSystem.UseVisualStyleBackColor = true;
            // 
            // btnAllFonts
            // 
            this.btnAllFonts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAllFonts.FlatAppearance.BorderSize = 0;
            this.btnAllFonts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllFonts.Image = global::FontManager.Properties.Resources.icon_all_font_2_16x16;
            this.btnAllFonts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllFonts.Location = new System.Drawing.Point(0, 0);
            this.btnAllFonts.Name = "btnAllFonts";
            this.btnAllFonts.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAllFonts.Size = new System.Drawing.Size(220, 40);
            this.btnAllFonts.TabIndex = 3;
            this.btnAllFonts.Text = "  All Fonts";
            this.btnAllFonts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllFonts.UseVisualStyleBackColor = true;
            // 
            // pnlListFont
            // 
            this.pnlListFont.Controls.Add(this.lbFonts);
            this.pnlListFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListFont.Location = new System.Drawing.Point(220, 0);
            this.pnlListFont.Margin = new System.Windows.Forms.Padding(0);
            this.pnlListFont.Name = "pnlListFont";
            this.pnlListFont.Size = new System.Drawing.Size(250, 642);
            this.pnlListFont.TabIndex = 1;
            // 
            // pnlShowContent
            // 
            this.pnlShowContent.Controls.Add(this.pnlViewGridSample);
            this.pnlShowContent.Controls.Add(this.pnlViewFontInfo);
            this.pnlShowContent.Controls.Add(this.pnlViewSentencesSample);
            this.pnlShowContent.Controls.Add(this.pnlViewAz09Sample);
            this.pnlShowContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShowContent.Location = new System.Drawing.Point(470, 0);
            this.pnlShowContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlShowContent.Name = "pnlShowContent";
            this.pnlShowContent.Size = new System.Drawing.Size(712, 642);
            this.pnlShowContent.TabIndex = 2;
            // 
            // pnlViewGridSample
            // 
            this.pnlViewGridSample.Controls.Add(this.pnlViewGridSampleChild);
            this.pnlViewGridSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewGridSample.Location = new System.Drawing.Point(0, 0);
            this.pnlViewGridSample.Name = "pnlViewGridSample";
            this.pnlViewGridSample.Size = new System.Drawing.Size(712, 642);
            this.pnlViewGridSample.TabIndex = 0;
            // 
            // pnlViewGridSampleChild
            // 
            this.pnlViewGridSampleChild.Controls.Add(this.pnlDrawCharacter);
            this.pnlViewGridSampleChild.Controls.Add(this.cbSubsetFont);
            this.pnlViewGridSampleChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewGridSampleChild.Location = new System.Drawing.Point(0, 0);
            this.pnlViewGridSampleChild.Name = "pnlViewGridSampleChild";
            this.pnlViewGridSampleChild.Padding = new System.Windows.Forms.Padding(0, 0, 56, 0);
            this.pnlViewGridSampleChild.Size = new System.Drawing.Size(712, 642);
            this.pnlViewGridSampleChild.TabIndex = 6;
            // 
            // cbSubsetFont
            // 
            this.cbSubsetFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubsetFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubsetFont.FormattingEnabled = true;
            this.cbSubsetFont.Location = new System.Drawing.Point(468, 17);
            this.cbSubsetFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSubsetFont.Name = "cbSubsetFont";
            this.cbSubsetFont.Size = new System.Drawing.Size(188, 24);
            this.cbSubsetFont.TabIndex = 2;
            // 
            // pnlViewFontInfo
            // 
            this.pnlViewFontInfo.Controls.Add(this.pnlFontInfoBottomView);
            this.pnlViewFontInfo.Controls.Add(this.pnlFontInforTopView);
            this.pnlViewFontInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewFontInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlViewFontInfo.Name = "pnlViewFontInfo";
            this.pnlViewFontInfo.Size = new System.Drawing.Size(712, 642);
            this.pnlViewFontInfo.TabIndex = 0;
            // 
            // pnlFontInfoBottomView
            // 
            this.pnlFontInfoBottomView.AutoScroll = true;
            this.pnlFontInfoBottomView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFontInfoBottomView.Location = new System.Drawing.Point(0, 79);
            this.pnlFontInfoBottomView.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFontInfoBottomView.Name = "pnlFontInfoBottomView";
            this.pnlFontInfoBottomView.Size = new System.Drawing.Size(712, 563);
            this.pnlFontInfoBottomView.TabIndex = 2;
            // 
            // pnlFontInforTopView
            // 
            this.pnlFontInforTopView.Controls.Add(this.lblFontInfoFontStyle);
            this.pnlFontInforTopView.Controls.Add(this.lblFontInfoTitleFont);
            this.pnlFontInforTopView.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFontInforTopView.Location = new System.Drawing.Point(0, 0);
            this.pnlFontInforTopView.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFontInforTopView.Name = "pnlFontInforTopView";
            this.pnlFontInforTopView.Size = new System.Drawing.Size(712, 79);
            this.pnlFontInforTopView.TabIndex = 3;
            // 
            // lblFontInfoFontStyle
            // 
            this.lblFontInfoFontStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFontInfoFontStyle.AutoSize = true;
            this.lblFontInfoFontStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFontInfoFontStyle.Location = new System.Drawing.Point(280, 43);
            this.lblFontInfoFontStyle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFontInfoFontStyle.Name = "lblFontInfoFontStyle";
            this.lblFontInfoFontStyle.Size = new System.Drawing.Size(120, 29);
            this.lblFontInfoFontStyle.TabIndex = 1;
            this.lblFontInfoFontStyle.Text = "Font Style";
            this.lblFontInfoFontStyle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFontInfoTitleFont
            // 
            this.lblFontInfoTitleFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFontInfoTitleFont.AutoSize = true;
            this.lblFontInfoTitleFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFontInfoTitleFont.Location = new System.Drawing.Point(267, 7);
            this.lblFontInfoTitleFont.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFontInfoTitleFont.Name = "lblFontInfoTitleFont";
            this.lblFontInfoTitleFont.Size = new System.Drawing.Size(160, 36);
            this.lblFontInfoTitleFont.TabIndex = 0;
            this.lblFontInfoTitleFont.Text = "Font Name";
            this.lblFontInfoTitleFont.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlViewSentencesSample
            // 
            this.pnlViewSentencesSample.Controls.Add(this.trbrEditSizeFontSentencesView);
            this.pnlViewSentencesSample.Controls.Add(this.pnlViewSentencesSampleChild);
            this.pnlViewSentencesSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewSentencesSample.Location = new System.Drawing.Point(0, 0);
            this.pnlViewSentencesSample.Name = "pnlViewSentencesSample";
            this.pnlViewSentencesSample.Size = new System.Drawing.Size(712, 642);
            this.pnlViewSentencesSample.TabIndex = 0;
            // 
            // trbrEditSizeFontSentencesView
            // 
            this.trbrEditSizeFontSentencesView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trbrEditSizeFontSentencesView.Location = new System.Drawing.Point(656, 0);
            this.trbrEditSizeFontSentencesView.Maximum = 6;
            this.trbrEditSizeFontSentencesView.Minimum = 1;
            this.trbrEditSizeFontSentencesView.Name = "trbrEditSizeFontSentencesView";
            this.trbrEditSizeFontSentencesView.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trbrEditSizeFontSentencesView.Size = new System.Drawing.Size(56, 150);
            this.trbrEditSizeFontSentencesView.TabIndex = 4;
            this.trbrEditSizeFontSentencesView.Value = 1;
            // 
            // pnlViewSentencesSampleChild
            // 
            this.pnlViewSentencesSampleChild.Controls.Add(this.rtxtViewSentencesSample);
            this.pnlViewSentencesSampleChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewSentencesSampleChild.Location = new System.Drawing.Point(0, 0);
            this.pnlViewSentencesSampleChild.Name = "pnlViewSentencesSampleChild";
            this.pnlViewSentencesSampleChild.Padding = new System.Windows.Forms.Padding(56, 0, 56, 0);
            this.pnlViewSentencesSampleChild.Size = new System.Drawing.Size(712, 642);
            this.pnlViewSentencesSampleChild.TabIndex = 5;
            // 
            // rtxtViewSentencesSample
            // 
            this.rtxtViewSentencesSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtViewSentencesSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtViewSentencesSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtViewSentencesSample.Location = new System.Drawing.Point(56, 0);
            this.rtxtViewSentencesSample.Name = "rtxtViewSentencesSample";
            this.rtxtViewSentencesSample.Size = new System.Drawing.Size(600, 642);
            this.rtxtViewSentencesSample.TabIndex = 4;
            this.rtxtViewSentencesSample.Text = resources.GetString("rtxtViewSentencesSample.Text");
            // 
            // pnlViewAz09Sample
            // 
            this.pnlViewAz09Sample.Controls.Add(this.trbrEditSizeFontAz09View);
            this.pnlViewAz09Sample.Controls.Add(this.pnlViewAz09SampleChild);
            this.pnlViewAz09Sample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewAz09Sample.Location = new System.Drawing.Point(0, 0);
            this.pnlViewAz09Sample.Name = "pnlViewAz09Sample";
            this.pnlViewAz09Sample.Size = new System.Drawing.Size(712, 642);
            this.pnlViewAz09Sample.TabIndex = 0;
            // 
            // trbrEditSizeFontAz09View
            // 
            this.trbrEditSizeFontAz09View.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trbrEditSizeFontAz09View.Location = new System.Drawing.Point(656, 0);
            this.trbrEditSizeFontAz09View.Maximum = 6;
            this.trbrEditSizeFontAz09View.Minimum = 1;
            this.trbrEditSizeFontAz09View.Name = "trbrEditSizeFontAz09View";
            this.trbrEditSizeFontAz09View.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trbrEditSizeFontAz09View.Size = new System.Drawing.Size(56, 150);
            this.trbrEditSizeFontAz09View.TabIndex = 2;
            this.trbrEditSizeFontAz09View.Value = 1;
            // 
            // pnlViewAz09SampleChild
            // 
            this.pnlViewAz09SampleChild.Controls.Add(this.rtxtViewAz09Sample);
            this.pnlViewAz09SampleChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewAz09SampleChild.Location = new System.Drawing.Point(0, 0);
            this.pnlViewAz09SampleChild.Name = "pnlViewAz09SampleChild";
            this.pnlViewAz09SampleChild.Padding = new System.Windows.Forms.Padding(56, 0, 56, 0);
            this.pnlViewAz09SampleChild.Size = new System.Drawing.Size(712, 642);
            this.pnlViewAz09SampleChild.TabIndex = 6;
            // 
            // rtxtViewAz09Sample
            // 
            this.rtxtViewAz09Sample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtViewAz09Sample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtViewAz09Sample.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtViewAz09Sample.Location = new System.Drawing.Point(56, 0);
            this.rtxtViewAz09Sample.Name = "rtxtViewAz09Sample";
            this.rtxtViewAz09Sample.Size = new System.Drawing.Size(600, 642);
            this.rtxtViewAz09Sample.TabIndex = 2;
            this.rtxtViewAz09Sample.Text = "\n\nABCDEFGHIJKLM\n\nNOPQRSTUVWXYZ\n\nabcdefghijklm\n\nnopqrstuvwxyz\n\n1234567890";
            // 
            // pnlBorder
            // 
            this.pnlBorder.AllowDrop = true;
            this.pnlBorder.Controls.Add(this.tblPnlBody);
            this.pnlBorder.Controls.Add(this.pnlTitle);
            this.pnlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorder.Location = new System.Drawing.Point(5, 5);
            this.pnlBorder.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Padding = new System.Windows.Forms.Padding(4);
            this.pnlBorder.Size = new System.Drawing.Size(1190, 690);
            this.pnlBorder.TabIndex = 1;
            // 
            // lblPlaceholder
            // 
            this.lblPlaceholder.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblPlaceholder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblPlaceholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaceholder.Location = new System.Drawing.Point(37, 10);
            this.lblPlaceholder.Name = "lblPlaceholder";
            this.lblPlaceholder.Size = new System.Drawing.Size(360, 21);
            this.lblPlaceholder.TabIndex = 2;
            this.lblPlaceholder.Text = "<Placeholder>";
            // 
            // lbFonts
            // 
            this.lbFonts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbFonts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFonts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbFonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFonts.FormattingEnabled = true;
            this.lbFonts.Location = new System.Drawing.Point(0, 0);
            this.lbFonts.Name = "lbFonts";
            this.lbFonts.Size = new System.Drawing.Size(250, 642);
            this.lbFonts.TabIndex = 0;
            // 
            // pnlDrawCharacter
            // 
            this.pnlDrawCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDrawCharacter.AutoScroll = true;
            this.pnlDrawCharacter.Location = new System.Drawing.Point(25, 72);
            this.pnlDrawCharacter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDrawCharacter.Name = "pnlDrawCharacter";
            this.pnlDrawCharacter.Size = new System.Drawing.Size(631, 570);
            this.pnlDrawCharacter.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Font Manager";
            this.pnlTitle.ResumeLayout(false);
            this.tblPnlTitle.ResumeLayout(false);
            this.pnlColumn1.ResumeLayout(false);
            this.pnlColumn2.ResumeLayout(false);
            this.pnlColumn3.ResumeLayout(false);
            this.pnlColumn3Child.ResumeLayout(false);
            this.pnlSearchBox.ResumeLayout(false);
            this.pnlSearchBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbxSearchOption)).EndInit();
            this.tblPnlBody.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlListFont.ResumeLayout(false);
            this.pnlShowContent.ResumeLayout(false);
            this.pnlViewGridSample.ResumeLayout(false);
            this.pnlViewGridSampleChild.ResumeLayout(false);
            this.pnlViewFontInfo.ResumeLayout(false);
            this.pnlFontInforTopView.ResumeLayout(false);
            this.pnlFontInforTopView.PerformLayout();
            this.pnlViewSentencesSample.ResumeLayout(false);
            this.pnlViewSentencesSample.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbrEditSizeFontSentencesView)).EndInit();
            this.pnlViewSentencesSampleChild.ResumeLayout(false);
            this.pnlViewAz09Sample.ResumeLayout(false);
            this.pnlViewAz09Sample.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbrEditSizeFontAz09View)).EndInit();
            this.pnlViewAz09SampleChild.ResumeLayout(false);
            this.pnlBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.TableLayoutPanel tblPnlBody;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlListFont;
        private System.Windows.Forms.Panel pnlShowContent;
        private System.Windows.Forms.TableLayoutPanel tblPnlTitle;
        private System.Windows.Forms.Panel pnlColumn1;
        private System.Windows.Forms.Panel pnlColumn2;
        private System.Windows.Forms.Panel pnlColumn3;
        private System.Windows.Forms.Panel pnlColumn3Child;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddFonts;
        private System.Windows.Forms.Button btnDisOrEnableFont;
        private System.Windows.Forms.PictureBox picbxSearchOption;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Panel pnlSearchBox;
        private System.Windows.Forms.Button btnViewGridSample;
        private System.Windows.Forms.Button btnViewAz09Sample;
        private System.Windows.Forms.Button btnViewFontInfo;
        private System.Windows.Forms.Button btnViewSentencesSample;
        private System.Windows.Forms.Button btnFontsUser;
        private System.Windows.Forms.Button btnAllFonts;
        private FontManager.UI.Control.FontListBox lbFonts;
        private System.Windows.Forms.Button btnFontsSystem;
        private System.Windows.Forms.Panel pnlViewFontInfo;
        private System.Windows.Forms.Panel pnlViewSentencesSample;
        private System.Windows.Forms.Panel pnlViewGridSample;
        private System.Windows.Forms.Panel pnlViewAz09Sample;
        private System.Windows.Forms.TrackBar trbrEditSizeFontAz09View;
        private System.Windows.Forms.TrackBar trbrEditSizeFontSentencesView;
        private System.Windows.Forms.Panel pnlViewSentencesSampleChild;
        private System.Windows.Forms.Panel pnlViewAz09SampleChild;
        private System.Windows.Forms.Panel pnlViewGridSampleChild;
        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.ToolTip mainToolTip;
        private System.Windows.Forms.RichTextBox rtxtViewAz09Sample;
        private System.Windows.Forms.RichTextBox rtxtViewSentencesSample;
        private System.Windows.Forms.Panel pnlFontInfoBottomView;
        private System.Windows.Forms.Panel pnlFontInforTopView;
        private System.Windows.Forms.Label lblFontInfoFontStyle;
        private System.Windows.Forms.Label lblFontInfoTitleFont;
        private System.Windows.Forms.ComboBox cbSubsetFont;
        private DoubleBufferPanel pnlDrawCharacter;
        private System.Windows.Forms.Label lblPlaceholder;
    }
}