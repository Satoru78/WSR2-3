//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSR2_3.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employees
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Subdivision { get; set; }
        public Nullable<int> IDDepartment { get; set; }
        public string Code { get; set; }
    
        public virtual Departament Departament { get; set; }
    }
}
