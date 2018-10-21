using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Photo_album
{
    public class ChangeAlbumVM : BaseVm
    {
        ICommand _close;
        ICommand _create;
        ICommand _choose;

        public ObservableCollection<DataTable> Albums { get; set; }
        public DataTable Categories { get; set; }

        public ChangeAlbumVM()
        {
            Albums = new ObservableCollection<DataTable>();
            ReloadTables();
        }

        private void ReloadTables()
        {
            Albums?.Clear();
            var _tables = SqlWorker.GetTables();

            if (_tables == null)
                return;

            foreach (DataTable i in _tables)
                Albums.Add(i);
        }

        private void GetAlbums()
        {

        }

        public ICommand Close
        {
            get
            {
                return _close ?? (_close = new RelayCommand(obj =>
                {
                    Environment.Exit(0);
                }));
            }
        }

        public ICommand Create
        {
            get
            {
                return _create ?? (_create = new RelayCommand(async obj =>
                {
                    var res = (RCreationAlbum)new BuildInputForm().GetWindow(new Creation_new_photo_album());

                    if (res != null)
                    {
                        await SqlWorker.CreateNewAlbumAsync(res.AlbumName);
                        ReloadTables();
                    }
                }));
            }
        }

        public ICommand Choose
        {
            get
            {
                return _choose ?? (_choose = new RelayCommand(obj =>
                {
                    if (obj == null)
                        return;
                    ClassHandlers.ViewAlbumVM.LoadData((DataTable)obj);
                }));
            }
        }
    }
}
