using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenThirdDoor : MonoBehaviour
{
    public Control1 Control1;
    
    // Start is called before the first frame update
    void Start()
    {
        Control1 = GameObject.FindWithTag("Player").GetComponent<Control1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Control1.KeyIsUp)
        {
            Open();
        }
    }

    private void Open()
    {
        if (transform.position.x>-1f)
        {
            transform.Translate(Vector3.left*Time.deltaTime);
        } 
    }
}
