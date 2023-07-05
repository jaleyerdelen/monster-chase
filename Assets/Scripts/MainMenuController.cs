using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        //Debug.Log("button is pressed"); Button onClick özelliðinden dolayý karakter seçip buradaki fonksiyonlarý çalýþtýrabiliyoruz.
        
        int selectedCharacter =
             int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Debug.Log("selected " +  selectedCharacter);

        GameManager.instance.CharIndex = selectedCharacter;

        //Build settings'de iki sahnenin de olmasý gerekiyor loadScene için 
        SceneManager.LoadScene("SampleScene"); // Menüdeki karakter seçiminden sonra oyuna yönlendiriyor.
    }
}
