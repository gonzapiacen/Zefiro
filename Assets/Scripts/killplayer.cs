using UnityEngine;

public class killplayer : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Debug.Log("El jugado a muerto");
        Gamemanager.instance.respawn();
    }
}

}
