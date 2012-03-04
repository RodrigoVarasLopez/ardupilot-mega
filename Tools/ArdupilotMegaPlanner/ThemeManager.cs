﻿using System;
using System.Drawing;
using System.Windows.Forms;
using log4net;

namespace ArdupilotMega
{
    /// <summary>
    /// Helper class for the stylng 'theming' of forms and controls, and provides MessageBox
    /// replacements which are also styled
    /// </summary>
    public class ThemeManager
    {
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static Themes _currentTheme = Themes.BurntKermit;

        public enum Themes
        {
            /// <summary>
            /// no theme - standard Winforms appearance
            /// </summary>
            None,
   
            /// <summary>
            /// Standard Planner Charcoal & Green colours
            /// </summary>
            BurntKermit,
        }

        /// <summary>
        /// Change the current theme. Existing controls are not affected
        /// </summary>
        /// <param name="theme"></param>
        public static void SetTheme(Themes theme)
        {
            log.Debug("Theme set to " +  Enum.GetName(typeof(Themes), theme));
            _currentTheme = theme;
        }

        /// <summary>
        /// Will recursively apply the current theme to 'control'
        /// </summary>
        /// <param name="control"></param>
        public static void ApplyThemeTo(Control control)
        {
            switch (_currentTheme)
            {
                case Themes.BurntKermit: ApplyBurntKermitTheme(control, 0);
                    break;
            
                    // More themes go here

                default:
                    break;
            }

                    
        }

        private static void ApplyBurntKermitTheme(Control temp, int level)
        {
            if (level == 0)
            {
                temp.BackColor = Color.FromArgb(0x26, 0x27, 0x28);
                temp.ForeColor = Color.White;// Color.FromArgb(0xe6, 0xe8, 0xea);
            }

            //temp.Font = new Font("Lucida Console", 8.25f);

            foreach (Control ctl in temp.Controls)
            {
                if (ctl.GetType() == typeof(Button))
                {
                    ctl.ForeColor = Color.Black;
                }
                else if (ctl.GetType() == typeof(TextBox))
                {
                    ctl.BackColor = Color.FromArgb(0x43, 0x44, 0x45);
                    ctl.ForeColor = Color.White;// Color.FromArgb(0xe6, 0xe8, 0xea);
                    TextBox txt = (TextBox)ctl;
                    txt.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof(DomainUpDown))
                {
                    ctl.BackColor = Color.FromArgb(0x43, 0x44, 0x45);
                    ctl.ForeColor = Color.White;// Color.FromArgb(0xe6, 0xe8, 0xea);
                    DomainUpDown txt = (DomainUpDown)ctl;
                    txt.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof(GroupBox))
                {
                    ctl.BackColor = Color.FromArgb(0x26, 0x27, 0x28);
                    ctl.ForeColor = Color.White;// Color.FromArgb(0xe6, 0xe8, 0xea);
                }
                else if (ctl.GetType() == typeof(ZedGraph.ZedGraphControl))
                {
                    var zg1 = (ZedGraph.ZedGraphControl)ctl;
                    zg1.GraphPane.Chart.Fill = new ZedGraph.Fill(Color.FromArgb(0x1f, 0x1f, 0x20));
                    zg1.GraphPane.Fill = new ZedGraph.Fill(Color.FromArgb(0x37, 0x37, 0x38));

                    foreach (ZedGraph.LineItem li in zg1.GraphPane.CurveList)
                        li.Line.Width = 4;

                    zg1.GraphPane.Title.FontSpec.FontColor = Color.White;

                    zg1.GraphPane.XAxis.MajorTic.Color = Color.White;
                    zg1.GraphPane.XAxis.MinorTic.Color = Color.White;
                    zg1.GraphPane.YAxis.MajorTic.Color = Color.White;
                    zg1.GraphPane.YAxis.MinorTic.Color = Color.White;

                    zg1.GraphPane.XAxis.MajorGrid.Color = Color.White;
                    zg1.GraphPane.YAxis.MajorGrid.Color = Color.White;

                    zg1.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White;
                    zg1.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White;

                    zg1.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White;
                    zg1.GraphPane.XAxis.Title.FontSpec.FontColor = Color.White;

                    zg1.GraphPane.Legend.Fill = new ZedGraph.Fill(Color.FromArgb(0x85, 0x84, 0x83));
                    zg1.GraphPane.Legend.FontSpec.FontColor = Color.White;
                }
                else if (ctl.GetType() == typeof(BSE.Windows.Forms.Panel) || ctl.GetType() == typeof(SplitterPanel))
                {
                    ctl.BackColor = Color.FromArgb(0x26, 0x27, 0x28);
                    ctl.ForeColor = Color.White;// Color.FromArgb(0xe6, 0xe8, 0xea);
                }
                else if (ctl.GetType() == typeof(Form))
                {
                    ctl.BackColor = Color.FromArgb(0x26, 0x27, 0x28);
                    ctl.ForeColor = Color.White;// Color.FromArgb(0xe6, 0xe8, 0xea);
                }
                else if (ctl.GetType() == typeof(RichTextBox))
                {
                    ctl.BackColor = Color.FromArgb(0x43, 0x44, 0x45);
                    ctl.ForeColor = Color.White;
                    RichTextBox txtr = (RichTextBox)ctl;
                    txtr.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof(CheckedListBox))
                {
                    ctl.BackColor = Color.FromArgb(0x43, 0x44, 0x45);
                    ctl.ForeColor = Color.White;
                    CheckedListBox txtr = (CheckedListBox)ctl;
                    txtr.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof(TabPage))
                {
                    ctl.BackColor = Color.FromArgb(0x26, 0x27, 0x28);  //Color.FromArgb(0x43, 0x44, 0x45);
                    ctl.ForeColor = Color.White;
                    TabPage txtr = (TabPage)ctl;
                    txtr.BorderStyle = BorderStyle.None;
                }
                else if (ctl.GetType() == typeof(TabControl))
                {
                    ctl.BackColor = Color.FromArgb(0x26, 0x27, 0x28);  //Color.FromArgb(0x43, 0x44, 0x45);
                    ctl.ForeColor = Color.White;
                    TabControl txtr = (TabControl)ctl;

                }
                else if (ctl.GetType() == typeof(DataGridView))
                {
                    ctl.ForeColor = Color.White;
                    DataGridView dgv = (DataGridView)ctl;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.BackgroundColor = Color.FromArgb(0x26, 0x27, 0x28);
                    DataGridViewCellStyle rs = new DataGridViewCellStyle();
                    rs.BackColor = Color.FromArgb(0x43, 0x44, 0x45);
                    rs.ForeColor = Color.White;
                    dgv.RowsDefaultCellStyle = rs;

                    DataGridViewCellStyle hs = new DataGridViewCellStyle(dgv.ColumnHeadersDefaultCellStyle);
                    hs.BackColor = Color.FromArgb(0x26, 0x27, 0x28);
                    hs.ForeColor = Color.White;

                    dgv.ColumnHeadersDefaultCellStyle = hs;
                    dgv.RowHeadersDefaultCellStyle = hs;
                }
                else if (ctl.GetType() == typeof(ComboBox))
                {
                    ctl.BackColor = Color.FromArgb(0x43, 0x44, 0x45);
                    ctl.ForeColor = Color.White;
                    ComboBox CMB = (ComboBox)ctl;
                    CMB.FlatStyle = FlatStyle.Flat;
                }
                else if (ctl.GetType() == typeof(NumericUpDown))
                {
                    ctl.BackColor = Color.FromArgb(0x43, 0x44, 0x45);
                    ctl.ForeColor = Color.White;
                }
                else if (ctl.GetType() == typeof(TrackBar))
                {
                    ctl.BackColor = Color.FromArgb(0x26, 0x27, 0x28);
                    ctl.ForeColor = Color.White;
                }
                else if (ctl.GetType() == typeof(LinkLabel))
                {
                    ctl.BackColor = Color.FromArgb(0x26, 0x27, 0x28);
                    ctl.ForeColor = Color.White;
                    LinkLabel LNK = (LinkLabel)ctl;
                    LNK.ActiveLinkColor = Color.White;
                    LNK.LinkColor = Color.White;
                    LNK.VisitedLinkColor = Color.White;

                }
                else if (ctl.GetType() == typeof(HorizontalProgressBar2) || ctl.GetType() == typeof(VerticalProgressBar2))
                {
                    ((HorizontalProgressBar2)ctl).BackgroundColor = Color.FromArgb(0x43, 0x44, 0x45);
                    ((HorizontalProgressBar2)ctl).ValueColor = Color.FromArgb(148, 193, 31);
                }

                if (ctl.Controls.Count > 0)
                    ApplyBurntKermitTheme(ctl, 1);
            }
        }

    }
}