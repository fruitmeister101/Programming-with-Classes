namespace WarLords
{
    using Raylib_cs;
class Unit : Sprite
{
    public float range;
    public float sightRange;
    public int MaxHP;
    int HP;
    public int damage;
    public float moveSpeed;
    public int attackCoolDown;
    int remainingAttackCoolDown;
    public int spawnCoolDown;
    Unit? target;

    public Unit(Vector2 pos, float range=20.0f, float sightRange=100.0f, int MaxHP=200, int damage=10, float moveSpeed=1.0f, int attackCoolDown=25, int spawnCoolDown=75, int team=0){
        this.pos=pos;
        this.range=range;
        this.sightRange=sightRange;
        this.MaxHP=MaxHP;
        this.damage=damage;
        this.moveSpeed=moveSpeed;
        this.attackCoolDown=attackCoolDown;
        this.team=team;
        this.spawnCoolDown=spawnCoolDown;
        HP = MaxHP;
    }
    public void ResetUnit(Vector2 pos, float range=20.0f, float sightRange=100.0f, int MaxHP=200, int damage=10, float moveSpeed=1.0f, int attackCoolDown=25, int spawnCoolDown=75, int team=0){
        this.pos=pos;
        this.range=range;
        this.sightRange=sightRange;
        this.MaxHP=MaxHP;
        this.damage=damage;
        this.moveSpeed=moveSpeed;
        this.attackCoolDown=attackCoolDown;
        this.team=team;
        this.spawnCoolDown=spawnCoolDown;
        HP = MaxHP;
    }

    public bool BasicLogic(){
        CoolDown();
        target = FindClosestEnemy();
        if (target != null)
        {
            float dist = Vector2.Subtract(target.pos, pos).Magitude();
            if(dist <= range){
                AttackTarget(); 
                }
            else if(dist <= sightRange){
                MoveToTarget();
                }
            else{MoveToEnemyBase();}
        }
        else{MoveToEnemyBase();}

        if(HP <= 0){DeacivateMe(); return false;}
        color2 = new Color((int)color2.r,(int)color2.g,(int)color2.b, 255 * HP / MaxHP );

        pos = Vector2.Add(pos, vel);
        if(pos.x > WarLordsRipOff.WINDOW_WIDTH){DeacivateMe();}
        if(pos.x < 0){DeacivateMe();}
        return true;
    }


    Unit? FindClosestEnemy(){
        Unit? bestYet = null;
        float bestDist = 5000.0f;
        foreach (Unit enemy in WarLordsRipOff.objects.units)
        {
            if (team != enemy.team){
                if((int)MathF.Sign(enemy.pos.x - pos.x) == team * 2 - 1){
                    float dist = Vector2.Scale(Vector2.Subtract(enemy.pos, pos), 1.0f, 3.0f).Magitude();
                    if(dist > sightRange){}
                    else if(dist < bestDist){
                        bestDist = dist;
                        bestYet = enemy;
                    }
                }
            }
        } 
        return bestYet;
    }


    void CoolDown(){
        if (remainingAttackCoolDown > 0){remainingAttackCoolDown--;}
    }

    void AttackTarget(){
        if (target is null){return;}
        if (remainingAttackCoolDown <= 0){
            target.HP -= damage;
            remainingAttackCoolDown = attackCoolDown;
        }
        //vel = Vector2.ZERO; // Because my ZERO vector isn't working, and I don't know why. When this is implemented, the unit moves like it's opponent, literally copy-paste vel vector and everything. -_- >_<
        vel = new Vector2();
    }
    void MoveToTarget(){
        if(target == null){return;}
        vel = Vector2.Subtract(target.pos, pos).Normalized(moveSpeed);
    }
    void MoveToEnemyBase(){
        vel.y = 0.0f;
        vel.x = ((team * 2) - 1 ) * moveSpeed;
    }

    public new void DeacivateMe(){
        WarLordsRipOff.objects.DeacivateUnit(this);
    }




    //Basic Presets for Units. I have no idea if they are balanced

    public static Unit Soldier(){
        return new Unit(new Vector2());
    }
    public static Unit Ranger(){
        return new Unit(new Vector2(), 200, 400, 25, 20, 0.25f, 75, 150);
    }
    public static Unit Tank(){
        return new Unit(new Vector2(),20, 200, 500, 5, 0.66f, 50, 120);
    }
    public static Unit Scout(){
        return new Unit(new Vector2(), 20, 50, 50, 10, 3, 75, 90);
    }
    public static Unit StoneThrower(){
        return new Unit(new Vector2(), 100, 250, 100, 15, 1, 55, 80);
    }
    
}
}