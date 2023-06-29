using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
//OBSERVADOR
public interface IObserver
{
    void Updated(ISubject subject);
}
