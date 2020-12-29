using System;

using FluentMigrator;

namespace EmergingBooking.Migrations
{
    [Migration(2)]
    public class Room_12042019 : Migration
    {
        private readonly string NomeDaTabela = "Rooms";

        public override void Down()
        {
            Delete.Table(NomeDaTabela);
        }

        public override void Up()
        {
            if (Schema.Table(NomeDaTabela).Exists())
                Delete.Table(NomeDaTabela);

            Create
                .Table(NomeDaTabela)
                .WithColumn("Code").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("HotelCode").AsGuid().ForeignKey("Hotels", "Code")
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Description").AsString(int.MaxValue).NotNullable()
                .WithColumn("Capacity").AsInt32()
                .WithColumn("AvailableQuantity").AsInt32()
                .WithColumn("PricePerNight").AsDecimal(18, 2)
                .WithColumn("Amenities").AsString(500);

            /* Uncomment the line below, if you really want to populate the EmergingBooking database
               when running FluentMigration on this project */
            //InserirRoons();
        }

        private void InserirRoons()
        {
            Insert
                .IntoTable(NomeDaTabela)
                .Row(new
                {
                    Code = Guid.NewGuid(),
                    HotelCode = Guid.Parse("c0467889-e454-41ca-a730-6d8047924a5c"),
                    Name = "Mocked Room 1",
                    Description = "Room Suite",
                    Capacity = 3,
                    AvailableQuantity = 5,
                    PricePerNight = 145,
                    Amenities = "Wifi|Bar|Pool",
                })
                .Row(new
                {
                    Code = Guid.NewGuid(),
                    HotelCode = Guid.Parse("c0467889-e454-41ca-a730-6d8047924a5c"),
                    Name = "Mocked Room 2",
                    Description = "Room Suite",
                    Capacity = 3,
                    AvailableQuantity = 5,
                    PricePerNight = 149,
                    Amenities = "Wifi|Bar|Pool",
                })
                .Row(new
                {
                    Code = Guid.NewGuid(),
                    HotelCode = Guid.Parse("50dbe52d-e4fc-4d4f-8140-6601e7054abe"),
                    Name = "Mocked Room 3",
                    Description = "Room Vip",
                    Capacity = 4,
                    AvailableQuantity = 10,
                    PricePerNight = 349,
                    Amenities = "Wifi|Bar|Pool",
                })
                .Row(new
                {
                    Code = Guid.NewGuid(),
                    HotelCode = Guid.Parse("50dbe52d-e4fc-4d4f-8140-6601e7054abe"),
                    Name = "Mocked Room 4",
                    Description = "Room Vip",
                    Capacity = 4,
                    AvailableQuantity = 10,
                    PricePerNight = 445,
                    Amenities = "Wifi|Bar|Pool",
                });
        }
    }
}