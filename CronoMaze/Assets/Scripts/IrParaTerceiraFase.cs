using UnityEngine;
using UnityEngine.SceneManagement;

public class IrParaTerceiraFase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.Equals("Player")){
            SceneManager.LoadScene("fase3");
        }
    }
}
