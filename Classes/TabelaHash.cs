namespace Controle_de_Estacionamento.Classes;

public class TabelaHash
{

    private List<Ticket>[] tabela;

    private int count;

    public TabelaHash(int size)
    {
        tabela = new List<Ticket>[size];
        for(int i = 0; i < size; i++)
        {
            tabela[i] = new List<Ticket>();
        }
    }

    private int Hashing(Ticket data)
    {
        int soma = 0;
        foreach(char c in data.GetCodigo())
        {
            soma += c;
        }
        return (soma % data.GetCodigo().Length) % tabela.Length;
    }

    public void Add(Ticket data)
    {
        int chave = Hashing(data);
        tabela[chave].Add(data);
        count++;
    }

    public void Remove(Ticket data)
    {
        int chave = Hashing(data);
        tabela[chave].Remove(data);
        count--;
    }

    public bool Contains(Ticket data)
    {
        int chave = Hashing(data);
        for(int i = 0; i < tabela[chave].Count; i++)
        {
            if (tabela[chave][i].GetCodigo() == data.GetCodigo())
            {
                return true;
            }
        }
        return false;
    }

    public int Count()
    {
        return count;
    }

    public void Clear()
    {
        for(int i = 0; i < tabela.Length; i++)
        {
            tabela[i].Clear();
        }
    }

    public override string ToString()
    {
        string s = "";
        for(int i = 0; i < tabela.Length - 1; i++)
        {
            s += "[";
            try
            {
                for(int j = 0; j < tabela[i].Count - 1; j++)
                {
                    s += $"{tabela[i][j]}, ";
                }
                s += $"{tabela[i][tabela[i].Count]}],";
            }
            catch
            {
                s += "]";
            }
        }
        return s;
    }
}
