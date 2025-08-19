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
    string[,] tabuleiro = new string[3, 3];
    string turno = "X";
    int contadorTurnos = 0;
    int mioloDoTabuleiro = 1;


    //for que preenche a matriz com os numeros de 1 a 9, ou seja, o miolo do tabuleiro
    for (int i = 0; i < tabuleiro.GetLength(0); i++)//get lenght (pesquisar melhor sobre isso)
    { 
       for (int j = 0; j < tabuleiro.GetLength(1); j++)
        {
            tabuleiro[i, j] = mioloDoTabuleiro.ToString();//melhorar essa conversao para string se possível
            mioloDoTabuleiro++;
        }

    }
    // esse segundo for é quem imprime a matriz na tela
    for (int i = 0; i < tabuleiro.GetLength(0); i++)
    {
        for (int j = 0; j < tabuleiro.GetLength(1); j++)
        {
            Console.Write(tabuleiro[i, j]);
            if (j < 2) Console.Write("  | ");
            
        }
        Console.WriteLine();
        if (i < 2) Console.WriteLine("---+----+----");

    }

    // Esse while é o que controla o jogo, ele vai rodar enquanto o contador de turnos for menor que 9, ou seja, enquanto houver jogadas possíveis
    while (contadorTurnos < 9)
    {
        Console.WriteLine("|====================================|");
        Console.WriteLine($"|========| O jogador {turno} joga |========|");
        Console.WriteLine("|====================================|");
        string jogada = Console.ReadLine();

        // Aqui eu estou verificando se a jogada é válida, ou seja, se o jogador digitou um número de 1 a 9
        // Se for valida ele atualiza o tabuleiro
        for (int i = 0; i < tabuleiro.GetLength(0); i++)
                                                     
        {
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                if(jogada == tabuleiro[i, j])
                {
                    tabuleiro[i, j] = turno;

                }
            }

        }

        // Aqui eu estou imprimindo o tabuleiro atualizado na tela
        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                Console.Write(tabuleiro[i, j]);
                if (j < 2) Console.Write("  | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("---+----+----");
        }


        //comeco a verificar se o jogador ganhou, ou seja, se ele conseguiu fazer uma linha, coluna ou diagonal com o mesmo simbolo
        // ta fucionando, agora é so replicar para TODAS as as possibilidades de vitoria (emoji de caveira)
        if (contadorTurnos > 3)
        {
            if (tabuleiro[0, 0] == tabuleiro[0, 1] && tabuleiro[0, 1] == tabuleiro[0, 2])
            {
                Console.WriteLine($"Jogador {turno} VENCEUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU ");

            }

        }



            contadorTurnos++;
        if(contadorTurnos % 2 == 0) 
        {
            turno = "X";
        }
        else
        {
            turno = "O";
        }
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