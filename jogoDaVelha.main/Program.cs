// =======================================================|

// TRABALHO DE CONCLUSÃO DE MATÉRIA - JOGO DA VELHA EM C#
// FEITO POR: Gabriel Marczal; Bianca Michoski; Thais Colaço; José Guides

// ========================================================|

//                SETOR DE COMENTÁRIOS

// Já estou dando uma olhada em como fazer o ranking funcionar sem problemas, até então, favor não mexer nesse método || - marcZ
// Incluir verificação de jogada inválida (ex: letra, número fora do intervalo, casa já ocupada) no modo Jogador VS PC || - marcZ


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
string centralizar = "centralizar"; //string para servir de exemplo de centralização
int larguraConsole = Console.WindowWidth;// faz a contagem da largura do console, ou seja, quantos caracteres cabem na tela do console
int espacosNecessarios = (larguraConsole - centralizar.Length) / 2; // calcula quantos espaços são necessários para centralizar a string "centralizar" na tela do console
string posicionar = new string(' ', espacosNecessarios);// cria uma string com os espaços necessários para centralizar a string "centralizar" na tela do console

// ========================================================|

while (!fimDeJogo)
{
    Console.Clear();
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
    int modoDeJogoConvert;

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
            InicieJogadorVSJogador(ref rankingJ1, ref rankingJ2);
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




    static void InicieJogadorVSJogador(ref int rankingJ1, ref int rankingJ2)
    {
        //int rankingJ1 = 0;
        //int rankingJ2 = 0;

        bool continuar = true;

        do
        {

            string[,] tabuleiro = new string[3, 3];
            string turno = "X";
            int contadorTurnos = 0;
            string mensagemVitoria = "O Jogador ( X ) Ganhou!";
            string mensagemVitoria2 = "O Jogador ( O ) Ganhou!";

            Console.WriteLine("|=======================================|");
            Console.WriteLine("|  Modo selecionado: Jogador vs Jogador |");
            Console.WriteLine("|=======================================|");

            //=======================================================================//

            CriarTabuleiro(tabuleiro);

            ImprimirTabuleiro(tabuleiro);

            while (contadorTurnos < 9)
            {
                Console.WriteLine("|====================================|");
                Console.Write($" Vez do Jogador {turno}: ");
                string jogada = Console.ReadLine();
                Console.WriteLine("|====================================|");



                // Comentários explicativos do que cada parte do código faz || - Bianca
                // Aqui eu vou verificar se a jogada é válida, ou seja, se o jogador digitou um número de 1 a 9 e se não está tentando ocupar um lugar que já está preenchido
                // Se for valida ele vai atualizar o tabuleiro

                // Variavel boleana para verificar se é verdadeiro ou falso
                // Começa no falso pois ainda não fizemos nenhuma jogada
                bool jogadaValida = false;

                // Enquanto o usuario não fizar uma jogada válida, o programa não vai sair desse while
                while (!jogadaValida)
                {
                    // Verifica se a jogada é um número e se está dentro do intervalo de 1 a 9
                    if (int.TryParse(jogada, out int posicao) && posicao >= 1 && posicao <= 9)
                    {

                        // Converte a posição para índices da matriz
                        int linha = (posicao - 1) / 3;
                        int coluna = (posicao - 1) % 3;

                        // Verifica se a posição já está sendo ocupada ocupada, e se não estiver ele atualiza o tabuleiro
                        if (tabuleiro[linha, coluna] != "X" && tabuleiro[linha, coluna] != "O")
                        {
                            tabuleiro[linha, coluna] = turno; // Atualiza o tabuleiro com o símbolo do jogador
                            jogadaValida = true; // Marca a jogada como válida
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

                //comeco a verificar se o jogador ganhou, ou seja, se ele conseguiu fazer uma linha, coluna ou diagonal com o mesmo simbolo
                // ta fucionando, agora é so replicar para TODAS as as possibilidades de vitoria (emoji de caveira)
                if (contadorTurnos > 3)
                {

                    for (int i = 0; i < 3; i++) // Verifica linhas
                    {
                        if (tabuleiro[i, 0] == tabuleiro[i, 1] && tabuleiro[i, 1] == tabuleiro[i, 2])
                        {
                            if (turno == "X")
                            {
                                Console.WriteLine(mensagemVitoria);
                                rankingJ1++;

                                Console.WriteLine("Deseja jogar novamente no modo Jogador vs Jogador?");
                                Console.WriteLine("1 - Sim");
                                Console.WriteLine("2 - Não, voltar ao Menu Principal");
                                string resposta = Console.ReadLine();

                                if (resposta == "1")
                                {
                                    Console.Clear();
                                    InicieJogadorVSJogador(ref rankingJ1, ref rankingJ2);

                                }
                            }

                            else
                            {
                                Console.WriteLine(mensagemVitoria2);
                                rankingJ2++;

                                Console.WriteLine("Deseja jogar novamente no modo Jogador vs Jogador?");
                                Console.WriteLine("1 - Sim");
                                Console.WriteLine("2 - Não, voltar ao Menu Principal");
                                string resposta = Console.ReadLine();

                                if (resposta == "1")
                                {
                                    InicieJogadorVSJogador(ref rankingJ1, ref rankingJ2);

                                }
                            }
                            return;
                        }


                    }

                    for (int j = 0; j < 3; j++) // Verifica colunas
                    {
                        if (tabuleiro[0, j] == tabuleiro[1, j] && tabuleiro[1, j] == tabuleiro[2, j])
                        {
                            if (turno == "X")
                            {
                                Console.WriteLine(mensagemVitoria);
                                rankingJ1++;

                                Console.WriteLine("Deseja jogar novamente no modo Jogador vs Jogador?");
                                Console.WriteLine("1 - Sim");
                                Console.WriteLine("2 - Não, voltar ao Menu Principal");
                                string resposta = Console.ReadLine();

                                if (resposta == "1")
                                {
                                    InicieJogadorVSJogador(ref rankingJ1, ref rankingJ2);
                                }
                            }

                            else
                            {
                                Console.WriteLine(mensagemVitoria2);
                                rankingJ2++;

                                Console.WriteLine("Deseja jogar novamente no modo Jogador vs Jogador?");
                                Console.WriteLine("1 - Sim");
                                Console.WriteLine("2 - Não, voltar ao Menu Principal");
                                string resposta = Console.ReadLine();

                                if (resposta == "1")
                                {
                                    InicieJogadorVSJogador(ref rankingJ1, ref rankingJ2);
                                }
                            }

                            return;
                        }
                    }

                    // Verifica se a diagonal principal está completa
                    if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2])
                    {
                        if (turno == "X")
                        {
                            Console.WriteLine(mensagemVitoria);
                            rankingJ1++;

                            Console.WriteLine("Deseja jogar novamente no modo Jogador vs Jogador?");
                            Console.WriteLine("1 - Sim");
                            Console.WriteLine("2 - Não, voltar ao Menu Principal");
                            string resposta = Console.ReadLine();

                            if (resposta == "1")
                            {
                                InicieJogadorVSJogador(ref rankingJ1, ref rankingJ2);
                            }
                        }

                        else
                        {
                            Console.WriteLine(mensagemVitoria2);
                            rankingJ2++;

                            Console.WriteLine("Deseja jogar novamente no modo Jogador vs Jogador?");
                            Console.WriteLine("1 - Sim");
                            Console.WriteLine("2 - Não, voltar ao Menu Principal");
                            string resposta = Console.ReadLine();

                            if (resposta == "1")
                            {
                                InicieJogadorVSJogador(ref rankingJ1, ref rankingJ2);
                            }
                        }

                        return;
                    }
                    // Verifica se a diagonal secundária está completa
                    if (tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0])
                    {
                        if (turno == "X")
                        {
                            Console.WriteLine(mensagemVitoria);
                            rankingJ1++;

                            Console.WriteLine("Deseja jogar novamente no modo Jogador vs Jogador?");
                            Console.WriteLine("1 - Sim");
                            Console.WriteLine("2 - Não, voltar ao Menu Principal");
                            string resposta = Console.ReadLine();

                            if (resposta == "1")
                            {
                                InicieJogadorVSJogador(ref rankingJ1, ref rankingJ2);
                            }
                        }

                        else
                        {
                            Console.WriteLine(mensagemVitoria2);
                            rankingJ2++;

                            Console.WriteLine("Deseja jogar novamente no modo Jogador vs Jogador?");
                            Console.WriteLine("1 - Sim");
                            Console.WriteLine("2 - Não, voltar ao Menu Principal");
                            string resposta = Console.ReadLine();

                            if (resposta != "1")
                            {
                                InicieJogadorVSJogador(ref rankingJ1, ref rankingJ2);
                            }

                        }

                        return;
                    }
                }

                contadorTurnos++;

                if (contadorTurnos % 2 == 0)
                {
                    turno = "X";
                }

                else
                {
                    turno = "O";
                }

                if (contadorTurnos == 9)
                {
                    Console.WriteLine("Deu velha! Ninguém ganhou dessa vez :(");
                    Console.WriteLine("Reinicie o jogo para jogar novamente");
                }


            }
            // Avaliar possibilidade de incrementar esta parte na situação onde o jogo deu velha
            /*
            Console.WriteLine("Deseja jogar novamente no modo Jogador vs Jogador?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não, voltar ao Menu Principal");
            string resposta = Console.ReadLine();

            if (resposta != "1")
            {
                continuar = false;
            }
            */
        } while (continuar);
    }

    // ========================================================================================================//

    static void InicieJogadorVSPc()
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
            { // Precisa dessas chaves para o switch funcionar corretamente?
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

            Console.WriteLine("Deseja jogar novamente no modo Jogador vs Computador?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não, voltar ao Menu Principal");
            string resposta = Console.ReadLine();

            if (resposta != "1")
            {
                continuar = false;
            }
        } while (continuar);
    }

    // ========================================================================================================//

    static void InicieModoFacil()
    {
        string[,] tabuleiro = new string[3, 3];
        string jogador1 = "X";
        string computador = "O";
        int rankingJvP = 0;
        int rankingPC = 0;
        string turno = "X";
        int contadorTurnos = 0;
        string mensagemVitoria = "O Jogador ( X ) Ganhou!";
        string mensagemVitoria2 = "O Computador ( O ) Ganhou!";

        //================================================================================//

        Console.WriteLine("|-------------------|");
        Console.WriteLine("|=== Modo Fácil ====|");
        Console.WriteLine("|-------------------|");

        CriarTabuleiro(tabuleiro);

        ImprimirTabuleiro(tabuleiro);

        //=============================== Logica do jogo =================================//


        while (contadorTurnos < 9)
        {
            string jogada = "";

            if (turno == computador)
            {
                Console.WriteLine("|====================================================|");
                Console.WriteLine("|=========|        O computador joga       |=========|");
                Console.WriteLine("|====================================================|");
                Console.Write("O computador está pensando"); // Imprimindo mensagem de pensamento do PC
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
            }

            //=================================== Atualização / impressão do tabuleiro =====================//

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

            contadorTurnos++;

            if (turno == jogador1)    //serve para controlar de quem é o turno de jogar
            {
                turno = computador;
            }

            else
            {
                turno = jogador1;
            }
        }

        if (contadorTurnos > 3)
        {
            if (contadorTurnos > 3)
            {
                for (int i = 0; i < 3; i++) // Verifica linhas
                {
                    if (tabuleiro[i, 0] == tabuleiro[i, 1] && tabuleiro[i, 1] == tabuleiro[i, 2])
                    {
                        if (turno == "X")
                        {
                            Console.WriteLine(mensagemVitoria);
                            rankingJvP++;
                        }

                        else
                        {
                            Console.WriteLine(mensagemVitoria2);
                            rankingPC++;
                        }

                        return;
                    }
                }

                for (int j = 0; j < 3; j++) // Verifica colunas
                {
                    if (tabuleiro[0, j] == tabuleiro[1, j] && tabuleiro[1, j] == tabuleiro[2, j])
                    {
                        if (turno == "X")
                        {
                            Console.WriteLine(mensagemVitoria);
                            rankingJvP++;
                        }

                        else
                        {
                            Console.WriteLine(mensagemVitoria2);
                            rankingPC++;
                        }
                        return;
                    }
                }

                // Verifica se a diagonal principal está completa
                if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2])
                {
                    if (turno == "X")
                    {
                        Console.WriteLine(mensagemVitoria);
                        rankingJvP++;
                    }

                    else
                    {
                        Console.WriteLine(mensagemVitoria2);
                        rankingPC++;
                    }
                    return;
                }

                // Verifica se a diagonal secundária está completa
                if (tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0])
                {
                    if (turno == "X")
                    {
                        Console.WriteLine(mensagemVitoria);
                        rankingJvP++;
                    }

                    else
                    {
                        Console.WriteLine(mensagemVitoria2);
                        rankingPC++;
                    }

                    return;
                }
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

    static void ExibirRanking(int rankingJ1, int rankingJ2, int rankingJvP, int rankingPC) // Já estou trabalhando neste método do ranking, favor não mexer || - marcZ
    {
        Console.WriteLine("=============== Ranking ===============");
        Console.WriteLine($"Jogador 1 (X): {rankingJ1} vitórias");
        Console.WriteLine($"Jogador 2 (O): {rankingJ2} vitórias");
        Console.WriteLine("=======================================");
        Console.WriteLine($"Jogador (X): {rankingJvP} vitórias");
        Console.WriteLine($"Computador (O): {rankingPC} vitórias");
        Console.WriteLine("=======================================");
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

// Boa noite por hoje filho do caos, amanhã a gente se vê || - marcZ