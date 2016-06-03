using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Movies.View {
    partial class MovieForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent() {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MovieForm));

            cmdCancel = new Button();
            cmdFinish = new Button();
            cmdOK = new Button();

            cmdForm = new Button[10];

            cboGenre = new ComboBox();

            dgv = new DataGridView();

            lblActors = new Label();
            lblDescription = new Label();
            lblDirector = new Label();
            lblGenre = new Label();
            lblTitle = new Label();
            lblRating = new Label();
            lblYear = new Label();

            lblPnlAsterisk = new Label[7];
            lblPnlInfo = new Label[8];
            lblSearch = new Label();

            mnuStrip = new MenuStrip();

            pnlAddEditInfo = new Panel();
            pnlSearch = new Panel();

            picLogo = new PictureBox();
            picAddEdit = new PictureBox();

            tlpBottom = new TableLayoutPanel();
            tlpCenter = new TableLayoutPanel();
            tlpDgv = new TableLayoutPanel();
            tlpTop = new TableLayoutPanel();

            txtSearch = new TextBox();
            txtPnlAddEdit = new TextBox[8];

            tlbFiles = new ToolStripMenuItem();
            tlbAdd = new ToolStripMenuItem();
            tlbAll = new ToolStripMenuItem();
            tlbDel = new ToolStripMenuItem();
            tlbEdit = new ToolStripMenuItem();
            tlbInfo = new ToolStripMenuItem();
            tlbLoad = new ToolStripMenuItem();
            tlbNext = new ToolStripMenuItem();
            tlbPrevious = new ToolStripMenuItem();
            tlbQuit = new ToolStripMenuItem();
            tlbReset = new ToolStripMenuItem();
            tlbSave = new ToolStripMenuItem();

            tlbHelp = new ToolStripMenuItem();

            tlbAbout = new ToolStripMenuItem();

            tlbSettings = new ToolStripMenuItem();

            tlbColors = new ToolStripMenuItem();

            tlbBorders = new ToolStripMenuItem();
            tlbCenter = new ToolStripMenuItem();

            tlbBlack = new ToolStripMenuItem();
            tlbBlanchedAlmond = new ToolStripMenuItem();
            tlbBurgundy = new ToolStripMenuItem();
            tlbCream = new ToolStripMenuItem();
            tlbDarkGrey = new ToolStripMenuItem();
            tlbLightCyan = new ToolStripMenuItem();
            tlbLightGoldenrodYellow = new ToolStripMenuItem();
            tlbLightGreen = new ToolStripMenuItem();
            tlbPaleGoldenrod = new ToolStripMenuItem();
            tlbPeriwinkle = new ToolStripMenuItem();
            tlbPurple = new ToolStripMenuItem();
            tlbSnow = new ToolStripMenuItem();
            tlbTransparent = new ToolStripMenuItem();
            tlbWhite = new ToolStripMenuItem();
            //
            // cmdCancel
            // 
            cmdCancel.Click += new EventHandler(CancelClick);
            cmdCancel.Location = new Point(233, 330);
            cmdCancel.Name = "cmdCancel";
            cmdCancel.Size = new Size(75, 23);
            cmdCancel.TabIndex = 25;
            cmdCancel.Text = "Cancel";
            cmdCancel.UseVisualStyleBackColor = true;
            pnlAddEditInfo.Controls.Add(cmdCancel);
            //
            // cmdFinish
            // 
            cmdFinish.Click += new EventHandler(FinishClick);
            cmdFinish.Location = new Point(136, 330);
            cmdFinish.Name = "cmdFinish";
            cmdFinish.TabIndex = 24;
            cmdFinish.Text = "Adding";
            cmdFinish.Size = new Size(75, 23);
            cmdFinish.UseVisualStyleBackColor = true;
            pnlAddEditInfo.Controls.Add(cmdFinish);
            //
            // cmdOK
            // 
            cmdOK.Click += new EventHandler(OkClick);
            cmdOK.Location = new Point(150, 325);
            cmdOK.ForeColor = Color.White;
            cmdOK.Name = "cmdOK";
            cmdOK.Size = new Size(75, 23);
            cmdOK.TabIndex = 2;
            cmdOK.Text = "OK";
            cmdCancel.UseVisualStyleBackColor = true;
            pnlAddEditInfo.Controls.Add(cmdOK);
            //
            // cboGenre
            //
            cboGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGenre.Items.Add("Action");
            cboGenre.Items.Add("Adult");
            cboGenre.Items.Add("Adventure");
            cboGenre.Items.Add("Comedy");
            cboGenre.Items.Add("Comedy Drama");
            cboGenre.Items.Add("Crime");
            cboGenre.Items.Add("Drama");
            cboGenre.Items.Add("Epic");
            cboGenre.Items.Add("Experimental");
            cboGenre.Items.Add("Family");
            cboGenre.Items.Add("Fantasy");
            cboGenre.Items.Add("Historical");
            cboGenre.Items.Add("Horror");
            cboGenre.Items.Add("Musical");
            cboGenre.Items.Add("Mystery");
            cboGenre.Items.Add("Romance");
            cboGenre.Items.Add("Science Fiction");
            cboGenre.Items.Add("Spy");
            cboGenre.Items.Add("Thriller");
            cboGenre.Items.Add("War");
            cboGenre.Items.Add("Western");
            cboGenre.Location = new Point(218, 68);
            cboGenre.Size = new Size(160, 20);
            pnlAddEditInfo.Controls.Add(cboGenre);
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.Anchor = (AnchorStyles.Bottom) | (AnchorStyles.Top) |
                (AnchorStyles.Left) | (AnchorStyles.Right);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = SystemColors.Control;
            dgv.Click += new EventHandler(DataGridViewSelectionChanged);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f1c40f");
            dgv.Columns.Add("id", "ID");
            dgv.Columns.Add("title", "Title");
            dgv.Columns.Add("year", "Release Year");
            dgv.Columns.Add("genre", "Genre");
            dgv.Columns.Add("rating", "Rating");
            dgv.Columns.Add("director", "Director");
            dgv.Columns.Add("firstActor", "First Actor");
            dgv.Columns.Add("secondActor", "Second Actor");
            dgv.Columns.Add("thirdActor", "Third Actor");
            dgv.Columns[0].Width = 25;
            dgv.Dock = DockStyle.Fill;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Location = new Point(0, 98);
            dgv.Name = "dgv";
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //
            // lblSearch
            //
            lblSearch.Anchor = AnchorStyles.None;
            lblSearch.Location = new Point(0, 43);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(42, 20);
            lblSearch.Text = "Search: ";
            lblSearch.TabIndex = 8;
            //
            // mnuStrip
            //
            mnuStrip.Items.AddRange(new ToolStripItem[] {
            tlbFiles,
            tlbHelp,
            tlbAbout,
            tlbSettings});
            mnuStrip.Name = "mnuStrip";
            //
            // tlbFiles
            //
            tlbFiles.DropDownItems.AddRange(new ToolStripItem[] {
            tlbAdd,
            tlbEdit,
            tlbDel,
            tlbInfo,
            tlbSave,
            tlbLoad,
            tlbReset,
            tlbPrevious,
            tlbAll,
            tlbNext,
            tlbQuit});
            tlbFiles.Name = "tlbFiles";
            tlbFiles.ShortcutKeys = (Keys.Control | Keys.F);
            tlbFiles.Text = "&File";
            //
            // tlbAdd
            //
            tlbAdd.Click += new EventHandler(AddClick);
            tlbAdd.Name = "tlbAdd";
            tlbAdd.ShortcutKeys = (Keys.Control | Keys.N);
            tlbAdd.Text = "&Add";
            //
            // tlbEdit
            //
            tlbEdit.Click += new EventHandler(EditClick);
            tlbEdit.Enabled = false;
            tlbEdit.Name = "tlbEdit";
            tlbEdit.ShortcutKeys = (Keys.Control | Keys.E);
            tlbEdit.Text = "&Edit";
            //
            // tlbDel
            //
            tlbDel.Click += new EventHandler(DelClick);
            tlbDel.Enabled = false;
            tlbDel.Name = "tlbDel";
            tlbDel.ShortcutKeys = (Keys.Control | Keys.W);
            tlbDel.Text = "&Delete";
            //
            // tlbInfo
            //
            tlbInfo.Click += new EventHandler(InfoClick);
            tlbInfo.Enabled = false;
            tlbInfo.Name = "tlbInfo";
            tlbInfo.ShortcutKeys = (Keys.Control | Keys.I);
            tlbInfo.Text = "Info";
            //
            // tlbSave
            //
            tlbSave.Click += new EventHandler(SaveClick);
            tlbSave.Enabled = false;
            tlbSave.Name = "tlbSave";
            tlbSave.ShortcutKeys = (Keys.Control | Keys.S);
            tlbSave.Text = "&Save";
            //
            // tlbLoad
            //
            tlbLoad.Enabled = false;
            tlbLoad.Name = "tlbLoad";
            tlbLoad.ShortcutKeys = (Keys.Control | Keys.L);
            tlbLoad.Text = "&Load";
            tlbLoad.Click += new EventHandler(LoadClick);
            //
            // tlbReset
            //
            tlbReset.Enabled = false;
            tlbReset.Name = "tlbReset";
            tlbReset.ShortcutKeys = (Keys.Control | Keys.R);
            tlbReset.Text = "&Reset";
            tlbReset.Click += new EventHandler(ResetClick);
            //
            // tlbAll
            //
            tlbAll.Click += new EventHandler(AllClick);
            tlbAll.Enabled = false;
            tlbAll.Name = "tlbAll";
            tlbAll.ShortcutKeys = (Keys.Control | Keys.B);
            tlbAll.Text = "&All";
            //
            // tlbPrevious
            //
            tlbPrevious.Click += new EventHandler(PreviousClick);
            tlbPrevious.Enabled = false;
            tlbPrevious.Name = "tlbPrevious";
            tlbPrevious.ShortcutKeys = (Keys.Control | Keys.Left);
            tlbPrevious.Text = "&Previous";
            //
            // tlbNext
            //
            tlbNext.Click += new EventHandler(NextClick);
            tlbNext.Enabled = false;
            tlbNext.Name = "tlbNext";
            tlbNext.ShortcutKeys = (Keys.Control | Keys.Right);
            tlbNext.Text = "&Next";
            //
            // tlbQuit
            //
            tlbQuit.Click += new EventHandler(QuitClick);
            tlbQuit.Enabled = true;
            tlbQuit.Name = "tlbQuit";
            tlbQuit.ShortcutKeys = (Keys.Control | Keys.Q);
            tlbQuit.Text = "&Quit";
            //
            // tlbHelp
            //
            tlbHelp.Click += new EventHandler(HelpClick);
            tlbHelp.Name = "tlbHelp";
            tlbHelp.ShortcutKeys = (Keys.Control | Keys.H);
            tlbHelp.Text = "&Help";
            //
            // tlbAbout
            //
            tlbAbout.Click += new EventHandler(AboutClick);
            tlbAbout.Name = "tlbAbout";
            tlbAbout.Text = "&About";
            //
            // tlbSettings
            //
            tlbSettings.DropDownItems.AddRange(new ToolStripItem[] {
            tlbColors});
            tlbSettings.Name = "tlbSettings";
            tlbSettings.ShortcutKeys = (Keys.Control | Keys.S);
            tlbSettings.Size = new Size(61, 20);
            tlbSettings.Text = "&Settings";
            //
            // tlbColors
            //
            tlbColors.DropDownItems.AddRange(new ToolStripItem[] {
            tlbBorders,
            tlbCenter});
            tlbColors.Name = "tlbColors";
            tlbColors.ShortcutKeys = (Keys.Control | Keys.S);
            tlbColors.Size = new Size(61, 20);
            tlbColors.Text = "&Colors";
            //
            // tlbCenter
            //
            tlbCenter.DropDownItems.AddRange(new ToolStripItem[] {
                tlbBlack,
                tlbLightGoldenrodYellow,
                tlbSnow,
                tlbTransparent
            });
            tlbCenter.Name = "tlbCenter";
            tlbCenter.Size = new Size(107, 22);
            tlbCenter.Text = "&Center";
            //
            // tlbBlack
            //
            tlbBlack.Click += new EventHandler(ColorCenter);
            tlbBlack.Name = "tlbBlack";
            tlbBlack.Text = "&Black";
            //
            // tlbLightGoldenrowYellow
            //
            tlbLightGoldenrodYellow.Click += new EventHandler(ColorCenter);
            tlbLightGoldenrodYellow.Name = "tlbLightGoldenrodYellow";
            tlbLightGoldenrodYellow.Text = "&LightGoldenrowYellow";
            //
            // tlbSnow
            //
            tlbSnow.Click += new EventHandler(ColorCenter);
            tlbSnow.Name = "tlbSnow";
            tlbSnow.Text = "&Snow";
            //
            // tlbTransparent
            //
            tlbTransparent.Click += new EventHandler(ColorCenter);
            tlbTransparent.Name = "tlbTransparent";
            tlbTransparent.Text = "&Transparent";
            //
            // tlbBorders
            //
            tlbBorders.Click += new EventHandler(SwitchColor);
            tlbBorders.DropDownItems.AddRange(new ToolStripItem[] {
            tlbBlanchedAlmond,
            tlbBurgundy,
            tlbCream,
            tlbDarkGrey,
            tlbLightCyan,
            tlbLightGreen,
            tlbPaleGoldenrod,
            tlbPeriwinkle,
            tlbPurple,
            tlbWhite});
            tlbBorders.Name = "tlbBorders";
            tlbBorders.Size = new Size(107, 22);
            tlbBorders.Text = "&Borders";
            //
            // tlbBlanchedAlmond
            //
            tlbBlanchedAlmond.Click += new EventHandler(SwitchColor);
            tlbBlanchedAlmond.Name = "tlbBlanchedAlmond";
            tlbBlanchedAlmond.Text = "&BlanchedAlmond";
            //
            // tlbBurgundy
            //
            tlbBurgundy.Click += new EventHandler(SwitchColor);
            tlbBurgundy.Name = "tlbBurgundy";
            tlbBurgundy.Text = "&Burgundy ";
            //
            // tlbCream
            //
            tlbCream.Click += new EventHandler(SwitchColor);
            tlbCream.Name = "tlbCream";
            tlbCream.Text = "&Cream";
            //
            // tlbDarkGrey
            //
            tlbDarkGrey.Click += new EventHandler(SwitchColor);
            tlbDarkGrey.Name = "tlbDarkGrey";
            tlbDarkGrey.Text = "&DarkGrey ";
            //
            // tlbLightCyan
            //
            tlbLightCyan.Click += new EventHandler(SwitchColor);
            tlbLightCyan.Name = "tlbLightCyan";
            tlbLightCyan.Text = "&LightCyan ";
            //
            // tlbLightGreen
            //
            tlbLightGreen.Click += new EventHandler(SwitchColor);
            tlbLightGreen.Name = "tlbLightGreen";
            tlbLightGreen.Text = "&LightGreen ";
            //
            // tlbPaleGoldenrod
            //
            tlbPaleGoldenrod.Click += new EventHandler(SwitchColor);
            tlbPaleGoldenrod.Name = "tlbPaleGoldenrod";
            tlbPaleGoldenrod.Text = "&PaleGoldenrod ";
            //
            // tlbPeriwinkle
            //
            tlbPeriwinkle.Click += new EventHandler(SwitchColor);
            tlbPeriwinkle.Name = "tlbPeriwinkle";
            tlbPeriwinkle.Text = "&Periwinkle ";
            //
            // tlbPurple
            //
            tlbPurple.Click += new EventHandler(SwitchColor);
            tlbPurple.Name = "tlbPurple";
            tlbPurple.Text = "&Purple ";
            //
            // tlbWhite
            //
            tlbWhite.Click += new EventHandler(SwitchColor);
            tlbWhite.Name = "tlbWhite";
            tlbWhite.Text = "&White";
            //
            // tltGeneral
            //
            tltGeneral = new ToolTip();
            //
            // lblTitle
            //
            lblTitle.Location = new System.Drawing.Point(185, 19);
            lblTitle.Name = "label1";
            lblTitle.Size = new System.Drawing.Size(30, 13);
            lblTitle.Text = "Title:";
            pnlAddEditInfo.Controls.Add(lblTitle);
            //
            // lblYear
            //
            lblYear.Location = new Point(140, 45);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(74, 13);
            lblYear.Text = "Release Year: ";
            pnlAddEditInfo.Controls.Add(lblYear);
            //
            // lblGenre
            //
            lblGenre.Location = new Point(175, 70);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(39, 20);
            lblGenre.Text = "Genre: ";
            pnlAddEditInfo.Controls.Add(lblGenre);
            //
            // lblRating
            //
            lblRating.Location = new Point(173, 94);
            lblRating.Name = "label3";
            lblRating.Size = new Size(41, 13);
            lblRating.Text = "Rating:";
            pnlAddEditInfo.Controls.Add(lblRating);
            //
            // lblDirector
            //
            lblDirector.Location = new Point(168, 120);
            lblDirector.Name = "lblDirector";
            lblDirector.Size = new Size(47, 13);
            lblDirector.Text = "Director: ";
            pnlAddEditInfo.Controls.Add(lblDirector);
            //
            // lblActors
            //
            lblActors.Location = new Point(175, 146);
            lblActors.Name = "lblActors";
            lblActors.Size = new Size(40, 13);
            lblActors.Text = "Actors: ";
            pnlAddEditInfo.Controls.Add(lblActors);
            //
            // lblDescription
            //
            lblDescription.Location = new Point(0, 230);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(70, 13);
            lblDescription.Text = "Description: ";
            pnlAddEditInfo.Controls.Add(lblDescription);
            //
            // pnlAddEditInfo
            //
            pnlAddEditInfo.Anchor = AnchorStyles.None;
            pnlAddEditInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlAddEditInfo.Name = "pnlAddEditInfo";
            pnlAddEditInfo.Size = new Size(400, 360);
            pnlAddEditInfo.Visible = false;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.Location = new Point(549, 3);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(232, 68);
            //
            // picAddEdit
            //
            picAddEdit.Click += new EventHandler(PictureAddClick);
            picAddEdit.Location = new Point(19, 16);
            picAddEdit.Name = "picAddEdit";
            picAddEdit.Size = new Size(100, 150);
            picAddEdit.SizeMode = PictureBoxSizeMode.StretchImage;
            picAddEdit.Image = Properties.Resources.nonePicture;
            pnlAddEditInfo.Controls.Add(picAddEdit);
            //
            // picLogo
            //
            picLogo.Dock = DockStyle.Fill;
            picLogo.Image = Properties.Resources.logo;
            picLogo.Location = new Point(3, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(129, 68);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            //
            // tlpBottom
            //
            tlpBottom.BackColor = Color.Moccasin;
            tlpBottom.ColumnCount = 5;
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.005F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66333F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66333F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66333F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.005F));
            tlpBottom.Dock = DockStyle.Bottom;
            tlpBottom.Location = new Point(0, 463);
            tlpBottom.Name = "tlpBottom";
            tlpBottom.RowCount = 1;
            tlpBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 87.7193F));
            tlpBottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
            tlpBottom.Size = new Size(784, 98);
            //
            // tlpCenter
            //
            tlpCenter.BackColor = Color.Snow;
            tlpCenter.ColumnCount = 3;
            tlpCenter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpCenter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpCenter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpCenter.Dock = DockStyle.Fill;
            tlpCenter.Location = new Point(0, 98);
            tlpCenter.Name = "tlpCenter";
            tlpCenter.RowCount = 2;
            tlpCenter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCenter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            //
            // tlpDgv
            //
            tlpDgv.ColumnCount = 1;
            tlpDgv.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpDgv.Controls.Add(dgv, 0, 0);
            tlpDgv.Dock = DockStyle.Fill;
            tlpDgv.Location = new Point(0, 98);
            tlpDgv.Name = "tlpDgv";
            tlpDgv.RowCount = 1;
            tlpDgv.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpDgv.Visible = false;
            //
            // tlpTop
            //
            tlpTop.BackColor = Color.Moccasin;
            tlpTop.ColumnCount = 9;
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.22907F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.319319F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.563986F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.559239F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.559239F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.559239F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.559239F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.559239F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.09143F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpTop.Controls.Add(picLogo, 0, 0);
            tlpTop.Controls.Add(pnlSearch, 8, 0);
            tlpTop.Dock = DockStyle.Top;
            tlpTop.Location = new Point(0, 24);
            tlpTop.Name = "tlpTop";
            tlpTop.RowCount = 1;
            tlpTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTop.Size = new Size(784, 74);
            //
            // txtSearch
            //
            txtSearch.Anchor = AnchorStyles.None;
            txtSearch.Location = new Point(58, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(166, 20);
            txtSearch.TextChanged += new EventHandler(SearchTextChanged);
            txtSearch.TabIndex = 8;
            //
            // Form
            //
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 700);
            Controls.Add(pnlAddEditInfo);
            Controls.Add(tlpBottom);
            Controls.Add(tlpCenter);
            Controls.Add(tlpDgv);
            Controls.Add(tlpTop);
            Controls.Add(mnuStrip);
            Icon = (Icon)(resources.GetObject("$this.Icon"));
            MainMenuStrip = mnuStrip;
            Name = "MovieForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movies Library";
            ResumeLayout(false);
            PerformLayout();

            mnuStrip.ResumeLayout(false);
            mnuStrip.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            tlpBottom.ResumeLayout(false);
            tlpBottom.PerformLayout();
            tlpCenter.ResumeLayout(false);
            tlpCenter.PerformLayout();
            tlpDgv.ResumeLayout(false);
            tlpDgv.PerformLayout();
            tlpTop.ResumeLayout(false);
            tlpTop.PerformLayout();
        }

        /// <summary>
        /// Adds Buttons to the Form.
        /// </summary>
        private void AddButtonsForm() {
            for (int i = 0; i < 10; i++) {
                cmdForm[i] = new Button();
                if (i < 7) {
                    cmdForm[i].Location = new Point(140 + (i * 60), 11);
                    tlpTop.Controls.Add(cmdForm[i], i + 1, 0);
                } else {
                    cmdForm[i].Location = new Point(240 + ((i % 6) * 130), 25);
                    tlpBottom.Controls.Add(cmdForm[i], (i + 1) % 7, 0);
                }
                cmdForm[i].Anchor = AnchorStyles.None;
                cmdForm[i].Click += new EventHandler(ButtonClick);
                cmdForm[i].FlatAppearance.BorderSize = 0;
                cmdForm[i].FlatAppearance.MouseOverBackColor = Color.Transparent;
                cmdForm[i].FlatStyle = FlatStyle.Flat;
                cmdForm[i].Image = dblDefaultImages[i];
                cmdForm[i].Name = "cmdDynamic" + i;
                cmdForm[i].MouseEnter += new EventHandler(ButtonEnter);
                cmdForm[i].MouseLeave += new EventHandler(ButtonLeave);
                cmdForm[i].Size = new Size(48, 48);
                cmdForm[i].Tag = i + 1;
                cmdForm[i].TabIndex = i + 1;
            }
        }

        /// <summary>
        /// Adds Asterisks to Panels 'Add', 'Edit' and 'Info'.
        /// </summary>
        public void AddLblAsteriskToPanelAddEditInfo() {
            for (int i = 0; i < 7; i++) {
                lblPnlAsterisk[i] = new Label();
                lblPnlAsterisk[i].Font = new Font("Microsoft Sans Serif", 10F,
                    FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                lblPnlAsterisk[i].ForeColor = Color.Red;
                lblPnlAsterisk[i].Name = "lblDynamic" + (i + 1);
                if (i < 6) {
                    lblPnlAsterisk[i].Location = new Point(380, 20 + (i * 25));
                } else {
                    lblPnlAsterisk[i].Location = new Point(380, 20 + ((i + 2) * 20));
                }
                lblPnlAsterisk[i].Size = new Size(13, 20);
                lblPnlAsterisk[i].Text = "*";
                pnlAddEditInfo.Controls.Add(lblPnlAsterisk[i]);
            }
        }

        /// <summary>
        /// Adds Labels to 'Info' Panel.
        /// </summary>
        public void AddLblInfoToPanelAddEditInfo() {
            for (int i = 0; i < 8; i++) {
                lblPnlInfo[i] = new Label();
                lblPnlInfo[i].Location = new Point(218, 19 + (i * 24));
                lblPnlInfo[i].ForeColor = Color.White;
                lblPnlInfo[i].Name = "lblDynamicInfo" + (i + 1);
                lblPnlInfo[i].Size = new Size(160, 20);
                pnlAddEditInfo.Controls.Add(lblPnlInfo[i]);
            }
        }

        /// <summary>
        /// Initializes the Panels of the PictureBox.
        /// </summary>
        public void AddPanelForPicture() {
            for (int i = 0; i < 6; i++) {
                dblPnl.Add(new Panel());
                dblPnl[dblPnl.Count - 1].Dock = DockStyle.Fill;
                dblPnl[dblPnl.Count - 1].Name = "pnl" + (i + 1);
                dblPnl[dblPnl.Count - 1].Size = new Size(255, 176);
                if (i < 3) {
                    dblPnl[dblPnl.Count - 1].Location = new Point(3 + (i * 261), 3);
                    tlpCenter.Controls.Add(dblPnl[dblPnl.Count - 1], i, 0);
                } else {
                    dblPnl[dblPnl.Count - 1].Location = new Point(3 + ((i % 3) * 261), 185);
                    tlpCenter.Controls.Add(dblPnl[dblPnl.Count - 1], (i % 3), 1);
                }
            }
        }

        /// <summary>
        /// Adds a PictureBox to the 'dblPic' list.
        /// </summary>
        /// <param name="img">image to add to the PictureBox<param>
        public void AddPictureBox(Image img) {
            dblPic.Add(new PictureBox());
            dblPic[dblPic.Count - 1].Anchor = AnchorStyles.None;
            dblPic[dblPic.Count - 1].Click += new EventHandler(PictureAddEditClick);
            dblPic[dblPic.Count - 1].Image = img;
            dblPic[dblPic.Count - 1].Location = new Point(75, 3);
            dblPic[dblPic.Count - 1].MouseHover += new EventHandler(PictureMouseHover);
            dblPic[dblPic.Count - 1].MouseEnter += new EventHandler(PictureMouseEnter);
            dblPic[dblPic.Count - 1].MouseLeave += new EventHandler(PictureMouseLeave);
            dblPic[dblPic.Count - 1].Name = "pic" + dblPic.Count;
            dblPic[dblPic.Count - 1].Size = new Size(100, 150);
            dblPic[dblPic.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// Adds TextBox to 'Add', 'Edit' and 'Info' Panels.
        /// </summary>
        public void AddTextBoxToPanelAddEditInfo() {
            for (int i = 0; i < 8; i++) {
                txtPnlAddEdit[i] = new TextBox();
                txtPnlAddEdit[i].Name = "txtDynamic" + i;
                if (i < 2) {
                    txtPnlAddEdit[i].Location = new Point(218, 16 + (i * 26));
                    txtPnlAddEdit[i].Size = new Size(160, 20);
                } else if (i == 7) {
                    txtPnlAddEdit[i].Location = new Point(70, 226);
                    txtPnlAddEdit[i].Multiline = true;
                    txtPnlAddEdit[i].ScrollBars = ScrollBars.Vertical;
                    txtPnlAddEdit[i].Size = new Size(309, 90);
                    txtPnlAddEdit[i].WordWrap = true;
                } else {
                    txtPnlAddEdit[i].Location = new Point(218, 16 + ((i + 1) * 26));
                    txtPnlAddEdit[i].Size = new Size(160, 20);
                }
                txtPnlAddEdit[i].TabIndex = i + 1;
                pnlAddEditInfo.Controls.Add(txtPnlAddEdit[i]);
            }
        }

        /// <summary>
        /// Aligns header of the 'All Movies' DataGridViewColumn.
        /// </summary>
        public void DataGridHeaderAlignmentCenter() {
            foreach (DataGridViewColumn column in dgv.Columns) {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        /// <summary>
        /// Loads the Images of the PictureBox and the text of the Labels.
        /// </summary>
        private void LoadImagesAndLabels() {
            for (int i = 0; i < 6 && i < dblMovie.Count; i++) {
                try {
                    AddPictureBox(Image.FromFile(@"MoviesImages/" +
                        dblMovie[dblMovie.Count - (1 + i)].title.ToLower()));
                } catch (System.IO.FileNotFoundException) {
                    AddPictureBox(Properties.Resources.nonePicture);
                }
                AddLabel(dblMovie[dblMovie.Count - (1 + i)].title.ToUpper());
                dblPnl[i].Controls.Add(dblPic[i]);
                dblPnl[i].Controls.Add(dblLbl[i]);
            }
        }

        #endregion
        private Button cmdCancel;
        private Button cmdFinish;
        private Button cmdOK;

        private Button[] cmdForm;

        private ComboBox cboGenre;

        private DataGridView dgv; 

        private Label lblActors;
        private Label lblDescription;
        private Label lblDirector;
        private Label lblGenre;
        private Label lblRating;
        private Label lblSearch;
        private Label lblTitle;
        private Label lblYear;

        private Label[] lblPnlAsterisk;
        private Label[] lblPnlInfo;

        private MenuStrip mnuStrip;

        private Panel pnlSearch;
        private Panel pnlAddEditInfo;

        private PictureBox picLogo;
        private PictureBox picAddEdit;

        private TableLayoutPanel tlpBottom;
        private TableLayoutPanel tlpCenter;
        private TableLayoutPanel tlpDgv;
        private TableLayoutPanel tlpTop;

        private TextBox txtSearch;
        private TextBox[] txtPnlAddEdit;

        private ToolStripMenuItem tlbFiles;
        private ToolStripMenuItem tlbAdd;
        private ToolStripMenuItem tlbAll;
        private ToolStripMenuItem tlbDel;
        private ToolStripMenuItem tlbEdit;
        private ToolStripMenuItem tlbInfo;
        private ToolStripMenuItem tlbLoad;
        private ToolStripMenuItem tlbNext;
        private ToolStripMenuItem tlbPrevious;
        private ToolStripMenuItem tlbQuit;
        private ToolStripMenuItem tlbReset;
        private ToolStripMenuItem tlbSave;

        private ToolStripMenuItem tlbAbout;

        private ToolStripMenuItem tlbHelp;

        private ToolStripMenuItem tlbSettings;

        private ToolStripMenuItem tlbColors;

        private ToolStripMenuItem tlbBorders;
        private ToolStripMenuItem tlbCenter;

        private ToolStripMenuItem tlbBlack;
        private ToolStripMenuItem tlbBlanchedAlmond;
        private ToolStripMenuItem tlbBurgundy;
        private ToolStripMenuItem tlbCream;
        private ToolStripMenuItem tlbDarkGrey;
        private ToolStripMenuItem tlbLightCyan;
        private ToolStripMenuItem tlbLightGoldenrodYellow;
        private ToolStripMenuItem tlbLightGreen;
        private ToolStripMenuItem tlbPaleGoldenrod;
        private ToolStripMenuItem tlbPeriwinkle;
        private ToolStripMenuItem tlbPurple;
        private ToolStripMenuItem tlbSnow;
        private ToolStripMenuItem tlbTransparent;
        private ToolStripMenuItem tlbWhite;

        private ToolTip tltGeneral;
    }
}