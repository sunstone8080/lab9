using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifetime = 3f;

    private IObjectPool<Bullet> pool;
    private float timer;
    private bool released;

    public void SetPool(IObjectPool<Bullet> p) => pool = p;

    public void Activate(Vector3 position)
    {
        transform.position = position;
        timer = lifetime;
        released = false;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0f) Release();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Target target))
        {
            target.Hit();
            Release();
        }
    }

    private void Release()
    {
        if (released) return;   
        released = true;
        pool.Release(this);  
    }
}
