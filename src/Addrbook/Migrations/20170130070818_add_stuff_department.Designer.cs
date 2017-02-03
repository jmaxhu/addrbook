using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Addrbook.Data;

namespace Addrbook.Migrations
{
    /// <summary>
    /// auto generated migrations
    /// </summary>
    [DbContext(typeof(AddrBookDbContext))]
    [Migration("20170130070818_add_stuff_department")]
    partial class add_stuff_department
    {
        /// <summary>
        /// BuildTargetModel
        /// </summary>
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Addrbook.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Addrbook.Models.Stuff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CellPhone");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("InnerPhone")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasMaxLength(10);

                    b.Property<string>("Office")
                        .HasMaxLength(10);

                    b.Property<string>("Phone")
                        .HasMaxLength(12);

                    b.Property<string>("PhonePort")
                        .HasMaxLength(10);

                    b.Property<string>("Sex")
                        .HasMaxLength(2);

                    b.Property<string>("VirtualPhone");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Stuffs");
                });

            modelBuilder.Entity("Addrbook.Models.Stuff", b =>
                {
                    b.HasOne("Addrbook.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
