using AcoWeb.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcoWeb.API.Data;

public class EmployeesContext : DbContext
{
    public EmployeesContext(DbContextOptions<EmployeesContext> options) : base(options)
    {

    }

    public DbSet<Office> Offices { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.EmployeeAddress)
            .WithOne(ea => ea.Employee)
            .HasForeignKey<EmployeeAddress>(ea => ea.EmployeeId);

        // Seed the database with some data
        modelBuilder.Entity<Office>().HasData(
            new Office
            {
                Id = Guid.Parse("5ab77607-42e8-4a25-b47a-db8983a652e8"),
                Name = "Oscar",
                Address = "1492 Brentwood Drive",
            },
            new Office
            {
                Id = Guid.Parse("ca2abc8e-1bdc-4887-8f97-215fe050f22f"),
                Name = "Maud",
                Address = "3406 Thrash Trail",
            },
            new Office
            {
                Id = Guid.Parse("d097a599-4619-4473-ae86-d353c3069597"),
                Name = "Redding",
                Address = "784 Byers Lanet",
            },
            new Office
            {
                Id = Guid.Parse("99bc7e9d-9033-4752-a3db-a577447a7df3"),
                Name = "Payson",
                Address = "1698 Brown Street d",
            },
            new Office
            {
                Id = Guid.Parse("170ff47b-290a-4b22-acf7-8e265afeafb5"),
                Name = "Lindsay",
                Address = "	876 Chicago Avenue",
            },
            new Office
            {
                Id = Guid.Parse("a228f20b-7458-4a8c-95ba-4b209965d677"),
                Name = "Newark",
                Address = "1641 Granville Lane",
            },
            new Office
            {
                Id = Guid.Parse("7c862b39-c6d1-4c91-8181-c6cc35890bca"),
                Name = "WASHINGTON",
                Address = "1477 Liberty Street",
            }
        );

        modelBuilder.Entity<Employee>().HasData(
           new Employee
           {
               Id = Guid.Parse("6978cc16-5f5a-4020-bb79-4cc4dcc36b72"),
               OfficeId = Guid.Parse("5ab77607-42e8-4a25-b47a-db8983a652e8"),
               RoleInCompany = "Manager",
               FirstName = "Antonio",
               LastName = "P Summers",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 200000
           },
           new Employee
           {
               Id = Guid.Parse("4fa3169e-0779-45cc-9139-dc4ee92cbd5f"),
               OfficeId = Guid.Parse("5ab77607-42e8-4a25-b47a-db8983a652e8"),
               RoleInCompany = "Backend developer",
               FirstName = "Colton",
               LastName = "Minton",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 190000
           },
           new Employee
           {
               Id = Guid.Parse("3675f42d-9bbb-488f-bd36-c7e6411c87d5"),
               OfficeId = Guid.Parse("5ab77607-42e8-4a25-b47a-db8983a652e8"),
               RoleInCompany = "Developer",
               FirstName = "Crystal",
               LastName = "Krupa",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 420000
           },
           new Employee
           {
               Id = Guid.Parse("ea3a236e-fda4-4e3f-ae1d-3bd3a535a177"),
               OfficeId = Guid.Parse("5ab77607-42e8-4a25-b47a-db8983a652e8"),
               RoleInCompany = "Sellman",
               FirstName = "Caitlin",
               LastName = "Nicholson",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 100000
           },
           new Employee
           {
               Id = Guid.Parse("270ed53a-053b-442a-9302-716959d0a51a"),
               OfficeId = Guid.Parse("5ab77607-42e8-4a25-b47a-db8983a652e8"),
               RoleInCompany = "Credit officer",
               FirstName = "Kristi",
               LastName = "Mauricio",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 200000
           },
           new Employee
           {
               Id = Guid.Parse("b1ee8f72-0cc0-4cd9-bcc6-11183cf24da8"),
               OfficeId = Guid.Parse("7c862b39-c6d1-4c91-8181-c6cc35890bca"),
               RoleInCompany = "Sellman",
               FirstName = "Thomas",
               LastName = "Spates",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 200000
           },
           new Employee
           {
               Id = Guid.Parse("d447d3e9-82d3-4aba-80ae-223a6683f5c3"),
               OfficeId = Guid.Parse("7c862b39-c6d1-4c91-8181-c6cc35890bca"),
               RoleInCompany = "Sellman",
               FirstName = "Pattie",
               LastName = "Foster",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 400000
           },
           new Employee
           {
               Id = Guid.Parse("c5dceee6-ab09-42ab-bc30-cb0e91114b3d"),
               OfficeId = Guid.Parse("7c862b39-c6d1-4c91-8181-c6cc35890bca"),
               RoleInCompany = "Web developer",
               FirstName = "Candy",
               LastName = "Gilbert",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 500000
           },
               new Employee
               {
                   Id = Guid.Parse("85cbcd1f-8b72-4398-b2fe-b2776ab0be0f"),
                   OfficeId = Guid.Parse("ca2abc8e-1bdc-4887-8f97-215fe050f22f"),
                   RoleInCompany = "Manager",
                   FirstName = "Jessica",
                   LastName = "Gibbs",
                   HireDate = new DateTime(2012, 01, 01),
                   Salary = 200000
               },

           new Employee
           {
               Id = Guid.Parse("8588c7bf-2bd4-436a-a1fc-9c790895b9d5"),
               OfficeId = Guid.Parse("ca2abc8e-1bdc-4887-8f97-215fe050f22f"),
               RoleInCompany = "Backend developer",
               FirstName = "Rhonda",
               LastName = "Macklin",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 190000
           },
           new Employee
           {
               Id = Guid.Parse("c3f4100c-f746-467b-ab9e-4c16361a44af"),
               OfficeId = Guid.Parse("ca2abc8e-1bdc-4887-8f97-215fe050f22f"),
               RoleInCompany = "Head Of Developers",
               FirstName = "Willie",
               LastName = "Overton",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 12500000
           },
           new Employee
           {
               Id = Guid.Parse("d11d3a8d-30b6-4b3a-ad9b-ab2141a2f6bb"),
               OfficeId = Guid.Parse("d097a599-4619-4473-ae86-d353c3069597"),
               RoleInCompany = "Sellman",
               FirstName = "Gary",
               LastName = "Owens",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 100000
           },
           new Employee
           {
               Id = Guid.Parse("5c0bd7ac-a87b-4e92-81bb-14de6fdc6808"),
               OfficeId = Guid.Parse("d097a599-4619-4473-ae86-d353c3069597"),
               RoleInCompany = "Credit officer",
               FirstName = "Bart",
               LastName = "Burgess",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 250000
           },
           new Employee
           {
               Id = Guid.Parse("217cfe3f-f278-4ce8-84de-d9d523ca3802"),
               OfficeId = Guid.Parse("d097a599-4619-4473-ae86-d353c3069597"),
               RoleInCompany = "Sellman",
               FirstName = "Diane",
               LastName = "Perry",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 100000
           },
           new Employee
           {
               Id = Guid.Parse("532c9736-4fb6-4a4d-aa8f-e7a2d6a4ca49"),
               OfficeId = Guid.Parse("d097a599-4619-4473-ae86-d353c3069597"),
               RoleInCompany = "Sellman",
               FirstName = "Sarah",
               LastName = "Crews",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 240000
           },
           new Employee
           {
               Id = Guid.Parse("f3ad3974-0c05-4db0-bda0-dee18f00a291"),
               OfficeId = Guid.Parse("d097a599-4619-4473-ae86-d353c3069597"),
               RoleInCompany = "Web developer",
               FirstName = "Catherine",
               LastName = "Easley",
               HireDate = new DateTime(2012, 01, 01),
               Salary = 100000
           }
        );
    }
}
