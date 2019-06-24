using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointable : MonoBehaviour
{
   public int points;

   public int getPoints()
   {
        return points;
   }

   public void playSoundFX()
   {
        GameObject soundManager = GameObject.Find("SoundManager");
        if (soundManager != null)
        {
            soundManager.GetComponent<SoundManager>().playPick();
        }
    }
}
