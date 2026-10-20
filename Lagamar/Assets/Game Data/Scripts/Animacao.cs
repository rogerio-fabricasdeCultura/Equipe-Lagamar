using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacao : MonoBehaviour
{
   public Animator playerAnimator;
   
   public void PLayerAnimation(string animationName) {
        playerAnimator.Play(animationName);
   }
}