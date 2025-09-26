using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemInitializer : MonoBehaviour
{
    public static int itemsRecolectados = 0;
    public static int itemsNecesarios = 4;

    void Start()
    {
        
        itemsRecolectados = 0;

        var item = GetComponent<collectibleItem>();
        if (item != null)
        {
            
            item.SetEffect(new specialItemEfect(4));
            item.OnCollected += ItemRecolectado; 
        }
    }

    private void ItemRecolectado()
    {
        itemsRecolectados++;
        Debug.Log("Objetos recolectados: " + itemsRecolectados);

        if (itemsRecolectados >= itemsNecesarios)
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}

