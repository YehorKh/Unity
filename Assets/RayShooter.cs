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
    public GameObject bulletPrefab; 
    public float bulletSpeed = 1000f;
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
            StartCoroutine(ShootBullet(ray));
            if (Physics.Raycast(ray, out hit))
            {

                GameObject hitObject = hit.transform.gameObject;

                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                AnimationNinja targetNinja = hitObject.GetComponent<AnimationNinja>();
                if (target)
                {
                    target.ReactToHit();
                }
                if(targetNinja)
                {
                    targetNinja.Die();
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
    private IEnumerator ShootBullet(Ray ray)
    {
        GameObject bullet = Instantiate(bulletPrefab, ray.origin, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = ray.direction * bulletSpeed;
        }

        yield return new WaitForSeconds(2);
        Destroy(bullet);
    }
    private void OnGUI()
    {
        int n = 12;
        float xxx = camera.pixelWidth / 2 - n / 2;
        float yyy = camera.pixelHeight / 2 - n / 2;
        GUI.Label(new Rect(xxx, yyy, n, n), "+");


    }
}
