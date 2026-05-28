using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToRocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && GameManager.Instance.IsLevelFinished())
        {
            SceneManager.LoadScene("Menu");
        }
    }
}