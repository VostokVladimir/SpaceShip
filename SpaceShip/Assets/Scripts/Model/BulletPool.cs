using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletPool : MonoBehaviour
{
    public GameObject prefab { get; }
    public bool autoExpand { get; set; }
    public Transform poolContainer { get; }

    public List<GameObject> pool;


    

    public BulletPool(GameObject prefab, int count, Transform poolConteiner)
    {
        this.prefab = prefab;
        this.poolContainer = poolConteiner;
        this.CreatePool(count);
    }

    public void CreatePool(int count)
    {
        this.pool = new List<GameObject>();
        for (int i = 0; i <= count; i++)
        {
            CreateObject();
        }
    }

    private GameObject CreateObject(bool isAtiveByDefault=false)
    {
        var created_object =Instantiate(this.prefab, this.poolContainer);
        created_object.gameObject.SetActive(isAtiveByDefault);
        this.pool.Add(created_object);
        return created_object;
    }

    public bool HasFreeElement(out GameObject object_pool)
    {
        foreach(var element in pool)
        {
            if(!element.activeInHierarchy)
            {
                object_pool = element;
                object_pool.SetActive(true);
                return true;
            }
           
        }
        object_pool = null;
        return false;



    }

    public GameObject GetFreeObject()
    {
        if(this.HasFreeElement(out GameObject gameObject))
        {
            return gameObject;
        }

        if(this.autoExpand)
        {
            

              return this.CreateObject(true); 

        }
        throw new Exception ($"There is no free elements in pool of type {typeof(GameObject)}");



    }

    public void ReturnToPool(GameObject element)
    {
        if(element.activeSelf)
        {   gameObject.SetActive(false);
            element.transform.localPosition = Vector3.zero;
            element.transform.localRotation = Quaternion.identity;
            
        }
    }

}

