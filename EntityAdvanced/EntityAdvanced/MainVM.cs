using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EntityAdvanced
{
    class MainVM :BindableBase 
    {
        ObservableCollection<TabControl> Tabs { get; set; }
        LibraryEntities context = new LibraryEntities();

        public MainVM()
        {
            
        }
    }
}
