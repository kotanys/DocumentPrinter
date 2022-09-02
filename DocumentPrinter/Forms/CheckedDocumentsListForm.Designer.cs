namespace DocumentPrinter.Forms
{
    partial class CheckedDocumentsListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckedDocumentsListForm));
            this.listBox = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.changeDocumentFormatButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.Control;
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(0, 25);
            this.listBox.Margin = new System.Windows.Forms.Padding(0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(226, 50);
            this.listBox.Sorted = true;
            this.listBox.TabIndex = 0;
            this.listBox.Click += new System.EventHandler(this.ListBoxClickHandler);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeDocumentFormatButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(226, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // changeDocumentFormatButton
            // 
            this.changeDocumentFormatButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.changeDocumentFormatButton.Image = ((System.Drawing.Image)(resources.GetObject("changeDocumentFormatButton.Image")));
            this.changeDocumentFormatButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changeDocumentFormatButton.Name = "changeDocumentFormatButton";
            this.changeDocumentFormatButton.Size = new System.Drawing.Size(23, 22);
            this.changeDocumentFormatButton.Text = "Сменить формат документов";
            this.changeDocumentFormatButton.Click += new System.EventHandler(this.ChangeDocumentFormatButtonClickHandler);
            // 
            // CheckedDocumentsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 75);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CheckedDocumentsListForm";
            this.Text = "Выбранные документы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckedDocumentsListFormClosingHandler);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBox;
        private ToolStrip toolStrip1;
        private ToolStripButton changeDocumentFormatButton;
    }
}