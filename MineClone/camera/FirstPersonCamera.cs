using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MineClone.camera
{
    public class FirstPersonCamera : ICamera
    {
        private Matrix view;
        private Matrix projection;
        private Vector3 cameraPosition = new Vector3(0, 50, 13);

        
        float leftrightRot = MathHelper.PiOver2;
        float updownRot = -MathHelper.Pi / 100.0f;
        const float rotationSpeed = 0.25f;
        const float moveSpeed = 30.0f;
        MouseState originalMouseState;

        MineClone game;

        public FirstPersonCamera(MineClone game)
        {
            this.game = game;
        }
        
        private GraphicsDevice device;

        public Vector3 getCameraPosition()
        {
            return cameraPosition;
        }

        public Matrix getProjection()
        {
            return projection;
        }

        public Matrix getView()
        {
            return view;
        }

        public void Load(GraphicsDevice device)
        {
            this.device = device;
            UpdateViewMatrix();
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, device.Viewport.AspectRatio, 0.3f, 1000.0f);
            Mouse.SetPosition(device.Viewport.Width / 2, device.Viewport.Height / 2);
            originalMouseState = Mouse.GetState();
        }

        public void ProcessInput(float amount)
        {            
            MouseState currentMouseState = Mouse.GetState();

            if (currentMouseState != originalMouseState && !game.IsMouseVisible)
            {                
                float xDifference = currentMouseState.X - originalMouseState.X;
                float yDifference = currentMouseState.Y - originalMouseState.Y;
                leftrightRot -= rotationSpeed * xDifference * amount;
                updownRot -= rotationSpeed * yDifference * amount;
                Mouse.SetPosition(device.Viewport.Width / 2, device.Viewport.Height / 2);
                UpdateViewMatrix();
                originalMouseState = Mouse.GetState();
            }

            if (currentMouseState.LeftButton == ButtonState.Pressed && game.IsMouseVisible)
            {
                game.IsMouseVisible = false;
                Mouse.SetPosition(device.Viewport.Width / 2, device.Viewport.Height / 2);                
            }

            Vector3 moveVector = new Vector3(0, 0, 0);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                moveVector += new Vector3(0, 0, -1);
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                moveVector += new Vector3(0, 0, 1);
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
                moveVector += new Vector3(1, 0, 0);
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
                moveVector += new Vector3(-1, 0, 0);
            if (keyState.IsKeyDown(Keys.Space))
                moveVector += new Vector3(0, 1, 0);
            if (keyState.IsKeyDown(Keys.LeftShift))
                moveVector += new Vector3(0, -1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.IsMouseVisible = true;

            AddToCameraPosition(moveVector * amount);

            cameraPosition -= new Vector3(0, 0.24f, 0);
            if (game.DetectCollision(cameraPosition))
            {
                cameraPosition = lastCameraPosition;
            }
            UpdateViewMatrix();
        }

        private void AddToCameraPosition(Vector3 vectorToAdd)
        {
            Matrix cameraRotation = 
                //Matrix.CreateRotationX(updownRot);
                Matrix.CreateRotationY(leftrightRot);
            Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
            cameraPosition += moveSpeed * rotatedVector;            

            if (game.DetectCollision(cameraPosition))
            {
                cameraPosition = lastCameraPosition;
            }
            
            if (cameraPosition != lastCameraPosition)
            {
                lastCameraPosition = cameraPosition;
                game.Update();
            }
            UpdateViewMatrix();
        }

        Vector3 lastCameraPosition = new Vector3(0, 0, 0);

        private void UpdateViewMatrix()
        {
            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);

            Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
            Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);

            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = cameraPosition + cameraRotatedTarget;

            Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);
            view = Matrix.CreateLookAt(cameraPosition, cameraFinalTarget, cameraRotatedUpVector);
        }
    }
}
