﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server.DB.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<battle> battle { get; set; }
        public virtual DbSet<level> level { get; set; }
        public virtual DbSet<resource> resource { get; set; }
        public virtual DbSet<spell> spell { get; set; }
        public virtual DbSet<tower> tower { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<user_resource> user_resource { get; set; }
    }
}
