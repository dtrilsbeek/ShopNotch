CREATE TABLE [dbo].[Theme] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (100) NULL,
    [Settings] TEXT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[User] (
    [Id]       INT            NOT NULL,
    [Email]    NVARCHAR (150) NULL,
    [Password] CHAR (128)     NULL,
    [Name]     NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Shop] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [ThemeId] INT            NULL,
    [Name]    NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Shop_Theme] FOREIGN KEY ([ThemeId]) REFERENCES [dbo].[Theme] ([Id])
);

CREATE TABLE [dbo].[Product] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    [Description] TEXT           NULL,
    [Price]       MONEY          NULL,
    [SKU]         NVARCHAR (100) NULL,
    [Length]      INT            NULL,
    [Width]       INT            NULL,
    [Height]      INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Category] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (100) NULL,
    [ParentId] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[CategoryPerProduct] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ProductId]  INT NULL,
    [CategoryId] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CategoryPerProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_CategoryPerProduct_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);

CREATE TABLE [dbo].[Address] (
    [Id]          INT            NOT NULL,
    [UserId]      INT            NULL,
    [Type]        INT            NULL,
    [Firstname]   NVARCHAR (100) NULL,
    [Lastname]    NVARCHAR (100) NULL,
    [Company]     NVARCHAR (100) NULL,
    [Address1]    NVARCHAR (100) NULL,
    [Address2]    NVARCHAR (100) NULL,
    [City]        NVARCHAR (100) NULL,
    [Postcode]    NVARCHAR (50)  NULL,
    [Country]     NVARCHAR (100) NULL,
    [StateCounty] NVARCHAR (100) NULL,
    [Phone]       NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Address_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

CREATE TABLE [dbo].[Order] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [ShopId]            INT            NULL,
    [BillingAddressId]  INT            NULL,
    [ShippingAddressId] INT            NULL,
    [DateCreated]       DATETIME       DEFAULT (getdate()) NULL,
    [Email]             NVARCHAR (150) NULL,
    [Status]            INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Billing_Address] FOREIGN KEY ([BillingAddressId]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_Order_Shipping_Address] FOREIGN KEY ([ShippingAddressId]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_Order_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop] ([Id])
);

CREATE TABLE [dbo].[OrderLog] (
    [Id]      INT  NOT NULL,
    [OrderId] INT  NULL,
    [LogText] TEXT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderLog_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);

CREATE TABLE [dbo].[ProductPerOrder] (
    [Id]        INT NOT NULL,
    [OrderId]   INT NULL,
    [ProductId] INT NULL,
    [Quantity]  INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductPerOrder_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_ProductPerOrder_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);

