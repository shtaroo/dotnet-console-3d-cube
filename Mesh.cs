using System;

// The mesh class is what the renderer uses to render
// different objects and shapes.
public class Mesh {
    public List<Vector3> vertices = new List<Vector3>();
    public List<int[]> triangles = new List<int[]>();
    public float MeshCenter;

    float zAxis = 4;

    float positiveToNegative = 1;
    private void FindMeshCenter()
    {
        foreach (Vector3 vector in vertices)
        {
            MeshCenter += vector.Z;
        }
        MeshCenter /= vertices.Count;
    }

    public void InitSquareMesh() {
        //Frontal
        while (positiveToNegative > -1)
        {
            vertices.Add(new Vector3 {X = -1, Y = positiveToNegative, Z = 4});
            vertices.Add(new Vector3 {X = 1, Y = positiveToNegative, Z = 4});

            vertices.Add(new Vector3 {X = positiveToNegative, Y = 1, Z = 4});
            vertices.Add(new Vector3 {X = positiveToNegative, Y = -1, Z = 4});

            vertices.Add(new Vector3 {X = -1, Y = positiveToNegative, Z = 6});
            vertices.Add(new Vector3 {X = 1, Y = positiveToNegative, Z = 6});

            vertices.Add(new Vector3 {X = positiveToNegative, Y = 1, Z = 6});
            vertices.Add(new Vector3 {X = positiveToNegative, Y = -1, Z = 6});


            positiveToNegative -= 0.1f;
        }
        
        while(zAxis < 6)
        {
            vertices.Add(new Vector3 {X = -1, Y = -1, Z = zAxis});
            vertices.Add(new Vector3 {X = 1, Y = -1, Z = zAxis});
            vertices.Add(new Vector3 {X = -1, Y = 1, Z = zAxis});
            vertices.Add(new Vector3 {X = 1, Y = 1, Z = zAxis});

            zAxis += 0.1f;
        }

        FindMeshCenter();
    }
}