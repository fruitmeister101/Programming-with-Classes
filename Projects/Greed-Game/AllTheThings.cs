using Raylib_cs;
namespace GreedGame{
class AllTheThings{
List<Sprite> sprites = new List<Sprite>();
List<Agent> agents = new List<Agent>();

public AllTheThings(){}


public void AddSprite(Sprite sprite){
    sprites.Add(sprite);
}
public void AddAgent(Agent agent){
    agents.Add(agent);
}
public void RemoveSprite(Sprite sprite){
    sprites.Remove(sprite);
}
public void RemoveAgent(Agent agent){
    agents.Remove(agent);
}
public void DrawAllThings(){
    foreach (Agent agent in agents)
    {
        agent.DrawMe();
    }
    foreach (Sprite sprite in sprites)
    {
        sprite.DrawMe();
    }
}
public void MoveAllThings(){
    foreach (Agent agent in agents)
    {
        if (agent.ID == "Player")
        {
            Player.MovePlayer(agent);
        }
        agent.MoveMe();
    }
}

public Sprite GetSpriteByID(string ID){
    foreach (Sprite sprite in sprites)
    {
        if (ID.ToLower() == sprite.ID.ToLower())
        {
            return sprite;
        }
    }
    return null;
}
public Agent GetAgentByID(string ID){
    foreach (Agent agent in agents)
    {
        if (ID.ToLower() == agent.ID.ToLower())
        {
            return agent;
        }
    }
    return null;
}

public int GetAgentCount(){
    return agents.Count();
}

}}