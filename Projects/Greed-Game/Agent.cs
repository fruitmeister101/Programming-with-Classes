namespace GreedGame{
class Agent : Sprite{

public Vector2 move = Vector2.ZERO;
public float g = 0.05f;
public float rotMove = 0.0f;
public float maxSpeedX = 1.0f;
public bool wrapAroundScreen = true;


public Agent(){}
public void MoveMe(){
    pos.x += move.x;
    pos.y += move.y;
    move.y += g;
    rot = rotMove == 0 ? move != Vector2.ZERO ? Vector2.VectorToDegrees(move) + rotOffset : rot : rot + rotMove;
    if (this.ID == "Player")
    {
        if (pos.y > Greed.WINDOW_HEIGHT - size || pos.y < size)
        {
            pos.y -= move.y;
        }
        if (pos.x > Greed.WINDOW_WIDTH - size || pos.x < size)
        {
            pos.x -= move.x;
        }
    }
    else{
        if (wrapAroundScreen)
        {
            if (pos.x > Greed.WINDOW_WIDTH + size){
                pos.x = -size;
            }
            else if (pos.x < -size){
                pos.x = Greed.WINDOW_WIDTH + size;
            }
        }
        else{
            if (pos.x > Greed.WINDOW_WIDTH || pos.x < 0)
            {
                move.x *= -1.0f;
            }
        }
        if (pos.y > Greed.WINDOW_HEIGHT + size){
            ResetObstacle(this);
        }
        else if (pos.y < -size)
        {
            pos.y = -size;
        }
        CheckCollidedWithPlayer();
        bool special = rotMove == 60;
        if (special)
        {
            color = new Raylib_cs.Color(ColorRandom(),ColorRandom(),ColorRandom(),ColorRandom());
        }
    }
}

void CheckCollidedWithPlayer(){
    var player = Greed.allTheThings.GetAgentByID("player");
    if (player == null){return;}
    if(Vector2.GetMagnitude(Vector2.Subtract(player.pos, pos)) < size + player.size){
        GotCollected();
    }
}
void GotCollected(){
    bool special = rotMove == 60;
    if(ID == "Rock"){
        ResetObstacle(this);
        Greed.Instance.score -= (int) size * (special ? 250 : 100);
        Greed.Instance.scoreSpawnNew -= (int) size * (special ? 250 : 100);
    }
    else if (ID == "Gem")
    {
        Greed.Instance.score += (int) size * (special ? 250 : 100);
        Greed.Instance.scoreSpawnNew += (int) size * (special ? 250 : 100);
        ResetObstacle(this);
    }
}


public static void DefaultRandomize(Agent agent, bool gem=false){
    agent.ID = gem ? "Gem" : "Rock" ;
    agent.maxSpeedX = 7.5f;
    agent.move = new Vector2(Agent.RndX(agent),Greed.rnd.NextSingle() * -15.0f + MathF.Log2(Greed.allTheThings.GetAgentCount()));
    agent.g = 0.05f;
    agent.size = Greed.rnd.NextSingle() * 30.0f + 5.0f;
    agent.shape = gem ? 4 : 3; 
    agent.rotOffset = gem ? 0 : 30;
    agent.color = gem ? new Raylib_cs.Color(ColorRandom(), ColorRandom(), ColorRandom(), 255) : Raylib_cs.Color.RED; 
    agent.pos = new Vector2(Greed.rnd.NextSingle() * Greed.WINDOW_WIDTH, -agent.size);
    agent.rotMove = Greed.rnd.Next(0,50) == 0 ? 60 : 0 ;
}

public static float RndX(Agent agent){
    return (Greed.rnd.NextSingle() * agent.maxSpeedX) - (agent.maxSpeedX / 2.0f);
}

public static void ResetObstacle(Agent agent){
    if(agent.ID != "Player" && agent.ID != "Score"){
        DefaultRandomize(agent, agent.ID == "Gem" ? true : false);
    }
}


}}