namespace WarLords
{
    using Raylib_cs;
class CursorLocation : Sprite
{
    public Unit selectedUnit;
    public Vector2 moveBounds = new Vector2(150 ,WarLordsRipOff.WINDOW_HEIGHT - 250); // Just using a Vector to store both numbers.
    int counter=0;
    public int countRequiredToSpawn = 100;
    float moveSpeed = 10.0f;
    


    public CursorLocation(string name="", int team=0){
        sizeX = 5;
        sizeY = 25;
        color = Color.GREEN;
        color2 = new Color();
        this.name = name;
        this.team = team;
        SetUnit(Unit.Soldier());
        

    }


    public void UpdateMe(){
        counter++;
        if(counter >= countRequiredToSpawn){
            SpawnNew();
            counter = 0;
        }

        pos.x = team == 0 ? WarLordsRipOff.WINDOW_WIDTH - 25 : 25 ;
        pos.y += team == 0 ? Keyboard.GetPlayer2Move().y * moveSpeed : Keyboard.GetPlayer1Move().y * moveSpeed;
        if(pos.y < moveBounds.x){pos.y = moveBounds.x;}
        if(pos.y > moveBounds.y){pos.y = moveBounds.y;}
    }




    public void SetUnit(Unit unit){
        selectedUnit = unit;
        countRequiredToSpawn = unit.spawnCoolDown;
        
    }

    public void SpawnNew(){
        WarLordsRipOff.objects.AddUnit(pos, selectedUnit.range, selectedUnit.sightRange, selectedUnit.MaxHP, selectedUnit.damage, selectedUnit.moveSpeed, selectedUnit.attackCoolDown, selectedUnit.spawnCoolDown, team); //use My pos and team, and pass in all the other args from the selected unit
    }

}
}