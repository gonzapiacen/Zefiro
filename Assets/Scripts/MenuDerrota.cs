using UnityEngine;

public class MenuDerrota : MonoBehaviour
{
    public GameObject opcionesMenu;
    public GameObject mainMenu;

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }

    public void  PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("level1");
    } 

}
 