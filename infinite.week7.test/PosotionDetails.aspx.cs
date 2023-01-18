using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

using System.Data;

namespace infinite.week7.test
{
    public partial class PosotionDetails : System.Web.UI.Page
    {
        private SqlConnection conobj = null;
        private SqlCommand cmdobj = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddNew_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (conobj = new SqlConnection(ConfigurationManager.ConnectionStrings["HRCon"].ConnectionString))
                {
                    using (cmdobj = new SqlCommand("InsertPositionDetails", conobj))
                    {
                        cmdobj.CommandType = CommandType.StoredProcedure;
                        cmdobj.Parameters.AddWithValue("@PositionCode", TxtPositionCode.Text);
                        cmdobj.Parameters.AddWithValue("@Description", TxtDescription.Text);
                        cmdobj.Parameters.AddWithValue("@Year", DdlYear.SelectedValue);
                        cmdobj.Parameters.AddWithValue("@BudgetStrength", TxtBudgetedStrength.Text);
                        cmdobj.Parameters.AddWithValue("CurrentStrength", TxtCurrentStrength.Text);



                        if (conobj.State == ConnectionState.Closed)
                        {
                            conobj.Open();
                        }
                        int res = cmdobj.ExecuteNonQuery();
                        if (res > 0)
                        {
                            LblMessage.Text = "Position Added Successfully";
                        }
                        else
                        {
                            LblMessage.Text = "Error";
                        }



                        cmdobj.Dispose();
                        conobj.Close();



                    }
                }
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {

            TxtPositionCode.Text = "";
            TxtDescription.Text = "";
            TxtCurrentStrength.Text = "";
            TxtBudgetedStrength.Text = "";
            DdlYear.SelectedValue = null;

        }
    }
}









   