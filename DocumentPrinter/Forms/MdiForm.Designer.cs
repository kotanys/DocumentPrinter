namespace DocumentPrinter.Forms
{
    partial class MdiForm
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
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            printButton = new ToolStripMenuItem();
            clearSelectionButton = new ToolStripMenuItem();
            windowsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            OpenDocumentFolderButton = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, windowsToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(434, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { printButton, clearSelectionButton, OpenDocumentFolderButton });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // printButton
            // 
            printButton.Name = "printButton";
            printButton.Size = new Size(224, 22);
            printButton.Text = "Печать";
            printButton.Click += PrintButtonClickHandler;
            // 
            // clearSelectionButton
            // 
            clearSelectionButton.Name = "clearSelectionButton";
            clearSelectionButton.Size = new Size(224, 22);
            clearSelectionButton.Text = "Очистить выбор";
            clearSelectionButton.Click += ClearSelectionButtonClickHandler;
            // 
            // windowsToolStripMenuItem
            // 
            windowsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            windowsToolStripMenuItem.Size = new Size(47, 20);
            windowsToolStripMenuItem.Text = "Окна";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(203, 22);
            toolStripMenuItem1.Text = "Выбранные документы";
            toolStripMenuItem1.Click += ChosenDocumentsButtonClickHandler;
            // 
            // OpenDocumentFolderButton
            // 
            OpenDocumentFolderButton.Name = "OpenDocumentFolderButton";
            OpenDocumentFolderButton.Size = new Size(224, 22);
            OpenDocumentFolderButton.Text = "Открыть папку документов";
            OpenDocumentFolderButton.Click += OnOpenDocumentsFolderButtonPressedHandler;
            // 
            // MdiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(434, 411);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            MaximumSize = new Size(700, 700);
            MinimumSize = new Size(300, 300);
            Name = "MdiForm";
            Text = "DocumentPrinter";
            FormClosing += OnFormClosingHandler;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem clearSelectionButton;
        private ToolStripMenuItem printButton;
        private ToolStripMenuItem windowsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem OpenDocumentFolderButton;
    }
}