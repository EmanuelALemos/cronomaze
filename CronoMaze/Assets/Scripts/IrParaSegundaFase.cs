using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximaFase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.Equals("Player")){
            SceneManager.LoadScene("fase2");
        }
    }
}
