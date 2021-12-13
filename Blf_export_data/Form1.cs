using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSMaster;
using ClosedXML;
using ClosedXML.Excel;

namespace Blf_export_data
{
    class TreeViewEnhanced : TreeView
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203) { m.Result = IntPtr.Zero; }
            else base.WndProc(ref m);
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //DBC 名称集合
        List<string> MessagePath = new List<string>();
        //DBC名称
        string DBCname = "";
        //当前加载DBC计数
        int MessageList = 0;
        //加载报文AHeadle
        uint AId = 0;
        //判断是否加载blf—判断blf 加载格式是否正确
        public static bool Isloadblf = false;
        //查询blf参数
        public static int realIndex = 0;
        public static int AHeadleblf = 0;
        public static int AObjCount = 0;
        public static TSupportedObjType messageType = TSupportedObjType.sotUnknown;
        //获取信号值
        public static double CANAValue = 0;
        //信号值集合
        public static List<double> CANAValuelist = new List<double>();
        //导出不同Excel列计数集合
        List<int> SaveExcel_IndexList = new List<int>();
        //导出不同Excel文件名索引
        int DBC_Index;
        //报文名
        string MessageName = "";
        //信号名
        string SignalName = "";
        //can节点索引值
        int CAN_Node_Index;
        
        //Excel 
        static XLWorkbook workbook = new XLWorkbook();
        IXLWorksheet sheet = workbook.Worksheets.Add("Sheet001");
        int Signal_row = 1;
        string path;
        APP_CHANNEL[] chns = new APP_CHANNEL[] { APP_CHANNEL.CHN1, APP_CHANNEL.CHN2, APP_CHANNEL.CHN3, APP_CHANNEL.CHN4, APP_CHANNEL.CHN5, APP_CHANNEL.CHN6, APP_CHANNEL.CHN7, APP_CHANNEL.CHN8, APP_CHANNEL.CHN9, APP_CHANNEL.CHN10, APP_CHANNEL.CHN11, APP_CHANNEL.CHN12, APP_CHANNEL.CHN13, APP_CHANNEL.CHN14, APP_CHANNEL.CHN15, APP_CHANNEL.CHN16, APP_CHANNEL.CHN17};
        private void btn_LoadDBC_Click(object sender, EventArgs e)
        {
            if (MessagePath.Count == 0)
            {
                LoadDBC();
            }
            else
            {
                int ret = MessagePath.Count;
                for (int i = 0; i < ret; i++)
                {
                    if (tb_LoaddbcPath.Text.IndexOf(MessagePath[i]) >= 0)
                    {
                        MessageBox.Show("该DBC已载入，请勿重复载入");
                        break;
                    }
                    else if(i == ret-1)
                    {
                        LoadDBC();
                    }
                }

            }

        }
        
        private void LoadDBC()
        {
            int ret = TsMasterApi.tsdb_load_can_db(tb_LoaddbcPath.Text, chns, ref AId);
            if (ret == 0)
            {
                treeView1.Nodes.Add("CAN报文列表_" + MessageList.ToString());
                treeView1.Nodes[MessageList].Tag = AId;
                DBCname  = TsMasterApi.tsdb_get_can_db_info(AId, 0, 0, 0);
                
                
                MessagePath.Add(DBCname);
                SaveExcel_IndexList.Add(1);

                Log(DBCname + ".dbc加载成功");
                Log("生成报文列表中");
                //获取报文表数量
                
                int SignalCount = int.Parse(TsMasterApi.tsdb_get_can_db_info(AId, 10, 0, 0));
                //获取信号数量
                int MessageCount = int.Parse(TsMasterApi.tsdb_get_can_db_info(AId, 11, 0, 0));
                for (int i = 0; i < MessageCount; i++)
                {
                    //获取报文名称
                    string str1 = TsMasterApi.tsdb_get_can_db_info(AId, 44, i, 0);
                    treeView1.Nodes[MessageList].Nodes.Add(str1);
                    treeView1.Nodes[MessageList].Nodes[i].Tag = i;
                    cbb_CANFIDList.Items.Add((int.Parse(TsMasterApi.tsdb_get_can_db_info(AId, 42, i, 0))).ToString("X2")+ "_CAN_" + MessageList.ToString() + "_" + i.ToString());
                    cbb_Messagelist.Items.Add(str1 + "_CAN_" + MessageList.ToString() + "_" + i.ToString());
                    
                    for (int j = 0; j < SignalCount; j++)
                    {
                        //获取信号名称
                        string str2 = TsMasterApi.tsdb_get_can_db_info(AId, 33, j, 0);
                        //子节点__子子节点重置
                        if (j == 0)
                        {
                            CAN_Node_Index = 0;
                        }
                        //获取当前搜索id的报文id 与信号id是否一致
                        if (TsMasterApi.tsdb_get_can_db_info(AId, 20, j, 0) == TsMasterApi.tsdb_get_can_db_info(AId, 42, i, 0))
                        {
                            
                            treeView1.Nodes[MessageList].Nodes[i].Nodes.Add(str2);
                            //待思考该节点怎么增加Tag与信号索引对应
                            treeView1.Nodes[MessageList].Nodes[i].Nodes[CAN_Node_Index].Tag=j;
                            
                            CAN_Node_Index++;
                            
                            cbb_Signallist.Items.Add(str2 + "_CAN_" + MessageList.ToString() + "_" + i.ToString());
                        }
                    }
                }
                int MessageFDCount = int.Parse(TsMasterApi.tsdb_get_can_db_info(AId, 12, 0, 0));
                if (MessageFDCount > 0)
                {
                    treeView1.Nodes.Add("CANFD报文列表_" + MessageList.ToString());
                    
                    for (int i = 0; i < MessageFDCount; i++)
                    {
                        string str1 = TsMasterApi.tsdb_get_can_db_info(AId, 64, i, 0);
                        treeView1.Nodes[MessageList+1].Nodes.Add(str1);
                        treeView1.Nodes[MessageList+1].Nodes[i].Tag = i;
                        cbb_CANFIDList.Items.Add(TsMasterApi.tsdb_get_can_db_info(AId, 62, i, 0) + "_CANFD_" + MessageList.ToString() + "_" + i.ToString());
                        cbb_Messagelist.Items.Add(str1+ "_CANFD_" + MessageList.ToString() + "_" + i.ToString());
                        for (int j = 0; j < SignalCount; j++)
                        {
                            //子节点__子子节点重置
                            if (j == 0)
                            {
                                CAN_Node_Index = 0;
                            }
                            //获取信号名称
                            string str2 = TsMasterApi.tsdb_get_can_db_info(AId, 33, j, 0);
                            //获取当前搜索id的报文id 与信号id是否一致
                            if (TsMasterApi.tsdb_get_can_db_info(AId, 20, j, 0) == TsMasterApi.tsdb_get_can_db_info(AId, 62, i, 0))
                            {
                                treeView1.Nodes[MessageList + 1].Nodes[i].Nodes.Add(str2);
                                //待思考该节点怎么增加Tag与信号索引对应
                                treeView1.Nodes[MessageList+1].Nodes[i].Nodes[CAN_Node_Index].Tag = j;
                                cbb_Signallist.Items.Add(str2 + "_CANFD_" + MessageList.ToString() + "_" + i.ToString());
                                CAN_Node_Index++;
                            }
                        }
                    }
                    
                }
                
                treeView1.ExpandAll();

                foreach (TreeNode node in treeView1.Nodes)
                {
                    TestMod.HideCheckBox(treeView1, node);
                    foreach (TreeNode child in node.Nodes)
                        TestMod.HideCheckBox(treeView1, child);
                }
                Log("报文列表生成成功");
                cbb_CANFIDList.SelectedIndex = 0;
                cbb_Messagelist.SelectedIndex = 0;
                cbb_Signallist.SelectedIndex = 0;
                MessageList++;
            }
            else
            {
                Log(TsMasterApi.tsapp_get_error_description(ret));
            }
        }
        

        private delegate void DisplayMessage(string AMsg);
        private void Log(string msg)
        {
            if (tbMessage.InvokeRequired)
            {
                tbMessage.Invoke(new DisplayMessage(Log), new object[] { msg });
            }
            else
            {
                if (tbMessage.Lines.Count() > 100)
                {
                    tbMessage.Text = "";
                }
                tbMessage.Text += msg + "\r\n";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TsMasterApi.initialize_lib_tsmaster(Name);
            treeView1.CheckBoxes = true;
            textBox1.Text = "说明：该软件导出can\\canfd信号数据需先加载dbc文件，以及您录制的blf文件。\r\n导出方式有两种，一种直接双击信号名称即可；另一种通过按键导出，需选择对应的报文ID、报文名称、报文信号名称";
            textBox1.ReadOnly = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TsMasterApi.finalize_lib_tsmaster();
        }
        private Point pi;//定义一个坐标变量
                         //editMenuTree为TreeView的Name
        public int m_MouseClicks = 0;
        private void treeView1_MouseDown(object sender, MouseEventArgs e)//当鼠标指针位于控件上并按下鼠标键时发生
        {
            pi = new Point(e.X, e.Y);//记录当前位置
            this.m_MouseClicks = e.Clicks;
        }
        
        
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            //加载dbc后才能被允许导出数据
            if (Isloadblf)
            {
                TreeNode node = this.treeView1.GetNodeAt(pi);//检索位于指定点的树节点
                if (pi.X >= node.Bounds.Left && pi.X <= node.Bounds.Right)//当鼠标双击的位置在某个结点上时
                {
                    //判断选中的是否为信号节点
                    if (treeView1.SelectedNode.Text.IndexOf("报文列表")>=0 || treeView1.SelectedNode.Parent.Text.IndexOf("报文列表")>=0)
                    {
                        MessageBox.Show("输出信号请双击信号");
                    }
                    else
                    {
                        TsMasterApi.tslog_blf_read_start(tb_LoadblfPath.Text, ref AHeadleblf, ref AObjCount);
                        CANAValue = 0;
                        CANAValuelist.Clear();
                        MessageName = treeView1.SelectedNode.Parent.Text;
                        SignalName =  treeView1.SelectedNode.Text;
                        realIndex = 0;
                        TLIBCAN tmpCAN = new TLIBCAN();
                        TLIBLIN tmpLIN = new TLIBLIN();
                        TLIBCANFD tmpCANFD = new TLIBCANFD();
                        Log("数据处理中");

                        //导出不同数据库做准备
                        DBC_Index = int.Parse(treeView1.SelectedNode.Parent.Parent.Text.Substring(treeView1.SelectedNode.Parent.Parent.Text.IndexOf("_")));
                        


                        for (int i = 0; i < AObjCount; i++)
                        {

                            TsMasterApi.tslog_blf_read_object(AHeadleblf, ref realIndex, ref messageType, ref tmpCAN, ref tmpLIN, ref tmpCANFD);
                            if (messageType == TSupportedObjType.sotCAN)
                            {
                                //判断报文id 与选中信号节点报文id是否一致
                                if (tmpCAN.FIdentifier == int.Parse(TsMasterApi.tsdb_get_can_db_info((uint)treeView1.SelectedNode.Parent.Parent.Tag, 42, (int)treeView1.SelectedNode.Parent.Tag, 0)))
                                {
                                    TsMasterApi.tsdb_get_signal_value_can(ref tmpCAN, treeView1.SelectedNode.Parent.Text, treeView1.SelectedNode.Text,ref CANAValue);
                                    CANAValuelist.Add(CANAValue);
                                }
                            }
                            else if (messageType == TSupportedObjType.sotCANFD)
                            {
                                if (tmpCANFD.FIdentifier == int.Parse(TsMasterApi.tsdb_get_can_db_info((uint)treeView1.SelectedNode.Parent.Parent.Tag, 62, (int)treeView1.SelectedNode.Parent.Tag, 0)))
                                {
                                    TsMasterApi.tsdb_get_signal_value_canfd(ref tmpCANFD, treeView1.SelectedNode.Parent.Text, treeView1.SelectedNode.Text, ref CANAValue);
                                    CANAValuelist.Add(CANAValue);
                                }
                            }
                        }
                        TsMasterApi.tslog_blf_read_end(AHeadleblf);
                        
                        if (CANAValuelist.Count != 0)
                        {
                            SaveCSV(CANAValuelist);
                        }
                        Log("数据导出完成");
                        //Log(treeView1.SelectedNode.Parent.Text);
                        //Log(treeView1.SelectedNode.Parent.Tag.ToString());
                    }

                }
            }
            else
            {
                MessageBox.Show("请先载入blf文件");
            }
        }
        

        private void SaveCSV(List<Double> list1)
        {
            //注释部分为不同DBC导出不同Excel做准备
            string DateTimes = DateTime.Now.ToString("yyyy-MM-dd-HH");
            string newPath = System.IO.Path.Combine("./", DateTimes);
            System.IO.Directory.CreateDirectory(newPath);
            //path = newPath + "/" + MessagePath[DBC_Index] + "Blf_Message.xlsx";
            //sheet.Cell(1, SaveExcel_IndexList[DBC_Index]).Value = MessageName + ":" + SignalName;
            path = newPath + "/Blf_Message.xlsx";
            sheet.Cell(1,Signal_row).Value = MessageName + ":" + SignalName;
            for (int i = 0; i < list1.Count; i++)
            {
                sheet.Cell(i + 2,Signal_row).Value = list1[i].ToString();//该方法也是从1开始，非0
                //sheet.Cell(i + 2, SaveExcel_IndexList[DBC_Index]).Value = list1[i].ToString();
            }
            workbook.SaveAs(path);
            Signal_row++;
            //SaveExcel_IndexList[DBC_Index]++;
        }
        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = (this.m_MouseClicks > 1);
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = (this.m_MouseClicks > 1);
        }
        
        private void btn_Loadlbf_Click(object sender, EventArgs e)
        {
            int ret = TsMasterApi.tslog_blf_read_start(tb_LoadblfPath.Text,ref AHeadleblf,ref AObjCount);
            if (ret == 0)
            {
                Log("blf文件加载成功");
                Isloadblf = true;
                TsMasterApi.tslog_blf_read_end(AHeadleblf);
            }
            else
            {
                Log(TsMasterApi.tsapp_get_error_description(ret));
            }
        }

        private void btn_SaveCSV_Click(object sender, EventArgs e)
        {
            if (Isloadblf)
            {
                int CANidstr = int.Parse(cbb_CANFIDList.Text.Substring(0, cbb_CANFIDList.Text.IndexOf("_CAN")));
                string CANMesstr = cbb_Messagelist.Text.Substring(0, cbb_Messagelist.Text.IndexOf("_CAN"));
                string CANSgntr = cbb_Signallist.Text.Substring(0, cbb_Signallist.Text.IndexOf("_CAN"));
                realIndex = 0;
                CANAValuelist.Clear();
                TLIBCAN tmpCAN = new TLIBCAN();
                TLIBLIN tmpLIN = new TLIBLIN();
                TLIBCANFD tmpCANFD = new TLIBCANFD();
                Log("数据处理中");
                TsMasterApi.tslog_blf_read_start(tb_LoadblfPath.Text, ref AHeadleblf, ref AObjCount);
                for (int i = 0; i < AObjCount; i++)
                {

                    TsMasterApi.tslog_blf_read_object(AHeadleblf, ref realIndex, ref messageType, ref tmpCAN, ref tmpLIN, ref tmpCANFD);
                    if (messageType == TSupportedObjType.sotCAN)
                    {
                        if (int.Parse(tmpCAN.FIdentifier.ToString("X2")) == CANidstr)
                        {
                            TsMasterApi.tsdb_get_signal_value_can(ref tmpCAN, CANMesstr, CANSgntr, ref CANAValue);
                            CANAValuelist.Add(CANAValue);
                        }
                    }
                    else if (messageType == TSupportedObjType.sotCANFD)
                    {
                        if (int.Parse(tmpCANFD.FIdentifier.ToString("X2")) == CANidstr)
                        {
                            TsMasterApi.tsdb_get_signal_value_canfd(ref tmpCANFD, CANMesstr, CANSgntr, ref CANAValue);
                            CANAValuelist.Add(CANAValue);
                        }
                    }
                }
                TsMasterApi.tslog_blf_read_end(AHeadleblf);
                if (CANAValuelist.Count != 0)
                {
                    SaveCSV(CANAValuelist);
                }
                Log("数据导出完成");

            }
            else
            {
                MessageBox.Show("请先导入blf文件");
            }

        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Checked)
            {
                
            }
        }
    }
}
