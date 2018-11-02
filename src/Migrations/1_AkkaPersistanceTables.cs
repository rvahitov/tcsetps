using FluentMigrator;

namespace Correct.Storage.Migrations
{
    [Migration(1)]
    public class AkkaPersistanceTables : Migration
    {
        private const string SchemaName = "AkkaPersistance";
        private const string JournalTableName = "Journal";
        private const string SnapshotTableName = "Snapshot";
        private const string MetadataTableName = "Metadata";

        public override void Up()
        {
            CreateSchema();
            CreateJournalTable();
            CreateSnapshotTable();
            CreateMetadataTable();
        }

        public override void Down()
        {
            Delete.Table(MetadataTableName).InSchema(SchemaName);
            Delete.Table(SnapshotTableName).InSchema(SchemaName);
            Delete.Table(JournalTableName).InSchema(SchemaName);
            DeleteSchema();
        }

        private void CreateSchema()
        {
            Create.Schema(SchemaName);
        }

        private void DeleteSchema()
        {
            Delete.Schema(SchemaName);
        }

        private void CreateJournalTable()
        {
            Create.Table(JournalTableName).InSchema(SchemaName)
                .WithColumn("Ordering").AsInt64().Identity().PrimaryKey("PK_Journal")
                .WithColumn("PersistenceID").AsString(255).NotNullable()
                .WithColumn("SequenceNr").AsInt64().NotNullable()
                .WithColumn("Timestamp").AsInt64().NotNullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable()
                .WithColumn("Manifest").AsString(500).NotNullable()
                .WithColumn("Payload").AsBinary(int.MaxValue).NotNullable()
                .WithColumn("Tags").AsString(100).Nullable()
                .WithColumn("SerializerId").AsInt32().Nullable();
            Create.UniqueConstraint("QU_Journal")
                .OnTable(JournalTableName)
                .WithSchema(SchemaName)
                .Columns("PersistenceID", "SequenceNr");
        }

        private void CreateSnapshotTable()
        {
            Create.Table(SnapshotTableName).InSchema(SchemaName)
                .WithColumn("PersistenceID").AsString(255).NotNullable()
                .WithColumn("SequenceNr").AsInt64().NotNullable()
                .WithColumn("Timestamp").AsDateTime2().NotNullable()
                .WithColumn("Manifest").AsString(500).NotNullable()
                .WithColumn("Snapshot").AsBinary(int.MaxValue).NotNullable()
                .WithColumn("SerializerId").AsInt32().Nullable();
            Create.PrimaryKey("PK_Snapshot").OnTable(SnapshotTableName).WithSchema(SchemaName)
                .Columns("PersistenceID", "SequenceNr");
        }

        private void CreateMetadataTable()
        {
            Create.Table(MetadataTableName).InSchema(SchemaName)
                .WithColumn("PersistenceID").AsString(255).NotNullable()
                .WithColumn("SequenceNr").AsInt64().NotNullable();
            Create.PrimaryKey("PK_Metadata").OnTable(MetadataTableName).WithSchema(SchemaName)
                .Columns("PersistenceID", "SequenceNr");
        }
    }
}