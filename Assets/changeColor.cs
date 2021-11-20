using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeCamera(camera);


        }
    }

    void ChangeCamera(Camera camera)
    {
        camera.backgroundColor = Color.cyan;
       

    }
}
