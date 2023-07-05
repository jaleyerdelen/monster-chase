using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Bütün public deðiþkenlere ve public function'lara ulaþýr


    [SerializeField]
    private GameObject[] characters;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
            
        set { _charIndex = value; }
    }
                       

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject); // yeni sahne yüklenirken objeyi korur

        }
        else
        {
            Destroy(gameObject); // Kopya gameObject'leri siler
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) // Sahneyi mevcut yüklelenen sahneye ekler
    {
        if (scene.name == "SampleScene") // Yüklenecek sahne SampleScene ise seçtiðim index'deki karakterin kopyasýný oluþturur
        {
            Instantiate(characters[CharIndex]);

        }

    }

}
