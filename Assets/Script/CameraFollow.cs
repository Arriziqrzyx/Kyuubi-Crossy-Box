using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Player oyen;
    [SerializeField] Vector3 offset;

    private void Start()
    {
        offset = this.transform.position - oyen.transform.position;
    }

    Vector3 lastOyenlPos;

    void Update()
    {
        if(oyen.IsDie || lastOyenlPos == oyen.transform.position)
        return;

        var targetAnimalPos = new Vector3(
            oyen.transform.position.x,
            0,
            oyen.transform.position.z
        );
        
        transform.position = targetAnimalPos + offset;
        lastOyenlPos = oyen.transform.position;
    }
}
