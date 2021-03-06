﻿using System;
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
        private ICommand _remove;
        private string _selectedCategory;

        public ICommand Remove
        {
            get => _remove ?? (_remove = new RelayCommand(obj=>
            {
                SelectedDataRow.Delete();

                SqlWorker.Update(Album.TableName);
            }));
        }
        
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
            get => _rename ?? (_rename = new RelayCommand(obj=>
            {
                //Пришлось делать Clone для ItemArray, там делать все 
                //изменения, а затем присваивать измененный ItemArray начальному.
                //так почему то не робит.
                //SelectedDataRow.ItemArray.SetValue(sometext,2);

                SetRowDesc(SelectedDataRow, (string)obj);

                SqlWorker.Update(Album.TableName);
            }));
        }

        public DataView Rows
        {
            get
            {
                return Album?.DefaultView ;
            }
            //set => Album?.Rows = value;
        }

        public string SelectedCategory
        {
            set
            {
                _selectedCategory = value;

                if(value == "(Все)")
                {
                    Album.DefaultView.RowFilter = "";
                    Album.DefaultView.Sort = "Date";
                    return;
                }

                Album.DefaultView.RowFilter = $"Category = '{value}'";
                Album.DefaultView.Sort = "";

                RaisePropertyChanged();
            }
            get => _selectedCategory;
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
            Album.Rows.Add(1,File.ReadAllBytes(@"D:\Images\68450.jpg"),"lol","56j56j6jyu","2018-10-21");
            SqlWorker.Update(Album.TableName);
        }

        private void SetRowDesc(DataRow row,string text)
        {
            object[] temp = (object[])row.ItemArray.Clone();
            temp.SetValue(text, 2);
            row.ItemArray = temp;
        }


        public void LoadData(DataTable album)
        {
            Album = album;
           
            GetCategories(album);

            SelectedCategory = "(Все)";
            
            //InsertRow();
        }

        private void GetCategories(DataTable album)
        {
            Categories.Clear();
            Categories.Add("(Все)");
            var data = (from c in album.AsEnumerable() select c.ItemArray[3]).Distinct();
            foreach (string row in data)
                Categories.Add(row);
        }
    }
}
