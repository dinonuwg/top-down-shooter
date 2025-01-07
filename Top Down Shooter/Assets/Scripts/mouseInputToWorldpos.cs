using UnityEngine;

public class mouseInputToWorldpos : MonoBehaviour
{
    [SerializeField] private GameObject SpawnObject;
    [SerializeField] private Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));
          Vector3 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
          pos.z = 0;
 
          Instantiate(SpawnObject, pos, Quaternion.identity);

        }
    }
}
