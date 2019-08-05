using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClone.camera
{
    public interface ICamera
    {
        Matrix getView();
        Matrix getProjection();
        Vector3 getCameraPosition();
        void ProcessInput(float amount);
        void Load(GraphicsDevice device);
    }
}
