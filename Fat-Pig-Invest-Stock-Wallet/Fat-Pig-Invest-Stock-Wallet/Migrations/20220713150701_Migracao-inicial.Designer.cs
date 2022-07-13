﻿// <auto-generated />
using System;
using Fat_Pig_Invest_Stock_Wallet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fat_Pig_Invest_Stock_Wallet.Migrations
{
    [DbContext(typeof(FatPigInvestContext))]
    [Migration("20220713150701_Migracao-inicial")]
    partial class Migracaoinicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Fat_Pig_Invest_Stock_Wallet.Models.Acao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Acoes");
                });

            modelBuilder.Entity("Fat_Pig_Invest_Stock_Wallet.Models.Corretora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Corretoras");
                });

            modelBuilder.Entity("Fat_Pig_Invest_Stock_Wallet.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cnpj")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Fat_Pig_Invest_Stock_Wallet.Models.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Corretagem")
                        .HasColumnType("double");

                    b.Property<int>("CorretoraId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPregao")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Emolumentos")
                        .HasColumnType("double");

                    b.Property<int>("NumeroNota")
                        .HasColumnType("int");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CorretoraId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("Fat_Pig_Invest_Stock_Wallet.Models.Ordem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AcaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NotaId")
                        .HasColumnType("int");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("double");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("TipoOrdem")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("AcaoId");

                    b.HasIndex("NotaId");

                    b.ToTable("Ordens");
                });

            modelBuilder.Entity("Fat_Pig_Invest_Stock_Wallet.Models.Acao", b =>
                {
                    b.HasOne("Fat_Pig_Invest_Stock_Wallet.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Fat_Pig_Invest_Stock_Wallet.Models.Nota", b =>
                {
                    b.HasOne("Fat_Pig_Invest_Stock_Wallet.Models.Corretora", "Corretora")
                        .WithMany()
                        .HasForeignKey("CorretoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Corretora");
                });

            modelBuilder.Entity("Fat_Pig_Invest_Stock_Wallet.Models.Ordem", b =>
                {
                    b.HasOne("Fat_Pig_Invest_Stock_Wallet.Models.Acao", "Acao")
                        .WithMany()
                        .HasForeignKey("AcaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fat_Pig_Invest_Stock_Wallet.Models.Nota", "Nota")
                        .WithMany("Ordens")
                        .HasForeignKey("NotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acao");

                    b.Navigation("Nota");
                });

            modelBuilder.Entity("Fat_Pig_Invest_Stock_Wallet.Models.Nota", b =>
                {
                    b.Navigation("Ordens");
                });
#pragma warning restore 612, 618
        }
    }
}
