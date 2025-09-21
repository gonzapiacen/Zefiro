using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject opcionesMenu;
    public GameObject mainMenu;

   public void openOptionsPanel()
{
    opcionesMenu.SetActive(true);   
    mainMenu.SetActive(false);      
}

public void openMainMenuPanel()
{
    opcionesMenu.SetActive(false);  
    mainMenu.SetActive(true);       
}


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
 