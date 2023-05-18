namespace Controle_de_Estacionamento.Classes;

public class LeitorDePlaca
{
    private List<string> parana { get; set; }

    private List<string> rioGrandeDoSul { get; set; }
    
    private List<string> santaCatarina { get; set; }

    public LeitorDePlaca()
    {
        DefineParana();
        DefineRioGrandeDoSul();
        DefineSantaCatarina();
    }

    private string Converter(char c)
    {
        return Convert.ToString(c);
    }

    private char Somar(char c, int i)
    {
        return (c - 'A' + i) % 26 < 0 ? (char)('A' + ((c - 'A' + i) % 26) + 26) : (char)('A' + (c - 'A' + i) % 26);
    }

    private void Loopar(List<string> lista, char p, char s, char t, char pp, char ss, char tt)
    {
        for (char i = p; ; i = Somar(i, 1))
        {
            for (char j = s; ; j = Somar(j, 1))
            {
                for (char k = t; ; k = Somar(k, 1))
                {
                    lista.Add($"{Converter(i)}{Converter(j)}{Converter(k)}");
                    if (k == tt)
                    {
                        break;
                    }
                }
                if (j == ss)
                {
                    break;
                }
            }
            if (i == pp)
            {
                break;
            }
        }
    }

    private void DefineParana()
    {
        parana = new List<string>();
        Loopar(parana, 'A', 'A', 'A', 'B', 'E', 'Z');
        Loopar(parana, 'R', 'H', 'A', 'R', 'H', 'Z');
    }

    private void DefineRioGrandeDoSul()
    {
        rioGrandeDoSul = new List<string>();
        Loopar(rioGrandeDoSul, 'I', 'A', 'Q', 'J', 'D', 'O');
    }

    private void DefineSantaCatarina()
    {
        santaCatarina = new List<string>();
        Loopar(santaCatarina, 'L', 'W', 'R', 'M', 'M', 'M');
        Loopar(santaCatarina, 'O', 'K', 'D', 'O', 'K', 'H');
        Loopar(santaCatarina, 'Q', 'H', 'A', 'Q', 'J', 'Z');
        Loopar(santaCatarina, 'Q', 'T', 'K', 'Q', 'T', 'M');
        Loopar(santaCatarina, 'R', 'A', 'A', 'R', 'A', 'J');
        Loopar(santaCatarina, 'R', 'D', 'S', 'R', 'E', 'B');
        Loopar(santaCatarina, 'R', 'K', 'W', 'R', 'L', 'P');
        Loopar(santaCatarina, 'R', 'X', 'K', 'R', 'Y', 'I');
    }

    private void QuebraCaracteres(string placa)
    {
        placa = Converter(placa[0]) + Converter(placa[1]) + Converter(placa[2]);
    }

    public string GetEstado(string placa)
    {
        QuebraCaracteres(placa);
        return parana.Contains(placa) ? "Paraná" : rioGrandeDoSul.Contains(placa) ? "Rio Grande do Sul" : santaCatarina.Contains(placa) ? "Santa Catarina" : "Estado não registrado";
    }

    public List<string> GetParana()
    {
        return parana;
    }

    public List<string> GetRioGrandeDoSul() 
    {
        return rioGrandeDoSul;
    }

    public List<string> GetSantaCatarina()
    {
        return santaCatarina;
    }

    public void SetParana(List<string> parana) 
    {
        this.parana = parana;
    }

    public void SetRioGrandeDoSul(List<string> rioGrandeDoSul)
    {
        this.rioGrandeDoSul = rioGrandeDoSul;
    }

    public void SetSantaCatarina(List<string> santaCatarina)
    {
        this.santaCatarina = santaCatarina;
    }

}
