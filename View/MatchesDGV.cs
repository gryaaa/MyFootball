using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MyFootball.View
{
    public class MatchesDGV : DefaultDGW
    {
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn dateColumn;
        private DataGridViewTextBoxColumn homeTeamColumn;
        private DataGridViewTextBoxColumn homeTeamScoreColumn;
        private DataGridViewTextBoxColumn awayTeamScoreColumn;
        private DataGridViewTextBoxColumn awayTeamColumn;
        private DataGridViewButtonColumn detailsButtonColumn;
        public List<MatchViewModel> matches;

        public MatchesDGV(List<MatchViewModel> matches)
        {
            this.matches = matches;
            idColumn = new DataGridViewTextBoxColumn() { Visible = false };
            dateColumn = new DataGridViewTextBoxColumn() { HeaderText = "Дата", FillWeight = 60 };
            homeTeamColumn = new DataGridViewTextBoxColumn() { HeaderText = "Хозяева", FillWeight = 80, SortMode = DataGridViewColumnSortMode.NotSortable };
            homeTeamScoreColumn = new DataGridViewTextBoxColumn() { FillWeight = 10, SortMode = DataGridViewColumnSortMode.NotSortable };
            awayTeamScoreColumn = new DataGridViewTextBoxColumn() { FillWeight = 10, SortMode = DataGridViewColumnSortMode.NotSortable };
            awayTeamColumn = new DataGridViewTextBoxColumn() { HeaderText = "Гости", FillWeight = 80, SortMode = DataGridViewColumnSortMode.NotSortable };
            detailsButtonColumn = new DataGridViewButtonColumn() { FillWeight = 40 };

            Columns.AddRange(new DataGridViewColumn[] {
            idColumn,
            dateColumn,
            homeTeamColumn,
            homeTeamScoreColumn,
            awayTeamScoreColumn,
            awayTeamColumn,
            detailsButtonColumn});

            foreach (var match in matches)
            {
                Rows.Add(match.Id, match.DateTime, match.HomeTeam.Name, match.HomeTeamScore, match.AwayTeamScore, match.AwayTeam.Name, "Подробнее");
            }

            CellContentClick += (sender, e) =>
            {
                if (e.ColumnIndex == 6)
                {
                    new MatchEditForm(matches.Single(m => m.Id == (int)Rows[e.RowIndex].Cells[0].Value), this).Show();
                }
            };
        }

        public void Update()
        {
            if (SortOrder != SortOrder.None)
                Sort(SortedColumn, SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            var index = 0;
            if (CurrentCell != null) index = CurrentCell.RowIndex;
            Rows.Clear();
            foreach (var match in matches)
            {
                Rows.Add(match.Id, match.DateTime, match.HomeTeam.Name, match.HomeTeamScore, match.AwayTeamScore, match.AwayTeam.Name, "Подробнее");
            }
            if (SortOrder != SortOrder.None)
                Sort(SortedColumn, SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            if (index != 0)
                CurrentCell = this[1, index];
        }
    }
}
