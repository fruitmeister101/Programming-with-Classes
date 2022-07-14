namespace WarLords
{
    using System.Collections.Generic;
class Objects
{
    public List<Sprite> Specials = new List<Sprite>(); // Things like the scoreboard and selectors and stuff
    public List<Sprite> sprites = new List<Sprite>(); 
    public List<Sprite> inactiveSprites = new List<Sprite>();
    public List<Unit> units = new List<Unit>(); 
    public List<Unit> inactiveUnits = new List<Unit>();
    

    public Sprite? GetSpriteByName(string name){
        foreach (Unit sprite in sprites)
        {
            if (name == sprite.name)
            {
                return sprite;
            }
        }
        return null;
    }
    public Sprite? GetSpecialByName(string name){
        foreach (Unit sprite in Specials)
        {
            if (name == sprite.name)
            {
                return sprite;
            }
        }
        return null;
    }
    public void DrawAllSprites(){
        foreach (var sprite in sprites)
        {
            sprite.DrawMe();
        }
        foreach (var unit in units)
        {
            unit.DrawMe();
        }
        foreach (var sprite in Specials)
        {
            sprite.DrawMe();
        }
    }
    public void UpdateAllUnits(){
        for (int i = 0; i < units.Count; i++)
        {
                Unit? unit = units[i];
                i -= unit.BasicLogic() ? 0 : 1; //Check if the unit removed itself from the list so we don't throw errors or skip over units
        }
    }

    public Sprite AddSprite(){
    var X = inactiveSprites.Count() > 0 ? inactiveSprites[0] : new Sprite(); // get a reference to an inactive sprite, otherwise make a new one
    if(inactiveSprites.Count() > 0){AcivateSprite(X);} // If we are pulling it out and activating it, we should actually do that.
    else{sprites.Add(X);}
    return X;
    }
    public void DeacivateSprite(Sprite sprite){
        inactiveSprites.Add(sprite);
        sprites.Remove(sprite);
    }
    public Sprite AcivateSprite(Sprite sprite){
        sprites.Add(sprite);
        inactiveSprites.Remove(sprite);
        return sprite;
    }
    public Unit AddUnit(Vector2 pos, float range=20.0f, float sightRange=100.0f, int MaxHP=250, int damage=5, float moveSpeed=2.0f, int attackCoolDown=25, int spawnCoolDown=60, int team=0){
    var X = inactiveUnits.Count() > 0 ? inactiveUnits[0] : new Unit(pos, range, sightRange, MaxHP, damage, moveSpeed, attackCoolDown, spawnCoolDown, team); // get a reference to an inactive sprite, otherwise make a new one
    if(inactiveUnits.Count() > 0){AcivateUnit(X); X.ResetUnit(pos, range, sightRange, MaxHP, damage, moveSpeed, attackCoolDown, spawnCoolDown, team);} // If we are pulling it out and activating it, we should actually do that. Also, pass in the Constructor Defaults with options for them.
    else{units.Add(X);}
    return X;
    }
    public void DeacivateUnit(Unit unit){
        inactiveUnits.Add(unit);
        units.Remove(unit);
    }
    public Unit AcivateUnit(Unit unit){
        units.Add(unit);
        inactiveUnits.Remove(unit);
        return unit;
    }


}
}