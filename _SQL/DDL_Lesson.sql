use FieldAgent;

create table Agency (
    AgencyId int primary key identity(1, 1),
    ShortName varchar(25) not null,
    LongName varchar(250) not null
);

create table [Location] (
    LocationId int primary key identity(1, 1),
    [Name] varchar(25) not null,
    [Address] varchar(125) not null,
    City varchar(50) not null,
    CountryCode varchar(5) not null,
    PostalCode varchar(15) not null,
    AgencyId int not null,
    constraint fk_Location_AgencyId
        foreign key (AgencyId)
        references Agency(AgencyId)
);

create table Agent (
    AgentId int primary key identity(1, 1),
    FirstName varchar(25) not null,
    MiddleName varchar(25) null,
    LastName varchar(25) not null,
    DOB date null,
    Identifier varchar(50) not null,
    ActivationDate date not null,
    IsActive bit not null default 1,
    AgencyId int not null,
    constraint fk_Agent_AgencyId
        foreign key (AgencyId)
        references Agency(AgencyId),
    constraint uq_Agent_Identifier_AgencyId
        unique (Identifier, AgencyId)
);