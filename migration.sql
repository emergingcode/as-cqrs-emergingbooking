/* PREVIEW-ONLY MODE ========================================================= */

/* VersionMigration migrating ================================================ */

/* CreateTable VersionInfo */
CREATE TABLE [dbo].[VersionInfo] ([Version] BIGINT NOT NULL)
GO
/* VersionMigration migrated */
/* VersionUniqueMigration migrating ========================================== */

/* CreateIndex VersionInfo (Version) */
CREATE UNIQUE CLUSTERED INDEX [UC_Version] ON [dbo].[VersionInfo] ([Version] ASC)
GO
/* AlterTable VersionInfo */
/* No SQL statement executed. */
/* CreateColumn VersionInfo AppliedOn DateTime */
ALTER TABLE [dbo].[VersionInfo] ADD [AppliedOn] DATETIME
GO
/* VersionUniqueMigration migrated */
/* VersionDescriptionMigration migrating ===================================== */

/* AlterTable VersionInfo */
/* No SQL statement executed. */
/* CreateColumn VersionInfo Description String */
ALTER TABLE [dbo].[VersionInfo] ADD [Description] NVARCHAR(1024)
GO
/* VersionDescriptionMigration migrated */
/* 1: Hotel_12042019 migrating =============================================== */

/* CreateTable Hotels */
CREATE TABLE [dbo].[Hotels] ([Code] UNIQUEIDENTIFIER NOT NULL, [Name] NVARCHAR(100) NOT NULL, [StarsOfCategory] SMALLINT NOT NULL, [StarsOfRating] SMALLINT NOT NULL, [AddressStreet] NVARCHAR(100) NOT NULL, [AddressDistrict] NVARCHAR(100) NOT NULL, [AddressCity] NVARCHAR(100) NOT NULL, [AddressCountry] NVARCHAR(100) NOT NULL, [ZipCode] INT NOT NULL, [ContactMobile] NVARCHAR(20) NOT NULL, [ContactPhone] NVARCHAR(20) NOT NULL, [ContactEmail] NVARCHAR(100) NOT NULL, CONSTRAINT [PK_Hotels] PRIMARY KEY ([Code]))
GO
INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (1, '2021-01-09T21:05:53', N'Hotel_12042019')
GO
/* 1: Hotel_12042019 migrated */
/* 2: Room_12042019 migrating ================================================ */

/* CreateTable Rooms */
CREATE TABLE [dbo].[Rooms] ([Code] UNIQUEIDENTIFIER NOT NULL, [HotelCode] UNIQUEIDENTIFIER NOT NULL, [Name] NVARCHAR(100) NOT NULL, [Description] NVARCHAR(MAX) NOT NULL, [Capacity] INT NOT NULL, [AvailableQuantity] INT NOT NULL, [PricePerNight] DECIMAL(18,2) NOT NULL, [Amenities] NVARCHAR(500) NOT NULL, CONSTRAINT [PK_Rooms] PRIMARY KEY ([Code]))
GO
/* CreateForeignKey FK_Rooms_HotelCode_Hotels_Code Rooms(HotelCode) Hotels(Code) */
ALTER TABLE [dbo].[Rooms] ADD CONSTRAINT [FK_Rooms_HotelCode_Hotels_Code] FOREIGN KEY ([HotelCode]) REFERENCES [dbo].[Hotels] ([Code])
GO
INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (2, '2021-01-09T21:05:53', N'Room_12042019')
GO
/* 2: Room_12042019 migrated */
/* 3: Reservation_12042019 migrating ========================================= */

/* CreateTable Reservations */
CREATE TABLE [dbo].[Reservations] ([ReservationKey] UNIQUEIDENTIFIER NOT NULL, [Code] NVARCHAR(20) NOT NULL, [RoomCode] UNIQUEIDENTIFIER NOT NULL, [BookedBy] NVARCHAR(100) NOT NULL, [NumberOfGuests] SMALLINT NOT NULL CONSTRAINT [DF_Reservations_NumberOfGuests] DEFAULT 0, [NumberOfNights] SMALLINT NOT NULL CONSTRAINT [DF_Reservations_NumberOfNights] DEFAULT 0, [PaidPrice] DECIMAL(18,2) NOT NULL, [BreakfastIncluded] BIT NOT NULL, [Checkin] DATETIME, [Checkout] DATETIME, [HotelName] NVARCHAR(100) NOT NULL, [HotelAddress] NVARCHAR(400) NOT NULL, [HotelStarsOfCategory] SMALLINT NOT NULL, [RoomDescription] NVARCHAR(400) NOT NULL, [RoomCapacity] INT NOT NULL, [PricePerNight] DECIMAL(18,2) NOT NULL, CONSTRAINT [PK_Reservations] PRIMARY KEY ([ReservationKey]))
GO
INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (3, '2021-01-09T21:05:53', N'Reservation_12042019')
GO
/* 3: Reservation_12042019 migrated */
/* Task completed. */
