// =======================================================|

// TRABALHO DE CONCLUSÃO DE MATÉRIA - JOGO DA VELHA EM C#
// FEITO POR: Gabriel Marczal; Bianca Michoski; Thais Colaço; José Guides

// ========================================================|

//                SETOR DE COMENTÁRIOS

// Já estou dando uma olhada em como fazer o ranking funcionar sem problemas, até então, favor não mexer nesse método || - marcZ
// Precisamos colocar uma verificação para não permitir que o usuário escolha uma posição que já foi preenchida - Vou procurar isso hj de noite || - marcZ


// ========================================================|

// Variáveis Globais

using System;

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

            InicieJogadorVSJogador();
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

        default:

            Console.WriteLine("Opção inválida! Tente novamente digitando um valor númerico ou uma das opções abaixo");
            continue; /* O continue, como o nome diz continua o loop (esse codigo esta dentro de um while, para que o usuário
                       * consiga digitar outra opção válida
                      */
    }


    static void InicieJogadorVSJogador()
    {
        //Variaveis para a função
        string jogador1 = "X";
        string jogador2 = "O";
        int rankingJ1 = 0;
        int rankingJ2 = 0;
        string[,] tabuleiro = new string[3, 3];
        string turno = "X";
        int contadorTurnos = 0;
        int mioloDoTabuleiro = 1;
        string mensagemVitoria = "Jogador ( X ) VENCEUUUUUUUU ::))))";
        string mensagemVitoria2 = "Jogador ( O ) VENCEUUUUUUUU ::))))";

        Console.WriteLine("|=======================================|");
        Console.WriteLine("|Modo selecionado: Jogador vs Jogador   |");
        Console.WriteLine("|=======================================|");

        //=======================================================================//
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
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

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

        // Esse while é o que controla o jogo, ele vai rodar enquanto o contador de turnos for menor que 9, ou seja, enquanto houver jogadas possíveis
        while (contadorTurnos < 9)
        {
            Console.WriteLine("|====================================|");
            Console.WriteLine($"|========| O jogador {turno} joga |========|");
            Console.WriteLine("|====================================|");
            string jogada = Console.ReadLine();



            // Aqui eu vou verificar se a jogada é válida, ou seja, se o jogador digitou um número de 1 a 9 e se não está tentando ocupar um lugar que já está preenchido
            // Se for valida ele vai atualizar o tabuleiro

            // Variavel boleana para verificar se é verdadeiro ou falso
            //começa no falso pois ainda não fizemos nenhuma jogada
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


            // Aqui eu estou imprimindo o tabuleiro atualizado na tela
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

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


            //comeco a verificar se o jogador ganhou, ou seja, se ele conseguiu fazer uma linha, coluna ou diagonal com o mesmo simbolo
            // ta fucionando, agora é so replicar para TODAS as as possibilidades de vitoria (emoji de caveira)
            if (contadorTurnos > 3)
            {
                //PRIMEIRA LINHA -THAIS
                if (tabuleiro[0, 0] == tabuleiro[0,1] && tabuleiro[0,1] == tabuleiro[0, 2])
                {
                    
                        if (turno == "X")
                        {
                            Console.WriteLine(mensagemVitoria);
                            rankingJ1++;
                        }
                        else
                        {
                            Console.WriteLine(mensagemVitoria2);
                            rankingJ2++;
                        }
                    return;
                } // SEGUNDA LINHA
                if (tabuleiro[1, 0] == tabuleiro[1,1]&& tabuleiro[1,1] == tabuleiro[1, 2])
                {
                    if (turno == "X")
                    {
                        Console.WriteLine(mensagemVitoria);
                        rankingJ1++;
                    }
                    else
                    {
                        Console.WriteLine(mensagemVitoria2);
                        rankingJ2++;
                    }
                    return;
                } // TERCEIRA LINHA
                if (tabuleiro[2,0] == tabuleiro[2,1] && tabuleiro[2,1]== tabuleiro[2, 2])
                {
                    if (turno == "X")
                    {
                        Console.WriteLine(mensagemVitoria);
                        rankingJ1++;
                    }
                    else
                    {
                        Console.WriteLine(mensagemVitoria2);
                        rankingJ2++;
                    }
                    return;
                } // PRIMEIRA COLUNA
                if(tabuleiro[0,0] == tabuleiro[1,0]&& tabuleiro[1,0] == tabuleiro[2, 0])
                {
                    if (turno == "X")
                    {
                        Console.WriteLine(mensagemVitoria);
                        rankingJ1++;
                    }
                    else
                    {
                        Console.WriteLine(mensagemVitoria2);
                        rankingJ2++;
                    }
                    return;
                } // SEGUNDA COLUNA
                if(tabuleiro[0, 1] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 1])
                {
                    if (turno == "X")
                    {
                        Console.WriteLine(mensagemVitoria);
                        rankingJ1++;
                    }
                    else
                    {
                        Console.WriteLine(mensagemVitoria2);
                        rankingJ2++;
                    }
                    return;
                } // TERCEIRA COLUNA
                if(tabuleiro[0, 2] == tabuleiro[1, 2] && tabuleiro[1, 2] == tabuleiro[2, 2])
                {
                    if (turno == "X")
                    {
                        Console.WriteLine(mensagemVitoria);
                        rankingJ1++;
                    }
                    else
                    {
                        Console.WriteLine(mensagemVitoria2);
                        rankingJ2++;
                    }
                    return;
                } // DIAGONAL ESQUERDA
                if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2])
                {
                    if (turno == "X")
                    {
                        Console.WriteLine(mensagemVitoria);
                        rankingJ1++;
                    }
                    else
                    {
                        Console.WriteLine(mensagemVitoria2);
                        rankingJ2++;
                    }
                    return;
                } // DIAGONAL DIREITA
                if (tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0])
                {
                    if (turno == "X")
                    {
                        Console.WriteLine(mensagemVitoria);
                        rankingJ1++;
                    }
                    else
                    {
                        Console.WriteLine(mensagemVitoria2);
                        rankingJ2++;
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
                return;
            }
        }


    }

    // ========================================================================================================//


    

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

    // ========================================================================================================//

    // Ainda não estamos utilizando esses métodos, mas eles serão usados no futuro || Favor não apagar

    // ========================================================================================================//

    static void InicieModoFacil()
    {
        //variaveis para função
        string[,] tabuleiro = new string[3, 3]; 
        string jogador1 = "X";
        string computador = "O";
        int rankingJ1 = 0;
        string turno = "X";
        int contadorTurnos = 0;
        int mioloDoTabuleiro = 1;
        string mensagemVitoriaJVSC = "Jogador ( X ) VENCEUUUUUUUU ::))))";
        string mensagemVitoriaPC = "Computador VENCEUUUUUUUU ::))))";
        int rankingPC = 1;
        
        //================================================================================//
        Console.WriteLine("|-----------------|");
        Console.WriteLine("|===Modo Fácil====|");
        Console.WriteLine("|-----------------|");

        for (int i = 0; i < tabuleiro.GetLength(0); i++)
        {
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                tabuleiro[i, j] = mioloDoTabuleiro.ToString();
                mioloDoTabuleiro++;
            }

        }
        
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
        //=================================================================================// logica do jogo
            while (contadorTurnos < 9)
        {
            string jogada = "";
            if(turno == computador)
            {
                Console.WriteLine("|====================================|");
                Console.WriteLine("|=========| O computador joga |======|");
                Console.WriteLine("|====================================|");

                for (int i = 0; i < 3 && jogada == ""; i++) { 
                    for (int j = 0; j < 3; j++)
                    {
                        if (tabuleiro[i,j] != "X" && tabuleiro[i,j] != "O")
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
                Console.WriteLine($"|========| O jogador {turno} joga |========|");
                Console.WriteLine("|====================================|");
                jogada = Console.ReadLine();
            }
            //=================================== Atualização / impressão do tabuleiro =====================//
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0;j <3; j++)
                {
                    if (jogada == tabuleiro[i, j])
                    {
                        tabuleiro[i, j] = turno;
                    }
                }
            }
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
            //implementar a lógica da vitoria -- Thais
        }

    }

    //=============================================================================================//

    static void InicieModoDificil()
    {
        Console.WriteLine("|------------------|");
        Console.WriteLine("|===Modo Dificil===|");
        Console.WriteLine("|------------------|");
    }
   //===========================================================================================================//
    static void ExibirRanking(int rankingJ1, int rankingJ2) // Já estou trabalhando neste método do ranking, favor não mexer || - marcZ
    {
        Console.WriteLine("==Ranking top10 atualizadao.com.br da silva==");
        Console.WriteLine($"Jogador 1 (X): {rankingJ1} vitórias");
        Console.WriteLine($"Jogador 2 (O): {rankingJ2} vitórias");
}
    //===================================================================================================//
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
// Boa noite dnv Filho do Caos, salve salve pros mano da firma! || - marcZ

// Boa noite, aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa - Bia

//aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa