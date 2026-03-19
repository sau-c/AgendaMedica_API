USE [AgendaMedica]
GO
/****** Object:  StoredProcedure [dbo].[poblarAgendaMedica]    Script Date: 18/03/2026 10:06:05 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[poblarAgendaMedica]
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        -- =========================================
        -- MÉDICOS (IDs FIJOS)
        -- =========================================
        INSERT INTO Medico (Id, Nombre, ApellidoPaterno, ApellidoMaterno, IsDeleted) VALUES
        ('AAAAAAA1-0000-0000-0000-000000000001', 'Juan', 'Perez', 'Lopez',0),
        ('AAAAAAA2-0000-0000-0000-000000000002', 'Maria', 'Gonzalez', 'Ramirez',0),
        ('AAAAAAA3-0000-0000-0000-000000000003', 'Carlos', 'Hernandez', 'Torres',0),
        ('AAAAAAA4-0000-0000-0000-000000000004', 'Ana', 'Martinez', 'Flores',0),
        ('AAAAAAA5-0000-0000-0000-000000000005', 'Luis', 'Garcia', 'Sanchez',0),
        ('AAAAAAA6-0000-0000-0000-000000000006', 'Sofia', 'Rodriguez', 'Diaz',0),
        ('AAAAAAA7-0000-0000-0000-000000000007', 'Diego', 'Morales', 'Vargas',0),
        ('AAAAAAA8-0000-0000-0000-000000000008', 'Laura', 'Castro', 'Rojas',0),
        ('AAAAAAA9-0000-0000-0000-000000000009', 'Jorge', 'Ortega', 'Mendoza',0),
        ('AAAAAAA0-0000-0000-0000-000000000010', 'Elena', 'Silva', 'Navarro',0);


        -- =========================================
        -- PACIENTES
        -- =========================================
        INSERT INTO Paciente (Id, Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Telefono, CorreoElectronico, IsDeleted) VALUES 
        ('BBBBBBB1-0000-0000-0000-000000000001', 'Juan', 'Perez', 'Lopez', '1995-03-15', '5512345678', 'juan.perez@gmail.com',0),
        ('BBBBBBB2-0000-0000-0000-000000000002', 'Maria', 'Gonzalez', 'Ramirez', '1990-07-22', '5523456789', 'maria.gonzalez@gmail.com',0),
        ('BBBBBBB3-0000-0000-0000-000000000003', 'Carlos', 'Hernandez', 'Torres', '1988-11-10', '5534567890', 'carlos.hernandez@gmail.com',0),
        ('BBBBBBB4-0000-0000-0000-000000000004', 'Ana', 'Martinez', 'Flores', '1998-01-05', '5545678901', 'ana.martinez@gmail.com',0),
        ('BBBBBBB5-0000-0000-0000-000000000005', 'Luis', 'Garcia', 'Sanchez', '1992-09-30', '5556789012', 'luis.garcia@gmail.com',0),
        ('BBBBBBB6-0000-0000-0000-000000000006', 'Sofia', 'Rodriguez', 'Diaz', '2000-06-18', '5567890123', 'sofia.rodriguez@gmail.com',0),
        ('BBBBBBB7-0000-0000-0000-000000000007', 'Diego', 'Morales', 'Vargas', '1985-12-25', '5578901234', 'diego.morales@gmail.com',0),
        ('BBBBBBB8-0000-0000-0000-000000000008', 'Laura', 'Castro', 'Rojas', '1997-04-12', '5589012345', 'laura.castro@gmail.com',0),
        ('BBBBBBB9-0000-0000-0000-000000000009', 'Jorge', 'Ortega', 'Mendoza', '1993-08-08', '5590123456', 'jorge.ortega@gmail.com',0),
        ('BBBBBBB0-0000-0000-0000-000000000010', 'Elena', 'Silva', 'Navarro', '1989-02-14', '5501234567', 'elena.silva@gmail.com',0);


        -- =========================================
        -- ESPECIALIDADES
        -- =========================================
        INSERT INTO Especialidad (Id, Nombre, DuracionConsultaMinutos, IsDeleted) VALUES
        ('11111111-1111-1111-1111-111111111111', 'Medicina General', 20, 0),
        ('22222222-2222-2222-2222-222222222222', 'Cardiología', 30, 0),
        ('33333333-3333-3333-3333-333333333333', 'Cirugía', 45, 0),
        ('44444444-4444-4444-4444-444444444444', 'Pediatría', 20, 0),
        ('55555555-5555-5555-5555-555555555555', 'Ginecología', 30, 0);


        -- =========================================
        -- RELACIÓN
        -- =========================================
        INSERT INTO MedicoEspecialidad (EspecialidadesId, MedicoId) VALUES
        ('11111111-1111-1111-1111-111111111111', 'AAAAAAA1-0000-0000-0000-000000000001'),
        ('22222222-2222-2222-2222-222222222222', 'AAAAAAA1-0000-0000-0000-000000000001'),

        ('11111111-1111-1111-1111-111111111111', 'AAAAAAA2-0000-0000-0000-000000000002'),
        ('33333333-3333-3333-3333-333333333333', 'AAAAAAA2-0000-0000-0000-000000000002'),

        ('11111111-1111-1111-1111-111111111111', 'AAAAAAA3-0000-0000-0000-000000000003'),
        ('44444444-4444-4444-4444-444444444444', 'AAAAAAA3-0000-0000-0000-000000000003');

        COMMIT;
        PRINT 'TRANSACCIÓN EXITOSA';
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT ERROR_MESSAGE();
    END CATCH
END
