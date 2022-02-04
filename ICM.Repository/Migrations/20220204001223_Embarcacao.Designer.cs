﻿// <auto-generated />
using System;
using ICM.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ICM.Repository.Migrations
{
    [DbContext(typeof(ICMContext))]
    [Migration("20220204001223_Embarcacao")]
    partial class Embarcacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ICM.Domain.Barco.Embarcacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<string>("RegistroMarinha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RegistroMarinha");

                    b.Property<int>("Tamanho")
                        .HasColumnType("int")
                        .HasColumnName("Tamanho");

                    b.Property<int>("TipoCombustivel")
                        .HasColumnType("int")
                        .HasColumnName("TipoCombustivel");

                    b.Property<int>("TipoMotor")
                        .HasColumnType("int")
                        .HasColumnName("TipoMotor");

                    b.Property<int>("TipoVaga")
                        .HasColumnType("int")
                        .HasColumnName("TipoVaga");

                    b.HasKey("Id");

                    b.ToTable("Tbl_ICM_Embarcacao", (string)null);
                });

            modelBuilder.Entity("ICM.Domain.Conta.HabilitacaoNautica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataEmissao");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataValidade");

                    b.Property<int>("NumHabilitacao")
                        .HasColumnType("int")
                        .HasColumnName("NumHabilitacao");

                    b.Property<int>("SocioId")
                        .HasColumnType("int")
                        .HasColumnName("SocioId");

                    b.Property<int>("TipoHabilitacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SocioId");

                    b.ToTable("Tbl_ICM_HabilitacaoNautica", (string)null);
                });

            modelBuilder.Entity("ICM.Domain.Conta.InfoBasica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("NumTelefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NumTelefone");

                    b.Property<int>("SocioId")
                        .HasColumnType("int")
                        .HasColumnName("SocioId");

                    b.HasKey("Id");

                    b.HasIndex("SocioId");

                    b.ToTable("Tbl_ICM_InfoBasica", (string)null);
                });

            modelBuilder.Entity("ICM.Domain.Conta.Socio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Tbl_ICM_Socio", (string)null);
                });

            modelBuilder.Entity("ICM.Domain.Conta.HabilitacaoNautica", b =>
                {
                    b.HasOne("ICM.Domain.Conta.Socio", "Socio")
                        .WithMany("HabilitacaoNautica")
                        .HasForeignKey("SocioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Socio");
                });

            modelBuilder.Entity("ICM.Domain.Conta.InfoBasica", b =>
                {
                    b.HasOne("ICM.Domain.Conta.Socio", "Socio")
                        .WithMany("InfoBasica")
                        .HasForeignKey("SocioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Socio");
                });

            modelBuilder.Entity("ICM.Domain.Conta.Socio", b =>
                {
                    b.OwnsOne("ICM.Domain.Conta.ValueObject.CNPJ", "CNPJ", b1 =>
                        {
                            b1.Property<int>("SocioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CNPJ");

                            b1.HasKey("SocioId");

                            b1.ToTable("Tbl_ICM_Socio");

                            b1.WithOwner()
                                .HasForeignKey("SocioId");
                        });

                    b.OwnsOne("ICM.Domain.Conta.ValueObject.CPF", "CPF", b1 =>
                        {
                            b1.Property<int>("SocioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CPF");

                            b1.HasKey("SocioId");

                            b1.ToTable("Tbl_ICM_Socio");

                            b1.WithOwner()
                                .HasForeignKey("SocioId");
                        });

                    b.Navigation("CNPJ");

                    b.Navigation("CPF");
                });

            modelBuilder.Entity("ICM.Domain.Conta.Socio", b =>
                {
                    b.Navigation("HabilitacaoNautica");

                    b.Navigation("InfoBasica");
                });
#pragma warning restore 612, 618
        }
    }
}
