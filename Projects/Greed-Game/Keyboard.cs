using Raylib_cs;

namespace GreedGame{

class Keyboard{

static int moveSpeed=6;

public Keyboard(){}
public static Vector2 GetPlayerMove(){
    int x=0;
    int y=0;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
    {
        x--;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
    {
        x++;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
    {
        y--;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
    {
        y++;
    }
    return Vector2.Normalize(new Vector2(x,y),moveSpeed);
}
}


}