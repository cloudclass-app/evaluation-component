using Evaluations.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql;

namespace Evaluations.Api.Data
{
    public class EvaluationContext : DbContext
    {
        static EvaluationContext() {
            NpgsqlConnection.GlobalTypeMapper
                .MapEnum<CourseMemberRole>()
                .MapEnum<EvaluationKind>()
                .MapEnum<EvaluationPartKind>();
        }

        public EvaluationContext(DbContextOptions<EvaluationContext> options) : base(options) { }

        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Evaluation> Evaluations => Set<Evaluation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasPostgresEnum<CourseMemberRole>()
                .HasPostgresEnum<EvaluationKind>()
                .HasPostgresEnum<EvaluationPartKind>();

            modelBuilder.ConfigureEntity<Course>();
            modelBuilder.ConfigureEntity<CourseMember>();
            modelBuilder.ConfigureEntity<Evaluation>();
            modelBuilder.ConfigureEntity<EvaluationPart>();
            modelBuilder.ConfigureEntity<EvaluationPartResult>();
        }
    }
}