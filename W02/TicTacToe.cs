class TicTacToe{

    bool game = true;
    string player;
    List<string> board;

    public void Main(){
        StartGame();
        do{
            SwapPlayers();
            MakeMove();
            PrintBoard();
            CheckWinOrTie();
        }while(game);
    }



    void StartGame(){
        player = "O";
        board = new List<string>();
        for(int i = 1; i < 10; i ++){
            board.Add(i.ToString());
        }
        PrintBoard();
        
    }
    void CheckWinOrTie(){
        if(board[0] == board[1] && board[1] == board[2]){game = false;}
        if(board[3] == board[4] && board[4] == board[5]){game = false;}
        if(board[6] == board[7] && board[7] == board[8]){game = false;}

        if(board[0] == board[3] && board[3] == board[6]){game = false;}
        if(board[1] == board[4] && board[4] == board[7]){game = false;}
        if(board[2] == board[5] && board[5] == board[8]){game = false;}

        if(board[0] == board[4] && board[4] == board[8]){game = false;}
        if(board[2] == board[4] && board[4] == board[6]){game = false;}
        
        if(game == false){
            Console.WriteLine($"Well Played, {player}. You win!");
            return;
        }
        bool failed = false;
        foreach(string space in board){
            try{
                int.Parse(space);
                failed = true;
            }
            catch{
            }
        }
        if(failed == false){
            Console.WriteLine($"Oh No!! It's a Tie between the Players!");
            game = false;
        }



    }
    void SwapPlayers(){
        if(player == "O"){
            player = "X";
        }
        else{
            player = "O";
        }

    }
    void MakeMove(){
        bool selecting = true;
        Console.Write($"{player}, make your move: ");
        do{

            string sel = Console.ReadLine();
            if(sel == null){
                Console.Write("Error: Bad Input. Try Again: ");
            }
            else if(board.Contains(sel) && sel != "X" && sel != "X"){
                try{
                    int selInt = int.Parse(sel) - 1;
                    board[selInt] = player;
                    selecting = false;
                }
                catch{
                    Console.Write("Error: Selection does not exist or is taken.\nThis error message should not appear. Good Job gettin this error Try Again: ");
                }
            }
            else{
                Console.Write("Error: Selection does not exist or is Taken. Try Again: ");
            }
            
        }while(selecting);
    }
    void PrintBoard(){
        Console.WriteLine($"\n{board[0]} | {board[1]} | {board[2]} \n---------\n{board[3]} | {board[4]} | {board[5]} \n---------\n{board[6]} | {board[7]} | {board[8]} \n");
    }
}