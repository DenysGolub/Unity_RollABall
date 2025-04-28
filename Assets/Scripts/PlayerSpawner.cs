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
    public GameObject chickenParticle;
    public AudioClip chickenSound;
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0); 
        
        GameObject player = Instantiate(characterPrefabs[selectedCharacter], spawnPoint.position, spawnPoint.rotation);
        player.GetComponentInChildren<Rigidbody>().gameObject.AddComponent<PlayerController>();
        player.GetComponentInChildren<PlayerController>().collectiblesCount = 22;
        player.GetComponentInChildren<PlayerController>().winTextObject = winText;
        player.GetComponentInChildren<PlayerController>().countText = countText;
        player.GetComponentInChildren<PlayerController>().speed = 10;
        player.GetComponentInChildren<PlayerController>().chickenParticle = chickenParticle;
        player.GetComponentInChildren<PlayerController>().chickenSound = chickenSound;



        cam.GetComponent<CameraController>().player = player.GetComponentInChildren<PlayerController>().gameObject;
        enemy.GetComponent<EnemyMovement>().player = player.GetComponentInChildren<PlayerController>().gameObject;

        player.GetComponentInChildren<PlayerController>().buttonMainMenu = buttonMainMenu;
        player.GetComponentInChildren<PlayerController>().buttonRestart = buttonRestart;


    }


}
