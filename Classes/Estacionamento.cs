﻿namespace Controle_de_Estacionamento.Classes;

public class Estacionamento
{
    private ArrayList<Carro> vagas;

    private TabelaHash ticketsRegistrados;

    public Estacionamento(int m, int n)
    {
        vagas = new ArrayList<Carro>(m, n);
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
            carro.GetTicket().SetHoraSaida(horaSaida);
            vagas.Remove(carro);
            ticketsRegistrados.Remove(carro.GetTicket());
        }
    }

    public ArrayList<Carro> GetVagas()
    {
        return vagas;
    }

    public TabelaHash GetTicketsRegistrados()
    {
        return ticketsRegistrados;
    }

    public void SetVagas(ArrayList<Carro> vagas)
    {
        this.vagas = vagas;
    }

    public void SetTicketsRegistrados(TabelaHash ticketsRegistrados)
    {
        this.ticketsRegistrados = ticketsRegistrados;
    }

}