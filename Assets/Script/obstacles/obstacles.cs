using UnityEngine;

public class obstacles : MonoBehaviour
{
    Player player;
    Parallax_Endless roade;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        roade = GameObject.Find("Roade").GetComponent<Parallax_Endless>();

    }


    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player hit obstacle! Game Over screen would show now.");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit obstacle! Game Over screen would show now.");
            // Here you can later trigger death screen, stop game, etc.
        }
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
