// =======================================================|

// TRABALHO DE CONCLUSÃO DE MATÉRIA - JOGO DA VELHA EM C#
// FEITO POR: Gabriel Marczal; Bianca Michoski; Thais Colaço; José Guides

// ========================================================|

//                SETOR DE COMENTÁRIOS

// Falta criar o modo difícil do jogo contra o computador || - marcZ

// ========================================================|

// Variáveis Globais

Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

bool fimDeJogo = false;
string[,] tabuleiro = new string[3, 3];
int rankingJ1 = 0;
int rankingJ2 = 0;
int rankingPC = 0;
int rankingJvP = 0;
string centralizar = "centralizar";
int larguraConsole = Console.WindowWidth;
int espacosNecessarios = (larguraConsole - centralizar.Length) / 2;
string posicionar = new string(' ', espacosNecessarios);
bool sair = false;
int modoDeJogoConvert;
string resposta = "";

// ========================================================|

while (!fimDeJogo)
{
    Console.Clear();
    Console.WriteLine("|========================================================================|");
    Console.WriteLine("|                    TRABALHO DE CONCLUSÃO DE MATÉRIA                    |");
    Console.WriteLine("| FEITO POR: Gabriel Marczal; Bianca Michoski; Thais Colaço; José Guides |");
    Console.WriteLine("|========================================================================|");
    Console.WriteLine(" ");
    Console.WriteLine("|=======================================================|");
    Console.WriteLine("|||||||||||||||||||---MENU PRINCIPAL---||||||||||||||||||");
    Console.WriteLine("|=======================================================|");
    Console.WriteLine(" ");

   
        Console.WriteLine("Bem vindo ao jogo da velha!");
        Console.WriteLine("Escolha o modo de jogo: ");
        Console.WriteLine("1 - Jogador vs Jogador");
        Console.WriteLine("2 - Jogador vs Computador");
        Console.WriteLine("3 - Exibir Ranking");
        Console.WriteLine("4 - Sair do Jogo");
        Console.Write("Selecione: ");
        string modoDeJogo = Console.ReadLine();
        modoDeJogoConvert = Convert.ToInt32(modoDeJogo);

        if (!int.TryParse(modoDeJogo, out modoDeJogoConvert))
        {
            /* Esse if está em branco pois ele serve apenas para fazer a verificação se o usuário digitou um NUMERO
             * pq ele vai executar o código que está no switch, entao nao precisa de uma mensagem de erro
             */
        }

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
                ExibirRanking(rankingJ1, rankingJ2, rankingJvP, rankingPC);
                break;

            case 4:
                Console.WriteLine("Jogo encerrado!");
                modoDeJogoConvert = 4;
                fimDeJogo = true;
                break;

            default:

                Console.WriteLine("Opção inválida! Tente novamente digitando um valor númerico ou uma das opções abaixo");
                continue; /* O continue, como o nome diz continua o loop (esse codigo esta dentro de um while, para que o usuário
                       * consiga digitar outra opção válida
                      */
        
    }
    
    static void CriarTabuleiro(string[,] tabuleiro)
    {
        int mioloDoTabuleiro = 1;

        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                tabuleiro[i, j] = mioloDoTabuleiro.ToString();
                mioloDoTabuleiro++;
            }

        }
    }

    static void ImprimirTabuleiro(string[,] tabuleiro)
    {
        Console.Clear();

        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

                if (tabuleiro[i, j] == "X")
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }

                else if (tabuleiro[i, j] == "O")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.Write(tabuleiro[i, j]);

                if (j < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("  | ");

                }
            }

            Console.WriteLine();

            if (i < 2)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("---+----+----");
            }
        }

        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;
    }


//=========================================================================================//

    void InicieJogadorVSJogador() // Não alterar para "static void..." ISSO DESTRÓI O RANKING || - marcZ
    {
        bool continuar = true;

        do
        {
            string[,] tabuleiro = new string[3, 3];
            string turno = "X";
            int contadorTurnos = 0;

            Console.WriteLine("|=======================================|");
            Console.WriteLine("|  Modo selecionado: Jogador vs Jogador |");
            Console.WriteLine("|=======================================|");

            CriarTabuleiro(tabuleiro);
            ImprimirTabuleiro(tabuleiro);

            while (contadorTurnos < 9)
            {
                Console.WriteLine("|====================================|");
                Console.Write($" Vez do Jogador {turno}: ");
                string jogada = Console.ReadLine();
                Console.WriteLine("|====================================|");

                bool jogadaValida = false;

                while (!jogadaValida)
                {
                    if (int.TryParse(jogada, out int posicao) && posicao >= 1 && posicao <= 9)
                    {
                        int linha = (posicao - 1) / 3;
                        int coluna = (posicao - 1) % 3;

                        if (tabuleiro[linha, coluna] != "X" && tabuleiro[linha, coluna] != "O")
                        {
                            tabuleiro[linha, coluna] = turno;
                            jogadaValida = true;
                        }

                        else
                        {
                            Console.WriteLine("Esta posição já está ocupada! Tente novamente.");
                            jogada = Console.ReadLine();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Jogada inválida! Digite um número de 1 a 9.");
                        jogada = Console.ReadLine();
                    }
                }

                ImprimirTabuleiro(tabuleiro);

                if (contadorTurnos >= 4)
                {
                    string vencedor = VerificarVencedor(tabuleiro);

                    if (vencedor == "X" || vencedor == "O")
                    {
                        Console.WriteLine($"\nO Jogador ( {vencedor} ) Ganhou!");

                        if (vencedor == "X") rankingJ1++;
                        else rankingJ2++;

                        Console.WriteLine(" ");
                        Console.WriteLine("=============== Ranking ===============");
                        Console.WriteLine($"Jogador 1 (X): {rankingJ1} vitórias");
                        Console.WriteLine($"Jogador 2 (O): {rankingJ2} vitórias");
                        Console.WriteLine("=======================================");
                        Console.WriteLine(" ");
                        Console.WriteLine("Deseja jogar novamente no modo Jogador vs Jogador?");
                        Console.WriteLine("1 - Sim");
                        Console.WriteLine("2 - Não, voltar ao Menu Principal");
                        resposta = Console.ReadLine();

                        if (resposta == "1")
                        {
                            InicieJogadorVSJogador();
                        }

                        return;
                    }
                }

                contadorTurnos++;

                // alterna turno
                turno = (turno == "X") ? "O" : "X";

                if (contadorTurnos == 9)
                {
                    Console.WriteLine("Deu velha! Ninguém ganhou dessa vez :(");
                    Console.WriteLine("Deseja jogar novamente no modo Jogador vs Jogador?");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não, voltar ao Menu Principal");
                    string resposta = Console.ReadLine();

                    if (resposta != "1")
                    {
                        continuar = false;
                    }
                }
            }

        } while (continuar);
    }


    // ========================================================================================================//

    void InicieJogadorVSPc()
    {

        bool continuar = true;

        do
        {
            Console.Clear();
            Console.WriteLine("|=======================================|");
            Console.WriteLine("|Modo selecionado: Jogador vs computador|");
            Console.WriteLine("|=======================================|");
            Console.WriteLine("Selecione a dificuldade do jogo: ");
            Console.WriteLine("D - Dificil");
            Console.WriteLine("F - Facil");


            string dificuldade = Console.ReadLine().ToUpper();
            { // Precisa dessas chaves para o switch funcionar corretamente? || - marcZ //R: Sim, precisa porem para os cases não xD - Thais
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

        } while (!continuar);
    }

    // ========================================================================================================//

    void InicieModoFacil()
    {
        bool continuar = true;
        string[,] tabuleiro = new string[3, 3];
        string jogador1 = "X";
        string computador = "O";
        string turno = "X";
        int contadorTurnos = 0;

        string mensagemVitoriaJogador = "O Jogador ( X ) Ganhou!";
        string mensagemVitoriaPC = "O Computador ( O ) Ganhou!";

        Console.WriteLine("|-------------------|");
        Console.WriteLine("|=== Modo Fácil ====|");
        Console.WriteLine("|-------------------|");

        CriarTabuleiro(tabuleiro);
        ImprimirTabuleiro(tabuleiro);

        while (contadorTurnos < 9)
        {
            string jogada = "";

            if (turno == computador)
            {
                Console.WriteLine("|====================================================|");
                Console.WriteLine("|=========|        O computador joga       |=========|");
                Console.WriteLine("|====================================================|");
                Console.Write("O computador está pensando");
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(2000);

                for (int i = 0; i < 3 && jogada == ""; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (tabuleiro[i, j] != "X" && tabuleiro[i, j] != "O")
                        {
                            jogada = tabuleiro[i, j];
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("|====================================|");
                Console.Write($" Vez do Jogador {turno}: ");
                jogada = Console.ReadLine();
                Console.WriteLine("|====================================|");

                // Validação se jogada é valida
                bool jogadaValida = false;
                while (!jogadaValida)
                {
                    if (int.TryParse(jogada, out int posicao) && posicao >= 1 && posicao <= 9)
                    {
                        int linha = (posicao - 1) / 3;
                        int coluna = (posicao - 1) % 3;

                        if (tabuleiro[linha, coluna] != "X" && tabuleiro[linha, coluna] != "O")
                        {
                            jogadaValida = true;
                        }
                        else
                        {
                            Console.WriteLine("Esta posição já está ocupada! Tente novamente.");
                            jogada = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Jogada inválida! Digite um número de 1 a 9.");
                        jogada = Console.ReadLine();
                    }
                }
            }

            // Atualiza tabuleiro
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (jogada == tabuleiro[i, j])
                    {
                        tabuleiro[i, j] = turno;
                    }
                }
            }

            ImprimirTabuleiro(tabuleiro);

            if (contadorTurnos >= 4)
            {
                string vencedor = VerificarVencedor(tabuleiro);

                if (vencedor == "X" || vencedor == "O")
                {
                    if (vencedor == "X")
                    {
                        Console.WriteLine(mensagemVitoriaJogador);
                        rankingJvP++;

                        Console.WriteLine(" ");
                        Console.WriteLine("=============== Ranking ===============");
                        Console.WriteLine($"Jogador (X): {rankingJvP} vitórias");
                        Console.WriteLine($"Computador (O): {rankingPC} vitórias");
                        Console.WriteLine("=======================================");
                        Console.WriteLine(" ");
                        Console.WriteLine("Deseja jogar novamente no modo Jogador vs Computador?");
                        Console.WriteLine("1 - Sim");
                        Console.WriteLine("2 - Não, voltar ao Menu Principal");
                        string resposta = Console.ReadLine();
                        if(resposta == "1")
                        {
                            InicieJogadorVSPc();
                        }
                        else
                        {
                            continuar = false; //DDDDDDDDDDDDAAAAAAAAAAAAAAAAAALLLLLLLLLLLLEEEEEEEEEEEEEEEEEE, SEXTOOOOOOOUUUUUUUUUUUUU
                        }
       
                     }

                    else
                    {
                        Console.WriteLine(mensagemVitoriaPC);
                        rankingPC++;

                        Console.WriteLine(" ");
                        Console.WriteLine("=============== Ranking ===============");
                        Console.WriteLine($"Jogador (X): {rankingJvP} vitórias");
                        Console.WriteLine($"Computador (O): {rankingPC} vitórias");
                        Console.WriteLine("=======================================");
                        Console.WriteLine(" ");
                        Console.WriteLine("Deseja jogar novamente no modo Jogador vs Computador?");
                        Console.WriteLine("1 - Sim");
                        Console.WriteLine("2 - Não, voltar ao Menu Principal");
                        string resposta = Console.ReadLine();

                        if (resposta == "1")
                        {
                            InicieJogadorVSPc();
                        }
                        else
                        {
                           continuar = false;
                        }
    
                    }

                    return; // fim da partida
                }
            }

            contadorTurnos++;

            // Alterna turno
            turno = (turno == jogador1) ? computador : jogador1;

            if (contadorTurnos == 9)
            {
                Console.WriteLine("Deu velha! Ninguém ganhou dessa vez :(");
                return;
            }
        }
    }


    //=============================================================================================//

    static void InicieModoDificil()
    {
        Console.WriteLine("|--------------------|");
        Console.WriteLine("|=== Modo Dificil ===|");
        Console.WriteLine("|--------------------|");
    }

    //==============================================================================================//

    void ExibirRanking(int rankingJ1, int rankingJ2, int rankingJvP, int rankingPC)
    {
        Console.WriteLine("=============== Ranking ===============");
        Console.WriteLine($"Jogador 1 (X): {rankingJ1} vitórias");
        Console.WriteLine($"Jogador 2 (O): {rankingJ2} vitórias");
        Console.WriteLine("=======================================");
        Console.WriteLine($"Jogador (X): {rankingJvP} vitórias");
        Console.WriteLine($"Computador (O): {rankingPC} vitórias");
        Console.WriteLine("=======================================");
        Console.WriteLine("Pressione Enter para voltar ao menu principal...");
        Console.ReadLine();
    }

    //=============================================================================================//

    static string VerificarVencedor(string[,] tabuleiro)
    {
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[i, 0] == tabuleiro[i, 1] && tabuleiro[i, 1] == tabuleiro[i, 2])
            {
                return tabuleiro[i, 0]; // "X" ou "O"
            }
        }

        for (int j = 0; j < 3; j++)
        {
            if (tabuleiro[0, j] == tabuleiro[1, j] && tabuleiro[1, j] == tabuleiro[2, j])
            {
                return tabuleiro[0, j];
            }
        }

        if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2])
        {
            return tabuleiro[0, 0];
        }

        if (tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0])
        {
            return tabuleiro[0, 2];
        }

        // Nenhum vencedor
        return "";
    }


    //=============================================================================================//

    if (modoDeJogoConvert == 4)
    {
        fimDeJogo = true;
    }
} // Fim do while principal




// ========================================================|

// Setor do nosso querido amigo, o Filho do CAOS

// Filho do CAOS que acabou com nossa felicidade
// vvvvvvvvvvvvvv

// Teste pra ve se o bagua me aceita la

// ^^^^^^^^^^^^^^
// NÃO MEXER NO FILHO DO CAOS, ELE É O QUE FAZ O JOGO FUNCIONAR

// ========================================================|