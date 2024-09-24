using MyFootball.View;

namespace MyFootball
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            contentPanel.Controls.Add(new MainSeasonSection(), 0, 1);

            mainButton.Click += (e, a) =>
            {
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add(new FillHeaderLabel("Главная"),0,0);
                contentPanel.Controls.Add(new MainSeasonSection(),0,1);

            };

            CalendarButton.Click += (e, a) =>
            {
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add(new FillHeaderLabel("Календарь"), 0, 0);
                contentPanel.Controls.Add(new CalendarSection(), 0, 1);

            };

            teamsButton.Click += (e, a) =>
            {   
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add(new FillHeaderLabel("Команды"), 0, 0);//вывод команд
                contentPanel.Controls.Add(new TeamsSection(), 0, 1);

            };

            tableButton.Click += (e, a) =>
            {
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add(new FillHeaderLabel("Таблица"), 0, 0);
                contentPanel.Controls.Add(SeasonViewModel.GetTable(), 0, 1);

            };
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}