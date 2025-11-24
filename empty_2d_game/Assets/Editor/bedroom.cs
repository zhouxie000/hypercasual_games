using UnityEngine;
using UnityEditor;

public class BedroomSceneCreator : MonoBehaviour
{
    [MenuItem("Tools/Create Bedroom Scene")]
    static void CreateBedroomScene()
    {
        // Clear existing objects
        foreach (var obj in Object.FindObjectsOfType<GameObject>())
        {
            if (obj != null)
                DestroyImmediate(obj);
        }

        // Create floor
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.name = "Floor";
        floor.transform.localScale = new Vector3(10f, 0.2f, 10f);
        floor.transform.position = new Vector3(0, 0, 0);
        floor.GetComponent<Renderer>().material.color = new Color(0.8f, 0.7f, 0.6f);

        // Create walls
        CreateWall("Wall_Back", new Vector3(0, 2.5f, -5f), new Vector3(10f, 5f, 0.2f));
        CreateWall("Wall_Left", new Vector3(-5f, 2.5f, 0), new Vector3(0.2f, 5f, 10f));
        CreateWall("Wall_Right", new Vector3(5f, 2.5f, 0), new Vector3(0.2f, 5f, 10f));

        // Create bed
        GameObject bedBase = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bedBase.name = "Bed_Base";
        bedBase.transform.localScale = new Vector3(3f, 0.4f, 2f);
        bedBase.transform.position = new Vector3(-2f, 0.2f, 2f);
        bedBase.GetComponent<Renderer>().material.color = new Color(0.6f, 0.3f, 0.2f);

        GameObject mattress = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mattress.name = "Mattress";
        mattress.transform.localScale = new Vector3(3f, 0.4f, 2f);
        mattress.transform.position = new Vector3(-2f, 0.6f, 2f);
        mattress.GetComponent<Renderer>().material.color = new Color(1f, 1f, 0.9f);

        GameObject pillow = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pillow.name = "Pillow";
        pillow.transform.localScale = new Vector3(1f, 0.2f, 0.6f);
        pillow.transform.position = new Vector3(-2f, 0.9f, 3.2f);
        pillow.GetComponent<Renderer>().material.color = Color.white;

        // Create light
        GameObject lightObj = new GameObject("Directional Light");
        Light light = lightObj.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1.2f;
        lightObj.transform.rotation = Quaternion.Euler(50f, 30f, 0);

        // Create camera
        GameObject camObj = new GameObject("Main Camera");
        Camera cam = camObj.AddComponent<Camera>();
        camObj.tag = "MainCamera";
        cam.transform.position = new Vector3(0, 3f, -8f);
        cam.transform.rotation = Quaternion.Euler(10f, 0, 0);

        Debug.Log("Bedroom scene created successfully!");
    }

    static void CreateWall(string name, Vector3 pos, Vector3 scale)
    {
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.name = name;
        wall.transform.position = pos;
        wall.transform.localScale = scale;
        wall.GetComponent<Renderer>().material.color = new Color(0.9f, 0.9f, 0.95f);
    }
}
