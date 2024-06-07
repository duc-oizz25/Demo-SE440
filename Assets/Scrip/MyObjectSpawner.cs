using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
namespace Game
{
    public class MyObjectSpawner : ObjectSpawner
    {
        [Header("Custom Spawm")]
        [SerializeField] private GameObject objectSpawn;

        private GameObject _spawned;
        protected virtual bool CustomSpawnGameObject(Vector3 spawnPoint, Vector3 spawnNormal)
        {
            if(_spawned != null)
            {
                return true;
            }

            _spawned = Instantiate(objectSpawn);
            _spawned.transform.position = spawnPoint;
            return true;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
