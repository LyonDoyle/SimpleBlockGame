namespace BlockGameApp
{
    partial class frmSettings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPlayerColor = new System.Windows.Forms.Button();
            this.btnEnemyColor = new System.Windows.Forms.Button();
            this.btnBackgroundColor = new System.Windows.Forms.Button();
            this.btnGoalColor = new System.Windows.Forms.Button();
            this.grpManualSettings = new System.Windows.Forms.GroupBox();
            this.chkRetroMode = new System.Windows.Forms.CheckBox();
            this.grpManualSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(64, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(145, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnPlayerColor
            // 
            this.btnPlayerColor.FlatAppearance.BorderSize = 0;
            this.btnPlayerColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayerColor.Location = new System.Drawing.Point(6, 19);
            this.btnPlayerColor.Name = "btnPlayerColor";
            this.btnPlayerColor.Size = new System.Drawing.Size(75, 23);
            this.btnPlayerColor.TabIndex = 2;
            this.btnPlayerColor.Text = "Player Color";
            this.btnPlayerColor.UseVisualStyleBackColor = true;
            // 
            // btnEnemyColor
            // 
            this.btnEnemyColor.FlatAppearance.BorderSize = 0;
            this.btnEnemyColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnemyColor.Location = new System.Drawing.Point(87, 19);
            this.btnEnemyColor.Name = "btnEnemyColor";
            this.btnEnemyColor.Size = new System.Drawing.Size(75, 23);
            this.btnEnemyColor.TabIndex = 3;
            this.btnEnemyColor.Text = "Enemy Color";
            this.btnEnemyColor.UseVisualStyleBackColor = true;
            // 
            // btnBackgroundColor
            // 
            this.btnBackgroundColor.FlatAppearance.BorderSize = 0;
            this.btnBackgroundColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackgroundColor.Location = new System.Drawing.Point(6, 48);
            this.btnBackgroundColor.Name = "btnBackgroundColor";
            this.btnBackgroundColor.Size = new System.Drawing.Size(237, 23);
            this.btnBackgroundColor.TabIndex = 4;
            this.btnBackgroundColor.Text = "Background Color";
            this.btnBackgroundColor.UseVisualStyleBackColor = true;
            // 
            // btnGoalColor
            // 
            this.btnGoalColor.FlatAppearance.BorderSize = 0;
            this.btnGoalColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoalColor.Location = new System.Drawing.Point(168, 19);
            this.btnGoalColor.Name = "btnGoalColor";
            this.btnGoalColor.Size = new System.Drawing.Size(75, 23);
            this.btnGoalColor.TabIndex = 5;
            this.btnGoalColor.Text = "Goal Color";
            this.btnGoalColor.UseVisualStyleBackColor = true;
            // 
            // grpManualSettings
            // 
            this.grpManualSettings.AutoSize = true;
            this.grpManualSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpManualSettings.Controls.Add(this.btnPlayerColor);
            this.grpManualSettings.Controls.Add(this.btnGoalColor);
            this.grpManualSettings.Controls.Add(this.btnEnemyColor);
            this.grpManualSettings.Controls.Add(this.btnBackgroundColor);
            this.grpManualSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpManualSettings.Location = new System.Drawing.Point(12, 12);
            this.grpManualSettings.Name = "grpManualSettings";
            this.grpManualSettings.Size = new System.Drawing.Size(249, 90);
            this.grpManualSettings.TabIndex = 6;
            this.grpManualSettings.TabStop = false;
            this.grpManualSettings.Text = "Manual Settings";
            // 
            // chkRetroMode
            // 
            this.chkRetroMode.AutoSize = true;
            this.chkRetroMode.Location = new System.Drawing.Point(12, 108);
            this.chkRetroMode.Name = "chkRetroMode";
            this.chkRetroMode.Size = new System.Drawing.Size(81, 17);
            this.chkRetroMode.TabIndex = 7;
            this.chkRetroMode.Text = "Retro mode";
            this.chkRetroMode.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.chkRetroMode);
            this.Controls.Add(this.grpManualSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.grpManualSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPlayerColor;
        private System.Windows.Forms.Button btnEnemyColor;
        private System.Windows.Forms.Button btnBackgroundColor;
        private System.Windows.Forms.Button btnGoalColor;
        private System.Windows.Forms.GroupBox grpManualSettings;
        private System.Windows.Forms.CheckBox chkRetroMode;
    }
}