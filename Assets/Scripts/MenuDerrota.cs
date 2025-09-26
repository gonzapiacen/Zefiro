using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDerrota : MonoBehaviour
{
    public GameObject opcionesMenu;
    public GameObject mainMenu;
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

 