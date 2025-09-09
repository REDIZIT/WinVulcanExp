using System.Collections.Generic;
using Silk.NET.Maths;

public static class Engine
{
    public static List<Vertex> verts = new();
    public static List<int> tris = new();

    private static VulkanProvider provider;

    public static void AddTriangle(int x, int y, int width, int height)
    {
        int vertsIndex = verts.Count;
        verts.Add(Vertex.FromPos(x, y));
        verts.Add(Vertex.FromPos(x + width / 2, y + height));
        verts.Add(Vertex.FromPos(x + width, y));

        tris.Add(vertsIndex + 0);
        tris.Add(vertsIndex + 1);
        tris.Add(vertsIndex + 2);
    }

    public static void Init()
    {
        AddTriangle(100, 100, 100, 100);

        provider = new VulkanProvider();
        provider.Init();

        provider.UpdateVertexBuffer(verts);

        provider.Run();
    }

    public static void OnPreRender()
    {

    }
}