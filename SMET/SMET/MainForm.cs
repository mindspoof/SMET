using System;
using System.Windows.Forms;

namespace SMET
{
    public partial class MainForm : Form
    {
        readonly MeterpreterBuilder _builder = new MeterpreterBuilder();
        private bool isBindTcp = false;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbPayload.SelectedIndex = 0;
            cmbEncryption.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            txtStatus.Text = @"SMET - Symmetric Meterpreter Encryption Tool" + Environment.NewLine + @"Eyüp Çelik - @EPICROUTERS - http://eyupcelik.com.tr";
        }
        private void btnBuilder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIP.Text))
            {
                if (!string.IsNullOrEmpty(txtPort.Text))
                {
                    _builder.Ip = txtIP.Text;
                    _builder.Port = txtPort.Text;
                    if (cmbPayload.SelectedIndex == 0)
                    {
                        if (cmbEncryption.SelectedIndex == 0)
                        {
                            txtStatus.Text += Environment.NewLine + @"Meterpreter reverse_tcp " + cmbType.Text + @" is building, please wait...";
                            if (cmbType.SelectedIndex == 0)
                            {
                                _builder.SaveReverseMeterpreter();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                            else
                            {
                                _builder.SaveReverseMeterpreterConsole();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                        }
                        else if (cmbEncryption.SelectedIndex == 1)
                        {
                            txtStatus.Text += Environment.NewLine + @"Meterpreter reverse_tcp " + cmbType.Text + @" AES Encrypted is building, please wait...";
                            txtStatus.Text += Environment.NewLine + @"AES Decrypt Key = ]Ze68t`WFDrs9DJ(cIXTqOvHJnjJR':%oA77go";
                            if (cmbType.SelectedIndex == 0)
                            {
                                _builder.SaveReverseMeterpreterAes();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                            else
                            {
                                _builder.SaveReverseMeterpreterAesConsole();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                        }
                        else
                        {
                            txtStatus.Text += Environment.NewLine + @"Meterpreter reverse_tcp " + cmbType.Text + @" DES Encrypted is building, please wait...";
                            txtStatus.Text += Environment.NewLine + @"DES Decrypt Key = <7/m9@bA";
                            if (cmbType.SelectedIndex == 0)
                            {
                                _builder.SaveReverseMeterpreterDes();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                            else
                            {
                                _builder.SaveReverseMeterpreterDesConsole();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                        }
                    }
                    else if (cmbPayload.SelectedIndex == 1)
                    {
                        txtStatus.Text += Environment.NewLine + @"x64 Meterpreter reverse_tcp " + cmbType.Text + @" is building, please wait...";
                        if (cmbType.SelectedIndex == 0)
                        {
                            _builder.Savex64ReverseMeterpreter();
                            txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                        }
                        else
                        {
                            _builder.Savex64ReverseMeterpreterConsole();
                            txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                        }
                    }
                    else if (cmbPayload.SelectedIndex == 2)
                    {
                        if (cmbEncryption.SelectedIndex == 0)
                        {
                            txtStatus.Text += Environment.NewLine + @"Meterpreter reverse_tcp_rc4 " + cmbType.Text + @" is building, please wait...";
                            txtStatus.Text += Environment.NewLine + @"RC4 Password = warsql";
                            if (cmbType.SelectedIndex == 0)
                            {
                                _builder.SaveMeterpreterRc4();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                            else
                            {
                                _builder.SaveMeterpreterRc4Console();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                        }
                        else if (cmbEncryption.SelectedIndex == 1)
                        {
                            txtStatus.Text += Environment.NewLine + @"Meterpreter reverse_tcp_rc4 " + cmbType.Text + @" AES Encrypted is building, please wait...";
                            txtStatus.Text += Environment.NewLine + @"AES Decrypt Key = k}{eG>ES,i6mTCAsG)1udbki/a";
                            txtStatus.Text += Environment.NewLine + @"RC4 Password = warsql";
                            if (cmbType.SelectedIndex == 0)
                            {
                                _builder.SaveMeterpreterRc4Aes();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                            else
                            {
                                _builder.SaveMeterpreterRc4AesConsole();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                        }
                        else
                        {
                            txtStatus.Text += Environment.NewLine + @"Meterpreter reverse_tcp_rc4 " + cmbType.Text + @" DES Encrypted is building, please wait...";
                            txtStatus.Text += Environment.NewLine + @"DES Decrypt Key = z*W)6.@7";
                            txtStatus.Text += Environment.NewLine + @"RC4 Password = warsql";
                            if (cmbType.SelectedIndex == 0)
                            {
                                _builder.SaveMeterpreterRc4Des();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                            else
                            {
                                _builder.SaveMeterpreterRc4DesConsole();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                        }
                    }
                    else if (cmbPayload.SelectedIndex == 3)
                    {
                        if (cmbEncryption.SelectedIndex == 0)
                        {
                            txtStatus.Text += Environment.NewLine + @"Metasploit shell/reverse_tcp " + cmbType.Text + @" is building, please wait...";
                            if (cmbType.SelectedIndex == 0)
                            {
                                _builder.SaveReverseShell();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                            else
                            {
                                _builder.SaveReverseShellConsole();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                        }
                        else if (cmbEncryption.SelectedIndex == 1)
                        {
                            txtStatus.Text += Environment.NewLine + @"Metasploit shell/reverse_tcp " + cmbType.Text + @" AES Encrypted is building, please wait...";
                            txtStatus.Text += Environment.NewLine + @"AES Decrypt Key = %HR$L-:#upg5cW7kDeva}aOkjK";
                            if (cmbType.SelectedIndex == 0)
                            {
                                _builder.SaveReverseShellAes();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                            else
                            {
                                _builder.SaveReverseShellAesConsole();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                        }
                        else
                        {
                            txtStatus.Text += Environment.NewLine + @"Metasploit shell/reverse_tcp " + cmbType.Text + @" DES Encrypted is building, please wait...";
                            txtStatus.Text += Environment.NewLine + @"DES Decrypt Key = ?(#(?5:3";
                            if (cmbType.SelectedIndex == 0)
                            {
                                _builder.SaveReverseShellDes();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                            else
                            {
                                _builder.SaveReverseShellDesConsole();
                                txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                            }
                        }
                    }
                }
                else
                {
                    txtStatus.Text += Environment.NewLine + @"Port can not be empty";
                }
            }
            else
            {
                if (isBindTcp == true)
                {
                    if (cmbEncryption.SelectedIndex == 0)
                    {
                        _builder.Port = txtPort.Text;
                        txtStatus.Text += Environment.NewLine + @"Meterpreter bind_tcp " + cmbType.Text + @" is building, please wait...";
                        if (cmbType.SelectedIndex == 0)
                        {
                            _builder.SaveBindMeterpreter();
                            txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                        }
                        else
                        {
                            _builder.SaveBindMeterpreterConsole();
                            txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                        }
                    }
                    else if (cmbEncryption.SelectedIndex == 1)
                    {
                        _builder.Port = txtPort.Text;
                        txtStatus.Text += Environment.NewLine + @"Meterpreter bind_tcp " + cmbType.Text + @" is building, please wait...";
                        txtStatus.Text += Environment.NewLine + @"AES Decrypt Key = )'QIYUsKfEfno1*`<d|EU8cuMt";
                        if (cmbType.SelectedIndex == 0)
                        {
                            _builder.SaveBindMeterpreterAes();
                            txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                        }
                        else
                        {
                            _builder.SaveBindMeterpreterAesConsole();
                            txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                        }
                    }
                    else
                    {
                        _builder.Port = txtPort.Text;
                        txtStatus.Text += Environment.NewLine + @"Meterpreter bind_tcp " + cmbType.Text + @" is building, please wait...";
                        txtStatus.Text += Environment.NewLine + @"DES Decrypt Key = l+'dW1*.";
                        if (cmbType.SelectedIndex == 0)
                        {
                            _builder.SaveBindMeterpreterDes();
                            txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                        }
                        else
                        {
                            _builder.SaveBindMeterpreterDesConsole();
                            txtStatus.Text += Environment.NewLine + @"File Saved: " + Application.StartupPath + @"\" + _builder.FileName;
                        }
                    }

                }
                else
                {
                    txtStatus.Text += Environment.NewLine + @"IP address can not be empty";
                }
            }
        }
        private void cmbPayload_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayload.SelectedIndex == 4)
            {
                txtIP.Text = string.Empty;
                txtIP.ReadOnly = true;
                isBindTcp = true;
            }
            else
            {
                txtIP.ReadOnly = false;
                isBindTcp = false;
            }
        }
    }
}
