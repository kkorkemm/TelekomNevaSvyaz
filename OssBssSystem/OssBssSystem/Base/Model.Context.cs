﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TelekomNevaSvyazDBEntities : DbContext
    {
        public TelekomNevaSvyazDBEntities()
            : base("name=TelekomNevaSvyazDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AddressRaions> AddressRaions { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<Contract_Service> Contract_Service { get; set; }
        public virtual DbSet<ContractTypes> ContractTypes { get; set; }
        public virtual DbSet<Equipments> Equipments { get; set; }
        public virtual DbSet<EquipmentTypes> EquipmentTypes { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<ProblemTypes> ProblemTypes { get; set; }
        public virtual DbSet<RaionTypes> RaionTypes { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<RequestStatuses> RequestStatuses { get; set; }
        public virtual DbSet<ServiceConnectTypes> ServiceConnectTypes { get; set; }
        public virtual DbSet<ServiceKinds> ServiceKinds { get; set; }
        public virtual DbSet<ServiceTypes> ServiceTypes { get; set; }
    }
}
