namespace 컴퓨터_비전_권순석__Ver_0._1
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originalImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiplyDivisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reversalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackWhiteTransformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackandWhiteConversionAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackandWhiteConversionMedianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaConversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.concaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convexParabolaConversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rangeProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geometryProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.symmetricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upDownSymmetryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftandRightSymmetryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reduceScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleDownAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleDownMedianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleUpBasicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleUpBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationBasicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpeningHPFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpeningLPFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rotationClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pixelProcessingToolStripMenuItem,
            this.geometryProcessingToolStripMenuItem,
            this.areaProcessingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pixelProcessingToolStripMenuItem
            // 
            this.pixelProcessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.originalImageToolStripMenuItem,
            this.brightToolStripMenuItem,
            this.multiplyDivisionToolStripMenuItem,
            this.reversalToolStripMenuItem,
            this.blackWhiteTransformToolStripMenuItem,
            this.blackandWhiteConversionAverageToolStripMenuItem,
            this.blackandWhiteConversionMedianToolStripMenuItem,
            this.gammaConversionToolStripMenuItem,
            this.concaveToolStripMenuItem,
            this.convexParabolaConversionToolStripMenuItem,
            this.rangeProcessingToolStripMenuItem});
            this.pixelProcessingToolStripMenuItem.Name = "pixelProcessingToolStripMenuItem";
            this.pixelProcessingToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.pixelProcessingToolStripMenuItem.Text = "Pixel Processing";
            // 
            // originalImageToolStripMenuItem
            // 
            this.originalImageToolStripMenuItem.Name = "originalImageToolStripMenuItem";
            this.originalImageToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.originalImageToolStripMenuItem.Text = "Original Image";
            this.originalImageToolStripMenuItem.Click += new System.EventHandler(this.originalImageToolStripMenuItem_Click);
            // 
            // brightToolStripMenuItem
            // 
            this.brightToolStripMenuItem.Name = "brightToolStripMenuItem";
            this.brightToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.brightToolStripMenuItem.Text = "Brightness";
            this.brightToolStripMenuItem.Click += new System.EventHandler(this.brightToolStripMenuItem_Click);
            // 
            // multiplyDivisionToolStripMenuItem
            // 
            this.multiplyDivisionToolStripMenuItem.Name = "multiplyDivisionToolStripMenuItem";
            this.multiplyDivisionToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.multiplyDivisionToolStripMenuItem.Text = "Multiply / Division";
            this.multiplyDivisionToolStripMenuItem.Click += new System.EventHandler(this.multiplyDivisionToolStripMenuItem_Click);
            // 
            // reversalToolStripMenuItem
            // 
            this.reversalToolStripMenuItem.Name = "reversalToolStripMenuItem";
            this.reversalToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.reversalToolStripMenuItem.Text = "Reversal";
            this.reversalToolStripMenuItem.Click += new System.EventHandler(this.reversalToolStripMenuItem_Click);
            // 
            // blackWhiteTransformToolStripMenuItem
            // 
            this.blackWhiteTransformToolStripMenuItem.Name = "blackWhiteTransformToolStripMenuItem";
            this.blackWhiteTransformToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.blackWhiteTransformToolStripMenuItem.Text = "Black-and-White Conversion";
            this.blackWhiteTransformToolStripMenuItem.Click += new System.EventHandler(this.blackWhiteTransformToolStripMenuItem_Click);
            // 
            // blackandWhiteConversionAverageToolStripMenuItem
            // 
            this.blackandWhiteConversionAverageToolStripMenuItem.Name = "blackandWhiteConversionAverageToolStripMenuItem";
            this.blackandWhiteConversionAverageToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.blackandWhiteConversionAverageToolStripMenuItem.Text = "Black-and-White Conversion(Average)";
            this.blackandWhiteConversionAverageToolStripMenuItem.Click += new System.EventHandler(this.blackandWhiteConversionAverageToolStripMenuItem_Click);
            // 
            // blackandWhiteConversionMedianToolStripMenuItem
            // 
            this.blackandWhiteConversionMedianToolStripMenuItem.Name = "blackandWhiteConversionMedianToolStripMenuItem";
            this.blackandWhiteConversionMedianToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.blackandWhiteConversionMedianToolStripMenuItem.Text = "Black-and-White Conversion(Median)";
            this.blackandWhiteConversionMedianToolStripMenuItem.Click += new System.EventHandler(this.blackandWhiteConversionMedianToolStripMenuItem_Click);
            // 
            // gammaConversionToolStripMenuItem
            // 
            this.gammaConversionToolStripMenuItem.Name = "gammaConversionToolStripMenuItem";
            this.gammaConversionToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.gammaConversionToolStripMenuItem.Text = "Gamma Conversion";
            this.gammaConversionToolStripMenuItem.Click += new System.EventHandler(this.gammaConversionToolStripMenuItem_Click);
            // 
            // concaveToolStripMenuItem
            // 
            this.concaveToolStripMenuItem.Name = "concaveToolStripMenuItem";
            this.concaveToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.concaveToolStripMenuItem.Text = "Concave Parabola Conversion";
            this.concaveToolStripMenuItem.Click += new System.EventHandler(this.concaveToolStripMenuItem_Click);
            // 
            // convexParabolaConversionToolStripMenuItem
            // 
            this.convexParabolaConversionToolStripMenuItem.Name = "convexParabolaConversionToolStripMenuItem";
            this.convexParabolaConversionToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.convexParabolaConversionToolStripMenuItem.Text = "Convex Parabola Conversion";
            this.convexParabolaConversionToolStripMenuItem.Click += new System.EventHandler(this.convexParabolaConversionToolStripMenuItem_Click);
            // 
            // rangeProcessingToolStripMenuItem
            // 
            this.rangeProcessingToolStripMenuItem.Name = "rangeProcessingToolStripMenuItem";
            this.rangeProcessingToolStripMenuItem.Size = new System.Drawing.Size(344, 26);
            this.rangeProcessingToolStripMenuItem.Text = "Range Processing";
            this.rangeProcessingToolStripMenuItem.Click += new System.EventHandler(this.rangeProcessingToolStripMenuItem_Click);
            // 
            // geometryProcessingToolStripMenuItem
            // 
            this.geometryProcessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.symmetricToolStripMenuItem,
            this.moveScreenToolStripMenuItem,
            this.reduceScreenToolStripMenuItem,
            this.expandScreenToolStripMenuItem,
            this.rotationToolStripMenuItem});
            this.geometryProcessingToolStripMenuItem.Name = "geometryProcessingToolStripMenuItem";
            this.geometryProcessingToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.geometryProcessingToolStripMenuItem.Text = "Geometry Processing";
            // 
            // symmetricToolStripMenuItem
            // 
            this.symmetricToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upDownSymmetryToolStripMenuItem,
            this.leftandRightSymmetryToolStripMenuItem});
            this.symmetricToolStripMenuItem.Name = "symmetricToolStripMenuItem";
            this.symmetricToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.symmetricToolStripMenuItem.Text = "Symmetry";
            // 
            // upDownSymmetryToolStripMenuItem
            // 
            this.upDownSymmetryToolStripMenuItem.Name = "upDownSymmetryToolStripMenuItem";
            this.upDownSymmetryToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.upDownSymmetryToolStripMenuItem.Text = "Up-and-Down Symmetry";
            this.upDownSymmetryToolStripMenuItem.Click += new System.EventHandler(this.upDownSymmetryToolStripMenuItem_Click);
            // 
            // leftandRightSymmetryToolStripMenuItem
            // 
            this.leftandRightSymmetryToolStripMenuItem.Name = "leftandRightSymmetryToolStripMenuItem";
            this.leftandRightSymmetryToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.leftandRightSymmetryToolStripMenuItem.Text = "Left-and-Right Symmetry";
            this.leftandRightSymmetryToolStripMenuItem.Click += new System.EventHandler(this.leftandRightSymmetryToolStripMenuItem_Click);
            // 
            // moveScreenToolStripMenuItem
            // 
            this.moveScreenToolStripMenuItem.Name = "moveScreenToolStripMenuItem";
            this.moveScreenToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.moveScreenToolStripMenuItem.Text = "Move Screen";
            this.moveScreenToolStripMenuItem.Click += new System.EventHandler(this.moveScreenToolStripMenuItem_Click);
            // 
            // reduceScreenToolStripMenuItem
            // 
            this.reduceScreenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleDownToolStripMenuItem,
            this.scaleDownAverageToolStripMenuItem,
            this.scaleDownMedianToolStripMenuItem});
            this.reduceScreenToolStripMenuItem.Name = "reduceScreenToolStripMenuItem";
            this.reduceScreenToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.reduceScreenToolStripMenuItem.Text = "Scale Down";
            // 
            // scaleDownToolStripMenuItem
            // 
            this.scaleDownToolStripMenuItem.Name = "scaleDownToolStripMenuItem";
            this.scaleDownToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.scaleDownToolStripMenuItem.Text = "Scale Down(Basic)";
            this.scaleDownToolStripMenuItem.Click += new System.EventHandler(this.scaleDownToolStripMenuItem_Click);
            // 
            // scaleDownAverageToolStripMenuItem
            // 
            this.scaleDownAverageToolStripMenuItem.Name = "scaleDownAverageToolStripMenuItem";
            this.scaleDownAverageToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.scaleDownAverageToolStripMenuItem.Text = "Scale Down(Average)";
            this.scaleDownAverageToolStripMenuItem.Click += new System.EventHandler(this.scaleDownAverageToolStripMenuItem_Click);
            // 
            // scaleDownMedianToolStripMenuItem
            // 
            this.scaleDownMedianToolStripMenuItem.Name = "scaleDownMedianToolStripMenuItem";
            this.scaleDownMedianToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.scaleDownMedianToolStripMenuItem.Text = "Scale Down(Median)";
            this.scaleDownMedianToolStripMenuItem.Click += new System.EventHandler(this.scaleDownMedianToolStripMenuItem_Click);
            // 
            // expandScreenToolStripMenuItem
            // 
            this.expandScreenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleUpBasicToolStripMenuItem,
            this.scaleUpBackToolStripMenuItem,
            this.scaleUpToolStripMenuItem});
            this.expandScreenToolStripMenuItem.Name = "expandScreenToolStripMenuItem";
            this.expandScreenToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.expandScreenToolStripMenuItem.Text = "Scale Up";
            // 
            // scaleUpBasicToolStripMenuItem
            // 
            this.scaleUpBasicToolStripMenuItem.Name = "scaleUpBasicToolStripMenuItem";
            this.scaleUpBasicToolStripMenuItem.Size = new System.Drawing.Size(298, 26);
            this.scaleUpBasicToolStripMenuItem.Text = "Scale Up(Basic)";
            this.scaleUpBasicToolStripMenuItem.Click += new System.EventHandler(this.scaleUpBasicToolStripMenuItem_Click);
            // 
            // scaleUpBackToolStripMenuItem
            // 
            this.scaleUpBackToolStripMenuItem.Name = "scaleUpBackToolStripMenuItem";
            this.scaleUpBackToolStripMenuItem.Size = new System.Drawing.Size(298, 26);
            this.scaleUpBackToolStripMenuItem.Text = "Scale Up(Backward)";
            this.scaleUpBackToolStripMenuItem.Click += new System.EventHandler(this.scaleUpBackToolStripMenuItem_Click);
            // 
            // scaleUpToolStripMenuItem
            // 
            this.scaleUpToolStripMenuItem.Name = "scaleUpToolStripMenuItem";
            this.scaleUpToolStripMenuItem.Size = new System.Drawing.Size(298, 26);
            this.scaleUpToolStripMenuItem.Text = "Scale Up(Bilinear Interpolation)";
            this.scaleUpToolStripMenuItem.Click += new System.EventHandler(this.scaleUpToolStripMenuItem_Click);
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotationBasicToolStripMenuItem,
            this.rotationCenterToolStripMenuItem,
            this.rotationClockwiseToolStripMenuItem,
            this.rotationToolStripMenuItem1});
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.rotationToolStripMenuItem.Text = "Rotation";
            // 
            // rotationBasicToolStripMenuItem
            // 
            this.rotationBasicToolStripMenuItem.Name = "rotationBasicToolStripMenuItem";
            this.rotationBasicToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.rotationBasicToolStripMenuItem.Text = "Rotation(Basic)";
            this.rotationBasicToolStripMenuItem.Click += new System.EventHandler(this.rotationBasicToolStripMenuItem_Click);
            // 
            // rotationCenterToolStripMenuItem
            // 
            this.rotationCenterToolStripMenuItem.Name = "rotationCenterToolStripMenuItem";
            this.rotationCenterToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.rotationCenterToolStripMenuItem.Text = "Rotation(Center)";
            this.rotationCenterToolStripMenuItem.Click += new System.EventHandler(this.rotationCenterToolStripMenuItem_Click);
            // 
            // areaProcessingToolStripMenuItem
            // 
            this.areaProcessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.embossingToolStripMenuItem,
            this.blurringToolStripMenuItem,
            this.smoothingToolStripMenuItem,
            this.sharpeningToolStripMenuItem,
            this.sharpeningHPFToolStripMenuItem,
            this.sharpeningLPFToolStripMenuItem});
            this.areaProcessingToolStripMenuItem.Name = "areaProcessingToolStripMenuItem";
            this.areaProcessingToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.areaProcessingToolStripMenuItem.Text = "Area Processing";
            // 
            // embossingToolStripMenuItem
            // 
            this.embossingToolStripMenuItem.Name = "embossingToolStripMenuItem";
            this.embossingToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.embossingToolStripMenuItem.Text = "Embossing";
            this.embossingToolStripMenuItem.Click += new System.EventHandler(this.embossingToolStripMenuItem_Click);
            // 
            // blurringToolStripMenuItem
            // 
            this.blurringToolStripMenuItem.Name = "blurringToolStripMenuItem";
            this.blurringToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.blurringToolStripMenuItem.Text = "Blurring";
            this.blurringToolStripMenuItem.Click += new System.EventHandler(this.blurringToolStripMenuItem_Click);
            // 
            // smoothingToolStripMenuItem
            // 
            this.smoothingToolStripMenuItem.Name = "smoothingToolStripMenuItem";
            this.smoothingToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.smoothingToolStripMenuItem.Text = "Smoothing";
            this.smoothingToolStripMenuItem.Click += new System.EventHandler(this.smoothingToolStripMenuItem_Click);
            // 
            // sharpeningToolStripMenuItem
            // 
            this.sharpeningToolStripMenuItem.Name = "sharpeningToolStripMenuItem";
            this.sharpeningToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.sharpeningToolStripMenuItem.Text = "Sharpening";
            this.sharpeningToolStripMenuItem.Click += new System.EventHandler(this.sharpeningToolStripMenuItem_Click);
            // 
            // sharpeningHPFToolStripMenuItem
            // 
            this.sharpeningHPFToolStripMenuItem.Name = "sharpeningHPFToolStripMenuItem";
            this.sharpeningHPFToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.sharpeningHPFToolStripMenuItem.Text = "Sharpening(HPF)";
            this.sharpeningHPFToolStripMenuItem.Click += new System.EventHandler(this.sharpeningHPFToolStripMenuItem_Click);
            // 
            // sharpeningLPFToolStripMenuItem
            // 
            this.sharpeningLPFToolStripMenuItem.Name = "sharpeningLPFToolStripMenuItem";
            this.sharpeningLPFToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.sharpeningLPFToolStripMenuItem.Text = "Sharpening(LPF)";
            this.sharpeningLPFToolStripMenuItem.Click += new System.EventHandler(this.sharpeningLPFToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 462);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(830, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(418, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(400, 400);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 13F);
            this.label1.Location = new System.Drawing.Point(143, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "원본 이미지";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 13F);
            this.label2.Location = new System.Drawing.Point(561, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "변환 이미지";
            // 
            // rotationClockwiseToolStripMenuItem
            // 
            this.rotationClockwiseToolStripMenuItem.Name = "rotationClockwiseToolStripMenuItem";
            this.rotationClockwiseToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.rotationClockwiseToolStripMenuItem.Text = "Rotation(Clockwise)";
            this.rotationClockwiseToolStripMenuItem.Click += new System.EventHandler(this.rotationClockwiseToolStripMenuItem_Click);
            // 
            // rotationToolStripMenuItem1
            // 
            this.rotationToolStripMenuItem1.Name = "rotationToolStripMenuItem1";
            this.rotationToolStripMenuItem1.Size = new System.Drawing.Size(247, 26);
            this.rotationToolStripMenuItem1.Text = "Rotation(AntiClockwise)";
            this.rotationToolStripMenuItem1.Click += new System.EventHandler(this.rotationToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 484);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem originalImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reversalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackWhiteTransformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackandWhiteConversionAverageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackandWhiteConversionMedianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gammaConversionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem concaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convexParabolaConversionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rangeProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geometryProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem symmetricToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upDownSymmetryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftandRightSymmetryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reduceScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleDownAverageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleDownMedianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleUpBasicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleUpBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationBasicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areaProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpeningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpeningHPFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpeningLPFToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem brightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiplyDivisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationClockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem1;
    }
}

