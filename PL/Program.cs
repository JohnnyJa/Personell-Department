using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace PL
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.Launch();
        }
    }
}