
class MagicNumberGame{


    /*
    float x = float.Parse(Console.ReadLine());
    float y = float.Parse(Console.ReadLine());
    float z = float.Parse(Console.ReadLine());

    float answer = (x + y) * z;

    Console.WriteLine($"The answer is {answer}");

    // I'm working off my phone, and don't have access to see the correct capitalization for words and stuff. Grain of salt please... 
    */



    //Main Game Start -----------------------------------------------------------------


    public int magicNumber = 0;
    int counter = 0;
    public void Main(){
    
        magicNumber = PickRandomNumber();
        bool continueGame = true;
        counter = 0;
        while (continueGame){
            counter++;
            int guess = int.Parse(Console.ReadLine());
            continueGame = GuessNumber(guess);
        }
        Console.WriteLine("Well, thanks for playing! =D\n");
    }

    //Main Game End -------------------------------------------------------------------



    bool GuessNumber(int number){

        if(number == magicNumber){
            Console.Write($"Wow, Good Job! You guessed my number in {counter} tries!\nIf you would like to play again, enter 'y' :");
            if(Console.ReadLine() == "y"){
                PickRandomNumber();
                counter = 0;
                return true;
            }
            return false;
        }
        else{
            if (number > magicNumber){
                Console.Write("Nope! Guess lower :");
            }
            else{
                Console.Write("Nope! Guess Higher :");
            }
            return true;
        }
    }

    int PickRandomNumber(){
        Console.WriteLine("What Number Range do you want to work with? (pick 2 integers) :");
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        Random rnd = new Random();
        int randNum = rnd.Next(x, y);
        Console.WriteLine("Alrighty then, Guess the number I picked!");
        return randNum;
    }

};
/*
TestingClasses TC = new TestingClasses();

TC.Main();
*/
