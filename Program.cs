namespace LW5
{
    internal static class Program
    {
        public static GraphEditor GraphEditor { get; } = new();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(GraphEditor);
        }
    }
}