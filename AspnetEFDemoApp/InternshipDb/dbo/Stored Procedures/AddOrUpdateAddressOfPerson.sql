-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE AddOrUpdateAddressOfPerson
	@PersonId INT,
	@AddressId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE Person SET AddressId = @AddressId 
		WHERE Person.Id = @PersonId

END