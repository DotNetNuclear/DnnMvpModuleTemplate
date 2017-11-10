namespace ModuleTemplateWizard
{
    partial class ProjectCustomProps
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
            this.txtRootNamespace = new System.Windows.Forms.TextBox();
            this.lblRootNamespace = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lblOwnerName = new System.Windows.Forms.Label();
            this.txtOwnerName = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOwnerEmail = new System.Windows.Forms.Label();
            this.txtOwnerEmail = new System.Windows.Forms.TextBox();
            this.lblOwnerWebsite = new System.Windows.Forms.Label();
            this.txtOwnerWebsite = new System.Windows.Forms.TextBox();
            this.lblDevUrl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblExampleUrl = new System.Windows.Forms.Label();
            this.gbWebserver = new System.Windows.Forms.GroupBox();
            this.txtDevUrl = new System.Windows.Forms.TextBox();
            this.rbIISExpress = new System.Windows.Forms.RadioButton();
            this.rbIIS = new System.Windows.Forms.RadioButton();
            this.gbWebserver.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRootNamespace
            // 
            this.txtRootNamespace.Location = new System.Drawing.Point(182, 71);
            this.txtRootNamespace.Name = "txtRootNamespace";
            this.txtRootNamespace.Size = new System.Drawing.Size(334, 26);
            this.txtRootNamespace.TabIndex = 0;
            // 
            // lblRootNamespace
            // 
            this.lblRootNamespace.AutoSize = true;
            this.lblRootNamespace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRootNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRootNamespace.Location = new System.Drawing.Point(26, 71);
            this.lblRootNamespace.Name = "lblRootNamespace";
            this.lblRootNamespace.Size = new System.Drawing.Size(152, 20);
            this.lblRootNamespace.TabIndex = 81;
            this.lblRootNamespace.Text = "Root Namespace:";
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.Gray;
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(452, 426);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(199, 41);
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lblOwnerName
            // 
            this.lblOwnerName.AutoSize = true;
            this.lblOwnerName.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOwnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerName.Location = new System.Drawing.Point(26, 117);
            this.lblOwnerName.Name = "lblOwnerName";
            this.lblOwnerName.Size = new System.Drawing.Size(116, 20);
            this.lblOwnerName.TabIndex = 82;
            this.lblOwnerName.Text = "Owner Name:";
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.Location = new System.Drawing.Point(182, 117);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(467, 26);
            this.txtOwnerName.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(482, 26);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Customize the project properties for your module";
            // 
            // lblOwnerEmail
            // 
            this.lblOwnerEmail.AutoSize = true;
            this.lblOwnerEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnerEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOwnerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerEmail.Location = new System.Drawing.Point(26, 164);
            this.lblOwnerEmail.Name = "lblOwnerEmail";
            this.lblOwnerEmail.Size = new System.Drawing.Size(114, 20);
            this.lblOwnerEmail.TabIndex = 83;
            this.lblOwnerEmail.Text = "Owner Email:";
            // 
            // txtOwnerEmail
            // 
            this.txtOwnerEmail.Location = new System.Drawing.Point(182, 163);
            this.txtOwnerEmail.Name = "txtOwnerEmail";
            this.txtOwnerEmail.Size = new System.Drawing.Size(467, 26);
            this.txtOwnerEmail.TabIndex = 2;
            // 
            // lblOwnerWebsite
            // 
            this.lblOwnerWebsite.AutoSize = true;
            this.lblOwnerWebsite.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnerWebsite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOwnerWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerWebsite.Location = new System.Drawing.Point(26, 211);
            this.lblOwnerWebsite.Name = "lblOwnerWebsite";
            this.lblOwnerWebsite.Size = new System.Drawing.Size(135, 20);
            this.lblOwnerWebsite.TabIndex = 84;
            this.lblOwnerWebsite.Text = "Owner Website:";
            // 
            // txtOwnerWebsite
            // 
            this.txtOwnerWebsite.Location = new System.Drawing.Point(182, 211);
            this.txtOwnerWebsite.Name = "txtOwnerWebsite";
            this.txtOwnerWebsite.Size = new System.Drawing.Size(467, 26);
            this.txtOwnerWebsite.TabIndex = 3;
            // 
            // lblDevUrl
            // 
            this.lblDevUrl.AutoSize = true;
            this.lblDevUrl.BackColor = System.Drawing.Color.Transparent;
            this.lblDevUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDevUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevUrl.Location = new System.Drawing.Point(69, 72);
            this.lblDevUrl.Name = "lblDevUrl";
            this.lblDevUrl.Size = new System.Drawing.Size(37, 20);
            this.lblDevUrl.TabIndex = 85;
            this.lblDevUrl.Text = "Url:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(522, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 99;
            this.label1.Text = ".[projectname]";
            // 
            // lblExampleUrl
            // 
            this.lblExampleUrl.AutoSize = true;
            this.lblExampleUrl.BackColor = System.Drawing.Color.Transparent;
            this.lblExampleUrl.Location = new System.Drawing.Point(148, 364);
            this.lblExampleUrl.Name = "lblExampleUrl";
            this.lblExampleUrl.Size = new System.Drawing.Size(91, 20);
            this.lblExampleUrl.TabIndex = 103;
            this.lblExampleUrl.Text = "Example url";
            // 
            // gbWebserver
            // 
            this.gbWebserver.BackColor = System.Drawing.Color.Transparent;
            this.gbWebserver.Controls.Add(this.txtDevUrl);
            this.gbWebserver.Controls.Add(this.rbIISExpress);
            this.gbWebserver.Controls.Add(this.rbIIS);
            this.gbWebserver.Controls.Add(this.lblDevUrl);
            this.gbWebserver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbWebserver.Location = new System.Drawing.Point(30, 260);
            this.gbWebserver.Name = "gbWebserver";
            this.gbWebserver.Size = new System.Drawing.Size(619, 147);
            this.gbWebserver.TabIndex = 104;
            this.gbWebserver.TabStop = false;
            this.gbWebserver.Text = "Webserver";
            // 
            // txtDevUrl
            // 
            this.txtDevUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDevUrl.Location = new System.Drawing.Point(121, 69);
            this.txtDevUrl.Name = "txtDevUrl";
            this.txtDevUrl.Size = new System.Drawing.Size(454, 26);
            this.txtDevUrl.TabIndex = 106;
            // 
            // rbIISExpress
            // 
            this.rbIISExpress.AutoSize = true;
            this.rbIISExpress.BackColor = System.Drawing.Color.Transparent;
            this.rbIISExpress.Location = new System.Drawing.Point(312, 29);
            this.rbIISExpress.Name = "rbIISExpress";
            this.rbIISExpress.Size = new System.Drawing.Size(127, 24);
            this.rbIISExpress.TabIndex = 103;
            this.rbIISExpress.TabStop = true;
            this.rbIISExpress.Text = "IIS Express";
            this.rbIISExpress.UseVisualStyleBackColor = false;
            this.rbIISExpress.CheckedChanged += new System.EventHandler(this.rbIISExpress_CheckedChanged);
            // 
            // rbIIS
            // 
            this.rbIIS.AutoSize = true;
            this.rbIIS.BackColor = System.Drawing.Color.Transparent;
            this.rbIIS.Checked = true;
            this.rbIIS.Location = new System.Drawing.Point(195, 30);
            this.rbIIS.Name = "rbIIS";
            this.rbIIS.Size = new System.Drawing.Size(58, 24);
            this.rbIIS.TabIndex = 102;
            this.rbIIS.TabStop = true;
            this.rbIIS.Text = "IIS";
            this.rbIIS.UseVisualStyleBackColor = false;
            this.rbIIS.CheckedChanged += new System.EventHandler(this.rbIIS_CheckedChanged);
            // 
            // ProjectCustomProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::ModuleTemplateWizard.Properties.Resources.Logo2_lrg_wm;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(692, 490);
            this.Controls.Add(this.lblExampleUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOwnerWebsite);
            this.Controls.Add(this.txtOwnerWebsite);
            this.Controls.Add(this.lblOwnerEmail);
            this.Controls.Add(this.txtOwnerEmail);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblOwnerName);
            this.Controls.Add(this.txtOwnerName);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lblRootNamespace);
            this.Controls.Add(this.txtRootNamespace);
            this.Controls.Add(this.gbWebserver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProjectCustomProps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DotNetNuke Module Project Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectCustomProps_FormClosing);
            this.gbWebserver.ResumeLayout(false);
            this.gbWebserver.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRootNamespace;
        private System.Windows.Forms.Label lblRootNamespace;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lblOwnerName;
        private System.Windows.Forms.TextBox txtOwnerName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOwnerEmail;
        private System.Windows.Forms.TextBox txtOwnerEmail;
        private System.Windows.Forms.Label lblOwnerWebsite;
        private System.Windows.Forms.TextBox txtOwnerWebsite;
        private System.Windows.Forms.Label lblDevUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblExampleUrl;
        private System.Windows.Forms.GroupBox gbWebserver;
        private System.Windows.Forms.RadioButton rbIISExpress;
        private System.Windows.Forms.RadioButton rbIIS;
        private System.Windows.Forms.TextBox txtDevUrl;
    }
}