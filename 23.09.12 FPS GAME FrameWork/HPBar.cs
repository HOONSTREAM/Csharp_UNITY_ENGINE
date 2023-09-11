using UnityEngine;

public class HPBar : MonoBehaviour
{
    public Transform Target;
    private void Start()
    {
        Transform parent = transform.parent;
       
    }
    // Update is called once per frame
    void Update()
    {

        transform.forward = Target.forward; //ºôº¸µå 
        

    }
}
