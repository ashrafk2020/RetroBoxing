using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AIBehaviour : ScriptableObject
{

    public abstract bool DoAction(Transform targerPos , Transform playerPos);
    public  bool SetAction { get; set; }



}

