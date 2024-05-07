using UnityEngine;

public class ScytheProjectile : MonoBehaviour, IPoolable
{
    float lifetime = 2f;

    public void Reset()
    {
        lifetime = 2f;
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            gameObject.SetActive(false);
        }
        transform.position += 5f * Time.deltaTime * transform.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.Damage(10);
        }
    }
}
