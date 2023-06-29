using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
//observador
public interface IObserver
{
    void Updated(ISubject subject);
}
