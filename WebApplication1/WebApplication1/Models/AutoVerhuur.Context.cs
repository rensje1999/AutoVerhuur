﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Voertuigen_Verhuur_JansenEntities2 : DbContext
    {
        public Voertuigen_Verhuur_JansenEntities2()
            : base("name=Voertuigen_Verhuur_JansenEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Klanten> Klantens { get; set; }
        public virtual DbSet<Medewerker> Medewerkers { get; set; }
        public virtual DbSet<PrijsHistorie> PrijsHistories { get; set; }
        public virtual DbSet<Verhuren> Verhurens { get; set; }
        public virtual DbSet<Voertuigen> Voertuigens { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
    }
}
