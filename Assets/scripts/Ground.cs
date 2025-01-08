using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        float Speed = GameManager.Instance.gameSpeed / transform.localScale.x;
        meshRenderer.material.mainTextureOffset += Vector2.right * Speed * Time.deltaTime;
    }
}
