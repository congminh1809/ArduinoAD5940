using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Giao tiếp qua Serial
using System.IO;
using System.IO.Ports;
using System.Xml;

// Thêm ZedGraph
using ZedGraph;

namespace CsharpInterface
{
    public
    partial class Form1 : Form
    {
        string SDatas = String.Empty; // Khai báo chuỗi để lưu dữ liệu cảm biến gửi qua Serial
        string SRealTime = String.Empty; // Khai báo chuỗi để lưu thời gian gửi qua Serial
        int status = 0; // Khai báo biến để xử lý sự kiện vẽ đồ thị
        double realtime = 0; //Khai báo biến thời gian để vẽ đồ thị
        double datas = 0; //Khai báo biến dữ liệu cảm biến để vẽ đồ thị

        int repeatCount = 3;
        int numberSample = 1000;

        double[] bufferC = new double[16000];
        double[] bufferV = new double[16000];
        double[] tempC = new double[16000];
        string[] bufferCStr = new string[16000];
        string[] bufferVStr = new string[16000];
        int recieverCount = 0;


        public
            Form1()
        {
            InitializeComponent();
        }

        private
            void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = SerialPort.GetPortNames(); // Lấy nguồn cho comboBox là tên của cổng COM
            comboBox1.Text = Properties.Settings.Default.ComName; // Lấy ComName đã làm ở bước 5 cho comboBox

            // Khởi tạo ZedGraph
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Cyclic - Voltammetry Graph";
            myPane.XAxis.Title.Text = "Potential (mV)";
            myPane.YAxis.Title.Text = "Current (mA)";

            RollingPointPairList list = new RollingPointPairList(60000);
            LineItem curve = myPane.AddCurve("Dữ liệu", list, Color.Red, SymbolType.None);

            myPane.XAxis.Scale.Min = -10;
            myPane.XAxis.Scale.Max = 10;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            myPane.YAxis.Scale.Min = -20;
            myPane.YAxis.Scale.Max = 20;

            myPane.AxisChange();
        }

        // Hàm Tick này sẽ bắt sự kiện cổng Serial mở hay không
        private
            void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                progressBar1.Value = 0;
                //ClearZedGraph();
            }
            else if (serialPort1.IsOpen)
            {
                progressBar1.Value = 100;

                progressBarMeasure.Value = (recieverCount) / (numberSample / 99);

                if (progressBarMeasure.Value > 100)
                {
                    progressBarMeasure.Value = 100;
                }

                if (recieverCount == numberSample)
                {
                    //recieverCount = 0;
                    //progressBarMeasure.Value = 0;

                    serialPort1.Close();
                    Data_Listview();
                    SmoothingData(bufferC);
                    //Data_Listview();
                    ClearZedGraph();
                    Draw();


                }
                //Draw();
                //Data_Listview();
                status = 0;

            }
        }
        // Hàm này lưu lại cổng COM đã chọn cho lần kết nối
        private
        void SaveSetting()
        {
            Properties.Settings.Default.ComName = comboBox1.Text;
            Properties.Settings.Default.Save();
        }

        // Nhận và xử lý string gửi từ Serial
        private
            void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string[] arrList = serialPort1.ReadLine().Split('|'); // Đọc một dòng của Serial, cắt chuỗi khi gặp ký tự gạch đứng
                //SRealTime = arrList[0]; // Chuỗi đầu tiên lưu vào SRealTime
                //SDatas = arrList[1]; // Chuỗi thứ hai lưu vào SDatas

                //double.TryParse(SDatas, out datas); // Chuyển đổi sang kiểu double
                //double.TryParse(SRealTime, out realtime);

                bufferVStr[recieverCount] = arrList[0];
                bufferCStr[recieverCount] = arrList[1];
                recieverCount++;

                //progressBarMeasure.Value = (recieverCount + 1) / 10;

                //if (recieverCount == 999)
                //{
                //    //recieverCount = 0;
                //    Data_Listview();
                //}

                //realtime = realtime / 100; // Đối ms sang s
                //datas = datas ;
                status = 1; // Bắt sự kiện xử lý xong chuỗi, đổi starus về 1 để hiển thị dữ liệu trong ListView và vẽ đồ thị
            }
            catch
            {
                return;
            }
        }

        // Hiển thị dữ liệu trong ListView
        private
            void Data_Listview()
        {
            if (status == 0)
                return;
            else
            {
                for (int i = 0; i < recieverCount; i++)
                {
                    double.TryParse(bufferVStr[i], out bufferV[i]); // Chuyển đổi sang kiểu double
                    double.TryParse(bufferCStr[i], out bufferC[i]);
                    tempC[i] = bufferC[i];
                    //SmoothingData(bufferC);
                    //ListViewItem item = new ListViewItem(bufferV[i].ToString()); // Gán biến realtime vào cột đầu tiên của ListView
                    //item.SubItems.Add(bufferC[i].ToString());
                    ListViewItem item = new ListViewItem(bufferVStr[i].ToString()); // Gán biến realtime vào cột đầu tiên của ListView
                    item.SubItems.Add(bufferCStr[i].ToString());
                    listView1.Items.Add(item); // Gán biến datas vào cột tiếp theo của ListView
                                               // Không nên gán string SDatas vì khi xuất dữ liệu sang Excel sẽ là dạng string, không thực hiện các phép toán được

                    listView1.Items[listView1.Items.Count - 1].EnsureVisible(); // Hiện thị dòng được gán gần nhất ở ListView, tức là mình cuộn ListView
                }
                //SmoothingData(bufferC);
                //Draw();
            }
        }

        // Hàm làm mịn dữ liệu
        private
            void SmoothingData(double[] a)
        {

            int frame;
            //int num = 1;
            double sum = 0;
            //int countFrame = 1;
            frame = 35;
            //n = 802;
            //n = (Convert.ToInt32(txt_EVol) - Convert.ToInt32(txt_SVol)) / Convert.ToInt32(txt_Step) + 1;

            for (int i = 0; i < numberSample; i++)
            {
                //a[i]=(a[i-Buffer/2] + … + a[i] + … + a[i+Buffer/2]) / Buffer
                sum = 0;
                if (i < frame / 2)
                {
                    //sum = 0;
                    for (int j = 0; j <= i + frame/2; j++)
                    {
                        sum += tempC[j];
                    }
                    a[i] = sum / (i + frame/2 + 1);
                    //sum = 0;

                }

                if (i >= frame / 2 && i < numberSample - frame / 2)
                {
                    //sum = 0;
                    //for (int j = i - frame / 2; j <= i + frame / 2; j++)
                    for (int j = (i - (frame / 2)); j < (i - (frame / 2) + frame); j++)
                    {
                        sum += tempC[j];
                    }
                    a[i] = sum / frame;
                    //sum = 0;
                }

                if (i >= numberSample - (frame / 2))
                {
                    //sum = 0;
                    for (int j = i - frame / 2; j < numberSample; j++)
                    {
                        sum += tempC[j];
                    }
                    a[i] = sum / ((numberSample - 1 - i) + frame / 2 + 1);
                    //sum = 0;

                }

            }


        }


        // Vẽ đồ thị
        private
            void Draw()
        {

            if (zedGraphControl1.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curve = zedGraphControl1.GraphPane.CurveList[0] as LineItem;

            if (curve == null)
                return;

            IPointListEdit list = curve.Points as IPointListEdit;

            if (list == null)
                return;

            //list.Add(realtime, datas); // Thêm điểm trên đồ thị
            //for (int i = 0; i < numberSample; i++)
            int temp1 = (numberSample / repeatCount * (repeatCount - 2)) + (numberSample / (2 * repeatCount)) - 1;
            //int temp2 = (numberSample / repeatCount * (repeatCount - 1)) + (numberSample / (2 * repeatCount)) - 1;
            //int temp1 = (numberSample / repeatCount * (repeatCount - 2)) + (numberSample / 2);
            //for (int i = 0; i < numberSample; i++)
            for (int i = numberSample / repeatCount * (repeatCount - 2); i < numberSample / repeatCount * (repeatCount - 1); i++)
            {
                if (i <= temp1)
                {
                    bufferV[i] = bufferV[i] - (numberSample / repeatCount * (repeatCount - 2));
                    list.Add(bufferV[i], bufferC[i]);
                }
                if (i > temp1)
                {
                    bufferV[i] = (numberSample / repeatCount * (repeatCount - 1)) - bufferV[i];
                    list.Add(bufferV[i], bufferC[i]);
                }
                //double.TryParse(bufferVStr[i], out bufferV[i]); // Chuyển đổi sang kiểu double
                //double.TryParse(bufferCStr[i], out bufferC[i]);
                //list.Add(bufferV[i], bufferC[i]);
            }

            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            Scale yScale = zedGraphControl1.GraphPane.YAxis.Scale;

            // Tự động Scale theo trục x
            if (realtime > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = realtime + xScale.MajorStep;
                xScale.Min = xScale.Max - 30;
            }

            // Tự động Scale theo trục y
            if (datas > yScale.Max - yScale.MajorStep)
            {
                yScale.Max = datas + yScale.MajorStep;
            }
            else if (datas < yScale.Min + yScale.MajorStep)
            {
                yScale.Min = datas - yScale.MajorStep;
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();

            //ZedGraph.GraphPane myPane = zedGraphControl1.GraphPane;
            //myPane.XAxis.Scale.Min = 0.0;
            //zedGraphControl1.AxisChange();
            //zedGraphControl1.RestoreScale(myPane);
            //zedGraphControl1.ZoomOut(pane);
        }

        // Xóa đồ thị, với ZedGraph thì phải khai báo lại như ở hàm Form1_Load, nếu không sẽ không hiển thị
        private
            void ClearZedGraph()
        {
            zedGraphControl1.GraphPane.CurveList.Clear(); // Xóa đường
            zedGraphControl1.GraphPane.GraphObjList.Clear(); // Xóa đối tượng

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Current-Voltage chart for Biomedical Testing";
            myPane.XAxis.Title.Text = "Potential (mV)";
            myPane.YAxis.Title.Text = "Current (µA)";

            RollingPointPairList list = new RollingPointPairList(60000);
            LineItem curve = myPane.AddCurve("Data", list, Color.Red, SymbolType.None);

            myPane.XAxis.Scale.Min = -10;
            myPane.XAxis.Scale.Max = 550;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            myPane.YAxis.Scale.Min = -120;
            myPane.YAxis.Scale.Max = 120;

            //myPane.XAxis.Scale.Min = Convert.ToInt32(txt_SVol.Text) - 150;
            //myPane.XAxis.Scale.Max = Convert.ToInt32(txt_EVol.Text) + 150;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            //myPane.YAxis.Scale.Min = -20;
            //myPane.YAxis.Scale.Max = 50;
            //graphHeightMax = Convert.ToInt32(bufferC.Max());
            //graphHeightMin = Convert.ToInt32(bufferC.Min());
            myPane.XAxis.Scale.Min = 0 - 50;
            myPane.XAxis.Scale.Max = 500 + 50;
            myPane.YAxis.Scale.Min = Convert.ToInt32(bufferC.Min()) - 5;
            myPane.YAxis.Scale.Max = Convert.ToInt32(bufferC.Max()) + 5;

            zedGraphControl1.AxisChange();
        }

        // Hàm xóa dữ liệu
        private
            void ResetValue()
        {
            realtime = 0;
            datas = 0;
            SDatas = String.Empty;
            SRealTime = String.Empty;
            status = 0; // Chuyển status về 0
        }

        // Hàm lưu ListView sang Excel
        private
            void SaveToExcel()
        {
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;

            // Đặt tên cho hai ô A1. B1 lần lượt là "Thời gian (s)" và "Dữ liệu", sau đó tự động dãn độ rộng
            Microsoft.Office.Interop.Excel.Range rg = (Microsoft.Office.Interop.Excel.Range)ws.get_Range("A1", "B1");
            ws.Cells[1, 1] = "Potential";
            ws.Cells[1, 2] = "Current";
            ws.Cells[1, 3] = "Smooth";
            rg.Columns.AutoFit();

            // Lưu từ ô đầu tiên của dòng thứ 2, tức ô A2
            int i = 2;
            int j = 1;
            int smooth = 0;

            ////Làm mịn dữ liệu
            //SmoothingData(dataToSmooth);

            foreach (ListViewItem comp in listView1.Items)
            {
                //ws.Cells[i, j] = comp.Text.ToString();
                ws.Cells[i, j] = Convert.ToDouble(comp.Text);
                foreach (ListViewItem.ListViewSubItem drv in comp.SubItems)
                {
                    //ws.Cells[i, j] = drv.Text.ToString();
                    ws.Cells[i, j] = Convert.ToDouble(drv.Text);
                    j++;
                }
                j = 1;
                i++;

                ws.Cells[smooth + 2, 3] = Convert.ToDouble(bufferC[smooth]);
                smooth++;
                ws.Cells[1, 3] = "Smooth";
            }
        }

        // Sự kiện nhấn nút btConnect
        private
            void btConnect_Click(object sender, EventArgs e)
        {
            string str = txt_SVol.Text + '|' + txt_EVol.Text + '_' + txt_Step.Text;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write("2"); //Gửi ký tự "2" qua Serial, tương ứng với state = 2
                //serialPort1.WriteLine(str);
                serialPort1.WriteLine(str);
                serialPort1.Close();
                btConnect.Text = "Kết nối";
                btExit.Enabled = true;
                SaveSetting(); // Lưu cổng COM vào ComName
            }
            else
            {
                serialPort1.PortName = comboBox1.Text; // Lấy cổng COM
                serialPort1.BaudRate = 9600; // Baudrate là 9600, trùng với baudrate của Arduino
                repeatCount = Convert.ToInt32(txt_Repeat.Text);
                numberSample = (Convert.ToInt32(txt_EVol.Text) - Convert.ToInt32(txt_SVol.Text)) / Convert.ToInt32(txt_Step.Text) * repeatCount;
                //serialPort1.Write("2"); //Gửi ký tự "2" qua Serial, tương ứng với state = 2
                //serialPort1.Write("1"); //Gửi ký tự "2" qua Serial, tương ứng với state = 1
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine(str);
                    btConnect.Text = "Ngắt kết nối";
                    serialPort1.WriteLine(str);
                    progressBar1.Value = 100;
                    btExit.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Không thể mở cổng" + serialPort1.PortName, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện nhấn nút btExxit
        private
            void btExit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (traloi == DialogResult.OK)
            {
                Application.Exit(); // Đóng ứng dụng
            }
        }

        // Sự kiện nhấn nút btSave
        private
            void btSave_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn lưu số liệu?", "Lưu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (traloi == DialogResult.OK)
            {
                SaveToExcel(); // Thực thi hàm lưu ListView sang Excel
            }
        }

        // Sự kiện nhấn nút btCheck
        private
            void btCheck_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("1"); //Gửi ký tự "1" qua Serial, chạy hàm tạo Random ở Arduino
            }
            else
                MessageBox.Show("Bạn không thể chạy khi chưa kết nối với thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        // Sự kiện nhấn nút btPause
        private
            void btPause_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("0"); //Gửi ký tự "0" qua Serial, Dừng Arduino
            }
            else
                MessageBox.Show("Bạn không thể dừng khi chưa kết nối với thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Sự kiện nhấn nút Clear
        private
            void btClear_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa dữ liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (traloi == DialogResult.OK)
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write("2"); //Gửi ký tự "2" qua Serial
                        listView1.Items.Clear(); // Xóa listview

                        //Xóa đường trong đồ thị
                        ClearZedGraph();

                        //Xóa dữ liệu trong Form
                        ResetValue();
                    }
                    else
                        MessageBox.Show("Bạn không thể dừng khi chưa kết nối với thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không thể xóa khi chưa kết nối với thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Sự kiện nhấn nút Run
        private
            void btRun_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear(); // Xóa listview
            ClearZedGraph();
            //ResetValue();
            //Draw();
            //Draw();
            //Data_Listview();

        }

        private void txt_SVol_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_EVol_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Repeat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Step_TextChanged(object sender, EventArgs e)
        {

        }
    }
}