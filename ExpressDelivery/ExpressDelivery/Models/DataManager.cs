using ExpressDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressDelivery.Models
{
    public class DataManager
    {
        public List<object> GetListObjectMap()
        {
            List<object> result = new List<object>();
            var list = Repository.Select<Филиалы>().OrderBy(x => x.адресФилиала).ToList();
            
            foreach (Филиалы item in list)
            {
                var data = new
                {
                    Name = item.наименованиеФилиала,
                    Adress = item.адресФилиала,
                    State = item.Города.наименованиеГорода,
                    Latitude = item.почтовыйИндекс,   //широта
                    Longitude = item.почтовыйИндекс //долгота
                };
                result.Add(data);
            }
            return result;
        }
    }
}