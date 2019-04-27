using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    protected AudioSource[] sourceArray;
    
    [SerializeField]
    private int sourceAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
            instance = this;
        else if(instance == this)
        {

        }
        else {
            Destroy(this);
        }

        for (int i = 0; i < sourceAmount; i++)
        {
            GameObject obj = new GameObject("Source " + i, typeof(AudioSource));
            sourceArray[i] = obj.GetComponent<AudioSource>();
        }

    }

    
    public static void PlaySound(AudioClip AudioClip){
        foreach (var item in AudioController.instance.sourceArray)
        {
            if(!item.isPlaying)
            {
                item.clip = AudioClip;
                item.Play();
                break;
            }
        }
    }
}
