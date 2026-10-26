using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int poolSize = 25;

    private ObjectPool<Bullet> pool;

    void Awake()
    {
        pool = new ObjectPool<Bullet>(
            createFunc: CreateBullet,
            actionOnGet: b => b.gameObject.SetActive(true),
            actionOnRelease: b => b.gameObject.SetActive(false),
            actionOnDestroy: b => Destroy(b.gameObject),
            collectionCheck: true,
            defaultCapacity: poolSize,
            maxSize: poolSize);
   var warm = new Bullet[poolSize];
        for (int i = 0; i < poolSize; i++) warm[i] = pool.Get();
        for (int i = 0; i < poolSize; i++) pool.Release(warm[i]);
    }

    private Bullet CreateBullet()
    {
        Bullet b = Instantiate(bulletPrefab, transform);
        b.SetPool(pool);
        return b;
    }
  public Bullet Fire(Vector3 position)
    {
        if (pool.CountActive >= poolSize) return null;
        Bullet b = pool.Get();
        b.Activate(position);
        return b;
    }
}
