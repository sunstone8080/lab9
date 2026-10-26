using UnityEngine;

//Concrete builder
public class TargetBuilder : ITargetBuilder
{
    private readonly Target prefab;
    private Target target;

    public TargetBuilder(Target prefab) { this.prefab = prefab; }

    public void Reset(Vector3 spawnPosition, int direction)
    {
        target = Object.Instantiate(prefab, spawnPosition, Quaternion.identity);
        target.Direction = direction;
    }

    public void SetSpeed(float speed)   => target.Speed = speed;
    public void SetPoints(int points)   => target.Points = points;
    public void SetSize(float size)     => target.transform.localScale = Vector3.one * size;
    public void SetColor(Color color)   => target.GetComponent<SpriteRenderer>().color = color;

    public Target GetTarget()
    {
        Target result = target;
        target = null;
        return result;
    }
}
