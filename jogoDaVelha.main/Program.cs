



// =======================================================|

// Variáveis Globais


bool b = false;
char[,] tabuleiro = new char[3, 3];




// ========================================================|


Console.WriteLine("|=======================================================|");
Console.WriteLine("|||||||||||||||||||---MENU PRINCIPAL---||||||||||||||||||");
Console.WriteLine("|=======================================================|");

Console.WriteLine("Bem vindo ao jogo da velha!");
Console.WriteLine("Escolha o modo de jogo: ");
Console.WriteLine("1 - Jogador vs Jogador");
Console.WriteLine("2 - Jogador vs Computador");
Console.WriteLine("3 - Exibir Ranking");
Console.WriteLine("4 - Sair do Jogo");
Console.Write("Selecione: ");

string modoDeJogo = Console.ReadLine();
int modoDeJogoConvert = Convert.ToInt32(modoDeJogo);

do
{
   
    Console.Clear();
   

    switch (modoDeJogoConvert)
    {
        case 1:

            InicieJogadorVSJogador(tabuleiro);
            break;

        case 2:

            InicieJogadorVSPc();
            break;

        case 3:

            ExibirRanking();
            break;

        case 4:
            Console.WriteLine("Jogo encerrado!");
            break;

        default:

            Console.WriteLine("Tecla inválida :(");
            break;
    }

    static void JogoDaVelha(char[,] tabuleiro)
    {
        
    }

    static void InicieJogadorVSJogador(char[,] tabuleiro)
    {
        Console.WriteLine("|====================================|");
        Console.WriteLine("|Modo selecionado: Jogador vs Jogador|");
        Console.WriteLine("|====================================|");

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tabuleiro[i, j] = ' ';
            }
        }


        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(tabuleiro[i, j]);
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("-----");

        }


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

    // Ainda não estamos utilizando esses métodos, mas eles serão usados no futuro || Favor não apagar


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
        Console.WriteLine("==Ranking top10 atualizadao.com.br da silva==");
    }

    if (modoDeJogoConvert == 3) // Verificação para ver se o usuário escolheu sair do jogo
    {
        b = true;
    }
}

while (!b);









// ========================================================|
// Setor do nosso querido amigo, o Filho do CAOS

// Filho do CAOS que acabou com nossa felicidade
// vvvvvvvvvvvvvv

// Teste pra ve se o bagua me aceita la

// ^^^^^^^^^^^^^^
// NÃO MEXER NO FILHO DO CAOS, ELE É O QUE FAZ O JOGO FUNCIONAR

// ========================================================|