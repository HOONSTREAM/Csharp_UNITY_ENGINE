using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager

{
    AudioSource[] _audiosource = new AudioSource[(int)Define.Sound.Maxcount]; // BGM,EFFECT 용도 하나씩
    //MP3 Player -> AudioSource 컴포넌트
    //MP3 음원 -> AudioClip 
    // 귀  -> Audio Listener

    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);

            string[] soundnames = System.Enum.GetNames(typeof(Define.Sound));

            for(int i = 0; i < soundnames.Length-1; i++)
            {
              GameObject go =   new GameObject { name = soundnames[i] };
               _audiosource[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform; //root의 자식이 되는 것.
            }

            _audiosource[(int)Define.Sound.Bgm].loop = true; //bgm은 루프
        }
    }

    public void Play(Define.Sound type, string path, float pitch = 1.0f)
    {
        if (path.Contains("Sound/") == false)
        {
            path = $"Sound/{path}";
        }
        
        if(type == Define.Sound.Bgm)
        {
            AudioClip audioclip = Managers.Resources.Load<AudioClip>(path);
            if (audioclip == null)
            {
                Debug.Log($"Audio clip Missing !{path} ");
                return;
            }

            //TODO
                

        }

        else
        {
            AudioClip audioclip = Managers.Resources.Load<AudioClip>(path);
            if (audioclip == null)
            {
                Debug.Log($"Audio clip Missing !{path} ");
                return;
            }

            AudioSource audiosource = _audiosource[(int)Define.Sound.Effect];
            audiosource.pitch = pitch;
            audiosource.PlayOneShot(audioclip);

        }
    }

}
