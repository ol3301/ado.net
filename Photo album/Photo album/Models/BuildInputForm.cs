using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Photo_album
{
    public class BuildInputForm
    {
        /// <summary>
        /// Формирует диалоговое окно с произвольным контентом
        /// </summary>
        /// <param name="content">Контент который будет отображаться в сгенерированном окне</param>
        /// <returns>Результат работы диалогового окна</returns>
        public IData GetWindow(object content,object datacontext=null)
        {
            InputWindow w = new InputWindow();
            w.SizeToContent = SizeToContent.WidthAndHeight;
            w.Content = content;
            w.DataContext = datacontext;
            w.Title = (content as UserControl).Tag.ToString();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //Это надо для закрытия формы
            App.CurentWindow = w;

            w.ShowDialog();
            return (w.Content as IReturn).Data;
        }
    }
}
