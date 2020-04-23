using UnityEngine;

public struct LightSource {
  public const int size = (3 + 3 + 3 + 1 + 1 + 1) * 4;

  public Vector3 color; // 3 * 4 bytes
  public Vector3 direction; // 3 * 4 bytes
  public Vector3 position; // 3 * 4 bytes
  public float range; // 1 * 4 bytes
  public float spotAngle; // 1 * 4 bytes
  public uint type; // 1 * 4 bytes

  public LightSource(UnityEngine.Experimental.Rendering.VisibleLight light) {
    color = (Vector4)light.finalColor;
    position = light.localToWorld * new Vector4(0f, 0f, 0f, 1f);
    direction = (Vector3)(light.localToWorld * new Vector4(0f, 0f, 1f, 1f)) - position;
    range = light.range;
    spotAngle = light.spotAngle;
    type = (uint)light.lightType;
  }
}
