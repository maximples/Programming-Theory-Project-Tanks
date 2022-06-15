using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class SaveData : MonoBehaviour
{
    public static SaveData Instance;
    public float difficultyLevel = 1;
    // Start is called before the first frame update
    private void Awake()
    {
     
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void DifficultyCorrect(float correct)
    {
        difficultyLevel=correct;

    }
     
}
