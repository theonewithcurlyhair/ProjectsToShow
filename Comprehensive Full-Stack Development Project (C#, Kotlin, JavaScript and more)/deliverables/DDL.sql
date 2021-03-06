USE [master]
GO
/****** Object:  Database [Capstone]    Script Date: 2020-05-12 10:43:32 AM ******/
CREATE DATABASE [Capstone]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Capstone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Capstone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Capstone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Capstone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Capstone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Capstone] SET ARITHABORT OFF 
GO
ALTER DATABASE [Capstone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Capstone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Capstone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Capstone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Capstone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Capstone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Capstone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Capstone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Capstone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Capstone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Capstone] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [Capstone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Capstone] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Capstone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Capstone] SET  MULTI_USER 
GO
ALTER DATABASE [Capstone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Capstone] SET ENCRYPTION ON
GO
ALTER DATABASE [Capstone] SET QUERY_STORE = ON
GO
ALTER DATABASE [Capstone] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO)
GO
USE [Capstone]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 2020-05-12 10:43:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2020-05-12 10:43:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[InvocDate] [date] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailReminder]    Script Date: 2020-05-12 10:43:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailReminder](
	[LastReminderSent] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2020-05-12 10:43:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FName] [varchar](50) NOT NULL,
	[LName] [varchar](50) NOT NULL,
	[MName] [varchar](50) NULL,
	[BirthDate] [date] NOT NULL,
	[StreetAddress] [varchar](255) NOT NULL,
	[City] [varchar](255) NOT NULL,
	[PostalCode] [varchar](50) NOT NULL,
	[SIN] [varchar](50) NOT NULL,
	[SeniorityDate] [date] NULL,
	[WorkPhoneNumber] [varchar](50) NULL,
	[CellPhoneNumber] [varchar](50) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[JobID] [int] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[SupervisorID] [int] NULL,
	[IsSupervisor] [bit] NULL,
	[Country] [varchar](50) NULL,
	[Province] [varchar](50) NULL,
	[JobStartDate] [datetime2](7) NULL,
	[OfficeLocation] [varchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 2020-05-12 10:43:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Justification] [varchar](255) NOT NULL,
	[Location] [varchar](255) NOT NULL,
	[Subtotal] [money] NOT NULL,
	[ItemStatusID] [int] NOT NULL,
	[PurchaseOrderID] [int] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[ModifyReason] [varchar](255) NULL,
	[DenyReason] [varchar](255) NULL,
	[IsNoLongerNeeded] [bit] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemStatus]    Script Date: 2020-05-12 10:43:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ItemStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 2020-05-12 10:43:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[Subtotal] [money] NOT NULL,
	[Taxes] [money] NOT NULL,
	[Total] [money] NOT NULL,
	[EmployeeID] [int] NULL,
	[OrderStatusID] [int] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PerfomanceRating] [varchar](max) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[ReviewDate] [datetime2](7) NOT NULL,
	[EmployeeId] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Status] [varchar](50) NULL,
	[Password] [nvarchar](512) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
	[RetiredDate] [datetime2](7) NULL,
	[TerminatedDate] [datetime2](7) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_IsNoLongerNeeded]  DEFAULT ((0)) FOR [IsNoLongerNeeded]
GO
ALTER TABLE [dbo].[Employee]  WITH NOCHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH NOCHECK ADD  CONSTRAINT [FK_Employee_Job] FOREIGN KEY([JobID])
REFERENCES [dbo].[Job] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Job]
GO
ALTER TABLE [dbo].[Item]  WITH NOCHECK ADD  CONSTRAINT [FK_Item_ItemStatus] FOREIGN KEY([ItemStatusID])
REFERENCES [dbo].[ItemStatus] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_ItemStatus]
GO
ALTER TABLE [dbo].[Item]  WITH NOCHECK ADD  CONSTRAINT [FK_Item_PurchaseOrder] FOREIGN KEY([PurchaseOrderID])
REFERENCES [dbo].[PurchaseOrder] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_PurchaseOrder]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH NOCHECK ADD  CONSTRAINT [FK_PurchaseOrder_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Employee]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH NOCHECK ADD  CONSTRAINT [FK_PurchaseOrder_OrderStatus] FOREIGN KEY([OrderStatusID])
REFERENCES [dbo].[OrderStatus] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_OrderStatus]
GO
ALTER TABLE [dbo].[User]  WITH NOCHECK ADD  CONSTRAINT [FK_User_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Employee]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddDepartment]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_AddDepartment]
(
    -- Add the parameters for the stored procedure here
    @name varchar(50),
    @description varchar(50),
	@invocDate datetime
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRY
	BEGIN TRANSACTION
	IF EXISTS 
		(SELECT * FROM Department WHERE Name = @name)
            THROW 5100, 'This Department already exists', 1
    -- Insert statements for procedure here
    INSERT INTO Department(Name,Description,InvocDate) VALUES (@name, @description, @invocDate)

	COMMIT

	END TRY
	BEGIN CATCH
		IF @@trancount > 0 ROLLBACK TRANSACTION
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_Authorization]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_Authorization]
(
    -- Add the parameters for the stored procedure here
    @loginId int,
	@password nvarchar(512)
)
AS
BEGIN
	BEGIN TRY
		SET NOCOUNT ON

		-- Check if paramaters are empty
		IF @loginId = 0 OR @loginId = '' THROW 50001, 'Login(EmployeeID) is required',1;
		IF @password = '' THROW 50002, 'Password is requried',1;

		--Check if user exists but password is incorrect
		IF EXISTS(SELECT * FROM [dbo].[User] WHERE EmployeeID = @loginId) AND 
			(SELECT [dbo].[User].Password FROM [dbo].[User] WHERE EmployeeID = @loginId) != @password
			THROW 50003, 'Password is incorrect',1;

		--Check if user is active
		IF (SELECT [dbo].[User].Status FROM [dbo].[User] WHERE EmployeeID = @loginId) <> 'Active'
			THROW 50004, 'User is inactive',1;

		 --Select logged employee details
		DECLARE @supId int = (SELECT Employee.SupervisorID FROM Employee WHERE ID = @loginId)

		IF (@supId != @loginId)
			SELECT *, (SELECT "User".Status FROM "User" WHERE EmployeeID = @loginId) AS Status,
				(SELECT FName FROM Employee WHERE ID = @supId) AS SFName,
				(SELECT MName FROM Employee WHERE ID = @supId) AS SMName,
				(SELECT LName FROM Employee WHERE ID = @supId) AS SLName,
				(SELECT Name FROM Department WHERE ID = Employee.DepartmentID) AS DepartmentName,
				(SELECT Name FROM Job WHERE ID = Employee.JobID) AS JobName,
				(SELECT CONCAT(Employee.FName, ' ', Employee.LName) FROM Employee WHERE ID = @supId) AS SupervisorName,
				(SELECT Department.ID FROM Department INNER JOIN Employee ON Department.ID = Employee.DepartmentID WHERE Employee.ID = @supId) AS DepID
			FROM Employee WHERE ID = @loginId;
		ELSE
			SELECT *, (SELECT "User".Status FROM "User" WHERE EmployeeID = @loginId) AS Status,
				(SELECT Name FROM Department WHERE ID = Employee.DepartmentID) AS DepartmentName,
				(SELECT Name FROM Job WHERE ID = Employee.JobID) AS JobName,
				(SELECT CONCAT(Employee.FName, ' ', Employee.LName) FROM Employee WHERE ID = @supId) AS SupervisorName,
				(SELECT Department.ID FROM Department INNER JOIN Employee ON Department.ID = Employee.DepartmentID WHERE Employee.ID = @supId) AS DepID
			FROM Employee WHERE ID = @loginId;
			

		--SELECt Employee.ID,Employee.FName, Employee.MName, Employee.LName, Employee.IsSupervisor, Employee.SupervisorID, (SELECT CONCAT(Employee.FName, ' ', Employee.LName) FROM Employee WHERE ID = @supId) AS SupervisorName, Employee.Email, Department.Name AS DepName, Department.ID AS DepID FROM Employee 
		--INNER JOIN Department ON Employee.DepartmentID = Department.ID
		--WHERE Employee.ID = @loginId

	END TRY
	BEGIN CATCH
		THROW;
	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_createEmployee]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_createEmployee]
(
    -- Add the parameters for the stored procedure here
    @empId int,
	@fName varchar(50),
	@lName varchar(50),
	@mName varchar(50),
	@bDate date,
	@streetAddress varchar(255),
	@City varchar(255),
	@postalCode varchar(50),
	@sin varchar(50),
	@senorityDate date,
	@wPhone varchar(50),
	@cPhone varchar(50),
	@email varchar(255),
	@departmentId int,
	@jobId int,
	@supId int,
	@password nvarchar(255),
	@country varchar(50) = null,
	@province varchar(50),
	@isSuper bit,
	@status varchar(255),
	@jobStartDate Date
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
	SET IDENTITY_INSERT Employee ON
	SET XACT_ABORT ON

	BEGIN TRY
	
	BEGIN TRANSACTION
	        IF EXISTS 
				(SELECT * FROM Employee WHERE ID = @empId)
            THROW 5100, 'This Employee already exists', 1


    -- Insert statements for procedure here
    INSERT INTO Employee(ID,FName,LName,MName,BirthDate,StreetAddress,City,PostalCode,SIN,SeniorityDate,WorkPhoneNumber,CellPhoneNumber,Email,DepartmentID,JobID,SupervisorID, Country, Province, IsSupervisor, JobStartDate) 
	VALUES (@empId, @fName, @lName, @mName, @bDate, @streetAddress, @City, @postalCode,
	@sin, @senorityDate, @wPhone, @cPhone, @email, @departmentId, @jobId, @supId, @country, @province, @isSuper, @jobStartDate)

	if @@ERROR <> 0
		begin
			rollback transaction
		end
			else
		begin
			EXEC sp_CreateUser @status, @password, @empId
		end
	COMMIT

	END TRY
	BEGIN CATCH
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateItem]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CreateItem]
	@name varchar(50),
	@desc varchar(255),
	@qty int,
	@price money,
	@justification	varchar(255),
	@location varchar(255),
	@subtotal money,
	@status int,
	@timeStamp timestamp output,
	@id int output,
	@orderID int = NULL
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY
		INSERT INTO Item(Name, Description, Quantity, Price, Justification, Location, Subtotal, ItemStatusID, PurchaseOrderID)
		VALUES(@name, @desc, @qty, @price, @justification, @location, @subtotal, @status, @orderID)

		set @id = @@IDENTITY
		set @timeStamp = (SELECT TimeStamp FROM Item WHERE ID = @id)

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		RAISERROR ('Something went wrong on Server Side. Please Retry', 16,1,1)
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateReview]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_CreateReview]
(
    -- Add the parameters for the stored procedure here
    @perfomanceRating varchar(50),
	@comment varchar (255),
	@reviewDate Date,
	@employeeId int
)
AS
BEGIN
BEGIN TRY
BEGIN TRANSACTION
    -- Insert statements for procedure here
    INSERT INTO Review VALUES (@perfomanceRating, @comment, @reviewDate, @employeeId)
COMMIT
END TRY
BEGIN CATCH
	ROLLBACK;
	Print Error_Message() 
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_createUser]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_createUser]
	@status varchar(255),
	@password nvarchar(255),
	@empID int
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY
        INSERT INTO [dbo].[User]([Status], Password, EmployeeID)
        VALUES(@status, @password, @empID)

        PRINT 'User created successfuly'
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE() 
    END CATCH

END;
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteDepartment]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteDepartment]
(
    -- Add the parameters for the stored procedure here
    @id int
)
AS
BEGIN
	BEGIN TRY
    -- Insert statements for procedure here
    IF (SELECT COUNT(*) FROM Employee INNER JOIN Department ON Employee.DepartmentID = Department.ID WHERE Department.ID = @id) > 0
		THROW 50001, 'Cannot delete, this Department has employees assigned', 1;
	ELSE
		DELETE Department WHERE Department.ID = @id
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteItem]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DeleteItem]
@id int
as
begin
delete from Item where ID = @id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllHREmployees]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllHREmployees]

AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
  SELECT Email FROM Employee INNER JOIN Department ON Employee.DepartmentID = Department.ID WHERE [Name] = 'HR Department'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDepartments]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetDepartments]
(
	@id int = 0
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
	if @id = 0
	BEGIN 
		SELECT * FROM Department
	END
	else
	BEGIN
		SELECT Department.ID, Department.Name FROM Department INNER JOIN Employee ON Department.ID = Employee.DepartmentID WHERE Employee.ID = @id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getDepByID]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_getDepByID]
(
	@depId int
)
AS
BEGIN

    -- Insert statements for procedure here
    SELECT * FROM Department WHERE Department.ID = @depId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmpReviews]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetEmpReviews]
(
    -- Add the parameters for the stored procedure here
	@empId int
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT * FROM Review WHERE EmployeeId = @empId ORDER BY ReviewDate
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetItemDetails]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetItemDetails]
	@itemId int
AS

BEGIN
SELECT * FROM Item WHERE ID = @itemId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPurchaseOrderDetails]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPurchaseOrderDetails]
	@orderID int
AS

BEGIN
	SELECT *, (SELECT Employee.FName FROM Employee WHERE ID = PurchaseOrder.EmployeeID) AS FName, 
	(SELECT Employee.MName FROM Employee WHERE ID = PurchaseOrder.EmployeeID) AS MName,
	 (SELECT Employee.LName FROM Employee WHERE ID = PurchaseOrder.EmployeeID) AS LName,
	 (SELECT Department.Name FROM Department WHERE ID = (SELECT Employee.DepartmentID FROM Employee WHERE ID = PurchaseOrder.EmployeeID)) AS DepName,
	 (SELECT Employee.DepartmentID FROM Employee WHErE ID  = PurchaseOrder.EmployeeID) as DepID,
	 (SELECT Email FROM Employee WHERE ID = PurchaseOrder.EmployeeID) AS Email
	  FROM PurchaseOrder WHERE ID = @orderID;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPurchaseOrderItems]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPurchaseOrderItems]
	@orderID int
AS

BEGIN
	SELECT * FROM Item WHERE PurchaseOrderID = @orderID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPurchaseOrders]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPurchaseOrders]
AS

BEGIN
	SELECT *, (SELECT Employee.FName FROM Employee WHERE ID = PurchaseOrder.EmployeeID) AS FName, 
	(SELECT Employee.MName FROM Employee WHERE ID = PurchaseOrder.EmployeeID) AS MName,
	 (SELECT Employee.LName FROM Employee WHERE ID = PurchaseOrder.EmployeeID) AS LName,
	 (SELECT Department.Name FROM Department WHERE ID = (SELECT Employee.DepartmentID FROM Employee WHERE ID = PurchaseOrder.EmployeeID)) AS DepName,
	 (SELECT Employee.DepartmentID FROM Employee WHErE ID  = PurchaseOrder.EmployeeID) as DepID
	  FROM PurchaseOrder 
	 ORDER BY PurchaseOrder.TimeStamp DESC
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetReviewDetails]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetReviewDetails]
(
    -- Add the parameters for the stored procedure here
    @id int
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

	--Select logged employee details
		DECLARE @supId int = (SELECT Employee.SupervisorID FROM Employee INNER JOIN Review ON Review.EmployeeId = Employee.ID WHERE Review.ID = @id)

    -- Insert statements for procedure here
    SELECT Review.Comment, Review.PerfomanceRating, Review.ReviewDate, Employee.SupervisorID as supID,
	(SELECT FName + ' '+ MName + ' ' + LName FROM Employee WHERE Employee.ID = @supId) as Name 
	FROM Review INNER JOIN Employee ON Review.EmployeeId = Employee.ID 
	WHERE Review.ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSupervisedEmployee]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSupervisedEmployee]
(
    -- Add the parameters for the stored procedure here
    @empId int
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
select ID, (FName + ' ' + LName) as [Name], ReviewDate, Email
from (
  select ID, SupervisorID, FName, LName, Email
    , (select max(ReviewDate) from dbo.Review R where R.EmployeeID = E.ID) ReviewDate
  from dbo.Employee E
) E
where SupervisorID = @empId
and (ReviewDate is null or ReviewDate < dateadd(month, -3, current_timestamp));
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getSupervisors]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_getSupervisors]
(
    -- Add the parameters for the stored procedure here
    @departmentId int
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
	-- We retrieve only employees 
select E.Id, E.FName + ' ' + E.LName as Name from employee E LEFT OUTER JOIN Employee E2 ON E.Id = E2.SupervisorID  WHERE E.DepartmentID = @departmentId AND E.IsSupervisor = 1
  Group By E.Id, E.FName, E.LName
  HAVING COUNT(E.ID) < 11

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSuperWithPendReviews]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSuperWithPendReviews]

AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
select (se.fname + ' ' + se.lname) Name, s.id superID, se.Email
from (select distinct supervisorid id from employee) s
inner join employee se on se.id = s.id
inner join employee e on e.supervisorid = s.id
left join (
  select employeeid, max(reviewdate) reviewdate
  from review
  group by employeeid  
) r on r.employeeid = e.id 
group by s.id, se.fname, se.lname, se.Email
having count(case when coalesce(r.reviewdate, dateadd(month, -4, getdate())) < dateadd(month, -3, getdate()) then 1 end) > 0
END
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_InitPO]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InitPO]
	@id int output,
	@item_id int output,
	@item_timestamp timestamp output,
	@timestamp timestamp output,
	@date date,
	@subtotal money,
	@taxes money,
	@total money,
	@empID int,
	@status int,
	@name varchar(50),
	@desc varchar(255),
	@qty int,
	@price money,
	@justification	varchar(255),
	@location varchar(255),
	@item_subtotal money,
	@item_status int
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY
		INSERT INTO PurchaseOrder(OrderDate, Subtotal, Taxes, Total, EmployeeID, OrderStatusID)
		VALUES(@date, @subtotal, @taxes, @total, @empID, @status)

		SET @id = (SELECT @@IDENTITY);
		SET @timestamp = (SELECT TimeStamp FROM PurchaseOrder WHERE ID = @id);
	
		INSERT INTO Item(Name, Description, Quantity, Price, Justification, Location, Subtotal, ItemStatusID, PurchaseOrderID)
		VALUES(@name, @desc, @qty, @price, @justification, @location, @item_subtotal, @item_status, @id)

		SET @item_id = @@IDENTITY;
		SET @item_timestamp = (SELECT Item.TimeStamp FROM Item WHERE ID = @item_id)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		RAISERROR ('Something went wrong on Server Side. Please Retry', 16,1,1)
	END CATCH
END


select * from PurchaseOrder where ID = 10000019
select * from Item where PurchaseOrderID = 10000019
GO
/****** Object:  StoredProcedure [dbo].[sp_ModifyDepartment]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_ModifyDepartment]
(
    -- Add the parameters for the stored procedure here
	@TimeStamp timestamp OUTPUT,
	@Id int,
	@Name varchar(50),
	@Description varchar(50),
	@InvocDate Date
)
AS
BEGIN
BEGIN TRY

	IF @TimeStamp <> (SELECT [TimeStamp] FROM Department WHERE ID = @Id)
		THROW 50001, 'This record was modified since you retrieved it. Please reload information and try again', 1;

	UPDATE Department 
		SET Name = @Name,
		Description = @Description,
		InvocDate = @InvocDate
	WHERE ID = @Id

	SET @TimeStamp = (SELECT [TimeStamp] FROM Department WHERE ID = @Id)
END TRY
BEGIN CATCH
	;THROW
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModifyItem]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ModifyItem]
	@itemID int,
	@name varchar(50),
	@desc varchar(255),
	@qty int,
	@price money,
	@justification	varchar(255),
	@location varchar(255),
	@subtotal money,
	@status int,
	@timeStamp timestamp output,
	@isNoLongerNeeded bit = 0,
	@modifyReason varchar(255) = null,
	@denyReason varchar(255) = null
AS
BEGIN
	BEGIN TRANSACTION;
		BEGIN TRY
		UPDATE Item 
			SET Name = @name,
				Description = @desc,
				Quantity = @qty,
				Price = @price,
				Justification = @justification,
				Location = @location, 
				Subtotal = @subtotal,
				ItemStatusID = @status,
				ModifyReason = @modifyReason,
				DenyReason = @denyReason,
				IsNoLongerNeeded = @isNoLongerNeeded
		WHERE ID = @itemID and TimeStamp = @timeStamp 
		IF @@ROWCOUNT = 0
		BEGIN
			 RAISERROR ('Refresh Data. Item has changed',
				   16, -- Severity.
				   1, -- State.
				   1) -- myKey that was changed
		END
		SET @timeStamp = (SELECT TimeStamp FROM Item WHERE ID = @itemID)

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		RAISERROR ('Something went wrong on Server Side. Please Retry and Refresh data', 16,1,1)
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModifyPersonalInfo]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_ModifyPersonalInfo]
(
    -- Add the parameters for the stored procedure here
	@TimeStamp timestamp OUTPUT,
	@Id int,
	@StreetAddress varchar(255),
	@City varchar(255),
	@PostalCode varchar(50),
	@Wphone varchar(50),
	@Cphone	varchar(50),
	@Country varchar(50),
	@Province varchar(50)
)
AS
BEGIN
BEGIN TRY

	IF @TimeStamp <> (SELECT [TimeStamp] FROM Employee WHERE ID = @Id)
		THROW 50001, 'This record was modified since you retrieved it. Please reload information and try again', 1;

	UPDATE Employee 
		SET StreetAddress = @StreetAddress,
		City = @City,
		PostalCode = @PostalCode,
		WorkPhoneNumber = @Wphone,
		CellPhoneNumber = @Cphone,
		Country = @Country,
		Province = @Province
	WHERE ID = @Id

	SET @TimeStamp = (SELECT [TimeStamp] FROM Employee WHERE ID = @Id)
END TRY
BEGIN CATCH
	;THROW
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModifyPurchaseOrder]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ModifyPurchaseOrder]
	@orderID int,
	@subtotal money,
	@taxes money,
	@total money,
	@status int,
	@timeStamp timestamp output
AS

BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY
		UPDATE PurchaseOrder
			SET 
				Subtotal = @subtotal,
				Taxes = @taxes,
				Total = @total,
				OrderStatusID = @status
		WHERE ID = @orderID and TimeStamp = @timeStamp
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR('Refresh Data, Purhcase Order Request was changed',16,1)
		END
		set @timeStamp = (Select TimeStamp from PurchaseOrder where ID = @orderID)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		RAISERROR ('Something went wrong on Server Side. Please Retry and Refresh Data', 16,1,1)
	END CATCH
END


GO
/****** Object:  StoredProcedure [dbo].[sp_ModifyUser]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_ModifyUser]
(
    -- Add the parameters for the stored procedure here
	@Timestamp Timestamp OUTPUT,
    @empId int,
	--@fName varchar(50),
	--@lName varchar(50),
	--@mName varchar(50),
	@jobStartDate Date,
	@streetAddress varchar(255),
	@City varchar(255),
	@postalCode varchar(50),
	@sin varchar(50),
	@senorityDate Date,
	@wPhone varchar(50),
	@cPhone varchar(50),
	@email varchar(255),
	@departmentId int,
	@jobId int,
	@supId int,
	@country varchar(50),
	@province varchar(50),
	@StatusDate datetime2,
	@Status varchar(50),
	@Birthday Date

)
AS
BEGIN
	BEGIN TRY
		IF @TimeStamp <> (SELECT [TimeStamp] FROM Employee WHERE ID = @empId)
		THROW 50001, 'This record was modified since you retrieved it. Please reload information and try again', 1;

			BEGIN TRANSACTION [Transac]
				UPDATE Employee SET JobStartDate = @jobStartDate,
				StreetAddress = @streetAddress,
				City = @City,
				PostalCode = @postalCode,
				[SIN] = @sin,
				SeniorityDate = @senorityDate,
				WorkPhoneNumber = @wPhone,
				CellPhoneNumber = @cPhone,
				Email = @email,
				DepartmentID = @departmentId,
				JobID = @jobId,
				SupervisorID = @supId,
				Country = @country,
				Province = @province,
				BirthDate = @Birthday
				WHERE ID = @empId

				if @Status = 'Retired'
				BEGIN
					UPDATE [User] SET [Status] = @Status,
						RetiredDate = @StatusDate
					WHERE EmployeeID = @empId
				END
				if @Status = 'Terminated'
				BEGIN
					UPDATE [User] SET [Status] = @Status,
						TerminatedDate = @StatusDate
					WHERE EmployeeID = @empId
				END
				if @Status = 'Active'
				BEGIN
					UPDATE [User] SET [Status] = @Status
					WHERE EmployeeID = @empId
				END
			
				COMMIT TRANSACTION [Transac]

		SET @TimeStamp = (SELECT [TimeStamp] FROM Employee WHERE ID = @empId)

	END TRY
	BEGIN CATCH
		 DECLARE
		   @ErMessage NVARCHAR(2048),
		   @ErSeverity INT,
		   @ErState INT
 
		 SELECT
		   @ErMessage = ERROR_MESSAGE(),
		   @ErSeverity = ERROR_SEVERITY(),
		   @ErState = ERROR_STATE()
 
		 RAISERROR (@ErMessage,
					 @ErSeverity,
					 @ErState )
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_RetrieveEmployee]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_RetrieveEmployee]
(
    -- Add the parameters for the stored procedure here
    @id int
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT * FROM Employee JOIN [User] ON Employee.ID = [User].EmployeeID WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchEmployee]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_SearchEmployee]
@keywordId varchar(8) = null, 
@keywordName varchar(30) = null,
@SupervisorId int
as 

begin 
begin try
if @keywordId is not null
    select Employee.ID, FName + ' ' + LName as Name, CellPhoneNumber, Email, OfficeLocation, Department.Name as DepartmentName, Job.Name as JobName 
	from Employee INNER JOIN Department ON Employee.DepartmentID = Department.ID INNER JOIN Job ON Employee.JobID = Job.ID 
	where Employee.ID = @keywordId ORDER BY Employee.LName
else if @keywordName is not null
        select Employee.ID, FName + ' ' + LName as Name, CellPhoneNumber, Email, OfficeLocation, Department.Name as DepartmentName, Job.Name as JobName 
		from Employee INNER JOIN Department ON Employee.DepartmentID = Department.ID INNER JOIN Job ON Employee.JobID = Job.ID  
		where LName like '%' + @keywordName + '%'
		ORDER BY Employee.LName
else if @keywordId is null AND @keywordName is null
	    select Employee.ID, FName + ' ' + LName as Name, CellPhoneNumber, Email, OfficeLocation, Department.Name as DepartmentName, Job.Name as JobName 
		from Employee INNER JOIN Department ON Employee.DepartmentID = Department.ID INNER JOIN Job ON Employee.JobID = Job.ID
		ORDER BY Employee.LName
end try
begin catch 
  ;throw
end catch
end
GO
/****** Object:  StoredProcedure [dbo].[sp_updateEmailSendDate]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[sp_updateEmailSendDate]

AS
BEGIN
	BEGIN TRY
	BEGIN TRANSACTION
    -- Insert statements for procedure here
		UPDATE EmailReminder SET LastReminderSent =  GETDATE()
	COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK
		;THROW
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 2020-05-12 10:43:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sysdiagrams'
GO
USE [master]
GO
ALTER DATABASE [Capstone] SET  READ_WRITE 
GO
