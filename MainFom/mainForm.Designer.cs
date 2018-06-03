namespace MainForm {
    partial class mainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTool = new System.Windows.Forms.ToolStripMenuItem();
            this.teamsToolLoadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolLoadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTool = new System.Windows.Forms.ToolStripMenuItem();
            this.teamsToolSaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolSaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.enrollmentPage = new System.Windows.Forms.TabPage();
            this.teamSelectedEnrollmentLabel = new System.Windows.Forms.Label();
            this.playerSelectedEnrollmentLabel = new System.Windows.Forms.Label();
            this.teamSelectedEnrollmentTextBox = new System.Windows.Forms.TextBox();
            this.playerSelectedEnrollmentTextBox = new System.Windows.Forms.TextBox();
            this.enrollmentButton = new System.Windows.Forms.Button();
            this.enrollTeamListView = new System.Windows.Forms.ListView();
            this.teamEnrollmentHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.enrollPlayerListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.teamEnrolLabel = new System.Windows.Forms.Label();
            this.playerEnrolLabel = new System.Windows.Forms.Label();
            this.tabDisplayTeam = new System.Windows.Forms.TabPage();
            this.gotoAddTeamButton = new System.Windows.Forms.Button();
            this.teamListView = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGround = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCoach = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFoundedYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRegion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabDisplayPlayers = new System.Windows.Forms.TabPage();
            this.gotoAddPlayerButton = new System.Windows.Forms.Button();
            this.playerListView = new System.Windows.Forms.ListView();
            this.columnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDOB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnWeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBirthPlace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTeam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rugbyManagementTab = new System.Windows.Forms.TabControl();
            this.SearchTab = new System.Windows.Forms.TabPage();
            this.chartTab = new System.Windows.Forms.TabPage();
            this.searchListView = new System.Windows.Forms.ListView();
            this.placeOfBirthRadioButton = new System.Windows.Forms.RadioButton();
            this.ageRadioButton = new System.Windows.Forms.RadioButton();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.columnIDSearch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNameSearch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDOBSearch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeightSearch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnWeightSearch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBirthPlaceSearch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTeamSearch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchByLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.enrollmentPage.SuspendLayout();
            this.tabDisplayTeam.SuspendLayout();
            this.tabDisplayPlayers.SuspendLayout();
            this.rugbyManagementTab.SuspendLayout();
            this.SearchTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(907, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTool,
            this.saveTool});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openTool
            // 
            this.openTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teamsToolLoadItem,
            this.playersToolLoadItem});
            this.openTool.Name = "openTool";
            this.openTool.Size = new System.Drawing.Size(216, 26);
            this.openTool.Text = "Open";
            // 
            // teamsToolLoadItem
            // 
            this.teamsToolLoadItem.Name = "teamsToolLoadItem";
            this.teamsToolLoadItem.Size = new System.Drawing.Size(216, 26);
            this.teamsToolLoadItem.Text = "Teams";
            this.teamsToolLoadItem.Click += new System.EventHandler(this.teamsToolLoad_Click);
            // 
            // playersToolLoadItem
            // 
            this.playersToolLoadItem.Name = "playersToolLoadItem";
            this.playersToolLoadItem.Size = new System.Drawing.Size(216, 26);
            this.playersToolLoadItem.Text = "Players";
            this.playersToolLoadItem.Click += new System.EventHandler(this.playersToolLoad_Click);
            // 
            // saveTool
            // 
            this.saveTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teamsToolSaveItem,
            this.playersToolSaveItem});
            this.saveTool.Name = "saveTool";
            this.saveTool.Size = new System.Drawing.Size(216, 26);
            this.saveTool.Text = "Save";
            // 
            // teamsToolSaveItem
            // 
            this.teamsToolSaveItem.Name = "teamsToolSaveItem";
            this.teamsToolSaveItem.Size = new System.Drawing.Size(216, 26);
            this.teamsToolSaveItem.Text = "Teams";
            this.teamsToolSaveItem.Click += new System.EventHandler(this.teamsToolSave_Click);
            // 
            // playersToolSaveItem
            // 
            this.playersToolSaveItem.Name = "playersToolSaveItem";
            this.playersToolSaveItem.Size = new System.Drawing.Size(216, 26);
            this.playersToolSaveItem.Text = "Players";
            this.playersToolSaveItem.Click += new System.EventHandler(this.playersToolSave_Click);
            // 
            // openFileDialogue
            // 
            this.openFileDialogue.FileName = "openFileDialogue";
            // 
            // enrollmentPage
            // 
            this.enrollmentPage.Controls.Add(this.teamSelectedEnrollmentLabel);
            this.enrollmentPage.Controls.Add(this.playerSelectedEnrollmentLabel);
            this.enrollmentPage.Controls.Add(this.teamSelectedEnrollmentTextBox);
            this.enrollmentPage.Controls.Add(this.playerSelectedEnrollmentTextBox);
            this.enrollmentPage.Controls.Add(this.enrollmentButton);
            this.enrollmentPage.Controls.Add(this.enrollTeamListView);
            this.enrollmentPage.Controls.Add(this.enrollPlayerListView);
            this.enrollmentPage.Controls.Add(this.teamEnrolLabel);
            this.enrollmentPage.Controls.Add(this.playerEnrolLabel);
            this.enrollmentPage.Location = new System.Drawing.Point(4, 25);
            this.enrollmentPage.Name = "enrollmentPage";
            this.enrollmentPage.Padding = new System.Windows.Forms.Padding(3);
            this.enrollmentPage.Size = new System.Drawing.Size(855, 414);
            this.enrollmentPage.TabIndex = 4;
            this.enrollmentPage.Text = "Enrollment";
            this.enrollmentPage.UseVisualStyleBackColor = true;
            // 
            // teamSelectedEnrollmentLabel
            // 
            this.teamSelectedEnrollmentLabel.AutoSize = true;
            this.teamSelectedEnrollmentLabel.Location = new System.Drawing.Point(613, 167);
            this.teamSelectedEnrollmentLabel.Name = "teamSelectedEnrollmentLabel";
            this.teamSelectedEnrollmentLabel.Size = new System.Drawing.Size(103, 17);
            this.teamSelectedEnrollmentLabel.TabIndex = 8;
            this.teamSelectedEnrollmentLabel.Text = "Team Selected";
            // 
            // playerSelectedEnrollmentLabel
            // 
            this.playerSelectedEnrollmentLabel.AutoSize = true;
            this.playerSelectedEnrollmentLabel.Location = new System.Drawing.Point(613, 88);
            this.playerSelectedEnrollmentLabel.Name = "playerSelectedEnrollmentLabel";
            this.playerSelectedEnrollmentLabel.Size = new System.Drawing.Size(107, 17);
            this.playerSelectedEnrollmentLabel.TabIndex = 7;
            this.playerSelectedEnrollmentLabel.Text = "Player Selected";
            // 
            // teamSelectedEnrollmentTextBox
            // 
            this.teamSelectedEnrollmentTextBox.Location = new System.Drawing.Point(613, 196);
            this.teamSelectedEnrollmentTextBox.Name = "teamSelectedEnrollmentTextBox";
            this.teamSelectedEnrollmentTextBox.Size = new System.Drawing.Size(179, 22);
            this.teamSelectedEnrollmentTextBox.TabIndex = 6;
            // 
            // playerSelectedEnrollmentTextBox
            // 
            this.playerSelectedEnrollmentTextBox.Location = new System.Drawing.Point(613, 128);
            this.playerSelectedEnrollmentTextBox.Name = "playerSelectedEnrollmentTextBox";
            this.playerSelectedEnrollmentTextBox.Size = new System.Drawing.Size(179, 22);
            this.playerSelectedEnrollmentTextBox.TabIndex = 5;
            // 
            // enrollmentButton
            // 
            this.enrollmentButton.Location = new System.Drawing.Point(626, 260);
            this.enrollmentButton.Name = "enrollmentButton";
            this.enrollmentButton.Size = new System.Drawing.Size(140, 39);
            this.enrollmentButton.TabIndex = 4;
            this.enrollmentButton.Text = "Enroll";
            this.enrollmentButton.UseVisualStyleBackColor = true;
            this.enrollmentButton.Click += new System.EventHandler(this.enrollmentButton_Click);
            // 
            // enrollTeamListView
            // 
            this.enrollTeamListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.teamEnrollmentHeader});
            this.enrollTeamListView.GridLines = true;
            this.enrollTeamListView.Location = new System.Drawing.Point(338, 80);
            this.enrollTeamListView.Name = "enrollTeamListView";
            this.enrollTeamListView.Size = new System.Drawing.Size(179, 317);
            this.enrollTeamListView.TabIndex = 3;
            this.enrollTeamListView.UseCompatibleStateImageBehavior = false;
            this.enrollTeamListView.View = System.Windows.Forms.View.Details;
            this.enrollTeamListView.SelectedIndexChanged += new System.EventHandler(this.enrollTeamListView_SelectedIndexChanged);
            // 
            // teamEnrollmentHeader
            // 
            this.teamEnrollmentHeader.Text = "Team Name";
            this.teamEnrollmentHeader.Width = 173;
            // 
            // enrollPlayerListView
            // 
            this.enrollPlayerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.enrollPlayerListView.GridLines = true;
            this.enrollPlayerListView.Location = new System.Drawing.Point(39, 80);
            this.enrollPlayerListView.Name = "enrollPlayerListView";
            this.enrollPlayerListView.Size = new System.Drawing.Size(247, 310);
            this.enrollPlayerListView.TabIndex = 2;
            this.enrollPlayerListView.UseCompatibleStateImageBehavior = false;
            this.enrollPlayerListView.View = System.Windows.Forms.View.Details;
            this.enrollPlayerListView.SelectedIndexChanged += new System.EventHandler(this.enrollPlayerListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 112;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Team ";
            this.columnHeader2.Width = 131;
            // 
            // teamEnrolLabel
            // 
            this.teamEnrolLabel.AutoSize = true;
            this.teamEnrolLabel.Location = new System.Drawing.Point(347, 29);
            this.teamEnrolLabel.Name = "teamEnrolLabel";
            this.teamEnrolLabel.Size = new System.Drawing.Size(44, 17);
            this.teamEnrolLabel.TabIndex = 1;
            this.teamEnrolLabel.Text = "Team";
            // 
            // playerEnrolLabel
            // 
            this.playerEnrolLabel.AutoSize = true;
            this.playerEnrolLabel.Location = new System.Drawing.Point(65, 29);
            this.playerEnrolLabel.Name = "playerEnrolLabel";
            this.playerEnrolLabel.Size = new System.Drawing.Size(48, 17);
            this.playerEnrolLabel.TabIndex = 0;
            this.playerEnrolLabel.Text = "Player";
            // 
            // tabDisplayTeam
            // 
            this.tabDisplayTeam.Controls.Add(this.gotoAddTeamButton);
            this.tabDisplayTeam.Controls.Add(this.teamListView);
            this.tabDisplayTeam.Location = new System.Drawing.Point(4, 25);
            this.tabDisplayTeam.Name = "tabDisplayTeam";
            this.tabDisplayTeam.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisplayTeam.Size = new System.Drawing.Size(855, 414);
            this.tabDisplayTeam.TabIndex = 3;
            this.tabDisplayTeam.Text = "Team";
            this.tabDisplayTeam.UseVisualStyleBackColor = true;
            // 
            // gotoAddTeamButton
            // 
            this.gotoAddTeamButton.Location = new System.Drawing.Point(53, 6);
            this.gotoAddTeamButton.Name = "gotoAddTeamButton";
            this.gotoAddTeamButton.Size = new System.Drawing.Size(94, 33);
            this.gotoAddTeamButton.TabIndex = 1;
            this.gotoAddTeamButton.Text = "Add Team";
            this.gotoAddTeamButton.UseVisualStyleBackColor = true;
            this.gotoAddTeamButton.Click += new System.EventHandler(this.gotoAddTeamButton_Click);
            // 
            // teamListView
            // 
            this.teamListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnGround,
            this.columnCoach,
            this.columnFoundedYear,
            this.columnRegion,
            this.columnPlayers});
            this.teamListView.GridLines = true;
            this.teamListView.Location = new System.Drawing.Point(53, 59);
            this.teamListView.Name = "teamListView";
            this.teamListView.Size = new System.Drawing.Size(754, 337);
            this.teamListView.TabIndex = 0;
            this.teamListView.UseCompatibleStateImageBehavior = false;
            this.teamListView.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            // 
            // columnGround
            // 
            this.columnGround.Text = "Ground";
            // 
            // columnCoach
            // 
            this.columnCoach.Text = "Coach";
            // 
            // columnFoundedYear
            // 
            this.columnFoundedYear.Text = "Founded Year";
            this.columnFoundedYear.Width = 108;
            // 
            // columnRegion
            // 
            this.columnRegion.Text = "Region";
            this.columnRegion.Width = 86;
            // 
            // columnPlayers
            // 
            this.columnPlayers.Text = "Players";
            this.columnPlayers.Width = 298;
            // 
            // tabDisplayPlayers
            // 
            this.tabDisplayPlayers.Controls.Add(this.gotoAddPlayerButton);
            this.tabDisplayPlayers.Controls.Add(this.playerListView);
            this.tabDisplayPlayers.Location = new System.Drawing.Point(4, 25);
            this.tabDisplayPlayers.Name = "tabDisplayPlayers";
            this.tabDisplayPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisplayPlayers.Size = new System.Drawing.Size(855, 414);
            this.tabDisplayPlayers.TabIndex = 1;
            this.tabDisplayPlayers.Text = "Players";
            this.tabDisplayPlayers.UseVisualStyleBackColor = true;
            // 
            // gotoAddPlayerButton
            // 
            this.gotoAddPlayerButton.Location = new System.Drawing.Point(32, 19);
            this.gotoAddPlayerButton.Name = "gotoAddPlayerButton";
            this.gotoAddPlayerButton.Size = new System.Drawing.Size(116, 30);
            this.gotoAddPlayerButton.TabIndex = 1;
            this.gotoAddPlayerButton.Text = "Add Player";
            this.gotoAddPlayerButton.UseVisualStyleBackColor = true;
            this.gotoAddPlayerButton.Click += new System.EventHandler(this.gotoAddPlayerButton_Click);
            // 
            // playerListView
            // 
            this.playerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnPName,
            this.columnDOB,
            this.columnHeight,
            this.columnWeight,
            this.columnBirthPlace,
            this.columnTeam});
            this.playerListView.GridLines = true;
            this.playerListView.Location = new System.Drawing.Point(32, 55);
            this.playerListView.Name = "playerListView";
            this.playerListView.Size = new System.Drawing.Size(765, 318);
            this.playerListView.TabIndex = 0;
            this.playerListView.UseCompatibleStateImageBehavior = false;
            this.playerListView.View = System.Windows.Forms.View.Details;
            // 
            // columnID
            // 
            this.columnID.Text = "ID";
            // 
            // columnPName
            // 
            this.columnPName.Text = "Name";
            this.columnPName.Width = 155;
            // 
            // columnDOB
            // 
            this.columnDOB.Text = "Date Of Birth";
            this.columnDOB.Width = 97;
            // 
            // columnHeight
            // 
            this.columnHeight.Text = "Height";
            // 
            // columnWeight
            // 
            this.columnWeight.Text = "Weight";
            // 
            // columnBirthPlace
            // 
            this.columnBirthPlace.Text = "Place of Birth";
            this.columnBirthPlace.Width = 145;
            // 
            // columnTeam
            // 
            this.columnTeam.Text = "Team";
            this.columnTeam.Width = 147;
            // 
            // rugbyManagementTab
            // 
            this.rugbyManagementTab.Controls.Add(this.tabDisplayPlayers);
            this.rugbyManagementTab.Controls.Add(this.tabDisplayTeam);
            this.rugbyManagementTab.Controls.Add(this.enrollmentPage);
            this.rugbyManagementTab.Controls.Add(this.SearchTab);
            this.rugbyManagementTab.Controls.Add(this.chartTab);
            this.rugbyManagementTab.Location = new System.Drawing.Point(12, 42);
            this.rugbyManagementTab.Name = "rugbyManagementTab";
            this.rugbyManagementTab.SelectedIndex = 0;
            this.rugbyManagementTab.Size = new System.Drawing.Size(863, 443);
            this.rugbyManagementTab.TabIndex = 1;
            // 
            // SearchTab
            // 
            this.SearchTab.Controls.Add(this.searchByLabel);
            this.SearchTab.Controls.Add(this.searchButton);
            this.SearchTab.Controls.Add(this.searchTextBox);
            this.SearchTab.Controls.Add(this.ageRadioButton);
            this.SearchTab.Controls.Add(this.placeOfBirthRadioButton);
            this.SearchTab.Controls.Add(this.searchListView);
            this.SearchTab.Location = new System.Drawing.Point(4, 25);
            this.SearchTab.Name = "SearchTab";
            this.SearchTab.Padding = new System.Windows.Forms.Padding(3);
            this.SearchTab.Size = new System.Drawing.Size(855, 414);
            this.SearchTab.TabIndex = 5;
            this.SearchTab.Text = "Search";
            this.SearchTab.UseVisualStyleBackColor = true;
            // 
            // chartTab
            // 
            this.chartTab.Location = new System.Drawing.Point(4, 25);
            this.chartTab.Name = "chartTab";
            this.chartTab.Padding = new System.Windows.Forms.Padding(3);
            this.chartTab.Size = new System.Drawing.Size(855, 414);
            this.chartTab.TabIndex = 6;
            this.chartTab.Text = "Chart";
            this.chartTab.UseVisualStyleBackColor = true;
            // 
            // searchListView
            // 
            this.searchListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIDSearch,
            this.columnNameSearch,
            this.columnDOBSearch,
            this.columnHeightSearch,
            this.columnWeightSearch,
            this.columnBirthPlaceSearch,
            this.columnTeamSearch});
            this.searchListView.GridLines = true;
            this.searchListView.Location = new System.Drawing.Point(29, 95);
            this.searchListView.Name = "searchListView";
            this.searchListView.Size = new System.Drawing.Size(783, 295);
            this.searchListView.TabIndex = 0;
            this.searchListView.UseCompatibleStateImageBehavior = false;
            this.searchListView.View = System.Windows.Forms.View.Details;
            // 
            // placeOfBirthRadioButton
            // 
            this.placeOfBirthRadioButton.AutoSize = true;
            this.placeOfBirthRadioButton.Location = new System.Drawing.Point(29, 68);
            this.placeOfBirthRadioButton.Name = "placeOfBirthRadioButton";
            this.placeOfBirthRadioButton.Size = new System.Drawing.Size(113, 21);
            this.placeOfBirthRadioButton.TabIndex = 1;
            this.placeOfBirthRadioButton.Text = "Place of Birth";
            this.placeOfBirthRadioButton.UseVisualStyleBackColor = true;
            // 
            // ageRadioButton
            // 
            this.ageRadioButton.AutoSize = true;
            this.ageRadioButton.Checked = true;
            this.ageRadioButton.Location = new System.Drawing.Point(29, 41);
            this.ageRadioButton.Name = "ageRadioButton";
            this.ageRadioButton.Size = new System.Drawing.Size(54, 21);
            this.ageRadioButton.TabIndex = 2;
            this.ageRadioButton.TabStop = true;
            this.ageRadioButton.Text = "Age";
            this.ageRadioButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(187, 51);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(365, 22);
            this.searchTextBox.TabIndex = 3;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(592, 47);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(121, 31);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // columnIDSearch
            // 
            this.columnIDSearch.Text = "ID";
            // 
            // columnNameSearch
            // 
            this.columnNameSearch.Text = "Name";
            this.columnNameSearch.Width = 140;
            // 
            // columnDOBSearch
            // 
            this.columnDOBSearch.Text = "Date Of Birth";
            this.columnDOBSearch.Width = 114;
            // 
            // columnHeightSearch
            // 
            this.columnHeightSearch.Text = "Height";
            this.columnHeightSearch.Width = 70;
            // 
            // columnWeightSearch
            // 
            this.columnWeightSearch.Text = "Weight";
            this.columnWeightSearch.Width = 68;
            // 
            // columnBirthPlaceSearch
            // 
            this.columnBirthPlaceSearch.Text = "Place of Birth";
            this.columnBirthPlaceSearch.Width = 140;
            // 
            // columnTeamSearch
            // 
            this.columnTeamSearch.Text = "Team";
            this.columnTeamSearch.Width = 184;
            // 
            // searchByLabel
            // 
            this.searchByLabel.AutoSize = true;
            this.searchByLabel.Location = new System.Drawing.Point(29, 18);
            this.searchByLabel.Name = "searchByLabel";
            this.searchByLabel.Size = new System.Drawing.Size(77, 17);
            this.searchByLabel.TabIndex = 5;
            this.searchByLabel.Text = "Search By:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 518);
            this.Controls.Add(this.rugbyManagementTab);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "mainForm";
            this.Text = "Rugby_Organiser";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.enrollmentPage.ResumeLayout(false);
            this.enrollmentPage.PerformLayout();
            this.tabDisplayTeam.ResumeLayout(false);
            this.tabDisplayPlayers.ResumeLayout(false);
            this.rugbyManagementTab.ResumeLayout(false);
            this.SearchTab.ResumeLayout(false);
            this.SearchTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTool;
        private System.Windows.Forms.ToolStripMenuItem teamsToolLoadItem;
        private System.Windows.Forms.ToolStripMenuItem playersToolLoadItem;
        private System.Windows.Forms.ToolStripMenuItem saveTool;
        private System.Windows.Forms.ToolStripMenuItem teamsToolSaveItem;
        private System.Windows.Forms.ToolStripMenuItem playersToolSaveItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogue;
        private System.Windows.Forms.TabPage enrollmentPage;
        private System.Windows.Forms.Label teamSelectedEnrollmentLabel;
        private System.Windows.Forms.Label playerSelectedEnrollmentLabel;
        private System.Windows.Forms.TextBox teamSelectedEnrollmentTextBox;
        private System.Windows.Forms.TextBox playerSelectedEnrollmentTextBox;
        private System.Windows.Forms.Button enrollmentButton;
        private System.Windows.Forms.ListView enrollTeamListView;
        private System.Windows.Forms.ColumnHeader teamEnrollmentHeader;
        private System.Windows.Forms.ListView enrollPlayerListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label teamEnrolLabel;
        private System.Windows.Forms.Label playerEnrolLabel;
        private System.Windows.Forms.TabPage tabDisplayTeam;
        private System.Windows.Forms.ListView teamListView;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnGround;
        private System.Windows.Forms.ColumnHeader columnCoach;
        private System.Windows.Forms.ColumnHeader columnFoundedYear;
        private System.Windows.Forms.ColumnHeader columnRegion;
        private System.Windows.Forms.ColumnHeader columnPlayers;
        private System.Windows.Forms.TabPage tabDisplayPlayers;
        private System.Windows.Forms.Button gotoAddPlayerButton;
        private System.Windows.Forms.ListView playerListView;
        private System.Windows.Forms.ColumnHeader columnID;
        private System.Windows.Forms.ColumnHeader columnPName;
        private System.Windows.Forms.ColumnHeader columnDOB;
        private System.Windows.Forms.ColumnHeader columnHeight;
        private System.Windows.Forms.ColumnHeader columnWeight;
        private System.Windows.Forms.ColumnHeader columnBirthPlace;
        private System.Windows.Forms.ColumnHeader columnTeam;
        private System.Windows.Forms.TabControl rugbyManagementTab;
        private System.Windows.Forms.Button gotoAddTeamButton;
        private System.Windows.Forms.TabPage SearchTab;
        private System.Windows.Forms.TabPage chartTab;
        private System.Windows.Forms.Label searchByLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.RadioButton ageRadioButton;
        private System.Windows.Forms.RadioButton placeOfBirthRadioButton;
        private System.Windows.Forms.ListView searchListView;
        private System.Windows.Forms.ColumnHeader columnIDSearch;
        private System.Windows.Forms.ColumnHeader columnNameSearch;
        private System.Windows.Forms.ColumnHeader columnDOBSearch;
        private System.Windows.Forms.ColumnHeader columnHeightSearch;
        private System.Windows.Forms.ColumnHeader columnWeightSearch;
        private System.Windows.Forms.ColumnHeader columnBirthPlaceSearch;
        private System.Windows.Forms.ColumnHeader columnTeamSearch;
    }
}

