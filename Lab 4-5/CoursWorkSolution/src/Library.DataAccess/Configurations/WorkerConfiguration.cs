using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations
{
	public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
	{
		public void Configure(EntityTypeBuilder<Worker> builder)
		{
			builder.HasKey(i => i.Id);
			builder.Property(i => i.Id)
				.IsRequired(true)
				.ValueGeneratedOnAdd();

			builder.HasOne(i => i.Position)
				.WithMany(i => i.Workers);

			builder.ToTable("Workers");
		}
	}
}
