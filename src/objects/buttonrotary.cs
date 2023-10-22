using Godot;
namespace Underworld
{
    public class buttonrotary:model3D
    {

        public static buttonrotary CreateInstance(Node3D parent, uwObject obj, string name)
        {
            var b = new buttonrotary(obj);
            var modelNode = b.Generate3DModel(parent, name);
            SetModelRotation(parent, b);
            //DisplayModelPoints(b, modelNode);
            return b;
        }

        public buttonrotary(uwObject _uwobject)
        {
            uwobject = _uwobject;
        }


public override Vector3[] ModelVertices()
        {
            var v = new Vector3[4];
            v[0] = new Vector3(-0.0625f, 0f, 0.0625f);
            v[1] = new Vector3(0.1875f, 0f, 0.0625f);
            v[2] = new Vector3(0.1875f, 0.25f, 0.0625f);
            v[3] = new Vector3(-0.0625f, 0.25f, 0.0625f);
            return v;
        }

        public override int[] ModelTriangles(int meshNo)
        {
            var tris = new int[6];
            tris[0] = 0;
            tris[1] = 3;
            tris[2] = 2;
            tris[3] = 2;
            tris[4] = 1;
            tris[5] = 0;
            return tris;
        }

        public override Vector2[] ModelUVs(Vector3[] verts)
        {
            var uv = new Vector2[4];
            uv[0] = new Vector2(0, 1);
            uv[1] = new Vector2(1, 1);
            uv[2] = new Vector2(1, 0);
            uv[3] = new Vector2(0, 0);
            return uv;
        }

        public override ShaderMaterial GetMaterial(int textureno, int surface)
        {
            int startIndex = uwobject.item_id-353; //item id is either 353 or 354, and has 8 sprites for each in tm flat. flags is the individual sprite index.
            return GetTmObj.GetMaterial(4  + (startIndex * 8) + uwobject.flags);
        }

    }//end class
} //end namespace