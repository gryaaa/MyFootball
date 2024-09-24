using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFootball.View
{
    public class PlayerForm : Form
    {
        private FillTablePanel mainPanel;
        private float rowHeight = 20F;
        private TableLayoutPanel tableLayoutPanel1;
        private Label nameLabel;
        private MaskedTextBox lastnameBox;
        private MaskedTextBox numberBox;
        private MaskedTextBox ageBox;
        private Label lastNameLabel;
        private Label ageLabel;
        private Label numberLabel;
        private Label positionLabel;
        private MaskedTextBox nameBox;
        private ComboBox positionComboBox;
        private Button button1;
        private System.ComponentModel.IContainer components;
        private float columnWeight = 50F;

        public bool Validate()
        {
            return !(string.IsNullOrEmpty(nameBox.Text)
                || string.IsNullOrEmpty(lastnameBox.Text)
                || string.IsNullOrEmpty(ageBox.Text)
                || string.IsNullOrEmpty(numberBox.Text));
        }

        public PlayerForm()
        {
            InitializeComponent();

            nameBox.Click += (e, a) => nameBox.SelectionStart = nameBox.Text.Length;
            lastnameBox.Click += (e, a) => lastnameBox.SelectionStart = lastnameBox.Text.Length;
            ageBox.Click += (e, a) => ageBox.SelectionStart = ageBox.Text.Length;
            numberBox.Click += (e, a) => numberBox.SelectionStart = numberBox.Text.Length;

            foreach (var item in Enum.GetValues(typeof(Position)))//немного рефлексии
                positionComboBox.Items.Add(item);
        }

        public PlayerForm(TeamViewModel team, PlayersDGV data)//для добавления нового игрока
            :this()
        {
            button1.Click += (e, a) =>
            {
                if (!Validate())
                {
                    MessageBox.Show("Введены не все параметры");
                    return;
                }
                var player = new Player();
                player.Name = nameBox.Text;
                player.Surname = lastnameBox.Text;
                player.Number = int.Parse(numberBox.Text);
                player.Position = (Position)positionComboBox.SelectedItem;
                player.Age = int.Parse(ageBox.Text);

                team.AddPlayer(player);
                data.AddRow(player);
                Close();
            };
        }

        public PlayerForm(Player player, PlayersDGV data)//для изменения существующего игрока
            :this()
        {
            nameBox.Text = player.Name;
            lastnameBox.Text = player.Surname;
            numberBox.Text = player.Number.ToString();
            positionComboBox.SelectedIndex = (int)player.Position;
            ageBox.Text = player.Age.ToString();

            button1.Click += (e, a) => 
            {
                if (!Validate())
                {
                    MessageBox.Show("Введены не все параметры");
                    return;
                }
                player.Name = nameBox.Text;
                player.Surname= lastnameBox.Text;
                player.Number = int.Parse(numberBox.Text);
                player.Position = (Position)positionComboBox.SelectedItem;
                player.Age= int.Parse(ageBox.Text);
                
                PlayerRepository.Update(player);
                data.EditCurrentRow(player);
                Close();
            };

        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lastnameBox = new System.Windows.Forms.MaskedTextBox();
            this.numberBox = new System.Windows.Forms.MaskedTextBox();
            this.ageBox = new System.Windows.Forms.MaskedTextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.MaskedTextBox();
            this.positionComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.69231F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.30769F));
            this.tableLayoutPanel1.Controls.Add(this.lastnameBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numberBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ageBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lastNameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ageLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.numberLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.positionLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.nameBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.positionComboBox, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 198);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lastnameBox
            // 
            this.lastnameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastnameBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastnameBox.Location = new System.Drawing.Point(124, 42);
            this.lastnameBox.Mask = "LLLLLLLLLLLLLLLLLLLLLLLLLLL";
            this.lastnameBox.Name = "lastnameBox";
            this.lastnameBox.PromptChar = ' ';
            this.lastnameBox.Size = new System.Drawing.Size(157, 27);
            this.lastnameBox.TabIndex = 10;
            // 
            // numberBox
            // 
            this.numberBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numberBox.Location = new System.Drawing.Point(124, 120);
            this.numberBox.Mask = "00";
            this.numberBox.Name = "numberBox";
            this.numberBox.PromptChar = ' ';
            this.numberBox.Size = new System.Drawing.Size(157, 27);
            this.numberBox.TabIndex = 8;
            // 
            // ageBox
            // 
            this.ageBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ageBox.Location = new System.Drawing.Point(124, 81);
            this.ageBox.Mask = "000";
            this.ageBox.Name = "ageBox";
            this.ageBox.PromptChar = ' ';
            this.ageBox.Size = new System.Drawing.Size(157, 27);
            this.ageBox.TabIndex = 7;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameLabel.Location = new System.Drawing.Point(3, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(115, 39);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Имя";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastNameLabel.Location = new System.Drawing.Point(3, 39);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(115, 39);
            this.lastNameLabel.TabIndex = 1;
            this.lastNameLabel.Text = "Фамилия";
            this.lastNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ageLabel.Location = new System.Drawing.Point(3, 78);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(115, 39);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "Возраст";
            this.ageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberLabel.Location = new System.Drawing.Point(3, 117);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(115, 39);
            this.numberLabel.TabIndex = 3;
            this.numberLabel.Text = "Номер";
            this.numberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionLabel.Location = new System.Drawing.Point(3, 156);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(115, 42);
            this.positionLabel.TabIndex = 4;
            this.positionLabel.Text = "Позиция";
            this.positionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameBox.Location = new System.Drawing.Point(124, 3);
            this.nameBox.Mask = "LLLLLLLLLLLLLLLLLLLLLLLLLLL";
            this.nameBox.Name = "nameBox";
            this.nameBox.PromptChar = ' ';
            this.nameBox.Size = new System.Drawing.Size(157, 27);
            this.nameBox.TabIndex = 5;
            // 
            // positionComboBox
            // 
            this.positionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.positionComboBox.FormattingEnabled = true;
            this.positionComboBox.Location = new System.Drawing.Point(124, 159);
            this.positionComboBox.Name = "positionComboBox";
            this.positionComboBox.Size = new System.Drawing.Size(157, 23);
            this.positionComboBox.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PlayerForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlayerForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
