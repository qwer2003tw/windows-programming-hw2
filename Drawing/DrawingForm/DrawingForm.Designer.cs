namespace DrawingForm
{
    partial class DrawingForm
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
            this._diamond = new System.Windows.Forms.Button();
            this._line = new System.Windows.Forms.Button();
            this._clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _diamond
            // 
            this._diamond.Location = new System.Drawing.Point(12, 12);
            this._diamond.Name = "_diamond";
            this._diamond.Size = new System.Drawing.Size(233, 38);
            this._diamond.TabIndex = 0;
            this._diamond.Text = "Diamond";
            this._diamond.UseVisualStyleBackColor = true;
            this._diamond.Click += new System.EventHandler(this.HandleDiamondButtonClick);
            // 
            // _line
            // 
            this._line.Location = new System.Drawing.Point(283, 12);
            this._line.Name = "_line";
            this._line.Size = new System.Drawing.Size(233, 38);
            this._line.TabIndex = 1;
            this._line.Text = "Line";
            this._line.UseVisualStyleBackColor = true;
            this._line.Click += new System.EventHandler(this.HandleLineButtonClick);
            // 
            // _clear
            // 
            this._clear.Location = new System.Drawing.Point(554, 12);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(233, 38);
            this._clear.TabIndex = 2;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            this._clear.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._clear);
            this.Controls.Add(this._line);
            this.Controls.Add(this._diamond);
            this.Name = "DrawingForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _diamond;
        private System.Windows.Forms.Button _line;
        private System.Windows.Forms.Button _clear;
    }
}

