namespace MyFootball
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.TableLayoutPanel();
            this.leftMenuPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.tableButton = new System.Windows.Forms.Button();
            this.teamsButton = new System.Windows.Forms.Button();
            this.CalendarButton = new System.Windows.Forms.Button();
            this.mainButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainMenu.SuspendLayout();
            this.leftMenuPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.MainMenu.ColumnCount = 2;
            this.MainMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.625F));
            this.MainMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.375F));
            this.MainMenu.Controls.Add(this.leftMenuPanel, 0, 0);
            this.MainMenu.Controls.Add(this.contentPanel, 1, 0);
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RowCount = 1;
            this.MainMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainMenu.Size = new System.Drawing.Size(800, 450);
            this.MainMenu.TabIndex = 0;
            // 
            // leftMenuPanel
            // 
            this.leftMenuPanel.ColumnCount = 1;
            this.leftMenuPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftMenuPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftMenuPanel.Controls.Add(this.buttonsPanel, 0, 1);
            this.leftMenuPanel.Controls.Add(this.label1, 0, 0);
            this.leftMenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftMenuPanel.Location = new System.Drawing.Point(5, 5);
            this.leftMenuPanel.Name = "leftMenuPanel";
            this.leftMenuPanel.RowCount = 2;
            this.leftMenuPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.38739F));
            this.leftMenuPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.61261F));
            this.leftMenuPanel.Size = new System.Drawing.Size(157, 440);
            this.leftMenuPanel.TabIndex = 0;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.tableButton);
            this.buttonsPanel.Controls.Add(this.teamsButton);
            this.buttonsPanel.Controls.Add(this.CalendarButton);
            this.buttonsPanel.Controls.Add(this.mainButton);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsPanel.Location = new System.Drawing.Point(3, 57);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(151, 380);
            this.buttonsPanel.TabIndex = 0;
            // 
            // tableButton
            // 
            this.tableButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tableButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tableButton.Location = new System.Drawing.Point(0, 141);
            this.tableButton.Name = "tableButton";
            this.tableButton.Size = new System.Drawing.Size(151, 47);
            this.tableButton.TabIndex = 3;
            this.tableButton.Text = "Таблица";
            this.tableButton.UseVisualStyleBackColor = true;
            // 
            // teamsButton
            // 
            this.teamsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.teamsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.teamsButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.teamsButton.Location = new System.Drawing.Point(0, 94);
            this.teamsButton.Name = "teamsButton";
            this.teamsButton.Size = new System.Drawing.Size(151, 47);
            this.teamsButton.TabIndex = 2;
            this.teamsButton.Text = "Команды";
            this.teamsButton.UseVisualStyleBackColor = true;
            // 
            // CalendarButton
            // 
            this.CalendarButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CalendarButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CalendarButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CalendarButton.Location = new System.Drawing.Point(0, 47);
            this.CalendarButton.Name = "CalendarButton";
            this.CalendarButton.Size = new System.Drawing.Size(151, 47);
            this.CalendarButton.TabIndex = 1;
            this.CalendarButton.Text = "Календарь";
            this.CalendarButton.UseVisualStyleBackColor = true;
            // 
            // mainButton
            // 
            this.mainButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.mainButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mainButton.Location = new System.Drawing.Point(0, 0);
            this.mainButton.Name = "mainButton";
            this.mainButton.Size = new System.Drawing.Size(151, 47);
            this.mainButton.TabIndex = 0;
            this.mainButton.Text = "Главная";
            this.mainButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "РПЛ 22/23";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentPanel
            // 
            this.contentPanel.ColumnCount = 1;
            this.contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(170, 5);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.RowCount = 2;
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.306306F));
            this.contentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.6937F));
            this.contentPanel.Size = new System.Drawing.Size(625, 440);
            this.contentPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainMenu);
            this.Name = "Form1";
            this.Text = "MyFootball";
            this.MainMenu.ResumeLayout(false);
            this.leftMenuPanel.ResumeLayout(false);
            this.leftMenuPanel.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel MainMenu;
        private TableLayoutPanel leftMenuPanel;
        private Panel buttonsPanel;
        private Button mainButton;
        private Button tableButton;
        private Button teamsButton;
        private Button CalendarButton;
        private TableLayoutPanel contentPanel;
        private Label label1;
    }
}