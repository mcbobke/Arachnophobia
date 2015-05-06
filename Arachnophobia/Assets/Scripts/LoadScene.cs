using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        if (index == -1)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
            Application.LoadLevel(index);
    }
}
