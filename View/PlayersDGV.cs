using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootball.View
{
    public class PlayersDGV:DefaultDGW
    {
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn numberColumn;
        private DataGridViewTextBoxColumn nameColumn;
        private DataGridViewTextBoxColumn lastNameColumn;
        private DataGridViewTextBoxColumn PositionColumn;
        private DataGridViewTextBoxColumn AgeColumn;

        public PlayersDGV(List<Player> players)
        {
            Dock= DockStyle.Fill;

            idColumn = new DataGridViewTextBoxColumn() { Visible = false };
            numberColumn = new DataGridViewTextBoxColumn() { HeaderText = "№", FillWeight = 60 };
            nameColumn= new DataGridViewTextBoxColumn() { HeaderText = "Имя", FillWeight = 100 };
            lastNameColumn = new DataGridViewTextBoxColumn() { HeaderText = "Фамилия", FillWeight = 100 };   
            PositionColumn= new DataGridViewTextBoxColumn() { HeaderText = "Позиция", FillWeight = 100 };
            AgeColumn = new DataGridViewTextBoxColumn() { HeaderText = "Возраст", FillWeight = 60 };

            Columns.AddRange(new DataGridViewColumn[] {
            idColumn,
            numberColumn,
            nameColumn,
            lastNameColumn,
            PositionColumn,
            AgeColumn});

            foreach (var player in players)
                Rows.Add(player.Id, player.Number, player.Name, player.Surname, player.Position, player.Age);
        }

        public void AddRow(Player player)
        {
            Rows.Add(player.Id, player.Number, player.Name, player.Surname, player.Position, player.Age);
            if (SortOrder != SortOrder.None)
                Sort(SortedColumn, SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
        }

        public void EditCurrentRow(Player player)
        {
            CurrentRow.Cells[0].Value = player.Id;
            CurrentRow.Cells[1].Value = player.Number;
            CurrentRow.Cells[2].Value = player.Name;
            CurrentRow.Cells[3].Value = player.Surname;
            CurrentRow.Cells[4].Value = player.Position;
            CurrentRow.Cells[5].Value = player.Age;
            if (SortOrder != SortOrder.None)
                Sort(SortedColumn, SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
        }

        public void DeleteCurrentRow()
        {
            Rows.RemoveAt(CurrentRow.Index);
        }
    }
}
