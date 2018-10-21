using System.Windows;
using System.Windows.Input;

namespace Photo_album
{
    class CreationAlbumVM : BaseVm
    {
        private ICommand _close;
        private ICommand _add;


        public ICommand Close
        {
            get
            {
                return _close ?? (_close = new RelayCommand( obj =>
                {
                    App.CurentWindow.Close();
                }));
            }
        }

        public ICommand Add
        {
            get
            {
                return _add ?? (_add = new RelayCommand(view =>
                {
                    if (Name != "")
                    {
                        (view as IReturn).Data = new RCreationAlbum(Name);
                        Close.Execute(null);
                    }
                }));
            }
        }

        public string Name { get; set; }

        public CreationAlbumVM()
        {

        }
    }
}
