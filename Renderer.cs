using System;
public class Renderer(Mesh mesh) {
    
    int speed = 33; //30 frames per second ish
    double thetaRotation1 = 0.03; //two standard rotation variables
    double thetaRotation2 = -0.02;
    double thetaRotation3 = -0.04;

    string[] shades = [".", ":", "#", "@"];

    int count = 0;

    public void Render() {
        Clear();
        foreach (Vector3 vector in mesh.vertices) {
            DrawPoint(vector);
            vector.Z -= mesh.MeshCenter;
            ApplyYAxisRotation(vector, thetaRotation1);
            ApplyXAxisRotation(vector, thetaRotation2);
            ApplyZAxisRotation(vector, thetaRotation3);
            vector.Z += mesh.MeshCenter;
        }
        Thread.Sleep(speed);
        Render();
    }

    private void DrawPoint(Vector3 vector) {
        
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        float xScreenPos = vector.GetXScreenPosition();
        float yScreenPos = vector.GetYScreenPosition();

        float consoleXFloat = (xScreenPos + 1) * (consoleWidth / 2f);
        float consoleYFloat = (1 - (yScreenPos + 1) / 2f) * consoleHeight;

        int consoleX = Math.Clamp((int)Math.Round(consoleXFloat), 0, Console.WindowWidth - 1);
        int consoleY = Math.Clamp((int)Math.Round(consoleYFloat), 0, Console.WindowHeight - 1);

        Console.SetCursorPosition(consoleX, consoleY);
        Console.WriteLine("*");
    }

    private void ApplyYAxisRotation(Vector3 vector, double theta)
    {
        
        double rotatedX = vector.X * Math.Cos(theta) + vector.Z * Math.Sin(theta);
        double rotatedZ = (-vector.X) * Math.Sin(theta) + vector.Z * Math.Cos(theta);

        vector.X = (float) rotatedX;
        vector.Z = (float) rotatedZ;
    }

    private void ApplyXAxisRotation(Vector3 vector, double theta)
    {
        
        double rotatedY = vector.Y * Math.Cos(theta) - vector.Z * Math.Sin(theta);
        double rotatedZ = vector.Y * Math.Sin(theta) + vector.Z * Math.Cos(theta);

        vector.Y = (float) rotatedY;
        vector.Z = (float) rotatedZ;
    }

    private void ApplyZAxisRotation(Vector3 vector, double theta)
    {
        
        double rotatedX = vector.X * Math.Cos(theta) - vector.Y * Math.Sin(theta);
        double rotatedY = vector.X * Math.Sin(theta) + vector.Y * Math.Cos(theta);

        vector.X = (float) rotatedX;
        vector.Y = (float) rotatedY;
    }

    public void Clear() {
        Console.Clear();
    }
}