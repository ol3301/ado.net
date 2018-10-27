using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DzMobilki
{
    /// <summary>
    /// Извлекает спец.символы из строки
    /// </summary>
    public class SelectorKey
    {
        string res;
        public SelectorKey(ref string source)
        {
            if (source.Contains("-m"))
                res = "-m";//model
            else if (source.Contains("-n"))
                res = "-n";//Customer's name
            else if (source.Contains("-p"))
                res = "-p";//Phone's price
            if(res != "")
                source = source.Remove(source.IndexOf(res),res.Length);
        }

        public string GetResult()
        {
            return res;
        }
    }
    
    /// <summary>
    /// Данный конвертер определяет что пользователь имел виду, и возвращает искомые им данные
    /// </summary>
    public class StringToGridData : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string request = (string)value;
            DbModel model = new DbModel();

            try
            {


                switch (new SelectorKey(ref request).GetResult())
                {
                    //ищем по моделе телефона
                    case "-m":
                        return  model.FindByModelOfPhone(request);
                      

                    //ищем по имени гостя
                    case "-n":
                        return model.FindByNameOfCustomer(request);
                      

                    //ищем по цене телефона
                    case "-p":
                        return model.FindByPriceOfPhone(int.Parse(request));
                      

                    default:
                        return null;
                }

            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
                return null;
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture){ throw new NotImplementedException(); }
    }
}
