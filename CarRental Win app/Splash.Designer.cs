namespace CarRental
{
    partial class Splash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.MyCar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.myprogress = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.Precentage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MyCar)).BeginInit();
            this.myprogress.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyCar
            // 
            this.MyCar.BackColor = System.Drawing.Color.Transparent;
            this.MyCar.Image = ((System.Drawing.Image)(resources.GetObject("MyCar.Image")));
            this.MyCar.ImageRotate = 0F;
            this.MyCar.Location = new System.Drawing.Point(25, 32);
            this.MyCar.Name = "MyCar";
            this.MyCar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.MyCar.Size = new System.Drawing.Size(127, 114);
            this.MyCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MyCar.TabIndex = 0;
            this.MyCar.TabStop = false;
            this.MyCar.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // myprogress
            // 
            this.myprogress.Controls.Add(this.Precentage);
            this.myprogress.Controls.Add(this.MyCar);
            this.myprogress.FillColor = System.Drawing.Color.Red;
            this.myprogress.FillThickness = 8;
            this.myprogress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.myprogress.ForeColor = System.Drawing.Color.White;
            this.myprogress.Location = new System.Drawing.Point(315, 106);
            this.myprogress.Minimum = 0;
            this.myprogress.Name = "myprogress";
            this.myprogress.ProgressColor = System.Drawing.Color.White;
            this.myprogress.ProgressColor2 = System.Drawing.Color.White;
            this.myprogress.ProgressThickness = 8;
            this.myprogress.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.myprogress.Size = new System.Drawing.Size(177, 177);
            this.myprogress.TabIndex = 1;
            this.myprogress.Text = "guna2CircleProgressBar1";
            // 
            // Precentage
            // 
            this.Precentage.AutoSize = true;
            this.Precentage.Font = new System.Drawing.Font("Agency FB", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Precentage.ForeColor = System.Drawing.Color.White;
            this.Precentage.Location = new System.Drawing.Point(50, 115);
            this.Precentage.Name = "Precentage";
            this.Precentage.Size = new System.Drawing.Size(18, 21);
            this.Precentage.TabIndex = 4;
            this.Precentage.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(270, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "Car Rental System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(349, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "CodeSpace";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(800, 359);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myprogress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyCar)).EndInit();
            this.myprogress.ResumeLayout(false);
            this.myprogress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox MyCar;
        private Guna.UI2.WinForms.Guna2CircleProgressBar myprogress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Precentage;
    }
}

