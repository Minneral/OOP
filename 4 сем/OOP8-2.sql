CREATE PROCEDURE [dbo].[sp_InsertProduct]
    @name VARCHAR(100),
    @description VARCHAR(255),
	@fullDescription TEXT,
	@price Decimal,
	@url VARCHAR(255)
AS
    INSERT INTO Товары(Название_продукта, Описание, Полное_описание, Цена) VALUES
		(@name,@description, @fullDescription, @price);

	INSERT INTO Изображения(id_продукта, Ссылка_на_изображение) VALUES
		((SELECT SCOPE_IDENTITY()), @url)
GO

DROP PROCEDURE sp_InsertProduct
DROP PROCEDURE sp_DeleteProduct


CREATE PROCEDURE [dbo].[sp_DeleteProduct]
    @name VARCHAR(100),
    @description VARCHAR(255),
	@fullDescription TEXT,
	@price Decimal,
	@url VARCHAR(255)
AS

DELETE FROM Изображения
		WHERE	(Изображения.id_продукта = (SELECT id FROM Товары 
												WHERE	Товары.Название_продукта = @name AND
														Товары.Описание = @description AND
														Товары.Цена = @price) AND
				Ссылка_на_изображение = @url);

DELETE FROM Товары
		WHERE	(Товары.Название_продукта = @name AND
				Товары.Описание = @description AND
				Товары.Цена = @price);

	
GO



CREATE PROCEDURE [dbo].[sp_EditProduct]
    @name VARCHAR(100),
    @description VARCHAR(255),
	@fullDescription TEXT,
	@price Decimal,
	@url VARCHAR(255),
	@name_new VARCHAR(100),
    @description_new VARCHAR(255),
	@fullDescription_new TEXT,
	@price_new Decimal,
	@url_new VARCHAR(255)
AS

UPDATE Изображения
	SET Изображения.Ссылка_на_изображение = @url_new
		WHERE	(Изображения.id_продукта = (SELECT id FROM Товары 
												WHERE	Товары.Название_продукта = @name AND
														Товары.Описание = @description AND
														Товары.Цена = @price) AND
				Ссылка_на_изображение = @url);

UPDATE Товары
	SET Товары.Название_продукта = @name_new,
		Товары.Описание = @description_new,
		Товары.Полное_описание = @fullDescription_new,
		Товары.Цена = @price_new
		WHERE	(Товары.Название_продукта = @name AND
				Товары.Описание = @description AND
				Товары.Цена = @price);
GO