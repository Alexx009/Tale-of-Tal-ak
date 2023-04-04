using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionElavator : MonoBehaviour
{
  private void OncollisonEnter(Collision collision)
  {
    if(collision.gameObject.name == "Character1")
    {
        collision.gameObject.transform.SetParent(transform);
    }
  }

   private void OncollisonExit(Collision collision)
  {
    if(collision.gameObject.name == "Character1")
    {
        collision.gameObject.transform.SetParent(null);
    }
  }
}
