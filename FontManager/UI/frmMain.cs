using FontManager.Callback;
using FontManager.FontService;
using FontManager.Model;
using FontManager.Properties;
using FontManager.UI.Control;
using FontManager.Utils;
using Newtonsoft.Json;
using SharpFont;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TestCSharpNghia;

namespace FontManager.UI
{
    public partial class frmMain : Form
    {
        #region Khai bao cac thanh phan su dung cho viec Keo' di chuyen form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        #endregion

        #region PhucTV variable
        private enum MenuItem { AllFont, SystemFont, UserFont }
        private const int FORM_PADDING = 5;
        private const int FORM_BORDER_THICKNESS = 2;
        private Color FORM_BORDER_COLOR = ColorHelper.ConvertToARGB("#9ca7a8");             // old version is #7f8c8d
        private Color TITLE_COLOR = ColorHelper.ConvertToARGB("#d4d2d5");                   // old version is #939e9f
        private Color MENU_BACKGROUND_COLOR = ColorHelper.ConvertToARGB("#ededed");         // old version is #D6D6D6
        private Color LIST_FONT_BACKGROUND_COLOR = ColorHelper.ConvertToARGB("#ffffff");    // old version is #bdc3c7
        private Color BODY_VIEW_FONT_CONTENT_COLOR = ColorHelper.ConvertToARGB("#ffffff");  // old version is #ecf0f1
        private Color RADIO_BTN_SELECTED_COLOR = ColorHelper.ConvertToARGB("#bababa");      // old version is #b1bcbd
        private Color SEARCH_BOX_BACKGROUND_COLOR = ColorHelper.ConvertToARGB("#ededed");   // old version is #9da8a9
        private Color PLACEHOLDER_COLOR = Color.Gray; 
        private ContextMenuStrip cmSearchType = new ContextMenuStrip();
        private ContextMenu cmFontItem = new ContextMenu();
        private MenuItem selectedMenuItem;
        private FontFamily defaultFontFamilyViewSample = new FontFamily("Arial");
        private string selectedFontPath = null;
        #endregion

        #region NghiaVN Variable
        private FontManager.Manager.FontManager fontManager;
        private FontReading fontReading;
        private FontInstallation fontInstallation;
        private FileManager fileManager;
        private FontInfo currentFontSelected;
        private SearchType currentSearchType = SearchType.All;
        private SearchEngine searchEngine;
        private string keyWord;
        public event SearchtypeHandler listenter;
        private event LoadBackgroundSuccessHandler loadDataBackLoadListener;
        private const int NUMBER_THREAD_LOAD_BACKGROUND = 2;
        private Board.Board mBoard;
        private FontService.FontService mFontService;
        private int mRows;
        private Label[,] CharactersLabel;
        private List<int> CharacterIndex = new List<int>();
        private bool firstLaunch = false;

        #endregion

        public frmMain()
        {
            InitializeComponent();
            Load += FrmMain_Load;
            Logger.Debug = true;

            // Them callback cho viec Keo' di chuyen form
            #region
            pnlColumn1.MouseDown += DragMoveFormCallback;
            pnlColumn2.MouseDown += DragMoveFormCallback;
            pnlColumn3.MouseDown += DragMoveFormCallback;
            pnlColumn3Child.MouseDown += DragMoveFormCallback;
            listenter += SearchTypeClicked_listenter;
            #endregion


            // Set mau sac cho cac thanh phan cua form
            #region
            SetFormBorderColor(FORM_BORDER_COLOR);
            pnlTitle.BackColor = TITLE_COLOR;
            pnlMenu.BackColor = MENU_BACKGROUND_COLOR;
            pnlListFont.BackColor = LIST_FONT_BACKGROUND_COLOR;
            pnlShowContent.BackColor = BODY_VIEW_FONT_CONTENT_COLOR;
            pnlSearchBox.BackColor = SEARCH_BOX_BACKGROUND_COLOR;
            txtSearchBox.BackColor = SEARCH_BOX_BACKGROUND_COLOR;
            btnViewAz09Sample.PerformClick();
            rtxtViewAz09Sample.BackColor = BODY_VIEW_FONT_CONTENT_COLOR;
            rtxtViewSentencesSample.BackColor = BODY_VIEW_FONT_CONTENT_COLOR;
            // rtxtViewGridSample.BackColor = BODY_VIEW_FONT_CONTENT_COLOR;
            lblPlaceholder.BackColor = SEARCH_BOX_BACKGROUND_COLOR;
            lblPlaceholder.ForeColor = PLACEHOLDER_COLOR;
            #endregion

            // Cac su kien cua cac control
            #region
            btnClose.Click += BtnClose_Click;
            btnMaximize.Click += BtnMaximize_Click;
            this.SizeChanged += FrmMain_SizeChanged;
            btnMinimize.Click += BtnMinimize_Click;
            btnViewAz09Sample.Click += BtnViewAz09Sample_Click;
            btnViewGridSample.Click += BtnViewGridSample_Click;
            btnViewSentencesSample.Click += BtnViewSentencesSample_Click;
            btnViewFontInfo.Click += BtnViewFontInfo_Click;
            picbxSearchOption.Click += PicbxSearchType_Click;
            cmSearchType.ItemClicked += CmSearchOption_ItemClicked;
            btnAddFonts.Click += BtnAddFonts_Click;
            btnDisOrEnableFont.Click += BtnDisOrEnableFont_Click;
            txtSearchBox.TextChanged += TxtSearchBox_TextChanged;
            btnAllFonts.Click += BtnAllFonts_Click;
            btnFontsSystem.Click += BtnFontsSystem_Click;
            btnFontsUser.Click += BtnFontsUser_Click;
            lbFonts.MouseDown += LbFonts_MouseDown;
            trbrEditSizeFontAz09View.Scroll += TrbrEditSizeFontAz09View_Scroll;
            trbrEditSizeFontSentencesView.Scroll += TrbrEditSizeFontSentencesView_Scroll;
            txtSearchBox.LostFocus += txtSearchBox_LostFocus;
            lblPlaceholder.Click += LblPlaceholder_Click;


            #endregion

            // Khoi tao mot vai thanh phan
            #region
            MakeFormBackgroundTransparent(Color.MediumAquamarine);

            cmSearchType.Items.Add("All");
            cmSearchType.Items.Add("PostScript name");
            cmSearchType.Items.Add("Family");
            cmSearchType.Items.Add("Style");
            //cmSearchOption.Items.Add("Kind");
            cmSearchType.Items.Add("Copyright");
            cmSearchType.Items.Add("Language");
            cmSearchType.Items.Add("File name");
            cmSearchType.Items.Add("Manufacturer name");
            cmSearchType.Items.Add("Designer name");
            cmSearchType.Items.Add("Subsets");
            //cmSearchOption.Items.Add("Repertoire");

            cmFontItem.MenuItems.Add("Add Fonts...", new EventHandler(CmFontItemAddFont_Click));
            cmFontItem.MenuItems.Add("Enable/disable Font", new EventHandler(CmFontItemEnDisableFont_Click));
            cmFontItem.MenuItems.Add("Open file location", new EventHandler(CmFontItemOpenFileLocation_Click));

            ((ToolStripMenuItem)cmSearchType.Items[0]).Checked = true;
            selectedMenuItem = MenuItem.AllFont;


            rtxtViewAz09Sample.SelectAll();
            rtxtViewAz09Sample.SelectionAlignment = HorizontalAlignment.Center;
            rtxtViewAz09Sample.Select(1, 0);
            lblPlaceholder.Text = "Type for search all...";
            #endregion

            //font info view 
            #region Tamphu.pn

            FontInfoUc uc = new FontInfoUc("PostScript name", "none");
            FontInfoUc uc2 = new FontInfoUc("Language", "none");
            FontInfoUc uc1 = new FontInfoUc("Fullname", "none");
            FontInfoUc uc3 = new FontInfoUc("Family", "none");
            FontInfoUc uc4 = new FontInfoUc("Style", "none");
            FontInfoUc uc5 = new FontInfoUc("Kind", "none");
            FontInfoUc uc6 = new FontInfoUc("Script", "none");
            FontInfoUc uc7 = new FontInfoUc("Verson", "none");
            FontInfoUc uc8 = new FontInfoUc("Location", "none");
            FontInfoUc uc9 = new FontInfoUc("Unique name", "none");
            FontInfoUc uc10 = new FontInfoUc("Manufacturer", "none");
            FontInfoUc uc11 = new FontInfoUc("Designer", "none");
            FontInfoUc uc12 = new FontInfoUc("Copyright", "none");
            FontInfoUc uc13 = new FontInfoUc("TradeMark", "none");
            FontInfoUc uc14 = new FontInfoUc("License", "none");
            FontInfoUc uc15 = new FontInfoUc("GlyphCount", "none");


            pnlFontInfoBottomView.Controls.Add(uc15);
            uc15.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc14);
            uc14.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc13);
            uc13.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc12);
            uc12.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc11);
            uc11.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc10);
            uc10.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc9);
            uc9.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc8);
            uc8.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc7);
            uc7.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc6);
            uc6.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc2);
            uc2.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc5);
            uc5.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc4);
            uc4.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc3);
            uc3.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc1);
            uc1.Dock = DockStyle.Top;
            pnlFontInfoBottomView.Controls.Add(uc);
            uc.Dock = DockStyle.Top;
            FontInfoUc uc16 = new FontInfoUc("Subset Font", "none");

            pnlFontInfoBottomView.Controls.Add(uc16);
            uc16.Dock = DockStyle.Top;
            #endregion
        }

        private void LblPlaceholder_Click(object sender, EventArgs e)
        {
            lblPlaceholder.Visible = false;
            txtSearchBox.Focus();
        }

      public class SortSubset : IComparer<Subset>
        {
            public int Compare(Subset x, Subset y)
            {
                return string.Compare(x.name, y.name);
            }
        }

        public void txtSearchBox_LostFocus(object sender, EventArgs e)
        {
            //if (String.IsNullOrWhiteSpace(txtSearchBox.Text))
            //    txtSearchBox.Text = "Enter text here...";
            if (txtSearchBox.Text.Length == 0)
                lblPlaceholder.Visible = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            #region NghiaNV
            fileManager = FileManager.GetInstance();
            fontManager = FontManager.Manager.FontManager.GetInstance();
            fontInstallation = new FontInstallation();

            fontReading = new FontReading();
            fontInstallation = new FontInstallation();
            fontManager = FontManager.Manager.FontManager.GetInstance();
            fileManager = FileManager.GetInstance();
            searchEngine = new SearchEngine();

            mBoard = new Board.Board();
            mFontService = new FontService.FontService();


            lbFonts.SelectedIndex = -1;

            //setup font support
            SetupSupportFontFormat();

            //Load Subset Data from file
            if (!SharedData.SharedData.IsSubsetsLoaded)
                FileManager.LoadSubsetDataFromFile();

            //SharedData.SharedData.Subsets.Sort(new SortSubset());
            //string json = JsonConvert.SerializeObject(SharedData.SharedData.Subsets);

            //File.WriteAllText(Path.Combine(fileManager.GetCachedFolderProject(), "nghia.txt"), json);

            SharedData.SharedData.FontInfos = fontInstallation.GetListFontInfoInstalled();
            lbFonts.DataSource = SharedData.SharedData.FontInfos;

            lbFonts.SelectedIndexChanged += lbFonts_SelectedIndexChanged;
            pnlDrawCharacter.Paint += PnlDrawCharacter_Paint;
            pnlDrawCharacter.SizeChanged += PnlDrawCharacter_SizeChanged;


            //Load Font Data
            firstLaunch = bool.Parse(File.ReadAllText(Path.Combine(fileManager.GetCachedFolderProject(), "Settings.txt")));
            if (firstLaunch == true)
            {
                Logger.d("Load data background");
                loadDataBackLoadListener += FrmMain_loadDataBackLoadListener;
                SharedData.SharedData.FontInfos = fontInstallation.GetListFontInfoInstalled();
                lbFonts.DataSource = SharedData.SharedData.FontInfos;
                LoadDataBackground();
                File.WriteAllText(Path.Combine(fileManager.GetCachedFolderProject(), "Settings.txt"), "false");
            }
            else
            {
                Logger.d("Load data from file cached");
                SharedData.SharedData.FontInfos = fileManager.GetFontDataCached();
                lbFonts.DataSource = SharedData.SharedData.FontInfos;
            }

            cbSubsetFont.SelectedIndexChanged += CbSubsetFont_SelectedIndexChanged;
            #endregion

            #region Tamphu.pn
            BtnViewAz09Sample_Click(sender, e);
            BtnAllFonts_Click(sender, e);

            if (lbFonts.Items.Count > 0)
            {
                lbFonts.SelectedIndex = -1;
                lbFonts.SelectedIndex = 0;
            }
            #endregion Tamphu.pn
        }

        private void PnlDrawCharacter_SizeChanged(object sender, EventArgs e)
        {
            Logger.d("On changed");
            if (mBoard != null)
            {
                mBoard.SetData((float)pnlDrawCharacter.Width - 1, (float)pnlDrawCharacter.Height, mBoard.Column, mBoard.Row);
                //Update location for Character Lable
                if (CharactersLabel != null)
                {
                    for (int i = 0; i < mBoard.Row; i++)
                    {
                        for (int j = 0; j < mBoard.Column; j++)
                        {
                            try
                            {
                                CharactersLabel[i, j].Location = new Point((int)(j * mBoard.ItemWidth) + 1, (int)(i * mBoard.ItemHeight) + 1);
                                CharactersLabel[i, j].Size = new Size((int)mBoard.ItemWidth - 2, (int)mBoard.ItemWidth - 2);
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
        }

        private void PnlDrawCharacter_Paint(object sender, PaintEventArgs e)
        {
            Logger.d("Panel Charactor OnPaint");
            if (mBoard != null)
            {
                HandleDrawCharacter();
            }
        }

        public void UpdateCharacter()
        {

        }

        private void HandleDrawCharacter()
        {
            pnlDrawCharacter.CreateGraphics().Clear(Color.White);
            mBoard.Draw(pnlDrawCharacter.CreateGraphics(), pnlDrawCharacter);
        }

        //Subset Index Changed
        private void CbSubsetFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbSubsetFont.SelectedIndex;
            Logger.d("Index Selected: " + index);


            if (index >= 0)
            {
                Subset currentSubset = currentFontSelected.Subsets[index];
                // pnlViewGridSample.BackColor = Color.Green;
                //pnlViewGridSampleChild.BackColor = Color.Red;
                //pnlDrawCharacter.BackColor = Color.Red;
                float widthPanel = pnlDrawCharacter.Width;
                float heightPanel = pnlDrawCharacter.Height;
                mFontService.SetFont(currentFontSelected.Location);
                mFontService.SetSize(10);

                Face face = mFontService.FontFace;

                int start = int.Parse(currentSubset.start, System.Globalization.NumberStyles.HexNumber);
                int end = int.Parse(currentSubset.end, System.Globalization.NumberStyles.HexNumber);

                //count font visible in subset


                CharacterIndex.Clear();

                for (int i = start; i < end; i++)
                {
                    if (face.GetCharIndex((uint)i) != 0)
                    {
                        CharacterIndex.Add(i);
                    }
                }


                int row = (int)Math.Ceiling((decimal)CharacterIndex.Count / (decimal)15);
                this.mRows = row;
                Logger.d("Row: " + this.mRows);

                mBoard.SetData(pnlDrawCharacter.Width - 1, pnlDrawCharacter.Height, 15, this.mRows);
                CharactersLabel = new Label[mBoard.Row, mBoard.Column];

                pnlDrawCharacter.Controls.Clear();

                for (int i = 0; i < mBoard.Row; i++)
                {
                    for (int j = 0; j < mBoard.Column; j++)
                    {
                        CharactersLabel[i, j] = new Label();
                        CharactersLabel[i, j].ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        CharactersLabel[i, j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        CharactersLabel[i, j].Size = new Size((int)mBoard.ItemWidth - 2, (int)mBoard.ItemHeight - 2);
                        CharactersLabel[i, j].Location = new Point((int)(j * mBoard.ItemWidth) + 1, (int)(i * mBoard.ItemWidth) + 1);
                    }
                }

                mFontService.SetSize((int)(0.6f * mBoard.ItemHeight));

                int currentRow = 0;
                int currentColumn = 0;

                for (int i = 0; i < CharacterIndex.Count; i++)
                {
                    if (currentColumn >= mBoard.Column)
                    {
                        currentColumn = 0;
                        currentRow++;
                    }

                    try
                    {
                        Bitmap bitmap = mFontService.RenderCharacterCode((uint)CharacterIndex[i]);
                        CharactersLabel[currentRow, currentColumn].Image = bitmap;
                        pnlDrawCharacter.Controls.Add(CharactersLabel[currentRow, currentColumn]);
                        currentColumn++;
                    }
                    catch (Exception ex)
                    {
                        Logger.d(ex.Message);
                    }
                }

                currentRow = 0;
                currentColumn = 0;

                HandleDrawCharacter();

            }

        }

        private void FrmMain_loadDataBackLoadListener(object sender, LoadBackgroundSuccessArgs e)
        {
            //this.isLoadedBackground = true;
            //SharedData.SharedData.FontInfos[10].Disable = true;

            //SharedData.SharedData.FontAdded = fontInstallation.GetListFontUserFromFile();
            //if (SharedData.SharedData.FontAdded != null)
            //{
            //    Logger.d("UserCached: " + SharedData.SharedData.FontAdded.Count);
            //    SharedData.SharedData.FontInfos.AddRange(SharedData.SharedData.FontAdded);
            //    lbFonts.Invoke(new Action(() => { lbFonts.DataSource = null; lbFonts.DataSource = SharedData.SharedData.FontInfos; }));
            //}
        }

        private void lbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFonts.SelectedItem == null)
                return;

            currentFontSelected = lbFonts.SelectedItem as FontInfo;
            if (!currentFontSelected.Loaded)
            {
                fontReading.ReadingFontInfo(Path.Combine(fileManager.GetFontsSystemFolder(), currentFontSelected.FileNameInRegistry), ref currentFontSelected);
            }

            //Logger.FontInfomation(currentFontSelected);
            selectedFontPath = currentFontSelected.Location;

            FontFamily ff = GetFontFamilyFromLocation(selectedFontPath);
            FontStyle fs = FontStyle.Regular;
            if (currentFontSelected.FontSubFamily == FontStyle.Bold.ToString())
                fs = FontStyle.Bold;
            else if (currentFontSelected.FontSubFamily == FontStyle.Italic.ToString())
                fs = FontStyle.Italic;
            else if (currentFontSelected.FontSubFamily == FontStyle.Regular.ToString())
                fs = FontStyle.Regular;
            else if (currentFontSelected.FontSubFamily == FontStyle.Strikeout.ToString())
                fs = FontStyle.Strikeout;
            else if (currentFontSelected.FontSubFamily == FontStyle.Underline.ToString())
                fs = FontStyle.Underline;

            cbSubsetFont.DataSource = currentFontSelected.Subsets.Select(x => x.name).ToList();
            // Cai font hien thi cho A-z 0-9 sample


            if (ff == null)
                rtxtViewAz09Sample.Font = new Font(defaultFontFamilyViewSample, rtxtViewAz09Sample.Font.Size);
            else
                rtxtViewAz09Sample.Font = new Font(ff, rtxtViewAz09Sample.Font.Size, fs);

            // Cai font hien thi cho Sentences sample
            if (ff == null)
                rtxtViewSentencesSample.Font = new Font(defaultFontFamilyViewSample, rtxtViewSentencesSample.Font.Size);
            else
                rtxtViewSentencesSample.Font = new Font(ff, rtxtViewSentencesSample.Font.Size, fs);

            // Cai font hien thi cho Grid sample
            //if (ff == null)
            //    rtxtViewGridSample.Font = new Font(defaultFontFamilyViewSample, rtxtViewGridSample.Font.Size);
            //else
            //    rtxtViewGridSample.Font = new Font(ff, rtxtViewGridSample.Font.Size, fs);

            // Gan thong tin font cho panel font info
            #region Tamphu.pn

            lblFontInfoTitleFont.Text = lblFontInfoFontStyle.Text = currentFontSelected.FullName;
            if (ff == null)
            {
                lblFontInfoTitleFont.Font = new Font(defaultFontFamilyViewSample, 18);
                lblFontInfoFontStyle.Font = new Font(defaultFontFamilyViewSample, 18);
            }
            else
            {
                lblFontInfoTitleFont.Font = new Font(ff, 18);
                lblFontInfoFontStyle.Font = new Font(defaultFontFamilyViewSample, 18);
            }

            FontInfoUc uc = (FontInfoUc)pnlFontInfoBottomView.Controls[0];
            uc.ContentChange(currentFontSelected.GlyphCount.ToString());
            FontInfoUc uc1 = (FontInfoUc)pnlFontInfoBottomView.Controls[1];
            uc1.ContentChange(currentFontSelected.License);
            FontInfoUc uc2 = (FontInfoUc)pnlFontInfoBottomView.Controls[2];
            uc2.ContentChange(currentFontSelected.TradeMark);
            FontInfoUc uc3 = (FontInfoUc)pnlFontInfoBottomView.Controls[3];
            uc3.ContentChange(currentFontSelected.Copyright);
            FontInfoUc uc4 = (FontInfoUc)pnlFontInfoBottomView.Controls[4];
            uc4.ContentChange(currentFontSelected.Designer);
            FontInfoUc uc5 = (FontInfoUc)pnlFontInfoBottomView.Controls[5];
            uc5.ContentChange(currentFontSelected.Manufacturer);
            FontInfoUc uc6 = (FontInfoUc)pnlFontInfoBottomView.Controls[6];
            uc6.ContentChange(currentFontSelected.UniqueId);
            FontInfoUc uc7 = (FontInfoUc)pnlFontInfoBottomView.Controls[7];
            uc7.ContentChange(currentFontSelected.Location);
            FontInfoUc uc8 = (FontInfoUc)pnlFontInfoBottomView.Controls[8];
            uc8.ContentChange(currentFontSelected.Version);
            FontInfoUc uc9 = (FontInfoUc)pnlFontInfoBottomView.Controls[9];
            uc9.ContentChange("none");
            FontInfoUc uc10 = (FontInfoUc)pnlFontInfoBottomView.Controls[10];
            uc10.ContentChange(currentFontSelected.StringLanguageSupported);
            FontInfoUc uc11 = (FontInfoUc)pnlFontInfoBottomView.Controls[11];
            uc11.ContentChange("none");
            FontInfoUc uc12 = (FontInfoUc)pnlFontInfoBottomView.Controls[12];
            uc12.ContentChange(currentFontSelected.FontSubFamily);
            FontInfoUc uc13 = (FontInfoUc)pnlFontInfoBottomView.Controls[13];
            uc13.ContentChange(currentFontSelected.FontFamily);
            FontInfoUc uc14 = (FontInfoUc)pnlFontInfoBottomView.Controls[14];
            uc14.ContentChange(currentFontSelected.FullName);
            FontInfoUc uc15 = (FontInfoUc)pnlFontInfoBottomView.Controls[15];
            uc15.ContentChange(currentFontSelected.PostscriptName);

            FontInfoUc uc16 = (FontInfoUc)pnlFontInfoBottomView.Controls[16];
            uc16.ContentChange(Utils.TextUtils.GetSubsetFontText(currentFontSelected.Subsets));
            pnlFontInfoBottomView.Refresh();
            #endregion
        }

        private void SetupSupportFontFormat()
        {
            fontManager.AddFontFormat(FontType.TTF);
            fontManager.AddFontFormat(FontType.OTF);
        }

        #region PhucTV
        private static FontFamily GetFontFamilyFromLocation(string pathFont)
        {
            if (File.Exists(pathFont) == false) return null;

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(pathFont);


            return pfc.Families.Length > 0 ? pfc.Families[0] : null;

        }

        private void TrbrEditSizeFontAz09View_Scroll(object sender, EventArgs e)
        {
            switch (trbrEditSizeFontAz09View.Value)
            {
                case 1:
                    rtxtViewAz09Sample.Font = new Font(rtxtViewAz09Sample.Font.FontFamily, 14);
                    break;
                case 2:
                    rtxtViewAz09Sample.Font = new Font(rtxtViewAz09Sample.Font.FontFamily, 15);
                    break;
                case 3:
                    rtxtViewAz09Sample.Font = new Font(rtxtViewAz09Sample.Font.FontFamily, 17);
                    break;
                case 4:
                    rtxtViewAz09Sample.Font = new Font(rtxtViewAz09Sample.Font.FontFamily, 20);
                    break;
                case 5:
                    rtxtViewAz09Sample.Font = new Font(rtxtViewAz09Sample.Font.FontFamily, 24);
                    break;
                case 6:
                    rtxtViewAz09Sample.Font = new Font(rtxtViewAz09Sample.Font.FontFamily, 29);
                    break;
            }
        }

        private void TrbrEditSizeFontSentencesView_Scroll(object sender, EventArgs e)
        {
            switch (trbrEditSizeFontSentencesView.Value)
            {
                case 1:
                    rtxtViewSentencesSample.Font = new Font(rtxtViewSentencesSample.Font.FontFamily, 14);
                    break;
                case 2:
                    rtxtViewSentencesSample.Font = new Font(rtxtViewSentencesSample.Font.FontFamily, 15);
                    break;
                case 3:
                    rtxtViewSentencesSample.Font = new Font(rtxtViewSentencesSample.Font.FontFamily, 17);
                    break;
                case 4:
                    rtxtViewSentencesSample.Font = new Font(rtxtViewSentencesSample.Font.FontFamily, 20);
                    break;
                case 5:
                    rtxtViewSentencesSample.Font = new Font(rtxtViewSentencesSample.Font.FontFamily, 24);
                    break;
                case 6:
                    rtxtViewSentencesSample.Font = new Font(rtxtViewSentencesSample.Font.FontFamily, 29);
                    break;
            }
        }


        private void LbFonts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = this.lbFonts.IndexFromPoint(e.Location);
                lbFonts.SelectedIndex = index;
                cmFontItem.Show(sender as FontListBox, e.Location);
            }
        }

        private void CmSearchOption_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Xu ly UI
            ToolStripItem itemClicked = e.ClickedItem;
            ((ToolStripMenuItem)itemClicked).Checked = true;
            int indexItemClicked = cmSearchType.Items.IndexOf(itemClicked);
            int i = 0;
            foreach (var item in cmSearchType.Items)
            {
                if (i++ != indexItemClicked)
                    ((ToolStripMenuItem)item).Checked = false;
            }
            lblPlaceholder.Text = "Type for searching " + e.ClickedItem.Text.ToLower() + "...";

            if (listenter != null)
            {
                listenter.Invoke(sender, new SearchTypeEventArgs((SearchType)indexItemClicked));
            }
        }

        private void PicbxSearchType_Click(object sender, EventArgs e)
        {
            cmSearchType.Show(sender as PictureBox, new Point(picbxSearchOption.Location.X, picbxSearchOption.Location.Y + picbxSearchOption.Height));
        }
        #endregion

        #region Cac thanh phan co ban cua form: close, maximize, minimize, drag-move, resize,...
        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Image = Resources.icon_maximize_exit_16x16;
                this.Padding = new Padding(0);
                DisableFormBorder(true);
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Image = Resources.icon_maximize_16x16;
                this.Padding = new Padding(FORM_PADDING);
                DisableFormBorder(false);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (FontManager.Properties.Settings.Default.FirstLanch || SharedData.SharedData.DataChanged)
            {
                fileManager.SaveFontData(SharedData.SharedData.FontInfos);
            }
           
            this.Close();
        }


        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Image = Resources.icon_maximize_exit_16x16;
                this.Padding = new Padding(0);
                DisableFormBorder(true);
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Image = Resources.icon_maximize_16x16;
                this.Padding = new Padding(FORM_PADDING);
                DisableFormBorder(false);

                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            }
        }

        private void DisableFormBorder(bool toggle)
        {
            if (toggle == true)
            {
                pnlBorder.Padding = new Padding(0);
            }
            else
            {
                pnlBorder.Padding = new Padding(FORM_BORDER_THICKNESS);
            }
        }

        private void MakeFormBackgroundTransparent(Color colorNeedToAvoid)
        {
            this.BackColor = colorNeedToAvoid;
            this.TransparencyKey = colorNeedToAvoid;
            //this.BackColor = Color.FromArgb(0, 255, 255, 255);
        }

        // Chuc nang resize form
        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htLeft = 10;
            const int htRight = 11;
            const int htTop = 12;
            const int htTopLeft = 13;
            const int htTopRight = 14;
            const int htBottom = 15;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;

            if (m.Msg == wmNcHitTest)
            {
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = PointToClient(new Point(x, y));
                Size clientSize = ClientSize;
                ///allow resize on the lower right corner
                if (pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                    return;
                }
                ///allow resize on the lower left corner
                if (pt.X <= 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htBottomRight : htBottomLeft);
                    return;
                }
                ///allow resize on the upper right corner
                if (pt.X <= 16 && pt.Y <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htTopRight : htTopLeft);
                    return;
                }
                ///allow resize on the upper left corner
                if (pt.X >= clientSize.Width - 16 && pt.Y <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htTopLeft : htTopRight);
                    return;
                }
                ///allow resize on the top border
                if (pt.Y <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htTop);
                    return;
                }
                ///allow resize on the bottom border
                if (pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htBottom);
                    return;
                }
                ///allow resize on the left border
                if (pt.X <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htLeft);
                    return;
                }
                ///allow resize on the right border
                if (pt.X >= clientSize.Width - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htRight);
                    return;
                }
            }

            base.WndProc(ref m);
        }

        // Chuc nang keo title de di chuyen form
        private void DragMoveFormCallback(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        // Chinh mau sac cho Vien` form
        private void SetFormBorderColor(Color color)
        {
            pnlBorder.BackColor = color;
        }
        #endregion

        #region xu ly

        // xong
        #region 4 button đầu tiên ở thanh title
        private void BtnViewAz09Sample_Click(object sender, EventArgs e)
        {
            btnViewAz09Sample.BackColor = RADIO_BTN_SELECTED_COLOR;
            btnViewGridSample.BackColor = TITLE_COLOR;
            btnViewSentencesSample.BackColor = TITLE_COLOR;
            btnViewFontInfo.BackColor = TITLE_COLOR;

            pnlViewAz09Sample.Visible = true;
            pnlViewGridSample.Visible = false;
            pnlViewSentencesSample.Visible = false;
            pnlViewFontInfo.Visible = false;
        }

        private void BtnViewGridSample_Click(object sender, EventArgs e)
        {
            btnViewAz09Sample.BackColor = TITLE_COLOR;
            btnViewGridSample.BackColor = RADIO_BTN_SELECTED_COLOR;
            btnViewSentencesSample.BackColor = TITLE_COLOR;
            btnViewFontInfo.BackColor = TITLE_COLOR;

            pnlViewAz09Sample.Visible = false;
            pnlViewGridSample.Visible = true;
            pnlViewSentencesSample.Visible = false;
            pnlViewFontInfo.Visible = false;
        }

        private void BtnViewSentencesSample_Click(object sender, EventArgs e)
        {
            btnViewAz09Sample.BackColor = TITLE_COLOR;
            btnViewGridSample.BackColor = TITLE_COLOR;
            btnViewSentencesSample.BackColor = RADIO_BTN_SELECTED_COLOR;
            btnViewFontInfo.BackColor = TITLE_COLOR;

            pnlViewAz09Sample.Visible = false;
            pnlViewGridSample.Visible = false;
            pnlViewSentencesSample.Visible = true;
            pnlViewFontInfo.Visible = false;
        }

        private void BtnViewFontInfo_Click(object sender, EventArgs e)
        {
            btnViewAz09Sample.BackColor = TITLE_COLOR;
            btnViewGridSample.BackColor = TITLE_COLOR;
            btnViewSentencesSample.BackColor = TITLE_COLOR;
            btnViewFontInfo.BackColor = RADIO_BTN_SELECTED_COLOR;

            pnlViewAz09Sample.Visible = false;
            pnlViewGridSample.Visible = false;
            pnlViewSentencesSample.Visible = false;
            pnlViewFontInfo.Visible = true;
        }
        #endregion

        #region 2 button tiếp theo ở thanh title
        private void BtnAddFonts_Click(object sender, EventArgs e)
        {
            // Lay danh sach file da chon
            List<FontInfo> listFontAdd = new List<FontInfo>();

            List<string> filesSeletedPath = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (ofd.FileNames.Length > 0)
                {
                    filesSeletedPath = new List<string>();
                    foreach (string path in ofd.FileNames)
                        filesSeletedPath.Add(path);
                }
            }

            if (filesSeletedPath != null && filesSeletedPath.Count > 0)
            {
                for (int i = 0; i < filesSeletedPath.Count; i++)
                {
                    FontInfo fontInfo = new FontInfo();
                    fontInfo.NameInRegistry = Path.GetFileNameWithoutExtension(filesSeletedPath[i]);
                    fontInfo.FileNameInRegistry = Path.GetFileName(filesSeletedPath[i]);
                    fontReading.ReadingFontInfo(filesSeletedPath[i], ref fontInfo);
                    fontInfo.Loaded = true;
                    fontInfo.Disable = true;
                    fontInfo.Owner = FontOwner.User;
                    fileManager.CopyFileTo(fontInfo.Location, Path.Combine(fileManager.GetFontsFolderProject(), "Disable"));
                    fontInfo.Location = Path.Combine(Path.Combine(fileManager.GetFontsFolderProject(), "Disable"), fontInfo.FileNameInRegistry);
                    listFontAdd.Add(fontInfo);
                }
            }


            SharedData.SharedData.FontInfos.AddRange(listFontAdd);
            lbFonts.DataSource = null;

            lbFonts.DataSource = SharedData.SharedData.FontInfos;

            lbFonts.DataSourceChanged -= LbFonts_DataSourceChanged;
            lbFonts.DataSourceChanged += LbFonts_DataSourceChanged;

            SharedData.SharedData.DataChanged = true;

            //lbFonts.Invalidate();

            // Cai cat fonts tu cac file da chon
        }

        private void LbFonts_DataSourceChanged(object sender, EventArgs e)
        {
            Logger.d("Data Changed");
        }

        private void BtnDisOrEnableFont_Click(object sender, EventArgs e)
        {
            HandleEnDisableFont();
        }
        #endregion

        #region khung tìm kiếm
        private void SearchTypeClicked_listenter(object sender, SearchTypeEventArgs e)
        {
            currentSearchType = e.SearchType;
        }

        private void TxtSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBox.Text.Length == 0)
            {
                if (!lbFonts.DataSource.Equals(SharedData.SharedData.FontInfos))
                {
                    lbFonts.DataSource = SharedData.SharedData.FontInfos;
                }
            }


            keyWord = txtSearchBox.Text;
        }

        private void SearchEngine_ListenerSearchFinished(object sender, SearchFinishedEventArgs e)
        {
            Logger.d("Search Finished");
            Logger.d(e.SearchResult.Count);

            lbFonts.BeginInvoke(new Action(() => { lbFonts.DataSource = null; lbFonts.DataSource = e.SearchResult; }));

        }


        #endregion

        #region 3 button ở cột bên trái
        private void BtnAllFonts_Click(object sender, EventArgs e)
        {
            // xu ly UI
            selectedMenuItem = MenuItem.AllFont;
            btnAllFonts.Font = new Font(btnAllFonts.Font.Name, btnAllFonts.Font.Size, FontStyle.Bold);
            btnFontsSystem.Font = new Font(btnFontsSystem.Font.Name, btnFontsSystem.Font.Size, FontStyle.Regular);
            btnFontsUser.Font = new Font(btnFontsUser.Font.Name, btnFontsUser.Font.Size, FontStyle.Regular);
            lbFonts.DataSource = SharedData.SharedData.FontInfos;
            Logger.d("Assign Data");

        }

        private void BtnFontsSystem_Click(object sender, EventArgs e)
        {
            // xu ly UI
            selectedMenuItem = MenuItem.SystemFont;
            btnAllFonts.Font = new Font(btnAllFonts.Font.Name, btnAllFonts.Font.Size, FontStyle.Regular);
            btnFontsSystem.Font = new Font(btnFontsSystem.Font.Name, btnFontsSystem.Font.Size, FontStyle.Bold);
            btnFontsUser.Font = new Font(btnFontsUser.Font.Name, btnFontsUser.Font.Size, FontStyle.Regular);
            lbFonts.DataSource = SharedData.SharedData.FontInfos.Where(x => x.Owner == FontOwner.System).Select(x => x).ToList();
        }

        private void BtnFontsUser_Click(object sender, EventArgs e)
        {
            // xu ly UI
            selectedMenuItem = MenuItem.UserFont;
            btnAllFonts.Font = new Font(btnAllFonts.Font.Name, btnAllFonts.Font.Size, FontStyle.Regular);
            btnFontsSystem.Font = new Font(btnFontsSystem.Font.Name, btnFontsSystem.Font.Size, FontStyle.Regular);
            btnFontsUser.Font = new Font(btnFontsUser.Font.Name, btnFontsUser.Font.Size, FontStyle.Bold);
            lbFonts.DataSource = SharedData.SharedData.FontInfos.Where(x => x.Owner == FontOwner.User).Select(x => x).ToList();
        }
        #endregion

        // xong
        #region context menu cho mỗi font thuộc list font
        private void CmFontItemAddFont_Click(object sender, EventArgs e)
        {
            BtnAddFonts_Click(sender, e);
        }

        private void CmFontItemEnDisableFont_Click(object sender, EventArgs e)
        {
            HandleEnDisableFont();
        }


        private void CmFontItemOpenFileLocation_Click(object sender, EventArgs e)
        {
            if (currentFontSelected.Location != null && File.Exists(currentFontSelected.Location))
            {
                string fontsSysDir = Path.GetPathRoot(System.Environment.SystemDirectory) + @"Windows\Fonts";
                if (currentFontSelected.Location.Contains(fontsSysDir))
                    Process.Start("explorer.exe", fontsSysDir);
                else
                    Process.Start("explorer.exe", "/select, " + currentFontSelected.Location);
            }
            //Process.Start("explorer.exe", "/select, " + Directory.GetParent(currentFontSelected.Location).FullName);
        }
        #endregion

        #endregion

        #region Disable And Active Font Feature
        private void HandleEnDisableFont()
        {
            if (currentFontSelected.Disable == true)
            {
                //install font
                InstallError error = fontInstallation.InstallFont(currentFontSelected.Location);

                if (error == InstallError.INSTALL_SUSCESS)
                {
                    Logger.d("Install Success");
                    string fontSystem = Path.Combine(fileManager.GetFontsSystemFolder(), currentFontSelected.FileNameInRegistry);
                    currentFontSelected.Location = fontSystem;
                    currentFontSelected.Disable = false;
                    lbFonts.Invalidate();
                }

                else if (error == InstallError.INSTALL_DUPLICATE)
                {
                    Logger.d("Duplicate");
                }
            }
            else
            {
                //move font to disable  

                bool flag = fontInstallation.DisableFont(currentFontSelected);
                currentFontSelected.Location = Path.Combine(Path.Combine(fileManager.GetFontsFolderProject(), "Disable"), Path.GetFileName(currentFontSelected.Location));

                if (flag)
                {
                    lbFonts.Invalidate();
                }

                currentFontSelected.Disable = true;

            }

            SharedData.SharedData.DataChanged = true;
        }

        #endregion

        #region Search Feature
        private void txtSearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
                return;

            searchEngine.ListenerSearchFinished -= SearchEngine_ListenerSearchFinished;
            searchEngine.ListenerSearchFinished += SearchEngine_ListenerSearchFinished;
            if (keyWord != null)
                searchEngine.FindFont(SharedData.SharedData.FontInfos, keyWord, 3, currentSearchType);
            e.Handled = true;
        }

        #endregion

        #region Load Data in Background
        private void LoadDataBackground()
        {
            int countFont = SharedData.SharedData.FontInfos.Count;

            int midule = countFont / 2;

            Thread thread1 = new Thread((x) => LoadFontInfoBackground(x));
            Thread thread2 = new Thread((x) => LoadFontInfoBackground(x));

            thread1.Start(new DataLoadArgs()
            {
                Start = 0,
                End = midule,
            });

            thread2.Start(new DataLoadArgs()
            {
                Start = midule + 1,
                End = countFont,
            });
        }

        int n_thread = 0;
        public void LoadFontInfoBackground(object obj)
        {
            DataLoadArgs data = obj as DataLoadArgs;

            for (int i = data.Start; i < data.End; i++)
            {
                FontInfo info = SharedData.SharedData.FontInfos[i];
                string filePath = Path.Combine(fileManager.GetFontsSystemFolder(), info.FileNameInRegistry);
                fontReading.ReadingFontInfo(filePath, ref info);
            }
            Logger.d("Loaded:" + data.End);
            n_thread++;
            if (n_thread == NUMBER_THREAD_LOAD_BACKGROUND)
            {
                if (loadDataBackLoadListener != null)
                {
                    Logger.d("Fire LoadBackground Finished");
                    loadDataBackLoadListener.Invoke(this, new LoadBackgroundSuccessArgs());
                }
            }

        }

        public class DataLoadArgs
        {
            public int Start { get; set; }
            public int End { get; set; }
        }

        #endregion

    }
}
