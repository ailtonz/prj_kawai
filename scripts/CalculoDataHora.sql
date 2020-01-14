SELECT  
	(cast(Reserva.dataReserva as varchar) + ' ' +  cast(Reserva.horaInicio as varchar)) as Inicio,
	(cast(Reserva.dataReserva as varchar) + ' ' +  cast(Reserva.horaTerminio as varchar)) as Terminio,
	DateDiff(n,(cast(Reserva.dataReserva as varchar) + ' ' +  cast(Reserva.horaInicio as varchar)), (cast(Reserva.dataReserva as varchar) + ' ' +  cast(Reserva.horaTerminio as varchar)))/60 As Horas   
FROM Reserva;