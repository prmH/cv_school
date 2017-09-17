using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Imaging;

namespace cvSchool
{
    public partial class cv_school : Form
    {
        string _mainPath = AppContext.BaseDirectory;        

        public cv_school()
        {
            InitializeComponent();
        }

        void writeLog(string info, bool isNew = false)
        {
            if (isNew) tbLog.AppendText("\r\n");
            tbLog.AppendText(info + "\r\n");
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            if (fdbMain.ShowDialog() == DialogResult.OK)
            {
                _mainPath = fdbMain.SelectedPath;
                tbPath.Text = _mainPath;
                tbLog.Clear();
                btFragment.Enabled = true;
                writeLog(String.Format("Исходный каталог: {0}", _mainPath));
            }
        }

        private void cv_school_Load(object sender, EventArgs e)
        {
            string _folder = "cv_school_test";            
            _mainPath = _mainPath.Substring(0, _mainPath.IndexOf(_folder) + _folder.Length);
            tbPath.Text = _mainPath;
            writeLog(String.Format("Исходный каталог: {0}", _mainPath));
        }        

        private void btFragment_Click(object sender, EventArgs e)
        {
            try
            {
                writeLog("1. Выделение фрагментов", true);
                string _srcFolder = _mainPath + @"\images\";
                string _frgFolder = _mainPath + @"\fragments\";
                string _antFolder = _mainPath + @"\annotations\";

                Int32 i = 0;
                Int32 x = 0;

                Directory.CreateDirectory(_frgFolder);
                writeLog(String.Format("Каталог с исходными картинками: {0}", _srcFolder));
                writeLog(String.Format("Каталог с фрагментами: {0}", _frgFolder));

                string[] files = Directory.GetFiles(_srcFolder);
                writeLog(String.Format("Количество файлов в каталоге: {0}", files.Length));

                foreach (string f in files)
                {
                    FileInfo file = new FileInfo(f);
                    Bitmap _src = new Bitmap(f);

                    x = 0;
                    i += 1;                    
                    writeLog(String.Format("Обработка {0}-го файла: {1}", i, file.Name), true);

                    var _antFile = file.Name.Substring(0, file.Name.IndexOf(file.Extension));
                    _antFile = _antFolder + _antFile + ".txt";
                    writeLog(String.Format("Файл с аннотациями: {0}", _antFile));

                    string[] _lines = File.ReadAllLines(_antFile);
                    writeLog(String.Format("Файл с аннотациями содержит {0} фрагмента", _lines.Length));

                    foreach (string _line in _lines)
                    {
                        writeLog(String.Format("Обработка фрагмента с координатами {0}", _line));
                        var _frgFile = file.Name.Substring(0, file.Name.IndexOf(file.Extension));
                        _frgFile = _frgFolder + _frgFile + "_" + x + ".png";
                        string[] _coord = _line.Split(',');
                        Rectangle rectangle = new Rectangle(Int32.Parse(_coord[0]), 
                                                            Int32.Parse(_coord[1]),
                                                            Int32.Parse(_coord[2]),
                                                            Int32.Parse(_coord[3]));
                        Bitmap _dst = CropImage(_src, rectangle);
                        _dst.Save(_frgFile);
                        writeLog(String.Format("Фрагент сохранен: {0}", _frgFile));
                        x += 1;
                    }                   
                }                
                writeLog("Выделение фрагментов успешно завершено!");
            }
            catch
            {
                writeLog("Упс! Произошла ошибка");
            }
        }

        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics g = Graphics.FromImage(bmp);            
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        private void btnGrey_Click(object sender, EventArgs e)
        {
            try
            {
                writeLog("2. Преобразование greyscale", true);
                string _srcFolder = _mainPath + @"\fragments\";
                string _grsFolder = _mainPath + @"\fragments_greyscale\";

                Directory.CreateDirectory(_grsFolder);
                writeLog(String.Format("Каталог с исходными фрагментами: {0}", _srcFolder));
                writeLog(String.Format("Каталог с преобразованными фрагментами: {0}", _grsFolder));

                string[] files = Directory.GetFiles(_srcFolder);
                writeLog(String.Format("Количество исходных фрагментов: {0}", files.Length));

                foreach (string f in files)
                {
                    FileInfo file = new FileInfo(f);
                    Bitmap _src = new Bitmap(f);
                    Bitmap _dst;
                    Int32 x, y;

                    writeLog(String.Format("Обработка фрагмента: {0}", file.Name));

                    for (x = 0; x < _src.Width; x++)
                    {
                        for (y = 0; y < _src.Height; y++)
                        {
                            Color pixelColor = _src.GetPixel(x, y);
                            int grayScale = (int)((pixelColor.R * 0.3) + (pixelColor.G * 0.59) + (pixelColor.B * 0.11));
                            Color newColor = Color.FromArgb(pixelColor.A, grayScale, grayScale, grayScale);
                            _src.SetPixel(x, y, newColor);
                        }
                    }
                    _dst = _src;

                    var _grsFile = file.Name.Substring(0, file.Name.IndexOf(file.Extension));
                    _grsFile = _grsFolder + _grsFile + "_grey" + ".png";
                    _dst.Save(_grsFile);
                    writeLog(String.Format("Преобразованный фрагент сохранен: {0}", _grsFile));                    
                }
                writeLog("Преобразование greyscale успешно завершено!");
            }
            catch
            {
                writeLog("Упс! Произошла ошибка");
            }            
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            try
            {
                writeLog("3. Отображение фрагментов по горизонтали", true);
                string _srcFolder = _mainPath + @"\fragments\";
                string _frfFolder = _mainPath + @"\fragments_flip\";

                Directory.CreateDirectory(_frfFolder);
                writeLog(String.Format("Каталог с исходными фрагментами: {0}", _srcFolder));
                writeLog(String.Format("Каталог с преобразованными фрагментами: {0}", _frfFolder));

                string[] files = Directory.GetFiles(_srcFolder);
                writeLog(String.Format("Количество исходных фрагментов: {0}", files.Length));

                foreach (string f in files)
                {
                    FileInfo file = new FileInfo(f);
                    Bitmap _src = new Bitmap(f);
                    Bitmap _dst;
                    
                    writeLog(String.Format("Обработка фрагмента: {0}", file.Name));

                    _src.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    _dst = _src;

                    var _frfFile = file.Name.Substring(0, file.Name.IndexOf(file.Extension));
                    _frfFile = _frfFolder + _frfFile + "_flip" + ".png";
                    _dst.Save(_frfFile);
                    writeLog(String.Format("Преобразованный фрагент сохранен: {0}", _frfFile));
                }
                writeLog("Преобразование фрагментов по горизонтали успешно завершено!");
            }
            catch
            {
                writeLog("Упс! Произошла ошибка");
            }            
        }

        private void btnNormalize_Click(object sender, EventArgs e)
        {
            try
            {
                writeLog("4. Нормализация изображений", true);
                string _srcFolder = _mainPath + @"\fragments_flip\";
                string _nrmFolder = _mainPath + @"\fragments_norm\";

                Directory.CreateDirectory(_nrmFolder);
                writeLog(String.Format("Каталог с исходными фрагментами: {0}", _srcFolder));
                writeLog(String.Format("Каталог с преобразованными фрагментами: {0}", _nrmFolder));

                string[] files = Directory.GetFiles(_srcFolder);
                writeLog(String.Format("Количество исходных фрагментов: {0}", files.Length));

                foreach (string f in files)
                {
                    FileInfo file = new FileInfo(f);
                    Bitmap _src = new Bitmap(f);
                    float minBrightness = 0;
                    float maxBrightness = 255;

                    writeLog(String.Format("Обработка фрагмента: {0}", file.Name));

                    Bitmap _dst = new Bitmap(_src.Width, _src.Height);

                    for (int x = 0; x < _src.Width; ++x)
                    {
                        for (int y = 0; y < _src.Height; ++y)
                        {
                            float pixelBrightness = _src.GetPixel(x, y).GetBrightness();
                            if (x == 0 && y == 0)
                            {
                                minBrightness = pixelBrightness;
                                maxBrightness = pixelBrightness;
                            }

                            minBrightness = Math.Min(minBrightness, pixelBrightness);
                            maxBrightness = Math.Max(maxBrightness, pixelBrightness);
                        }
                    }

                    for (int x = 0; x < _src.Width; x++)
                    {
                        for (int y = 0; y < _src.Height; y++)
                        {
                            Color pixelColor = _src.GetPixel(x, y);
                            float normalizedPixelBrightness = (pixelColor.GetBrightness() - minBrightness)*((1 - 0)/ (maxBrightness - minBrightness));
                            Color normalizedPixelColor = ColorFromAhsb(pixelColor.A, pixelColor.GetHue(), pixelColor.GetSaturation(), normalizedPixelBrightness);

                            _dst.SetPixel(x, y, normalizedPixelColor);
                        }
                    }

                    var _nrmFile = file.Name.Substring(0, file.Name.IndexOf(file.Extension));
                    _nrmFile = _nrmFolder + _nrmFile + "_norm" + ".png";
                    _dst.Save(_nrmFile);
                    writeLog(String.Format("Преобразованный фрагент сохранен: {0}", _nrmFile));
                }
                writeLog("Нормализация фрагментов успешно завершена!");
            }
            catch
            {
                writeLog("Упс! Произошла ошибка");
            }
        }
        public static Color ColorFromAhsb(int a, float h, float s, float b)
        {
            if (0 > a || 255 < a)
            {
                throw new ArgumentOutOfRangeException("a", a, "InvalidAlpha");
            }
            if (0f > h || 360f < h)
            {
                throw new ArgumentOutOfRangeException("h", h, "InvalidHue");
            }
            if (0f > s || 1f < s)
            {
                throw new ArgumentOutOfRangeException("s", s, "InvalidSaturation");
            }
            if (0f > b || 1f < b)
            {
                throw new ArgumentOutOfRangeException("b", b, "InvalidBrightness");
            }

            if (0 == s)
            {
                return Color.FromArgb(a, Convert.ToInt32(b * 255), Convert.ToInt32(b * 255), Convert.ToInt32(b * 255));
            }

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < b)
            {
                fMax = b - (b * s) + s;
                fMin = b + (b * s) - s;
            }
            else
            {
                fMax = b + (b * s);
                fMin = b - (b * s);
            }

            iSextant = (int)Math.Floor(h / 60f);
            if (300f <= h)
            {
                h -= 360f;
            }
            h /= 60f;
            h -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = h * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - h * (fMax - fMin);
            }

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(a, iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(a, iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(a, iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(a, iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(a, iMax, iMin, iMid);
                default:
                    return Color.FromArgb(a, iMax, iMid, iMin);
            }
        }

        private void btnNoise_Click(object sender, EventArgs e)
        {
            try
            {
                writeLog("5. Добавление шума", true);
                string _srcFolder = _mainPath + @"\fragments_greyscale\";
                string _frnFolder = _mainPath + @"\fragments_noise\";

                Directory.CreateDirectory(_frnFolder);
                writeLog(String.Format("Каталог с исходными фрагментами: {0}", _srcFolder));
                writeLog(String.Format("Каталог с преобразованными фрагментами: {0}", _frnFolder));

                string[] files = Directory.GetFiles(_srcFolder);
                writeLog(String.Format("Количество исходных фрагментов: {0}", files.Length));

                foreach (string f in files)
                {
                    FileInfo file = new FileInfo(f);
                    Bitmap _src = new Bitmap(f);                    

                    writeLog(String.Format("Обработка фрагмента: {0}", file.Name));

                    Bitmap _dst = addNoise(_src, 20);                                

                    var _frnFile = file.Name.Substring(0, file.Name.IndexOf(file.Extension));
                    _frnFile = _frnFolder + _frnFile + "_noise" + ".png";
                    _dst.Save(_frnFile);
                    writeLog(String.Format("Преобразованный фрагент сохранен: {0}", _frnFile));
                }
                writeLog("Добавление шума успешно завершена!");
            }
            catch
            {
                writeLog("Упс! Произошла ошибка");
            }
        }

        public static Bitmap addNoise(Bitmap src, int amount)
        {
            Bitmap dst = new Bitmap(src.Width, src.Height);           
            Random r = new Random();

            for (int x = 0; x < src.Width; ++x)
            {
                for (int y = 0; y < src.Height; ++y)
                {
                    Color pixelColor = src.GetPixel(x, y);
                    int R = pixelColor.R + r.Next(-amount, amount + 1);
                    int G = pixelColor.G + r.Next(-amount, amount + 1);
                    int B = pixelColor.B + r.Next(-amount, amount + 1);
                    R = R > 255 ? 255 : R;
                    R = R < 0 ? 0 : R;
                    G = G > 255 ? 255 : G;
                    G = G < 0 ? 0 : G;
                    B = B > 255 ? 255 : B;
                    B = B < 0 ? 0 : B;
                    Color newPixelColor = Color.FromArgb(R, G, B);
                    dst.SetPixel(x, y, newPixelColor);
                }
            }            
            return dst;
        }
    }
    
}
