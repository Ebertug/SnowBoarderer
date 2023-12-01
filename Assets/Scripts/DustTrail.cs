using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustEffect;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground"){
            dustEffect.Play();
        }
    }    

    private void OnCollisionExit2D(Collision2D other) {
         if (other.gameObject.tag == "Ground"){
            dustEffect.Stop();
        }
    }
}

//
// OnCollisionExit2D ile collision kesişmeyi bırakınca tetiklenme
// effect.Stop(); ile effecti durdurma
//