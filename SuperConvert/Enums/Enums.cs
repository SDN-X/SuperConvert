using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SuperConvert
{
    public static class Enums
    {
        public enum Calender
        {
            Gregorian = 1,
            Hijri = 2
        }
        public enum ExcelFileType
        {
            CSV = 1,
            XLS = 2,
            XLSX = 3
        }
        public enum FileFormat
        {
            None = 0,
            DOC = 1,
            DOCX = 2,
            EML = 3,
            LOG = 4,
            MSG = 5,
            ODT = 6,
            RTF = 7,
            TXT = 8,
            WPD = 9,
            AAE = 10,
            BIN = 11,
            CSV = 12,
            DAT = 13,
            KEY = 14,
            MPP = 15,
            OBB = 16,
            PPT = 17,
            PPTX = 18,
            RPT = 19,
            SDF = 20,
            TAR = 21,
            VCF = 22,
            XML = 23,
            BMP = 24,
            DCM = 25,
            DDS = 26,
            DJVU = 27,
            GIF = 28,
            HEIC = 29,
            JPG = 30,
            PNG = 31,
            PSD = 32,
            TGA = 33,
            TIF = 34
        }
    }
}