//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OssBssSystem.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class Events
    {
        public int ID { get; set; }
        public int EmployeeRoleID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual EmployeeRoles EmployeeRoles { get; set; }
    }
}