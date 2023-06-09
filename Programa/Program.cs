﻿namespace Controle_de_Estacionamento.Programa;

internal class Program
{
    public static string InputPlaca()
    {
        string placa = Console.ReadLine();
        if (placa.Length != 7)
        {
            Console.WriteLine("Tamanho de Placa Inválido");
            return InputPlaca();
        }
        else
        {
            string modelo = "";
            foreach(char c in placa)
            {
                modelo += char.IsAsciiLetter(c) ? "L" : char.IsAsciiDigit(c) ? "N" : "NA";
            }
            if(modelo != "LLLNLNN") 
            {
                Console.WriteLine("Modelo de Placa Inválido. Insira Apenas Placas no Novo Modelo Mercosul");
                return InputPlaca();
            }
            return placa;
        }
    }

    public static int Input()
    {
        int input = 0;
        try
        {
            input = Convert.ToInt32(Console.ReadLine());
            return input == 0 || input == 1 || input == 2 || input == 3 || input == 4 || input == 5 || input == 6? input : Input();
        } catch 
        {
            Console.WriteLine("Insira Apenas Números");
            return Input();
        }
    }

    public static int InputHora()
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

    public static int InputMinuto()
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

    public static int[] InputMxN()
    {
        string s = Console.ReadLine();
        try
        {
            string[] parts = s.Split(" ");
            return new int[] { Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1])};
        }
        catch
        {
            try
            {
                string[] parts = s.Split("x");
                return new int[] { Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]) };
            }
            catch{
                try
                {
                    char[] parts = s.ToCharArray();
                    return new int[] { Convert.ToInt32(Convert.ToString(parts[0])), Convert.ToInt32(Convert.ToString(parts[1])) };
                }
                catch
                {
                    return InputMxN();
                }
            }
        }
    }

    public static DateTime DefineHoraSaida(int hora, int minuto, DateTime horaEntrada)
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

    public static void Main(string[] args)
    {
        int controle = -1;
        Console.WriteLine("Bem Vindo ao Gerenciador de Estacionamento!");
        Console.WriteLine("Qual o tamanho do Estacionamento? (mxn)");
        int[] mxn = InputMxN();
        Estacionamento estacionamento = new Estacionamento(mxn[0], mxn[1]);
        while (controle != 0) 
        {
            Console.WriteLine("O que deseja fazer?\n1 - Inserir | 2 - Remover\n3 - Exibir Detalhes de um Carro | 4 - Mostrar Vagas\n5 - Remover Todos | 6 - Criar Novo Estacionamento\n0 - Encerrar Programa");
            controle = Input();
            if(controle == 1) 
            {
                Console.WriteLine("Digite a Placa do Carro");
                string placa = InputPlaca();
                Console.WriteLine("Digite a Hora e o Minuto de Entrada:");
                Console.Write("Hora: ");
                int hora = InputHora();
                Console.Write("Minuto: ");
                int minuto = InputMinuto();
                estacionamento.InserirCarro(new Carro(placa), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora, minuto, 0));
                Console.WriteLine($"\n{estacionamento}");
            }
            if(controle == 2)
            {
                Console.WriteLine("Digite a Placa do Carro");
                string placa = InputPlaca();
                if (estacionamento.GetVagas().Contains(new Carro(placa))){
                    int hora = 0, minuto = 0;
                    int[] index = estacionamento.GetVagas().IndexOf(new Carro(placa));
                    DateTime horaSaida = DefineHoraSaida(hora, minuto, estacionamento.GetVagas().Get(index[0], index[1]).GetTicket().GetHoraEntrada());
                    estacionamento.RemoverCarro(new Carro(placa), horaSaida);
                    Console.WriteLine($"\n{estacionamento}");
                }
                else
                {
                    Console.WriteLine("Carro Não Encontrado");
                }
            }
            if (controle == 3)
            {
                Console.WriteLine("Digite a Placa do Carro");
                string placa = InputPlaca();
                if(estacionamento.GetVagas().Contains(new Carro(placa))){
                    Console.WriteLine($"\n{estacionamento.ExibirDetalhes(new Carro(placa))}\n");
                }                
            }
            if (controle == 4)
            {
                Console.WriteLine($"\n{estacionamento}");
            }
            if(controle == 5)
            {
                estacionamento.RemoverTodos();
            }
            if(controle == 6)
            {
                Console.WriteLine("Qual o tamanho do Estacionamento? (mxn)");
                mxn = InputMxN();
                estacionamento = new Estacionamento(mxn[0], mxn[1]);
            }
        }
    }
}
