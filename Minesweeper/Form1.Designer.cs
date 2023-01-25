namespace Minesweeper
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
            this.valider_button = new System.Windows.Forms.Button();
            this.rows = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cols = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mines = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // valider_button
            // 
            this.valider_button.Location = new System.Drawing.Point(307, 361);
            this.valider_button.Name = "valider_button";
            this.valider_button.Size = new System.Drawing.Size(236, 47);
            this.valider_button.TabIndex = 0;
            this.valider_button.Text = "Valider";
            this.valider_button.UseVisualStyleBackColor = true;
            this.valider_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // rows
            // 
            this.rows.Location = new System.Drawing.Point(363, 151);
            this.rows.Name = "rows";
            this.rows.Size = new System.Drawing.Size(165, 31);
            this.rows.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(282, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "rows :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(282, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cols : ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cols
            // 
            this.cols.Location = new System.Drawing.Point(363, 203);
            this.cols.Name = "cols";
            this.cols.Size = new System.Drawing.Size(165, 31);
            this.cols.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(197, 19);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(466, 98);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bienvenue ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.UseMnemonic = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(282, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mines : ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // mines
            // 
            this.mines.Location = new System.Drawing.Point(363, 256);
            this.mines.Name = "mines";
            this.mines.Size = new System.Drawing.Size(165, 31);
            this.mines.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mines);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cols);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rows);
            this.Controls.Add(this.valider_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TextBox mines;
        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cols;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rows;

        private System.Windows.Forms.Button valider_button;

        #endregion
    }
}