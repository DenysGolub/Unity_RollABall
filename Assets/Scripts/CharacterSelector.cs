using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characterPrefabs; 
    private GameObject currentCharacter;
    private int currentIndex = 0;

    public Transform spawnPoint; 

    void Start()
    {
        SpawnCharacter();
    }

    public void OnCharacterButtonClicked()
    {
        currentIndex++;
        if (currentIndex >= characterPrefabs.Length)
            currentIndex = 0;

        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        if (currentCharacter != null)
            Destroy(currentCharacter);

        currentCharacter = Instantiate(characterPrefabs[currentIndex], spawnPoint.position, spawnPoint.rotation);
    }

    public void ConfirmSelection()
    {
        PlayerPrefs.SetInt("SelectedCharacter", currentIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene("1_ForestLevel");
    }
}
