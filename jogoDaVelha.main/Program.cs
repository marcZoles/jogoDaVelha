bool b = false;

Console.WriteLine("|=======================================================|");
Console.WriteLine("|||||||||||||||||||---MENU PRINCIPAL---||||||||||||||||||");
Console.WriteLine("|=======================================================|");

while (!b)
{

    Console.WriteLine("Sempre que quiser sair do jogo aperte 'S'");
    Console.WriteLine("Escolha o modo de jogo: ");
    Console.WriteLine("1 - Jogador vs Jogador");
    Console.WriteLine("2 - Jogador vs Computador");
    Console.WriteLine("3 - Sair do jogo");
    Console.WriteLine("4 - Exibir Ranking");
    Console.Write("Selecione: ");

    string modoDeJogo = Console.ReadLine();
    int modoDeJogoConvert = Convert.ToInt32(modoDeJogo);


    Console.Clear();
   

    switch (modoDeJogoConvert)
    {
        case 1:

            InicieJogadorVSJogador();
            break;

        case 2:

            InicieJogadorVSPc();
            break;

        case 3:

            Console.WriteLine("Jogo encerrado!");
            break;

        case 4:
            ExibirRanking();
            break;

        default:

            Console.WriteLine("Tecla inválida :(");
            break;
    }

    static void InicieJogadorVSJogador()
    {
        Console.WriteLine("|====================================|");
        Console.WriteLine("|Modo selecionado: Jogador vs Jogador|");
        Console.WriteLine("|====================================|");
    }

    static void InicieJogadorVSPc()
    {
        Console.WriteLine("|=======================================|");
        Console.WriteLine("|Modo selecionado: Jogador vs computador|");
        Console.WriteLine("|=======================================|");
        Console.WriteLine("Selecione a dificuldade do jogo: ");
        Console.WriteLine("D - Dificil");
        Console.WriteLine("F - Facil");
        string dificuldade = Console.ReadLine();
        Console.Clear();
        switch (dificuldade)
        {
            case "F":
                InicieModoFacil();
                break;
            case "D":
                InicieModoDificil();
                break;
            default:
                Console.WriteLine("Opção invalida");
                break;
        }

    }
    static void InicieModoFacil()
    {
        Console.WriteLine("==Modo Fácil===");
    }

    static void InicieModoDificil()
    {
        Console.WriteLine("==Modo Dificil==");
    }

    static void ExibirRanking()
    {
        Console.WriteLine("==Ranking top10 atualizadao==");
    }


    if (modoDeJogoConvert == 3)
    {
        b = true;
    }
}

// Filho do CAOS que acabou com nossa felicidade
// vvvvvvvvvvvvvv

// Teste pra ve se o bagua me aceita la

// ^^^^^^^^^^^^^^
// NÃO MEXER NO FILHO DO CAOS, ELE É O QUE FAZ O JOGO FUNCIONAR