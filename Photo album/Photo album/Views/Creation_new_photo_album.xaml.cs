using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Photo_album
{
    /// <summary>
    /// Логика взаимодействия для Creation_new_photo_album.xaml
    /// </summary>
    public partial class Creation_new_photo_album : UserControl,IReturn
    {
        public IData Data { get; set; }

        public Creation_new_photo_album()
        {
            InitializeComponent();

            if (DataContext == null)
                DataContext = new CreationAlbumVM();
        }
    }
}
