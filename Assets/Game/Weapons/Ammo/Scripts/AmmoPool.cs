using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AmmoPool : MonoBehaviour
{
    [Inject] DiContainer diContainer; 
    [System.Serializable]
    public class Ammo
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    [ SerializeField] private List<Ammo> ammos;
    private Dictionary<string, Queue<GameObject>> ammoDictinary;

    private void Awake()
    {
        ammoDictinary = new Dictionary<string, Queue<GameObject>>();

        foreach (Ammo ammo in ammos)
        {
            Queue<GameObject> ammoPool = new Queue<GameObject>();  

            for(int i = 0;i <ammo.size; i++)
            {
                GameObject newAmmo = diContainer.InstantiatePrefab(ammo.prefab);
                newAmmo.SetActive(false);
                newAmmo.transform.parent = null;
                ammoPool.Enqueue(newAmmo);
            }
            ammoDictinary.Add(ammo.tag, ammoPool);
        }
    }

    public void GetAmmoFromPool(string tag, Transform startPosition, Vector3 direction, int damage)
    {
        if (!ammoDictinary.ContainsKey(tag) || ammoDictinary.Count == 0) return;

        GameObject newAmmo = ammoDictinary[tag].Dequeue();

        newAmmo.SetActive(true);
        newAmmo.TryGetComponent<IPooledObject>(out IPooledObject pooledObject);
        if (pooledObject != null)
            pooledObject.GetFromPool(startPosition, direction, damage);

        ammoDictinary[tag].Enqueue(newAmmo);
    }
}
