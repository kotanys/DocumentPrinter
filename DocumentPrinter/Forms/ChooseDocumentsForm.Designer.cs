namespace DocumentPrinter.Forms
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
            this.documentNameListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // documentNameListBox
            // 
            this.documentNameListBox.BackColor = System.Drawing.SystemColors.Control;
            this.documentNameListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.documentNameListBox.CheckOnClick = true;
            this.documentNameListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.documentNameListBox.FormattingEnabled = true;
            this.documentNameListBox.Location = new System.Drawing.Point(0, 0);
            this.documentNameListBox.Margin = new System.Windows.Forms.Padding(5);
            this.documentNameListBox.Name = "documentNameListBox";
            this.documentNameListBox.Size = new System.Drawing.Size(129, 18);
            this.documentNameListBox.TabIndex = 0;
            this.documentNameListBox.SelectedValueChanged += new System.EventHandler(this.DocumentNameListBoxSelectedValueChangedHandler);
            // 
            // ChooseDocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(129, 48);
            this.ControlBox = false;
            this.Controls.Add(this.documentNameListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ChooseDocumentsForm";
            this.Text = "Выберите документы";
            this.ResumeLayout(false);

        }
        private CheckedListBox documentNameListBox;
    }
}