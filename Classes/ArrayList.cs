namespace Controle_de_Estacionamento.Classes;

public class ArrayList<T>
{
    private T[][] array;

    private int count;

    public ArrayList(int m, int n)
    {
        array = new T[m][];
        for(int i = 0; i < m; i++)
        {
            array[i] = new T[n];
        }
        count = 0;
    }


    public void Add(T data)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for(int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] == null)
                {
                    array[i][j] = data;
                    count++;
                    return;
                }
            }
        }
    }

    public int Count()
    {
        return count;
    }

    public void Clear()
    {
        for(int i = 0; i < array.Length; i++)
        {
            for(int j = 0; j < array[i].Length; j++)
            {
                array[i][j] = default(T);
            }
        }
    }

    public bool Contains(T data)
    {
        for (int i = 0; i < count; i++)
        {
            for(int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j].Equals(data))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void Remove(int m, int n)
    {
        if(m < array.Length)
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
        for (int i = 0; i < array.Length; i++)
        {
            for(int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j].Equals(data))
                {
                    array[i][j] = default(T);
                    count--;
                    return;
                }
            }
        }
    }

    public T Get(int m, int n)
    {
        return array[m][n];
    }

    public int[] IndexOf(T data)
    {
        for (int i = 0; i < count; i++)
        {
            for(int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j].Equals(data))
                {
                    return new int[] {i, j };
                    
                }
            }
        }
        return new int[] { -1, -1 };
    }

    public override string ToString()
    {
        String s = "[";
        for (int i = 0; i < array.Length; i++)
        {
            s += "[";
            try
            {
                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    s += $"{array[i][j]}, ";
                }
                s += $"{array[i][array[i].Length - 1]}]";
            }
            catch
            {
                s += "]";
            }
        }
        return $"{s}]";
    }
}
