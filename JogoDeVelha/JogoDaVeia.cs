using System;

class JogoDaVeia
{
    static void Main(string[] args)
    {
        // Use o grid como um tabuleiro de jogo da velha
        // O tabuleiro é uma matriz 3x3, onde cada célula pode ser
        // ' ' (vazio), 'X' (jogador X) ou 'O' (jogador O)
        char[,] grid = {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };

        int maxRounds = 9;
        int currentRound = 0;

        PrintGrid(grid);

        while (currentRound < maxRounds)
        {
            currentRound++;

            /*
            - o X começa jogando;
            - o O joga na rodada seguinte;
            - Intercale entre o X e o O a cada rodada;
            - Verifique se a jogada é válida (a posição não pode estar ocupada);
            - Verifique se o jogador venceu (3 na horizontal, vertical ou diagonal);
            - Se houver um vencedor, exiba uma mensagem e encerre o jogo;
            - Imprima o tabuleiro após cada jogada;
            */
            
            //JOGADOR X
            Console.WriteLine("Jogador X: ");
            Console.Write("Linha: ");
            int posX_row = int.Parse(Console.ReadLine());
            
            Console.Write("Coluna: ");
            int posX_col = int.Parse(Console.ReadLine());
            Console.WriteLine();
            
            while(grid[posX_row-1, posX_col-1] == 'O' || grid[posX_row-1, posX_col-1] == 'X'){
                Console.WriteLine("Pegue uma Posição Valida!");
                Console.Write("Linha: ");
                posX_row = int.Parse(Console.ReadLine());
                
                Console.Write("Coluna: ");
                posX_col = int.Parse(Console.ReadLine());
                Console.WriteLine();
                
            }
            
            grid[posX_row-1, posX_col-1] = 'X';
            
            
            //FIM JOGADOR X
            
            //JOGADOR O
            Console.WriteLine("Jogador O: ");
            
            Console.Write("Linha: ");
            int posO_row = int.Parse(Console.ReadLine());
            
            Console.Write("Coluna: ");
            int posO_col = int.Parse(Console.ReadLine());
            Console.WriteLine();
            
            while(grid[posO_row-1, posO_col-1] == 'O' || grid[posO_row-1, posO_col-1] == 'X'){
                Console.WriteLine("Pegue uma Posição Valida!");
                Console.Write("Linha: ");
                posO_row = int.Parse(Console.ReadLine());
            
                Console.Write("Coluna: ");
                posO_col = int.Parse(Console.ReadLine());
                Console.WriteLine();
                
            }
            
            
            grid[posO_row-1, posO_col-1] = 'O';
            
            
            //FIM JOGADOR O
            //FIM DA RODADA(CHECKS DO JOGO)
            Console.Clear();
            if(CheckRows(grid) == true || CheckColumns(grid) == true){
                Console.WriteLine("alguem Ganho");
                PrintGrid(grid);
            }
            else{
                PrintGrid(grid);
            }
            
        }

        // Se chegar aqui, é porque o jogo terminou sem vencedor
        Console.WriteLine("Empate!");
        PrintGrid(grid);
    }

    static bool CheckRows(char[,] grid)
    {
        // Verifique as linhas para ver se há um vencedor
        for(int i = 0; i < 3; i++){
            if (grid[i,0] == 'X' && grid[i,1] == 'X' && grid[i,2] == 'X'){
            return true;
            }
            else if (grid[i,0] == 'O' && grid[i,1] == 'O' && grid[i,2] == 'O'){
                return true;
            }
            
        };
        return false;
    }

    static bool CheckColumns(char[,] grid)
    {
        // Verifique as colunas para ver se há um vencedor
        for(int i = 0; i < 3; i++){
            if (grid[0,i] == 'X' && grid[1,i] == 'X' && grid[2,i] == 'X'){
            return true;
            }
            else if (grid[0,i] == 'O' && grid[1,i] == 'O' && grid[2,i] == 'O'){
                return true;
            }
            
          
        };
        return false;  
    }

    static bool CheckDiagonals(char[,] grid)
    {
        // Verifique as diagonais para ver se há um vencedor
        if(grid[1,1] == 'X' && grid[2,2] == 'X' && grid[3,3] == 'X'){
            return true;
        }
        else if(grid[3,1] == 'X' && grid[2,2] == 'X' && grid[1,3] == 'X'){
            return true;
        }
        else if(grid[3,1] == 'O' && grid[2,2] == 'O' && grid[1,3] == 'O'){
            return true;
        }
        else if(grid[1,1] == 'O' && grid[2,2] == 'O' && grid[3,3] == 'O'){
            return true;
        }
        else{
            return false;
        }
    }   

    static void PrintGrid(char[,] grid)
    {
        Console.Clear();
        Console.WriteLine("    1   2   3  ");
        Console.WriteLine("  +---+---+---+");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{i + 1} | {grid[i, 0]} | {grid[i, 1]} | {grid[i, 2]} |");
            Console.WriteLine("  +---+---+---+");
        }
        Console.WriteLine();
    }
}