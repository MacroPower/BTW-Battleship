namespace Battleship
{
    partial class AddShipsForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtXVal = new System.Windows.Forms.TextBox();
            this.txtYVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYVal2 = new System.Windows.Forms.TextBox();
            this.txtXVal2 = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtXVal
            // 
            this.txtXVal.Location = new System.Drawing.Point(72, 35);
            this.txtXVal.Name = "txtXVal";
            this.txtXVal.Size = new System.Drawing.Size(47, 20);
            this.txtXVal.TabIndex = 1;
            // 
            // txtYVal
            // 
            this.txtYVal.Location = new System.Drawing.Point(72, 61);
            this.txtYVal.Name = "txtYVal";
            this.txtYVal.Size = new System.Drawing.Size(47, 20);
            this.txtYVal.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "X - Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y - Value";
            // 
            // txtYVal2
            // 
            this.txtYVal2.Location = new System.Drawing.Point(125, 61);
            this.txtYVal2.Name = "txtYVal2";
            this.txtYVal2.Size = new System.Drawing.Size(47, 20);
            this.txtYVal2.TabIndex = 6;
            // 
            // txtXVal2
            // 
            this.txtXVal2.Location = new System.Drawing.Point(125, 35);
            this.txtXVal2.Name = "txtXVal2";
            this.txtXVal2.Size = new System.Drawing.Size(47, 20);
            this.txtXVal2.TabIndex = 5;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(122, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(56, 13);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "ShipName";
            // 
            // AddShipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 95);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.txtYVal2);
            this.Controls.Add(this.txtXVal2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtYVal);
            this.Controls.Add(this.txtXVal);
            this.Controls.Add(this.button1);
            this.Name = "AddShipsForm";
            this.Text = "AddShipsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtXVal;
        private System.Windows.Forms.TextBox txtYVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYVal2;
        private System.Windows.Forms.TextBox txtXVal2;
        private System.Windows.Forms.Label titleLabel;
    }
}