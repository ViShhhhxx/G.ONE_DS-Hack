using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_handler : MonoBehaviour
{
    public static SFX_handler Instance;

    public AudioClip PointGain, Click;
    private AudioSource AuSource;

    public void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        AuSource = GetComponent<AudioSource>();
        //AuSource.clip = Click;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void PlayAudio(string name)
    {
        switch (name)
        {
            case "Point":
                AuSource.PlayOneShot(PointGain);
                break;
            case "Click":
                AuSource.PlayOneShot(Click);
                DontDestroyOnLoad(AuSource);
                StartCoroutine(waitAndDestroy());
                break;
        }
        

    }

    IEnumerator waitAndDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

}
