using Multicad;
using Multicad.CustomObjectBase;
using Multicad.DatabaseServices;
using Multicad.Geometry;
using Multicad.Runtime;
using Multicad.Constants;

namespace AstraMarkerWpf.Models
{
    [CustomEntity("92CACA03-C4AD-4199-87BE-7B37A1B474AD", 1, "ASTRA_MARKER", "Astra Marker")]
    public class AstraMarker: McCustomBase
    {
        private double _radius;
        private Point3d _center;

        public AstraMarker()
        {
            _radius = 1.0;
            _center = new Point3d(0, 0, 0);
        }

        public AstraMarker(double radius, Point3d center) : base()
        {
            _radius = radius;
            _center = center;
        }

        public override hresult OnMcSerialization(McSerializationInfo info)
        {
            try
            {
                info.Add(nameof(_radius), _radius);
                info.Add(nameof(_center), _center);
                return hresult.s_Ok;
            }
            catch
            {
                return hresult.e_Fail;
            }
        }
        public override hresult OnMcDeserialization(McSerializationInfo info)
        {
            try
            {
                info.GetValue(nameof(_radius), out _radius);
                info.GetValue(nameof(_center), out _center);
                return hresult.s_Ok;
            }
            catch
            {
                return hresult.e_Fail;
            }
        }

        public override void OnDraw(GeometryBuilder dc)
        {
            base.OnDraw(dc);
            dc.Clear();
            dc.Color = Colors.ByDefault;
            dc.DrawCircle(Center, Radius);
        }
        public override hresult PlaceObject(PlaceFlags lInsertType)
        {
            InputJig jig = new();
            if (!jig.GetRealNumber("Введите радиус", out double radius) || radius < 0)
            {
                return hresult.e_Fail;
            }

            InputResult point = jig.GetPoint("Введите центральную точку");
            if (point.Result != InputResult.ResultCode.Normal)
            {
                return hresult.e_Fail;
            }

            Radius = radius;
            Center = point.Point;

            DbEntity.AddToCurrentDocument();

            return hresult.s_Ok;
        }

        /// <summary>
        /// Радиус круга.
        /// </summary>
        public double Radius
        {
            get { return _radius; }
            set { _radius = value > 0 ? value : _radius; }
        }

        /// <summary>
        /// Центр круга.
        /// </summary>
        public Point3d Center { get; set; }

    }
}
