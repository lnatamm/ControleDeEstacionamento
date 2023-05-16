namespace Controle_de_Estacionamento.Classes;

public class Ticket
{

    private string placa { get; set; }

    private string estado { get; set; }

    private string codigo { get; set; }

    private double valor { get; set; }

    public Ticket(string placa)
    {
        this.placa = placa;
        DefineEstado();
        DefineCodigo();
        valor = 0;
    }

    public Ticket()
    {
        placa = "";
        estado = "";
        codigo = "";
        valor = 0;
    }

    private void DefineEstado()
    {

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

    public string GetCodigo()
    {
        return codigo;
    }

    public double GetValor() 
    {
        return valor;
    }

    public void SetCodigo(string codigo)
    {
        this.codigo = codigo;
    }

    public void SetValor(double valor)
    {
        this.valor = valor;
    }

}
