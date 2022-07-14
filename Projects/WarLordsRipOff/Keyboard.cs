using Raylib_cs;

namespace WarLords{

class Keyboard{


public Keyboard(){}
public static Vector2 GetPlayer1Move(){
    int x=0;
    int y=0;
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_D))
    {
        x--;
    }
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
    {
        x++;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {
        y--;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
    {
        y++;
    }
    return new Vector2(x,y);
}
public static Vector2 GetPlayer2Move(){
    int x=0;
    int y=0;
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
    {
        x--;
    }
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT))
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
    return new Vector2(x,y);
}
}


}