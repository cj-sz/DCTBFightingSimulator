
namespace DCTBFightingSimulator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SeparationBar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.simulateEveButton = new System.Windows.Forms.Button();
            this.pveButton = new System.Windows.Forms.Button();
            this.pvpButton = new System.Windows.Forms.Button();
            this.createCharButton = new System.Windows.Forms.Button();
            this.charDatabaseButton = new System.Windows.Forms.Button();
            this.welcomeLabel1 = new System.Windows.Forms.Label();
            this.welcomeLabel2 = new System.Windows.Forms.Label();
            this.roadmapButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.changelogButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SeparationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Information";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Release: v0.0.1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Visit Page";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SeparationBar
            // 
            this.SeparationBar.Image = ((System.Drawing.Image)(resources.GetObject("SeparationBar.Image")));
            this.SeparationBar.InitialImage = null;
            this.SeparationBar.Location = new System.Drawing.Point(137, 9);
            this.SeparationBar.Name = "SeparationBar";
            this.SeparationBar.Size = new System.Drawing.Size(10, 823);
            this.SeparationBar.TabIndex = 3;
            this.SeparationBar.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 10);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // simulateEveButton
            // 
            this.simulateEveButton.Location = new System.Drawing.Point(15, 119);
            this.simulateEveButton.Name = "simulateEveButton";
            this.simulateEveButton.Size = new System.Drawing.Size(112, 53);
            this.simulateEveButton.TabIndex = 5;
            this.simulateEveButton.Text = "Simulate EvE";
            this.simulateEveButton.UseVisualStyleBackColor = true;
            // 
            // pveButton
            // 
            this.pveButton.Location = new System.Drawing.Point(15, 178);
            this.pveButton.Name = "pveButton";
            this.pveButton.Size = new System.Drawing.Size(112, 53);
            this.pveButton.TabIndex = 6;
            this.pveButton.Text = "PvE";
            this.pveButton.UseVisualStyleBackColor = true;
            // 
            // pvpButton
            // 
            this.pvpButton.Location = new System.Drawing.Point(19, 237);
            this.pvpButton.Name = "pvpButton";
            this.pvpButton.Size = new System.Drawing.Size(112, 53);
            this.pvpButton.TabIndex = 7;
            this.pvpButton.Text = "Local PvP";
            this.pvpButton.UseVisualStyleBackColor = true;
            // 
            // createCharButton
            // 
            this.createCharButton.Location = new System.Drawing.Point(19, 296);
            this.createCharButton.Name = "createCharButton";
            this.createCharButton.Size = new System.Drawing.Size(112, 53);
            this.createCharButton.TabIndex = 8;
            this.createCharButton.Text = "Create a Character";
            this.createCharButton.UseVisualStyleBackColor = true;
            // 
            // charDatabaseButton
            // 
            this.charDatabaseButton.Location = new System.Drawing.Point(19, 355);
            this.charDatabaseButton.Name = "charDatabaseButton";
            this.charDatabaseButton.Size = new System.Drawing.Size(112, 53);
            this.charDatabaseButton.TabIndex = 9;
            this.charDatabaseButton.Text = "Character Database";
            this.charDatabaseButton.UseVisualStyleBackColor = true;
            // 
            // welcomeLabel1
            // 
            this.welcomeLabel1.AutoSize = true;
            this.welcomeLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.welcomeLabel1.Location = new System.Drawing.Point(234, 180);
            this.welcomeLabel1.Name = "welcomeLabel1";
            this.welcomeLabel1.Size = new System.Drawing.Size(856, 51);
            this.welcomeLabel1.TabIndex = 10;
            this.welcomeLabel1.Text = "Welcome to DCTBFightingSimulator v0.0.1!";
            // 
            // welcomeLabel2
            // 
            this.welcomeLabel2.AutoSize = true;
            this.welcomeLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.welcomeLabel2.Location = new System.Drawing.Point(314, 253);
            this.welcomeLabel2.Name = "welcomeLabel2";
            this.welcomeLabel2.Size = new System.Drawing.Size(693, 37);
            this.welcomeLabel2.TabIndex = 11;
            this.welcomeLabel2.Text = "Use one of the buttons on the left to get started.";
            // 
            // roadmapButton
            // 
            this.roadmapButton.Location = new System.Drawing.Point(19, 468);
            this.roadmapButton.Name = "roadmapButton";
            this.roadmapButton.Size = new System.Drawing.Size(115, 32);
            this.roadmapButton.TabIndex = 12;
            this.roadmapButton.Text = "Roadmap";
            this.roadmapButton.UseVisualStyleBackColor = true;
            this.roadmapButton.Click += new System.EventHandler(this.roadmapButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(19, 414);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 10);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // changelogButton
            // 
            this.changelogButton.Location = new System.Drawing.Point(19, 430);
            this.changelogButton.Name = "changelogButton";
            this.changelogButton.Size = new System.Drawing.Size(115, 32);
            this.changelogButton.TabIndex = 14;
            this.changelogButton.Text = "Changelog";
            this.changelogButton.UseVisualStyleBackColor = true;
            this.changelogButton.Click += new System.EventHandler(this.changelogButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 844);
            this.Controls.Add(this.changelogButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.roadmapButton);
            this.Controls.Add(this.welcomeLabel2);
            this.Controls.Add(this.welcomeLabel1);
            this.Controls.Add(this.charDatabaseButton);
            this.Controls.Add(this.createCharButton);
            this.Controls.Add(this.pvpButton);
            this.Controls.Add(this.pveButton);
            this.Controls.Add(this.simulateEveButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SeparationBar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "DCTBFightingSimulator v0.0.1";
            ((System.ComponentModel.ISupportInitialize)(this.SeparationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox SeparationBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button simulateEveButton;
        private System.Windows.Forms.Button pveButton;
        private System.Windows.Forms.Button pvpButton;
        private System.Windows.Forms.Button createCharButton;
        private System.Windows.Forms.Button charDatabaseButton;
        private System.Windows.Forms.Label welcomeLabel1;
        private System.Windows.Forms.Label welcomeLabel2;
        private System.Windows.Forms.Button roadmapButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button changelogButton;
    }
}

