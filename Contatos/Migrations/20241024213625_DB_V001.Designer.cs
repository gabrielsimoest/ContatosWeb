﻿// <auto-generated />
using Contatos.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Contatos.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20241024213625_DB_V001")]
    partial class DB_V001
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Contatos.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("Contatos.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContatoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Numero")
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("Contatos.Models.Telefone", b =>
                {
                    b.HasOne("Contatos.Models.Contato", "Contato")
                        .WithMany("Telefones")
                        .HasForeignKey("ContatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato");
                });

            modelBuilder.Entity("Contatos.Models.Contato", b =>
                {
                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
