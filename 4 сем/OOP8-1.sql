CREATE TABLE ������ (
    id INT IDENTITY(1,1) PRIMARY KEY,
    ��������_�������� VARCHAR(100) NOT NULL,
    �������� VARCHAR(255) NOT NULL,
    ������_�������� TEXT NOT NULL,
    ���� DECIMAL(10, 2) NOT NULL
);

CREATE TABLE ����������� (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_�������� INT NOT NULL FOREIGN KEY REFERENCES ������(id),
    ������_��_����������� VARCHAR(255) NOT NULL,
);

INSERT INTO ������(��������_��������, ��������, ������_��������, ����) VALUES
('���������','�������', '����� �������', 10),
('������� ���������','�������', '����� �������', 12),
('������','�������', '����� �������', 14),
('������','�������', '����� �������', 7);

INSERT INTO �����������(id_��������, ������_��_�����������) VALUES
	(1, 'https://dodopizza-a.akamaihd.net/static/Img/Products/70834e6311c0483493bf2279dbc1718d_292x292.webp'),
	(2, 'https://dodopizza-a.akamaihd.net/static/Img/Products/68826b8afe1f45369e33db7b3ab44ef5_292x292.webp'),
	(3, 'https://dodopizza-a.akamaihd.net/static/Img/Products/4fa4de77d8a34912830cfdbedfaff698_292x292.webp'),
	(4, 'https://dodopizza-a.akamaihd.net/static/Img/Products/c04ab5bb5c824108ac857043bc8f8751_292x292.webp');


SELECT ������.��������_��������[��������], ������.��������, ������.������_��������, ������.����, �����������.������_��_�����������[URL] FROM
	������ INNER JOIN ����������� ON ������.id = �����������.id_��������;

EXEC sp_InsertProduct
		@name = '���������',
		@description = '�������',
		@fullDescription = '����� �������',
		@price = 10,
		@url = 'https://dodopizza-a.akamaihd.net/static/Img/Products/70834e6311c0483493bf2279dbc1718d_292x292.webp';

EXEC sp_InsertProduct
		@name = '������� ���������',
		@description = '�������',
		@fullDescription = '����� �������',
		@price = 12,
		@url = 'https://dodopizza-a.akamaihd.net/static/Img/Products/68826b8afe1f45369e33db7b3ab44ef5_292x292.webp';

EXEC sp_InsertProduct
		@name = '������',
		@description = '�������',
		@fullDescription = '����� �������',
		@price = 14,
		@url = 'https://dodopizza-a.akamaihd.net/static/Img/Products/4fa4de77d8a34912830cfdbedfaff698_292x292.webp';

EXEC sp_InsertProduct
		@name = '������',
		@description = '�������',
		@fullDescription = '����� �������',
		@price = 7,
		@url = 'https://dodopizza-a.akamaihd.net/static/Img/Products/c04ab5bb5c824108ac857043bc8f8751_292x292.webp';

exec sp_GetProducts

DELETE FROM �����������;
DELETE FROM ������;