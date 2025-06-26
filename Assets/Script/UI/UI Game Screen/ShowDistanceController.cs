using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowDistanceController : MonoBehaviour
{
    Player player;
    TMP_Text distanceText;


    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainGame")
        {
        player = GameObject.Find("Player").GetComponent<Player>();
        distanceText = GameObject.Find("DistanceText").GetComponent<TMP_Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainGame")
        {
            int distance = Mathf.FloorToInt(player.distance);
            distanceText.text = distance + " m";
        }
    }
}
