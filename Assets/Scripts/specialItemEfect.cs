using UnityEngine;

public class specialItemEfect : ItemEfect
{
    private int requiredItems;

    // Constructor que acepta un parámetro
    public specialItemEfect(int required = 4)
    {
        requiredItems = required;
    }

    public void Apply(GameObject player)
    {
        // Aquí puedes aplicar efectos específicos del ítem si es necesario
        Debug.Log("Efecto especial aplicado al jugador.");
    }
}
