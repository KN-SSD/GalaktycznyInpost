using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int numberOfCollectables = 0;

    public UnityEvent<PlayerInventory> onCollectableGet;

    public void collectedCollectables()
    {
        numberOfCollectables++;
        Debug.Log("Krysztly: " + numberOfCollectables);

        if (onCollectableGet!=null)
        {
            onCollectableGet.Invoke(this);
        }
    }
}
