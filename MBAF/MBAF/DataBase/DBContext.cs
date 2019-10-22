﻿using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace MBAF.DataBase
{
    internal class MyDBContext : DbContext
    {
        internal MyDBContext() : base($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\DataBase\Database1.mdf;Integrated Security=True;")
        {
        }
        public DbSet<Corps> Corps { get; set; }
        public DbSet<AudienceType> AudienceType { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}