using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Spawner : MonoBehaviour {
    private Collider spawnArea;
    public GameObject[] fruitPrefabs;
    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;
    public float minAngle = -15f;
    public float maxAngle = 15f;
    public float minForce = 18f;
    public float maxForce = 22f;
    public float maxLifetime = 5f;
    public float spawnerDelay = 3f;
    public bool condition = true;
    private List<GameObject> spawnQueue = new List<GameObject>();
    private System.Random rng = new System.Random();

    private void Awake() {
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable() {
        RefillAndShuffleQueue();
        StartCoroutine(Spawn());
    }

    private void OnDisable() {
        StopAllCoroutines();
    }
    private Coroutine spawnCoroutine;

    public void RestartSpawner()
    {
        if (spawnCoroutine != null)
            StopCoroutine(spawnCoroutine);

        spawnCoroutine = StartCoroutine(Spawn());
    }

    private void RefillAndShuffleQueue() {
        spawnQueue.Clear();
        spawnQueue.AddRange(fruitPrefabs);

        // Fisher-Yates shuffle
        for (int i = spawnQueue.Count - 1; i > 0; i--) {
            int j = rng.Next(i + 1);
            GameObject temp = spawnQueue[i];
            spawnQueue[i] = spawnQueue[j];
            spawnQueue[j] = temp;
        }
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnerDelay);

        while (true)
        {
            if (!condition)
            {
                yield return null;
                continue;
            }

            if (spawnQueue.Count == 0)
                RefillAndShuffleQueue();

            GameObject prefab = spawnQueue[0];
            spawnQueue.RemoveAt(0);

            Vector3 position = new Vector3
            {
                x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            };

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
            GameObject fruit = Instantiate(prefab, position, rotation);
            //Destroy(fruit, maxLifetime);

            float force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }


}
