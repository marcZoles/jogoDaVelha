// =======================================================|

// TRABALHO DE CONCLUSÃO DE MATÉRIA - JOGO DA VELHA EM C#
// FEITO POR: Gabriel Marczal; Bianca Michoski; Thais Colaço; José Guides

// ========================================================|

//                SETOR DE COMENTÁRIOS

// Já estou dando uma olhada em como fazer o ranking funcionar sem problemas, até então, favor não mexer nesse método || - marcZ


// ========================================================|

// Variáveis Globais

Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();
bool b = false;
char[,] tabuleiro = new char[3, 3]; // a virgula [,] indica que é uma matriz e não um array
string jogador1 = "X";
string jogador2 = "O";
int rankingJ1 = 0;
int rankingJ2 = 0;

// ========================================================|

while (!b)
{
    Console.WriteLine("===Criado por: Gabriel Marczal, Bianca Michoski, Thais Colaço e José Guides===");
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


    switch (modoDeJogoConvert) // Problema do loop infinito foi corrigido pelo José & Thays, agora tá funcionando filé || - marcZ
    {
        case 1:

            InicieJogadorVSJogador(tabuleiro);
            break;

        case 2:

            InicieJogadorVSPc();
            break;

        case 3:

            ExibirRanking(rankingJ1, rankingJ2);
            break;

        case 4:
            Console.WriteLine("Jogo encerrado!");
            modoDeJogoConvert = 4;
            b = true;
            break;

        case 5:
            JogoDaVelha();
            break;

        default:

            Console.WriteLine("Opção inválida! Tente novamente digitando um valor númerico ou uma das opções abaixo");
            continue; /* O continue, como o nome diz continua o loop (esse codigo esta dentro de um while, para que o usuário
                       * consiga digitar outra opção válida
                      */
    }


    static void JogoDaVelha()
    {
        string jogador1 = "X";
        string jogador2 = "O";
        int rankingJ1 = 0;
        int rankingJ2 = 0;
        string[,] tabuleiro = new string[3, 3];
        string turno = "X";
        int contadorTurnos = 0;
        int mioloDoTabuleiro = 1;
        string mensagemVitoria = $"Jogador {turno} VENCEUUUUUUUU ::))))";

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
                    if (jogada == tabuleiro[i, j])
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

                for (int i = 1; i < 3; i++) //ele ira verificar as 3 linhas (0, 1, 2)
                {
                    if (tabuleiro[i, 0] != "" && // Verifica se a primeira linha não está vazia - Thais
                        tabuleiro[i, 0] == tabuleiro[i, 1] && // verifica se a primeira linha é igual a segunda - Thais
                        tabuleiro[i, 1] == tabuleiro[i, 2]) // verifica se a segunda linha é igual a terceira - Thais
                    {
                        Console.WriteLine(mensagemVitoria);
                        if (turno == "X")
                        {
                            rankingJ1++; // verificar se o ranking está correto e se não precisa fazer "return rankingJ1++" || - marcZ
                            Console.WriteLine($"O jogador {turno} tem " + i + " vitorias");

                        }
                        else
                        {
                            rankingJ2++;
                            Console.WriteLine($"O jogaodor {turno} tem " + i + " vitorias");
                        }

                        // colunas
                        for (int j = 1; j < 3; j++)
                        {
                            if (tabuleiro[0, j] != "" &&
                                tabuleiro[0, j] == tabuleiro[1, j] &&
                                tabuleiro[1, j] == tabuleiro[2, j])
                            {
                                Console.WriteLine(mensagemVitoria);
                                if (turno == "X")
                                {
                                    rankingJ1++;
                                    Console.WriteLine($"O jogaodor {turno} tem " + i + " vitorias");
                                }
                                else
                                {
                                    rankingJ2++;
                                    Console.WriteLine($"O jogaodor {turno} tem " + i + " vitorias");
                                }
                            }
                        }
                        // diagonais
                        if (tabuleiro[0, 0] != " " &&
                            tabuleiro[0, 0] == tabuleiro[1, 1] &&
                            tabuleiro[1, 1] == tabuleiro[2, 2])
                        {
                            Console.WriteLine(mensagemVitoria);
                            if (turno == "X")
                            {
                                rankingJ1++;
                                Console.WriteLine($"O jogaodor {turno} tem " + i + " vitorias");
                            }
                            else
                            {
                                rankingJ2++;
                                Console.WriteLine($"O jogaodor {turno} tem " + i + " vitorias");
                            }
                        }
                        if (tabuleiro[0, 2] != " " &&
                            tabuleiro[0, 2] == tabuleiro[1, 1] &&
                            tabuleiro[1, 1] == tabuleiro[2, 0])
                        {
                            Console.WriteLine(mensagemVitoria);
                            if (turno == "X")
                            {
                                rankingJ1++;
                                Console.WriteLine($"O jogaodor {turno} tem " + i + " vitorias");
                            }
                            else
                            {
                                rankingJ2++;
                                Console.WriteLine($"O jogaodor {turno} tem " + i + " vitorias");
                            }
                        }
                    }
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
        }


    }

    // ========================================================================================================//


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

    // ========================================================================================================//

    static void InicieJogadorVSPc()
    {
        
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
        }
    }
    // Ainda não estamos utilizando esses métodos, mas eles serão usados no futuro || Favor não apagar

    // ========================================================================================================//

    static void InicieModoFacil()
    {
        Console.WriteLine("==Modo Fácil===");
    }

    static void InicieModoDificil()
    {
        Console.WriteLine("==Modo Dificil==");
    }

    static void ExibirRanking(int rankingJ1, int rankingJ2) // Já estou trabalhando neste método do ranking, favor não mexer || - marcZ
    {
        Console.WriteLine("==Ranking top10 atualizadao.com.br da silva==");
        Console.WriteLine($"Jogador 1 (X): {rankingJ1} vitórias");
        Console.WriteLine($"Jogador 2 (O): {rankingJ2} vitórias");
}

    if (modoDeJogoConvert == 4) // Verificação para ver se o usuário escolheu sair do jogo
    {
        b = true;
    }
}




// ========================================================|
// Setor do nosso querido amigo, o Filho do CAOS

// Filho do CAOS que acabou com nossa felicidade
// vvvvvvvvvvvvvv

// Teste pra ve se o bagua me aceita la

// ^^^^^^^^^^^^^^
// NÃO MEXER NO FILHO DO CAOS, ELE É O QUE FAZ O JOGO FUNCIONAR

// ========================================================|

//aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
// Boa noite Filho do Caos || - marcZ

//aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa