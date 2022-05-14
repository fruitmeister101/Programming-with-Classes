

class HighLow{
    bool game = true;
    string guess = "";
    int pick = 0;
    int prevPick = 0;
    bool badGuess = true;
    int score = 0;
    Random rnd = new Random();
    public void Main(){
        StartGame();
        PickNumber();
        do{
            do{
                Guess();
                ValidateGuess();
            }while(badGuess);
            PickNumber();
            RevealGuess();
        }while(game);
        Print("Game Over!!");
    }
    void StartGame(){
        badGuess = true;
        game = true;
        score = 300;
        Print("Your Score starts at 300\nCorrect guessing increases your score by 100\nIncorrect guesses reduce your score by 75\n");
    }
    void PickNumber(){
        prevPick = pick;
        pick = rnd.Next(1,14);
        if(pick > 13 || pick < 1){
            Print("Hidden Error Message 1. You shouldn't see this, but if you do, you will lose the game");
        }
    }
    void Guess(){

        Print($"The number is {pick}");
        guess = Input("Guess whether the next number will be [1] Higher or [2] lower");
    }
    void ValidateGuess(){
        if (guess == "1" || guess == "2")
        {
            badGuess = false;
            return;
        }
        Print("Your guess is not within the values given. Guess again.");
        score -= 1;
    }
    void RevealGuess(){
        Print($"The next number is: {pick}");
        if(pick > prevPick && guess == "1"){
            Print("You are Correct!");
            score += 100;
        }
        else if(pick < prevPick && guess == "2"){
            Print("You are Correct!");
            score += 100;
        }
        else{
            Print("Wrong");
            score -= 75;
        }
        game = score > 0;
        Print($"Your Score is: {score}\n\n");
    }
    void Print(string message=""){
        Console.WriteLine(message);
    }
    string Input(string message=""){
        Console.Write(message + ": ");
        string x = Console.ReadLine();
        
        x = x is null ? "" : x;

        return x;
    }
}