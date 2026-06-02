using UnityEngine;

public class MaterialAutoTile : MonoBehaviour
{
    public float tileSize = 1f;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        Vector3 size = rend.bounds.size;

        rend.material.SetTextureScale(
            "_BaseMap",
            new Vector2(size.x / tileSize, size.z / tileSize)
        );
    }
}