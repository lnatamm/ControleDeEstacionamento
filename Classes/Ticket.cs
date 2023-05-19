namespace Controle_de_Estacionamento.Classes;

public class Ticket
{

    private LeitorDePlaca leitor { get; set; }

    private string placa { get; set; }

    private string estado { get; set; }

    private string codigo { get; set; }

    private DateTime horaEntrada { get; set; }

    private DateTime horaSaida { get; set; }

    private int valor { get; set; }

    public Ticket(string placa)
    {
        this.placa = placa;
        leitor = new LeitorDePlaca();
        DefineEstado();
        DefineCodigo();
        horaEntrada = new DateTime();
        horaSaida = new DateTime();
        valor = 0;
    }

    public Ticket()
    {
        placa = "";
        estado = "";
        codigo = "";
        horaEntrada = new DateTime();
        horaSaida = new DateTime();
        valor = 0;
    }

    private void DefineEstado()
    {
        estado = leitor.GetEstado(placa);
    }

    private void DefineCodigo()
    {
        string s = "";
        foreach(char c in placa)
        {
            s += char.IsAsciiLetterOrDigit(Convert.ToChar(c + 1)) ? Convert.ToChar(c + 1) : char.IsAsciiLetter(Convert.ToChar(c)) ? "A" : "0";
        }
        codigo = s;
    }

    private double TempoDecorrido()
    {
        TimeSpan diferenca = horaSaida - horaEntrada;
        return diferenca.TotalHours;
    }

    private void DefineValor()
    {
        double fracaoHora = TempoDecorrido();
        int tempoTeto;
        if(fracaoHora < 0.25)
        {
            valor = 0;
        }
        else if(fracaoHora < 3)
        {
            valor = 8;
        }
        else
        {
            tempoTeto = (int)Math.Ceiling(fracaoHora);
            valor = ((tempoTeto - 3) * 2) + 8;
        }
    }

    public LeitorDePlaca GetLeitor()
    {
        return leitor;
    }

    public string GetPlaca()
    {
        return placa;
    }

    public string GetEstado()
    {
        return estado;
    }

    public string GetCodigo()
    {
        return codigo;
    }

    public DateTime GetHoraEntrada()
    {
        return horaEntrada;
    }

    public DateTime GetHoraSaida()
    {
        return horaSaida;
    }

    public int GetValor() 
    {
        return valor;
    }

    public void SetLeitor(LeitorDePlaca leitor)
    {
        this.leitor = leitor;
    }

    public void SetPlaca(string placa)
    {
        this.placa = placa;
    }

    public void SetEstado(string estado)
    {
        this.estado = estado;
    }

    public void SetCodigo(string codigo)
    {
        this.codigo = codigo;
    }

    public void SetHoraEntrada(DateTime horaEntrada)
    {
        this.horaEntrada = horaEntrada;
    }

    public void SetHoraSaida(DateTime horaSaida)
    {
        this.horaSaida = horaSaida;
        DefineValor();
    }

    public void SetValor(int valor)
    {
        this.valor = valor;
    }

    public override string ToString()
    {
        return valor < 10 ? $"Placa: {placa}\nEstado: {estado}\nCodigo do Ticket: {codigo}\nHora de Entrada: {horaEntrada.Hour}h{horaEntrada.Minute}m\nHora de Saída: {horaSaida.Hour}h{horaSaida.Minute}m\nValor Cobrado: R$0{valor}.00\n" : $"Placa: {placa}\nEstado: {estado}\nCodigo do Ticket: {codigo}\nHora de Entrada: {horaEntrada.Hour}h{horaEntrada.Minute}m\nHora de Saída: {horaSaida.Hour}h{horaSaida.Minute}m\nValor Cobrado: R${valor}.00\n";
    }

}
