using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    public Image introImage; // Assign this in the Inspector
    public Sprite[] introSprites; // Array to hold multiple images if needed
    public float displayTime = 3.0f; // Time each image is displayed
    public string nextSceneName; // Name of the next scene to load

    private int currentImageIndex = 0;

    void Start()
    {
        StartCoroutine(PlayIntro());
    }

     IEnumerator PlayIntro()
    {
        for (int i = 0; i < introSprites.Length; i++)
        {
            currentImageIndex = i; // Track the current image index
            introImage.sprite = introSprites[currentImageIndex];
            yield return new WaitForSeconds(displayTime);
        }
        SceneManager.LoadScene(nextSceneName);
    }
}