//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpressDelivery.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Сообщения
    {
        public int кодСообщения { get; set; }
        public System.DateTime датаСообщения { get; set; }
        public string темаСообщения { get; set; }
        public string текстСообщения { get; set; }
        public int табельныйНомер { get; set; }
        public string категорияСообщения { get; set; }
    
        public virtual Сотрудники Сотрудники { get; set; }
    }
}
