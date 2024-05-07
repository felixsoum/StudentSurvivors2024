using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] int maxHp = 10;
    Rigidbody2D rb;
    int currentHp;

    private void Awake()
    {
        currentHp = maxHp;
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Damage(int value)
    {
        currentHp -= value;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        SoundPlayer.GetInstance().PlayDeathAudio();
        Player.GetInstance().AddExp();
        Destroy(gameObject);
    }

    protected virtual void FixedUpdate()
    {
        // direction (vecteur) = destination - source
        var direction = Player.GetInstance().transform.position - transform.position;
        rb.velocity = direction.normalized * moveSpeed;
    }
}
