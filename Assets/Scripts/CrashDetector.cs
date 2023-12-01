using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;
   void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !hasCrashed){
            
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControl();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene",loadDelay);  
        }
   }
    void ReloadScene(){
        
        Debug.Log("Crash!");
        SceneManager.LoadScene(0); 

    }
}

//
// Invoke() komutu ile istenilen fonksiyonun, istenilen gecikme ile çalışması sağlandı.
// GetComponen<AudioSource>.Play(); ile ses çalma
// effect oluşturduktan sonra .Play:(); ile effecti çalıştırma. [SerializeField] ParticleSystem crashEffect;
// FindObjectOfType<PlayerController>.DisableControl ile başka dosyadaki fonksiyonu (public ise) çağırdık
// SceneManager.LoadScene(index) ile istenilen sahneyi yükleme, leveling vs.
//