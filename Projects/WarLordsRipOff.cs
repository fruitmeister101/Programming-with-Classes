namespace WarLords
{
using Raylib_cs;

class WarLordsRipOff
{
    public static WarLordsRipOff? Instance;
    public WindowDirector window = new WindowDirector();
    static string WINDOW_NAME = "WarLords Rip-Off";
    public static int WINDOW_WIDTH = 1500;
    public static int WINDOW_HEIGHT = 900;
    static int WINDOW_FRAMERATE = 30;
    public static int FONT_SIZE = 20;
    public static Color DEFAULT_COLOR = new Raylib_cs.Color(0, 0, 0, 255);
    public static Random rnd = new Random(DateTime.Now.Second + DateTime.Now.Millisecond);
    public static Objects objects = new Objects();
    List<CursorLocation> cursors = new List<CursorLocation>();


    public WarLordsRipOff(){
        Instance = this;
        bool game = true;
        
        window.OpenWindow(WINDOW_WIDTH, WINDOW_HEIGHT, WINDOW_NAME, WINDOW_FRAMERATE);

        var cursor = new CursorLocation("Player1", 1);
        cursors.Add(cursor);
        objects.Specials.Add((Sprite)cursor);
        cursor.SetUnit(Unit.Ranger());
        cursor = new CursorLocation("Player2", 0);
        cursors.Add(cursor);
        objects.Specials.Add((Sprite)cursor);

        do{
            Raylib.WaitTime(10);
            Raylib.BeginDrawing();
            Raylib.ClearBackground(DEFAULT_COLOR);
            objects.UpdateAllUnits();
            UpdateCursors();
            objects.DrawAllSprites();

            Raylib.EndDrawing();
            if(Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE)){ break; }

        }while(game);
        window.CloseWindow();


    }



    void UpdateCursors(){
        foreach (var cursor in cursors)
        {
            cursor.UpdateMe();
        }
    }


}
}