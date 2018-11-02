using FluentMigrator;

namespace Correct.Storage.Migrations
{
    [TimestampedMigration(2018,11,1,9,52)]
    public class BoxTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Box")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("AggregateId").AsString(255).NotNullable().Unique()
                .WithColumn("Barcode").AsString(255).NotNullable().Unique()
                .WithColumn("Created").AsDateTimeOffset().NotNullable()
                .WithColumn("Modified").AsDateTimeOffset().NotNullable();
        }
    }
}