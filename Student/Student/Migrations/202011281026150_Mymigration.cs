namespace Student.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mymigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseKeyId = c.Int(nullable: false, identity: true),
                        CourseId = c.String(nullable: false, maxLength: 50),
                        CourseName = c.String(nullable: false, maxLength: 200),
                        NumderofModules = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        TrainerKeyId = c.Int(nullable: false),
                        Studentcource_StudentCourseId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseKeyId)
                .ForeignKey("dbo.Trainers", t => t.TrainerKeyId, cascadeDelete: true)
                .ForeignKey("dbo.Studentcources", t => t.Studentcource_StudentCourseId)
                .Index(t => t.TrainerKeyId)
                .Index(t => t.Studentcource_StudentCourseId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerKeyId = c.Int(nullable: false, identity: true),
                        TrainerId = c.String(nullable: false, maxLength: 50),
                        TrainerName = c.String(nullable: false, maxLength: 200),
                        Expertise = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.TrainerKeyId);
            
            CreateTable(
                "dbo.Studentcources",
                c => new
                    {
                        StudentCourseId = c.Int(nullable: false, identity: true),
                        StudentKeyId = c.Int(nullable: false),
                        CourseKeyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCourseId);
            
            CreateTable(
                "dbo.StudentInfoes",
                c => new
                    {
                        StudentKeyId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(nullable: false, maxLength: 200),
                        StudentName = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 500),
                        City = c.String(nullable: false, maxLength: 200),
                        AreaofInterest = c.String(nullable: false, maxLength: 200),
                        DOB = c.String(nullable: false),
                        CourseCompleted = c.String(nullable: false, maxLength: 200),
                        Studentcource_StudentCourseId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentKeyId)
                .ForeignKey("dbo.Studentcources", t => t.Studentcource_StudentCourseId)
                .Index(t => t.Studentcource_StudentCourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentInfoes", "Studentcource_StudentCourseId", "dbo.Studentcources");
            DropForeignKey("dbo.Courses", "Studentcource_StudentCourseId", "dbo.Studentcources");
            DropForeignKey("dbo.Courses", "TrainerKeyId", "dbo.Trainers");
            DropIndex("dbo.StudentInfoes", new[] { "Studentcource_StudentCourseId" });
            DropIndex("dbo.Courses", new[] { "Studentcource_StudentCourseId" });
            DropIndex("dbo.Courses", new[] { "TrainerKeyId" });
            DropTable("dbo.StudentInfoes");
            DropTable("dbo.Studentcources");
            DropTable("dbo.Trainers");
            DropTable("dbo.Courses");
        }
    }
}
