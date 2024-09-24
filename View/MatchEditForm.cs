using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyFootball.View
{
    public class MatchEditForm : Form
    {
        private FillTablePanel mainTable;
        private FillTablePanel headTable;
        private FillTablePanel bodyTable;
        private FillTablePanel controllersTable;
        private MaskedTextBox homeScoreBox;
        private MaskedTextBox awayScoreBox;
        private MaskedTextBox dateBox;

        private FillButton saveButton;
        private ComboBox possibleDatesBox;

        private MatchViewModel Match;

        public MatchEditForm(MatchViewModel match, MatchesDGV matches)
        {
            Match = match;
            Initialize();
            homeScoreBox.Click += (e, a) => homeScoreBox.SelectionStart = homeScoreBox.Text.Length;
            awayScoreBox.Click += (e, a) => awayScoreBox.SelectionStart = awayScoreBox.Text.Length;

            var possibleDates = new List<DateTime>();
            if (!Match.IsFinished)
            {
                possibleDates = Match.TakePossibleTransferDates().ToList();
                possibleDatesBox.Items.Add(Match.DateTime);
                foreach (var item in possibleDates.Where(d => d > Match.DateTime).Take(10))
                    possibleDatesBox.Items.Add(item);
                possibleDatesBox.SelectedIndex = 0;

                possibleDatesBox.LostFocus += (e, a) =>//валидация даты здесь и сейчас
                {
                    if (DateTime.TryParse(possibleDatesBox.Text, out var date))//валидация в случае введенного или выбранного
                    {
                        if (Match.DateTime.Equals((DateTime)possibleDatesBox.SelectedItem)) return;
                        if (possibleDates.Select(d => d.Date).Contains(date.Date))
                        {
                            Match.DateTime = date;
                            matches.Update();
                        }
                        else
                        {
                            MessageBox.Show("Дата занята");
                            possibleDatesBox.SelectedIndex = 0;
                        }
                    }

                    else if (possibleDatesBox.SelectedItem!=null)//в случае, если только выбранная дата
                    {
                        if (Match.DateTime.Equals((DateTime)possibleDatesBox.SelectedItem)) return;
                        Match.DateTime = (DateTime)possibleDatesBox.SelectedItem;
                        matches.Update();
                    }
                    
                    else
                    {
                        MessageBox.Show("Дата введена некоректно");
                        possibleDatesBox.SelectedIndex = 0;
                    }
                };
            }

            saveButton.Click += (sender, e) =>
                {
                    if (!Validate()) MessageBox.Show("Некорректный ввод результата");
                    if (homeScoreBox.Text.Length > 0 && awayScoreBox.Text.Length > 0)
                    {
                        Match.AssignResult(int.Parse(homeScoreBox.Text), int.Parse(awayScoreBox.Text));
                        matches.Update();
                        Close();
                    }
                };
        }

        public bool Validate()
        {
            return !(string.IsNullOrEmpty(homeScoreBox.Text) ^ string.IsNullOrEmpty(awayScoreBox.Text));
        }//либо оба пусты, либо оба заполнены

        //если матч сыгран нельзя перенести его дату, только 
        private void Initialize()
        {
            Size = new Size(400, 300);

            mainTable = new FillTablePanel(1, 3);
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 80));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            homeScoreBox = new MaskedTextBox() { Mask = "00", PromptChar = ' ', Text = Match.HomeTeamScore.ToString(), Dock = DockStyle.Fill};
            awayScoreBox = new MaskedTextBox() { Mask = "00", PromptChar = ' ', Text = Match.AwayTeamScore.ToString(), Dock = DockStyle.Fill, Anchor = AnchorStyles.Top | AnchorStyles.Bottom };
            dateBox = new MaskedTextBox() { Mask = "00/00/0000 90:00", PromptChar = '_' };

            headTable = new FillTablePanel(4, 1);
            var sizes = new Single[] { 40F, 10F, 10F, 40F };
            foreach (var size in sizes)
                headTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, size));
            headTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            headTable.Controls.Add(new FillHeaderLabel(Match.HomeTeam.Name), 0, 0);
            headTable.Controls.Add(homeScoreBox, 1, 0);
            headTable.Controls.Add(awayScoreBox, 2, 0);
            headTable.Controls.Add(new FillHeaderLabel(Match.AwayTeam.Name), 3, 0);

            bodyTable = new FillTablePanel(2, 4);
            var columnSize = 50F;
            var rowSize = 25F;
            for (int i = 0; i < bodyTable.ColumnCount; i++)
                bodyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, columnSize));
            for (int i = 0; i < bodyTable.RowCount; i++)
                bodyTable.RowStyles.Add(new RowStyle(SizeType.Percent, rowSize));
            bodyTable.Controls.Add(new FillLabel("Статус"), 0, 0);
            bodyTable.Controls.Add(new FillLabel("Стадион"), 0, 1);
            bodyTable.Controls.Add(new FillLabel("Вместимость"), 0, 2);
            bodyTable.Controls.Add(new FillLabel("Стоимость билетов"), 0, 3);

            bodyTable.Controls.Add(new FillLabel(Match.IsFinished ? "Завершен" : "Не сыгран"), 1, 0);
            bodyTable.Controls.Add(new FillLabel(Match.Stadium.Name), 1, 1);
            bodyTable.Controls.Add(new FillLabel(Match.Stadium.Capacity.ToString()), 1, 2);
            bodyTable.Controls.Add(new FillLabel(Match.TicketCoast.ToString()), 1, 3);

            saveButton = new FillButton("Сохранить");

            possibleDatesBox = new ComboBox() { Text = "Перенести на" };

            controllersTable = new FillTablePanel(2, 1);
            controllersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            controllersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            controllersTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            controllersTable.Controls.Add(saveButton, 1, 0);

            if (!Match.IsFinished)
                controllersTable.Controls.Add(possibleDatesBox, 0, 0);

            mainTable.Controls.Add(headTable, 0, 0);
            mainTable.Controls.Add(bodyTable, 0, 1);
            mainTable.Controls.Add(controllersTable, 0, 2);

            Controls.Add(mainTable);
        }
    }
}
