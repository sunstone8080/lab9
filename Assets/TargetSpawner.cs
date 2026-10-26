using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Target targetPrefab;
    [SerializeField] private float spawnInterval = 1.2f;
    [SerializeField] private float[] rowHeights = { 4f, 2.5f, 1f };

    private TargetDirector director;
    private float timer;

    void Awake()
    {
        director = new TargetDirector(new TargetBuilder(targetPrefab));
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0f) return;
        timer = spawnInterval;

        int row = Random.Range(0, rowHeights.Length);
        int dir = (row % 2 == 0) ? 1 : -1;
        Vector3 pos = new Vector3(-dir * 11f, rowHeights[row], 0f);

        switch (Random.Range(0, 3))
        {
            case 0: director.BuildDuck(pos, dir); break;
            case 1: director.BuildRabbit(pos, dir); break;
            default: director.BuildOwl(pos, dir); break;
        }
    }
}
