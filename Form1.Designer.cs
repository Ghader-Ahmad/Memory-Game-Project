namespace Memory_Game_Project
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
            System.Windows.Forms.Button btnStart;
            System.Windows.Forms.Button btnExist;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            btnStart = new System.Windows.Forms.Button();
            btnExist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = System.Drawing.Color.Pink;
            btnStart.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            btnStart.FlatAppearance.BorderSize = 2;
            btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnStart.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnStart.ForeColor = System.Drawing.Color.Magenta;
            btnStart.Location = new System.Drawing.Point(159, 287);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(193, 63);
            btnStart.TabIndex = 3;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExist
            // 
            btnExist.BackColor = System.Drawing.Color.Pink;
            btnExist.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            btnExist.FlatAppearance.BorderSize = 2;
            btnExist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExist.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnExist.ForeColor = System.Drawing.Color.Magenta;
            btnExist.Location = new System.Drawing.Point(526, 287);
            btnExist.Name = "btnExist";
            btnExist.Size = new System.Drawing.Size(193, 63);
            btnExist.TabIndex = 5;
            btnExist.Text = "EXIST";
            btnExist.UseVisualStyleBackColor = false;
            btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Viner Hand ITC", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(223, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 60);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome to memory game.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(880, 496);
            this.Controls.Add(btnExist);
            this.Controls.Add(this.label1);
            this.Controls.Add(btnStart);
            this.Name = "Form1";
            this.Text = "Memory Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}

