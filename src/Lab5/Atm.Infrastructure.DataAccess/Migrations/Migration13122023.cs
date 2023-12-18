using FluentMigrator;

namespace Atm.Migrations;

[Migration(13122023)]
public class Migration13122023 : Migration
{
    public override void Up()
    {
        Create.Schema("atm_db");
        Create.Table("atm_users")
            .InSchema("atm_db")
            .WithColumn("user_id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("user_name").AsString().NotNullable()
            .WithColumn("user_role").AsInt32().NotNullable()
            .WithColumn("user_password").AsString().NotNullable()
            .WithColumn("user_salt").AsString().NotNullable();
        Create.Table("atm_transactions")
            .InSchema("atm_db")
            .WithColumn("user_id").AsInt32().NotNullable().ForeignKey()
            .WithColumn("transaction_type").AsString().NotNullable()
            .WithColumn("billState").AsInt32().NotNullable()
            .WithColumn("date").AsString().NotNullable();
        Create.Table("atm_users_bill")
            .InSchema("atm_db")
            .WithColumn("user_id").AsInt32().NotNullable().ForeignKey()
            .WithColumn("money_bill").AsInt32().NotNullable();

        Create.Index("IX_Users_Ids")
            .OnTable("atm_users")
            .InSchema("atm_db")
            .OnColumn("user_id")
            .Ascending()
            .WithOptions().NonClustered();
    }

    public override void Down()
    {
        Delete.Index("IX_Users_Ids").OnTable("atm_users").InSchema("atm_db");
        Delete.Table("atm_users").InSchema("atm_db");
        Delete.Table("atm_transactions").InSchema("atm_db");
        Delete.Table("atm_users_bill").InSchema("atm_db");
        Delete.Schema("atm_db");
    }
}