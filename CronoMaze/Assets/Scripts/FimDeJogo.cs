using UnityEngine;
using UnityEngine.SceneManagement;

public class FimDeJogo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.Equals("Player")){
            SceneManager.LoadScene("parabensScene");
        }
    }
}
