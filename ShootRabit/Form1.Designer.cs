namespace ShootRabit
{
    partial class ShootRabit
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
            this.timeGameLoop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timeGameLoop
            // 
            this.timeGameLoop.Tick += new System.EventHandler(this.timeGameLoop_Tick);
            // 
            // MoleShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ShootRabit.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(600, 438);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ShootRabit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShootRabit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShootRabit_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShootRabit_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerGameLoop;


        public System.Windows.Forms.Timer timeGameLoop { get; set; }
    }
}

