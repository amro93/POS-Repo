﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS.DAL.DBContexts;

namespace POS.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180727124659_TestDB")]
    partial class TestDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ChangeDetector.SkipDetectChanges", "true")
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");
#pragma warning restore 612, 618
        }
    }
}
