namespace PillajoMateop2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.Pagina1), typeof(Views.Pagina1));
        }
    }
}
