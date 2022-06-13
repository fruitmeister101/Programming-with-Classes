using Raylib_cs;
namespace GreedGame{
class Sprite{
public string ID = "";
public string DisplayText = "";
public Vector2 pos = Vector2.ZERO;
public float size = 1;
public int shape = 3;
public float rot = 0.0f;
public float rotOffset = 0;
public Raylib_cs.Color color = Greed.DEFAULT_DRAW_COLOR;
public Sprite(){}
public void DrawMe(){
    if (ID == "Score")
    {
        ScoreBanner.DrawMyText(this);
    }
    else{
        Raylib.DrawPoly(new System.Numerics.Vector2(pos.x,pos.y),shape,size,rot,color);
    }

}
public static int ColorRandom(){
    return Greed.rnd.Next(15, 256);
}
}}