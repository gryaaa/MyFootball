using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootball.View
{
    public class MainSeasonSection : FillTablePanel
    {
        private FillTablePanel seasonDescriptionPanel;
        private FillHeaderLabel currentDate;
        private FillButton nextDateButton;
        private MatchesDGV matchesDGV;

        public MainSeasonSection()
        {
            ColumnCount = 2;
            RowCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            seasonDescriptionPanel = new FillTablePanel(2, 2);
            seasonDescriptionPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            seasonDescriptionPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            seasonDescriptionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            seasonDescriptionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            nextDateButton = new FillButton("Перейти к следующему");
            seasonDescriptionPanel.Controls.Add(new FillHeaderLabel("Игровой день"), 0, 0);//заменить на вывод сегодняшнего дня

            currentDate = new FillHeaderLabel();
            seasonDescriptionPanel.Controls.Add(currentDate, 1, 0);
            seasonDescriptionPanel.Controls.Add(nextDateButton, 1, 1);

            UpdateMatches();

            Controls.Add(seasonDescriptionPanel, 0, 0);
            Controls.Add(matchesDGV, 0, 1);

            nextDateButton.Click += (e, a) =>
            {
                var matches = MatchRepository.GetMatches();
                var season = SeasonRepository.FindSeasonById(1);
                var gameDay = matches.Where(m => m.DateTime.Date == season.currentDate.Date);
                if (gameDay.Where(m => !m.IsFinished).Count() > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "В данном игровом дне остались матчи без заданного результата. Все равно перейти к следующему игровому дню?",
                        "Сообщение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.No)//перехода на следующий игровой день не произойдет только в этом случае
                        return;
                }
                season.currentDate = matches.OrderBy(m => m.DateTime).First(m => m.DateTime.Date > season.currentDate.Date).DateTime.Date;
                SeasonRepository.Update(season);
                matchesDGV.matches = matches.Where(m => m.DateTime.Date == season.currentDate.Date).Select(m => new MatchViewModel(m)).ToList();
                matchesDGV.Update();
                currentDate.Text = season.currentDate.ToString("d");
            };
        }

        public void UpdateMatches()
        {
            var date = SeasonRepository.FindSeasonById(1).currentDate.Date;
            var matches = MatchRepository.GetMatches().Where(m => m.DateTime.Date == date.Date).Select(m => new MatchViewModel(m)).ToList();
            matchesDGV = new MatchesDGV(matches);
            currentDate.Text = date.ToString("d");
        }
    }
}
