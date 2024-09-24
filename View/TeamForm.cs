using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootball.View
{
    public class TeamForm:Form//добавить кнопку добавления игрока(которая будет вызывать простую форму в нее будет передаваться teamview, она будет изменять состав команды и в нем будет вызываться событие изменения, на которое мы предварительно подпишем в окне формы updatePlayer) сюда бл
    {
        private TeamViewModel TeamVM;
        private FillTablePanel mainPanel;

        private FillTablePanel upperNestedPanel;
        private FillTablePanel teamDescriptionPanel;
            private FillHeaderLabel NameLabel;
            private FillLabel CityLabel;
            private FillLabel CoachLabel;
            private FillLabel StadiumLabel;
            private FillLabel PlaceInLastSeasonLabel;

        private TabControl teamContent;
            private TabPage playersPage;
            private PlayersDGV playersDGV;
        private FillLabel editLabel;
        private Button addPlayerButton;
        private Button editPlayerButton;
        private Button removePlayerButton;
        

            private TabPage matchesPage;
            private MatchesDGV matchesDGV;


        public TeamForm(TeamViewModel team) 
        {
            Size = new Size(600, 400);
            TeamVM = team;

            mainPanel = new FillTablePanel(1, 2);//основа
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            upperNestedPanel = new FillTablePanel(2, 1);//делает отступ для верхней панели для фотографии(возможно будет )
            upperNestedPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            upperNestedPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            upperNestedPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            teamDescriptionPanel = new FillTablePanel(2, 5);
            var rowSizes = new float[] { 24F, 19F, 19F, 19F, 19F };
            foreach (var size in rowSizes)
                teamDescriptionPanel.RowStyles.Add(new RowStyle(SizeType.Percent, size));
            var columnSizes = new float[] { 40F, 60F };
            foreach (var size in columnSizes)
                teamDescriptionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, size));


            teamContent = new TabControl() { SelectedIndex = 0, Dock = DockStyle.Fill};
            

            playersPage = new TabPage() { TabIndex = 0, Text = "Состав команды" };
            var e = new FillTablePanel(2, 1);
            e.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            e.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            e.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            playersDGV = new PlayersDGV(team.Players);
            editLabel = new FillLabel();
            addPlayerButton = new Button() { Dock = DockStyle.Top, Text = "Добавить" };
            editPlayerButton = new Button() { Dock = DockStyle.Top, Text = "Изменить" };
            removePlayerButton = new Button() { Dock = DockStyle.Top, Text = "Удалить" };
            editLabel.Controls.Add(addPlayerButton);
            editLabel.Controls.Add(editPlayerButton);
            editLabel.Controls.Add(removePlayerButton);
            e.Controls.Add(editLabel);
            e.Controls.Add(playersDGV);
            playersPage.Controls.Add(e);

            matchesPage = new TabPage() { TabIndex = 1, Text = "Матчи" };
            matchesDGV = new MatchesDGV(team.Matches);
            matchesPage.Controls.Add(matchesDGV);

            teamContent.Controls.Add(playersPage);
            teamContent.Controls.Add(matchesPage);

            teamDescriptionPanel.Controls.Add(new FillLabel("Название"), 0,0);
            teamDescriptionPanel.Controls.Add(new FillLabel("Город"),0, 1);
            teamDescriptionPanel.Controls.Add(new FillLabel("Тренер"), 0, 2);
            teamDescriptionPanel.Controls.Add(new FillLabel("Стадион"), 0, 3);
            teamDescriptionPanel.Controls.Add(new FillLabel("Место в прошлом сезоне"), 0, 4);

            NameLabel = new FillHeaderLabel();
            CityLabel = new FillLabel();
            CoachLabel = new FillLabel();
            StadiumLabel = new FillLabel();
            PlaceInLastSeasonLabel = new FillLabel();


            teamDescriptionPanel.Controls.Add(new FillHeaderLabel($"{team.Name}"), 1, 0);
            teamDescriptionPanel.Controls.Add(new FillLabel($"{team.City}"), 1, 1);
            teamDescriptionPanel.Controls.Add(new FillLabel($"{team.HeadCoach.Name} {team.HeadCoach.Surname}"), 1, 2);
            teamDescriptionPanel.Controls.Add(new FillLabel($"{team.Stadium.Name}"), 1, 3);
            teamDescriptionPanel.Controls.Add(new FillLabel($"{team.LastSeasonPlace}"), 1, 4);

            mainPanel.Controls.Add(teamDescriptionPanel, 0, 0);
            mainPanel.Controls.Add(teamContent, 0, 1);

            Controls.Add(mainPanel);

            //логика

            addPlayerButton.Click += (s, e)=>new PlayerForm(TeamVM, playersDGV).Show();
            editPlayerButton.Click += (s, e) =>
            {
                if (playersDGV.CurrentRow != null)
                    new PlayerForm(TeamVM.Players.Single(p => p.Id == (int)playersDGV.CurrentRow.Cells[0].Value), playersDGV).Show();
            };
            removePlayerButton.Click += (s, e) =>
            {
                if (playersDGV.CurrentRow == null || TeamVM.Players.Count==0) return;
                TeamVM.RemovePlayer(TeamVM.Players.Single(p => p.Id == (int)playersDGV.CurrentRow.Cells[0].Value));
                playersDGV.DeleteCurrentRow();
            };
        }
    }
}
