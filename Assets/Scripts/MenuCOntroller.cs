using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCOntroller : MonoBehaviour
{
    public void OnPlayClick()
    {
        SceneManager.LoadScene(2);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPlayClick();
        }
    }
    public void OnInstructionClick()
    {

    }


}
