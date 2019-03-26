using UnityEngine;

public class PrefabPoolUsage : MonoBehaviour
{
    public GameObject[] Prefabs;

    //pool random object from inside prefabs array
    public void PoolRandomObject()
    {
        var randomIndex = Random.Range(0, Prefabs.Length);
        var randomObj = Prefabs[randomIndex];
        var obj = PrefabPooler.Instance.Get(randomObj);
        obj.transform.SetParent(transform);
    }

    //release random child
    public void ReleaseRandomChild()
    {
        if (transform.childCount <= 0)
            return;

        var randomIndex = Random.Range(0, transform.childCount);
        var randomChild = transform.GetChild(randomIndex);
        PrefabPooler.Instance.ReleasePooledObject(randomChild.gameObject);
    }
}