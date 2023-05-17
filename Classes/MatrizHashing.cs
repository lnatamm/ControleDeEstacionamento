namespace Controle_de_Estacionamento.Classes;
public class MatrizHashing<T>
{
    private T[][] array;

    private int count;

    public MatrizHashing(int m, int n)
    {
        array = new T[m][];
        for (int i = 0; i < m; i++)
        {
            array[i] = new T[n];
        }
        count = 0;
    }

    private int Hashing(T data)
    {
        return data.GetHashCode() % array.Length;
    }

    public void Add(T data)
    {
        int hash = Hashing(data);
        int index = hash;
        int i = 1;
        while (array[index / array[0].Length][index % array[0].Length] != null)
        {
            index = (hash + (i * i)) % (array.Length * array[0].Length);
            i++;
            if(i > array.Length * array[0].Length)
            {
                return;
            }
        }
        array[index / array[0].Length][index % array[0].Length] = data;
    }

    public int Count()
    {
        return count;
    }

    public void Clear()
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                array[i][j] = default(T);
            }
        }
    }

    public bool Contains(T data)
    {
        int hash = Hashing(data);
        int index = hash;
        int i = 1;
        while (array[index / array[0].Length][index % array[0].Length] != null)
        {
            if (array[index / array[0].Length][index % array[0].Length].Equals(data)){
                return true;
            }
            index = (hash + (i * i)) % (array.Length * array[0].Length);
            i++;
            if (i > array.Length * array[0].Length)
            {
                return false;
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
                array[m][n] = default(T);
                count--;
            }
        }
    }

    public void Remove(T data)
    {
        int hash = Hashing(data);
        int index = hash;
        int i = 1;
        while (array[index / array[0].Length][index % array[0].Length] != null)
        {
            if (array[index / array[0].Length][index % array[0].Length].Equals(data))
            {
                array[index / array[0].Length][index % array[0].Length] = default(T);
                return;
            }
            index = (hash + (i * i)) % (array.Length * array[0].Length);
            i++;
            if (i > array.Length * array[0].Length)
            {
                return;
            }
        }
    }

    public T Get(int m, int n)
    {
        return array[m][n];
    }

    public int[] IndexOf(T data)
    {
        int hash = Hashing(data);
        int index = hash;
        int i = 1;
        while (array[index / array[0].Length][index % array[0].Length] != null)
        {
            if (array[index / array[0].Length][index % array[0].Length].Equals(data))
            {
                return new int[] { index / array[0].Length, index % array[0].Length };
            }
            index = (hash + (i * i)) % (array.Length * array[0].Length);
            i++;
            if (i > array.Length * array[0].Length)
            {
                return new int[] { -1, -1 };
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
