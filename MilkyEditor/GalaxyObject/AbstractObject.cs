using MilkyEditor.Rendering;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObject
{
    class AbstractObject
    {
        public void DrawBDL(Bmd model, RenderMode rnd = RenderMode.Opaque)
        {
            RenderInfo ri = new RenderInfo
            {
                Mode = rnd
            };

            BmdRenderer br = new BmdRenderer(model);
            br.Render(ri);
        }

        public void DrawCube(float color1, float color2, float color3, bool showAxis, bool useFill, bool isArea, RenderMode rnd = RenderMode.Opaque)
        {
            RenderInfo ri = new RenderInfo
            {
                Mode = rnd
            };
            RendererBase cubeRender;

            if (!useFill)
            {
                if (isArea)
                    cubeRender = new ColorCubeRenderer(250f, new Vector4(0.867f, 0.867f, 0.867f, 1f), new Vector4(color1, color2, color3, 1f), showAxis, useFill);
                else
                    cubeRender = new ColorCubeRenderer(250f, new Vector4(1f, 0f, 0f, 1f), new Vector4(color1, color2, color3, 1f), showAxis, useFill);
                cubeRender.Render(ri);
            }
            else
            {
                cubeRender = new ColorCubeRenderer(250f, new Vector4(1f, 1f, 1f, 1f), new Vector4(color1, color2, color3, 1f), showAxis, useFill);
                cubeRender.Render(ri);
            }
        }
    }
}
