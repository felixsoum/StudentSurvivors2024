using UnityEngine;

public class Merman : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundPlayer.GetInstance().PlayDeathAudio();
        Player.GetInstance().AddExp();
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        // direction (vecteur) = destination - source
        var direction = Player.GetInstance().transform.position - transform.position;
        rb.velocity = direction.normalized * moveSpeed;
    }
}
