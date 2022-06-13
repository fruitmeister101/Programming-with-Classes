public class HangMan{
    Random rnd = new Random();
    int maxWrongGuesses = 10;
    int wrongGuesses;
    List<char> guesses = new List<char>{};
    char[] magicWord;
    string hiddenWord;
    string guessLetter = "";
    int remainingLetters = 0;
    bool game = true;
    public void Main(){
        StartGame();
        PasteHiddenWordWithGuesses();
        do{
            TakeGuess();
            PasteHiddenWordWithGuesses();
            CheckGameState();
        }while(game);
        Print("\nGG, thanks for playing!");
    }
    void StartGame(){
        magicWord = RandomWord();
        wrongGuesses = 0;
    }
    void PasteHiddenWordWithGuesses(){
        remainingLetters = 0;
        foreach(char i in magicWord){
            if(magicWord.Contains(i) && guesses.Contains(i)){
                Print($"{i} ", false);
            }else{
                Print("_ ", false);
                remainingLetters++;
            }
            
        }
        Print();
    }
    char[] RandomWord(){
        string[] words = System.IO.File.ReadAllLines("valid-wordle-words.txt");
        int x = rnd.Next(words.Count());
        hiddenWord = words[x].ToLower();
        return hiddenWord.ToCharArray();
    }
    void TakeGuess(){
        bool failed = true;
        string charIn;
        char outchar;

        do{
            Print("guessed: ", false);
            foreach (char i in guesses){
                Print($"{i} ", false);
            }
            Print();
            int remaining = maxWrongGuesses - wrongGuesses;
            string s = remaining == 1 ? "" : "s";
            Print($"{remaining} mistake{s} remaining");
            charIn = Input("Guess a Letter").ToLower();
            bool temp = char.TryParse(charIn, out outchar);
            failed = (!temp || guesses.Contains(outchar));
            if(failed || !magicWord.Contains(outchar)){wrongGuesses++;if(wrongGuesses>=maxWrongGuesses){return;}} //Quick Check
        }while(failed);
        guesses.Add(outchar);
    }
    void CheckGameState(){
        if (wrongGuesses>=maxWrongGuesses)
        {
            Print("You ran out of Guesses");
            Print($"The word was: '{hiddenWord}'");
            game = false;
            return;
        }
        if (remainingLetters == 0)
        {
            Print("You Win!!\nYou guessed my word");
            game = false;
            return;
        }
    }
    void Print(string message="", bool newLine=true){
        if(newLine){
            Console.WriteLine(message);
        }
        else{
            Console.Write(message);
        }
    }
    string Input(string message=""){
        Console.Write(message + ": ");
        string x = Console.ReadLine();
        x = x is null ? "" : x;
        return x;
    }
}