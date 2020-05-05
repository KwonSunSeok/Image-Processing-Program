using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace Day019_01_칼라_영상처리_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte[,,] inImage, outImage;
        int inH, inW, outH, outW;
        Bitmap paper, image;
        string filename = "";

        ///////////////////////        
        /// *** 공통함수 *** ///
        ///////////////////////

        /// <summary>
        /// Open Image함수
        /// </summary>
        private void OpenImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "";
            ofd.Filter = "Color FIle(*.png;*.jpg;*.bmp;*.tif) | *.png;*.jpg;*.bmp;*.tif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                // 파일 --> 비트맵(image)
                image = new Bitmap(filename);

                //** 중요 ** --> 영상크기  및 메모리 할당
                inW = image.Height;
                inH = image.Width;
                inImage = new byte[3, inH, inW];
                // 파일 --> 배열로 값을 로딩하기
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        Color c = image.GetPixel(i, k);
                        inImage[0, i, k] = c.R;
                        inImage[1, i, k] = c.G;
                        inImage[2, i, k] = c.B;
                    }
                Equal();
            }
        }

        /// <summary>
        /// Save Image 함수
        /// </summary>
        private void SaveImage()
        {
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.DefaultExt = "";
            sdf.Filter = "PNG File(*.png) | *.png";
            if (sdf.ShowDialog() == DialogResult.OK)
            {
                string saveFname = sdf.FileName;
                image = new Bitmap(outH, outW);
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                    {
                        Color c;
                        int r, g, b;
                        r = outImage[0, i, k];
                        g = outImage[1, i, k];
                        b = outImage[2, i, k];
                        c = Color.FromArgb(r, g, b);
                        image.SetPixel(i, k, c);
                    }
                image.Save(saveFname, ImageFormat.Png);
                MessageBox.Show(saveFname + " 저장됨");
            }
        }

        /// /// <summary>
        /// DisplayImage 함수
        /// </summary>
        private void DisplayImage()
        {
            // Form 및 pictureBox 크기 조절
            int tempW = 0;
            if (outW < inW)
                tempW = inW;
            else
                tempW = outW;
            this.Size = new System.Drawing.Size(inH + outH + 50, tempW + 90);
            pictureBox1.Size = new System.Drawing.Size(inH, inW);
            pictureBox2.Size = new System.Drawing.Size(outH, outW);

            // 출력될 이미지의 각각의 픽셀값 저장
            Color c;
            int r, g, b;
            paper = new Bitmap(inH, inW);
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    r = inImage[0, i, k];
                    g = inImage[1, i, k];
                    b = inImage[2, i, k];
                    c = Color.FromArgb(r, g, b);
                    paper.SetPixel(i, k, c);
                }
            pictureBox1.Image = paper;
            pictureBox1.Location = new System.Drawing.Point(10, 25);
            paper = new Bitmap(outH, outW);
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    r = outImage[0, i, k];
                    g = outImage[1, i, k];
                    b = outImage[2, i, k];
                    c = Color.FromArgb(r, g, b);
                    paper.SetPixel(i, k, c);
                }
            pictureBox2.Image = paper;
            pictureBox2.Location = new System.Drawing.Point(inH + 30, 25);
        }

        /// <summary>
        /// QuickSort 함수
        /// </summary>
        /// <param 정렬 할 1차원 배열="numbers"></param>
        /// <param 왼쪽 끝 값="left"></param>
        /// <param 오른쪽 끝 값="right"></param>
        private void QuickSort(int[] numbers, int left, int right)
        {
            int l_hold = left, r_hold = right;      // 최초 left와 right를 기억한다.
            int pivot = numbers[left];              // 최초 피봇은 left부터 시작한다.

            // left와 right가 만날 때까지 실행을 한다.
            while (left < right)
            {
                // right와 피봇을 비교하여 right가 피봇보다 값이 작을 경우 피봇에 left에 right 값을 넣어준다.
                while ((pivot <= numbers[right]) && (left < right))
                    right--;
                if (left != right)
                    numbers[left] = numbers[right];

                // left와 피봇을 비교하여 left가 피봇보다 값이 높을 경우 피봇에 right에 left 값을 넣어준다.
                while ((pivot >= numbers[left]) && (left < right))
                    left++;
                if (left != right)
                {
                    numbers[right] = numbers[left];
                    right--; // right의 위치를 왼쪽으로 이동하여 다시 반복한다.
                }
            }

            // left와 right가 같아지는 순간 해당 위치는 피봇으로 값을 변환해준다.
            // 이렇게 되면 변경된 피봇의 위치를 기준으로 피봇보다 작으면 왼쪽, 피봇보다 크면 오른쪽으로 이동
            // 값을 다시 정리
            numbers[left] = pivot;
            pivot = left;
            left = l_hold;
            right = r_hold;

            // 위 과정을 재귀호출을 하여 정렬이 될 때까지 반복
            if (left < pivot)
                QuickSort(numbers, left, pivot - 1);
            if (right > pivot)
                QuickSort(numbers, pivot + 1, right);
        }

        /// <summary>
        /// Sub_input1 form에서 가져올 하나의 값
        /// </summary>
        /// <returns></returns>
        private double GetDoubleValue()
        {
            double retValue = 0.0;
            Sub_Input1 dlg = new Sub_Input1();
            if (dlg.ShowDialog(this) == DialogResult.OK) // this : 메인폼의 서브폼으로 인식하게 하기 위해
                                                         // Sub_Input1 form의 DialogResult가 OK이면 구문 수행
            {
                retValue = (double)dlg.numerick_double.Value;
            }
            return retValue;
        }

        /// <summary>
        /// Sub_input2 form에서 가져올 두개의 값
        /// </summary>
        /// <returns></returns>
        private double[] GetTwoDoubleValue()
        {
            double[] retValue = new double[2];
            Sub_Input2 dlg = new Sub_Input2();
            if (dlg.ShowDialog(this) == DialogResult.OK) // this : 메인폼의 서브폼으로 인식하게 하기 위해
                                                         // Sub_Input1 form의 DialogResult가 OK이면 구문 수행
            {
                retValue[0] = (double)dlg.numeric_double1.Value;
                retValue[1] = (double)dlg.numeric_double2.Value;
            }
            return retValue;
        }


        /// <summary>
        /// 파일이 없는 상태에서 메뉴를 선택 했을 경우 발생되는 함수
        /// </summary>
        /// <returns></returns>
        private bool CheckOpen()
        {
            if (filename.Length <= 0 || filename is null)
            {
                statusStrip1.Text = "파일을 먼저 열어야 합니다.";
                return false;
            }
            return true;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch(e.KeyCode)
                {
                    case Keys.O: OpenImage(); break;
                    case Keys.S: SaveImage(); break;
                }
            }
        }
        



        ///////////////////////////////////////////////
        /// *** 메뉴 선택시 실행되는 이벤트 함수들 *** ///
        ///////////////////////////////////////////////

        /// <summary>
        /// 열기
        /// </summary>
        private void 열기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        /// <summary>
        /// 저장
        /// </summary>
        private void 저장ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        /// <summary>
        /// 종료
        /// </summary>
        private void 종료ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void 동일이미지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Equal();
        }

        private void 밝게하기ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Bright();
        }

        private void 어둡게하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dark();
        }

        private void 곱하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Multiply();
        }

        private void 나누기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Division();
        }

        private void 반전ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reversal();
        }

        private void 흑백변환ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlackWhite();
        }

        private void 감마변환ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GammaTransform();
        }

        private void 오목파라볼라변환ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConcaveParabolaTransform();
        }

        private void 볼록파라볼라변환ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvexParabolaTransform();
        }

        private void 범위처리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RangeProcess();
        }

        private void 채도변경ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            outH = inH; outW = inW;
            outImage = new byte[3, outH, outW];
            // RGB --> HSV
            Color c;    // 색상 픽셀
            double hh, ss, vv;
            int rr, gg, bb;

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    rr = inImage[0, i, k];
                    gg = inImage[1, i, k];
                    bb = inImage[2, i, k];
                    c = Color.FromArgb(rr, gg, bb); // 색상 픽셀
                    hh = c.GetHue();
                    ss = c.GetSaturation();
                    vv = c.GetBrightness();
                    vv = vv - 0.05;                 // 채도 정도 ( -1 ~ 1 )
                    HsvToRgb(hh, ss, vv, out rr, out gg, out bb);
                    outImage[0, i, k] = (byte)rr;
                    outImage[1, i, k] = (byte)gg;
                    outImage[2, i, k] = (byte)bb;
                }
            DisplayImage();
        }




        private void 상하대칭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpDownSymmetry();
        }

        private void 좌우대칭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeftRightSymmetry();
        }

        private void 화면이동ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move_Screen();
        }

        private void 일반축소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom_Out();
        }

        private void 평균값축소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom_Out_Avg();
        }

        private void 중위값축소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom_Out_Median();
        }

        private void 일반확대ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom_In();
        }

        private void 백워딩확대ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom_In_Back();
        }

        private void 회전ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotate_Center();
        }




        private void 엠보싱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embossing();
        }

        private void 블러링ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blurr();
        }

        private void 스무딩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Smoothing();
        }

        private void 샤프닝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sharpening();
        }

        private void 샤프닝HPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sharpening_Hpf();
        }

        private void 샤프닝LPFToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sharpening_Lpf();
        }


        /////////////////////////////////////
        /// *** 영상 처리 알고리즘 함수 *** ///
        /////////////////////////////////////


        /// <summary>
        /// 화소점 동일 알고리즘
        /// </summary>
        private void Equal()
        {
            outH = inH; outW = inW;
            outImage = new byte[3, outH, outW];
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                        outImage[rgb, i, k] = inImage[rgb, i, k];
            DisplayImage();
        }

        /// <summary>
        /// 화소점 덧셈 알고리즘 (밝게하기)
        /// </summary>
        private void Bright()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }

            int value = (int)GetDoubleValue();
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        if (inImage[rgb, i, k] + value > 255)
                            outImage[rgb, i, k] = 255;
                        else
                            outImage[rgb, i, k] = (byte)(inImage[rgb, i, k] + value);
                    }
            DisplayImage();
        }

        /// <summary>
        /// 화소점 뺄셈 알고리즘 (어둡게하기)
        /// </summary>
        private void Dark()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }

            int value = (int)GetDoubleValue();
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        if (inImage[rgb, i, k] - value < 0)
                            outImage[rgb, i, k] = 0;
                        else
                            outImage[rgb, i, k] = (byte)(inImage[rgb, i, k] - value);
                    }
            DisplayImage();
        }

        /// <summary>
        /// 화소점 곱셈 알고리즘 (뚜렷하게하기)
        /// </summary>
        private void Multiply()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }

            int value = (int)GetDoubleValue();
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        if (outImage[rgb, i, k] * value > 255)
                            outImage[rgb, i, k] = 255;
                        else
                            outImage[rgb, i, k] = (byte)(outImage[rgb, i, k] * value);
                    }
            DisplayImage();
        }

        /// <summary>
        /// 화소점 나눗셈 알고리즘 (희미하게하기)
        /// </summary>
        private void Division()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }

            int value = (int)GetDoubleValue();
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                        outImage[rgb, i, k] = (byte)(outImage[rgb, i, k] / value);
            DisplayImage();
        }

        /// <summary>
        /// 화소점 반전 알고리즘
        /// </summary>
        private void Reversal()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                        outImage[rgb, i, k] = (byte)(255 - outImage[rgb, i, k]);
            DisplayImage();
        }

        /// <summary>
        /// 화소점 흑백변환 알고리즘
        /// </summary>
        private void BlackWhite()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        outImage[rgb, i, k] = (byte)((outImage[0, i, k] + outImage[1, i, k] + outImage[2, i, k]) / 3);
                    }
            DisplayImage();
        }

        /// <summary>
        /// 화소점 감마변환 알고리즘
        /// </summary>
        private void GammaTransform()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            double gamma = GetDoubleValue();

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        outImage[rgb, i, k] = (byte)(255.0 * Math.Pow(outImage[rgb, i, k] / 255.0, 1.0 / gamma));
                    }
            DisplayImage();
        }

        /// <summary>
        /// 화소점 오목 파라볼라 변환 알고리즘
        /// </summary>
        private void ConcaveParabolaTransform()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                        outImage[rgb, i, k] = (byte)(255.0 * (outImage[rgb, i, k] / 128.0 - 1) * (outImage[rgb, i, k] / 128.0 - 1));
            DisplayImage();
        }

        /// <summary>
        /// 화소점 볼록 파라볼라 변환 알고리즘
        /// </summary>
        private void ConvexParabolaTransform()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                        outImage[rgb, i, k] = (byte)(255.0 - 255.0 * (outImage[rgb, i, k] / 128.0 - 1) * (outImage[rgb, i, k] / 128.0 - 1));
            DisplayImage();
        }

        /// <summary>
        /// 화소점 범위처리 알고리즘
        /// </summary>
        private void RangeProcess()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            double[] arr = GetTwoDoubleValue();
            int first = (int)arr[0];
            int second = (int)arr[1];
            if (first > second)
            {
                int temp = first;
                first = second;
                second = temp;
            }

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        if (outImage[rgb, i, k] < second && outImage[rgb, i, k] > first)
                        {
                            outImage[rgb, i, k] = 0;
                        }
                        else
                            outImage[rgb, i, k] = outImage[rgb, i, k];
                    }
            DisplayImage();
        }

        /// <summary>
        /// 화소점 채도변경
        /// </summary>
        int CheckRange(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }
        void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
        {
            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color
                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color
                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color
                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color
                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.
                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.
                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            r = CheckRange((int)(R * 255.0));
            g = CheckRange((int)(G * 255.0));
            b = CheckRange((int)(B * 255.0));
        }



        /// <summary>
        /// 기하학 상하대칭 변환 알고리즘
        /// </summary>
        private void UpDownSymmetry()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < (sK + eK) / 2; k++)
                    {
                        byte temp = outImage[rgb, i, k];
                        outImage[rgb, i, k] = outImage[rgb, i, (sK + eK) - k - 1];
                        outImage[rgb, i, (sK + eK) - k - 1] = temp;
                    }
            DisplayImage();
        }

        /// <summary>
        /// 기하학 좌우대칭 변환 알고리즘
        /// </summary>
        private void LeftRightSymmetry()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sK; i < eK; i++)
                    for (int k = sI; k < (sI + eI) / 2; k++)
                    {
                        byte temp = outImage[rgb, k, i];
                        outImage[rgb, k, i] = outImage[rgb, (sI + eI) - k - 1, i];
                        outImage[rgb, (sI + eI) - k - 1, i] = temp;
                    }
            DisplayImage(); 
        }

        /// <summary>
        /// 기하학 화면이동 알고리즘
        /// </summary>
        private void Move_Screen()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            outImage = new byte[3, outH, outW];

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }

            double[] xVal = GetTwoDoubleValue();
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        if ((0 <= i - xVal[0] && i - xVal[0] < eK) && (0 <= k - xVal[1] && k - xVal[1] < eI))
                            outImage[rgb, i - (int)xVal[0], k - (int)xVal[1]] = inImage[rgb, i, k];
                    }
            DisplayImage();
        }

        /// <summary>
        /// 기하학 화면축소 알고리즘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zoom_Out()
        {
            if (!CheckOpen())
                return;
            int scale = (int)GetDoubleValue();
            outH = inH / scale; outW = inW / scale;
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        if ((0 <= i / scale && i / scale < outW) && (0 <= k / scale && k / scale < outH))
                            outImage[rgb, i / scale, k / scale] = inImage[rgb, i, k];
                    }
            DisplayImage();
        }

        /// <summary>
        /// 기하학 화면축소(평균값) 알고리즘
        /// </summary>
        private void Zoom_Out_Avg()
        {
            if (!CheckOpen())
                return;
            int scale = (int)GetDoubleValue();
            outH = inH / scale; outW = inW / scale;
            double S = 0;
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH - 2; i += scale)
                    for (int k = 0; k < inW - 2; k += scale)
                    {
                        for (int m = 0; m < scale; m++)
                            for (int n = 0; n < scale; n++)
                            {
                                S += inImage[rgb, i + m, k + n];
                            }
                        outImage[rgb, i / scale, k / scale] = (byte)(S / (scale * scale));
                        S = 0.0;
                    }
            DisplayImage();
        }

        /// <summary>
        /// 기하학 화면축소(중위수) 알고리즘
        /// </summary>
        private void Zoom_Out_Median()
        {
            if (!CheckOpen())
                return;
            int scale = (int)GetDoubleValue();
            outH = inH / scale; outW = inW / scale;
            int index = 0;
            int[] arr = { };
            Array.Resize(ref arr, arr.Length + scale * scale);
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH - 2; i += scale)
                    for (int k = 0; k < inW - 2; k += scale)
                    {
                        for (int m = 0; m < scale; m++)
                            for (int n = 0; n < scale; n++)
                            {
                                arr[index++] = inImage[rgb, i + m, k + n];
                            }
                        Array.Sort(arr);
                        outImage[rgb, i / scale, k / scale] = (byte)arr[(scale * scale) / 2];
                        index = 0;
                    }
            DisplayImage();
        }

        /// <summary>
        /// 기하학 화면확대 알고리즘
        /// </summary>
        private void Zoom_In()
        {
            if (!CheckOpen())
                return;
            int scale = (int)GetDoubleValue();
            outH = inH * scale; outW = inW * scale;
            outImage = new byte[3, outH, outW];
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        if ((0 <= i * scale && i * scale < outW) && (0 <= k * scale && k * scale < outH))
                            outImage[rgb, i * scale, k * scale] = inImage[rgb, i, k];
                    }
            DisplayImage();
        }

        /// <summary>
        /// 기하학 화면확대(백워딩 확대)
        /// </summary>
        private void Zoom_In_Back()
        {
            if (!CheckOpen())
                return;
            int scale = (int)GetDoubleValue();

            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }

            outH = (eI - sI + 1) * scale; outW = (eK - sK + 1) * scale;
            outImage = new byte[3, outH, outW];
            int p = 0, q = 0;
            for (int rgb = 0; rgb < 3; rgb++)
            {
                for (int i = sI; i < eI; i++)
                {
                    for (int k = sK; k < eK; k++)
                    {
                        for (int m = 0; m < scale; m++)
                        {
                            for (int n = 0; n < scale; n++)
                            {
                                outImage[rgb, p + m, q + n] = inImage[rgb, i, k];
                            }
                        }
                        q += scale;
                    }
                    q = 0;
                    p += scale;
                }
                p = 0;
            }
            DisplayImage();
        }

        /// <summary>
        /// 기하학 기본회전 알고리즘
        /// </summary>
        private void Rotate_Basic()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            outImage = new byte[3, outH, outW];
            int angle = (int)GetDoubleValue();
            double r = angle * Math.PI / 180.0;    // 입력받은 각도를 Degree -> Radian으로 변환
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        int newI = (int)(Math.Cos(r) * i + Math.Sin(r) * k);
                        int newK = (int)(-Math.Sin(r) * i + Math.Cos(r) * k);

                        if ((0 <= newI && newI < outW) && (0 <= newK && newK < outH))
                            outImage[rgb, newI, newK] = inImage[rgb, i, k];
                    }
            DisplayImage();
        }

        /// <summary>
        /// 기하학 중앙회전 알고리즘
        /// </summary>
        private void Rotate_Center()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            outImage = new byte[3, outH, outW];
            int angle = (int)GetDoubleValue();
            double r = angle * Math.PI / 180.0;    // 입력받은 각도를 Degree -> Radian으로 변환
            int cx = inH / 2;
            int cy = inW / 2;
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                    {
                        int oldI = (int)(Math.Cos(r) * (i - cx) + Math.Sin(r) * (k - cy)) + cx;
                        int oldK = (int)(-Math.Sin(r) * (i - cx) + Math.Cos(r) * (k - cy)) + cy;

                        if ((0 <= oldI && oldI < outW) && (0 <= oldK && oldK < outH))
                            outImage[rgb, i, k] = inImage[rgb, oldI, oldK];
                    }
            DisplayImage();
        }

        /// <summary>
        /// 기하학 영상 90도 회전(반시계) 알고리즘
        /// </summary>
        private void Turn90Degree()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            byte[,,] temp = new byte[3, outH, outW];                // 치환을 위한 temp 배열 선언
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)                       // temp 2차배열에 이미지 저장
                    for (int k = 0; k < inW; k++)
                        temp[rgb, i, k] = outImage[rgb, i, k];
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)                       // 이미지의 오른쪽 반을 먼저 반시계 방향으로 90도 회전 하여 outImage에 저장
                    for (int k = 0; k < inW / 2; k++)
                        outImage[rgb, k, i] = outImage[rgb, i, inW - k - 1];
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)                       // 이미지의 왼쪽 반을 반시계 방향으로 90도 회전 하여 outImage에 저장
                    for (int k = inW / 2; k < inW; k++)
                        outImage[rgb, k, i] = temp[rgb, i, inW - k - 1];
            DisplayImage();
        }

        /// <summary>
        /// 기하학 영상 90도 회전(시계) 알고리즘
        /// </summary>
        private void Turn90DegreeClock()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            byte[,] temp = new byte[outH, outW];                // 치환을 위한 temp 배열 선언
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)                       // temp 2차배열에 이미지 저장
                    for (int k = 0; k < inW; k++)
                        temp[i, k] = outImage[rgb, i, k];
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)                       // 이미지의 오른쪽 반을 먼저 시계 방향으로 90도 회전 하여 outImage에 저장
                    for (int k = 0; k < inW / 2; k++)
                        outImage[rgb, i, k] = outImage[rgb, inH - k - 1, i];
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)                       // 이미지의 왼쪽 반을 시계 방향으로 90도 회전 하여 outImage에 저장
                    for (int k = inW / 2; k < inW; k++)
                        outImage[rgb, i, k] = temp[inH - k - 1, i];
            DisplayImage();
        }




        /// <summary>
        /// 화소영역 엠보싱 알고리즘
        /// </summary>
        private void Embossing()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            const int mSize = 3;    // 마스크 사이즈
            // 마스크 정의
            double[,] mask = new double[mSize, mSize]
            { { -1.0, 0.0, 0.0 },
              {  0.0, 0.0, 0.0 },
              {  0.0, 0.0, 1.0 } };
            // 임시 입력, 임시 출력 메모리 할당
            double[,,] tmpInImage = new double[3, inH + 2, inW + 2];
            double[,,] tmpOutImage = new double[3, outH, outW];

            // 임시 입력을 127로 초기화
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH + 2; i++)
                    for (int k = 0; k < inW + 2; k++)
                        tmpInImage[rgb, i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                        tmpInImage[rgb, i + 1, k + 1] = inImage[rgb, i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        // 한 점에 대해서 마스크와 연산
                        for (int m = 0; m < mSize; m++)
                            for (int n = 0; n < mSize; n++)
                                S += mask[m, n] * tmpInImage[rgb, i + m, k + n];
                        tmpOutImage[rgb, i, k] = S;
                        S = 0.0;
                    }
            // 마스크의 합계가 0이면 전체에 128을 더한다.
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                        tmpOutImage[rgb, i, k] += 128;
            // 임시출력 -> 출력
            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        if (tmpOutImage[rgb, i, k] > 255)
                            outImage[rgb, i, k] = 255;
                        else if (tmpOutImage[rgb, i, k] < 0)
                            outImage[rgb, i, k] = 0;
                        else
                            outImage[rgb, i, k] = (byte)tmpOutImage[rgb, i, k];
                    }
            DisplayImage();
        }

        /// <summary>
        /// 화소영역 블러링 알고리즘
        /// </summary>
        private void Blurr()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            const int mSize = 3;    // 마스크 사이즈
            // 마스크 정의
            double[,] mask = new double[mSize, mSize]
            { { 1/9.0, 1/9.0, 1/9.0 },
              { 1/9.0, 1/9.0, 1/9.0 },
              { 1/9.0, 1/9.0, 1/9.0 } };
            // 임시 입력, 임시 출력 메모리 할당
            double[,,] tmpInImage = new double[3, inH + 2, inW + 2];
            double[,,] tmpOutImage = new double[3, outH, outW];

            // 임시 입력을 127로 초기화
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH + 2; i++)
                    for (int k = 0; k < inW + 2; k++)
                        tmpInImage[rgb, i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                        tmpInImage[rgb, i + 1, k + 1] = inImage[rgb, i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        // 한 점에 대해서 마스크와 연산

                        for (int m = 0; m < mSize; m++)
                            for (int n = 0; n < mSize; n++)
                                S += mask[m, n] * tmpInImage[rgb, i + m, k + n];
                        tmpOutImage[rgb, i, k] = S;
                        S = 0.0;
                    }
            // 임시출력 -> 출력
            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        if (tmpOutImage[rgb, i, k] > 255)
                            outImage[rgb, i, k] = 255;
                        else if (tmpOutImage[rgb, i, k] < 0)
                            outImage[rgb, i, k] = 0;
                        else
                            outImage[rgb, i, k] = (byte)tmpOutImage[rgb, i, k];
                    }
            DisplayImage();
        }

        /// <summary>
        /// 화소영역 스무딩(가우시안) 알고리즘
        /// </summary>
        private void Smoothing()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            const int mSize = 3;    // 마스크 사이즈
            // 마스크 정의
            double[,] mask = new double[mSize, mSize]
            { { 1/16.0, 1/8.0, 1/16.0 },
              {  1/8.0, 1/4.0,  1/8.0 },
              { 1/16.0, 1/8.0, 1/16.0 } };
            // 임시 입력, 임시 출력 메모리 할당
            double[,,] tmpInImage = new double[3, inH + 2, inW + 2];
            double[,,] tmpOutImage = new double[3, outH, outW];

            // 임시 입력을 127로 초기화
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH + 2; i++)
                    for (int k = 0; k < inW + 2; k++)
                        tmpInImage[rgb, i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                        tmpInImage[rgb, i + 1, k + 1] = inImage[rgb, i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        // 한 점에 대해서 마스크와 연산
                        for (int m = 0; m < mSize; m++)
                            for (int n = 0; n < mSize; n++)
                                S += mask[m, n] * tmpInImage[rgb, i + m, k + n];
                        tmpOutImage[rgb, i, k] = S;
                        S = 0.0;
                    }
            // 임시출력 -> 출력
            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        if (tmpOutImage[rgb, i, k] > 255)
                            outImage[rgb, i, k] = 255;
                        else if (tmpOutImage[rgb, i, k] < 0)
                            outImage[rgb, i, k] = 0;
                        else
                            outImage[rgb, i, k] = (byte)tmpOutImage[rgb, i, k];
                    }
            DisplayImage();
        }

        /// <summary>
        /// 화소영역 샤프닝 알고리즘
        /// </summary>
        private void Sharpening()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            const int mSize = 3;    // 마스크 사이즈
            // 마스크 정의
            double[,] mask = new double[mSize, mSize]
            { {  0.0, -1.0,  0.0 },
              { -1.0,  5.0, -1.0 },
              {  0.0, -1.0,  0.0 } };
            // 임시 입력, 임시 출력 메모리 할당
            double[,,] tmpInImage = new double[3, inH + 2, inW + 2];
            double[,,] tmpOutImage = new double[3, outH, outW];

            // 임시 입력을 127로 초기화
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH + 2; i++)
                    for (int k = 0; k < inW + 2; k++)
                        tmpInImage[rgb, i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                        tmpInImage[rgb, i + 1, k + 1] = inImage[rgb, i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        // 한 점에 대해서 마스크와 연산
                        for (int m = 0; m < mSize; m++)
                            for (int n = 0; n < mSize; n++)
                                S += mask[m, n] * tmpInImage[rgb, i + m, k + n];
                        tmpOutImage[rgb, i, k] = S;
                        S = 0.0;
                    }
            // 임시출력 -> 출력
            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        if (tmpOutImage[rgb, i, k] > 255)
                            outImage[rgb, i, k] = 255;
                        else if (tmpOutImage[rgb, i, k] < 0)
                            outImage[rgb, i, k] = 0;
                        else
                            outImage[rgb, i, k] = (byte)tmpOutImage[rgb, i, k];
                    }
            DisplayImage();
        }

        /// <summary>
        /// 화소영역 고주파 통과 필터를 이용한 샤프닝 알고리즘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sharpening_Hpf()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            const int mSize = 3;    // 마스크 사이즈
            // 마스크 정의
            double[,] mask = new double[mSize, mSize]
            { { -1/9.0, -1/9.0, -1/9.0 },
              { -1/9.0,  8/9.0, -1/9.0 },
              { -1/9.0, -1/9.0, -1/9.0 } };
            // 임시 입력, 임시 출력 메모리 할당
            double[,,] tmpInImage = new double[3, inH + 2, inW + 2];
            double[,,] tmpOutImage = new double[3, outH, outW];

            // 임시 입력을 127로 초기화
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH + 2; i++)
                    for (int k = 0; k < inW + 2; k++)
                        tmpInImage[rgb, i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                        tmpInImage[rgb, i + 1, k + 1] = inImage[rgb, i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        // 한 점에 대해서 마스크와 연산
                        for (int m = 0; m < mSize; m++)
                            for (int n = 0; n < mSize; n++)
                                S += mask[m, n] * tmpInImage[rgb, i + m, k + n];
                        tmpOutImage[rgb, i, k] = S;
                        S = 0.0;
                    }
            // 마스크의 합계가 0이면 전체에 128을 더한다.
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                        tmpOutImage[rgb, i, k] += 128;
            // 임시출력 -> 출력
            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        if (tmpOutImage[rgb, i, k] > 255)
                            outImage[rgb, i, k] = 255;
                        else if (tmpOutImage[rgb, i, k] < 0)
                            outImage[rgb, i, k] = 0;
                        else
                            outImage[rgb, i, k] = (byte)tmpOutImage[rgb, i, k];
                    }
            DisplayImage();
        }

        /// <summary>
        /// 화소영역 저주파 통과 필터를 이용한 샤프닝 알고리즘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sharpening_Lpf()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            const int mSize = 3;    // 마스크 사이즈
            // 마스크 정의
            double[,] mask = new double[mSize, mSize]
            { { 1/9.0, 1/9.0, 1/9.0 },
              { 1/9.0, 1/9.0, 1/9.0 },
              { 1/9.0, 1/9.0, 1/9.0 } };
            // 임시 입력, 임시 출력 메모리 할당
            double[,,] tmpInImage = new double[3, inH + 2, inW + 2];
            double[,,] tmpOutImage = new double[3, outH, outW];

            // 임시 입력을 127로 초기화
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH + 2; i++)
                    for (int k = 0; k < inW + 2; k++)
                        tmpInImage[rgb, i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                        tmpInImage[rgb, i + 1, k + 1] = inImage[rgb, i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        // 한 점에 대해서 마스크와 연산
                        for (int m = 0; m < mSize; m++)
                            for (int n = 0; n < mSize; n++)
                                S += mask[m, n] * tmpInImage[rgb, i + m, k + n];
                        tmpOutImage[rgb, i, k] = S;
                        S = 0.0;
                    }
            // 임시출력 -> 출력
            int sI = 0, eI = inH, sK = 0, eK = inW;
            if (mouseYN == true)
            {
                sI = sx; eI = ex;
                sK = sy; eK = ey;
                mouseYN = false;
            }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = sI; i < eI; i++)
                    for (int k = sK; k < eK; k++)
                    {
                        if (tmpOutImage[rgb, i, k] > 255)
                            outImage[rgb, i, k] = 255;
                        else if (tmpOutImage[rgb, i, k] < 0)
                            outImage[rgb, i, k] = 0;
                        else
                            outImage[rgb, i, k] = (byte)tmpOutImage[rgb, i, k];
                    }
            DisplayImage();
        }




        /// <summary>
        /// 히스토스트래치 알고리즘
        /// </summary>
        private void HistoStretch()
        {
            if (!CheckOpen())
                return;
            // ** 중요 ** 출력 영상의 크기를 결정 --> 알고리즘에 따라 다름
            outH = inH; outW = inW;
            // *** 진짜 영상처리 알고리즘 *** Output = Input
            // Output = (Input - 최소)/(최대-최소)*255
            byte minVal = inImage[0, 0, 0];
            byte maxVal = inImage[0, 0, 0];
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        if (inImage[rgb, i, k] < minVal)
                            minVal = inImage[rgb, i, k];
                        if (inImage[rgb, i, k] > maxVal)
                            maxVal = inImage[rgb, i, k];
                    }
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        double IN = inImage[rgb, i, k];
                        double OUT = (IN - minVal) / (double)(maxVal - minVal) * 255;
                        outImage[rgb, i, k] = (byte)OUT;
                    }
            DisplayImage();
        }

        /// <summary>
        /// 엔드-인 탐색 알고리즘
        /// </summary>
        private void EndInSearch()
        {
            if (!CheckOpen())
                return;
            // ** 중요 ** 출력 영상의 크기를 결정 --> 알고리즘에 따라 다름
            outH = inH; outW = inW;
            // *** 진짜 영상처리 알고리즘 *** Output = Input
            // Output = (Input - 최소)/(최대-최소)*255
            byte minVal = inImage[0, 0, 0];
            byte maxVal = inImage[0, 0, 0];
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        if (inImage[rgb, i, k] < minVal)
                            minVal = inImage[rgb, i, k];
                        if (inImage[rgb, i, k] > maxVal)
                            maxVal = inImage[rgb, i, k];
                    }
            minVal += 50; maxVal -= 50;
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        double IN = inImage[rgb, i, k];
                        double OUT = (IN - minVal) / (double)(maxVal - minVal) * 255;
                        if (OUT > 255)
                            outImage[rgb, i, k] = 255;
                        else if (OUT < 0)
                            outImage[rgb, i, k] = 0;
                        else
                            outImage[rgb, i, k] = (byte)OUT;
                    }
            DisplayImage();
        }

        /// <summary>
        /// 히스토그램 평활화 알고리즘
        /// </summary>
        private void HistoEqual()
        {
            if (!CheckOpen())
                return;
            // ** 중요 ** 출력 영상의 크기를 결정 --> 알고리즘에 따라 다름
            outH = inH; outW = inW;
            // 출력 영상 메모리 할당
            outImage = new byte[3, outH, outW];
            // *** 진짜 영상처리 알고리즘 ***
            // 1단계 : 히스코그램 생성
            int[] histo = new int[256];
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                        histo[inImage[rgb, i, k]]++;
            // 2단계 : 누적히스토그램 생성
            int[] sumHisto = new int[256];
            int sumVal = 0;
            for (int i = 0; i < histo.Length; i++)
            {
                sumVal += histo[i];
                sumHisto[i] = sumVal;
            }
            // 3단계 : 정규화된 누적히스토그램 생성
            // 결과 = (누적합 / (영상행개수*영상열개수)) * 255
            double[] normalHisto = new double[256];
            for (int i = 0; i < sumHisto.Length; i++)
                normalHisto[i] = (double)sumHisto[i] / (outW * outH) * 255;
            // 4단계 : 정규화된 값으로 영상을 출력하기
            for (int rgb = 0; rgb < 3; rgb++)
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                        outImage[rgb, i, k] = (byte)normalHisto[inImage[rgb, i, k]];
            DisplayImage();
        }



        // 마우스 이벤트
        bool mouseYN = false;
        int sx, sy, ex, ey;
        // 화소점처리 변수
        const int EQUAL = 0, BRIGHT = 1, DARK = 2, MUL = 3, DIV = 4, REV = 5, BLACK = 6, GAMMA = 7;
        const int CAVEPARA = 8, VEXPARA = 9, RANGE = 10;
        // 화소영역처리 변수
        const int EMB = 11, BLURR = 12, SMOOTH = 13, SHARP = 14, SHARPH = 15, SHARPL = 16;
        // 기하학처리 변수
        const int UD = 17, LR = 18, MS = 19, ZO = 20, ZIB = 21, RB = 22, RC = 23;

        int selectMenu;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!mouseYN)
                return;
            sx = e.X; sy = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if (!mouseYN)
                return;
            ex = e.X; ey = e.Y;
            int tmp;
            if (sx > ex)
            {
                tmp = sx;
                sx = ex;
                ex = tmp;
            }
            if (sy > ey)
            {
                tmp = sy;
                sy = ey;
                ey = tmp;
            }
            switch (selectMenu)
            {
                case EQUAL: Equal(); break;
                case BRIGHT: Bright(); break;
                case DARK: Dark(); break;
                case MUL: Multiply(); break;
                case DIV: Division(); break;
                case REV: Reversal(); break;
                case BLACK: BlackWhite(); break;
                case GAMMA: GammaTransform(); break;
                case CAVEPARA: ConcaveParabolaTransform(); break;
                case VEXPARA: ConvexParabolaTransform(); break;
                case RANGE: RangeProcess(); break;
                case EMB: Embossing(); break;
                case BLURR: Blurr(); break;
                case SMOOTH: Smoothing(); break;
                case SHARP: Sharpening(); break;
                case SHARPH: Sharpening_Hpf(); break;
                case SHARPL: Sharpening_Lpf(); break;
                case UD: UpDownSymmetry(); break;
                case LR: LeftRightSymmetry(); break;
                case MS: Move_Screen(); break;
                case ZO: Zoom_Out(); break;
                case ZIB: Zoom_In_Back(); break;
                case RB: Rotate_Basic(); break;
                case RC: Rotate_Center(); break;
            }
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        private void 동일이미지ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = EQUAL;
            mouseYN = true;
        }

        private void 밝게하기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = BRIGHT;
            mouseYN = true;
        }

        private void 어둡게하기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = DARK;
            mouseYN = true;
        }

        private void 곱하기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = MUL;
            mouseYN = true;
        }

        private void 나누기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = DIV;
            mouseYN = true;
        }

        private void 반전ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = REV;
            mouseYN = true;
        }

        private void 흑백변환ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = BLACK;
            mouseYN = true;
        }

        private void 감마변환ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = GAMMA;
            mouseYN = true;
        }

        private void 오목파라볼라변환ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = CAVEPARA;
            mouseYN = true;
        }

        private void 볼록파라볼라변환ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = VEXPARA;
            mouseYN = true;
        }

        private void 범위처리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = RANGE;
            mouseYN = true;
        }




        private void 엠보싱ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = EMB;
            mouseYN = true;
        }

        private void 블러링ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = BLURR;
            mouseYN = true;
        }

        private void 스무딩ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = SMOOTH;
            mouseYN = true;
        }

        private void 샤프닝ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = SHARP;
            mouseYN = true;
        }

        private void 샤프닝HPFToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = SHARPH;
            mouseYN = true;
        }

        private void 샤프닝LPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectMenu = SHARPL;
            mouseYN = true;
        }




        private void 상하대칭ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = LR;
            mouseYN = true;
        }

        private void 좌우대칭ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = UD;
            mouseYN = true;
        }

        private void 화면이동ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = MS;
            mouseYN = true;
        }

        private void 화면확대ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectMenu = ZIB;
            mouseYN = true;
        }




        ////////////////////////////////////////////
        /// *** OpenCV용 컴퓨터 비전 코드 모음 *** ///
        ////////////////////////////////////////////
        Mat inCvImage, outCvImage;
        private void Cv2ToOutImage()
        {
            // Cv2 출력 --> 내 코드로 출력
            outH = outCvImage.Height;
            outW = outCvImage.Width;
            outImage = new byte[3, outH, outW];
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    var c = outCvImage.At<Vec3b>(i, k);
                    outImage[0, i, k] = c.Item2;
                    outImage[1, i, k] = c.Item1;
                    outImage[2, i, k] = c.Item0;
                }
            DisplayImage();
        }

        private void 열기OpenCVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "";
            ofd.Filter = "Color FIle(*.png;*.jpg;*.bmp;*.tif) | *.png;*.jpg;*.bmp;*.tif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                // 파일 --> OpenCV Matrix
                inCvImage = Cv2.ImRead(filename);
                // OpenCV Matrix 좌우 정렬
                Cv2.Transpose(inCvImage, inCvImage);    
                //** 중요 ** --> 영상크기  및 메모리 할당
                inH = inCvImage.Height;
                inW = inCvImage.Width;
                inImage = new byte[3, inH, inW];
                // OpenCV Matrix --> 배열로 값을 로딩하기
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        var c = inCvImage.At<Vec3b>(i,k);
                        inImage[0, i, k] = c.Item2;
                        inImage[1, i, k] = c.Item1;
                        inImage[2, i, k] = c.Item0;
                    }
                Equal();
            }
        }

        private void 흑백변환ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // 알고리즘에 의해서 outCvImage의 크기를 결정
            int oH, oW;
            oH = inCvImage.Height;
            oW = inCvImage.Width;
            outCvImage = new Mat();

            ////// OpenCV용 알고리즘 활용 //////
            Cv2.CvtColor(inCvImage, outCvImage, ColorConversionCodes.BGR2GRAY);
            ///////////////////////////////////

            Cv2ToOutImage();
        }

        private void 이진화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cv2.CvtColor(inCvImage, outCvImage, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(outCvImage, outCvImage, 127, 255, ThresholdTypes.Otsu);

            Cv2ToOutImage();
        }

        private void 적응형이진화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cv2.CvtColor(inCvImage, outCvImage, ColorConversionCodes.BGR2GRAY);
            Cv2.AdaptiveThreshold(outCvImage, outCvImage, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 25, 5);

            Cv2ToOutImage();
        }

        private void 확대ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cv2.PyrUp(inCvImage, outCvImage, new OpenCvSharp.Size(inCvImage.Width * 2, inCvImage.Height * 2));

            Cv2ToOutImage();
        }

        private void 회전ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Mat matrix = Cv2.GetRotationMatrix2D(new Point2f(inCvImage.Width / 2, inCvImage.Height / 2), 45.0, 1.0);
            Cv2.WarpAffine(inCvImage, outCvImage, matrix, new OpenCvSharp.Size(inCvImage.Width, inCvImage.Height));

            Cv2ToOutImage();
        }

        private void 블러링ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Cv2.Blur(inCvImage, outCvImage, new OpenCvSharp.Size(15, 15));

            Cv2ToOutImage();
        }
        
        private void 모폴로지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 알고리즘에 의해서 outCvImage의 크기를 결정
            int oH, oW;
            oH = inCvImage.Height;
            oW = inCvImage.Width;
            outCvImage = new Mat();

            ////// OpenCV용 알고리즘 활용 //////
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Cross, new OpenCvSharp.Size(3, 3)); // 크기에 따른 효과
            Cv2.Dilate(inCvImage, outCvImage, kernel, new OpenCvSharp.Point(-1, -1), 3, BorderTypes.Reflect101, new Scalar(0));
            ///////////////////////////////////

            Cv2ToOutImage();
        }

        private void 색상추출ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 알고리즘에 의해서 outCvImage의 크기를 결정
            int oH, oW;
            oH = inCvImage.Height;
            oW = inCvImage.Width;
            outCvImage = new Mat();

            ////// OpenCV용 알고리즘 활용 //////
            ////// 주황색 추출하기 ----> HSV에서 H가 8 ~ 20(주황색)
            Mat hsv = new Mat(new OpenCvSharp.Size(oW, oH), MatType.CV_8UC3);
            Cv2.CvtColor(inCvImage, hsv, ColorConversionCodes.BGR2HSV);
            Mat[] hsv_array = Cv2.Split(hsv);
            Mat H = new Mat(inCvImage.Size(), MatType.CV_8UC1);
            Cv2.InRange(hsv_array[0], new Scalar(8), new Scalar(20), H);
            Cv2.BitwiseAnd(hsv, hsv, outCvImage, H);
            Cv2.CvtColor(outCvImage, outCvImage, ColorConversionCodes.HSV2BGR);
            ///////////////////////////////////

            Cv2ToOutImage();
        }
    }
}
