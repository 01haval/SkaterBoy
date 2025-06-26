using UnityEngine;

public class parallax : MonoBehaviour
{
    public float depth = 1;
    public float spawner_postion = 80;
    public float distroy_postion = -80;
    Player player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }


    void Start()
    {

    }


    void Update()
    {
        float realVelocity = player.velocity.x / depth;
        Vector2 postion = transform.position;

        postion.x -= realVelocity * Time.deltaTime;

        if (postion.x <= distroy_postion)
        {
            postion.x = spawner_postion;
        }

        transform.position = postion;
    }



}
