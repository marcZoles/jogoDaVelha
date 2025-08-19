// =======================================================|

// Variáveis Globais


bool b = false;
char[,] tabuleiro = new char[3, 3]; // a virgula [,] indica que é uma matriz e não um array


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
   
    Console.Clear();
   

    switch (modoDeJogoConvert) // Todas as opções do Switch estão rodando em loop infinito, ainda não consegui resolver || - marcZ
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
            modoDeJogoConvert = 4;
            b = true; // encerra o loop "do while" (se pá) || - marcZ
            break;

        case 5:
        JogoDaVelha();
            break;

        default:

            Console.WriteLine("Tecla inválida, tente novamente.");
            break;
    }
static void JogoDaVelha()
{
    string[,] tabuleiro = new string[3, 3]; // a virgula [,] indica que é uma matriz e não um array
    string turno = "X";
    int contadorTurnos = 0;
    int mioloDoTabuleiro = 1;



    for (int i = 0; i < tabuleiro.GetLength(0); i++)//get lenght começa na posicao que eu quero (pesquisar melhor sobre isso)  // linha
    { 
       for (int j = 0; j < tabuleiro.GetLength(1); j++) // coluna
        {
            tabuleiro[i, j] = " ";
        }

    }
    // esse segundo for é quem imprime a matriz na tela
    for (int i = 0; i < tabuleiro.GetLength(0); i++) //getlenght(0) eu estou selecionando a linha da matriz
    {
        for (int j = 0; j < tabuleiro.GetLength(1); j++)
        {
            Console.Write(tabuleiro[i, j]); //interessane usar o console.write apenas pq se nao fica tudo um em baixo do outro
            Console.Write(mioloDoTabuleiro);
            if (j < 2) Console.Write("  | ");
            mioloDoTabuleiro++;
        }
        Console.WriteLine();
        if (i < 2) Console.WriteLine("----+-----+-----");

    }

    while(contadorTurnos < 9)
    {
        string jogada; //lembrar de colocar variavel em branco do jeito do giancarlo
        Console.WriteLine("O jogador X comeca");
        jogada = Console.ReadLine();



        for (int i = 0; i < tabuleiro.GetLength(0); i++) 
        {
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                Console.Write(tabuleiro[i, j]);
                Console.Write(mioloDoTabuleiro);
                if (j < 2) Console.Write("  | ");
                mioloDoTabuleiro++;
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("----+-----+-----");

        }


        contadorTurnos++;
    }


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
                    if (j < 2) Console.Write(" | ");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("---+---+---");

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

    if (modoDeJogoConvert == 4) // Verificação para ver se o usuário escolheu sair do jogo
    {
        b = true;
    }




// ========================================================|
// Setor do nosso querido amigo, o Filho do CAOS

// Filho do CAOS que acabou com nossa felicidade
// vvvvvvvvvvvvvv

// Teste pra ve se o bagua me aceita la

// ^^^^^^^^^^^^^^
// NÃO MEXER NO FILHO DO CAOS, ELE É O QUE FAZ O JOGO FUNCIONAR

// ========================================================|