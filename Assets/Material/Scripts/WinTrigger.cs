using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject WinPannel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinPannel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
