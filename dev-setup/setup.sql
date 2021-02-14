IF DB_ID (N'$(DATABASE_NAME)') IS NOT NULL
DROP DATABASE $(DATABASE_NAME);
GO

CREATE DATABASE $(DATABASE_NAME);
GO

USE $(DATABASE_NAME)
GO

/* Create Table Hotels */
CREATE TABLE [dbo].[Hotels] ([Code] UNIQUEIDENTIFIER NOT NULL, [Name] NVARCHAR(100) NOT NULL, [StarsOfCategory] SMALLINT NOT NULL, [StarsOfRating] SMALLINT NOT NULL, [AddressStreet] NVARCHAR(100) NOT NULL, [AddressDistrict] NVARCHAR(100) NOT NULL, [AddressCity] NVARCHAR(100) NOT NULL, [AddressCountry] NVARCHAR(100) NOT NULL, [ZipCode] INT NOT NULL, [ContactMobile] NVARCHAR(20) NOT NULL, [ContactPhone] NVARCHAR(20) NOT NULL, [ContactEmail] NVARCHAR(100) NOT NULL, CONSTRAINT [PK_Hotels] PRIMARY KEY ([Code]))
GO


/* Create Table Rooms */
CREATE TABLE [dbo].[Rooms] ([Code] UNIQUEIDENTIFIER NOT NULL, [HotelCode] UNIQUEIDENTIFIER NOT NULL, [Name] NVARCHAR(100) NOT NULL, [Description] NVARCHAR(MAX) NOT NULL, [Capacity] INT NOT NULL, [AvailableQuantity] INT NOT NULL, [PricePerNight] DECIMAL(18,2) NOT NULL, [Amenities] NVARCHAR(500) NOT NULL, CONSTRAINT [PK_Rooms] PRIMARY KEY ([Code]))
GO
/* CreateForeignKey FK_Rooms_HotelCode_Hotels_Code Rooms(HotelCode) Hotels(Code) */
ALTER TABLE [dbo].[Rooms] ADD CONSTRAINT [FK_Rooms_HotelCode_Hotels_Code] FOREIGN KEY ([HotelCode]) REFERENCES [dbo].[Hotels] ([Code])
GO

/* Create Table Reservations */
CREATE TABLE [dbo].[Reservations] ([ReservationKey] UNIQUEIDENTIFIER NOT NULL, [Code] NVARCHAR(20) NOT NULL, [RoomCode] UNIQUEIDENTIFIER NOT NULL, [BookedBy] NVARCHAR(100) NOT NULL, [NumberOfGuests] SMALLINT NOT NULL CONSTRAINT [DF_Reservations_NumberOfGuests] DEFAULT 0, [NumberOfNights] SMALLINT NOT NULL CONSTRAINT [DF_Reservations_NumberOfNights] DEFAULT 0, [PaidPrice] DECIMAL(18,2) NOT NULL, [BreakfastIncluded] BIT NOT NULL, [Checkin] DATETIME, [Checkout] DATETIME, [HotelName] NVARCHAR(100) NOT NULL, [HotelAddress] NVARCHAR(400) NOT NULL, [HotelStarsOfCategory] SMALLINT NOT NULL, [RoomDescription] NVARCHAR(400) NOT NULL, [RoomCapacity] INT NOT NULL, [PricePerNight] DECIMAL(18,2) NOT NULL, CONSTRAINT [PK_Reservations] PRIMARY KEY ([ReservationKey]))
GO
