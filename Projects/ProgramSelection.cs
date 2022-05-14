

bool game = true;

Console.Write("Which Program would you like to run Today?\nCurrent selections available are (not case-sensitive):\nTicTacToe\nMagicNumberGame\nHighLow\n: ");
string potato = Console.ReadLine();
do{


    if(potato.ToLower() == "tictactoe"){
        TicTacToe Program = new TicTacToe();
        Program.Main();
    }
    if (potato.ToLower() == "magicnumbergame"){
        MagicNumberGame Program = new MagicNumberGame();
        Program.Main();
    }
    if (potato.ToLower() == "highlow"){
        HighLow Program = new HighLow();
        Program.Main();
    }

    Console.Write("\n\nWould you like to continue? (Leave Blank for no): ");
    string X = Console.ReadLine();
    game = X == "" || X == null;
}while(!game);


