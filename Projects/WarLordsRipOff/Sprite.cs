namespace WarLords
{
    using Raylib_cs;
class Sprite
{
    public string name = "";
    public Vector2 pos = new Vector2();
    public string text = "";
    public int sizeX = 10;
    public int sizeY = 25;
    public Color color = Color.GREEN;
    public Color color2 = Color.WHITE;
    public Vector2 vel = new Vector2();
    public int team = 0; // this should only ever be 0 or 1. 1 is player 1 <--, 0 is player 2 -->


    public void DrawMe(){
        Raylib.DrawRectangle((int)pos.x, (int)pos.y, sizeX, sizeY, color2);
        Raylib.DrawRectangleLines((int)pos.x, (int)pos.y, sizeX, sizeY, color);
    }

    public void DeacivateMe(){
        WarLordsRipOff.objects.DeacivateSprite(this);
    }




}
}