namespace WarLords
{
    using Raylib_cs;
class WindowDirector
{
    

    public void OpenWindow(int x=1500,int y=900, string name="WarLords Rip-Off", int frameRate = 30){
        Raylib.InitWindow(x, y, name);
        Raylib.SetTargetFPS(frameRate);
    }

    public void CloseWindow(){
        Raylib.CloseWindow();
    }








}
}