using System.Collections.Generic;
using Silk.NET.Maths;

public static class Engine
{
    public static List<Vector2D<int>> verts = new();
    public static List<int> tris = new();

    private static VulkanProvider provider;

    public static void AddTriangle(int x, int y, int width, int height)
    {
        int vertsIndex = verts.Count;
        verts.Add(new(x, y));
        verts.Add(new(x + width / 2, y + height));
        verts.Add(new(x + width, y));

        tris.Add(vertsIndex + 0);
        tris.Add(vertsIndex + 1);
        tris.Add(vertsIndex + 2);
    }

    public static void Init()
    {
        AddTriangle(100, 100, 100, 100);

        provider = new VulkanProvider();
        provider.Init();
        provider.Run();
    }

    public static void OnPreRender()
    {

    }
}