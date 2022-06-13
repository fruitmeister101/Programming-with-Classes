namespace GreedGame{
using Raylib_cs;
class ScoreBanner : Sprite{
    public ScoreBanner(){
        pos = new Vector2(15,15);
        ID = "Score";
    }
    public static void DrawMyText(Sprite s){
        s.DisplayText = "Score: " + Greed.Instance.score.ToString();
        Raylib.DrawText(s.DisplayText, (int)s.pos.x, (int)s.pos.y, Greed.FONT_SIZE, Greed.DEFAULT_DRAW_COLOR);
    }
}
}