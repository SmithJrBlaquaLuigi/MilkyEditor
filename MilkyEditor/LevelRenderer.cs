using MilkyEditor.GalaxyObject;
using MilkyEditor.Rendering;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkyEditor
{
    class LevelRenderer : GLControl
    {
        public LevelRenderer(Galaxy galaxy)
        {
            m_galaxy = galaxy;
            m_zone = null;
            isZone = false;

            Dock = DockStyle.Fill;

            Load += new EventHandler(Control_Load);
            Paint += new PaintEventHandler(Control_Paint);
            MouseMove += new MouseEventHandler(Control_MouseMove);
            MouseWheel += new MouseEventHandler(Control_MouseWheel);
            MouseUp += new MouseEventHandler(Control_MouseUp);
            MouseDown += new MouseEventHandler(Control_MouseDown);
            Resize += new EventHandler(Control_Resize);
        }

        public LevelRenderer(Zone zone)
        {
            m_galaxy = null;
            m_zone = zone;
            isZone = true;

            Dock = DockStyle.Fill;

            Load += new EventHandler(Control_Load);
            Paint += new PaintEventHandler(Control_Paint);
            MouseMove += new MouseEventHandler(Control_MouseMove);
            MouseWheel += new MouseEventHandler(Control_MouseWheel);
            MouseUp += new MouseEventHandler(Control_MouseUp);
            MouseDown += new MouseEventHandler(Control_MouseDown);
            Resize += new EventHandler(Control_Resize);
        }

        public void Clear()
        {
            m_galaxy = null;
            m_zone = null;

            GL.DeleteLists(ObjectLists, 1);
            GL.DeleteLists(ObjectListsTrans, 1);
            GL.DeleteLists(ObjectListsPicking, 1);

            GLLoaded = false;
        }

        /* GL Events */
        #region
        private void Control_Load(object sender, EventArgs e)
        {
            MakeCurrent();

            GL.Enable(EnableCap.DepthTest);
            GL.ClearDepth(1f);

            GL.FrontFace(FrontFaceDirection.Cw);

            CamRotation = new Vector2(0.0f, 0.0f);
            CamTarget = new Vector3(0.0f, 0.0f, 0.0f);
            CamDistance = 1f;

            renderInfo = new RenderInfo();

            UpdateViewport();
            UpdateCamera();

            ObjectLists = GL.GenLists(1);

            GL.NewList(ObjectLists, ListMode.Compile);

            if (isZone)
            {
                foreach (LevelObject lvlObj in m_zone.objects)
                    lvlObj.Render(RenderMode.Opaque, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), m_zone.filesystem);
            }
            else
            {
                foreach (LevelObject lvlObj in m_galaxy.objects)
                    lvlObj.Render(RenderMode.Opaque, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), m_galaxy.filesystem);

                foreach (Zone zone in m_galaxy.zones)
                {
                    foreach (LevelObject lvlObj in zone.objects)
                        lvlObj.Render(RenderMode.Opaque, zone.posBias, zone.rotBias, m_galaxy.filesystem);
                }
            }
            GL.EndList();

            ObjectListsTrans = GL.GenLists(1);

            GL.NewList(ObjectListsTrans, ListMode.Compile);

            if (isZone)
            {
                foreach (LevelObject lvlObj in m_zone.objects)
                    lvlObj.Render(RenderMode.Translucent, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), m_zone.filesystem);
            }
            else
            {
                foreach (LevelObject lvlObj in m_galaxy.objects)
                    lvlObj.Render(RenderMode.Translucent, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), m_galaxy.filesystem);

                foreach (Zone zone in m_galaxy.zones)
                {
                    foreach (LevelObject lvlObj in zone.objects)
                        lvlObj.Render(RenderMode.Translucent, zone.posBias, zone.rotBias, m_galaxy.filesystem);
                }
            }
            GL.EndList();

            ObjectListsPicking = GL.GenLists(1);

            GL.NewList(ObjectListsPicking, ListMode.Compile);

            if (isZone)
            {

            }
            else
            {
                foreach (LevelObject lvlObj in m_galaxy.objects)
                    lvlObj.Render(RenderMode.Picking, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), m_galaxy.filesystem);

                foreach (Zone zone in m_galaxy.zones)
                {
                    foreach (LevelObject lvlObj in zone.objects)
                        lvlObj.Render(RenderMode.Picking, zone.posBias, zone.rotBias, m_galaxy.filesystem);
                }
            }
            GL.EndList();

            GLLoaded = true;
        }

        private void Control_Paint(object sender, PaintEventArgs e)
        {
            if (!GLLoaded) return;

            MakeCurrent();


            GL.DepthMask(true); // ensures that GL.Clear() will successfully clear the buffers

            GL.ClearColor(0f, 0f, 0.125f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref CamMatrix);

            GL.Disable(EnableCap.Texture2D);

            GL.CallList(ObjectLists);
            GL.CallList(ObjectListsTrans);

            GL.Begin(PrimitiveType.Lines);
            GL.Color4(1f, 0f, 0f, 1f);
            GL.Vertex3(0f, 0f, 0f);
            GL.Vertex3(100000f, 0f, 0f);
            GL.Color4(0f, 1f, 0f, 1f);
            GL.Vertex3(0f, 0f, 0f);
            GL.Vertex3(0, 100000f, 0f);
            GL.Color4(0f, 0f, 1f, 1f);
            GL.Vertex3(0f, 0f, 0f);
            GL.Vertex3(0f, 0f, 100000f);
            GL.End();

            GL.Color4(1f, 1f, 1f, 1f);

            SwapBuffers();
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            // moves the camera around the scene
            float xdelta = (float)(e.X - m_LastMouseMove.X);
            float ydelta = (float)(e.Y - m_LastMouseMove.Y);

            m_LastMouseMove = e.Location;

            if (BMouseDown != MouseButtons.None)
            {
                if (BMouseDown == MouseButtons.Right)
                {
                    if (IsUpsideDown)
                        xdelta = -xdelta;

                    CamRotation.X -= xdelta * 0.002f;
                    CamRotation.Y -= ydelta * 0.002f;
                }
                else if (BMouseDown == MouseButtons.Left)
                {
                    xdelta *= 0.005f;
                    ydelta *= 0.005f;

                    CamTarget.X -= xdelta * (float)Math.Sin(CamRotation.X);
                    CamTarget.X -= ydelta * (float)Math.Cos(CamRotation.X) * (float)Math.Sin(CamRotation.Y);
                    CamTarget.Y += ydelta * (float)Math.Cos(CamRotation.Y);
                    CamTarget.Z += xdelta * (float)Math.Cos(CamRotation.X);
                    CamTarget.Z -= ydelta * (float)Math.Sin(CamRotation.X) * (float)Math.Sin(CamRotation.Y);
                }

                UpdateCamera();
            }

            Refresh();
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != BMouseDown) return;

            BMouseDown = MouseButtons.None;
            m_LastMouseMove = e.Location;
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (BMouseDown != MouseButtons.None) return;

            BMouseDown = e.Button;
            m_LastMouseMove = LastMouseClick = e.Location;
        }

        private void Control_MouseWheel(object sender, MouseEventArgs e)
        {
            float delta = -((e.Delta / 120.0f) * 0.1f);
            ZoomCamera(delta);

            Refresh();
        }

        private void Control_Resize(object sender, EventArgs e)
        {
            if (!GLLoaded)
                return;

            MakeCurrent();

            UpdateViewport();
        }
        #endregion

        private void UpdateCamera()
        {
            Vector3 up;

            if (Math.Cos(CamRotation.Y) < 0)
            {
                IsUpsideDown = true;
                up = new Vector3(0.0f, -1.0f, 0.0f);
            }
            else
            {
                IsUpsideDown = false;
                up = new Vector3(0.0f, 1.0f, 0.0f);
            }

            CamPosition.X = CamDistance * (float)Math.Cos(CamRotation.X) * (float)Math.Cos(CamRotation.Y);
            CamPosition.Y = CamDistance * (float)Math.Sin(CamRotation.Y);
            CamPosition.Z = CamDistance * (float)Math.Sin(CamRotation.X) * (float)Math.Cos(CamRotation.Y);

            Vector3 skybox_target;
            skybox_target.X = -(float)Math.Cos(CamRotation.X) * (float)Math.Cos(CamRotation.Y);
            skybox_target.Y = -(float)Math.Sin(CamRotation.Y);
            skybox_target.Z = -(float)Math.Sin(CamRotation.X) * (float)Math.Cos(CamRotation.Y);

            Vector3.Add(ref CamPosition, ref CamTarget, out CamPosition);

            CamMatrix = Matrix4.LookAt(CamPosition, CamTarget, up);

            CamMatrix = Matrix4.Mult(Matrix4.CreateScale(0.0001f), CamMatrix);
        }

        private void ZoomCamera(float delta)
        {
            CamTarget.X += delta * (float)Math.Cos(CamRotation.X) * (float)Math.Cos(CamRotation.Y);
            CamTarget.Y += delta * (float)Math.Sin(CamRotation.Y);
            CamTarget.Z += delta * (float)Math.Sin(CamRotation.X) * (float)Math.Cos(CamRotation.Y);

            UpdateCamera();
        }


        private void UpdateViewport()
        {
            GL.Viewport(ClientRectangle);

            AspectRatio = (float)Width / (float)Height;
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 projmtx = Matrix4.CreatePerspectiveFieldOfView(k_FOV, AspectRatio, k_zNear, k_zFar);
            GL.LoadMatrix(ref projmtx);

            PixelFactorX = ((2f * (float)Math.Tan(k_FOV / 2f) * AspectRatio) / (float)(Width));
            PixelFactorY = ((2f * (float)Math.Tan(k_FOV / 2f)) / (float)(Height));
        }

        /* Local variables */
        Galaxy m_galaxy;
        Zone m_zone;
        bool isZone;

        int ObjectLists;
        int ObjectListsPicking;
        int ObjectListsTrans;
        bool GLLoaded;

        private const float k_zNear = 0.01f;
        private const float k_zFar = 1000f;
        private const float k_FOV = (float)(70f * Math.PI) / 180f;

        private Vector2 CamRotation;
        private Vector3 CamTarget;
        private float CamDistance;
        private float AspectRatio;
        private float PixelFactorX, PixelFactorY;
        private Vector3 CamPosition;
        private bool IsUpsideDown;
        private Matrix4 CamMatrix;

        private bool OrthView = false;
        private float OrthZoom = 20f;

        private uint[] PickingFrameBuffer;
        private float PickingDepth;

        private MouseButtons BMouseDown;
        private Point LastMouseClick, m_LastMouseMove;
        private Point MouseCoords;

        private RenderInfo renderInfo;
    }
}
