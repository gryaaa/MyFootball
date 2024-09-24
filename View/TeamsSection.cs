using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootball.View
{
    public class TeamsSection:Panel
    {
        public TeamsSection()
        {
            AutoScroll= true;
            Dock = DockStyle.Fill;
            var teams = TeamRepository.GetTeams();
            SuspendLayout();
            foreach (var team in teams)
            {
                var teamItem = new TeamItem();
                teamItem.Text = team.Name;
                teamItem.Click += (e, a)=> new TeamForm(new TeamViewModel(team)).Show();
                Controls.Add(teamItem);
            }
            ResumeLayout();
        }
    }

    public class TeamItem:Button
    {
        public TeamItem()
        {
            Height = 35;
            Dock = DockStyle.Top;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FlatStyle = FlatStyle.Flat;
        }
    }

}
