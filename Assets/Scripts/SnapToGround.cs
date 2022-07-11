using UnityEditor;
using UnityEngine;
using System.Linq;

public class SnapToGround : MonoBehaviour
{
    [MenuItem("Custom/Snap to Object Below %g")]
    public static void Ground()
    {
        if (Selection.transforms.Length > 0)
        {
            Vector3[] positions = new Vector3[Selection.transforms.Length];

            foreach (var transform in Selection.transforms)
            {
                Bounds tBounds = transform.GetComponent<Renderer>().bounds;

                var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 10f);

                if (hits.Length > 0)
                {
                    positions.Initialize();

                    foreach (var hit in hits)
                    {
                        if (hit.collider.gameObject == transform.gameObject)
                            continue;

                        float yPos = hit.point.y + (transform.gameObject.transform.localScale.y / 2);
                        positions[positions.Length - 1] = new Vector3(transform.gameObject.transform.position.x, yPos, hit.point.z);
                    }

                    if (positions.Length > 0)
                    {
                        positions = positions.OrderBy(v => v.y).ToArray<Vector3>();
                        transform.position = positions[positions.Length - 1];
                        tBounds = transform.GetComponent<Renderer>().bounds;

                        float yBounds = tBounds.min.y + transform.gameObject.transform.localScale.y / 2;
                        float tempValue = transform.position.y - yBounds;

                        if (yBounds < transform.position.y)
                        {
                            float gap = transform.position.y - yBounds;
                            transform.position = new Vector3(transform.position.x, transform.position.y + gap, transform.position.z);
                        }
                    }
                }
            }
        }
    }
}