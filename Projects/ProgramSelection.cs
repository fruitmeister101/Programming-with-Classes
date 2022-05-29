


Console.Write("Which Program would you like to run Today?\nCurrent selections available are (not case-sensitive):\nTicTacToe\nMagicNumberGame\nHighLow\nHangMan\n: ");
string potato = Console.ReadLine();
bool game = false;
do{


    if(potato.ToLower() == "tictactoe"){
        TicTacToe Program = new TicTacToe();
        Program.Main();
        game = true;
    }
    if (potato.ToLower() == "magicnumbergame"){
        MagicNumberGame Program = new MagicNumberGame();
        Program.Main();
        game = true;
    }
    if (potato.ToLower() == "highlow"){
        HighLow Program = new HighLow();
        Program.Main();
        game = true;
    }
    if (potato.ToLower() == "hangman"){
        HangMan Program = new HangMan();
        Program.Main();
        game = true;
    }

    if(game){
        Console.Write("\n\nWould you like to continue? (Leave Blank for no): ");
        string X = Console.ReadLine();
        game = !(X == "" || X == null);
    }
}while(game);


