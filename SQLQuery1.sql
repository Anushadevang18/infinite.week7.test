
alter PROCEDURE InsertPositionDetails
(
    @PositionCode varchar(50),
    @Description varchar(50),
    @year int,
    @BudgetedStrength int,
    @CurrentStrength int
 )
as
begin
insert into PositionTable (PositionCode, Description, year, BudgetedStrength,CurrentStrength)
    values (@PositionCode, @Description, @year,  @BudgetedStrength ,  @CurrentStrength)
end

