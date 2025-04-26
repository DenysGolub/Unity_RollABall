using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public TextMeshProUGUI countText;
    public GameObject winText;
    public Camera cam;
    public GameObject enemy;
    private GameObject pl;
    public GameObject buttonRestart;
    public GameObject buttonMainMenu;

    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0); 
        
        GameObject player = Instantiate(characterPrefabs[selectedCharacter], spawnPoint.position, spawnPoint.rotation);

        player.GetComponentInChildren<PlayerController>().winTextObject = winText;
        player.GetComponentInChildren<PlayerController>().countText = countText;
        cam.GetComponent<CameraController>().player = player.GetComponentInChildren<PlayerController>().gameObject;
        enemy.GetComponent<EnemyMovement>().player = player.GetComponentInChildren<PlayerController>().gameObject;

        player.GetComponentInChildren<PlayerController>().buttonMainMenu = buttonMainMenu;
        player.GetComponentInChildren<PlayerController>().buttonRestart = buttonRestart;


    }


}
