using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Normal.Realtime;

public class Spawner : MonoBehaviour
{
  [SerializeField] private Realtime realtime;
  [SerializeField] private RealtimeAvatarManager realtimeAvatarManager;
  [SerializeField] private GameObject prefab;

  private void Start()
  {
    realtimeAvatarManager.avatarCreated += AvatarCreated;
  }

  public void AvatarCreated(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
  {
    if (!isLocalAvatar) return;

    Vector3 pos = transform.position;
    Quaternion rot = transform.rotation;

    GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    if (spawnPoints.Length == 0)
    {
      return;
    }
    else
    {
      int randomIdx = (int)Mathf.Floor(Random.Range(0, spawnPoints.Length));
      pos = spawnPoints[randomIdx].transform.position;
      rot = spawnPoints[randomIdx].transform.rotation;
    }

    var options = new Realtime.InstantiateOptions
    {
      ownedByClient = true,
      useInstance = realtime,
      destroyWhenOwnerLeaves = true,
      destroyWhenLastClientLeaves = true
    };
    Realtime.Instantiate(prefab.name, pos, Quaternion.identity, options);


  }

}
