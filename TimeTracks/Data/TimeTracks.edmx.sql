
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/19/2013 14:46:04
-- Generated from EDMX file: C:\Users\admin\Dev\timetracks\TimeTracks\Data\TimeTracks.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AccountCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Companies] DROP CONSTRAINT [FK_AccountCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_AccountUser];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationAdderess]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Locations] DROP CONSTRAINT [FK_LocationAdderess];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationPhoneNumber]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhoneNumbers] DROP CONSTRAINT [FK_LocationPhoneNumber];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Locations] DROP CONSTRAINT [FK_CompanyLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_AdderessCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Companies] DROP CONSTRAINT [FK_AdderessCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyPhoneNumber]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhoneNumbers] DROP CONSTRAINT [FK_CompanyPhoneNumber];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPhoneNumber]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhoneNumbers] DROP CONSTRAINT [FK_UserPhoneNumber];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDevice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Devices] DROP CONSTRAINT [FK_UserDevice];
GO
IF OBJECT_ID(N'[dbo].[FK_JobNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_JobNote];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractDraw]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayOuts_Draw] DROP CONSTRAINT [FK_ContractDraw];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPayOut]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayOuts] DROP CONSTRAINT [FK_UserPayOut];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationJob]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs] DROP CONSTRAINT [FK_LocationJob];
GO
IF OBJECT_ID(N'[dbo].[FK_PunchNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_PunchNote];
GO
IF OBJECT_ID(N'[dbo].[FK_JobPunch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Punches] DROP CONSTRAINT [FK_JobPunch];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyPunch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Punches] DROP CONSTRAINT [FK_CompanyPunch];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviceLocationLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocationLogs] DROP CONSTRAINT [FK_DeviceLocationLog];
GO
IF OBJECT_ID(N'[dbo].[FK_Contract_inherits_Job]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs_Contract] DROP CONSTRAINT [FK_Contract_inherits_Job];
GO
IF OBJECT_ID(N'[dbo].[FK_Draw_inherits_PayOut]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayOuts_Draw] DROP CONSTRAINT [FK_Draw_inherits_PayOut];
GO
IF OBJECT_ID(N'[dbo].[FK_Expense_inherits_PayOut]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayOuts_Expense] DROP CONSTRAINT [FK_Expense_inherits_PayOut];
GO
IF OBJECT_ID(N'[dbo].[FK_Commission_inherits_PayOut]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayOuts_Commission] DROP CONSTRAINT [FK_Commission_inherits_PayOut];
GO
IF OBJECT_ID(N'[dbo].[FK_Task_inherits_Job]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs_Task] DROP CONSTRAINT [FK_Task_inherits_Job];
GO
IF OBJECT_ID(N'[dbo].[FK_Call_inherits_Job]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jobs_Call] DROP CONSTRAINT [FK_Call_inherits_Job];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[Adderesses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Adderesses];
GO
IF OBJECT_ID(N'[dbo].[PhoneNumbers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhoneNumbers];
GO
IF OBJECT_ID(N'[dbo].[Locations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locations];
GO
IF OBJECT_ID(N'[dbo].[Jobs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jobs];
GO
IF OBJECT_ID(N'[dbo].[Devices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Devices];
GO
IF OBJECT_ID(N'[dbo].[Notes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notes];
GO
IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Punches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Punches];
GO
IF OBJECT_ID(N'[dbo].[PayOuts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayOuts];
GO
IF OBJECT_ID(N'[dbo].[LocationLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationLogs];
GO
IF OBJECT_ID(N'[dbo].[Jobs_Contract]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jobs_Contract];
GO
IF OBJECT_ID(N'[dbo].[PayOuts_Draw]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayOuts_Draw];
GO
IF OBJECT_ID(N'[dbo].[PayOuts_Expense]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayOuts_Expense];
GO
IF OBJECT_ID(N'[dbo].[PayOuts_Commission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayOuts_Commission];
GO
IF OBJECT_ID(N'[dbo].[Jobs_Task]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jobs_Task];
GO
IF OBJECT_ID(N'[dbo].[Jobs_Call]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jobs_Call];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [UserName] nvarchar(15)  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Role] int  NOT NULL,
    [PayRate] decimal(19,4)  NULL,
    [PayInterval] int  NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Active] bit  NOT NULL,
    [ASPid] nvarchar(max)  NULL,
    [Account_Id] int  NOT NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Account_Id] int  NOT NULL,
    [Adderess_Id] int  NOT NULL
);
GO

-- Creating table 'Adderesses'
CREATE TABLE [dbo].[Adderesses] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [StreetAdderess] nvarchar(100)  NOT NULL,
    [Suite] nvarchar(50)  NULL,
    [City] nvarchar(50)  NOT NULL,
    [State] nvarchar(50)  NOT NULL,
    [ZipCode] int  NOT NULL,
    [Primary] bit  NULL,
    [Country] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'PhoneNumbers'
CREATE TABLE [dbo].[PhoneNumbers] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [AreaCode] int  NOT NULL,
    [Number] int  NOT NULL,
    [Type] int  NOT NULL,
    [Extension] nvarchar(max)  NOT NULL,
    [Primary] bit  NULL,
    [Location_Id] int  NULL,
    [Company_Id] int  NULL,
    [User_Id] int  NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Adderess_Id] int  NOT NULL,
    [Company_Id] int  NOT NULL
);
GO

-- Creating table 'Jobs'
CREATE TABLE [dbo].[Jobs] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [StartDateTime] datetime  NOT NULL,
    [EndDateTime] datetime  NOT NULL,
    [Complete] bit  NOT NULL,
    [Location_Id] int  NOT NULL
);
GO

-- Creating table 'Devices'
CREATE TABLE [dbo].[Devices] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Serial] nvarchar(100)  NULL,
    [UID] nvarchar(50)  NOT NULL,
    [Owner] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Notes'
CREATE TABLE [dbo].[Notes] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [Job_Id] int  NOT NULL,
    [Punch_Id] int  NOT NULL
);
GO

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [WeekStart] int  NOT NULL
);
GO

-- Creating table 'Punches'
CREATE TABLE [dbo].[Punches] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [PunchIn] datetime  NOT NULL,
    [PunchOut] datetime  NULL,
    [PunchedInBy] int  NOT NULL,
    [PunchedOutBy] int  NULL,
    [Verified] bit  NULL,
    [VerifiedBy] int  NULL,
    [Job_Id] int  NOT NULL,
    [Company_Id] int  NOT NULL
);
GO

-- Creating table 'PayOuts'
CREATE TABLE [dbo].[PayOuts] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [Date] datetime  NOT NULL,
    [EnteredBy] int  NOT NULL,
    [Approved] bit  NOT NULL,
    [ApprovedBy] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'LocationLogs'
CREATE TABLE [dbo].[LocationLogs] (
    [Id] int IDENTITY(1000,1) NOT NULL,
    [Latitude] float  NOT NULL,
    [Longitude] float  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [Device_Id] int  NOT NULL
);
GO

-- Creating table 'Jobs_Contract'
CREATE TABLE [dbo].[Jobs_Contract] (
    [ContractPrice] decimal(19,4)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'PayOuts_Draw'
CREATE TABLE [dbo].[PayOuts_Draw] (
    [Id] int  NOT NULL,
    [Contract_Id] int  NOT NULL
);
GO

-- Creating table 'PayOuts_Expense'
CREATE TABLE [dbo].[PayOuts_Expense] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'PayOuts_Commission'
CREATE TABLE [dbo].[PayOuts_Commission] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Jobs_Task'
CREATE TABLE [dbo].[Jobs_Task] (
    [Priority] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Jobs_Call'
CREATE TABLE [dbo].[Jobs_Call] (
    [AllotedTime] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Adderesses'
ALTER TABLE [dbo].[Adderesses]
ADD CONSTRAINT [PK_Adderesses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PhoneNumbers'
ALTER TABLE [dbo].[PhoneNumbers]
ADD CONSTRAINT [PK_PhoneNumbers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [PK_Jobs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Devices'
ALTER TABLE [dbo].[Devices]
ADD CONSTRAINT [PK_Devices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [PK_Notes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Punches'
ALTER TABLE [dbo].[Punches]
ADD CONSTRAINT [PK_Punches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PayOuts'
ALTER TABLE [dbo].[PayOuts]
ADD CONSTRAINT [PK_PayOuts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationLogs'
ALTER TABLE [dbo].[LocationLogs]
ADD CONSTRAINT [PK_LocationLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Jobs_Contract'
ALTER TABLE [dbo].[Jobs_Contract]
ADD CONSTRAINT [PK_Jobs_Contract]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PayOuts_Draw'
ALTER TABLE [dbo].[PayOuts_Draw]
ADD CONSTRAINT [PK_PayOuts_Draw]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PayOuts_Expense'
ALTER TABLE [dbo].[PayOuts_Expense]
ADD CONSTRAINT [PK_PayOuts_Expense]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PayOuts_Commission'
ALTER TABLE [dbo].[PayOuts_Commission]
ADD CONSTRAINT [PK_PayOuts_Commission]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Jobs_Task'
ALTER TABLE [dbo].[Jobs_Task]
ADD CONSTRAINT [PK_Jobs_Task]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Jobs_Call'
ALTER TABLE [dbo].[Jobs_Call]
ADD CONSTRAINT [PK_Jobs_Call]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Account_Id] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [FK_AccountCompany]
    FOREIGN KEY ([Account_Id])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountCompany'
CREATE INDEX [IX_FK_AccountCompany]
ON [dbo].[Companies]
    ([Account_Id]);
GO

-- Creating foreign key on [Account_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_AccountUser]
    FOREIGN KEY ([Account_Id])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountUser'
CREATE INDEX [IX_FK_AccountUser]
ON [dbo].[Users]
    ([Account_Id]);
GO

-- Creating foreign key on [Adderess_Id] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [FK_LocationAdderess]
    FOREIGN KEY ([Adderess_Id])
    REFERENCES [dbo].[Adderesses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationAdderess'
CREATE INDEX [IX_FK_LocationAdderess]
ON [dbo].[Locations]
    ([Adderess_Id]);
GO

-- Creating foreign key on [Location_Id] in table 'PhoneNumbers'
ALTER TABLE [dbo].[PhoneNumbers]
ADD CONSTRAINT [FK_LocationPhoneNumber]
    FOREIGN KEY ([Location_Id])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationPhoneNumber'
CREATE INDEX [IX_FK_LocationPhoneNumber]
ON [dbo].[PhoneNumbers]
    ([Location_Id]);
GO

-- Creating foreign key on [Company_Id] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [FK_CompanyLocation]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyLocation'
CREATE INDEX [IX_FK_CompanyLocation]
ON [dbo].[Locations]
    ([Company_Id]);
GO

-- Creating foreign key on [Adderess_Id] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [FK_AdderessCompany]
    FOREIGN KEY ([Adderess_Id])
    REFERENCES [dbo].[Adderesses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AdderessCompany'
CREATE INDEX [IX_FK_AdderessCompany]
ON [dbo].[Companies]
    ([Adderess_Id]);
GO

-- Creating foreign key on [Company_Id] in table 'PhoneNumbers'
ALTER TABLE [dbo].[PhoneNumbers]
ADD CONSTRAINT [FK_CompanyPhoneNumber]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyPhoneNumber'
CREATE INDEX [IX_FK_CompanyPhoneNumber]
ON [dbo].[PhoneNumbers]
    ([Company_Id]);
GO

-- Creating foreign key on [User_Id] in table 'PhoneNumbers'
ALTER TABLE [dbo].[PhoneNumbers]
ADD CONSTRAINT [FK_UserPhoneNumber]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPhoneNumber'
CREATE INDEX [IX_FK_UserPhoneNumber]
ON [dbo].[PhoneNumbers]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Devices'
ALTER TABLE [dbo].[Devices]
ADD CONSTRAINT [FK_UserDevice]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDevice'
CREATE INDEX [IX_FK_UserDevice]
ON [dbo].[Devices]
    ([User_Id]);
GO

-- Creating foreign key on [Job_Id] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_JobNote]
    FOREIGN KEY ([Job_Id])
    REFERENCES [dbo].[Jobs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobNote'
CREATE INDEX [IX_FK_JobNote]
ON [dbo].[Notes]
    ([Job_Id]);
GO

-- Creating foreign key on [Contract_Id] in table 'PayOuts_Draw'
ALTER TABLE [dbo].[PayOuts_Draw]
ADD CONSTRAINT [FK_ContractDraw]
    FOREIGN KEY ([Contract_Id])
    REFERENCES [dbo].[Jobs_Contract]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractDraw'
CREATE INDEX [IX_FK_ContractDraw]
ON [dbo].[PayOuts_Draw]
    ([Contract_Id]);
GO

-- Creating foreign key on [User_Id] in table 'PayOuts'
ALTER TABLE [dbo].[PayOuts]
ADD CONSTRAINT [FK_UserPayOut]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPayOut'
CREATE INDEX [IX_FK_UserPayOut]
ON [dbo].[PayOuts]
    ([User_Id]);
GO

-- Creating foreign key on [Location_Id] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [FK_LocationJob]
    FOREIGN KEY ([Location_Id])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationJob'
CREATE INDEX [IX_FK_LocationJob]
ON [dbo].[Jobs]
    ([Location_Id]);
GO

-- Creating foreign key on [Punch_Id] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_PunchNote]
    FOREIGN KEY ([Punch_Id])
    REFERENCES [dbo].[Punches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PunchNote'
CREATE INDEX [IX_FK_PunchNote]
ON [dbo].[Notes]
    ([Punch_Id]);
GO

-- Creating foreign key on [Job_Id] in table 'Punches'
ALTER TABLE [dbo].[Punches]
ADD CONSTRAINT [FK_JobPunch]
    FOREIGN KEY ([Job_Id])
    REFERENCES [dbo].[Jobs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JobPunch'
CREATE INDEX [IX_FK_JobPunch]
ON [dbo].[Punches]
    ([Job_Id]);
GO

-- Creating foreign key on [Company_Id] in table 'Punches'
ALTER TABLE [dbo].[Punches]
ADD CONSTRAINT [FK_CompanyPunch]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyPunch'
CREATE INDEX [IX_FK_CompanyPunch]
ON [dbo].[Punches]
    ([Company_Id]);
GO

-- Creating foreign key on [Device_Id] in table 'LocationLogs'
ALTER TABLE [dbo].[LocationLogs]
ADD CONSTRAINT [FK_DeviceLocationLog]
    FOREIGN KEY ([Device_Id])
    REFERENCES [dbo].[Devices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviceLocationLog'
CREATE INDEX [IX_FK_DeviceLocationLog]
ON [dbo].[LocationLogs]
    ([Device_Id]);
GO

-- Creating foreign key on [Id] in table 'Jobs_Contract'
ALTER TABLE [dbo].[Jobs_Contract]
ADD CONSTRAINT [FK_Contract_inherits_Job]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Jobs]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PayOuts_Draw'
ALTER TABLE [dbo].[PayOuts_Draw]
ADD CONSTRAINT [FK_Draw_inherits_PayOut]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PayOuts]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PayOuts_Expense'
ALTER TABLE [dbo].[PayOuts_Expense]
ADD CONSTRAINT [FK_Expense_inherits_PayOut]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PayOuts]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PayOuts_Commission'
ALTER TABLE [dbo].[PayOuts_Commission]
ADD CONSTRAINT [FK_Commission_inherits_PayOut]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PayOuts]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Jobs_Task'
ALTER TABLE [dbo].[Jobs_Task]
ADD CONSTRAINT [FK_Task_inherits_Job]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Jobs]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Jobs_Call'
ALTER TABLE [dbo].[Jobs_Call]
ADD CONSTRAINT [FK_Call_inherits_Job]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Jobs]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------