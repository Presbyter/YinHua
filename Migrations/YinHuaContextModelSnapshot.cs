using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using YinHua.Data;

namespace YinHua.Migrations
{
    [DbContext(typeof(YinHuaContext))]
    partial class YinHuaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("YinHua.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Area")
                        .HasAnnotation("MaxLength", 400);

                    b.Property<string>("Company")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 11);

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
        }
    }
}
