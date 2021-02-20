using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public List<GameObject> _platforms = new List<GameObject>();

    
    public GameObject GetPooledObject()
    {

        List<GameObject> inactiveObjects = _platforms.FindAll(go => !go.activeInHierarchy);


        return inactiveObjects.Count > 0 ?
          inactiveObjects[Random.Range(0, inactiveObjects.Count)] :
          null;

        //for (int i = 0; i < _platforms.Count; i++)
        //{
        //    if (!_platforms[i].activeInHierarchy)
        //    {
        //        return _platforms[i];
        //    }
        //}
        //return null;

    }

    public void AddToPool(GameObject _platform)
    {
        _platforms.Add(_platform);
    }

}
