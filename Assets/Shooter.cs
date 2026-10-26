using UnityEngine;
using UnityEngine.InputSystem; 
public class Shooter : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float fireCooldown = 0.25f;
    [SerializeField] private float xLimit = 8f;

    private float nextFireTime;

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        float dir = 0f;
        if (kb.leftArrowKey.isPressed || kb.aKey.isPressed) dir -= 1f;
        if (kb.rightArrowKey.isPressed || kb.dKey.isPressed) dir += 1f;

        Vector3 pos = transform.position + Vector3.right * dir * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);
        transform.position = pos;

        if (kb.spaceKey.isPressed && Time.time >= nextFireTime)
        {
            if (bulletPool.Fire(transform.position + Vector3.up * 0.5f) != null)
                nextFireTime = Time.time + fireCooldown;
        }
    }
}
