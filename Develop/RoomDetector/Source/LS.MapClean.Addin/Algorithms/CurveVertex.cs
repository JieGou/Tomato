using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace LS.MapClean.Addin.Algorithms
{
    /// <summary>
    /// (Graph图)顶点
    /// </summary>
    public struct CurveVertex
    {
        public CurveVertex(Point3d point, ObjectId objId)
        {
            _point = point;
            _id = objId;
        }

        private Point3d _point;
        public Point3d Point
        {
            get { return _point; }
        }

        private ObjectId _id;
        public ObjectId Id
        {
            get { return _id; }
        }

        // Always create an override of Equals for struct
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(CurveVertex))
                return false;
            var right = (CurveVertex)obj;
            var result = Point.IsEqualTo(right.Point) && Id == right.Id;
            return result;
        }

        public override int GetHashCode()
        {
            //http://stackoverflow.com/questions/7813687/right-way-to-implement-gethashcode-for-this-struct
            unchecked
            {
                // 我们需要考虑精度的影响。
                var x = (int)(Point.X);
                var y = (int)(Point.Y);

                var hash = 17;

                // Suitable nullity checks etc, of course :)
                hash = (23 * hash) + x.GetHashCode();
                hash = (23 * hash) + y.GetHashCode();
                hash = (23*hash) + Id.GetHashCode();
                return hash;
            }
        }

        // Override operator == and !=
        public static bool operator ==(CurveVertex left, CurveVertex right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CurveVertex left, CurveVertex right)
        {
            return !left.Equals(right);
        }
    }
}
