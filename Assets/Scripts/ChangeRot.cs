using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRot : MonoBehaviour
{
    public void changeRot()
    {
        this.transform.Rotate(new Vector3(0, 0, 45f));
    }
}
