//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lesson2.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dishes
    {
        public int DishID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public bool IsInStopList { get; set; }
        public Nullable<int> DishTypeID { get; set; }
    
        public virtual DishTypes DishTypes { get; set; }
    }
}
