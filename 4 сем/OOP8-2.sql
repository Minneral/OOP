CREATE PROCEDURE [dbo].[sp_InsertProduct]
    @name VARCHAR(100),
    @description VARCHAR(255),
	@fullDescription TEXT,
	@price Decimal,
	@url VARCHAR(255)
AS
    INSERT INTO ������(��������_��������, ��������, ������_��������, ����) VALUES
		(@name,@description, @fullDescription, @price);

	INSERT INTO �����������(id_��������, ������_��_�����������) VALUES
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

DELETE FROM �����������
		WHERE	(�����������.id_�������� = (SELECT id FROM ������ 
												WHERE	������.��������_�������� = @name AND
														������.�������� = @description AND
														������.���� = @price) AND
				������_��_����������� = @url);

DELETE FROM ������
		WHERE	(������.��������_�������� = @name AND
				������.�������� = @description AND
				������.���� = @price);

	
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

UPDATE �����������
	SET �����������.������_��_����������� = @url_new
		WHERE	(�����������.id_�������� = (SELECT id FROM ������ 
												WHERE	������.��������_�������� = @name AND
														������.�������� = @description AND
														������.���� = @price) AND
				������_��_����������� = @url);

UPDATE ������
	SET ������.��������_�������� = @name_new,
		������.�������� = @description_new,
		������.������_�������� = @fullDescription_new,
		������.���� = @price_new
		WHERE	(������.��������_�������� = @name AND
				������.�������� = @description AND
				������.���� = @price);
GO