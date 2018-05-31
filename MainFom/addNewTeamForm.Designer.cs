namespace AddNewTeamForm {
    partial class addNewTeamForm {
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
            this.addTeamButton = new System.Windows.Forms.Button();
            this.addTeamNameLabel = new System.Windows.Forms.Label();
            this.addTeamGroundLabel = new System.Windows.Forms.Label();
            this.addTeamCoachLabel = new System.Windows.Forms.Label();
            this.addTeamYearFoundedLabel = new System.Windows.Forms.Label();
            this.addTeamRegionLabel = new System.Windows.Forms.Label();
            this.addTeamNameTextBox = new System.Windows.Forms.TextBox();
            this.addTeamGroundTextBox = new System.Windows.Forms.TextBox();
            this.addTeamCoachTextBox = new System.Windows.Forms.TextBox();
            this.addTeamRegionTextBox = new System.Windows.Forms.TextBox();
            this.addTeamYearFoundedTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addTeamButton
            // 
            this.addTeamButton.Location = new System.Drawing.Point(137, 382);
            this.addTeamButton.Name = "addTeamButton";
            this.addTeamButton.Size = new System.Drawing.Size(139, 58);
            this.addTeamButton.TabIndex = 0;
            this.addTeamButton.Text = "Add Team";
            this.addTeamButton.UseVisualStyleBackColor = true;
            this.addTeamButton.Click += new System.EventHandler(this.addTeamButton_Click);
            // 
            // addTeamNameLabel
            // 
            this.addTeamNameLabel.AutoSize = true;
            this.addTeamNameLabel.Location = new System.Drawing.Point(74, 92);
            this.addTeamNameLabel.Name = "addTeamNameLabel";
            this.addTeamNameLabel.Size = new System.Drawing.Size(85, 17);
            this.addTeamNameLabel.TabIndex = 1;
            this.addTeamNameLabel.Text = "Team Name";
            // 
            // addTeamGroundLabel
            // 
            this.addTeamGroundLabel.AutoSize = true;
            this.addTeamGroundLabel.Location = new System.Drawing.Point(77, 153);
            this.addTeamGroundLabel.Name = "addTeamGroundLabel";
            this.addTeamGroundLabel.Size = new System.Drawing.Size(56, 17);
            this.addTeamGroundLabel.TabIndex = 2;
            this.addTeamGroundLabel.Text = "Ground";
            // 
            // addTeamCoachLabel
            // 
            this.addTeamCoachLabel.AutoSize = true;
            this.addTeamCoachLabel.Location = new System.Drawing.Point(228, 153);
            this.addTeamCoachLabel.Name = "addTeamCoachLabel";
            this.addTeamCoachLabel.Size = new System.Drawing.Size(48, 17);
            this.addTeamCoachLabel.TabIndex = 3;
            this.addTeamCoachLabel.Text = "Coach";
            // 
            // addTeamYearFoundedLabel
            // 
            this.addTeamYearFoundedLabel.AutoSize = true;
            this.addTeamYearFoundedLabel.Location = new System.Drawing.Point(228, 220);
            this.addTeamYearFoundedLabel.Name = "addTeamYearFoundedLabel";
            this.addTeamYearFoundedLabel.Size = new System.Drawing.Size(98, 17);
            this.addTeamYearFoundedLabel.TabIndex = 4;
            this.addTeamYearFoundedLabel.Text = "Year Founded";
            // 
            // addTeamRegionLabel
            // 
            this.addTeamRegionLabel.AutoSize = true;
            this.addTeamRegionLabel.Location = new System.Drawing.Point(80, 220);
            this.addTeamRegionLabel.Name = "addTeamRegionLabel";
            this.addTeamRegionLabel.Size = new System.Drawing.Size(53, 17);
            this.addTeamRegionLabel.TabIndex = 5;
            this.addTeamRegionLabel.Text = "Region";
            // 
            // addTeamNameTextBox
            // 
            this.addTeamNameTextBox.Location = new System.Drawing.Point(80, 113);
            this.addTeamNameTextBox.Name = "addTeamNameTextBox";
            this.addTeamNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.addTeamNameTextBox.TabIndex = 6;
            // 
            // addTeamGroundTextBox
            // 
            this.addTeamGroundTextBox.Location = new System.Drawing.Point(80, 184);
            this.addTeamGroundTextBox.Name = "addTeamGroundTextBox";
            this.addTeamGroundTextBox.Size = new System.Drawing.Size(100, 22);
            this.addTeamGroundTextBox.TabIndex = 7;
            this.addTeamGroundTextBox.TextChanged += new System.EventHandler(this.addTeamGroundTextBox_TextChanged);
            // 
            // addTeamCoachTextBox
            // 
            this.addTeamCoachTextBox.Location = new System.Drawing.Point(231, 184);
            this.addTeamCoachTextBox.Name = "addTeamCoachTextBox";
            this.addTeamCoachTextBox.Size = new System.Drawing.Size(100, 22);
            this.addTeamCoachTextBox.TabIndex = 8;
            // 
            // addTeamRegionTextBox
            // 
            this.addTeamRegionTextBox.Location = new System.Drawing.Point(80, 253);
            this.addTeamRegionTextBox.Name = "addTeamRegionTextBox";
            this.addTeamRegionTextBox.Size = new System.Drawing.Size(100, 22);
            this.addTeamRegionTextBox.TabIndex = 9;
            // 
            // addTeamYearFoundedTextBox
            // 
            this.addTeamYearFoundedTextBox.Location = new System.Drawing.Point(231, 252);
            this.addTeamYearFoundedTextBox.Name = "addTeamYearFoundedTextBox";
            this.addTeamYearFoundedTextBox.Size = new System.Drawing.Size(100, 22);
            this.addTeamYearFoundedTextBox.TabIndex = 10;
            // 
            // addNewTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 482);
            this.Controls.Add(this.addTeamYearFoundedTextBox);
            this.Controls.Add(this.addTeamRegionTextBox);
            this.Controls.Add(this.addTeamCoachTextBox);
            this.Controls.Add(this.addTeamGroundTextBox);
            this.Controls.Add(this.addTeamNameTextBox);
            this.Controls.Add(this.addTeamRegionLabel);
            this.Controls.Add(this.addTeamYearFoundedLabel);
            this.Controls.Add(this.addTeamCoachLabel);
            this.Controls.Add(this.addTeamGroundLabel);
            this.Controls.Add(this.addTeamNameLabel);
            this.Controls.Add(this.addTeamButton);
            this.Name = "addNewTeamForm";
            this.Text = "Add Team";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addTeamButton;
        private System.Windows.Forms.Label addTeamNameLabel;
        private System.Windows.Forms.Label addTeamGroundLabel;
        private System.Windows.Forms.Label addTeamCoachLabel;
        private System.Windows.Forms.Label addTeamYearFoundedLabel;
        private System.Windows.Forms.Label addTeamRegionLabel;
        private System.Windows.Forms.TextBox addTeamNameTextBox;
        private System.Windows.Forms.TextBox addTeamGroundTextBox;
        private System.Windows.Forms.TextBox addTeamCoachTextBox;
        private System.Windows.Forms.TextBox addTeamRegionTextBox;
        private System.Windows.Forms.TextBox addTeamYearFoundedTextBox;
    }
}

