// <auto-generated />
using System;
using InchirieriEchipamenteAlpine.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InchirieriEchipamenteAlpine.Migrations
{
    [DbContext(typeof(InchirieriEchipamenteAlpineContext))]
    [Migration("20221218135113_Distribuitor")]
    partial class Distribuitor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.Distribuitor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeDistribuitor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Distribuitor");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.EchipamentAlpin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DataIntrareStoc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DistribuitorID")
                        .HasColumnType("int");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("Producator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DistribuitorID");

                    b.ToTable("EchipamentAlpin");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.EchipamentAlpin", b =>
                {
                    b.HasOne("InchirieriEchipamenteAlpine.Models.Distribuitor", "Distribuitor")
                        .WithMany("EchipamenteAlpine")
                        .HasForeignKey("DistribuitorID");

                    b.Navigation("Distribuitor");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.Distribuitor", b =>
                {
                    b.Navigation("EchipamenteAlpine");
                });
#pragma warning restore 612, 618
        }
    }
}
