﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Flight_backend.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Flight_backend.Controllers;
    using Flight_backend.Models;
    using Flight_backend.Repository;
    using System.Data.SqlClient;
    using System.ComponentModel;
    using System.Data.SqlClient;
    
    public partial class RegisterDBEntities : DbContext
    {
        public RegisterDBEntities()
            : base("name=RegisterDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}