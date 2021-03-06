using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ObjectPool : MonoBehaviour {
    Queue<GameObject> objectPool = new Queue<GameObject>();
    public GameObject objectToPool;

    private Vector3 baseTransform;

    private Quaternion baseRotation;

    public int amountToPool;

    protected void Awake() {
        baseTransform = objectToPool.transform.position;
        baseRotation = objectToPool.transform.rotation;
        initialisePool(amountToPool);
    }

    public void initialisePool(int quantity) {
        for (int i = 0; i < quantity; i++) {
            GameObject obj = (GameObject) Instantiate(objectToPool, baseTransform, baseRotation);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    public GameObject getPooledObject() {
        if (objectPool.Count == 0) {
            GameObject obj = (GameObject) Instantiate(objectToPool);
            return obj;
        } else {
            GameObject obj = objectPool.Dequeue();
            if (obj == null || obj.activeInHierarchy) {
                Debug.Log("Bad pooling.");
                return getPooledObject();
            } else {
                obj.transform.position = baseTransform;
                obj.transform.rotation = baseRotation;
                obj.SetActive(true);
                return obj;
            }
        }
    }
    
    public void returnPooledObject(GameObject objecToReturn) {
        objecToReturn.SetActive(false);
        objectPool.Enqueue(objecToReturn);
    }
}