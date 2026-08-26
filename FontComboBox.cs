using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VaderConsulting
{
    public class FontComboBox : ComboBox
    {
        private Font _Font = new Font("Arial", 8);
        private Pen _Pen = new Pen(Color.Black);
        private StringFormat _StringFormat = new StringFormat();

        internal FontComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            _StringFormat.Trimming = StringTrimming.None;
            _StringFormat.FormatFlags = StringFormatFlags.NoWrap;
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                ListFonts();
            this.DropDownHeight = 300;
            this.Font = new Font(this.Font.Name, 12);
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.MaxDropDownItems = 20;
        }

        private void ListFonts()
        {
            this.Items.Clear();
            System.Drawing.Text.InstalledFontCollection ifc = new System.Drawing.Text.InstalledFontCollection();
            this.BeginUpdate();
            foreach (FontFamily ff in ifc.Families)
            {
                this.Items.Add(ff.Name);
            }

            this.EndUpdate();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            //refresh pen and font
            try
            {
                FontFamily ff = new FontFamily(this.Items[e.Index].ToString());

                if (ff.IsStyleAvailable(FontStyle.Regular) == true)
                {
                    _Font = new Font(this.Items[e.Index].ToString(), this.Font.Size, FontStyle.Regular);
                }
                else if (ff.IsStyleAvailable(FontStyle.Italic) == true)
                {
                    _Font = new Font(this.Items[e.Index].ToString(), this.Font.Size, FontStyle.Italic);
                }
                else if (ff.IsStyleAvailable(FontStyle.Bold) == true)
                {
                    _Font = new Font(this.Items[e.Index].ToString(), this.Font.Size, FontStyle.Bold);
                }
                else
                {
                    _Font = new Font("Microsoft Sans Serif", this.Font.Size, FontStyle.Regular);
                }
            }
            catch (Exception)
            {
                _Font = new Font(this.Items[e.Index].ToString(), this.Font.Size, FontStyle.Bold);
            }
            _Pen = new Pen(this.ForeColor);

            e.DrawBackground();

            e.Graphics.DrawString(this.Items[e.Index].ToString(), _Font, _Pen.Brush, e.Bounds);

            if (e.State == DrawItemState.Focus)
                e.DrawFocusRectangle();

            //clear memory
            _Pen.Dispose();
            _Font.Dispose();
        }
    }
}
