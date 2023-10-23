using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LW5.Logic;

namespace LW5.UserInterface
{
    public partial class ResultViewer : Form
    {
        private List<Vertex> _result;
        public ResultViewer()
        {
            InitializeComponent();
        }

        public void SetContent(List<Vertex> result)
        {
            _result = result;

            UpdateData();
        }

        private void UpdateData()
        {
            DataView.Columns.Add("Number", "№");
            DataView.Columns[0].Width = 30;
            DataView.Columns.Add("Identifier", "Идентификатор");
            DataView.Columns.Add("Color", "Цвет");

            for (int i = 0; i < _result.Count; i++)
            {
                DataView.Rows.Add(i+1, _result[i].Identifier, _result[i].Color);
            }
        }

        private void DataView_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
