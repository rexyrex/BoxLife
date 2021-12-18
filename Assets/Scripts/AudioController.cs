using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public static AudioController ac;

    private AudioSource aSource;

    public AudioClip tp;
    public AudioClip[] slimeHitAudio;
    public AudioClip[] slimeDieAudio;
    public AudioClip[] sapphieHitAudio;
    public AudioClip[] sapphieDieAudio;

    public AudioClip[] playerSwordSwingAudio;

    public Dictionary<string, AudioClip[]> swingDictionary = new Dictionary<string, AudioClip[]>();
    public Dictionary<string, AudioClip[]> hitDictionary = new Dictionary<string, AudioClip[]>();
    public Dictionary<string, AudioClip[]> dieDictionary = new Dictionary<string, AudioClip[]>();
    public Dictionary<string, Dictionary<string, AudioClip[]>> soundDictionary = new Dictionary<string, Dictionary<string, AudioClip[]>>();
    void Awake()
    {
        if (ac == null)
        {
            DontDestroyOnLoad(gameObject);
            ac = this;

        }
        else if (ac != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        aSource = GetComponent<AudioSource>();

        swingDictionary.Add("player", playerSwordSwingAudio);

        hitDictionary.Add("slime", slimeHitAudio);
        hitDictionary.Add("sapphie", sapphieHitAudio);

        dieDictionary.Add("slime", slimeDieAudio);
        dieDictionary.Add("sapphie", sapphieDieAudio);

        soundDictionary.Add("hit", hitDictionary);
        soundDictionary.Add("die", dieDictionary);
        soundDictionary.Add("swing", swingDictionary);
        //aSource.clip = soundDictionary[soundsDictionary][typeDictionary][0];
        //aSource.clip = soundDictionary["hit"]["slime"][0];
    }

    //hit, die
    public void playSound(string soundsDictionary, string typeDictionary)
    {

        if (soundDictionary.ContainsKey(soundsDictionary) && soundDictionary[soundsDictionary].ContainsKey(typeDictionary))
        {
            int length = soundDictionary[soundsDictionary][typeDictionary].Length;
            AudioClip clipz = soundDictionary[soundsDictionary][typeDictionary][Random.Range(0,length)];
            
            aSource.PlayOneShot(clipz);            
        }

    }





    // Update is called once per frame
    void Update () {
		
	}
}
