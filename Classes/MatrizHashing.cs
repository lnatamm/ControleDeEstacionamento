namespace Controle_de_Estacionamento.Classes;
public class MatrizHashing
{
    private Carro[][] array;

    private List<int[]> posicoesPreenchidas;

    private int count;

    public MatrizHashing(int m, int n)
    {
        array = new Carro[m][];
        posicoesPreenchidas = new List<int[]>();
        for (int i = 0; i < m; i++)
        {
            array[i] = new Carro[n];
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

    private int InputTime()
    {
        int input = 0;
        try
        {
            input = Convert.ToInt32(Console.ReadLine());
            return input >= 0 ? input : InputTime();
        }
        catch
        {
            Console.WriteLine("Insira Apenas Números");
            return InputTime();
        }
    }

    public void Clear()
    {
        for(int i = 0; i < posicoesPreenchidas.Count; i++)
        {
            Console.WriteLine($"Placa: {array[posicoesPreenchidas[i][0]][posicoesPreenchidas[i][1]].GetPlaca()}");
            Console.WriteLine("Digite a Hora e o Minuto de Saída");
            Console.Write("Hora: ");
            int hora = InputTime();
            Console.Write("Minuto: ");
            int minuto = InputTime();
            array[posicoesPreenchidas[i][0]][posicoesPreenchidas[i][1]].GetTicket().SetHoraSaida(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora, minuto, 0));
            Console.WriteLine(array[posicoesPreenchidas[i][0]][posicoesPreenchidas[i][1]].GetTicket());
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
        for (int i = 0; i < array.Length; i++)
        {
            s += "[";
            for (int j = 0; j < array[i].Length - 1; j++)
            {
                s += array[i][j] + ", ";
            }
            s += $"{array[i][array[i].Length - 1]}]{Environment.NewLine}";
        }
        return s;
    }
}
