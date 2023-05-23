using System.Numerics;

namespace Controle_de_Estacionamento.Classes;
public class MatrizHashing
{
    private Carro[][] array;

    private List<int[]> posicoesPreenchidas;

    private int count;

    public MatrizHashing(int m, int n)
    {
        array = new Carro[n][];
        posicoesPreenchidas = new List<int[]>();
        for (int i = 0; i < n; i++)
        {
            array[i] = new Carro[m];
        }
        count = 0;
    }

    private int Hashing(Carro data)
    {
        return data.GetHashCode() % array[0].Length;
    }

    public void Add(Carro data)
    {
        int hash = Hashing(data);
        int linha = hash % array.Length;
        int coluna = hash;
        int tentativa = 1;
        int tentativaLinha = 1;
        int[] finalIndex;
        while (array[linha][coluna] != null)
        {
            coluna = (hash + tentativa) % array[linha].Length;
            tentativa++;
            if(tentativa > array[linha].Length)
            {
                tentativa = 1;
                linha++;
                tentativaLinha++;
                if(tentativaLinha > array.Length)
                {
                    return;
                }
                linha = linha % array.Length;
                coluna = hash;
            }
        }
        finalIndex = new int[] {linha, coluna};
        array[finalIndex[0]][finalIndex[1]] = data;
        posicoesPreenchidas.Add(finalIndex);
    }

    public int Count()
    {
        return count;
    }

    private int InputHora()
    {
        int input = 0;
        try
        {
            input = Convert.ToInt32(Console.ReadLine());
            return input < 0 ? InputHora() : input < 24 ? input : InputHora();
        }
        catch
        {
            Console.WriteLine("Insira Apenas Números");
            return InputHora();
        }
    }

    private int InputMinuto()
    {
        int input = 0;
        try
        {
            input = Convert.ToInt32(Console.ReadLine());
            return input < 0 ? InputMinuto() : input < 60 ? input : InputMinuto();
        }
        catch
        {
            Console.WriteLine("Insira Apenas Números");
            return InputHora();
        }
    }

    private DateTime DefineHoraSaida(int hora, int minuto, DateTime horaEntrada)
    {
        Console.WriteLine("Digite a Hora e o Minuto de Saída:");
        Console.Write("Hora: ");
        hora = InputHora();
        Console.Write("Minuto: ");
        minuto = InputMinuto();
        DateTime horaSaida = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora, minuto, 0);
        if (horaEntrada.CompareTo(horaSaida) > 0)
        {
            horaSaida = horaSaida.AddDays(1);
        }
        return horaSaida;
    }

    public void Clear()
    {
        for(int i = 0; i < posicoesPreenchidas.Count; i++)
        {
            Carro c = array[posicoesPreenchidas[i][0]][posicoesPreenchidas[i][1]];
            Console.WriteLine($"\nPlaca: {c.GetPlaca()}");
            int hora = 0, minuto = 0;
            DateTime horaSaida = DefineHoraSaida(hora, minuto, c.GetTicket().GetHoraEntrada());
            c.GetTicket().SetHoraSaida(horaSaida);
            Console.WriteLine($"\n{c.GetTicket()}");
            array[posicoesPreenchidas[i][0]][posicoesPreenchidas[i][1]] = null;
            posicoesPreenchidas.RemoveAt(i);
            Clear();
        }
        return;
    }

    public bool Contains(Carro data)
    {
        int hash = Hashing(data);
        int linha = hash % array.Length;
        int coluna = hash;
        int tentativa = 1;
        int tentativaLinha = 1;
        while (array[linha][coluna] != null)
        {
            try
            {
                if (array[linha][coluna].GetPlaca() == data.GetPlaca())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            coluna = (hash + tentativa) % array[linha].Length;            
            tentativa++;
            if (tentativa > array[linha].Length)
            {
                tentativa = 1;
                linha++;
                tentativaLinha++;
                if (tentativaLinha > array.Length)
                {
                    return false;
                }
                linha = linha % array.Length;
                coluna = hash;
            }
        }
        return false;
    }

    public void Remove(int m, int n)
    {
        if (m < array.Length)
        {
            if (n < array[m].Length)
            {
                array[m][n] = null;
                foreach (int[] i in posicoesPreenchidas)
                {
                    if (i[0] == m && i[1] == n)
                    {
                        posicoesPreenchidas.Remove(i);
                        break;
                    }
                }
                count--;
            }
        }
    }

    public void Remove(Carro data)
    {
        int hash = Hashing(data);
        int linha = hash % array.Length;
        int coluna = hash;
        int tentativa = 1;
        int tentativaLinha = 1;
        while (array[linha][coluna] != null)
        {
            try
            {
                if (array[linha][coluna].GetPlaca() == data.GetPlaca())
                {
                    array[linha][coluna] = null;
                    foreach (int[] i in posicoesPreenchidas)
                    {
                        if (i[0] == linha && i[1] == coluna)
                        {
                            posicoesPreenchidas.Remove(i);
                            break;
                        }
                    }
                    count--;
                }
            }
            catch
            {
                return;
            }
            coluna = (hash + tentativa) % array[linha].Length;            
            tentativa++;
            if (tentativa > array[linha].Length)
            {
                tentativa = 1;
                linha++;
                tentativaLinha++;
                if (tentativaLinha > array.Length)
                {
                    return;
                }
                linha = linha % array.Length;
                coluna = hash;
            }
        }
    }

    public Carro Get(int m, int n)
    {
        return array[m][n];
    }

    public int[] IndexOf(Carro data)
    {
        int hash = Hashing(data);
        int linha = hash % array.Length;
        int coluna = hash;
        int tentativa = 1;
        int tentativaLinha = 1;
        while (array[linha][coluna] != null)
        {
            try
            {
                if (array[linha][coluna].GetPlaca() == data.GetPlaca())
                {
                    return new int[] {linha, coluna};
                }
            }
            catch
            {
                return new int[] {-1, -1};
            }
            coluna = (hash + tentativa) % array[linha].Length;
            tentativa++;
            if (tentativa > array[linha].Length)
            {
                tentativa = 1;
                linha++;
                tentativaLinha++;
                if (tentativaLinha > array.Length)
                {
                    return new int[] { -1, -1 };
                }
                linha = linha % array.Length;
                coluna = hash;
            }
        }
        return new int[] { -1, -1 };
    }

    public override string ToString()
    {
        string s = "";
        int size = array[0].Length;
        for (int i = 0; i < size; i++)
        {
            s += "|";
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j][i] != null)
                {
                    s += array[j][i] + "|";
                }
                else
                {
                    s += "       |";
                }
            }
            s += Environment.NewLine;
        }
        return s;
    }
}