using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // B�t�n public de�i�kenlere ve public function'lara ula��r


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

            DontDestroyOnLoad(gameObject); // yeni sahne y�klenirken objeyi korur

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

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) // Sahneyi mevcut y�klelenen sahneye ekler
    {
        if (scene.name == "SampleScene") // Y�klenecek sahne SampleScene ise se�ti�im index'deki karakterin kopyas�n� olu�turur
        {
            Instantiate(characters[CharIndex]);

        }

    }

}
