using System;
using System.Collections.Generic;
using System.Timers;
using Silk.NET.Maths;
using Timer = System.Timers.Timer;

public static class Engine
{
    private static List<Mesh> meshes = new();

    private static VulkanProvider provider;

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

        meshes.Add(new()
        {
            vertices = new Vertex[]
            {
                new(0, 0, 0, 1),
                new(0, 400, 0, 0),
                new(400, 400, 1, 0),
                new(400, 400, 1, 0),
                new(400, 0, 1, 1),
                new(0, 0, 0, 1),
            }
        });

        provider.Run();
    }

    public static void OnPreRender()
    {
        Time.OnPreRender();

        float t = Time.timeSinceLoad;

        for (int i = 0; i < meshes[0].vertices.Length; i++)
        {
            meshes[0].vertices[i].color = new Vector3D<float>(t % 1, 0, 0);
        }

        provider.UpdateVertexBuffer(meshes);
    }
}