using System;

using FluentMigrator;

namespace EmergingBooking.Migrations
{
    [Migration(1)]
    public class Hotel_12042019 : Migration
    {
        private readonly string NomeDaTabela = "Hotels";

        public override void Down()
        {
            Delete.Table(NomeDaTabela);
        }

        public override void Up()
        {
            if (Schema.Table(NomeDaTabela).Exists())
            {
                Delete.ForeignKey("FK_Rooms_HotelCode_Hotels_Code").OnTable("Rooms");
                Delete.Column("HotelCode").FromTable("Rooms");

                Delete.Table(NomeDaTabela);
            }

            Create
                .Table(NomeDaTabela)
                .WithColumn("Code").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("StarsOfCategory").AsInt16()
                .WithColumn("StarsOfRating").AsInt16()
                .WithColumn("AddressStreet").AsString(100)
                .WithColumn("AddressDistrict").AsString(100)
                .WithColumn("AddressCity").AsString(100)
                .WithColumn("AddressCountry").AsString(100)
                .WithColumn("ZipCode").AsInt32()
                .WithColumn("ContactMobile").AsString(20)
                .WithColumn("ContactPhone").AsString(20)
                .WithColumn("ContactEmail").AsString(100);

            /* Uncomment the line below, if you really want to populate the EmergingBooking database
               when running FluentMigration on this project */
            //InserirHoteis();
        }

        private void InserirHoteis()
        {
            Insert
                .IntoTable(NomeDaTabela)
                .Row(new
                {
                    Code = Guid.Parse("c0467889-e454-41ca-a730-6d8047924a5c"),
                    Name = "Mocked Hotel",
                    StarsOfCategory = 3,
                    StarsOfRating = 3,
                    AddressStreet = "Mocked Street",
                    AddressDistrict = "Mocked district",
                    AddressCity = "Mocked city",
                    AddressCountry = "Mocked country",
                    ZipCode = 4200123,
                    ContactMobile = "000 123 456",
                    ContactPhone = "39 456 123",
                    ContactEmail = "mockedemail@teste.com"
                })
                .Row(new
                {
                    Code = Guid.Parse("50dbe52d-e4fc-4d4f-8140-6601e7054abe"),
                    Name = "Mocked Hotel VIP",
                    StarsOfCategory = 5,
                    StarsOfRating = 5,
                    AddressStreet = "Mocked Street vip",
                    AddressDistrict = "Mocked district vip",
                    AddressCity = "Mocked city vip",
                    AddressCountry = "Mocked country vip",
                    ZipCode = 4200123,
                    ContactMobile = "000 123 456",
                    ContactPhone = "39 456 123",
                    ContactEmail = "mockedemailvip@teste.com"
                });
        }
    }
}