using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 컴퓨터_비전_권순석__Ver_0._1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        byte[,] inImage, outImage;
        int inW, inH, outW, outH;
        string filename = "";
        Bitmap paper;
        int returnValue;

        ///////////////////////
        /// *** 공통함수 *** ///
        ///////////////////////

        /// <summary>
        /// Open Image함수
        /// </summary>
        private void OpenImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();          // Dialog를 연다
            ofd.DefaultExt = "raw";                             // 기본 확장명은 raw파일
            ofd.Filter = "RAW FIle(*.raw) | *.raw";             // raw파일을 확인함

            // Dialog에서 이미지를 선택한 경우
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                // 파일 --> 메모리
                long fSize = new FileInfo(filename).Length;
                //** 중요 ** --> 영상크기  및 메모리 할당
                inH = inW = (int)Math.Sqrt(fSize);
                inImage = new byte[inH, inW];
                outImage = new byte[inH, inW];
                // 파일 --> 배열로 값을 로딩하기
                BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open));
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        inImage[i, k] = br.ReadByte();
                        outImage[i, k] = inImage[i, k];
                    }

                br.Close();

                paper = new Bitmap(inH, inW);
                Color c;
                int r, g, b;
                for (int i = 0; i < inH; i++)
                    for (int k = 0; k < inW; k++)
                    {
                        r = g = b = inImage[i, k];
                        c = Color.FromArgb(r, g, b);
                        paper.SetPixel(k, i, c);
                    }
                pictureBox1.Image = paper;
                pictureBox2.Image = paper;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        /// <summary>
        /// Save Image 함수
        /// </summary>
        private void SaveImage()
        {
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.DefaultExt = "raw";
            sdf.Filter = "RAW file(*.raw) | *.raw";
            // Dialog에서 확인 버튼을 누르면,
            if (sdf.ShowDialog() == DialogResult.OK)
            {
                // 사용자가 정한 파일명으로 이미지를 저장
                string saveFname = sdf.FileName;
                BinaryWriter bw = new BinaryWriter(File.Open(saveFname, FileMode.CreateNew));
                for (int i = 0; i < outH; i++)
                    for (int k = 0; k < outW; k++)
                        bw.Write(outImage[i, k]);
                bw.Close();
                MessageBox.Show(saveFname + " 저장됨");
            }
        }

        /// <summary>
        /// DisplayImage 함수
        /// </summary>
        private void DisplayImage()
        {
            paper = new Bitmap(outH, outW);

            // 출력될 이미지의 각각의 픽셀값 저장
            Color c;
            int r, g, b;
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    r = g = b = outImage[i, k];
                    c = Color.FromArgb(r, g, b);
                    paper.SetPixel(k, i, c);
                }
            pictureBox2.Image = paper;
            // 상태바 출력
            statusStrip1.Text = "영상크기 : " + outH + " x " + outW;
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

        private int GetBrightnessValue()
        {
            int retValue = 0;
            Brightness dlg = new Brightness();
            if (dlg.ShowDialog(this) == DialogResult.OK)    // this : 메인폼의 서브폼으로 인식하게 하기 위해
                                                            // Sub_Input1 form의 DialogResult가 OK이면 구문 수행
            {
                retValue = dlg.trackBar_Brightness.Value;
            }
            return retValue;
        }

        private int GetMulDivValue()
        {
            int retValue = 0;
            MulDiv dlg = new MulDiv();
            if (dlg.ShowDialog(this) == DialogResult.OK) // this : 메인폼의 서브폼으로 인식하게 하기 위해
                                                         // Sub_Input1 form의 DialogResult가 OK이면 구문 수행
            {
                retValue = dlg.trackBar_MulDiv.Value;
            }
            return retValue;
        }

        private int GetGammaValue()
        {
            int retValue = 0;
            Gamma dlg = new Gamma();
            if (dlg.ShowDialog(this) == DialogResult.OK) // this : 메인폼의 서브폼으로 인식하게 하기 위해
                                                         // Sub_Input1 form의 DialogResult가 OK이면 구문 수행
            {
                retValue = dlg.trackBar_Gamma.Value;
            }
            return retValue;
        }

        private double[] GetRangeProgressValue()
        {
            double[] retValue = new double[2];
            RangeProgress dlg = new RangeProgress();
            if (dlg.ShowDialog(this) == DialogResult.OK) // this : 메인폼의 서브폼으로 인식하게 하기 위해
                                                         // Sub_Input1 form의 DialogResult가 OK이면 구문 수행
            {
                retValue[0] = (double)dlg.numeric_First.Value;
                retValue[1] = (double)dlg.numeric_Second.Value;
            }
            return retValue;
        }

        private int[] GetMoveScreenValue()
        {
            int[] retValue = new int[2];
            MoveScreen dlg = new MoveScreen();
            if (dlg.ShowDialog(this) == DialogResult.OK) // this : 메인폼의 서브폼으로 인식하게 하기 위해
                                                         // Sub_Input1 form의 DialogResult가 OK이면 구문 수행
            {
                retValue[0] = (int)dlg.numeric_Xindex.Value;
                retValue[1] = (int)dlg.numeric_Yindex.Value;
            }
            return retValue;
        }

        private int GetZoomValue()
        {
            int retValue = 0;
            Zoom dlg = new Zoom();
            if (dlg.ShowDialog(this) == DialogResult.OK) // this : 메인폼의 서브폼으로 인식하게 하기 위해
                                                         // Sub_Input1 form의 DialogResult가 OK이면 구문 수행
            {
                retValue = dlg.trackBar_Scale.Value;
            }
            return retValue;
        }

        private int GetRotateValue()
        {
            int retValue = 0;
            Rotate dlg = new Rotate();
            if (dlg.ShowDialog(this) == DialogResult.OK) // this : 메인폼의 서브폼으로 인식하게 하기 위해
                                                         // Sub_Input1 form의 DialogResult가 OK이면 구문 수행
            {
                retValue = dlg.trackBar_Degree.Value;
            }
            return retValue;
        }



        ///////////////////////////////////////////////
        /// *** 메뉴 선택시 실행되는 이벤트 함수들 *** ///
        ///////////////////////////////////////////////

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void originalImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Equal();
        }

        private void brightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bright();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bright();
        }

        private void multiplyDivisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MulDiv();
        }
        private void trackBar_MulDiv_Scroll(object sender, EventArgs e)
        {
            if (GetMulDivValue() != 0)
                MulDiv();
            else
                Equal();
        }
        
        private void reversalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reversal();
        }

        private void blackWhiteTransformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlackWhite();
        }

        private void blackandWhiteConversionAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlackWhiteAvg();
        }

        private void blackandWhiteConversionMedianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlackWhiteMedian();
        }
        
        private void gammaConversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GammaTransform();
        }

        private void concaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConcaveParabolaTransform();
        }

        private void convexParabolaConversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvexParabolaTransform();
        }
        
        private void rangeProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RangeProcess();
        }



        
        private void upDownSymmetryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpDownSymmetry();
        }

        private void leftandRightSymmetryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeftRightSymmetry();
        }

        private void moveScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move_Screen();
        }

        private void scaleDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom_Out();
        }

        private void scaleDownAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom_Out_Avg();
        }

        private void scaleDownMedianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom_Out_Median();
        }

        private void scaleUpBasicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom_In();
        }

        private void scaleUpBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom_In_Back();
        }

        private void scaleUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rotationBasicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotate_Basic();
        }

        private void rotationCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotate_Center();
        }

        private void rotationClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turn90DegreeClock();
        }

        private void rotationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Turn90Degree();
        }




        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embossing();
        }

        private void blurringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blurr();
        }

        private void smoothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Smoothing();
        }

        private void sharpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sharpening();
        }

        private void sharpeningHPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sharpening_Hpf();
        }

        private void sharpeningLPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sharpening_Lpf();
        }




        /////////////////////////////////////
        /// *** 영상처리 알고리즘 함수 *** ///
        ////////////////////////////////////

        /// <summary>
        /// 화소점 동일이미지 알고리즘
        /// </summary>
        private void Equal()
        {
            if (!CheckOpen())
                return;
            // ** 중요 ** 출력 영상의 크기를 결정 --> 알고리즘에 따라 다름
            outH = inH; outW = inW;
            // *** 진짜 영상처리 알고리즘 *** Output = Input
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    outImage[i, k] = inImage[i, k];
            DisplayImage();
        }

        /// <summary>
        /// 화소점 덧셈/뺄셈 알고리즘 (밝기조절)
        /// </summary>
        private void Bright()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            int value = GetBrightnessValue();
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (inImage[i, k] + value < 0)
                        outImage[i, k] = 0;
                    else if (inImage[i, k] + value > 255)
                        outImage[i, k] = 255;
                    else
                        outImage[i, k] = (byte)(inImage[i, k] + value);
                }
            DisplayImage();
        }

        /// <summary>
        /// 화소점 곱셈/나눗셈 알고리즘 (뚜렷/희미하게하기)
        /// </summary>
        private void MulDiv()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            int value = GetMulDivValue();
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (value > 0)
                    {
                        if (inImage[i, k] * value > 255)
                            outImage[i, k] = 255;
                        else
                            outImage[i, k] = (byte)(inImage[i, k] * value);
                    }
                    else if (value < 0)
                        outImage[i, k] = (byte)(inImage[i, k] / ((-1) * value));
                }
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
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    outImage[i, k] = (byte)(255 - outImage[i, k]);
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
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (outImage[i, k] >= 128)
                        outImage[i, k] = 255;
                    else
                        outImage[i, k] = 0;
                }
            DisplayImage();
        }

        /// <summary>
        /// 화소점 흑백변환(평균값) 알고리즘
        /// </summary>
        private void BlackWhiteAvg()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            int hap = 0;
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    hap += outImage[i, k];
            int avg = hap / (inH * inW);
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (outImage[i, k] >= avg)
                        outImage[i, k] = 255;
                    else
                        outImage[i, k] = 0;
                }
            DisplayImage();
        }

        /// <summary>
        /// 화소점 흑백변환(중위수) 알고리즘
        /// </summary>
        private void BlackWhiteMedian()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;

            /*// 직접 만든 QuickSort()함수를 사용하여 구현할 때
            int[] arr = { };

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    Array.Resize(ref arr, arr.GetLength(0) + 1);
                    arr[arr.GetLength(0) - 1] = outImage[i, k];
                }

            QuickSort(arr, 0, arr.GetLength(0) - 1);

            double median = (arr[(inH * inW / 2) - 1] + arr[inH * inW / 2]) / 2;

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (outImage[i, k] > median)
                        outImage[i, k] = 255;
                    else
                        outImage[i, k] = 0;
                }
            */

            // C#내부에 있는 함수 Array.Sort()함수를 이용하여 구현할 때
            byte[] ary1 = new byte[inH * inW];      // 2차원 배열 -> 1차원 배열
            int index = 0;
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    ary1[index++] = inImage[i, k];
            Array.Sort(ary1);                       // 1차원 배열 정렬 (오름차순)
            // Array.Reverse(ary1);                    // 1차원 배열 정렬 (내림차순)

            int midValue = ary1[ary1.Length / 2];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (inImage[i, k] > midValue)
                        outImage[i, k] = 255;
                    else
                        outImage[i, k] = 0;
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
            double gamma = GetGammaValue() / 10;
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImage[i, k] = (byte)(255.0 * Math.Pow(outImage[i, k] / 255.0, 1.0 / gamma));
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
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    outImage[i, k] = (byte)(255.0 * (outImage[i, k] / 128.0 - 1) * (outImage[i, k] / 128.0 - 1));
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
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    outImage[i, k] = (byte)(255.0 - 255.0 * (outImage[i, k] / 128.0 - 1) * (outImage[i, k] / 128.0 - 1));
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
            double[] arr = GetRangeProgressValue();
            int first = (int)arr[0];
            int second = (int)arr[1];
            if (first > second)
            {
                int temp = first;
                first = second;
                second = temp;
            }
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (outImage[i, k] < second && outImage[i, k] > first)
                    {
                        outImage[i, k] = 0;
                    }
                    else
                        outImage[i, k] = outImage[i, k];
                }
            DisplayImage();
        }
        



        /// <summary>
        /// 기하학 상하대칭 변환 알고리즘
        /// </summary>
        private void UpDownSymmetry()
        {
            if (!CheckOpen())
                return;
            outH = inH; outW = inW;
            for (int i = 0; i < inW; i++)
                for (int k = 0; k < inH / 2; k++)
                {
                    byte temp = outImage[k, i];
                    outImage[k, i] = outImage[inH - k - 1, i];
                    outImage[inH - k - 1, i] = temp;
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
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW / 2; k++)
                {
                    byte temp = outImage[i, k];
                    outImage[i, k] = outImage[i, inW - k - 1];
                    outImage[i, inW - k - 1] = temp;
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
            outImage = new byte[outH, outW];

            int[] xVal = GetMoveScreenValue();
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if ((0 <= i - xVal[0] && i - xVal[0] < inW) && (0 <= k - xVal[1] && k - xVal[1] < inH))
                        outImage[i - xVal[0], k - xVal[1]] = inImage[i, k];
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
            int scale = GetZoomValue();
            outH = inH / scale; outW = inW / scale;
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if ((0 <= i / scale && i / scale < outW) && (0 <= k / scale && k / scale < outH))
                        outImage[i / scale, k / scale] = inImage[i, k];
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
            int scale = GetZoomValue();
            outH = inH / scale; outW = inW / scale;
            double S = 0;
            for (int i = 0; i < inH - 2; i += scale)
                for (int k = 0; k < inW - 2; k += scale)
                {
                    for (int m = 0; m < scale; m++)
                        for (int n = 0; n < scale; n++)
                        {
                            S += inImage[i + m, k + n];
                        }
                    outImage[i / scale, k / scale] = (byte)(S / (scale * scale));
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
            int scale = GetZoomValue();
            outH = inH / scale; outW = inW / scale;
            int index = 0;
            int[] arr = { };
            Array.Resize(ref arr, arr.Length + scale * scale);
            for (int i = 0; i < inH - 2; i += scale)
                for (int k = 0; k < inW - 2; k += scale)
                {
                    for (int m = 0; m < scale; m++)
                        for (int n = 0; n < scale; n++)
                        {
                            arr[index++] = inImage[i + m, k + n];
                        }
                    Array.Sort(arr);
                    outImage[i / scale, k / scale] = (byte)arr[(scale * scale) / 2];
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
            int scale = GetZoomValue();
            outH = inH * scale; outW = inW * scale;
            outImage = new byte[outH, outW];
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if ((0 <= i * scale && i * scale < outW) && (0 <= k * scale && k * scale < outH))
                        outImage[i * scale, k * scale] = inImage[i, k];
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
            int scale = GetZoomValue();
            outH = inH * scale; outW = inW * scale;
            outImage = new byte[outH, outW];
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    if ((0 <= i / scale && i / scale < inW) && (0 <= k / scale && k / scale < inH))
                        outImage[i, k] = inImage[i / scale, k / scale];
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
            outImage = new byte[outH, outW];
            int angle = GetRotateValue();
            double r = angle * Math.PI / 180.0;    // 입력받은 각도를 Degree -> Radian으로 변환
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int newI = (int)(Math.Cos(r) * i + Math.Sin(r) * k);
                    int newK = (int)(-Math.Sin(r) * i + Math.Cos(r) * k);

                    if ((0 <= newI && newI < outW) && (0 <= newK && newK < outH))
                        outImage[newI, newK] = inImage[i, k];
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
            outImage = new byte[outH, outW];
            int angle = GetRotateValue();
            double r = angle * Math.PI / 180.0;    // 입력받은 각도를 Degree -> Radian으로 변환
            int cx = inH / 2;
            int cy = inW / 2;
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    int oldI = (int)(Math.Cos(r) * (i - cx) + Math.Sin(r) * (k - cy)) + cx;
                    int oldK = (int)(-Math.Sin(r) * (i - cx) + Math.Cos(r) * (k - cy)) + cy;

                    if ((0 <= oldI && oldI < outW) && (0 <= oldK && oldK < outH))
                        outImage[i, k] = inImage[oldI, oldK];
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
            byte[,] temp = new byte[outH, outW];                // 치환을 위한 temp 배열 선언
            for (int i = 0; i < inH; i++)                       // temp 2차배열에 이미지 저장
                for (int k = 0; k < inW; k++)
                    temp[i, k] = outImage[i, k];
            for (int i = 0; i < inH; i++)                       // 이미지의 오른쪽 반을 먼저 반시계 방향으로 90도 회전 하여 outImage에 저장
                for (int k = 0; k < inW / 2; k++)
                    outImage[k, i] = outImage[i, inW - k - 1];
            for (int i = 0; i < inH; i++)                       // 이미지의 왼쪽 반을 반시계 방향으로 90도 회전 하여 outImage에 저장
                for (int k = inW / 2; k < inW; k++)
                    outImage[k, i] = temp[i, inW - k - 1];
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
            for (int i = 0; i < inH; i++)                       // temp 2차배열에 이미지 저장
                for (int k = 0; k < inW; k++)
                    temp[i, k] = outImage[i, k];
            for (int i = 0; i < inH; i++)                       // 이미지의 오른쪽 반을 먼저 시계 방향으로 90도 회전 하여 outImage에 저장
                for (int k = 0; k < inW / 2; k++)
                    outImage[i, k] = outImage[inH - k - 1, i];
            for (int i = 0; i < inH; i++)                       // 이미지의 왼쪽 반을 시계 방향으로 90도 회전 하여 outImage에 저장
                for (int k = inW / 2; k < inW; k++)
                    outImage[i, k] = temp[inH - k - 1, i];
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
            double[,] tmpInImage = new double[inH + 2, inW + 2];
            double[,] tmpOutImage = new double[outH, outW];

            // 임시 입력을 127로 초기화
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInImage[i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInImage[i + 1, k + 1] = inImage[i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    // 한 점에 대해서 마스크와 연산
                    for (int m = 0; m < mSize; m++)
                        for (int n = 0; n < mSize; n++)
                            S += mask[m, n] * tmpInImage[i + m, k + n];
                    tmpOutImage[i, k] = S;
                    S = 0.0;
                }
            // 마스크의 합계가 0이면 전체에 128을 더한다.
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    tmpOutImage[i, k] += 128;
            // 임시출력 -> 출력
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutImage[i, k] > 255)
                        outImage[i, k] = 255;
                    else if (tmpOutImage[i, k] < 0)
                        outImage[i, k] = 0;
                    else
                        outImage[i, k] = (byte)tmpOutImage[i, k];
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
            double[,] tmpInImage = new double[inH + 2, inW + 2];
            double[,] tmpOutImage = new double[outH, outW];

            // 임시 입력을 127로 초기화
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInImage[i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInImage[i + 1, k + 1] = inImage[i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    // 한 점에 대해서 마스크와 연산
                    for (int m = 0; m < mSize; m++)
                        for (int n = 0; n < mSize; n++)
                            S += mask[m, n] * tmpInImage[i + m, k + n];
                    tmpOutImage[i, k] = S;
                    S = 0.0;
                }
            // 임시출력 -> 출력
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutImage[i, k] > 255)
                        outImage[i, k] = 255;
                    else if (tmpOutImage[i, k] < 0)
                        outImage[i, k] = 0;
                    else
                        outImage[i, k] = (byte)tmpOutImage[i, k];
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
            double[,] tmpInImage = new double[inH + 2, inW + 2];
            double[,] tmpOutImage = new double[outH, outW];

            // 임시 입력을 127로 초기화
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInImage[i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInImage[i + 1, k + 1] = inImage[i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    // 한 점에 대해서 마스크와 연산
                    for (int m = 0; m < mSize; m++)
                        for (int n = 0; n < mSize; n++)
                            S += mask[m, n] * tmpInImage[i + m, k + n];
                    tmpOutImage[i, k] = S;
                    S = 0.0;
                }
            // 임시출력 -> 출력
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutImage[i, k] > 255)
                        outImage[i, k] = 255;
                    else if (tmpOutImage[i, k] < 0)
                        outImage[i, k] = 0;
                    else
                        outImage[i, k] = (byte)tmpOutImage[i, k];
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
            double[,] tmpInImage = new double[inH + 2, inW + 2];
            double[,] tmpOutImage = new double[outH, outW];

            // 임시 입력을 127로 초기화
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInImage[i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInImage[i + 1, k + 1] = inImage[i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    // 한 점에 대해서 마스크와 연산
                    for (int m = 0; m < mSize; m++)
                        for (int n = 0; n < mSize; n++)
                            S += mask[m, n] * tmpInImage[i + m, k + n];
                    tmpOutImage[i, k] = S;
                    S = 0.0;
                }
            // 임시출력 -> 출력
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutImage[i, k] > 255)
                        outImage[i, k] = 255;
                    else if (tmpOutImage[i, k] < 0)
                        outImage[i, k] = 0;
                    else
                        outImage[i, k] = (byte)tmpOutImage[i, k];
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
            double[,] tmpInImage = new double[inH + 2, inW + 2];
            double[,] tmpOutImage = new double[outH, outW];

            // 임시 입력을 127로 초기화
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInImage[i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInImage[i + 1, k + 1] = inImage[i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    // 한 점에 대해서 마스크와 연산
                    for (int m = 0; m < mSize; m++)
                        for (int n = 0; n < mSize; n++)
                            S += mask[m, n] * tmpInImage[i + m, k + n];
                    tmpOutImage[i, k] = S;
                    S = 0.0;
                }
            // 마스크의 합계가 0이면 전체에 128을 더한다.
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    tmpOutImage[i, k] += 128;
            // 임시출력 -> 출력
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutImage[i, k] > 255)
                        outImage[i, k] = 255;
                    else if (tmpOutImage[i, k] < 0)
                        outImage[i, k] = 0;
                    else
                        outImage[i, k] = (byte)tmpOutImage[i, k];
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
            double[,] tmpInImage = new double[inH + 2, inW + 2];
            double[,] tmpOutImage = new double[outH, outW];

            // 임시 입력을 127로 초기화
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInImage[i, k] = 127.0;

            // 입력 --> 임시 입력
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInImage[i + 1, k + 1] = inImage[i, k];

            // 회선연산 처리
            double S = 0.0;     // 마스크와 곱해서 더한 값
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    // 한 점에 대해서 마스크와 연산
                    for (int m = 0; m < mSize; m++)
                        for (int n = 0; n < mSize; n++)
                            S += mask[m, n] * tmpInImage[i + m, k + n];
                    tmpOutImage[i, k] = S;
                    S = 0.0;
                }
            // 임시출력 -> 출력
            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutImage[i, k] > 255)
                        outImage[i, k] = 255;
                    else if (tmpOutImage[i, k] < 0)
                        outImage[i, k] = 0;
                    else
                        outImage[i, k] = (byte)tmpOutImage[i, k];
                }
            DisplayImage();
        }
    }
}
