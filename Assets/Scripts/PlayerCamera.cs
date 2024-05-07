using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = Player.GetInstance().gameObject;
    }

    private void FixedUpdate()
    {
        var pos = player.transform.position;
        pos.z = -10;
        transform.position = pos;
    }
}
