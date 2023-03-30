# normcore realtime transform 

test the bug with rigidbody realtime transforms in normcore.io

## to repro:
1. open the scene "RIGIDBODY" and play it
2. open the scene "RIGIDBODY" in another instance and play it
3. occasionally the instantiated object "CUBE_PREFAB" from the first client is spawned with weird coordinates on the second client
