using UnityEngine;

public class Merman : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundPlayer.GetInstance().PlayDeathAudio();
        Player.GetInstance().AddExp();
        Destroy(gameObject);
    }
}
