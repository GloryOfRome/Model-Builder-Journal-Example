#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model_Builder_Journal_Example.Models;

namespace Model_Builder_Journal_Example.Data
{
    public class Model_Builder_Journal_ExampleContext : DbContext
    {
        public Model_Builder_Journal_ExampleContext (DbContextOptions<Model_Builder_Journal_ExampleContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //当我们第一次建Model

            //将系统指向我们的类
            //builder.Entity<Journal>().HasKey(j => j.UserEditors);
            builder.Entity<Journal>().HasKey(j => j.UserOwnerNumber);
            builder.Entity<User>().HasKey(u => u.UserNumber);
            builder.Entity<UserJournal>().HasKey(uj => new { uj.UserEditorNumber, uj.JournalNumber });

            //建立关系
            builder.Entity<Journal>().HasOne(j => j.UserOwner)
                                     .WithMany(uo=>uo.Journals)
                                     .HasForeignKey(j=> j.UserOwnerNumber);

            //builder.Entity<User>().HasMany(u=>u.Journals)
            //                      .WithOne(j=>j.UserOwner)
            //                      .HasForeignKey(j=>j.UserEditorNumber);

            builder.Entity<UserJournal>().HasOne(uj => uj.Journal)
                                         .WithMany(j => j.UserJournals)
                                         .HasForeignKey(uj => uj.JournalNumber);

            builder.Entity<UserJournal>().HasOne(uj => uj.UserEditor)
                                         .WithMany(u => u.UserJournals)
                                         .HasForeignKey(uj => uj.UserEditorNumber);


            //builder.Entity<Journal>().HasMany(j => j.UserEditors)
            //                         .WithMany(u => u.Journals);

            builder.Entity<User>().HasData(new Models.User
            {
                UserNumber = "001",
                FristName ="Adminstrator"

            });
        }
        //public DbSet<Model_Builder_Journal_Example.Models.Journal> Journal { get; set; }
        public DbSet<Journal> Journal { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserJournal> UserJournals { get; set; }
    }
}
