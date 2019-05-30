using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Mixer;
using NAudio.Wave;

namespace OutputRegulator
{
    public partial class Form1 : Form
    {
        #region debug

#if DEBUG
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
#endif

        #endregion

        /// <summary>
        /// list of all output devices
        /// </summary>
        private readonly MMDeviceCollection _outputDevices;

        /// <summary>
        /// default volume scalar before reduce this
        /// </summary>
        private readonly List<float> _defaultVolumeScalar = new List<float>();

        /// <summary>
        /// selected input device (can be one)
        /// </summary>
        private readonly MMDevice _input;

        /// <summary>
        /// selected output device, if all checkbox is on this is useless
        /// </summary>
        private readonly MMDevice _output;

        private int _selectedOutputDevice;

        private int _tick;

        private bool _isActive;

        private readonly IniSettings _iniSettings = new IniSettings("./config.ini");

        public Form1()
        {
            #region debug

#if DEBUG


            AllocConsole();
#endif

            #endregion

            InitializeComponent();

            var enumerator = new MMDeviceEnumerator();
            var inputDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);

            _outputDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            _input = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Console);
            _output = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);

            Console.WriteLine(@"Default input {0}", _input);
            Console.WriteLine(@"Default output: {0}", _output);

            var settingsDeviceInput = _iniSettings.ReadValue("devices", "input");
            var settingsDeviceOutput = _iniSettings.ReadValue("devices", "output");

            // if no input device was set then use default
            if (string.IsNullOrEmpty(settingsDeviceInput))
            {
                settingsDeviceInput = _input.ToString();
            }

            // if no output device was set then use default
            if (string.IsNullOrEmpty(settingsDeviceOutput))
            {
                settingsDeviceOutput = _output.ToString();
            }

            // use default input device if current input device was not found
            var test = inputDevices.FirstOrDefault(device => device.ToString() == settingsDeviceInput);
            if (test == null)
            {
                settingsDeviceInput = _input.ToString();
            }

            // use default input device if current input device was not found
            test = _outputDevices.FirstOrDefault(device => device.ToString() == settingsDeviceOutput);
            if (test == null)
            {
                settingsDeviceOutput = _output.ToString();
            }

            foreach (var input in inputDevices)
            {
                inputDevice.Items.Add(input);
                if (settingsDeviceInput == input.ToString())
                {
                    inputDevice.SelectedIndex = inputDevice.Items.Count - 1;
                }
            }

            foreach (var output in _outputDevices)
            {
                outputDevice.Items.Add(output);
                if (settingsDeviceOutput == output.ToString())
                {
                    outputDevice.SelectedIndex = outputDevice.Items.Count - 1;
                }

                _defaultVolumeScalar.Add(output.AudioEndpointVolume.MasterVolumeLevelScalar);
            }

            reduceAll.Checked = _iniSettings.ReadBool("config", "reduceAll");
            reducePercent.Value = _iniSettings.ReadInt("config", "reducePercent", 70);
            needInputVolume.Value = _iniSettings.ReadInt("config", "needInputVolume", 10);
            ticksBeforeDeactivate.Value = _iniSettings.ReadInt("config", "ticksBeforeDeactivate", 30);

            updateTimer.Interval = 10;
            updateTimer.Start();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            progressBarVolume.Value = (int) (_input.AudioMeterInformation.MasterPeakValue * 100);
            labelInputVolume.Text = progressBarVolume.Value + @"%";

            float scalar = 0;
            if (progressBarVolume.Value >= needInputVolume.Value)
            {
                _tick = 0;
                if (_isActive)
                {
                    return;
                }

                scalar = (float) (reducePercent.Value / 100);
                _isActive = true;
            }
            else
            {
                if (!_isActive)
                {
                    return;
                }

                if (++_tick >= ticksBeforeDeactivate.Value)
                {
                    scalar = 0;
                    _isActive = false;
                }

                if (_isActive)
                {
                    return;
                }
            }

            if (reduceAll.Checked)
            {
                for (var i = 0; i < _outputDevices.Count; i++)
                {
                    SetOutput(_outputDevices.ElementAt(i), scalar, i);
                }
            }
            else
            {
                SetOutput(_output, scalar, _selectedOutputDevice);
            }
        }

        private void SetOutput(MMDevice output, float scalar, int defaultScalar)
        {
            output.AudioEndpointVolume.MasterVolumeLevelScalar = _defaultVolumeScalar[defaultScalar] - _defaultVolumeScalar[defaultScalar] * scalar;
        }

        private void reduceAll_CheckedChanged(object sender, EventArgs e)
        {
            outputDevice.Enabled = !reduceAll.Checked;
        }

        private void outputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedOutputDevice = outputDevice.SelectedIndex;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form_Closed(object sender, EventArgs e)
        {
            _iniSettings.WriteValue("devices", "input", inputDevice.SelectedItem.ToString());
            _iniSettings.WriteValue("devices", "output", outputDevice.SelectedItem.ToString());
            _iniSettings.WriteValue("config", "reduceAll", reduceAll.Checked ? "1" : "0");
            _iniSettings.WriteValue("config", "reducePercent", reducePercent.Value.ToString(CultureInfo.InvariantCulture));
            _iniSettings.WriteValue("config", "needInputVolume", needInputVolume.Value.ToString(CultureInfo.InvariantCulture));
            _iniSettings.WriteValue("config", "ticksBeforeDeactivate", ticksBeforeDeactivate.Value.ToString(CultureInfo.InvariantCulture));
            
            // reset outputs to default
            for (var i = 0; i < _outputDevices.Count; i++)
            {
                SetOutput(_outputDevices.ElementAt(i), 0, i);
            }
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;

            Hide();
            notifyIcon1.Visible = true;
        }
    }
}