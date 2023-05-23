using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
    protected Transform self;
    protected Transform target;
    protected Mover mover;
    protected Fighter fighter;
    protected Vector3 offset = new Vector3(3f,.2f,0);
   

    
   public BaseState(Transform self ,Transform target)
   {

        this.self = self;
        this.target = target;
        mover = self.GetComponent<Mover>();
        fighter = self.GetComponentInChildren<Fighter>();
   }
    


    public abstract  void EnterState();
    public abstract  void UpdateState();

    public abstract  void ExitState();







}
