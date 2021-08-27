CREATE TABLE Hotel (
	HotelID INT IDENTITY(1,1) NOT NULL,
	HotelName VARCHAR(150) NOT NULL,
	HotelEvaluation INT NOT NULL,
	HotelDescription VARCHAR(300) NOT NULL,
	HotelAddress NVARCHAR(80) NOT NULL,
	HotelComplement NVARCHAR(100),
	HotelCEP INT NOT NULL,
	HotelCity VARCHAR(100) NOT NULL,
	HotelState VARCHAR (2) NOT NULL,
	HotelAmenities NVARCHAR(1000)
	CONSTRAINT [HotelID] PRIMARY KEY CLUSTERED 
	);