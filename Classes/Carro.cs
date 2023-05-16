namespace Controle_de_Estacionamento.Classes;

public class Carro
{

    private string placa { get; set; }

    private string estado { get; set; }

    private Ticket ticket { get; set; }

    private DateTime horaEntrada { get; set; }

    private DateTime horaSaida { get; set; }

    public Carro(string placa, DateTime horaEntrada, DateTime horaSaida) 
    {
        this.placa = placa;
        this.horaEntrada = horaEntrada;
        this.horaSaida = horaSaida;
        ticket = new Ticket();
    }

    public Carro(string placa)
    {
        this.placa = placa;
    }

    public Carro()
    {
        placa = null;
        estado = null;
        ticket = null;
    }

    public string GetPlaca() 
    {
        return placa;
    }

    public string GetEstado()
    {
        return estado;
    }

    public Ticket GetTicket() 
    { 
        return ticket; 
    }

    public DateTime GetHoraEntrada()
    {
        return horaEntrada;
    }

    public DateTime GetHoraSaida()
    {
        return horaSaida;
    }

    public void SetPlaca(string placa)
    {
        this.placa = placa;
    }

    public void SetEstado(string estado)
    {
        this.estado = estado;
    }

    public void SetTicket(Ticket ticket)
    {
        this.ticket = ticket;
    }

    public void SetHoraEntrada(DateTime horaEntrada)
    {
        this.horaEntrada = horaEntrada;
    }

    public void SetHoraSaida(DateTime horaSaida)
    {
        this.horaSaida= horaSaida;
    }

    public override string ToString()
    {
        return placa;
    }

}
