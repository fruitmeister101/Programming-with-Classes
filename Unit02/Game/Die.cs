using System;


namespace Unit02.Game
{
    // TODO: Implement the Die class as follows...
    // 1) Add the class declaration. Use the following class comment.

        /// <summary>
        /// A small cube with a different number of spots on each of its six sides.
        /// 
        /// The responsibility of Die is to keep track of its currently rolled value and the points its
        /// worth.
        /// </summary> 
        public class Die{
            bool debug = false;
            public int points = 0;
            public int value = 0 ;
            public static Random rnd = new Random(DateTime.Now.Hour + DateTime.Now.Millisecond);

            public Die(){
                Roll();
            }

            public void Roll(int min = 1, int max = 7){
                
                value = rnd.Next(min, max);
                Score(value);
                
                if(debug){
                    Console.WriteLine($"rnd ={rnd}, points = {points}, value = {value}");
                }

            }
            void Score(int v){
                if(v == 5){
                    points = 50;
                }
                else if(v == 1){
                    points = 100;
                }
                else{
                    points = 0;
                }
            }

        }






        

    // 2) Create the class constructor. Use the following method comment.

        /// <summary>
        /// Constructs a new instance of Die.
        /// </summary>

    
    // 3) Create the Roll() method. Use the following method comment.
        
        /// <summary>
        /// Generates a new random value and calculates the points for the die. Fives are 
        /// worth 50 points, ones are worth 100 points, everything else is worth 0 points.
        /// </summary>
}