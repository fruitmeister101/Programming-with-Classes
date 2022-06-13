namespace GreedGame{
class Player : Agent{
        
public Player(bool regular=true){
    ID = "Player";
    maxSpeedX = 25;
    g = 0;
    shape = 3;
    size = 25;
    rotOffset = 30;
    color = Raylib_cs.Color.GREEN;
    wrapAroundScreen = false;
    pos = new Vector2(Greed.WINDOW_WIDTH / 2, Greed.WINDOW_HEIGHT - 50);
}


public static void MovePlayer(Agent player){
    player.move = Keyboard.GetPlayerMove();
}







}}