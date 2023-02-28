using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinokio.MPV
{
    public partial class MainForm : Form
    {
        private List<TimeChart> _charts = new List<TimeChart>();
        private Graphics _nowGraphics;
        public MainForm()
        {
            InitializeComponent();
        }
        public void InsertTimeCharts(List<TimeChart> timeCharts)
        {
            _charts = timeCharts;
            // 여기서 버튼들과 스크롤을 생성해야함
        }

        // 아래 다 쓸모없음 변경해야함 *****
        public void UpdateGraphics(Graphics g)
        {
            Graphics graphics = pbPreView.CreateGraphics();
            graphics = g;
            graphics.Dispose();
        }
        public PictureBox GetPictureBox()
        {
            return pbPreView;
        }
    }
}
