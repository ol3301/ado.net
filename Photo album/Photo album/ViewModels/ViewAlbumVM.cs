using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Photo_album
{
    public class ViewAlbumVM : BaseVm
    {
        private DataTable _album;
        private ICommand _rename;
        private DataRow _selectedDataRow;

        public DataTable Album
        {
            get { return _album; }
            set
            {
                _album = value;
                RaisePropertyChanged("Rows");
            }
        }

        public ICommand Rename
        {

            //просто лол
            get => _rename ?? (_rename = new RelayCommand(obj=>
            {
                string text = (string)obj;
                SelectedDataRow.ItemArray.SetValue(text,2);
                SqlWorker.Update(Album.TableName);
            }));
        }

        public DataRowCollection Rows
        {
            get => Album?.Rows;
            //set => Album?.Rows = value;
        }

        public ObservableCollection<string> Categories { get; set; }

        public DataRow SelectedDataRow
        {
            get { return _selectedDataRow; }
            set
            {
                _selectedDataRow = value;
                RaisePropertyChanged();
            }
        }

        public ViewAlbumVM()
        {
            Categories = new ObservableCollection<string>();
        }

        private void InsertRow()
        {
            Album.Rows.Add(1,File.ReadAllBytes(@"D:\Images\68450.jpg"),"lol","cata","2018-10-21");
            SqlWorker.Update(Album.TableName);
        }


        public void LoadData(DataTable album)
        {
            Album = album;
            GetCategories(album);
            //InsertRow();
        }

        private void GetCategories(DataTable album)
        {
            Categories.Clear();
            Categories.Add("(Все)");
            foreach (DataRow row in album.Rows)
                Categories.Add(row.ItemArray[3].ToString());                                
        }
    }
}
