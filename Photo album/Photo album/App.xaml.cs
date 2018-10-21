using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Photo_album
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Window CurentWindow { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ClassHandlers.ChangeAlbumVM = new ChangeAlbumVM();
            ClassHandlers.ViewAlbumVM = new ViewAlbumVM();
        }
    }
}
