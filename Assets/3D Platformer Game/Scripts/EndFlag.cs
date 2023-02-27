using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public string nextSceneName;
    public bool isLastLevel
        ;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(isLastLevel == true)
            {
                SceneManager.LoadScene(0);
            } 
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
