


Console.Write("Which Program would you like to run Today?\nCurrent selections available are (not case-sensitive):\nTicTacToe\nMagicNumberGame\n: ");
string potato = Console.ReadLine();

if(potato.ToLower() == "tictactoe"){
    TicTacToe Program = new TicTacToe();
    Program.Main();
}
if (potato.ToLower() == "magicnumbergame"){
    MagicNumberGame Program = new MagicNumberGame();
    Program.Main();
}


