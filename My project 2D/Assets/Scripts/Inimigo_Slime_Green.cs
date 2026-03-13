using UnityEngine;
using UnityEngine.SceneManagement;


public class Inimigo_Slime_Green : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            // Colidir

            //Destroy(collision.gameObject);
            SceneManager.LoadScene(0);
                  
        
        }

     

        
    }

   

}
