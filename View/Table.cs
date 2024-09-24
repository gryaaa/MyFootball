using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootball.View
{
    public class TeamsTableDGV : DefaultDGW
    {
        private DataGridViewTextBoxColumn teamColumn;
        private DataGridViewTextBoxColumn countOfMatches;
        private DataGridViewTextBoxColumn wonCountColumn;
        private DataGridViewTextBoxColumn drawCountColumn;
        private DataGridViewTextBoxColumn loseCountColumn;
        private DataGridViewTextBoxColumn PointsColumnt;

        public TeamsTableDGV(List<Team> teams)
        {
            Dock = DockStyle.Fill;

            teamColumn = new DataGridViewTextBoxColumn() { HeaderText = "Команда", FillWeight = 100 };
            countOfMatches = new DataGridViewTextBoxColumn() { HeaderText = "И", FillWeight = 30 };
            wonCountColumn = new DataGridViewTextBoxColumn() { HeaderText = "В", FillWeight = 30 };
            drawCountColumn = new DataGridViewTextBoxColumn() { HeaderText = "Н", FillWeight = 30 };
            loseCountColumn = new DataGridViewTextBoxColumn() { HeaderText = "П", FillWeight = 30 };
            PointsColumnt = new DataGridViewTextBoxColumn() { HeaderText = "Очки", FillWeight = 60 };

            Columns.AddRange(new DataGridViewColumn[] {
            teamColumn,
            countOfMatches,
            wonCountColumn,
            drawCountColumn,
            loseCountColumn,
            PointsColumnt});

            foreach (var team in teams)
                Rows.Add(team.Name, team.WinCount+team.LoseCount+team.DrawCount, team.WinCount, team.DrawCount, team.LoseCount, team.WinCount*3+team.DrawCount);
            Sort(PointsColumnt, System.ComponentModel.ListSortDirection.Descending);
        }
    }
}
