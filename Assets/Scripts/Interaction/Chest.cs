using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IInteractable
{
    [SerializeField] private string _promt;
    public string InteractionPromt => _promt;

    public string interactionPromt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        Debug.Log(message:"Opening Chest");
        return true;
    }
}
