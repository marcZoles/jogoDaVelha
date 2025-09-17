// =======================================================|

// TRABALHO DE CONCLUSÃO DE MATÉRIA - JOGO DA VELHA EM C#
// FEITO POR: Gabriel Marczal; Bianca Michoski; Thais Colaço; José Guides

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
bool sair = false;
int modoDeJogoConvert;
string resposta = "";
string centralizar = "centralizar";
int larguraConsole = Console.WindowWidth;

float espacosNecessarios1 = (larguraConsole - centralizar.Length) / 5f;
string posicionar1 = new string(' ', (int)espacosNecessarios1);

float espacosNecessarios2 = (larguraConsole - centralizar.Length) / 3.7f;
string posicionar2 = new string(' ', (int)espacosNecessarios2);

float espacosNecessarios3 = (larguraConsole - centralizar.Length) / 2.4f;
string posicionar3 = new string(' ', (int)espacosNecessarios3);

// ========================================================|
for (int i = 1; i >= 1; i++)
{
    Console.Clear();
    Console.WriteLine($"{posicionar1}|========================================================================|");
    Console.WriteLine($"{posicionar1}|                    TRABALHO DE CONCLUSÃO DE MATÉRIA                    |");
    Console.WriteLine($"{posicionar1}| FEITO POR: Gabriel Marczal; Bianca Michoski; Thais Colaço; José Guides |");
    Console.WriteLine($"{posicionar1}|========================================================================|\n");
    Console.WriteLine($"{posicionar2}|=======================================================|");
    Console.WriteLine($"{posicionar2}|||||||||||||||||||---MENU PRINCIPAL---||||||||||||||||||");
    Console.WriteLine($"{posicionar2}|=======================================================|\n");
    Console.WriteLine($"{posicionar3}Bem vindo ao jogo da velha!\n");
    Console.WriteLine($"{posicionar3} === INSTRUÇÕES DO JOGO === \n");
    Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine("|1. O tabuleiro é composto por números de 1 a 9, onde cada número representa sua respectiva posição no tabuleiro.    |");
    Console.WriteLine("|2. Para fazer sua jogada, basta digitar o número correspondente à posição desejada no tabuleiro.                    |");
    Console.WriteLine("|3. O jogador 1 sempre será identificado pelo símbolo 'X' e o jogador 2 (ou computador) pelo símbolo 'O'.            |");
    Console.WriteLine("|4. No modo Jogador vs Computador, cada jogada do computador terá um delay de 3s até ele realizar a jogada.          |");
    Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------|\n");

    if (i > 1)
    {
        break;
    }
}

while (!fimDeJogo)
{
    Console.WriteLine("Escolha o modo de jogo: ");
    Console.WriteLine("1 - Jogador vs Jogador");
    Console.WriteLine("2 - Jogador vs Computador");
    Console.WriteLine("3 - Exibir Ranking");
    Console.WriteLine("4 - Sair do Jogo");
    Console.Write("Selecione: \n");
    string modoDeJogo = Console.ReadLine();
    bool modoDeJogoInvalido = int.TryParse(modoDeJogo, out modoDeJogoConvert);

    if(modoDeJogoInvalido == false)
    {
        Console.Clear();
        Console.WriteLine("Opção inválida! Tente novamente digitando um valor númerico ou uma das opções abaixo\n\n");

        continue;
    }



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

        void InicieJogadorVSJogador()
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
                            Console.WriteLine("=======================================\n");
                            JogueNovamente();
                            resposta = Console.ReadLine();
                      

                            if (resposta == "1")
                            {
                                InicieJogadorVSJogador();
                            }

                            else
                            {
                                mostreMenu();
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
                        JogueNovamente();

                    string resposta = Console.ReadLine();

                        if (resposta == "1")
                        {
                            InicieJogadorVSJogador();
                        }
                    else
                    {
                        mostreMenu();
                    }
                        return;
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
                {
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
                            Console.WriteLine("=======================================\n");
                           JogueNovamente();
                            string resposta = Console.ReadLine();

                            if (resposta == "1")
                            {
                                InicieJogadorVSPc();
                            }

                            else
                            {
                            mostreMenu();
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
                            Console.WriteLine("=======================================\n");
                            
                            JogueNovamente();
                            string resposta = Console.ReadLine();

                            if (resposta == "1")
                            {
                                InicieJogadorVSPc();
                            }

                            else
                            {
                               mostreMenu();
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
                    JogueNovamente();
                string resposta = Console.ReadLine();

                if (resposta == "1")
                {
                    InicieJogadorVSPc();
                }

                else
                {
                    mostreMenu();
                }

                return;
                return; // precisa desse return para sair do while?
            } 
            }
        }


    //=============================================================================================//

    void InicieModoDificil()
    {
        string[,] tabuleiro = new string[3, 3];
        string jogador1 = "X";
        string computador = "O";
        string turno = "X";
        int contadorTurnos = 0;

        string mensagemVitoriaJogador = "O Jogador ( X ) Ganhou!";
        string mensagemVitoriaPC = "O Computador ( O ) Ganhou!";

        Console.WriteLine("|---------------------|");
        Console.WriteLine("|=== Modo Difícil ====|");
        Console.WriteLine("|---------------------|");

        CriarTabuleiro(tabuleiro);
        ImprimirTabuleiro(tabuleiro);

        while (contadorTurnos < 9)
        {
            string jogada = "";

            if (turno == computador)
            {
                Console.WriteLine("|====================================================|");
                Console.WriteLine("|=========|        Vez do Computador       |=========|");
                Console.WriteLine("|====================================================|");
                Console.Write("O computador está pensando");
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(2000);

                // Calcula a melhor jogada com Minimax
                (int linha, int coluna) mov = MelhorJogada(tabuleiro, computador, jogador1);
                // pega a representação textual da posição (1..9) para reusar seu código de update do tabuleiro
                jogada = tabuleiro[mov.linha, mov.coluna];
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

            // Atualiza tabuleiro (mesma lógica do modo fácil)
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
                        Console.WriteLine("=======================================\n");
                        JogueNovamente();
                        string resposta = Console.ReadLine();

                        if (resposta == "1") 
                        { 
                        InicieJogadorVSPc();
                        }

                        else 
                        { 
                         mostreMenu();
                        }
                    }

                    else if ( vencedor == "O")
                    {
                        Console.WriteLine(mensagemVitoriaPC);
                        rankingPC++;

                        Console.WriteLine(" ");
                        Console.WriteLine("=============== Ranking ===============");
                        Console.WriteLine($"Jogador (X): {rankingJvP} vitórias");
                        Console.WriteLine($"Computador (O): {rankingPC} vitórias");
                        Console.WriteLine("=======================================\n");

                        JogueNovamente();
                        string resposta = Console.ReadLine();

                        if (resposta == "1")
                        {
                            InicieJogadorVSPc();
                        }

                        else
                        {
                            mostreMenu();
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
                JogueNovamente();
                string resposta = Console.ReadLine();

                if (resposta == "1")
                {
                    InicieJogadorVSPc();
                }

                else
                {
                    mostreMenu();
                }
                return;
            }
        }
    }

    // ------------------ MelhorJogada (usa Minimax) ------------------ //


    (int, int) MelhorJogada(string[,] tabuleiro, string computador, string jogador)
    {
        int melhorValor = int.MinValue;
        (int, int) melhorMovimento = (-1, -1);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tabuleiro[i, j] != "X" && tabuleiro[i, j] != "O")
                {
                    string temp = tabuleiro[i, j];
                    tabuleiro[i, j] = computador;

                    int valor = Minimax(tabuleiro, 0, false, computador, jogador, int.MinValue, int.MaxValue);

                    tabuleiro[i, j] = temp;

                    if (valor > melhorValor)
                    {
                        melhorValor = valor;
                        melhorMovimento = (i, j);
                    }
                }
            }
        }

        // fallback se nada encontrado (não deve ocorrer)
        if (melhorMovimento.Item1 == -1)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (tabuleiro[i, j] != "X" && tabuleiro[i, j] != "O")
                        return (i, j);
        }

        return melhorMovimento;
    }

    // ------------------ Minimax com poda alfa-beta ------------------ //


    int Minimax(string[,] tabuleiro, int profundidade, bool isMaximizing, string computador, string jogador, int alpha, int beta)
    {
        // Estado terminal?
        string vencedor = VerificarVencedor(tabuleiro);
        if (vencedor == computador) return 10 - profundidade; // quanto mais cedo ganhar, melhor
        if (vencedor == jogador) return profundidade - 10;     // quanto mais tarde perder, "menos ruim"

        // Tabuleiro cheio -> empate
        bool cheio = true;
        for (int r = 0; r < 3; r++)
            for (int c = 0; c < 3; c++)
                if (tabuleiro[r, c] != "X" && tabuleiro[r, c] != "O")
                    cheio = false;

        if (cheio) return 0;

        if (isMaximizing)
        {
            int melhor = int.MinValue;
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (tabuleiro[r, c] != "X" && tabuleiro[r, c] != "O")
                    {
                        string temp = tabuleiro[r, c];
                        tabuleiro[r, c] = computador;

                        int valor = Minimax(tabuleiro, profundidade + 1, false, computador, jogador, alpha, beta);

                        tabuleiro[r, c] = temp;

                        if (valor > melhor) melhor = valor;
                        if (valor > alpha) alpha = valor;
                        if (beta <= alpha) return melhor; // poda
                    }
                }
            }
            return melhor;
        }

        else
        {
            int pior = int.MaxValue;
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (tabuleiro[r, c] != "X" && tabuleiro[r, c] != "O")
                    {
                        string temp = tabuleiro[r, c];
                        tabuleiro[r, c] = jogador;

                        int valor = Minimax(tabuleiro, profundidade + 1, true, computador, jogador, alpha, beta);

                        tabuleiro[r, c] = temp;

                        if (valor < pior) pior = valor;
                        if (valor < beta) beta = valor;
                        if (beta <= alpha) return pior; // poda
                    }
                }
            }
            return pior;
        }
    }


    //==============================================================================================//

    void ExibirRanking(int rankingJ1, int rankingJ2, int rankingJvP, int rankingPC)
    {
        Console.Clear();
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

        void JogueNovamente()
        {
            Console.WriteLine("Deseja jogar novamente?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não, voltar ao Menu Principal");
        }

        void mostreMenu()
        {
            Console.Clear();

            Console.WriteLine($"{posicionar1}|========================================================================|");
            Console.WriteLine($"{posicionar1}|                    TRABALHO DE CONCLUSÃO DE MATÉRIA                    |");
            Console.WriteLine($"{posicionar1}| FEITO POR: Gabriel Marczal; Bianca Michoski; Thais Colaço; José Guides |");
            Console.WriteLine($"{posicionar1}|========================================================================|\n");
            Console.WriteLine($"{posicionar3} === INSTRUÇÕES DO JOGO === \n");
            Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|1. O tabuleiro é composto por números de 1 a 9, onde cada número representa sua respectiva posição no tabuleiro.    |");
            Console.WriteLine("|2. Para fazer sua jogada, basta digitar o número correspondente à posição desejada no tabuleiro.                    |");
            Console.WriteLine("|3. O jogador 1 sempre será identificado pelo símbolo 'X' e o jogador 2 (ou computador) pelo símbolo 'O'.            |");
            Console.WriteLine("|4. No modo Jogador vs Computador, cada jogada do computador terá um delay de 3s até ele realizar a jogada.          |");
            Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------|\n");
            Console.WriteLine($"{posicionar2}|=======================================================|");
            Console.WriteLine($"{posicionar2}|||||||||||||||||||---MENU PRINCIPAL---||||||||||||||||||");
            Console.WriteLine($"{posicionar2}|=======================================================|\n");
            
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