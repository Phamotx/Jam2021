using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformPrefab = null;

    [Space]
    [SerializeField] private Transform _spawnPosition = null;
    //[SerializeField] private Transform _spawnPositionLeft = null;
    //[SerializeField] private Transform _spawnPositionRight = null;


    //[Header("Platform Dimensions")]
    //[SerializeField] private Vector3 minimumDimension = Vector3.zero;
    //[SerializeField] private Vector3 maxmimumDimension = Vector3.zero;

    [Header("Spawn Settings")]
    //[SerializeField] private float _minspawnTime = 3f;
    //[SerializeField] private float _maxspawnTime = 4f;
    //[SerializeField] private float _minFallSpeed = 3f;
    //[SerializeField] private float _minFallSpeed = 3f;
    [SerializeField] private float _spawnTime = 2f;
    [SerializeField] private float _fallSpeed = 0f;
    //[SerializeField] private float _minimumPlatformDistance = 3.5f;
    //[SerializeField] private float _maximumPlatformDistance = 4f;

    private ObjectPool _objectPool = null;
    private GameObject _spawnedPlatform = null;

    private Vector3 _previousPlatformPosition = Vector3.zero;

    private void Awake()
    {
        _objectPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        //***while player is alive***//
        while (true)
        {
            SpawnPlatform();
            yield return new WaitForSeconds(_spawnTime);
        }
    }


    private void SpawnPlatform()
    {

        //var randomPosition = GetRandomPosition(_previousPlatformPosition);
        //var randomPosition = new Vector3(_spawnPositionLeft.position.x, _spawnPositionLeft.position.y,
        //                                  Random.Range(_spawnPositionLeft.position.z, _spawnPositionRight.position.z));

        //_previousPlatformPosition = randomPosition;

        GameObject platform = null;
        if (_objectPool._platforms.Count >= 10)
        {
            platform = _objectPool.GetPooledObject();
        }        

        if (platform == null)
        {
            var randomIndex = Random.Range(0, _platformPrefab.Length);
            _spawnedPlatform = Instantiate(_platformPrefab[randomIndex], _spawnPosition.position, Quaternion.identity);
            _objectPool.AddToPool(_spawnedPlatform);
        }
        else
        {
            _spawnedPlatform = Instantiate(platform, _spawnPosition.position, Quaternion.identity);
        }
        _spawnedPlatform.GetComponent<Platform>().FallSpeed = _fallSpeed;
        _spawnedPlatform.gameObject.SetActive(true);
        _spawnedPlatform = null;
    }

    //List<int> tmpList = new List<int>();

    //private int GetRandomIndex()
    //{
    //    int index = 0;
    //    do
    //    {
    //        index = Random.Range(0, _platformPrefab.Length);
    //    } while (tmpList.Contains(index));
    //    tmpList.Add(index);
    //    return index;
    //}

    //private Vector3 GetRandomPosition(Vector3 prevPosition)
    //{
    //    if (prevPosition == Vector3.zero)
    //    {
    //        return new Vector3(_spawnPositionLeft.position.x, _spawnPositionLeft.position.y,
    //                                     Random.Range(_spawnPositionLeft.position.z, _spawnPositionRight.position.z));
    //    }
    //    else
    //    {
    //        var randomPosition = new Vector3(_spawnPositionLeft.position.x, _spawnPositionLeft.position.y,
    //                                 Random.Range(_spawnPositionLeft.position.z, _spawnPositionRight.position.z));
    //        if (Mathf.Abs(prevPosition.z - randomPosition.z) < _maximumPlatformDistance &&
    //            Mathf.Abs(prevPosition.z - randomPosition.z) > _minimumPlatformDistance)
    //        {
    //            return randomPosition;
    //        }
    //        else
    //        {
    //            GetRandomPosition(prevPosition);
    //        }
    //    }
    //    return Vector3.zero;
    //}

}
