using VizsgaCommon;

namespace VizsgaForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SQL.ConnectionString = "Server=localhost;Database=VizsgaGyak;User Id=sa;Password=titok;TrustServerCertificate=true";
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new F());
           // Application.Run(new Form1());
        }
    }
}