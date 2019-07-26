using asd;

namespace VectorStudy
{
    static class Helper
    {
        public static readonly Color BackGroundColor = ColorFromHex(0xff1e3a67);
        public static readonly Color PlaneColor = ColorFromHex(0xffffffff);
        public static readonly Color PaleColor = ColorFromHex(0x44ffffff);
        public static readonly Color AccentColor1 = ColorFromHex(0xffd45d87);
        public static readonly Color AccentColor2 = ColorFromHex(0xff3d93b6);

        public static Color ColorFromHex(uint hex)
        {
            var a = (hex >> 24) & 0xff;
            var r = (hex >> 16) & 0xff;
            var g = (hex >> 8) & 0xff;
            var b = (hex >> 0) & 0xff;
            return new Color((byte)r, (byte)g, (byte)b, (byte)a);
        }
    }
}