
/************************************************************************
 * FileName  DataTable\DataTableContextInfrastructure.IAg
 * FileDesc data/context
 * Author   System
 * CreateTime 2018-08-29 17:44:04

 * Copyright (c) Socool 2017. All Rights Reserved. 
 * ***********************************************************************/

// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.5

using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning
namespace Titan.Model.DataModel
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Reflection;


    public partial class DataTableContextback : DbContext
    {
        public DataTableContextback(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Author> Author { get; set; } // SysCompany

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ʹ��sql server���ݿ�
            //optionsBuilder.UseSqlServer("Data Source=192.168.0.207,1433;Initial Catalog=db_csdn_wx;User ID=hkuser;Password=csdn2018")

            //ʹ��mysql ���ݿ�
            optionsBuilder.UseSqlServer("Data Source=112.74.51.95;Initial Catalog=TestDB;User ID=sa;Password=Hanhongwei123!;MultipleActiveResultSets=true");
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .AddEnvironmentVariables();

            //Configuration = builder.Build();

            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //��ʵ����IEntityTypeConfiguration<Entity>�ӿڵ�ģ����������뵽modelBuilder�У�����ע��
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
// </auto-generated>