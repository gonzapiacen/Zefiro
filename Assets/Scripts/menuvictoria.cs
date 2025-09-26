using UnityEngine;
using UnityEngine.SceneManagement;

public class menuvicotira : MonoBehaviour
{
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    
    public void JugarDeNuevo()
    {
        SceneManager.LoadScene("level1"); 
    }

    public void Salir()
    {
        Application.Quit();
    
    }
}