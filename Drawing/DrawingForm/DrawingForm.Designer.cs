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
            this._ellipse = new System.Windows.Forms.Button();
            this._buttonBackward = new System.Windows.Forms.Button();
            this._buttonForward = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _diamond
            // 
            this._diamond.Location = new System.Drawing.Point(11, 29);
            this._diamond.Margin = new System.Windows.Forms.Padding(2);
            this._diamond.Name = "_diamond";
            this._diamond.Size = new System.Drawing.Size(130, 28);
            this._diamond.TabIndex = 0;
            this._diamond.Text = "Diamond";
            this._diamond.UseVisualStyleBackColor = true;
            this._diamond.Click += new System.EventHandler(this.HandleDiamondButtonClick);
            // 
            // _line
            // 
            this._line.Location = new System.Drawing.Point(160, 29);
            this._line.Margin = new System.Windows.Forms.Padding(2);
            this._line.Name = "_line";
            this._line.Size = new System.Drawing.Size(130, 28);
            this._line.TabIndex = 1;
            this._line.Text = "Line";
            this._line.UseVisualStyleBackColor = true;
            this._line.Click += new System.EventHandler(this.HandleLineButtonClick);
            // 
            // _clear
            // 
            this._clear.Location = new System.Drawing.Point(458, 29);
            this._clear.Margin = new System.Windows.Forms.Padding(2);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(130, 28);
            this._clear.TabIndex = 2;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            this._clear.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // _ellipse
            // 
            this._ellipse.Location = new System.Drawing.Point(309, 29);
            this._ellipse.Margin = new System.Windows.Forms.Padding(2);
            this._ellipse.Name = "_ellipse";
            this._ellipse.Size = new System.Drawing.Size(130, 28);
            this._ellipse.TabIndex = 3;
            this._ellipse.Text = "Ellipse";
            this._ellipse.UseVisualStyleBackColor = true;
            this._ellipse.Click += new System.EventHandler(this.HandleEllipseButtonClick);
            // 
            // _buttonBackward
            // 
            this._buttonBackward.Location = new System.Drawing.Point(11, 1);
            this._buttonBackward.Name = "_buttonBackward";
            this._buttonBackward.Size = new System.Drawing.Size(75, 24);
            this._buttonBackward.TabIndex = 4;
            this._buttonBackward.Text = "Undo";
            this._buttonBackward.UseVisualStyleBackColor = true;
            this._buttonBackward.Click += new System.EventHandler(this.HandleButtonBackwardClick);
            // 
            // _buttonForward
            // 
            this._buttonForward.Location = new System.Drawing.Point(93, 1);
            this._buttonForward.Name = "_buttonForward";
            this._buttonForward.Size = new System.Drawing.Size(75, 24);
            this._buttonForward.TabIndex = 5;
            this._buttonForward.Text = "Redo";
            this._buttonForward.UseVisualStyleBackColor = true;
            this._buttonForward.Click += new System.EventHandler(this.HandleButtonForwardClick);
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 338);
            this.Controls.Add(this._buttonForward);
            this.Controls.Add(this._buttonBackward);
            this.Controls.Add(this._ellipse);
            this.Controls.Add(this._clear);
            this.Controls.Add(this._line);
            this.Controls.Add(this._diamond);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DrawingForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _diamond;
        private System.Windows.Forms.Button _line;
        private System.Windows.Forms.Button _clear;
        private System.Windows.Forms.Button _ellipse;
        private System.Windows.Forms.Button _buttonBackward;
        private System.Windows.Forms.Button _buttonForward;
    }
}

