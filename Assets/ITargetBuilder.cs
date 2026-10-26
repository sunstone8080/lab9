using UnityEngine;

public interface ITargetBuilder
{
    void Reset(Vector3 spawnPosition, int direction);
    void SetSpeed(float speed);
    void SetSize(float size);
    void SetPoints(int points);
    void SetColor(Color color);
    Target GetTarget();
}
