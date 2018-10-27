using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzMobilki
{
    class DbModel
    {
        #region Public members
        public object FindByModelOfPhone(string model)
        {
            using(MobilkiEntities mobilki = new MobilkiEntities())
            {

                return (from c in mobilki.PHONES
                        where c.Model.Contains(model)
                        select new
                        {
                            c.Id,
                            c.Name,
                            c.Model,
                            c.Price
                        }).ToList();

            }
        }

        public object FindByNameOfCustomer(string name)
        {
            using (MobilkiEntities mobilki = new MobilkiEntities())
            {
                return (from c in mobilki.CUSTOMERS
                        where c.Name.Contains(name)
                        select new
                        {
                            c.Id,
                            c.Name
                        }).ToList();
            }
        }

        public object FindByPriceOfPhone(int price)
        {
            using (MobilkiEntities mobilki = new MobilkiEntities())
            {

                return (from c in mobilki.PHONES
                        where c.Price == price
                        select new
                        {
                            c.Id,
                            c.Name,
                            c.Model,
                            c.Price
                        }).ToList();

            }
        }

        #endregion
        public DbModel()
        {

        }
    }
}
