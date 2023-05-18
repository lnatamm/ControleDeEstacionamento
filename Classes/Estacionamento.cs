namespace Controle_de_Estacionamento.Classes;

public class Estacionamento
{
    private MatrizHashing vagas;

    private TabelaHash ticketsRegistrados;

    public Estacionamento(int m, int n)
    {
        vagas = new MatrizHashing(m, n);
        ticketsRegistrados = new TabelaHash(m * n);
    }

    private bool ValidaTicket(Carro carro)
    {
        return ticketsRegistrados.Contains(carro.GetTicket()); 
    }

    public void InserirCarro(Carro carro, DateTime horaEntrada)
    {   
        carro.GetTicket().SetHoraEntrada(horaEntrada);
        vagas.Add(carro);
        ticketsRegistrados.Add(carro.GetTicket());
    }

    public void RemoverCarro(Carro carro, DateTime horaSaida)
    {
        if(ValidaTicket(carro))
        {
            int[] index = vagas.IndexOf(carro);
            Carro c = vagas.Get(index[0], index[1]);
            c.GetTicket().SetHoraSaida(horaSaida);
            Console.WriteLine(c.GetTicket());
            vagas.Remove(carro);
            ticketsRegistrados.Remove(carro.GetTicket());
        }
    }

    public string ExibirDetalhes(Carro carro)
    {
        if (ValidaTicket(carro))
        {
            int[] index = vagas.IndexOf(carro);
            return vagas.Get(index[0], index[1]).GetTicket().ToString();
        }
        return "Placa não encontrada";
    }

    public void RemoverTodos()
    {
        vagas.Clear();
        Console.WriteLine(vagas);
    }

    public MatrizHashing GetVagas()
    {
        return vagas;
    }

    public TabelaHash GetTicketsRegistrados()
    {
        return ticketsRegistrados;
    }

    public void SetVagas(MatrizHashing vagas)
    {
        this.vagas = vagas;
    }

    public void SetTicketsRegistrados(TabelaHash ticketsRegistrados)
    {
        this.ticketsRegistrados = ticketsRegistrados;
    }

    public override string ToString()
    {
        return vagas.ToString();
    }

}
