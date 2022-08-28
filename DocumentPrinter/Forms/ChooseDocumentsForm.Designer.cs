﻿namespace DocumentPrinter.Forms
{
    partial class ChooseDocumentsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.docsListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // docsListBox
            // 
            this.docsListBox.BackColor = System.Drawing.SystemColors.Control;
            this.docsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.docsListBox.CheckOnClick = true;
            this.docsListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.docsListBox.FormattingEnabled = true;
            this.docsListBox.Location = new System.Drawing.Point(0, 0);
            this.docsListBox.Margin = new System.Windows.Forms.Padding(5);
            this.docsListBox.Name = "docsListBox";
            this.docsListBox.Size = new System.Drawing.Size(129, 18);
            this.docsListBox.TabIndex = 0;
            // 
            // ChooseDocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(129, 48);
            this.ControlBox = false;
            this.Controls.Add(this.docsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChooseDocumentsForm";
            this.Text = "Выберите документы";
            this.Load += new System.EventHandler(this.FormLoadHandler);
            this.ResumeLayout(false);

        }
        private CheckedListBox docsListBox;
    }
}