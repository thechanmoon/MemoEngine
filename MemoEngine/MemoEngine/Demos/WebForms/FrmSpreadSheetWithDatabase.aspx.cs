﻿using MemoEngine.Models;
using System;
using System.Collections.Generic;

namespace MemoEngine.Demos.WebForms
{
    public partial class FrmSpreadSheetWithDatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                기준단가가져오기();
            }
        }

        private void 기준단가가져오기()
        {
            txtStandardPrice.Text = 1234.ToString();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtStandardPrice.Text, out var standardPrice))
            {

            }
            else
            {
                standardPrice = 0; 
            }

            List<UserPriceData> twenty = new List<UserPriceData>();
            for (int i = 0; i < 21; i++)
            {
                int now = i + DateTime.Now.Year; 
                twenty.Add(new UserPriceData { Num = i, Year = now, StandardPrice = standardPrice, UserPrice = standardPrice }); 
            }

            ctlTwentyYears.DataSource = twenty;
            ctlTwentyYears.DataBind(); 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string[] userPrices = Request.Form.GetValues("txtUserPrice");
            string[] numbers = Request.Form.GetValues("hdnNum");
            string[] standardPrices = Request.Form.GetValues("hdnStandardPrice");
            string[] years = Request.Form.GetValues("hdnYear");

            List<UserPriceData> twenty = new List<UserPriceData>();
            for (int i = 0; i < 21; i++)
            {
                if (double.TryParse(userPrices[i], out var userPrice))
                {

                }
                else
                {
                    userPrice = 0;
                }
                if (int.TryParse(numbers[i], out var index))
                {

                }
                else
                {
                    index = 0;
                }
                if (double.TryParse(standardPrices[i], out var standardPrice))
                {

                }
                else
                {
                    standardPrice = 0;
                }
                if (int.TryParse(years[i], out var year))
                {

                }
                else
                {
                    year = 0;
                }

                twenty.Add(new UserPriceData { Num = index, Year = year, StandardPrice = standardPrice, UserPrice = userPrice });
            }

            ctlSavedData.DataSource = twenty;
            ctlSavedData.DataBind();
        }
    }
}
