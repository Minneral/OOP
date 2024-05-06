CREATE TABLE Товары (
    id INT IDENTITY(1,1) PRIMARY KEY,
    Название_продукта VARCHAR(100) NOT NULL,
    Описание VARCHAR(255) NOT NULL,
    Полное_описание TEXT NOT NULL,
    Цена DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Изображения (
    id INT IDENTITY(1,1) PRIMARY KEY,
    id_продукта INT NOT NULL FOREIGN KEY REFERENCES Товары(id),
    Ссылка_на_изображение VARCHAR(255) NOT NULL,
);

INSERT INTO Товары(Название_продукта, Описание, Полное_описание, Цена) VALUES
('Пепперони','Вкусная', 'Очень вкусная', 10),
('Двойная пепперони','Вкусная', 'Очень вкусная', 12),
('Мясная','Вкусная', 'Очень вкусная', 14),
('Сырная','Вкусная', 'Очень вкусная', 7);

INSERT INTO Изображения(id_продукта, Ссылка_на_изображение) VALUES
	(1, 'https://dodopizza-a.akamaihd.net/static/Img/Products/70834e6311c0483493bf2279dbc1718d_292x292.webp'),
	(2, 'https://dodopizza-a.akamaihd.net/static/Img/Products/68826b8afe1f45369e33db7b3ab44ef5_292x292.webp'),
	(3, 'https://dodopizza-a.akamaihd.net/static/Img/Products/4fa4de77d8a34912830cfdbedfaff698_292x292.webp'),
	(4, 'https://dodopizza-a.akamaihd.net/static/Img/Products/c04ab5bb5c824108ac857043bc8f8751_292x292.webp');


SELECT Товары.Название_продукта[Название], Товары.Описание, Товары.Полное_описание, Товары.Цена, Изображения.Ссылка_на_изображение[URL] FROM
	Товары INNER JOIN Изображения ON Товары.id = Изображения.id_продукта;

EXEC sp_InsertProduct
		@name = 'Пепперони',
		@description = 'Вкусная',
		@fullDescription = 'Очень вкусная',
		@price = 10,
		@url = 'https://dodopizza-a.akamaihd.net/static/Img/Products/70834e6311c0483493bf2279dbc1718d_292x292.webp';

EXEC sp_InsertProduct
		@name = 'Двойная пепперони',
		@description = 'Вкусная',
		@fullDescription = 'Очень вкусная',
		@price = 12,
		@url = 'https://dodopizza-a.akamaihd.net/static/Img/Products/68826b8afe1f45369e33db7b3ab44ef5_292x292.webp';

EXEC sp_InsertProduct
		@name = 'Мясная',
		@description = 'Вкусная',
		@fullDescription = 'Очень вкусная',
		@price = 14,
		@url = 'https://dodopizza-a.akamaihd.net/static/Img/Products/4fa4de77d8a34912830cfdbedfaff698_292x292.webp';

EXEC sp_InsertProduct
		@name = 'Сырная',
		@description = 'Вкусная',
		@fullDescription = 'Очень вкусная',
		@price = 7,
		@url = 'https://dodopizza-a.akamaihd.net/static/Img/Products/c04ab5bb5c824108ac857043bc8f8751_292x292.webp';

exec sp_GetProducts

DELETE FROM Изображения;
DELETE FROM Товары;