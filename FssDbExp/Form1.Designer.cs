﻿namespace FssDbExp
{
    partial class MainGui
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
            this.groupBoxCnInfo = new System.Windows.Forms.GroupBox();
            this.labelTestConnect = new System.Windows.Forms.Label();
            this.comboBoxTNSname = new System.Windows.Forms.ComboBox();
            this.buttonTestConnect = new System.Windows.Forms.Button();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTnsName = new System.Windows.Forms.Label();
            this.groupBoxExpType = new System.Windows.Forms.GroupBox();
            this.checkBoxExpTbl = new System.Windows.Forms.CheckBox();
            this.checkBoxExpObj = new System.Windows.Forms.CheckBox();
            this.labelMkDir = new System.Windows.Forms.Label();
            this.buttonCreateDir = new System.Windows.Forms.Button();
            this.buttonSelectDirectory = new System.Windows.Forms.Button();
            this.textBoxRootDir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxDirType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxHost = new System.Windows.Forms.CheckBox();
            this.checkBoxBDS = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxVersionName = new System.Windows.Forms.TextBox();
            this.labelVerName = new System.Windows.Forms.Label();
            this.buttonExpData = new System.Windows.Forms.Button();
            this.progressBarExpDt = new System.Windows.Forms.ProgressBar();
            this.groupBoxCnInfo.SuspendLayout();
            this.groupBoxExpType.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCnInfo
            // 
            this.groupBoxCnInfo.Controls.Add(this.labelTestConnect);
            this.groupBoxCnInfo.Controls.Add(this.comboBoxTNSname);
            this.groupBoxCnInfo.Controls.Add(this.buttonTestConnect);
            this.groupBoxCnInfo.Controls.Add(this.textBoxPass);
            this.groupBoxCnInfo.Controls.Add(this.textBoxUser);
            this.groupBoxCnInfo.Controls.Add(this.label3);
            this.groupBoxCnInfo.Controls.Add(this.label2);
            this.groupBoxCnInfo.Controls.Add(this.labelTnsName);
            this.groupBoxCnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCnInfo.Location = new System.Drawing.Point(6, 5);
            this.groupBoxCnInfo.Name = "groupBoxCnInfo";
            this.groupBoxCnInfo.Size = new System.Drawing.Size(650, 92);
            this.groupBoxCnInfo.TabIndex = 0;
            this.groupBoxCnInfo.TabStop = false;
            this.groupBoxCnInfo.Text = "Connection Info";
            // 
            // labelTestConnect
            // 
            this.labelTestConnect.AutoSize = true;
            this.labelTestConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestConnect.ForeColor = System.Drawing.Color.Green;
            this.labelTestConnect.Location = new System.Drawing.Point(554, 55);
            this.labelTestConnect.Name = "labelTestConnect";
            this.labelTestConnect.Size = new System.Drawing.Size(0, 15);
            this.labelTestConnect.TabIndex = 19;
            // 
            // comboBoxTNSname
            // 
            this.comboBoxTNSname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTNSname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTNSname.FormattingEnabled = true;
            this.comboBoxTNSname.Location = new System.Drawing.Point(97, 24);
            this.comboBoxTNSname.Name = "comboBoxTNSname";
            this.comboBoxTNSname.Size = new System.Drawing.Size(146, 21);
            this.comboBoxTNSname.TabIndex = 10;
            // 
            // buttonTestConnect
            // 
            this.buttonTestConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTestConnect.ForeColor = System.Drawing.Color.Blue;
            this.buttonTestConnect.Location = new System.Drawing.Point(435, 53);
            this.buttonTestConnect.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTestConnect.Name = "buttonTestConnect";
            this.buttonTestConnect.Size = new System.Drawing.Size(116, 25);
            this.buttonTestConnect.TabIndex = 5;
            this.buttonTestConnect.TabStop = false;
            this.buttonTestConnect.Text = "Test connection";
            this.buttonTestConnect.UseVisualStyleBackColor = true;
            this.buttonTestConnect.Click += new System.EventHandler(this.buttonTestConnect_Click);
            // 
            // textBoxPass
            // 
            this.textBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPass.Location = new System.Drawing.Point(319, 55);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(107, 21);
            this.textBoxPass.TabIndex = 1;
            this.textBoxPass.Enter += new System.EventHandler(this.textBoxPass_Enter);
            // 
            // textBoxUser
            // 
            this.textBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUser.Location = new System.Drawing.Point(97, 55);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(146, 21);
            this.textBoxUser.TabIndex = 0;
            this.textBoxUser.Enter += new System.EventHandler(this.textBoxUser_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pass:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Username:";
            // 
            // labelTnsName
            // 
            this.labelTnsName.AutoSize = true;
            this.labelTnsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTnsName.Location = new System.Drawing.Point(3, 28);
            this.labelTnsName.Name = "labelTnsName";
            this.labelTnsName.Size = new System.Drawing.Size(63, 15);
            this.labelTnsName.TabIndex = 1;
            this.labelTnsName.Text = "Database:";
            // 
            // groupBoxExpType
            // 
            this.groupBoxExpType.Controls.Add(this.checkBoxExpTbl);
            this.groupBoxExpType.Controls.Add(this.checkBoxExpObj);
            this.groupBoxExpType.Controls.Add(this.labelMkDir);
            this.groupBoxExpType.Controls.Add(this.buttonCreateDir);
            this.groupBoxExpType.Controls.Add(this.buttonSelectDirectory);
            this.groupBoxExpType.Controls.Add(this.textBoxRootDir);
            this.groupBoxExpType.Controls.Add(this.label6);
            this.groupBoxExpType.Controls.Add(this.comboBoxDirType);
            this.groupBoxExpType.Controls.Add(this.label5);
            this.groupBoxExpType.Controls.Add(this.checkBoxHost);
            this.groupBoxExpType.Controls.Add(this.checkBoxBDS);
            this.groupBoxExpType.Controls.Add(this.label4);
            this.groupBoxExpType.Controls.Add(this.textBoxVersionName);
            this.groupBoxExpType.Controls.Add(this.labelVerName);
            this.groupBoxExpType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxExpType.Location = new System.Drawing.Point(6, 103);
            this.groupBoxExpType.Name = "groupBoxExpType";
            this.groupBoxExpType.Size = new System.Drawing.Size(650, 142);
            this.groupBoxExpType.TabIndex = 1;
            this.groupBoxExpType.TabStop = false;
            this.groupBoxExpType.Text = "Export Option";
            // 
            // checkBoxExpTbl
            // 
            this.checkBoxExpTbl.AutoSize = true;
            this.checkBoxExpTbl.Checked = true;
            this.checkBoxExpTbl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExpTbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxExpTbl.Location = new System.Drawing.Point(194, 111);
            this.checkBoxExpTbl.Name = "checkBoxExpTbl";
            this.checkBoxExpTbl.Size = new System.Drawing.Size(86, 17);
            this.checkBoxExpTbl.TabIndex = 20;
            this.checkBoxExpTbl.Text = "Export Table";
            this.checkBoxExpTbl.UseVisualStyleBackColor = true;
            // 
            // checkBoxExpObj
            // 
            this.checkBoxExpObj.AutoSize = true;
            this.checkBoxExpObj.Checked = true;
            this.checkBoxExpObj.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExpObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxExpObj.Location = new System.Drawing.Point(98, 111);
            this.checkBoxExpObj.Name = "checkBoxExpObj";
            this.checkBoxExpObj.Size = new System.Drawing.Size(90, 17);
            this.checkBoxExpObj.TabIndex = 19;
            this.checkBoxExpObj.Text = "Export Object";
            this.checkBoxExpObj.UseVisualStyleBackColor = true;
            // 
            // labelMkDir
            // 
            this.labelMkDir.AutoSize = true;
            this.labelMkDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMkDir.ForeColor = System.Drawing.Color.Green;
            this.labelMkDir.Location = new System.Drawing.Point(554, 110);
            this.labelMkDir.Name = "labelMkDir";
            this.labelMkDir.Size = new System.Drawing.Size(0, 15);
            this.labelMkDir.TabIndex = 18;
            // 
            // buttonCreateDir
            // 
            this.buttonCreateDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateDir.ForeColor = System.Drawing.Color.Blue;
            this.buttonCreateDir.Location = new System.Drawing.Point(435, 105);
            this.buttonCreateDir.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCreateDir.Name = "buttonCreateDir";
            this.buttonCreateDir.Size = new System.Drawing.Size(116, 25);
            this.buttonCreateDir.TabIndex = 11;
            this.buttonCreateDir.Text = "Make Directory";
            this.buttonCreateDir.UseVisualStyleBackColor = true;
            this.buttonCreateDir.Click += new System.EventHandler(this.buttonCreateDir_Click);
            // 
            // buttonSelectDirectory
            // 
            this.buttonSelectDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectDirectory.ForeColor = System.Drawing.Color.Blue;
            this.buttonSelectDirectory.Location = new System.Drawing.Point(561, 78);
            this.buttonSelectDirectory.Name = "buttonSelectDirectory";
            this.buttonSelectDirectory.Size = new System.Drawing.Size(35, 23);
            this.buttonSelectDirectory.TabIndex = 17;
            this.buttonSelectDirectory.Text = ">>";
            this.buttonSelectDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectDirectory.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxRootDir
            // 
            this.textBoxRootDir.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxRootDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRootDir.ForeColor = System.Drawing.Color.Red;
            this.textBoxRootDir.Location = new System.Drawing.Point(97, 79);
            this.textBoxRootDir.Name = "textBoxRootDir";
            this.textBoxRootDir.Size = new System.Drawing.Size(454, 21);
            this.textBoxRootDir.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Export to:";
            // 
            // comboBoxDirType
            // 
            this.comboBoxDirType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDirType.FormattingEnabled = true;
            this.comboBoxDirType.Items.AddRange(new object[] {
            "FlexDB",
            "FDSFlexDB"});
            this.comboBoxDirType.Location = new System.Drawing.Point(519, 24);
            this.comboBoxDirType.Name = "comboBoxDirType";
            this.comboBoxDirType.Size = new System.Drawing.Size(115, 21);
            this.comboBoxDirType.TabIndex = 2;
            this.comboBoxDirType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(432, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Directory type:";
            // 
            // checkBoxHost
            // 
            this.checkBoxHost.AutoSize = true;
            this.checkBoxHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHost.Location = new System.Drawing.Point(319, 56);
            this.checkBoxHost.Name = "checkBoxHost";
            this.checkBoxHost.Size = new System.Drawing.Size(56, 17);
            this.checkBoxHost.TabIndex = 13;
            this.checkBoxHost.Text = "HOST";
            this.checkBoxHost.UseVisualStyleBackColor = true;
            // 
            // checkBoxBDS
            // 
            this.checkBoxBDS.AutoSize = true;
            this.checkBoxBDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxBDS.Location = new System.Drawing.Point(319, 29);
            this.checkBoxBDS.Name = "checkBoxBDS";
            this.checkBoxBDS.Size = new System.Drawing.Size(78, 17);
            this.checkBoxBDS.TabIndex = 12;
            this.checkBoxBDS.Text = "BDSHOST";
            this.checkBoxBDS.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(260, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "DB type:";
            // 
            // textBoxVersionName
            // 
            this.textBoxVersionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVersionName.Location = new System.Drawing.Point(97, 23);
            this.textBoxVersionName.Name = "textBoxVersionName";
            this.textBoxVersionName.Size = new System.Drawing.Size(146, 21);
            this.textBoxVersionName.TabIndex = 2;
            // 
            // labelVerName
            // 
            this.labelVerName.AutoSize = true;
            this.labelVerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVerName.Location = new System.Drawing.Point(4, 28);
            this.labelVerName.Name = "labelVerName";
            this.labelVerName.Size = new System.Drawing.Size(86, 15);
            this.labelVerName.TabIndex = 10;
            this.labelVerName.Text = "Version name:";
            // 
            // buttonExpData
            // 
            this.buttonExpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExpData.ForeColor = System.Drawing.Color.Blue;
            this.buttonExpData.Location = new System.Drawing.Point(255, 276);
            this.buttonExpData.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExpData.Name = "buttonExpData";
            this.buttonExpData.Size = new System.Drawing.Size(143, 35);
            this.buttonExpData.TabIndex = 10;
            this.buttonExpData.Text = "Generate Data";
            this.buttonExpData.UseVisualStyleBackColor = true;
            this.buttonExpData.Click += new System.EventHandler(this.buttonExpData_Click);
            // 
            // progressBarExpDt
            // 
            this.progressBarExpDt.Location = new System.Drawing.Point(6, 252);
            this.progressBarExpDt.Name = "progressBarExpDt";
            this.progressBarExpDt.Size = new System.Drawing.Size(650, 17);
            this.progressBarExpDt.Step = 1;
            this.progressBarExpDt.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarExpDt.TabIndex = 11;
            // 
            // MainGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(663, 316);
            this.Controls.Add(this.progressBarExpDt);
            this.Controls.Add(this.buttonExpData);
            this.Controls.Add(this.groupBoxExpType);
            this.Controls.Add(this.groupBoxCnInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainGui";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FssDbExp";
            this.Load += new System.EventHandler(this.MainGui_Load);
            this.groupBoxCnInfo.ResumeLayout(false);
            this.groupBoxCnInfo.PerformLayout();
            this.groupBoxExpType.ResumeLayout(false);
            this.groupBoxExpType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCnInfo;
        private System.Windows.Forms.Label labelTnsName;
        private System.Windows.Forms.Button buttonTestConnect;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxExpType;
        private System.Windows.Forms.CheckBox checkBoxHost;
        private System.Windows.Forms.CheckBox checkBoxBDS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxVersionName;
        private System.Windows.Forms.Label labelVerName;
        private System.Windows.Forms.ComboBox comboBoxDirType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSelectDirectory;
        private System.Windows.Forms.TextBox textBoxRootDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonExpData;
        private System.Windows.Forms.ProgressBar progressBarExpDt;
        private System.Windows.Forms.ComboBox comboBoxTNSname;
        private System.Windows.Forms.Button buttonCreateDir;
        private System.Windows.Forms.Label labelMkDir;
        private System.Windows.Forms.Label labelTestConnect;
        private System.Windows.Forms.CheckBox checkBoxExpTbl;
        private System.Windows.Forms.CheckBox checkBoxExpObj;
    }
}

