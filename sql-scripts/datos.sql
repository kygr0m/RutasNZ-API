USE [RutasDB]
GO
DELETE FROM [RutasDB].[dbo].[Regiones];
GO
DELETE FROM [RutasDB].[dbo].[Dificultades];
GO
DELETE FROM [RutasDB].[dbo].[Rutas];
GO
INSERT [dbo].[Dificultades] ([Id_Dificultad], [Nombre]) VALUES (N'f808ddcd-b5e5-4d80-b732-1ca523e48434', N'Difícil')
GO
INSERT [dbo].[Dificultades] ([Id_Dificultad], [Nombre]) VALUES (N'54466f17-02af-48e7-8ed3-5a4a8bfacf6f', N'Fácil')
GO
INSERT [dbo].[Dificultades] ([Id_Dificultad], [Nombre]) VALUES (N'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c', N'Medio')
GO
INSERT [dbo].[Regiones] ([Id_Region], [Codigo], [Nombre], [ImagenRegionUrl]) VALUES (N'906cb139-415a-4bbb-a174-1a1faf9fb1f6', N'MAD', N'Madrid', N'https://images.pexels.com/photos/1500598/pexels-photo-1500598.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2')
GO
INSERT [dbo].[Regiones] ([Id_Region], [Codigo], [Nombre], [ImagenRegionUrl]) VALUES (N'f7248fc3-2585-4efb-8d1d-1c555f4087f6', N'BCN', N'Barcelona', N'https://images.pexels.com/photos/819764/pexels-photo-819764.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2')
GO
INSERT [dbo].[Regiones] ([Id_Region], [Codigo], [Nombre], [ImagenRegionUrl]) VALUES (N'14ceba71-4b51-4777-9b17-46602cf66153', N'VAL', N'Valencia', N'https://images.pexels.com/photos/256150/pexels-photo-256150.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2')
GO
INSERT [dbo].[Regiones] ([Id_Region], [Codigo], [Nombre], [ImagenRegionUrl]) VALUES (N'6884f7d7-ad1f-4101-8df3-7a6fa7387d81', N'GR', N'Granada', N'https://images.pexels.com/photos/3049735/pexels-photo-3049735.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2')
GO
INSERT [dbo].[Regiones] ([Id_Region], [Codigo], [Nombre], [ImagenRegionUrl]) VALUES (N'cfa06ed2-bf65-4b65-93ed-c9d286ddb0de', N'SAN', N'San Sebastián', N'https://images.pexels.com/photos/4633874/pexels-photo-4633874.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2')
GO


INSERT INTO [RutasDB].[dbo].[Rutas]
(Id_ruta, Nombre, Descripcion, LongitudKm, ImagenRutaUrl, Id_Dificultad, Id_Region)
VALUES
('327aa9f7-26f7-4ddb-8047-97464374bb63', 'Ruta del Parque del Retiro', 'Este paseo escénico te lleva a través del hermoso Parque del Retiro en Madrid, ofreciendo vistas impresionantes de los jardines y estanques.', 3.5, 'https://images.pexels.com/photos/12848824/pexels-photo-12848824.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2', '54466F17-02AF-48E7-8ED3-5A4A8BFACF6F', '906CB139-415A-4BBB-A174-1A1FAF9FB1F6');
GO
INSERT INTO [RutasDB].[dbo].[Rutas]
(Id_ruta, Nombre, Descripcion, LongitudKm, ImagenRutaUrl, Id_Dificultad, Id_Region)
VALUES
('1cc5f2bc-ff4b-47c0-a475-1add56c6497b', 'Camino de Santiago Madrid', 'Este camino te lleva a lo largo de la famosa ruta del Camino de Santiago, con vistas impresionantes de la naturaleza y la historia.', 8.2, 'https://images.pexels.com/photos/28236738/pexels-photo-28236738/free-photo-of-way-of-st-james-to-compostela.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2', 'EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C', '906CB139-415A-4BBB-A174-1A1FAF9FB1F6');
GO
INSERT INTO [RutasDB].[dbo].[Rutas]
(Id_ruta, Nombre, Descripcion, LongitudKm, ImagenRutaUrl, Id_Dificultad, Id_Region)
VALUES
('09601132-f92d-457c-b47e-da90e117b33c', 'Sendero de la Alhambra', 'Explora el hermoso sendero que rodea la Alhambra en Granada, con una variedad de plantas y flores para admirar.', 2, 'https://images.pexels.com/photos/17740864/pexels-photo-17740864/free-photo-of-the-patio-de-la-acequia-of-the-generalife-palace-in-granada-spain.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2', '54466F17-02AF-48E7-8ED3-5A4A8BFACF6F', '6884f7d7-ad1f-4101-8df3-7a6fa7387d81');
GO
INSERT INTO [RutasDB].[dbo].[Rutas]
(Id_ruta, Nombre, Descripcion, LongitudKm, ImagenRutaUrl, Id_Dificultad, Id_Region)
VALUES
('30d654c7-89ac-4704-8333-5065b740150b', 'Ruta del Montjuïc', 'Este sendero te lleva a la cima de Montjuïc, ofreciendo vistas panorámicas de Barcelona y su puerto.', 2, 'https://images.pexels.com/photos/18803552/pexels-photo-18803552/free-photo-of-magic-fountain-of-montjuic-and-palau-nacional-in-barcelona.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2', 'ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c', 'f7248fc3-2585-4efb-8d1d-1c555f4087f6');
GO
INSERT INTO [RutasDB].[dbo].[Rutas]
(Id_ruta, Nombre, Descripcion, LongitudKm, ImagenRutaUrl, Id_Dificultad, Id_Region)
VALUES
('f7578324-f025-4c86-83a9-37a7f3d8fe81', 'Parque de la Ciudadela', 'Explora el hermoso Parque de la Ciudadela en Barcelona, con una amplia variedad de árboles, jardines y animales para admirar.', 3, 'https://images.pexels.com/photos/5263944/pexels-photo-5263944.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2', '54466F17-02AF-48E7-8ED3-5A4A8BFACF6F', 'f7248fc3-2585-4efb-8d1d-1c555f4087f6');
GO
INSERT INTO [RutasDB].[dbo].[Rutas]
(Id_ruta, Nombre, Descripcion, LongitudKm, ImagenRutaUrl, Id_Dificultad, Id_Region)
VALUES
('2d9d6604-bef9-4b0a-805d-630240a29595', 'Sendero de la Playa de la Concha', 'Disfruta de vistas panorámicas de San Sebastián y la Playa de la Concha en este sendero a lo largo de la costa.', 5.0, 'https://images.pexels.com/photos/28168827/pexels-photo-28168827/free-photo-of-playa-de-la-concha.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2', 'EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C', 'cfa06ed2-bf65-4b65-93ed-c9d286ddb0de');
GO
INSERT INTO [RutasDB].[dbo].[Rutas]
(Id_ruta, Nombre, Descripcion, LongitudKm, ImagenRutaUrl, Id_Dificultad, Id_Region)
VALUES
('1ea0b064-2d44-4324-91ee-6dd86c91b713', 'Ruta de Manzanares el Real', 'Disfruta de un hermoso recorrido por el Parque Regional de la Cuenca Alta del Manzanares, con vistas espectaculares de la Sierra de Guadarrama.', 5.0, 'https://images.pexels.com/photos/4282205/pexels-photo-4282205.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1', 'EA294873-7A8C-4C0F-BFA7-A2EB492CBF8C', '906CB139-415A-4BBB-A174-1A1FAF9FB1F6');
GO
