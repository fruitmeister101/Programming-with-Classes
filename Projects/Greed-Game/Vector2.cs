namespace GreedGame{
    class Vector2{
    public float x;
    public float y;
    public static Vector2 ZERO = new Vector2();
    public Vector2(float x=0.0f, float y=0.0f){
        this.x = x;
        this.y = y;
    }
    public void Set(float x=0.0f, float y=0.0f){}

    public static float GetMagnitude(Vector2 vec){
        float magnitude = MathF.Sqrt(vec.x*vec.x + vec.y*vec.y);
        return magnitude;
    }
    public static Vector2 Scale(Vector2 vec, float scale=1.0f){
        Vector2 result = new Vector2(vec.x*scale, vec.y*scale);
        return result;
    }
    public static Vector2 Normalize(Vector2 vec, float len=1.0f){
        float mag = Vector2.GetMagnitude(vec);
        if(mag == 0){return Vector2.ZERO;}
        return Scale(vec ,len / mag);
    }

    public static Vector2 Add(Vector2 a, Vector2 b){
        return new Vector2(a.x + b.x, a.y + b.y);
    }
    public static Vector2 Subtract(Vector2 a, Vector2 b){
        return new Vector2(a.x - b.x, a.y - b.y);
    }

    public static int VectorToDegrees(Vector2 vec){
        var temp2 = Vector2.Normalize(vec);
        var temp = (int)(MathF.Atan2(temp2.y, temp2.x)*180.0f/Math.PI);
        return temp;
    }

}
}