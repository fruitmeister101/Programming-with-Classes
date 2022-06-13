namespace GreedGame{

using Raylib_cs;
class Greed{
    static string WINDOW_NAME = "Greed";
    public static int WINDOW_WIDTH = 900;
    public static int WINDOW_HEIGHT = 600;
    static int WINDOW_FRAMERATE = 30;
    public static int FONT_SIZE = 20;
    public static Color DEFAULT_COLOR = new Raylib_cs.Color(0, 0, 0, 255);
    public static Color DEFAULT_DRAW_COLOR = new Raylib_cs.Color(255, 255, 255, 255);
    public static Random rnd = new Random(DateTime.Now.Second + DateTime.Now.Millisecond);
    public int score = 0;
    public int scoreSpawnNew = 0;
    int scoreRequiredForSpawn = 5000;
    public static AllTheThings allTheThings = new AllTheThings();
    public static Greed Instance;


    public Greed(){
        Instance = this;
        Raylib.InitWindow(WINDOW_WIDTH, WINDOW_HEIGHT, WINDOW_NAME);
        Raylib.SetTargetFPS(WINDOW_FRAMERATE);
        Keyboard keyboard = new Keyboard();

        allTheThings.AddAgent(new Player());
        allTheThings.AddSprite(new ScoreBanner());

        
        DoStartPopulation();

        do{
            Raylib.BeginDrawing();
            Raylib.ClearBackground(DEFAULT_COLOR); //Clears the screen back to Default color and begins drawing mode
            //Put Logic Here---->


            allTheThings.MoveAllThings();
            allTheThings.DrawAllThings();
            do{DoSpawnThing();}while(MathF.Abs(scoreSpawnNew) >= scoreRequiredForSpawn);



            //Put Logic Here----<
            Raylib.EndDrawing();
        }while(!Raylib.WindowShouldClose());
        Raylib.CloseWindow();
    }


    void DoStartPopulation(){
        for (int i = 0; i < 20; i++)
        {
            Agent newAgent = new Agent();
            newAgent.ID = "Rock";
            Agent.DefaultRandomize(newAgent, i > 10 ? true : false);

            allTheThings.AddAgent(newAgent);
        }
    }
    void DoSpawnThing(){
        if (scoreSpawnNew / scoreRequiredForSpawn >= 1.0f)
            {
                var tempAgent = new Agent();
                Agent.DefaultRandomize(tempAgent, rnd.Next(0,5) == 0 ? true : false);
                allTheThings.AddAgent(tempAgent);
                scoreSpawnNew -= scoreRequiredForSpawn;
            }
            else if (scoreSpawnNew / scoreRequiredForSpawn <= -0.5f)
            {
                var tempAgent = new Agent();
                Agent.DefaultRandomize(tempAgent, rnd.Next(0,5) != 0);
                allTheThings.AddAgent(tempAgent);
                scoreSpawnNew += scoreRequiredForSpawn;
            }
    }



}}