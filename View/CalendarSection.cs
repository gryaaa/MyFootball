using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootball.View
{
    public class CalendarSection : FillTablePanel//сюда передаются все матчи
    {
        private FillTablePanel filterPanel;
        private ComboBox matchTypesBox;
        private DateTimePicker dateFrom;
        private DateTimePicker dateTill;
        private MatchesDGV matchesDGV;
        private FillButton showButton;


        public CalendarSection()
            : base(1, 2)
        {
            filterPanel = new FillTablePanel(3, 3);


            filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
            filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
            filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            filterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            filterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            filterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
            showButton = new FillButton("Показать");

            matchTypesBox = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
            matchTypesBox.Items.Add("Все");
            matchTypesBox.Items.Add("Завершеннные");
            matchTypesBox.Items.Add("Несыгранные");
            matchTypesBox.SelectedIndex = 0;

            var season = SeasonRepository.FindSeasonById(1);

            dateFrom = new DateTimePicker() { Value = season.startSeason };
            dateTill = new DateTimePicker() { Value = season.endSeason };

            RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            matchesDGV = new MatchesDGV(MatchRepository.GetMatches()
                .Where(m => dateFrom.Value < m.DateTime && m.DateTime < dateTill.Value)
                .Select(m => new MatchViewModel(m)).ToList());

            showButton.Click += (e, a) => Update();

            filterPanel.Controls.Add(new FillLabel("От") { TextAlign = ContentAlignment.MiddleLeft});
            filterPanel.Controls.Add(new FillLabel("До") { TextAlign = ContentAlignment.MiddleLeft });
            filterPanel.Controls.Add(new FillLabel("Матчи") { TextAlign = ContentAlignment.MiddleLeft });
            filterPanel.Controls.Add(dateFrom);
            filterPanel.Controls.Add(dateTill);
            filterPanel.Controls.Add(matchTypesBox);
            filterPanel.Controls.Add(showButton, 2, 2);
            Controls.Add(filterPanel, 0, 0);
            Controls.Add(matchesDGV, 0, 1);
        }

        private void Update()
        {
            matchesDGV.matches = MatchRepository.GetMatches().Where(m => dateFrom.Value < m.DateTime && m.DateTime < dateTill.Value).Select(m => new MatchViewModel(m)).ToList();
            if (matchTypesBox.SelectedIndex != 0)
            {
                if (matchTypesBox.SelectedIndex == 1)
                    matchesDGV.matches = matchesDGV.matches.Where(m => m.IsFinished).ToList();
                else matchesDGV.matches = matchesDGV.matches.Where(m => !m.IsFinished).ToList();
            }
            matchesDGV.Update();
        }
    }
}
