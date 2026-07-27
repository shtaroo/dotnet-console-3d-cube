// The vector class is used to define the points
// of different objects and shapes for the mesh class.
public class Vector3 {

    public float X, Y, Z;

    public float GetXScreenPosition() {
        float screenX = (X / Z);
        return screenX;
    }

    public float GetYScreenPosition() {
        float screenY = (Y / Z);
        return screenY;
    }
}