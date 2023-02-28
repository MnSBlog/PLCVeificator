using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeChartEditor;
using static Pinokio.MPV.TimeChart;
using Excel = Microsoft.Office.Interop.Excel;
using SandBox;
using System.Windows.Forms.VisualStyles;
using Font = System.Drawing.Font;
using Microsoft.Office.Core;

namespace Pinokio.MPV
{
    public partial class StartMenu : Form
    {
        private SandBox.Communication _communication = new SandBox.Communication();
        private MainForm _mainForm = new MainForm();
        private VerifierForm _verifierForm = new VerifierForm();
        private TimeChart _timeChart;
        public StartMenu()
        {
            InitializeComponent();
        }
        private void dataLoadBtn_Click(object sender, EventArgs e)
        {
            string targetPath = WinFormUtils.OpenFileFinder("Excel Finder", "xlsx 파일(*.xlsx) | *.xlsx; | 모든 파일 (*.*) | *.*");
            if (targetPath != null)
            {
                // 여기서 dll로 *****
                Excel.Application excelAPP = new Excel.Application();
                Workbook excelFile = excelAPP.Workbooks.Open(targetPath);
                var sheetCount = excelFile.Worksheets.Count;
                for (int i = 1; i <= sheetCount; ++i)
                {
                    var sheet = excelFile.Worksheets.get_Item(i) as Worksheet;
                    if (sheet.Name.ToLower().Contains("time"))
                    {
                        // 타임차트인 경우에는 객체들을 불러온다.
                        _timeChart = new TimeChart(sheet);
                        // 메인 차트에 그림그리기 ***** UI 영역
                    }
                }
                excelFile.Close();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            _communication.Login();
        }
        private void StartMenu_Load(object sender, EventArgs e)
        {
            _mainForm.TopLevel = _verifierForm.TopLevel = false;
            this.Controls.Add(_mainForm);
            this.Controls.Add(_verifierForm);
            _mainForm.Parent = this.centerPanel;
            _verifierForm.Parent = this.centerPanel;

        }
        private void mainBtn_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            _mainForm.UpdateGraphics(_timeChart.DrawPanel(_mainForm.GetPictureBox()));
            _verifierForm.Hide();
        }

        private void optionBtn_Click(object sender, EventArgs e)
        {

        }

        private void reportBtn_Click(object sender, EventArgs e)
        {

        }

        private void verifierBtn_Click(object sender, EventArgs e)
        {
            _mainForm.Hide();
            _verifierForm.Show();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

    }
}
