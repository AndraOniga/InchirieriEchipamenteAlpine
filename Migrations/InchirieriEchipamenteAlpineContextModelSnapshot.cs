// <auto-generated />
using System;
using InchirieriEchipamenteAlpine.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InchirieriEchipamenteAlpine.Migrations
{
    [DbContext(typeof(InchirieriEchipamenteAlpineContext))]
    partial class InchirieriEchipamenteAlpineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.CategorieEchipament", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int>("EchipamentAlpinID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("EchipamentAlpinID");

                    b.ToTable("CategorieEchipament");
                });

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

                    b.Property<int?>("ProducatorID")
                        .HasColumnType("int");

                    b.Property<string>("Stare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DistribuitorID");

                    b.HasIndex("ProducatorID");

                    b.ToTable("EchipamentAlpin");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.Inchiriere", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DataReturnarii")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EchipamentAlpinID")
                        .HasColumnType("int");

                    b.Property<int?>("MembruID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EchipamentAlpinID");

                    b.HasIndex("MembruID");

                    b.ToTable("Inchiriere");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.Membru", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Membru");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.Producator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeProducator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaraOrigine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Producator");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.CategorieEchipament", b =>
                {
                    b.HasOne("InchirieriEchipamenteAlpine.Models.Categorie", "Categorie")
                        .WithMany("CategoriiEchipamente")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InchirieriEchipamenteAlpine.Models.EchipamentAlpin", "EchipamentAlpin")
                        .WithMany("CategoriiEchipamente")
                        .HasForeignKey("EchipamentAlpinID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("EchipamentAlpin");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.EchipamentAlpin", b =>
                {
                    b.HasOne("InchirieriEchipamenteAlpine.Models.Distribuitor", "Distribuitor")
                        .WithMany("EchipamenteAlpine")
                        .HasForeignKey("DistribuitorID");

                    b.HasOne("InchirieriEchipamenteAlpine.Models.Producator", "Producator")
                        .WithMany("EchipamenteAlpine")
                        .HasForeignKey("ProducatorID");

                    b.Navigation("Distribuitor");

                    b.Navigation("Producator");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.Inchiriere", b =>
                {
                    b.HasOne("InchirieriEchipamenteAlpine.Models.EchipamentAlpin", "EchipamentAlpin")
                        .WithMany()
                        .HasForeignKey("EchipamentAlpinID");

                    b.HasOne("InchirieriEchipamenteAlpine.Models.Membru", "Membru")
                        .WithMany("Inchirieri")
                        .HasForeignKey("MembruID");

                    b.Navigation("EchipamentAlpin");

                    b.Navigation("Membru");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.Categorie", b =>
                {
                    b.Navigation("CategoriiEchipamente");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.Distribuitor", b =>
                {
                    b.Navigation("EchipamenteAlpine");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.EchipamentAlpin", b =>
                {
                    b.Navigation("CategoriiEchipamente");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.Membru", b =>
                {
                    b.Navigation("Inchirieri");
                });

            modelBuilder.Entity("InchirieriEchipamenteAlpine.Models.Producator", b =>
                {
                    b.Navigation("EchipamenteAlpine");
                });
#pragma warning restore 612, 618
        }
    }
}
