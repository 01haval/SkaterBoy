using UnityEngine;

public class obstacles : MonoBehaviour
{
    Player player;
    GameController gameController;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }


    void Start()
    {

    }
    private void OnTriggerEnter2D()
    {
        gameController.GameOver();
    }

    void Update()
    {
        Vector2 postion = transform.position;


        postion.x -= player.velocity.x * Time.deltaTime;

        if (postion.x < -100)
        {
            Destroy(gameObject);
        }

        transform.position = postion;
    }

    private void FixedUpdate()
    {

    }
}
