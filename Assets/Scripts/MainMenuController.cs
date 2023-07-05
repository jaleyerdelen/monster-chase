using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        //Debug.Log("button is pressed"); Button onClick �zelli�inden dolay� karakter se�ip buradaki fonksiyonlar� �al��t�rabiliyoruz.
        
        int selectedCharacter =
             int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Debug.Log("selected " +  selectedCharacter);

        GameManager.instance.CharIndex = selectedCharacter;

        //Build settings'de iki sahnenin de olmas� gerekiyor loadScene i�in 
        SceneManager.LoadScene("SampleScene"); // Men�deki karakter se�iminden sonra oyuna y�nlendiriyor.
    }
}
