using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class RayShooter : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera camera;
    [SerializeField]
    private GUIStyle guiStyle;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center =new Vector3(camera.pixelWidth/ 2.0F, camera.pixelHeight/ 2.0F);

        if(Input.GetMouseButtonDown(0))
        {
            

            Ray ray = camera.ScreenPointToRay(center);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                //StartCoroutine(CreateSphereIndicator(hit.point));


                GameObject hitObject = hit.transform.gameObject;

                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if(target)
                {
                    target.ReactToHit();
                }
            }
        }
    }
    private IEnumerator CreateSphereIndicator(Vector3 hitPoint)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = hitPoint;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
    private void OnGUI()
    {
        float size = guiStyle.fontSize;
        float x = camera.pixelWidth / 2.0F-size/2.0F;
        float y = camera.pixelHeight / 2.0F - size / 2.0F;
        GUI.Label(new Rect(x, y, size, size), "+",guiStyle);


    }
}
