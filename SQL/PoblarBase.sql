USE [AgendaMedica]
GO
/****** Object:  StoredProcedure [dbo].[poblarAgendaMedica]    Script Date: 18/03/2026 02:34:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[poblarAgendaMedica]
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;
			INSERT INTO Medico (Id, Nombre, ApellidoPaterno, ApellidoMaterno, IsDeleted) VALUES
				(NEWID(), 'Juan', 'Perez', 'Lopez',0),
				(NEWID(), 'Maria', 'Gonzalez', 'Ramirez',0),
				(NEWID(), 'Carlos', 'Hernandez', 'Torres',0),
				(NEWID(), 'Ana', 'Martinez', 'Flores',0),
				(NEWID(), 'Luis', 'Garcia', 'Sanchez',0),
				(NEWID(), 'Sofia', 'Rodriguez', 'Diaz',0),
				(NEWID(), 'Diego', 'Morales', 'Vargas',0),
				(NEWID(), 'Laura', 'Castro', 'Rojas',0),
				(NEWID(), 'Jorge', 'Ortega', 'Mendoza',0),
				(NEWID(), 'Elena', 'Silva', 'Navarro',0);


			INSERT INTO Paciente (Id, Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Telefono, CorreoElectronico, IsDeleted) VALUES 
				(NEWID(), 'Juan', 'Perez', 'Lopez', '1995-03-15', '5512345678', 'juan.perez@gmail.com',0),
				(NEWID(), 'Maria', 'Gonzalez', 'Ramirez', '1990-07-22', '5523456789', 'maria.gonzalez@gmail.com',0),
				(NEWID(), 'Carlos', 'Hernandez', 'Torres', '1988-11-10', '5534567890', 'carlos.hernandez@gmail.com',0),
				(NEWID(), 'Ana', 'Martinez', 'Flores', '1998-01-05', '5545678901', 'ana.martinez@gmail.com',0),
				(NEWID(), 'Luis', 'Garcia', 'Sanchez', '1992-09-30', '5556789012', 'luis.garcia@gmail.com',0),
				(NEWID(), 'Sofia', 'Rodriguez', 'Diaz', '2000-06-18', '5567890123', 'sofia.rodriguez@gmail.com',0),
				(NEWID(), 'Diego', 'Morales', 'Vargas', '1985-12-25', '5578901234', 'diego.morales@gmail.com',0),
				(NEWID(), 'Laura', 'Castro', 'Rojas', '1997-04-12', '5589012345', 'laura.castro@gmail.com',0),
				(NEWID(), 'Jorge', 'Ortega', 'Mendoza', '1993-08-08', '5590123456', 'jorge.ortega@gmail.com',0),
				(NEWID(), 'Elena', 'Silva', 'Navarro', '1989-02-14', '5501234567', 'elena.silva@gmail.com',0);


			INSERT INTO Especialidad (Id, Nombre, DuracionConsultaMinutos, IsDeleted) VALUES
				('11111111-1111-1111-1111-111111111111', 'Medicina General', 20, 0),
				('22222222-2222-2222-2222-222222222222', 'Cardiología', 30, 0),
				('33333333-3333-3333-3333-333333333333', 'Cirugía', 45, 0),
				('44444444-4444-4444-4444-444444444444', 'Pediatría', 20, 0),
				('55555555-5555-5555-5555-555555555555', 'Ginecología', 30, 0)

			INSERT INTO [dbo].[MedicoEspecialidad] ([EspecialidadesId] ,[MedicoId]) VALUES
			   ('11111111-1111-1111-1111-111111111111', '7B453C67-BEA2-4EE6-84F1-310876174BBB'),
			   ('22222222-2222-2222-2222-222222222222', '7B453C67-BEA2-4EE6-84F1-310876174BBB'),
			   ('11111111-1111-1111-1111-111111111111', '29F7949E-98A1-4F7C-B8BE-396E3AEB2251'),
			   ('33333333-3333-3333-3333-333333333333', '29F7949E-98A1-4F7C-B8BE-396E3AEB2251'),
			   ('11111111-1111-1111-1111-111111111111', '18C7BA99-07F2-4E1B-90D1-B52AD54B8968'),
			   ('44444444-4444-4444-4444-444444444444', '18C7BA99-07F2-4E1B-90D1-B52AD54B8968')

			
        COMMIT;
        PRINT 'TRANSACCIÓN EXITOSA: Datos de prueba insertados correctamente.';
    END TRY
    BEGIN CATCH
        ROLLBACK;

        PRINT 'ERROR EN TRANSACCIÓN: No se insertó ningún dato.';
        PRINT ERROR_MESSAGE();
    END CATCH
END
