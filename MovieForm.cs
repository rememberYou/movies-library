#region license
// Copyright (C) 2016  Terencio Agozzino
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>
#endregion

using Movies.Models;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Movies.View {

    /// <summary>
    /// MovieForm is the class that models the internal features of the
    /// movies library.
    /// </summary>
    public partial class MovieForm : Form {

        private List<Image> dblDefaultImages;
        private List<Label> dblLbl;
        private List<Movie> dblMovie;
        private List<Movie> dblMovieFound;
        private List<Panel> dblPnl;
        private List<PictureBox> dblPic;
        private List<Tuple<bool, string, int, string>> dblBufferEdition;
        private List<Tuple<string, string>> dblBufferAdd;

        private Movie focusMovie;

        private bool isAllMovies;
        private bool isEditMode;
        private bool isInfo;

        private int index;
        private int page = 1;
        private int picFocusIndex;

        private string jsonPath = @"json.txt";
        private string picturePath;

        private string[] actors;

        /// <summary>
        /// Initializes a new instance of MoveForm class.
        /// </summary>
        public MovieForm() {
            InitializeComponent();

            pnlAddEditInfo.Location = new Point(
            ClientSize.Width / 2 - pnlAddEditInfo.Size.Width / 2,
            ClientSize.Height / 2 - pnlAddEditInfo.Size.Height / 2);

            dblDefaultImages = new List<Image>();
            dblDefaultImages.Add(Properties.Resources.add);
            dblDefaultImages.Add(Properties.Resources.edit);
            dblDefaultImages.Add(Properties.Resources.del);
            dblDefaultImages.Add(Properties.Resources.info);
            dblDefaultImages.Add(Properties.Resources.save);
            dblDefaultImages.Add(Properties.Resources.load);
            dblDefaultImages.Add(Properties.Resources.reset);
            dblDefaultImages.Add(Properties.Resources.previous);
            dblDefaultImages.Add(Properties.Resources.all);
            dblDefaultImages.Add(Properties.Resources.next);

            dblLbl = new List<Label>();
            dblMovie = new List<Movie>();
            dblMovieFound = new List<Movie>();
            dblPnl = new List<Panel>();
            dblPic = new List<PictureBox>();
            dblBufferEdition = new List<Tuple<bool, string, int, string>>();
            dblBufferAdd = new List<Tuple<string, string>>();

            focusMovie = new Movie();

            actors = new string[3];

            AddButtonsForm();
            AddPanelForPicture();
            AddLblAsteriskToPanelAddEditInfo();
            AddLblInfoToPanelAddEditInfo();
            AddTextBoxToPanelAddEditInfo();

            DataGridHeaderAlignmentCenter();

            InitMovies();

            LoadImagesAndLabels();

            EnableAdd(true);
            EnableEdit(false);
            EnableDel(false);
            EnableInfo(false);
            EnableSave(false);
            EnableLoad(false);
            EnablePrevious(false);
        }

        /// <summary>
        /// Raises the click event of the 'About' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void AboutClick(object sender, EventArgs e) {
            MessageBox.Show("Programmer: Terencio Agozzino\n" +
                    "             Email: agozzino.terencio@gmail.com \n" +
                    "Personal Site: http://terencio-agozzino.com\n" +
                    "         Created: May 29, 2016\n\n" +
                    "Copyright © 2016 - All Rights Reserved",
                    "About");
        }

        /// <summary>
        /// Adds actors in an array according to the TextBox control.
        /// </summary>
        private void AddActors() {
            if (txtPnlAddEdit[6].Text.Trim() != String.Empty) {
                actors[2] = txtPnlAddEdit[6].Text.Trim();
                actors[1] = txtPnlAddEdit[5].Text.Trim();
                actors[0] = txtPnlAddEdit[4].Text.Trim();
            } else if (txtPnlAddEdit[5].Text.Trim() != String.Empty) {
                actors[1] = txtPnlAddEdit[5].Text.Trim();
                actors[0] = txtPnlAddEdit[4].Text.Trim();
            } else {
                actors[0] = txtPnlAddEdit[3].Text.Trim();
            }
        }

        /// <summary>
        /// Raises the click event of the 'Add' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void AddClick(object sender, EventArgs e) {
            EnableEdit(false);
            EnableInfo(false);
            EnableDel(false);
            ShowMovies(false);
            if (tlpDgv.Visible) {
                tlpDgv.Visible = false;
            }
            isEditMode = false;
            isInfo = false;
            DisableButtons();
            ShowPanelAddEditInfo();
        }

        /// <summary>
        /// Occurs when the mouse pointer enters in the 'Add' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void AddEnter(object sender, EventArgs e) {
            cmdForm[0].Image = Properties.Resources.addEnter;
            tltGeneral.SetToolTip(cmdForm[0], "Add");
        }

        /// <summary>
        /// Adds a Label to the 'dblLbl' list.
        /// </summary>
        /// <param name="title">text of the Label<param>
        private void AddLabel(string title) {
            dblLbl.Add(new Label());
            dblLbl[dblLbl.Count - 1].Anchor = AnchorStyles.None;
            dblLbl[dblLbl.Count - 1].Location = new Point(50, 156);
            dblLbl[dblLbl.Count - 1].Name = "lbl" + dblLbl.Count;
            dblLbl[dblLbl.Count - 1].Text = title;
            dblLbl[dblLbl.Count - 1].AutoSize = false;
            dblLbl[dblLbl.Count - 1].Font = new Font("Tw Cen MT Condensed Extra Bold", 9.0f);
            dblLbl[dblLbl.Count - 1].BackColor = Color.PaleGoldenrod;
            dblLbl[dblLbl.Count - 1].TextAlign = ContentAlignment.MiddleCenter;
            dblLbl[dblLbl.Count - 1].BorderStyle = BorderStyle.FixedSingle;
            dblLbl[dblLbl.Count - 1].Dock = DockStyle.None;
            dblLbl[dblLbl.Count - 1].Click += new EventHandler(PictureAddEditClick);
            dblLbl[dblLbl.Count - 1].MouseEnter += new EventHandler(LabelEnter);
            dblLbl[dblLbl.Count - 1].MouseLeave += new EventHandler(LabelLeave);
            dblLbl[dblLbl.Count - 1].Size = new Size(150, 20);
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the 'Add' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void AddLeave(object sender, EventArgs e) {
            cmdForm[0].Image = Properties.Resources.addClick;
        }

        /// <summary>
        /// Raises the click event of the 'All' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void AllClick(object sender, EventArgs e) {
            TableLayoutPanelSwitcher(tlpCenter, tlpDgv);
            NavigationChecker();
        }

        /// <summary>
        /// Occurs when the mouse pointer enters in the 'All' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void AllEnter(object sender, EventArgs e) {
            cmdForm[8].Image = Properties.Resources.allEnter;
            tltGeneral.SetToolTip(cmdForm[8], "All Movies");
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the 'All' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void AllLeave(object sender, EventArgs e) {
            cmdForm[8].Image = Properties.Resources.allClick;
        }

        /// <summary>
        /// Manages the click of a Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        public void ButtonClick(object sender, EventArgs e) {
            Button tmpButton = sender as Button;
            int tag = (int)tmpButton.Tag;
            switch (tag) {
                case 1:
                    AddClick(sender, e);
                    break;
                case 2:
                    EditClick(sender, e);
                    break;
                case 3:
                    DelClick(sender, e);
                    break;
                case 4:
                    InfoClick(sender, e);
                    break;
                case 5:
                    SaveClick(sender, e);
                    break;
                case 6:
                    LoadClick(sender, e);
                    break;
                case 7:
                    ResetClick(sender, e);
                    break;
                case 8:
                    PreviousClick(sender, e);
                    break;
                case 9:
                    AllClick(sender, e);
                    break;
                case 10:
                    NextClick(sender, e);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        /// <summary>
        /// Manages the entry in a Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        public void ButtonEnter(object sender, EventArgs e) {
            Button tmpButton = sender as Button;
            int tag = (int)tmpButton.Tag;
            switch (tag) {
                case 1:
                    AddEnter(sender, e);
                    break;
                case 2:
                    EditEnter(sender, e);
                    break;
                case 3:
                    DelEnter(sender, e);
                    break;
                case 4:
                    InfoEnter(sender, e);
                    break;
                case 5:
                    SaveEnter(sender, e);
                    break;
                case 6:
                    LoadEnter(sender, e);
                    break;
                case 7:
                    ResetEnter(sender, e);
                    break;
                case 8:
                    PreviousEnter(sender, e);
                    break;
                case 9:
                    AllEnter(sender, e);
                    break;
                case 10:
                    NextEnter(sender, e);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        /// <summary>
        /// Manages the exit of a Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        public void ButtonLeave(object sender, EventArgs e) {
            Button tmpButton = sender as Button;
            int tag = (int)tmpButton.Tag;
            switch (tag) {
                case 1:
                    AddLeave(sender, e);
                    break;
                case 2:
                    EditLeave(sender, e);
                    break;
                case 3:
                    DelLeave(sender, e);
                    break;
                case 4:
                    InfoLeave(sender, e);
                    break;
                case 5:
                    SaveLeave(sender, e);
                    break;
                case 6:
                    LoadLeave(sender, e);
                    break;
                case 7:
                    ResetLeave(sender, e);
                    break;
                case 8:
                    PreviousLeave(sender, e);
                    break;
                case 9:
                    AllLeave(sender, e);
                    break;
                case 10:
                    NextLeave(sender, e);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        /// <summary>
        /// Raises the click event of the 'Cancel' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void CancelClick(object sender, EventArgs e) {
            pnlAddEditInfo.Visible = false;

            EnableAdd(true);
            EnableAll(true);
            EnableEdit(true);
            EnableDel(true);
            EnableInfo(true);
            EnableReset(true);

            txtSearch.TabStop = false;
            cmdForm[3].TabStop = false;


            ShowMovies(true);
            ClearPanelControls();

            NavigationChecker();
        }

        /// <summary>
        /// Clears the controls of the 'Add', 'Edit', 'Info' Panel.
        /// </summary>
        public void ClearPanelControls() {
            foreach (Control control in pnlAddEditInfo.Controls) {
                if (control is TextBox) {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox) {
                    ComboBox comboBox = (ComboBox)control;
                    comboBox.SelectedItem = null;
                    comboBox.Text = "";
                }

                picAddEdit.Image = Properties.Resources.nonePicture;
            }
        }

        /// <summary>
        /// Changes the color of the center Layout.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void ColorCenter(object sender, EventArgs e) {
            Color color;
            switch (((ToolStripMenuItem)sender).Name) {
                case "tlbBlack":
                    color = Color.Black;
                    break;
                case "tlbTransparent":
                    color = Color.Transparent;
                    break;
                case "tlbSnow":
                    color = Color.Snow;
                    break;
                case "tlbLightGoldenrodYellow":
                    color = Color.LightGoldenrodYellow;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
            tlpCenter.BackColor = color;
        }

        /// <summary>
        /// Raises the click event of the 'Delete' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void DelClick(object sender, EventArgs e) {
            UpdateDel();
            EnableSave(true);
            EnableLoad(true);
        }

        /// <summary>
        /// Occurs when the mouse pointer enters the 'Delete' control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void DelEnter(object sender, EventArgs e) {
            cmdForm[2].Image = Properties.Resources.delEnter;
            tltGeneral.SetToolTip(cmdForm[2], "Delete");
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the 'Delete' control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void DelLeave(object sender, EventArgs e) {
            cmdForm[2].Image = Properties.Resources.delClick;
        }

        /// <summary>
        /// Deserializes the path designed to a list of data.
        /// </summary>
        /// <typeparam name="T">type of Object to deserialize</typeparam>
        /// <param name="path">path for the text file</param>
        /// <returns>A deserialized list</returns>
        public static List<T> Deserialize<T>(string path) {
            List<T> dblDeserialize = new List<T>();
            if (File.Exists(path)) {
                string json = File.ReadAllText(path);
                dblDeserialize = JsonConvert.DeserializeObject<List<T>>(json);
            }
            return dblDeserialize;
        }

        /// <summary>
        /// Manages the selection of a row in the DataGridView.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void DataGridViewSelectionChanged(object sender, EventArgs e) {
            index = dgv.SelectedRows[0].Index;

            EnableEdit(true);
            EnableInfo(true);
            EnableDel(true);
        }

        /// <summary>
        /// Disables the navigation Buttons.
        /// </summary>
        private void DisableButtons() {
            EnableAdd(false);
            EnableInfo(false);
            EnableDel(false);
            EnableReset(false);
            EnableLoad(false);
            EnableSave(false);
            EnablePrevious(false);
            EnableAll(false);
            EnableNext(false);
        }

        /// <summary>
        /// Disposes the images of the PictureBox.
        /// </summary>
        private void DisposeImages() {
            foreach(PictureBox pic in dblPic) {
                pic.Image.Dispose();
            }
        }

        /// <summary>
        /// Updates Pictures of PictureBox.
        /// </summary>
        /// <param name="index">current index</param>
        /// <param name="dblList">list of movies</param>
        private void DisplayPicture(int index, List<Movie> dblList) {
            string caption = "              Title: " +
                dblList[dblList.Count - ((index + 1) + (6 * (page - 1)))].title + "\n" +
                "Release Year: " +
                dblList[dblList.Count - ((index + 1) + (6 * (page - 1)))].year + "\n" +
                "           Genre: " +
                dblList[dblList.Count - ((index + 1) + (6 * (page - 1)))].genre + "\n" +
                "          Rating: " +
                dblList[dblList.Count - ((index + 1) + (6 * (page - 1)))].rating + "\n" +
                "        Director: " +
                dblList[dblList.Count - ((index + 1) + (6 * (page - 1)))].director + "\n" +
                "          Actors: " +
                dblList[dblList.Count - ((index + 1) + (6 * (page - 1)))].actors[0];

            if (dblList[dblList.Count - ((index + 1) + (6 * (page - 1)))].actors[1] != null) {
                caption += "\n                       " +
                dblList[dblList.Count - ((index + 1) + (6 * (page - 1)))].actors[1];
            }

            if (dblList[dblList.Count - ((index + 1) + (6 * (page - 1)))].actors[2] != null) {
                caption += "\n                       " +
                dblList[dblList.Count - ((index + 1) + (6 * (page - 1)))].actors[2];
            }

            tltGeneral.SetToolTip(dblPic[index], caption);
        }

        /// <summary>
        /// Raises the click event of the 'Edit' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void EditClick(object sender, EventArgs e) {
            ClearPanelControls();
            DisableButtons();
            ShowMovies(false);
            isEditMode = true;
            isInfo = false;
            ShowPanelAddEditInfo();
        }

        /// <summary>
        /// Occurs when the mouse pointer enters in the 'Edit' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void EditEnter(object sender, EventArgs e) {
            cmdForm[1].Image = Properties.Resources.editEnter;
            tltGeneral.SetToolTip(cmdForm[1], "Edit");
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the 'Edit' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void EditLeave(object sender, EventArgs e) {
            cmdForm[1].Image = Properties.Resources.editClick;
        }

        /// <summary>
        /// Enables the asterisks of the Labels.
        /// </summary>
        /// <param name="value">true if the Labels are visible; otherwise
        /// false</param>
        private void EnableLabelAsterisk(bool value) {
            Array.ForEach(lblPnlAsterisk, lbl => lbl.Visible = value);
        }

        /// <summary>
        /// Enables the Labels of informations.
        /// </summary>
        /// <param name="value">true if the Labels are visible; otherwise
        /// false</param>
        private void EnableLabelInfo(bool value) {
            Array.ForEach(lblPnlInfo, lbl => lbl.Visible = value);
        }

        /// <summary>
        /// Enables the TextBox of the 'Add', 'Edit', 'Info' Panel.
        /// </summary>
        /// <param name="value">true if the Textbox are visible; otherwise
        /// false</param>
        private void EnableTextBoxPanel(bool value) {
            foreach (Control c in pnlAddEditInfo.Controls) {
                if (c is TextBox && c.Name != "txtDynamic7") {
                    ((TextBox)c).Visible = value;
                }
            }
        }

        /// <summary>
        /// Checks if the TextBox controls in the 'Add', 'Edit', 'Info' Panel
        /// are empty
        /// </summary>
        /// <returns>true if the Textbox's aren't empty;
        /// otherwise, false</returns>
        private bool EmptyFields() {
            if (txtPnlAddEdit[0].Text == String.Empty ||
                txtPnlAddEdit[1].Text == String.Empty ||
                txtPnlAddEdit[2].Text == String.Empty ||
                cboGenre.SelectedItem == null ||
                txtPnlAddEdit[3].Text == String.Empty ||
                txtPnlAddEdit[4].Text == String.Empty ||
                txtPnlAddEdit[7].Text == String.Empty) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Sets a value indicating if the 'Add' Button control can respond
        /// to the user interaction.
        /// </summary>
        /// <param name="value">true if the control can respond to user
        /// interaction; otherwise, false<param>
        private void EnableAdd(bool value) {
            if (value) {
                cmdForm[0].Enabled = true;
                cmdForm[0].Image = Properties.Resources.addClick;
                tlbAdd.Enabled = true;
            } else {
                cmdForm[0].Enabled = false;
                cmdForm[0].Image = Properties.Resources.add;
                tlbAdd.Enabled = false;
            }
        }

        /// <summary>
        /// Sets a value indicating if the 'Edit' Button control can respond
        /// to the user interaction.
        /// </summary>
        /// <param name="value">true if the control can respond to user
        /// interaction; otherwise, false<param>
        private void EnableEdit(bool value) {
            if (value) {
                cmdForm[1].Enabled = true;
                cmdForm[1].Image = Properties.Resources.editClick;
                tlbEdit.Enabled = true;
            } else {
                cmdForm[1].Enabled = false;
                cmdForm[1].Image = Properties.Resources.edit;
                tlbEdit.Enabled = false;
            }
        }

        /// <summary>
        /// Sets a value indicating if the 'Delete' Button control can respond
        /// to the user interaction.
        /// </summary>
        /// <param name="value">true if the control can respond to user
        /// interaction; otherwise, false<param>
        private void EnableDel(bool value) {
            if (value) {
                cmdForm[2].Enabled = true;
                cmdForm[2].Image = Properties.Resources.delClick;
                tlbDel.Enabled = true;
            } else {
                cmdForm[2].Enabled = false;
                cmdForm[2].Image = Properties.Resources.del;
                tlbDel.Enabled = false;
            }
        }

        /// <summary>
        /// Sets a value indicating if the 'Info' Button control can respond
        /// to the user interaction.
        /// </summary>
        /// <param name="value">true if the control can respond to user
        /// interaction; otherwise, false<param>
        private void EnableInfo(bool value) {
            if (value) {
                cmdForm[3].Enabled = true;
                cmdForm[3].Image = Properties.Resources.infoClick;
                tlbInfo.Enabled = true;
            } else {
                cmdForm[3].Enabled = false;
                cmdForm[3].Image = Properties.Resources.info;
                tlbInfo.Enabled = false;
            }
        }

        /// <summary>
        /// Sets a value indicating if the 'Save' Button control can respond
        /// to the user interaction.
        /// </summary>
        /// <param name="value">true if the control can respond to user
        /// interaction; otherwise, false<param>
        private void EnableSave(bool value) {
            if (value) {
                cmdForm[4].Enabled = true;
                cmdForm[4].Image = Properties.Resources.saveClick;
                tlbSave.Enabled = true;
            } else {
                cmdForm[4].Enabled = false;
                cmdForm[4].Image = Properties.Resources.save;
                tlbSave.Enabled = false;
            }
        }

        /// <summary>
        /// Sets a value indicating if the 'Load' Button control can respond
        /// to the user interaction.
        /// </summary>
        /// <param name="value">true if the control can respond to user
        /// interaction; otherwise, false<param>
        private void EnableLoad(bool value) {
            if (value) {
                cmdForm[5].Enabled = true;
                cmdForm[5].Image = Properties.Resources.loadClick;
                tlbLoad.Enabled = true;
            } else {
                cmdForm[5].Enabled = false;
                cmdForm[5].Image = Properties.Resources.load;
                tlbLoad.Enabled = false;
            }
        }

        /// <summary>
        /// Sets a value indicating if the 'Reset' Button control can respond
        /// to the user interaction.
        /// </summary>
        /// <param name="value">true if the control can respond to user
        /// interaction; otherwise, false<param>
        private void EnableReset(bool value) {
            if (value) {
                cmdForm[6].Enabled = true;
                cmdForm[6].Image = Properties.Resources.resetClick;
                tlbReset.Enabled = true;
            } else {
                cmdForm[6].Enabled = false;
                cmdForm[7].Image = Properties.Resources.reset;
                tlbReset.Enabled = false;
            }
        }

        /// <summary>
        /// Sets a value indicating if the 'Previous' Button control can respond
        /// to the user interaction.
        /// </summary>
        /// <param name="value">true if the control can respond to user
        /// interaction; otherwise, false<param>
        private void EnablePrevious(bool value) {
            if (value) {
                cmdForm[7].Enabled = true;
                cmdForm[7].Image = Properties.Resources.previousClick;
                tlbPrevious.Enabled = true;
            } else {
                cmdForm[7].Enabled = false;
                cmdForm[7].Image = Properties.Resources.previous;
                tlbPrevious.Enabled = false;
            }
        }

        /// <summary>
        /// Sets a value indicating if the 'All' Button control can respond
        /// to the user interaction.
        /// </summary>
        /// <param name="value">true if the control can respond to the user
        /// interaction; otherwise, false<param>
        private void EnableAll(bool value) {
            if (value) {
                cmdForm[8].Enabled = true;
                cmdForm[8].Image = Properties.Resources.allClick;
                tlbAll.Enabled = true;
            } else {
                cmdForm[8].Enabled = false;
                cmdForm[8].Image = Properties.Resources.all;
                tlbAll.Enabled = false;
            }
        }

        /// <summary>
        /// Sets a value indicating if the 'Next' Button control can respond
        /// to the user interaction.
        /// </summary>
        /// <param name="value">true if the control can respond to the user
        /// interaction; otherwise, false<param>
        private void EnableNext(bool value) {
            if (value) {
                cmdForm[9].Enabled = true;
                cmdForm[9].Image = Properties.Resources.nextClick;
                tlbNext.Enabled = true;
            } else {
                cmdForm[9].Enabled = false;
                cmdForm[9].Image = Properties.Resources.next;
                tlbNext.Enabled = false;
            }
        }

        /// <summary>
        /// Raises the click event of the 'Finish' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void FinishClick(object sender, EventArgs e) {
            if (EmptyFields()) {
                MessageBox.Show("All fields are required !", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (!isEditMode &&
                    IsAlreadyAMovie(txtPnlAddEdit[0].Text.Trim())) {
                MessageBox.Show("This movie is already registered !", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (!IsTitle(txtPnlAddEdit[0].Text.Trim())) {
                MessageBox.Show("The title of the movie is incorrect", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (!IsReleaseYear(txtPnlAddEdit[1].Text.Trim())) {
                MessageBox.Show("Enter a correct release year.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (!IsRating(txtPnlAddEdit[2].Text.Trim())) {
                MessageBox.Show("Enter a correct rating", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (!IsPerson(txtPnlAddEdit[3].Text.Trim())) {
                MessageBox.Show("Enter a correct director", "Warning",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (!IsPerson(txtPnlAddEdit[4].Text.Trim())) {
                MessageBox.Show("The first actor is incorrect", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (txtPnlAddEdit[7].Text.Trim() == String.Empty) {
                MessageBox.Show("The description of the movie is incorrect",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (isEditMode) {
                if (dblPic[((dblMovie.Count - picFocusIndex - 1) % 6)].Image != picAddEdit.Image) {
                    dblBufferEdition.Add(Tuple.Create(true, picturePath, picFocusIndex, dblMovie[picFocusIndex].title));
                } else {
                    dblBufferEdition.Add(Tuple.Create(false, picturePath, picFocusIndex, dblMovie[picFocusIndex].title));
                }
                dblMovie[picFocusIndex].title = txtPnlAddEdit[0].Text.Trim();
                dblMovie[picFocusIndex].year = txtPnlAddEdit[1].Text.Trim();
                dblMovie[picFocusIndex].genre = cboGenre.GetItemText(cboGenre.SelectedItem);
                dblMovie[picFocusIndex].rating = txtPnlAddEdit[2].Text.Trim();
                dblMovie[picFocusIndex].director = txtPnlAddEdit[3].Text.Trim();
                dblMovie[picFocusIndex].actors[0] = txtPnlAddEdit[4].Text.Trim();
                dblMovie[picFocusIndex].actors[1] = txtPnlAddEdit[5].Text.Trim();
                dblMovie[picFocusIndex].actors[2] = txtPnlAddEdit[6].Text.Trim();
                dblMovie[picFocusIndex].description = txtPnlAddEdit[7].Text.Trim();
                dblPic[((dblMovie.Count - picFocusIndex - 1) % 6)].Image = picAddEdit.Image;
                dblLbl[((dblMovie.Count - picFocusIndex - 1) % 6)].Text = dblMovie[picFocusIndex].title.ToUpper();
                pnlAddEditInfo.Visible = false;
                if (File.Exists(@"json.txt")) {
                    EnableLoad(true);
                }

                if (isAllMovies) {
                    dblMovie[dblMovie.Count - 1 - index].title = txtPnlAddEdit[0].Text.Trim();
                    dblMovie[dblMovie.Count - 1 - index].year = txtPnlAddEdit[1].Text.Trim();
                    dblMovie[dblMovie.Count - 1 - index].genre = cboGenre.GetItemText(cboGenre.SelectedItem);
                    dblMovie[dblMovie.Count - 1 - index].rating = txtPnlAddEdit[2].Text.Trim();
                    dblMovie[dblMovie.Count - 1 - index].director = txtPnlAddEdit[3].Text.Trim();
                    dblMovie[dblMovie.Count - 1 - index].actors[0] = txtPnlAddEdit[4].Text.Trim();
                    dblMovie[dblMovie.Count - 1 - index].actors[1] = txtPnlAddEdit[5].Text.Trim();
                    dblMovie[dblMovie.Count - 1 - index].actors[2] = txtPnlAddEdit[6].Text.Trim();
                    dblMovie[dblMovie.Count - 1 - index].description = txtPnlAddEdit[7].Text.Trim();
                    DataGridViewRow newDataRow = dgv.Rows[index];
                    newDataRow.Cells[0].Value = index;
                    newDataRow.Cells[1].Value = dblMovie[dblMovie.Count - 1 - index].title;
                    newDataRow.Cells[2].Value = dblMovie[dblMovie.Count - 1 - index].year;
                    newDataRow.Cells[3].Value = dblMovie[dblMovie.Count - 1 - index].genre;
                    newDataRow.Cells[4].Value = dblMovie[dblMovie.Count - 1 - index].rating;
                    newDataRow.Cells[5].Value = dblMovie[dblMovie.Count - 1 - index].director;
                    newDataRow.Cells[6].Value = dblMovie[dblMovie.Count - 1 - index].actors[0];
                    newDataRow.Cells[7].Value = dblMovie[dblMovie.Count - 1 - index].actors[1];
                    newDataRow.Cells[8].Value = dblMovie[dblMovie.Count - 1 - index].actors[2];
                }

                EnableAdd(true);
                EnableSave(true);
                EnableReset(true);
                EnableAll(true);
                ShowMovies(true);
                ClearPanelControls();
            } else {
                AddActors();
                if (dblMovie.Count < (6 * page)) {
                    dblPic[dblMovie.Count % 6].Image = picAddEdit.Image;
                    dblLbl[dblMovie.Count % 6].Text = txtPnlAddEdit[0].Text.Trim();
                    dblPnl[dblMovie.Count % 6].Visible = true;
                }
                dblMovie.Add(new Movie(txtPnlAddEdit[0].Text.Trim(),
                txtPnlAddEdit[1].Text.Trim(), cboGenre.GetItemText(cboGenre.SelectedItem),
                txtPnlAddEdit[2].Text.Trim(), txtPnlAddEdit[3].Text.Trim(),
                actors, txtPnlAddEdit[7].Text.Trim()));
                dblBufferAdd.Add(Tuple.Create(picturePath, txtPnlAddEdit[0].Text.Trim()));
                dgv.Rows.Add(dblMovie.Count, dblMovie[dblMovie.Count - 1].title, dblMovie[dblMovie.Count - 1].year,
                          dblMovie[dblMovie.Count - 1].genre, dblMovie[dblMovie.Count - 1].director,
                          dblMovie[dblMovie.Count - 1].actors[0], dblMovie[dblMovie.Count - 1].actors[1],
                          dblMovie[dblMovie.Count - 1].actors[2]);
                pnlAddEditInfo.Visible = false;

                if (File.Exists(@"json.txt")) {
                    EnableLoad(true);
                }
                EnableSave(true);
                EnableReset(true);
                EnableAll(true);
                ShowMovies(true);
                ClearPanelControls();
            }

            if (page == 1) {
                UpdateNextSearch(dblMovie);
            }

            NavigationChecker();

            txtSearch.TabStop = true;
            cmdForm[3].TabStop = true;
        }

        /// <summary>
        /// Raises the click event of the 'Help' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void HelpClick(object sender, EventArgs e) {
            if (MessageBox.Show("Do you want to read the report ?",
                "Help", MessageBoxButtons.YesNo,
                MessageBoxIcon.Asterisk) == DialogResult.Yes) {
                System.Diagnostics.Process.Start("main.pdf");
            }
        }

        /// <summary>
        /// Raises the click event of the 'Info' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data.</param>
        private void InfoClick(object sender, EventArgs e) {
            tltGeneral.SetToolTip(cmdForm[4], "Info");
            ShowMovies(false);
            isEditMode = false;
            isInfo = true;
            EnableAdd(false);
            EnableEdit(false);
            EnableDel(false);
            EnableReset(false);
            EnableLoad(false);
            EnableSave(false);
            EnableAll(false);
            DisableButtons();
            ShowPanelAddEditInfo();
        }

        /// <summary>
        /// Occurs when the mouse pointer enters the 'Info' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void InfoEnter(object sender, EventArgs e) {
            cmdForm[3].Image = Properties.Resources.infoEnter;
            tltGeneral.SetToolTip(cmdForm[3], "Info");
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the 'Info' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void InfoLeave(object sender, EventArgs e) {
            cmdForm[3].Image = Properties.Resources.infoClick;
        }

        /// <summary>
        /// Inits the rows of a DataGridView according to a list of Movies.
        /// </summary>
        /// <param name="dblMovie">list of movies</param>
        private void InitDataGridView(List<Movie> dblMovie) {
            for (int i = 0; i < dblMovie.Count; i++) {
                dgv.Rows.Add(i + 1, dblMovie[dblMovie.Count - (1 + i)].title,
                    dblMovie[dblMovie.Count - (1 + i)].year,
                    dblMovie[dblMovie.Count - (1 + i)].genre,
                    dblMovie[dblMovie.Count - (1 + i)].rating,
                    dblMovie[dblMovie.Count - (1 + i)].director,
                    dblMovie[dblMovie.Count - (1 + i)].actors[0],
                    dblMovie[dblMovie.Count - (1 + i)].actors[1],
                    dblMovie[dblMovie.Count - (1 + i)].actors[2]);
            }
        }

        /// <summary>
        /// Initializes movies of the library.
        /// </summary>
        private void InitMovies() {
            if (File.Exists(jsonPath)) {
                dblMovie = Deserialize<Movie>(jsonPath);

                EnableReset(true);
                EnableAll(true);

                NavigationChecker();

                InitDataGridView(dblMovie);
            }
        }

        /// <summary>
        /// Checks if the titlealready exists.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private bool IsAlreadyAMovie(string title) {
            foreach (Movie movie in dblMovie) {
                if (movie.title.Equals(title, StringComparison.InvariantCultureIgnoreCase)) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the year is correct.
        /// </summary>
        /// <param name="year">year of the movie</param>
        /// <returns>true if it is a correct year; otherwise, false</returns>
        private bool IsReleaseYear(string year) {
            if (Regex.IsMatch(year, "^(19|20)[0-9][0-9]")) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Checks if the rating is correct.
        /// </summary>
        /// <param name="rating">rating of the movie<param>
        /// <returns>true if it is a correct rating; otherwise, false</returns>
        private bool IsRating(string rating) {
            if (Regex.IsMatch(rating, @"^([0-4](\.\d{1})?)$|5$")) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Checks if the person is correct.
        /// </summary>
        /// <param name="person">name of the person<param>
        /// <returns>true if it is a person; otherwise, false</returns>
        private bool IsPerson(string person) {
            if (Regex.IsMatch(person, @"([A-Z][a-z]*)([\\s\\\'-][A-Z][a-z]*)*")) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Checks if the title is correct.
        /// </summary>
        /// <param name="title">title of the movie<param>
        /// <returns>true if it is a movie; otherwise, false</returns>
        private bool IsTitle(string title) {
            if (Regex.IsMatch(title, @"^[A-Za-z0-9\s-]+$")) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer enters in the Labels control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        public void LabelEnter(object sender, EventArgs e) {
            index = dblLbl.IndexOf(sender as Label);
            if (dblLbl[index].BackColor != ColorTranslator.FromHtml("#e8aaee")) {
                dblLbl[index].BackColor = ColorTranslator.FromHtml("#aab0ee");
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the Labels control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        public void LabelLeave(object sender, EventArgs e) {
            index = dblLbl.IndexOf(sender as Label);
            if (dblLbl[index].BackColor != ColorTranslator.FromHtml("#e8aaee")) {
                dblLbl[index].BackColor = Color.PaleGoldenrod;
            }
        }

        /// <summary>
        /// Raises the click event of the 'Load' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void LoadClick(object sender, EventArgs e) {
            string path = @"json.txt";
            dblMovie = Deserialize<Movie>(path);
            UpdateGUI();
            UpdateDataGridView(dblMovie);

            NavigationChecker();

            index = 0;
            page = 1;

            dblBufferAdd.Clear();
            dblBufferEdition.Clear();

            EnableReset(true);
            EnableAll(true);

            EnableLoad(false);
            EnablePrevious(false);

            UpdateGUI();

            MessageBox.Show("Movies Loaded !");
        }

        /// <summary>
        /// Occurs when the mouse pointer enters in the 'Load' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void LoadEnter(object sender, EventArgs e) {
            cmdForm[5].Image = Properties.Resources.loadEnter;
            tltGeneral.SetToolTip(cmdForm[5], "Load");
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the 'Load' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void LoadLeave(object sender, EventArgs e) {
            cmdForm[5].Image = Properties.Resources.loadClick;
        }

        /// <summary>
        /// Checks to enable/disable the 'Next' and 'Previous' Button.
        /// </summary>
        public void NavigationChecker() {
            NextCheck();
            PreviousCheck();
        }

        /// <summary>
        /// Checks to enable the 'Next' Button.
        /// </summary>
        private void NextCheck() {
            if (tlpDgv.Visible) {
                EnableNext(false);
            }
            else if (dblMovie.Count - (6 * page + 1) > 0) {
                EnableNext(true);
            } else {
                EnableNext(false);
            }
        }

        /// <summary>
        /// Raises the click event of the 'Next' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void NextClick(object sender, EventArgs e) {
            page += 1;
            UpdateNextSearch(dblMovie);
            foreach (Label lbl in dblLbl) {
                lbl.BackColor = Color.PaleGoldenrod;
            }
            EnablePrevious(true);
        }

        /// <summary>
        /// Occurs when the mouse pointer enters in the 'Next' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void NextEnter(object sender, EventArgs e) {
            cmdForm[9].Image = Properties.Resources.nextEnter;
            tltGeneral.SetToolTip(cmdForm[9], "Next page");
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the 'Next' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void NextLeave(object sender, EventArgs e) {
            cmdForm[9].Image = Properties.Resources.nextClick;
        }

        /// <summary>
        /// Raises the Click event of the Ok's Buttons control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void OkClick(object sender, EventArgs e) {
            pnlAddEditInfo.Visible = false;

            EnableAdd(true);
            EnableAll(true);
            EnableDel(true);
            EnableEdit(true);
            EnableInfo(true);
            EnableReset(true);

            NavigationChecker();

            cmdForm[3].TabStop = true;
            txtSearch.TabStop = true;

            ShowMovies(true);
        }

        /// <summary>
        /// Raises the click event of the PictureBox to add an image. 
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void PictureAddClick(object sender, EventArgs e) {
            using (OpenFileDialog dlg = new OpenFileDialog()) {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.png *.jpg *.bmp) | " +
                    "*.png; *.jpg; *.bmp | All Files(*.*) | *.* ";

                if (dlg.ShowDialog() == DialogResult.OK) {
                    try {
                        picAddEdit.Image = new Bitmap(dlg.FileName);
                        picturePath = dlg.FileName;
                    } catch (Exception ex) {
                        MessageBox.Show("Error: Could not read file from " +
                            "disk. Original error: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Raises the click event of the Picture of control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void PictureAddEditClick(object sender, EventArgs e) {
            if (sender is PictureBox) {
                index = dblPic.IndexOf(sender as PictureBox);
            } else {
                index = dblLbl.IndexOf(sender as Label);
            }
            dblPic[index].BorderStyle = BorderStyle.Fixed3D;
            dblLbl[index].BackColor = ColorTranslator.FromHtml("#e8aaee");
            for (int i = 0; i < dblPic.Count; i++) {
                if (i != index) {
                    dblPic[i].BorderStyle = BorderStyle.None;
                    dblLbl[i].BackColor = Color.PaleGoldenrod;
                }
            }
            picFocusIndex = dblMovie.Count - ((index + 1) + (6 * (page - 1)));
            focusMovie = dblMovie[picFocusIndex];

            EnableEdit(true);
            EnableDel(true);
            EnableInfo(true);
        }

        /// <summary>
        /// Occurs when the mouse pointer enters in the 'PictureBox' control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void PictureMouseEnter(object sender, EventArgs e) {
            index = dblPic.IndexOf(sender as PictureBox);
            if (dblLbl[index].BackColor != ColorTranslator.FromHtml("#e8aaee")) {
                dblLbl[index].BackColor = ColorTranslator.FromHtml("#aab0ee");
            }
        }

        /// <summary>
        /// Raises the Hover event of the PictureBox control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void PictureMouseHover(object sender, EventArgs e) {
            index = dblPic.IndexOf(sender as PictureBox);
            if (dblMovieFound.Count == 0) {
                DisplayPicture(index, dblMovie);
            } else {
                DisplayPicture(index, dblMovieFound);
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the 'PictureBox' control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void PictureMouseLeave(object sender, EventArgs e) {
            index = dblPic.IndexOf(sender as PictureBox);
            if (dblLbl[index].BackColor != ColorTranslator.FromHtml("#e8aaee")) {
                dblLbl[index].BackColor = Color.PaleGoldenrod;
            }
        }

        /// <summary>
        /// Checks to enable/disable the 'previous' buttons.
        /// </summary>
        public void PreviousCheck() {
            if (tlpDgv.Visible) {
                EnablePrevious(false);
            } else if (page > 1) {
                EnablePrevious(true);
            } else {
                EnablePrevious(false);
            }
        }

        /// <summary>
        /// Raises the click event of the 'Previous' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void PreviousClick(object sender, EventArgs e) {
            page -= 1;
            UpdatePicturePrev();
        }

        /// <summary>
        /// Occurs when the mouse pointer enters in the 'Previous' Button
        /// control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void PreviousEnter(object sender, EventArgs e) {
            cmdForm[7].Image = Properties.Resources.previousEnter;
            tltGeneral.SetToolTip(cmdForm[7], "Previous page");
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the 'Previous' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void PreviousLeave(object sender, EventArgs e) {
            cmdForm[7].Image = Properties.Resources.previousClick;
        }

        /// <summary>
        /// Raises the click event of the 'Reset' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data.</param>
        private void ResetClick(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Do you want to clear all "
                + "the movies ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                DisposeImages();
                for (int i = 0; i < dblPnl.Count; i++) {
                    dblPnl[i].Visible = false;
                }
                string path = @"json.txt";
                if (File.Exists(path)) {
                    File.Delete(path);
                }
                DirectoryInfo di = new DirectoryInfo(@"MoviesImages");
                foreach (FileInfo file in di.GetFiles()) {
                    file.Delete();
                }

                dblMovie.Clear();

                EnableReset(false);
                EnableEdit(false);
                EnableDel(false);
                EnableInfo(false);
                EnableSave(false);
                EnableAll(false);

                if (tlpDgv.Visible) {
                    TableLayoutPanelSwitcher(tlpCenter, tlpDgv);
                }
                UpdateDataGridView(dblMovie);
                NavigationChecker();
            }
        }

        /// <summary>
        /// Occurs when the mouse pointer enters in the 'Reset' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void ResetEnter(object sender, EventArgs e) {
            cmdForm[6].Image = Properties.Resources.resetEnter;
            tltGeneral.SetToolTip(cmdForm[6], "Reset");
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the 'Reset' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void ResetLeave(object sender, EventArgs e) {
            cmdForm[6].Image = Properties.Resources.resetClick;
        }

        /// <summary>
        /// Raises the click event of the 'Save' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void SaveClick(object sender, EventArgs e) {
            string json = Serialize(dblMovie, jsonPath);
            for (int i = 0; i < dblBufferEdition.Count; i++) {
                string pathOld = @"MoviesImages/" + dblBufferEdition[i].Item4.ToLower();
                if (File.Exists(pathOld)) {
                    if ((dblMovie[dblBufferEdition[i].Item3].title != dblBufferEdition[i].Item4)
                    && (dblBufferEdition[i].Item1)) {
                        string pathNew = @"MoviesImages/" + dblMovie[dblBufferEdition[i].Item3].title.ToLower();
                        File.Copy(dblBufferEdition[i].Item2, pathNew, true);
                        DisposeImages();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        File.Delete(pathOld);
                        UpdateGUI();
                    } else if (dblBufferEdition[i].Item1) {
                        DisposeImages();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        File.Copy(picturePath, pathOld, true);
                        UpdateGUI();
                    } else if (dblMovie[dblBufferEdition[i].Item3].title != dblBufferEdition[i].Item4) {
                        string pathNew = @"MoviesImages/" + dblMovie[dblBufferEdition[i].Item3].title.ToLower();
                        File.Copy(pathOld, pathNew, true);
                        DisposeImages();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        File.Delete(pathOld);
                        UpdateGUI();
                    }
                } else {
                    try {
                        File.Copy(picturePath, pathOld, true);
                    } catch {

                    }
                }
                dblBufferEdition.Clear();
            }
            if (dblBufferAdd.Count != 0) {
                for (int i = 0; i < dblBufferAdd.Count; i++) {
                    if (!string.IsNullOrEmpty(dblBufferAdd[i].Item1)) {
                        File.Copy(dblBufferAdd[i].Item1,
                            @"MoviesImages/" + dblBufferAdd[i].Item2.ToLower(), true);
                    }
                }
            }
            dblBufferAdd.Clear();
            dblBufferEdition.Clear();
            UpdateGUI();
            MessageBox.Show("Movies saved !");
        }

        /// <summary>
        /// Occurs when the mouse pointer enters in the 'Save' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void SaveEnter(object sender, EventArgs e) {
            cmdForm[4].Image = Properties.Resources.saveEnter;
            tltGeneral.SetToolTip(cmdForm[4], "Save");
        }

        /// <summary>
        /// Occurs when the mouse pointer leaves the 'Save' Button control.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void SaveLeave(object sender, EventArgs e) {
            cmdForm[4].Image = Properties.Resources.saveClick;
        }

        /// <summary>
        /// Manages the interaction with the search of movies.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        public void SearchTextChanged(object sender, EventArgs e) {
            TextBox txtTmp = (TextBox)sender;
            string input = txtTmp.Text;
            dblMovieFound.Clear();
            if (input.Length == 0) {
                UpdateGUI();
                NavigationChecker();
                EnableAll(true);
            } else {
                TemporaryMovies(input);
                UpdateNextSearch(dblMovieFound);
                EnableNext(false);
                EnableAll(false);
            }
        }

        /// <summary>
        /// Shows the movies.
        /// </summary>
        /// <param name="value">true if the movies are visibles; otherwise
        /// false.</param>
        private void ShowMovies(bool value) {
            if (isAllMovies) {
                tlpDgv.Visible = value;
            } else {
                tlpCenter.Visible = value;
            }
        }

        /// <summary>
        /// Show the 'Add', 'Edit', 'Info' Panel according to the user choices.
        /// </summary>
        public void ShowPanelAddEditInfo() {
            pnlAddEditInfo.Visible = true;
            if (isEditMode == true) {
                if (isAllMovies) {
                    try {
                        picAddEdit.Image = Image.FromFile(@"MoviesImages/" + dblMovie[dblMovie.Count - 1 - index].title.ToLower());
                    } catch (FileNotFoundException) {
                        picAddEdit.Image = Properties.Resources.nonePicture;
                    }
                    txtPnlAddEdit[0].Text = dblMovie[dblMovie.Count - 1 - index].title;
                    txtPnlAddEdit[1].Text = dblMovie[dblMovie.Count - 1 - index].year;
                    cboGenre.SelectedItem = dblMovie[dblMovie.Count - 1 - index].genre;
                    txtPnlAddEdit[2].Text = dblMovie[dblMovie.Count - 1 - index].rating;
                    txtPnlAddEdit[3].Text = dblMovie[dblMovie.Count - 1 - index].director;
                    txtPnlAddEdit[4].Text = dblMovie[dblMovie.Count - 1 - index].actors[0];
                    txtPnlAddEdit[5].Text = dblMovie[dblMovie.Count - 1 - index].actors[1];
                    txtPnlAddEdit[6].Text = dblMovie[dblMovie.Count - 1 - index].actors[2];
                    txtPnlAddEdit[7].Text = dblMovie[dblMovie.Count - 1 - index].description;
                } else {
                    picAddEdit.Image = dblPic[((dblMovie.Count - picFocusIndex - 1) % 6)].Image;
                    txtPnlAddEdit[0].Text = focusMovie.title;
                    txtPnlAddEdit[1].Text = focusMovie.year;
                    cboGenre.SelectedItem = focusMovie.genre;
                    txtPnlAddEdit[2].Text = focusMovie.rating;
                    txtPnlAddEdit[3].Text = focusMovie.director;
                    txtPnlAddEdit[4].Text = focusMovie.actors[0];
                    txtPnlAddEdit[5].Text = focusMovie.actors[1];
                    txtPnlAddEdit[6].Text = focusMovie.actors[2];
                    txtPnlAddEdit[7].Text = focusMovie.description;
                }
                pnlAddEditInfo.BackColor = ColorTranslator.FromHtml("#f1c40f");
                txtPnlAddEdit[7].ReadOnly = false;
                txtPnlAddEdit[7].TabStop = true;

                EnableLabelInfo(false);
                cmdOK.Visible = false;

                EnableTextBoxPanel(true);
                EnableLabelAsterisk(true);
                cboGenre.Visible = true;
                cmdCancel.Visible = true;
                cmdFinish.Visible = true;
            } else if (isInfo) {
                if (isAllMovies) {
                    try {
                        picAddEdit.Image = Image.FromFile(@"MoviesImages/" + dblMovie[dblMovie.Count - 1 - index].title.ToLower());
                    } catch (FileNotFoundException) {
                        picAddEdit.Image = Properties.Resources.nonePicture;
                    }
                    lblPnlInfo[0].Text = dblMovie[dblMovie.Count - 1 - index].title;
                    lblPnlInfo[1].Text = dblMovie[dblMovie.Count - 1 - index].year;
                    lblPnlInfo[2].Text = dblMovie[dblMovie.Count - 1 - index].genre;
                    lblPnlInfo[3].Text = dblMovie[dblMovie.Count - 1 - index].rating;
                    lblPnlInfo[4].Text = dblMovie[dblMovie.Count - 1 - index].director;
                    lblPnlInfo[5].Text = dblMovie[dblMovie.Count - 1 - index].actors[0];
                    lblPnlInfo[6].Text = dblMovie[dblMovie.Count - 1 - index].actors[1];
                    lblPnlInfo[7].Text = dblMovie[index].actors[2];
                    txtPnlAddEdit[7].Text = dblMovie[dblMovie.Count - 1 - index].description;
                } else {
                    picAddEdit.Image = dblPic[((dblMovie.Count - picFocusIndex - 1) % 6)].Image;
                    lblPnlInfo[0].Text = focusMovie.title;
                    lblPnlInfo[1].Text = focusMovie.year;
                    lblPnlInfo[2].Text = focusMovie.genre;
                    lblPnlInfo[3].Text = focusMovie.rating;
                    lblPnlInfo[4].Text = focusMovie.director;
                    lblPnlInfo[5].Text = focusMovie.actors[0];
                    lblPnlInfo[6].Text = focusMovie.actors[1];
                    lblPnlInfo[7].Text = focusMovie.actors[2];
                    txtPnlAddEdit[7].Text = focusMovie.description;
                }
                pnlAddEditInfo.BackColor = ColorTranslator.FromHtml("#2980b9");
                txtPnlAddEdit[7].ReadOnly = true;
                txtPnlAddEdit[7].TabStop = false;
                EnableTextBoxPanel(false); 
                EnableLabelAsterisk(false);
                cboGenre.Visible = false;
                cmdCancel.Visible = false;
                cmdFinish.Visible = false;

                EnableLabelInfo(true);
                cmdOK.Visible = true;

                txtSearch.TabStop = false;
                cmdForm[3].TabStop = false;
            } else {
                pnlAddEditInfo.BackColor = ColorTranslator.FromHtml("#2ecc71");

                EnableLabelInfo(false);
                cmdOK.Visible = false;

                EnableTextBoxPanel(true);
                EnableLabelAsterisk(true);
                cboGenre.Visible = true;
                cmdCancel.Visible = true;
                cmdFinish.Visible = true;

                txtPnlAddEdit[7].ReadOnly = false;
                txtPnlAddEdit[7].TabStop = true;
            }

            pnlAddEditInfo.Visible = true;
        }

        /// <summary>
        /// Serializes the list of data to the designated file path.
        /// </summary>
        /// <typeparam name="T">type of Object to serialize</typeparam>
        /// <param name="list">object list to serialize</param>
        /// <param name="path">path for the text file</param>
        /// <returns>A string representing serialized data</returns>
        public static string Serialize<T>(List<T> list, string path) {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, json);
            return json;
        }

        /// <summary>
        /// Raises the click event of the 'Color' Item.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data.</param>
        private void SwitchColor(object sender, EventArgs e) {
            Color color;
            switch (((ToolStripMenuItem)sender).Name) {
                case "tlbLightCyan":
                    color = Color.LightCyan;
                    break;
                case "tlbBlanchedAlmond":
                    color = Color.BlanchedAlmond;
                    break;
                case "tlbBurgundy":
                    color = ColorTranslator.FromHtml("#B00125");
                    break;
                case "tlbCream":
                    color = ColorTranslator.FromHtml("#FFFFCC");
                    break;
                case "tlbDarkGrey":
                    color = ColorTranslator.FromHtml("#323232");
                    break;
                case "tlbLightGreen":
                    color = ColorTranslator.FromHtml("#B2FF66");
                    break;
                case "tlbPaleGoldenrod":
                    color = Color.PaleGoldenrod;
                    break;
                case "tlbPeriwinkle":
                    color = ColorTranslator.FromHtml("#CCCCFF");
                    break;
                case "tlbPurple":
                    color = ColorTranslator.FromHtml("#CC99FF");
                    break;
                case "tlbWhite":
                    color = Color.White;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }

            tlpTop.BackColor = color;
            tlpBottom.BackColor = color;
        }

        /// <summary>
        /// Switchs of TableLayoutPanel according to the last TableLayoutPanel.
        /// </summary>
        /// <param name="tlpFirst">the first TableLayoutPanel</param>
        /// <param name="tlpSecond">the second TableLayoutPanel</param>
        private void TableLayoutPanelSwitcher(TableLayoutPanel tlpFirst,
            TableLayoutPanel tlpSecond) {
            if (tlpFirst.Visible) {
                txtSearch.Enabled = false;
                tlpFirst.Visible = false;
                tlpSecond.Visible = true;
                tltGeneral.SetToolTip(cmdForm[8], "Back to GUI");
                isAllMovies = true;
            } else {
                txtSearch.Enabled = true;
                tlpSecond.Visible = false;
                tlpFirst.Visible = true;
                tltGeneral.SetToolTip(cmdForm[8], "All Movies");
                isAllMovies = false;
            }
        }

        /// <summary>
        /// Adds movies to a temporary list according to a string.
        /// </summary>
        /// <param name="input">Input of the user</param>
        private void TemporaryMovies(string input) {
            foreach (Movie movie in dblMovie) {
                if (movie.title.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0) {
                    dblMovieFound.Add(movie);
                } else if (movie.year.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0) {
                    dblMovieFound.Add(movie);
                } else if (movie.genre.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0) {
                    dblMovieFound.Add(movie);
                } else if (movie.rating.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0) {
                    dblMovieFound.Add(movie);
                } else if (movie.director.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0) {
                    dblMovieFound.Add(movie);
                } else if (movie.actors[0].IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0) {
                    dblMovieFound.Add(movie);
                } else if (movie.actors[1].IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0) {
                    dblMovieFound.Add(movie);
                } else if (movie.actors[2].IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0) {
                    dblMovieFound.Add(movie);
                } else if (movie.description.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0) {
                    dblMovieFound.Add(movie);
                }
            }
        }

        /// <summary>
        /// Updates the DataGridView.
        /// </summary>
        /// <param name="dblMovie">list of movies</param>
        private void UpdateDataGridView(List<Movie> dblMovie) {
            dgv.Rows.Clear();
            InitDataGridView(dblMovie);
        }

        /// <summary>
        /// Updates the movies after deleted one.
        /// </summary>
        private void UpdateDel() {
            if (tlpDgv.Visible) {
                dgv.Rows.RemoveAt(index);
            }
            for (int i = index; i < 6 && i < dblMovie.Count - 1; i++) {
                dblPic[i].Image = Image.FromFile(@"MoviesImages/" + dblMovie[dblMovie.Count - (i + 2)].title.ToLower());
                dblLbl[i].Text = dblMovie[dblMovie.Count - (i + 2)].title.ToUpper();
            }
            if (dblMovie.Count < 7) {
                dblPnl[dblMovie.Count - 1].Visible = false;
            }
            //   }
            dblMovie.RemoveAt(picFocusIndex);
            if (picFocusIndex > 0) {
                picFocusIndex -= 1;
            } else {
                EnableDel(false);
            }
        }

        /// <summary>
        /// Updates images of PictureBox and texts of Labels with movies.
        /// </summary>
        public void UpdateGUI() {
            for (int i = 0; i < 6 && i < dblMovie.Count; i++) {
                if (cmdForm[6].Enabled) {
                    try {
                        dblPic[i].Image = Image.FromFile(@"MoviesImages/" +
                            dblMovie[dblMovie.Count - (1 + i)].title.ToLower());
                        dblLbl[i].Text = dblMovie[dblMovie.Count - (1 + i)].title.ToUpper();
                    } catch (FileNotFoundException) {
                        dblPic[i].Image = Properties.Resources.nonePicture;
                    }
                } else {
                    try {
                        AddPictureBox(Image.FromFile(@"MoviesImages/" +
                        dblMovie[dblMovie.Count - (1 + i)].title.ToLower()));
                    } catch {
                        AddPictureBox(Properties.Resources.nonePicture);
                    }
                }

                if (dblPnl[i].Visible == false) {
                    dblPnl[i].Visible = true;
                }
            }
        }


        /// <summary>
        /// Updates the PictureBox according to the previous page.
        /// </summary>
        private void UpdatePicturePrev() {
            DisposeImages();
            int freeSlot = (6 * (page + 1)) - dblMovie.Count;
            if (freeSlot > 0) {
                for (int i = 0; i < 6; i++) {
                    try {
                        dblPic[i].Image = Image.FromFile(@"MoviesImages/" + dblMovie[dblMovie.Count - ((6 * (page - 1)) + (i + 1))].title.ToLower());
                    } catch {
                        dblPic[i].Image = Properties.Resources.nonePicture;
                    }
                    dblLbl[i].Text = dblMovie[dblMovie.Count - ((6 * (page - 1)) + (i + 1))].title.ToUpper();
                    dblPnl[i].Visible = true;
                }
            } else {
                for (int i = 5; i >= 0; i--) {
                    try {
                        dblPic[5 - i].Image = Image.FromFile(@"MoviesImages/" + dblMovie[dblMovie.Count - ((6 * page) - (i % 6))].title.ToLower());
                    } catch {
                        dblPic[5 - i].Image = Properties.Resources.nonePicture;
                    }
                    dblLbl[5 - i].Text = dblMovie[dblMovie.Count - ((6 * page) - (i % 6))].title.ToUpper();
                    dblPnl[i].Visible = true;
                }
            }
            NavigationChecker();
        }

        /// <summary>
        /// Updates the next page and searched movies.
        /// </summary>
        public void UpdateNextSearch(List<Movie> dblList) {
            if (dblList == dblMovieFound) {
                page = 1;
            }
            DisposeImages();
            int start = dblList.Count - 6 * page;
            if (start > 0) {
                for (int i = 0; i < 6; i++) {
                    try {
                        dblPic[i].Image = Image.FromFile(@"MoviesImages/" + dblList[dblList.Count - ((6 * (page - 1)) + (i + 1))].title.ToLower());
                    } catch {
                        dblPic[i].Image = Properties.Resources.nonePicture;
                    }
                    dblLbl[i].Text = dblList[dblList.Count - ((6 * (page - 1)) + (i + 1))].title.ToUpper();
                    dblPic[i].Visible = true;
                }
            } else {
                int number = 6 - Math.Abs(start);
                for (int i = 0; i < number; i++) {
                    try {
                        dblPic[i].Image = Image.FromFile(@"MoviesImages/" + dblList[dblList.Count - ((6 * (page - 1)) + (i + 1))].title.ToLower());
                    } catch {
                        dblPic[i].Image = Properties.Resources.nonePicture;
                    }
                    dblLbl[i].Text = dblList[dblList.Count - ((6 * (page - 1)) + (i + 1))].title.ToUpper();
                    dblPic[i].Visible = true;
                }

                for (int i = number; i < 6; i++) {
                    dblPnl[i].Visible = false;
                }
            }
            NavigationChecker();
        }

        /// <summary>
        /// Raises the click event of the 'Quit' Item.
        /// </summary>
        /// <param name="sender">object which has raised the event</param>
        /// <param name="e">event data</param>
        private void QuitClick(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}