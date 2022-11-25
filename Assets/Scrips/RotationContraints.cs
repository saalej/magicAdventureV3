using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationContraints : MonoBehaviour
{
    private Quaternion contrain;

    // Start is called before the first frame update
    void Start()
    {
        contrain = Quaternion.Euler(15,10,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = contrain;
    }
}
