using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundsText;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.isMuted)
            soundsText.text = "/";
        else
            soundsText.text = "";
    }

    public void ToggleSound()
    {
        if (GameManager.isMuted)
        {
            GameManager.isMuted = false;
            soundsText.text = "";
        }
        else
        {
            GameManager.isMuted = true;
            soundsText.text = "/";
        }
    }
   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Called");
    }
}
