using Microsoft.Win32;
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

namespace EntityPractica1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LibraryEntities lib = new LibraryEntities();
        BitmapImage chosed = new BitmapImage();
        public MainWindow()
        {
            InitializeComponent();

            Update();
        }

        public void Update()
        {
            lib.SaveChanges();

            bk.ItemsSource = lib.BOOKS.ToList();

            at.ItemsSource = lib.AUTHORS.ToList();

            ab.ItemsSource = lib.AUTHORS_BOOKS.ToList();

            foreach (var b in lib.BOOKS)
                combobook.Items.Add(b.Id);
            foreach (var a in lib.AUTHORS)
                comboauthor.Items.Add(a.Id);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BOOKS book = (bk.SelectedItem as BOOKS);

            if(book.AUTHORS_BOOKS.Where(x => x.BOOKS.Id == book.Id).FirstOrDefault() is AUTHORS_BOOKS temp)
            {
                lib.AUTHORS_BOOKS.Remove(temp);
            }

            if(book.DEBTORS.Where(x=>x.BOOKS.Id == book.Id).FirstOrDefault() is DEBTORS temp2)
            {
                lib.DEBTORS.Remove(temp2);
            }

            lib.BOOKS.Remove(book);
            
            Update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lib.AUTHORS_BOOKS.Remove(lib.AUTHORS_BOOKS.Find((ab.SelectedItem as AUTHORS_BOOKS).Id));           
            Update();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AUTHORS authors = at.SelectedItem as AUTHORS;

            if (authors.AUTHORS_BOOKS.Where(x=>x.AUTHORS.Id == authors.Id).FirstOrDefault() is AUTHORS_BOOKS temp)
            {
                lib.AUTHORS_BOOKS.Remove(temp);
            }

            lib.AUTHORS.Remove(authors);            
            Update();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            lib.BOOKS.Add(new BOOKS { Name = BooksName.Text});
            
            Update();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            lib.AUTHORS.Add(new AUTHORS { Name = AuthorName.Text});
            Update();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            lib.AUTHORS_BOOKS.Add(new AUTHORS_BOOKS
            {
                IdBook = (int)combobook.SelectedItem,
                IdAuthor = (int)comboauthor.SelectedItem
            });
            Update();
        }
    }
}
