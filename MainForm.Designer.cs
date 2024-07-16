namespace SecondVersion
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewForResults = new System.Windows.Forms.DataGridView();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AbsoluteFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelativeFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelName = new System.Windows.Forms.Label();
            this.labelForNumber = new System.Windows.Forms.Label();
            this.buttonCount = new System.Windows.Forms.Button();
            this.richTextBoxForUserInput = new System.Windows.Forms.RichTextBox();
            this.menuStripOptions = new System.Windows.Forms.MenuStrip();
            this.toolStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSaveResults = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripInformation = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForResults)).BeginInit();
            this.menuStripOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // ResultsToolStripMenuItem
            // 
            this.ResultsToolStripMenuItem.Name = "ResultsToolStripMenuItem";
            this.ResultsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // InformationToolStripMenuItem
            // 
            this.InformationToolStripMenuItem.Name = "InformationToolStripMenuItem";
            this.InformationToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.InformationToolStripMenuItem.Text = "Справка";
            this.InformationToolStripMenuItem.Click += new System.EventHandler(this.InformationToolStripMenuItem_Click);
            // 
            // dataGridViewForResults
            // 
            this.dataGridViewForResults.AllowUserToAddRows = false;
            this.dataGridViewForResults.AllowUserToDeleteRows = false;
            this.dataGridViewForResults.AllowUserToResizeColumns = false;
            this.dataGridViewForResults.AllowUserToResizeRows = false;
            this.dataGridViewForResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewForResults.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewForResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewForResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Symbol,
            this.AbsoluteFrequency,
            this.RelativeFrequency});
            this.dataGridViewForResults.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewForResults.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewForResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewForResults.Location = new System.Drawing.Point(579, 70);
            this.dataGridViewForResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewForResults.Name = "dataGridViewForResults";
            this.dataGridViewForResults.RowHeadersVisible = false;
            this.dataGridViewForResults.RowHeadersWidth = 51;
            this.dataGridViewForResults.RowTemplate.Height = 24;
            this.dataGridViewForResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewForResults.Size = new System.Drawing.Size(492, 458);
            this.dataGridViewForResults.TabIndex = 12;
            // 
            // Symbol
            // 
            this.Symbol.HeaderText = "Символ";
            this.Symbol.MinimumWidth = 6;
            this.Symbol.Name = "Symbol";
            // 
            // AbsoluteFrequency
            // 
            this.AbsoluteFrequency.HeaderText = "Абсолютная частота встречаемости";
            this.AbsoluteFrequency.MinimumWidth = 6;
            this.AbsoluteFrequency.Name = "AbsoluteFrequency";
            // 
            // RelativeFrequency
            // 
            this.RelativeFrequency.HeaderText = "Относительная частота встречаемости";
            this.RelativeFrequency.MinimumWidth = 6;
            this.RelativeFrequency.Name = "RelativeFrequency";
            this.RelativeFrequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(671, 41);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(220, 16);
            this.labelName.TabIndex = 13;
            this.labelName.Text = "Общее число символов в тексте:";
            // 
            // labelForNumber
            // 
            this.labelForNumber.AutoSize = true;
            this.labelForNumber.Location = new System.Drawing.Point(908, 41);
            this.labelForNumber.Name = "labelForNumber";
            this.labelForNumber.Size = new System.Drawing.Size(103, 16);
            this.labelForNumber.TabIndex = 14;
            this.labelForNumber.Text = "не рассчитано";
            // 
            // buttonCount
            // 
            this.buttonCount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonCount.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCount.Location = new System.Drawing.Point(427, 532);
            this.buttonCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCount.Name = "buttonCount";
            this.buttonCount.Size = new System.Drawing.Size(269, 31);
            this.buttonCount.TabIndex = 18;
            this.buttonCount.Text = "Рассчитать";
            this.buttonCount.UseVisualStyleBackColor = false;
            this.buttonCount.Click += new System.EventHandler(this.buttonCount_Click);
            // 
            // richTextBoxForUserInput
            // 
            this.richTextBoxForUserInput.AcceptsTab = true;
            this.richTextBoxForUserInput.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxForUserInput.Location = new System.Drawing.Point(12, 38);
            this.richTextBoxForUserInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxForUserInput.Name = "richTextBoxForUserInput";
            this.richTextBoxForUserInput.Size = new System.Drawing.Size(561, 490);
            this.richTextBoxForUserInput.TabIndex = 19;
            this.richTextBoxForUserInput.Text = "";
            this.richTextBoxForUserInput.TextChanged += new System.EventHandler(this.richTextBoxForUserInput_TextChanged);
            // 
            // menuStripOptions
            // 
            this.menuStripOptions.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStripOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFile,
            this.toolStripSaveResults,
            this.toolStripInformation});
            this.menuStripOptions.Location = new System.Drawing.Point(0, 0);
            this.menuStripOptions.Name = "menuStripOptions";
            this.menuStripOptions.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStripOptions.Size = new System.Drawing.Size(1083, 28);
            this.menuStripOptions.TabIndex = 20;
            this.menuStripOptions.Text = "menuStripOptions";
            // 
            // toolStripFile
            // 
            this.toolStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpen,
            this.toolStripSave});
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.Size = new System.Drawing.Size(59, 24);
            this.toolStripFile.Text = "Файл";
            // 
            // toolStripOpen
            // 
            this.toolStripOpen.Name = "toolStripOpen";
            this.toolStripOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripOpen.Size = new System.Drawing.Size(216, 26);
            this.toolStripOpen.Text = "Открыть";
            this.toolStripOpen.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripSave
            // 
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripSave.Size = new System.Drawing.Size(216, 26);
            this.toolStripSave.Text = "Сохранить";
            this.toolStripSave.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripSaveResults
            // 
            this.toolStripSaveResults.Enabled = false;
            this.toolStripSaveResults.Name = "toolStripSaveResults";
            this.toolStripSaveResults.Size = new System.Drawing.Size(179, 24);
            this.toolStripSaveResults.Text = "Сохранить результаты";
            this.toolStripSaveResults.Click += new System.EventHandler(this.ResultsToolStripMenuItem_Click);
            // 
            // toolStripInformation
            // 
            this.toolStripInformation.Name = "toolStripInformation";
            this.toolStripInformation.Size = new System.Drawing.Size(81, 24);
            this.toolStripInformation.Text = "Справка";
            this.toolStripInformation.Click += new System.EventHandler(this.InformationToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 574);
            this.Controls.Add(this.menuStripOptions);
            this.Controls.Add(this.richTextBoxForUserInput);
            this.Controls.Add(this.buttonCount);
            this.Controls.Add(this.labelForNumber);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.dataGridViewForResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Символьный анализ текста";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForResults)).EndInit();
            this.menuStripOptions.ResumeLayout(false);
            this.menuStripOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem InformationToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewForResults;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelForNumber;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.Button buttonCount;
        private System.Windows.Forms.ToolStripMenuItem ResultsToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxForUserInput;
        private System.Windows.Forms.MenuStrip menuStripOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveResults;
        private System.Windows.Forms.ToolStripMenuItem toolStripInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AbsoluteFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelativeFrequency;
    }
}

