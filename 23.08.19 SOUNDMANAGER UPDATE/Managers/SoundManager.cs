using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager

{
    AudioSource[] _audiosource = new AudioSource[(int)Define.Sound.Maxcount]; // BGM,EFFECT �뵵 �ϳ���
    //MP3 Player -> AudioSource ������Ʈ
    //MP3 ���� -> AudioClip 
    // ��  -> Audio Listener

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
                go.transform.parent = root.transform; //root�� �ڽ��� �Ǵ� ��.
            }

            _audiosource[(int)Define.Sound.Bgm].loop = true; //bgm�� ����
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
