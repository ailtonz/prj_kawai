Declare @horaInicio datetime, @horaFim datetime

Select @Horainicio = '2009-01-01 10:10', @horaFim = '2009-01-02 09:00'

Select Convert(char(05),DateAdd(minute,DateDiff(n,@Horainicio, @horaFim),'1900-01-01'),14);