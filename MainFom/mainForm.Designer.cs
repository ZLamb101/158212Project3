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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
            this.menuStrip1.SuspendLayout();
            this.enrollmentPage.SuspendLayout();
            this.tabDisplayTeam.SuspendLayout();
            this.tabDisplayPlayers.SuspendLayout();
            this.rugbyManagementTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(907, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teamsToolStripMenuItem,
            this.playersToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // teamsToolStripMenuItem
            // 
            this.teamsToolStripMenuItem.Name = "teamsToolStripMenuItem";
            this.teamsToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.teamsToolStripMenuItem.Text = "Teams";
            this.teamsToolStripMenuItem.Click += new System.EventHandler(this.teamsToolStripMenuItem_Click);
            // 
            // playersToolStripMenuItem
            // 
            this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
            this.playersToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.playersToolStripMenuItem.Text = "Players";
            this.playersToolStripMenuItem.Click += new System.EventHandler(this.playersToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teamsToolStripMenuItem1,
            this.playersToolStripMenuItem1});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.loadToolStripMenuItem.Text = "Save";
            // 
            // teamsToolStripMenuItem1
            // 
            this.teamsToolStripMenuItem1.Name = "teamsToolStripMenuItem1";
            this.teamsToolStripMenuItem1.Size = new System.Drawing.Size(130, 26);
            this.teamsToolStripMenuItem1.Text = "Teams";
            this.teamsToolStripMenuItem1.Click += new System.EventHandler(this.teamsToolStripMenuItem1_Click);
            // 
            // playersToolStripMenuItem1
            // 
            this.playersToolStripMenuItem1.Name = "playersToolStripMenuItem1";
            this.playersToolStripMenuItem1.Size = new System.Drawing.Size(130, 26);
            this.playersToolStripMenuItem1.Text = "Players";
            this.playersToolStripMenuItem1.Click += new System.EventHandler(this.playersToolStripMenuItem1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
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
            this.columnHeader2.Width = 85;
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
            // 
            // columnPlayers
            // 
            this.columnPlayers.Text = "Players";
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
            // 
            // rugbyManagementTab
            // 
            this.rugbyManagementTab.Controls.Add(this.tabDisplayPlayers);
            this.rugbyManagementTab.Controls.Add(this.tabDisplayTeam);
            this.rugbyManagementTab.Controls.Add(this.enrollmentPage);
            this.rugbyManagementTab.Location = new System.Drawing.Point(13, 42);
            this.rugbyManagementTab.Name = "rugbyManagementTab";
            this.rugbyManagementTab.SelectedIndex = 0;
            this.rugbyManagementTab.Size = new System.Drawing.Size(863, 443);
            this.rugbyManagementTab.TabIndex = 1;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 518);
            this.Controls.Add(this.rugbyManagementTab);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "Rugby_Organiser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.enrollmentPage.ResumeLayout(false);
            this.enrollmentPage.PerformLayout();
            this.tabDisplayTeam.ResumeLayout(false);
            this.tabDisplayPlayers.ResumeLayout(false);
            this.rugbyManagementTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
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
    }
}

