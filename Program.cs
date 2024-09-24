using Microsoft.EntityFrameworkCore;
using MyFootball.View;
using System.Numerics;

namespace MyFootball
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
            //var ms = MatchRepository.GetMatches();
            //foreach (var item in ms)
            //{
            //    item.TicketCoast = item.T
            //}   
        }
    }
}