using UnityEngine;
using System.Collections;

public class BookController : MonoBehaviour
{
    public GameObject TutorialDisplay;

    // Use this for initialization
    private void Awake()
    {
        TutorialDisplay.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            TutorialDisplay.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            TutorialDisplay.SetActive(false);
    }
}
