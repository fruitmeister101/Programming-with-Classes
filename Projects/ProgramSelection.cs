using GreedGame;
using WarLords;


Console.Write("Which Program would you like to run Today?\nCurrent selections available are (not case-sensitive):\nTicTacToe\nMagicNumberGame\nHighLow\nHangMan\nGreed\nWarLords\n: ");
string potato = Console.ReadLine();

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
if (potato.ToLower() == "hangman"){
    HangMan Program = new HangMan();
    Program.Main();
}
if (potato.ToLower() == "greed"){
    new Greed();
}
if (potato.ToLower() == "warlords"){
    new WarLordsRipOff();
}



