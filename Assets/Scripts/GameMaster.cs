using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour { // A class which poses a connection between the player and the enemy so if the enemy dies we can still cause to do animations 

   
    public static void KillPlayer (Player player) // Kills the player 
    {
        Destroy(player.gameObject);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public static void KillEnemy(Enemy enemy)// kills the enemy 
    {
        Destroy(enemy.gameObject);
        


    }

}
