using System;
using System.IO;
using System.Drawing; // علشان Image
using System.Drawing.Imaging;

namespace el_shabander.bl
{
    class methods
    {
        // الصورة كـ byte[]
        public byte[] by;

        // تحويل Image -> byte[]
        public byte[] convert_byte(Image img)
        {
            if (img == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                // نخزن الصورة بنفس الـ RawFormat (سواء PNG, JPEG...)
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }
        public byte[] convert_byte2(Image img)
        {
            if (img == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        // تحويل byte[] -> MemoryStream
        public MemoryStream convert_image()
        {
            if (by == null) return null;
            return new MemoryStream(by);
        }

        // تحويل byte[] -> Image (لو محتاج تعرض الصورة مباشرة)
        public Image byte_to_image()
        {
            if (by == null) return null;
            using (MemoryStream ms = new MemoryStream(by))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
