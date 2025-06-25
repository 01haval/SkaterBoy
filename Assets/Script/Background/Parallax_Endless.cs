using UnityEngine;

public class Parallax_Endless : MonoBehaviour
{
    Material mat;
    public float depth = 1;
    float distance;
    Player player;
    public float realVelocity;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    void Update()
    {
        realVelocity = player.velocity.x / depth;
        distance += Time.fixedDeltaTime * realVelocity;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }

}
