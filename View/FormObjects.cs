using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyFootball.View
{
    public class FillLabel:Label
    {
        public FillLabel(string text)
            :this()
        {
            Text = text;
        }
        public FillLabel()
        {
            Dock = DockStyle.Fill;
            TextAlign = ContentAlignment.MiddleCenter;
        }
    }

    public class DefaultTopTableItemPanel:TableLayoutPanel
    {
        public DefaultTopTableItemPanel()
        {
            Height = 35;
            Dock = DockStyle.Top;
            Anchor = AnchorStyles.Left | AnchorStyles.Top;
            //CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }
    }

    public class FillButton:Button
    {
        public FillButton(string text)
        {
            this.Text = text;
            this.Dock = DockStyle.Top;
            FlatStyle = FlatStyle.Standard;
        }
    }

    public class DefaultTextBox : TextBox
    {
        public DefaultTextBox(string text)
        {
            Text = text;
            Dock = DockStyle.Fill;
        }

        public DefaultTextBox()
        {
            Dock = DockStyle.Fill;
        }
    }

    public class FillHeaderLabel : Label
    {
        public FillHeaderLabel(string text)
            :this()
        {
            Text = text;
        }
        public FillHeaderLabel()
        {
            Dock = DockStyle.Fill;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
        }
    }

    public class FillTablePanel: TableLayoutPanel
    {
        public FillTablePanel(int columnCount, int rowCount) 
        {
            Dock = DockStyle.Fill;
            ColumnCount = columnCount;
            RowCount = rowCount;
            //CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }

        public FillTablePanel()
        {
            Dock= DockStyle.Fill;
        }
    }

    public class DefaultDGW:DataGridView
    {
        public DefaultDGW()
        {
            Dock = DockStyle.Fill;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            ReadOnly = true;
            RowHeadersVisible = false;
        }
    }

    public class TwoPartContentForm : Form
    {
        private FillTablePanel mainPanel;
        
        public TwoPartContentForm()
        {
            mainPanel = new FillTablePanel(1, 2);
        }
    }
}
