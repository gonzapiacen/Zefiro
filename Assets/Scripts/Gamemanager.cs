using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    
    private Vector3 respawnPosition;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        respawnPosition =  Playermove.instance.transform.position;  

    }

    void Update()
    {

    }

    public void respawn()
    {
        Playermove.instance.gameObject.SetActive(false);
        Playermove.instance.transform.position = respawnPosition;
        Playermove.instance.gameObject.SetActive(true);
}

}

