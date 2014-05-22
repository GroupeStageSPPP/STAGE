using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetRH_Test_V2
{
    public partial class TestPassageRequest : Form
    {
        List<string> _ReqAP;
        List<string> _ReqAS1;
        List<string> _ReqAS2;
        List<string> _ReqAS3;

        public TestPassageRequest(List<string> ReqAP, List<string> ReqAS1, List<string> ReqAS2 = null, List<string> ReqAS3 = null)
        {
            InitializeComponent();

            _ReqAP = ReqAP;
            _ReqAS1 = ReqAS1;
            _ReqAS2 = ReqAS2;
            _ReqAS3 = ReqAS3;
        }

        private void TestPassageRequest_Load(object sender, EventArgs e)
        {
            labelAP_1.Text = _ReqAP[0];
            if (_ReqAP.Count() > 1)
            {
                labelAP_2.Text = _ReqAP[1];
                labelAP_3.Text = _ReqAP[2];
            }
            else
            {
                labelAP_2.Visible = false;
                labelAP_3.Visible = false;
            }

            labelAS1_1.Text = _ReqAS1[0];
            labelAS1_2.Text = _ReqAS1[1];
            labelAS1_3.Text = _ReqAS1[2];
            labelAS1_4.Text = _ReqAS1[3];

            if (_ReqAS2 != null)
            {
                labelAS2_1.Text = _ReqAS2[0];
                labelAS2_2.Text = _ReqAS2[1];
                labelAS2_3.Text = _ReqAS2[2];
                labelAS2_4.Text = _ReqAS2[3];
            }
            else
            {
                labelAS2_1.Visible = false;
                labelAS2_2.Visible = false;
                labelAS2_3.Visible = false;
                labelAS2_4.Visible = false;
            }

            if (_ReqAS3 != null)
            {
                labelAS3_1.Text = _ReqAS3[0];
                labelAS3_2.Text = _ReqAS3[1];
                labelAS3_3.Text = _ReqAS3[2];
                labelAS3_4.Text = _ReqAS3[3];
            }
            else
            {
                labelAS3_1.Visible = false;
                labelAS3_2.Visible = false;
                labelAS3_3.Visible = false;
                labelAS3_4.Visible = false;
            }

        }


    }
}
