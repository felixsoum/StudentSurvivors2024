using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movespeed;
    [SerializeField] BaseWeapon[] weapons;
    Rigidbody2D rb;
    Animator animator;

    private static Player instance;
    private int exp;

    public static Player GetInstance() => instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        weapons[0].LevelUp();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(x, y) * movespeed;
        animator.SetFloat("Speed", rb.velocity.magnitude);

        if (x != 0)
        {
            transform.localScale = new Vector3(x > 0 ? 1 : -1, 1, 1);
        }
    }

    internal void AddExp()
    {
        exp++;
        if (exp % 5 == 0)
        {
            // 50% chance level up weapon index 0
            // et 50% chance index 1
            weapons[UnityEngine.Random.value < 0.5f ? 0 : 1].LevelUp();
        }
    }
}
