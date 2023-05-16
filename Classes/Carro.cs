namespace Controle_de_Estacionamento.Classes;

public class Carro
{

    private string placa { get; set; }

    private Ticket ticket { get; set; }

    public Carro(string placa) 
    {
        this.placa = placa;
        ticket = new Ticket(placa);
    }

    public Carro()
    {
        placa = null;
        ticket = null;
    }

    public string GetPlaca() 
    {
        return placa;
    }

    public Ticket GetTicket() 
    { 
        return ticket; 
    }

    public void SetPlaca(string placa)
    {
        this.placa = placa;
    }

    public override string ToString()
    {
        return $"Placa: {placa}\nTicket:\n{ticket}";
    }

}
