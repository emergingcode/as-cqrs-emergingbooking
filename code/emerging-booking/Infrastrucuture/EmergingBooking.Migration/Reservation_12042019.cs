using FluentMigrator;

namespace EmergingBooking.Migrations
{
    [Migration(3)]
    public class Reservation_12042019 : Migration
    {
        private readonly string NomeDaTabela = "Reservations";

        public override void Down()
        {
            Delete.Table(NomeDaTabela);
        }

        public override void Up()
        {
            if (Schema.Table(NomeDaTabela).Exists())
            {
                Delete.Table(NomeDaTabela);
            }

            Create
                .Table(NomeDaTabela)
                .WithColumn("ReservationKey").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Code").AsString(20).NotNullable()
                .WithColumn("RoomCode").AsGuid().NotNullable()
                .WithColumn("BookedBy").AsString(100).NotNullable()
                .WithColumn("NumberOfGuests").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("NumberOfNights").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("PaidPrice").AsDecimal(18, 2)
                .WithColumn("BreakfastIncluded").AsBoolean()
                .WithColumn("Checkin").AsDateTime().Nullable()
                .WithColumn("Checkout").AsDateTime().Nullable()
                .WithColumn("HotelName").AsString(100)
                .WithColumn("HotelAddress").AsString(400)
                .WithColumn("HotelStarsOfCategory").AsInt16()
                .WithColumn("RoomDescription").AsString(400)
                .WithColumn("RoomCapacity").AsInt32()
                .WithColumn("PricePerNight").AsDecimal(18, 2);
        }
    }
}