using UnityEngine;
public class TargetDirector
{
    private readonly ITargetBuilder builder;
    public TargetDirector(ITargetBuilder builder) { this.builder = builder; }

    public Target BuildDuck(Vector3 pos, int dir)    
    {
        builder.Reset(pos, dir);
        builder.SetSpeed(2f); builder.SetSize(1.5f);
        builder.SetPoints(10); builder.SetColor(Color.yellow);
        return builder.GetTarget();
    }

    public Target BuildRabbit(Vector3 pos, int dir)  
    {
        builder.Reset(pos, dir);
        builder.SetSpeed(4f); builder.SetSize(1f);
        builder.SetPoints(25); builder.SetColor(Color.white);
        return builder.GetTarget();
    }

    public Target BuildOwl(Vector3 pos, int dir)    
    {
        builder.Reset(pos, dir);
        builder.SetSpeed(7f); builder.SetSize(0.6f);
        builder.SetPoints(50); builder.SetColor(Color.red);
        return builder.GetTarget();
    }
}
