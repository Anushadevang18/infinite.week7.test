use hr
alter PROCEDURE InsertPositionDetails
(
    @PositionCode char(4),
    @Description varchar(35),
    @year smallint,
    @BudgetedStrength int,
    @CurrentStrength int
 )
as
begin
insert  Position (cPositionCode, vDescription, siyear, iBudgetedStrength,iCurrentStrength)
    values (@PositionCode, @Description, @year,  @BudgetedStrength ,  @CurrentStrength)
end

