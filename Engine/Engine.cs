using System;
using System.Collections.Generic;
using System.Timers;
using Silk.NET.Maths;
using Timer = System.Timers.Timer;

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
        provider = new VulkanProvider();
        provider.Init();

        Timer timer = new Timer(1000);
        timer.Elapsed += (_, _) =>
        {
            Console.WriteLine("FPS: ~" + (1f / Time.deltaTime));
        };
        timer.Start();

        Time.Restart();

        AddTriangle(100, 100, 100, 100);
        AddTriangle(300, 100, 100, 100);
        provider.UpdateVertexBuffer(verts);

        provider.Run();
    }

    public static void OnPreRender()
    {
        Time.OnPreRender();

        float t = Time.deltaTime;

        verts[0] = Vertex.FromPos(50 + (float)Math.Sin(t) * 50, 0);
        provider.UpdateVertexBuffer(verts);
    }
}